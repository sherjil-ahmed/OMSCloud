using SharpMemoryCache;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace OMSCloud.Contracts.Caching
{
    public class InMemoryCacheProvider : ICacheProvider
    {
        private const string MemoryLimitPercent = "80";

        private MemoryCache mc = CreateMemoryCache();
        private object mcLock = new object();
        private long RefreshIntervalMilliseconds = 1000 * 60 * 5; // 5 minute cache

        public InMemoryCacheProvider()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expireAfterMilliseconds"> pass milliseconds after which the cache should expire. Pass -1 to set cache to never expire</param>
        public InMemoryCacheProvider(long expireAfterMilliseconds)
        {
            RefreshIntervalMilliseconds = expireAfterMilliseconds;
        }

        public void Initialize()
        {
            lock (mcLock)
            {
                mc.Dispose();
                // no more 
                mc = CreateMemoryCache();
            }
        }
        public object this[string key]
        {
            get
            {
                try
                {

                    lock (mcLock)
                    {
                        if (mc.Contains(key))
                        {
                            return mc.Get(key);
                        }
                        return null;
                    }
                }
                catch
                {
                    this.RecentlyFailed = true;
                    throw;
                }
            }
            set
            {
                try
                {
                    lock (mcLock)
                    {
                        // auto-expire stuff within 5 minutes
                        var policy = new CacheItemPolicy
                        {
                            AbsoluteExpiration = RefreshIntervalMilliseconds == -1 ?
                                System.Runtime.Caching.ObjectCache.InfiniteAbsoluteExpiration :
                                DateTimeOffset.UtcNow.AddMilliseconds(RefreshIntervalMilliseconds)
                        };
                        mc.Set(key, value, policy);
                    }
                }
                catch
                {
                    this.RecentlyFailed = true;
                    throw;
                }
            }
        }
        public bool RemoveWithResult(string key)
        {
            try
            {
                lock (mcLock)
                {
                    if (mc.Contains(key))
                    {
                        mc.Remove(key);
                        return true;
                    }
                    return false;
                }
            }
            catch
            {
                this.RecentlyFailed = true;
                return false;
            }
        }
        public void Remove(string key)
        {
            try
            {
                lock (mcLock)
                {
                    if(mc.Contains(key))
                        mc.Remove(key);
                }
            }
            catch
            {
                this.RecentlyFailed = true;
                throw;
            }
        }
        int removedCount = 0;
        public void Add(string key, object value)
        {
            try
            {
                lock (mcLock)
                {
                    // auto-expire stuff within 5 minutes
                    var policy = new CacheItemPolicy
                    {
                        AbsoluteExpiration = RefreshIntervalMilliseconds == -1 ?
                                System.Runtime.Caching.ObjectCache.InfiniteAbsoluteExpiration :
                                DateTimeOffset.UtcNow.AddMilliseconds(RefreshIntervalMilliseconds)
                        /*,
                        RemovedCallback = new CacheEntryRemovedCallback((a) =>
                        {
                            Interlocked.Increment(ref removedCount);
                            if (removedCount % 500000 == 0)
                            {
                                Console.WriteLine("Removed " + removedCount);
                                Console.WriteLine("Remaining " + GetCount());
                            }
                        })*/
                    };
                    mc.Set(key, value, policy);
                }
            }
            catch
            {
                this.RecentlyFailed = true;
                throw;
            }
        }
        public void AddOrUpdate(string key, object value)
        {
            try
            {
                lock (mcLock)
                {
                    // auto-expire stuff within 5 minutes
                    var policy = new CacheItemPolicy
                    {
                        AbsoluteExpiration = RefreshIntervalMilliseconds == -1 ?
                                System.Runtime.Caching.ObjectCache.InfiniteAbsoluteExpiration :
                                DateTimeOffset.UtcNow.AddMilliseconds(RefreshIntervalMilliseconds)
                        /*,
                        RemovedCallback = new CacheEntryRemovedCallback((a) =>
                        {
                            Interlocked.Increment(ref removedCount);
                            if (removedCount % 500000 == 0)
                            {
                                Console.WriteLine("Removed " + removedCount);
                                Console.WriteLine("Remaining " + GetCount());
                            }
                        })*/
                    };
                    if (mc.Contains(key))
                        mc.Remove(key);
                    mc.Set(key, value, policy);
                }
            }
            catch
            {
                this.RecentlyFailed = true;
                throw;
            }
        }
        public void Clear()
        {
            try
            {
                lock (mcLock)
                {
                    mc.Dispose();
                    mc = CreateMemoryCache();
                }
            }
            catch
            {
                this.RecentlyFailed = true;
                throw;
            }
        }
        private static TrimmingMemoryCache CreateMemoryCache()
        {
            // have to use this trimming memoyr cache due to bugs in .net
            // https://stackoverflow.com/questions/6895956/memorycache-does-not-obey-memory-limits-in-configuration
            return new TrimmingMemoryCache("avanturebytes",
                    // 50% of memory max
                    new NameValueCollection { { "physicalMemoryLimitPercentage", MemoryLimitPercent } }                   
                );
        }
        public bool RecentlyFailed
        {
            get;
            set;
        }
        public void ResetFailure()
        {
            this.RecentlyFailed = false;
        }
        public long GetCount()
        {
            return mc.GetCount();
        }
        public long GetCount(string key)
        {
            var count = (from c in mc
                          where c.Key.Contains(key)
                          select c).Count();
            return count;
        }
        
    }
}