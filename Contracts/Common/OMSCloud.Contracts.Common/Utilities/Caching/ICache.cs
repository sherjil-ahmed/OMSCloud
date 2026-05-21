using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

namespace OMSCloud.Contracts.Common.Utilities.Caching
{
    public interface ICache
    {
        string CacheName { get; set; }

        List<KeyValuePair<string, DateTime>> Keys { get; set; }

        bool Contains(string key);

        object Get(string key);

        object Get(String Key, CacheLoaderDelegate CacheLoader, CacheItemPolicy Policy);

        void ExecuteDataLoaders();

        void RegisterDataLoader(string key, CacheLoaderDelegate CacheLoader, CacheItemPolicy Policy);

        bool UnRegisterDataLoader(string key, CacheLoaderDelegate CacheLoader);

        void RemoveCache(string key);

        void RemoveKey(string key);

        void Set(string key, object item);
    }


}
