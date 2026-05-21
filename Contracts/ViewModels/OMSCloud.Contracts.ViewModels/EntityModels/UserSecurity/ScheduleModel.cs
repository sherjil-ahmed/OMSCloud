using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ScheduleModel : ConcurrencyBaseModel
    {
        public long ScheduleID { get; set; }
        public long? ShopID { get; set; }
        public long? ScheduleTypeID { get; set; }
        public bool IsException { get; set; }
        public short? FromDay { get; set; }
        public short? ToDay { get; set; }
        public short? Month { get; set; }
        public short? MonthDay { get; set; }
        public string WeekDays { get; set; }
        public long? StatusID { get; set; }
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }

    public class ScheduleDisplayModel : ScheduleWeekdaysModel
    {
        public string ShopName { get; set; }
        public string ScheduleTypeTitle { get; set; }
        public string StatusTitle { get; set; }
    }

    public class ScheduleWeekdaysModel : ScheduleModel
    {
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }
    }
}