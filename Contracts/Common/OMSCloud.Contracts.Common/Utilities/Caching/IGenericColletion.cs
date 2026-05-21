using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Common.Utilities.Caching
{
    public interface IGenericColletion
    {
        int Count { get; }
        bool DisableDisposing_Object_Is_Cached { get; set; }
        void AcceptChanges();
    }
}
