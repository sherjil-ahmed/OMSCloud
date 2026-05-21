using System;
using System.Web;
using System.Linq;
using System.Configuration;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OMSCloud.Contracts.Common;


namespace OMSCloud.Contracts.Caching
{
    public class CacheableAttribute : Attribute
    {
        public string Prefix { get; set; }
        public object Locker { get; set; } = new object();
    }
    /// <summary>
    /// Simple helper class to access the cache nicely wrapped up
    /// </summary>
    public class CacheManager
    {
        #region MiscConfiguration
        // use this when there are breaking changes in the cache - it ensures we don't blow up anything already
        // in place when we go to beta
        //private const string Version = "3";

        //private static ILog Log = LogManager.GetLogger(typeof(CacheManager));



        // remote cache lasts for 60 mins
        //private static int RemoteCacheLengthMinutes = 60;

        // re-check the cache provider every hour
        #if DEBUG
                private static int CACHE_PROVIDER_RECHECK_SECONDS = 60 * 1;
        #else
                private static int CACHE_PROVIDER_RECHECK_SECONDS = 60 * 60; 
        #endif

        #endregion MiscConfiguration

        #region Misc Data Members
        private static DateTime? lastCachePriorityCheck = null;
        private static List<ICacheProvider> cacheProviders = new List<ICacheProvider>();
        private static int currentCacheProvider = 0;
        #endregion Misc Data Members

        #region Constructor
        static CacheManager()
        {
            var cp = new InMemoryCacheProvider(-1);
            cp.Initialize();
            cacheProviders.Add(cp);
            
        }

        private static ICacheProvider Cache
        {
            get
            {
                var provider = cacheProviders[currentCacheProvider];

                var forcedSwap = false;
                if (currentCacheProvider > 0)
                {
                    // we're using a non-preferred cache provider
                    // check every so often to see if we can swap back
                    if (lastCachePriorityCheck == null || lastCachePriorityCheck.Value.IsOlderThan(CACHE_PROVIDER_RECHECK_SECONDS))
                    {
                        lastCachePriorityCheck = DateTime.UtcNow;
                        provider.RecentlyFailed = true;
                        forcedSwap = true;
                    }
                }

                // cache providers are responsible for monitoring their own failures
                // if they fail, we move to an alternative and attempt to use that instead.
                if (provider.RecentlyFailed)
                {
                    // save the old type for the log, and reset the failure
                    var old = provider.GetType();
                    provider.ResetFailure();

                    // bump to the next and roll over
                    currentCacheProvider++;
                    if (currentCacheProvider > cacheProviders.Count - 1)
                    {
                        currentCacheProvider = 0;
                    }

                    // immediately use the new provider
                    provider = cacheProviders[currentCacheProvider];

                    if (forcedSwap)
                    {
                        //Log.Fatal("RE-CHECKING CACHE PROVIDER! Switching from " + old + " to " + provider.GetType());
                        provider.Initialize();
                    }
                    else
                    {
                        //Log.Fatal("CACHE FAILURE! Switching from " + old + " to " + provider.GetType());
                    }

                    // save the time
                    lastCachePriorityCheck = DateTime.UtcNow;
                }
                return provider;
            }
        }
        #endregion Constructor

        private static Dictionary<string, object> lockers = new Dictionary<string, object>();
        public static object GetThreadLockerObject(string prefix, string key)
        {
            object returnLocker = null;
            if (lockers.ContainsKey(prefix + key))
            {
                returnLocker = lockers[prefix + key];
            }
            if (returnLocker == null)
            {
                returnLocker = new object();
                lockers[prefix + key] = returnLocker;
            }
            return returnLocker;
        }

        /// <summary>
        /// gets an item from cache
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="prefix"></param>
        /// <param name="key"></param>
        /// <param name="cache">this is nullable, if this argument is provided that will be used, othersise default Cache will be used</param>
        /// <returns></returns>
        public static T Get<T>(string prefix, string key, ICacheProvider cache = null) //where T : class
        {
            cache = cache ?? Cache;

            var obj = cache[prefix + key];
            T result = (T)obj;// (obj != null && obj is T) ? obj as T : null;
            return result;
        }

        private static Nullable<T> GetForValueType<T>(string prefix, string key, ICacheProvider cache = null) where T : struct
        {
            cache = cache ?? Cache;
            Nullable<T> result = null;
            throw new NotImplementedException("Function CacheManager.GetForValueType is not yet implemented.");
            //try
            //{
            //    result = (T)cache[prefix + key, typeof(T)];
            //}
            //catch
            //{
            //}

            return result;
        }

        /// <summary>
        /// Sets an items in cache
        /// </summary>
        /// <param name="prefix"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="cache"> this is nullable, if this argument is provided that will be used, othersise default Cache will be used</param>
        public static void Set(string prefix, string key, object value, ICacheProvider cache = null)
        {
            cache = cache ?? Cache;
            if (cache[prefix + key] != null)
            {
                cache[prefix + key] = value;
            }
            else
            {
                try
                {
                    cache.Add(prefix + key, value);

                }
                catch (Exception e)
                {
                    // already exists, update it
                    cache[prefix + key] = value;
                }
            }
        }

        public static void Remove(string prefix, string key)
        {
            Cache.Remove(prefix + key);
        }

        public static void ClearCache()
        {
            if (Cache is InMemoryCacheProvider)
            {
                var c = Cache as InMemoryCacheProvider;
                c.Clear();
            }
        }
            public static void RemoveAllLike(string country, string partialKey = "")
        {
            if (Cache is InMemoryCacheProvider)
            {
                var c = Cache as InMemoryCacheProvider;
                //var count1 = c.GetCount(partialKey);
                var keys = (from l in lockers
                            where l.Key.StartsWith(country) && l.Key.Contains(partialKey)
                            select c.RemoveWithResult(l.Key)).ToList();
                int count = keys.Count();
                //return count1 == count;
            }
            else
            {
                var keys = (from l in lockers
                            where l.Key.StartsWith(country) && l.Key.Contains(partialKey)
                            select l.Key).ToList();
                foreach (var key in keys)
                {
                    Cache.Remove(key);
                }
            }
        }

        public static void Remove(string completeKey)
        {
            Cache.Remove(completeKey);
        }
    }
}
