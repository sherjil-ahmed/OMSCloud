using Framework.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.DataStore.EF.OMSModel
{
    public class ConcurrentBaseEntity : BaseEntity
    {
        //Just an Indicator Class, actual fields are in POCO-Entity Classes
        //Since we have adopted Hybrid Approach to EF, Entities are being auto generated and can not be manually Modified
    }
}
