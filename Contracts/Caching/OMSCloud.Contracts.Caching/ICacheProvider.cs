using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Caching
{
    public interface ICacheableEntity { }
    public interface ICacheProvider
    {
        //ICacheProvider GetCache();

        void Initialize();

        object this[string key] { get; set; }

        void Remove(string key);

        void Add(string key, object value);

        void Clear();

        bool RecentlyFailed { get; set; }

        void ResetFailure();
    }
}
