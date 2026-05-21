using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Configuration;


namespace OMSCloud.Contracts.Common.Utilities.Caching
{
    public delegate object CacheLoaderDelegate();

    public class Cache : System.Runtime.Caching.MemoryCache, ICache
    {
        //TODO: HACK: Remove below line, is for testing only
        public static bool UseOldCode = false;

        private List<KeyValuePair<string, DateTime>> m_keys = new List<KeyValuePair<string, DateTime>>();
        private object CacheLocker = new object();
        private SortedList<string, CacheLoaderInfo> CacheLoaders = new SortedList<string, CacheLoaderInfo>();
        public static ICache m_CacheObject = null;
        public bool IsCacheEnabled { get; set; }
        public Cache(string name)
            : base(name)
        {
            if (ConfigurationManager.AppSettings["EnableLocalCache"] != null && ConfigurationManager.AppSettings["EnableLocalCache"] == "0")
                IsCacheEnabled = false;
            else
                IsCacheEnabled = true;

        }

        public override object Remove(string key, string regionName = null)
        {
            var target = base.Remove(key, regionName);
            if (null != target && target is IGenericColletion)
                ((IGenericColletion)target).DisableDisposing_Object_Is_Cached = false;

            return target;
        }
        public string CacheName { get; set; }

        public List<KeyValuePair<string, DateTime>> Keys { get { return m_keys; } set { m_keys = value; } }

        public static ICache CreateCacheObject(string name)
        {
            if (m_CacheObject == null)
            {
                m_CacheObject = new Cache(name);
            }
            return m_CacheObject;
        }

        public void ExecuteDataLoaders()
        {
            foreach (var info in CacheLoaders)
            {
                Get(info.Key);
            }
        }

        // HACK: Benchmark and Optimization – Jun-2015 – Start
        public object Get(String Key, CacheLoaderDelegate CacheLoader, CacheItemPolicy Policy)
        {
            //if (ConfigurationManager.AppSettings["EnableLocalCache"] != null && ConfigurationManager.AppSettings["EnableLocalCache"] == "0")
            //    cacheEnabled = false;

            if (!IsCacheEnabled)
                return CacheLoader();
            else
            {
                object item;
                lock (CacheLocker)
                {
                    item = this[Key];
                }

                if (item == null) //Load Data Through Loader
                {
                    item = CacheLoader();//Load data using delegate
                    if (item != null)
                    {
                        lock (CacheLocker)
                        {
                            var temp = this[Key];//recheck if some other thread has loded data
                            if (null == temp)
                            {
                                this.Add(Key, item, Policy);
                                Keys.Add(new KeyValuePair<string, DateTime>(Key, System.DateTime.Now));
                                if (item is IGenericColletion)
                                    ((IGenericColletion)item).DisableDisposing_Object_Is_Cached = true;
                            }
                        }
                    }
                }

                if (item != null && UseOldCode)
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

        }
        // Benchmark and Optimization – Jun-2015 – End

        //public override object Get(string key, string regionName = null)
        //{
        //    object item = base.Get(key, regionName);

        //    if (item == null)
        //    {
        //        lock (CacheLocker)
        //        {
        //            CacheLoaderDelegate loader = CacheLoaders[key].CacheLoader;
        //            if (loader != null)
        //            {
        //                item = loader();
        //                if (item != null)
        //                {
        //                    this.Add(key, item, CacheLoaders[key].Policy);
        //                    Keys.Add(new KeyValuePair<string, DateTime>(key, System.DateTime.Now));
        //                }
        //            }
        //        }
        //    }
        //    return item;
        //}

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
            this.Remove(key);
        }


        public bool Contains(string key)
        {
            return base.Contains(key);
        }

        public object Get(string key)
        {
            return base.Get(key);
        }

        public void RemoveKey(string key)
        {
            Keys.RemoveAll(p => p.Key.Contains(key));
        }

        public void Set(string key, object item)
        {
            this.Add(key, item, new CacheItemPolicy());
            Keys.Add(new KeyValuePair<string, DateTime>(key, System.DateTime.Now));
        }
    }


}
