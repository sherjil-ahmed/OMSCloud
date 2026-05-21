using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace OMSCloud.Contracts.Common.Utilities.Caching
{
    public class CacheFactory
    {
        public static ICache CreateCache(string name)
        {
            string cacheType = (ConfigurationManager.AppSettings["CacheType"] != null) ?
                ConfigurationManager.AppSettings["CacheType"].ToString()
                : "Inproc";
            return CreateCache(name, cacheType);
        }

        public static ICache CreateCache(string name, string cacheType)
        {
            switch (cacheType.ToLower())
            {
                case "dist":

                    return MemCached.CreateCacheObject(name);

                default:

                    return Cache.CreateCacheObject(name);
            }
        }
    }
}
