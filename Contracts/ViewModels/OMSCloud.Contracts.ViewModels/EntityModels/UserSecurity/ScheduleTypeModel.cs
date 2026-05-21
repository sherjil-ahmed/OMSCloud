using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    class ScheduleTypeModel : BaseModel
    {
        public long ScheduleTypeID { get; set; }
        public string ScheduleType { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public long StatusID { get; set; }
    }
}
