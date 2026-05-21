using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Common.DBEnums
{
    public enum DBStatusEnum
    {
        [Description("Approved")]
        Approved = 1,
        [Description("Active")]
        Active = 2,
        [Description("InActive")]
        InActive = 3,
        [Description("Deleted")]
        Deleted = 4,
        [Description("Expired")]
        Expired = 5,
        [Description("None")]
        None = 6
    }
}
