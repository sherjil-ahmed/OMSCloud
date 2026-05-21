using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Memcached.ClientLibrary;
using System.Configuration;
using System.Runtime.Caching;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace OMSCloud.Contracts.Common.Utilities.Caching
{
    public class MemCached : ICache
    {
        MemcachedClient mc = null;

        //private List<KeyValuePair<string, DateTime>> m_keys = new List<KeyValuePair<string, DateTime>>();
        private object CacheLocker = new object();
        private SortedList<string, CacheLoaderInfo> CacheLoaders = new SortedList<string, CacheLoaderInfo>();
        public static ICache m_CacheObject = null;
        private MemCached(string name)
        {
            CacheName = name;
            string[] serverlist = ConfigurationManager.AppSettings["Servers"].Split(',');
            // initialize the pool for memcache servers
            InitSocketPool(serverlist);

            // get client instance
            mc = new MemcachedClient();
            mc.EnableCompression = (ConfigurationManager.AppSettings["EnableCompression"] == "1") ? true : false;
        }

        public string CacheName { get; set; }

        public List<KeyValuePair<string, DateTime>> Keys
        {
            get { return (List<KeyValuePair<string, DateTime>>)mc.Get("KEYS"); }
            set { mc.Set("KEYS", value); }
        }

        public static ICache CreateCacheObject(string name)
        {
            if (m_CacheObject == null)
            {
                m_CacheObject = new MemCached(name);
            }
            return m_CacheObject;
        }

        public void ExecuteDataLoaders()
        {
            foreach (var info in CacheLoaders)
            {
                //Get(info.Key);
            }
        }

        public object Get(String Key, CacheLoaderDelegate CacheLoader, CacheItemPolicy Policy)
        {
            object item;

            item = mc.Get(Key);
            //item = this[Key];

            if (item == null) //Load Data Through Loader
            {
                lock (CacheLocker)
                {
                    item = mc.Get(Key);
                    //item = this[Key]; //Re-verification. May be any other thread has loaded it.
                    if (item == null)
                    {
                        item = CacheLoader();
                        if (item != null)
                        {
                            if (mc.Set(Key, item))
                            {
                                List<KeyValuePair<string, DateTime>> keys = Keys;
                                if (keys == null)
                                    keys = new List<KeyValuePair<string, DateTime>>();

                                keys.Add(new KeyValuePair<string, DateTime>(Key, System.DateTime.Now));
                                Keys = keys;
                            }
                            //this.Add(Key, item, Policy);
                        }
                    }
                }
            }

            if (item != null)
            {
                //Returning a clone of the object
                MemoryStream stream = new MemoryStream();
                Type[] t = new Type[1];
                t[0] = item.GetType();
                //Serialize the Record object to a memory stream using DataContractSerializer.
                DataContractSerializer serializer = new DataContractSerializer(item.GetType(), t);
                serializer.WriteObject(stream, item);

                string serialized = Encoding.UTF8.GetString(stream.ToArray());
                stream = new MemoryStream(Encoding.UTF8.GetBytes(serialized));
                XmlReader reader = XmlReader.Create(new StringReader(serialized));
                var obj = serializer.ReadObject(stream);

                return obj;
            }
            else
                return item;
        }

        private void InitSocketPool(string[] serverlist)
        {
            SockIOPool pool = SockIOPool.GetInstance();
            pool.SetServers(serverlist);
            pool.InitConnections = int.Parse(ConfigurationManager.AppSettings["InitConnections"]);
            pool.MinConnections = int.Parse(ConfigurationManager.AppSettings["MinConnections"]);
            pool.MaxConnections = int.Parse(ConfigurationManager.AppSettings["MaxConnections"]);
            pool.SocketConnectTimeout = int.Parse(ConfigurationManager.AppSettings["SocketConnectTimeout"]);
            pool.SocketTimeout = int.Parse(ConfigurationManager.AppSettings["SocketTimeout"]);
            pool.MaintenanceSleep = int.Parse(ConfigurationManager.AppSettings["MaintenanceSleep"]);
            pool.Failover = (ConfigurationManager.AppSettings["Failover"] == "1") ? true : false;
            pool.Nagle = (ConfigurationManager.AppSettings["Nagle"] == "1") ? true : false;

            pool.HashingAlgorithm = HashingAlgorithm.NewCompatibleHash;

            pool.Initialize();
        }

        public void RegisterDataLoader(string key, CacheLoaderDelegate CacheLoader, CacheItemPolicy Policy)
        {
            lock (CacheLocker)
            {
                CacheLoaderInfo Cacheinfo = new CacheLoaderInfo();
                Cacheinfo.CacheLoader = CacheLoader;
                Cacheinfo.Policy = Policy;
                CacheLoaders[key] = Cacheinfo;
            }
        }

        public bool UnRegisterDataLoader(string key, CacheLoaderDelegate CacheLoader)
        {
            bool sts = true;

            lock (CacheLocker)
            {
                sts = CacheLoaders.Remove(key);
            }

            return sts;
        }


        private struct CacheLoaderInfo
        {
            public CacheLoaderDelegate CacheLoader;
            public CacheItemPolicy Policy;
        }

        public void RemoveCache(string key)
        {
            mc.Delete(key);
            //this.Remove(key);
        }


        public bool Contains(string key)
        {
            return mc.KeyExists(key);
        }

        public object Get(string key)
        {
            return mc.Get(key);
        }

        public void RemoveKey(string key)
        {
            List<KeyValuePair<string, DateTime>> keys = Keys;
            if (keys == null)
                keys = new List<KeyValuePair<string, DateTime>>();

            keys.RemoveAll(p => p.Key.Contains(key));
            Keys = keys;
        }

        public void Set(string key, object item)
        {
            if (item != null)
            {
                if (mc.Set(key, item))
                {
                    List<KeyValuePair<string, DateTime>> keys = Keys;
                    if (keys == null)
                        keys = new List<KeyValuePair<string, DateTime>>();

                    keys.Add(new KeyValuePair<string, DateTime>(key, System.DateTime.Now));
                    Keys = keys;
                }
            }
        }
    }
}
