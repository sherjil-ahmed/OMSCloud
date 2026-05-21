using OMSCloud.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public partial class NotificationModel
    {
        public long SenderProfileID { get; set; }
        public string SenderName { get; set; }
        public long ReceiverProfileID { get; set; }
        public string ReceiverName { get; set; }
        public string Message { get; set; }        
        public DateTime NotificationTime { get; set; }
        public NotificationTypeEnum NotificationType { get; set; }
        public string NotificationTypeString { get; set; }
        public long ChatID { get; set; }
        public long SubjectRowID { get; set; }
    }

    public partial class NotifyModel : ConcurrencyBaseModel
    {
        public long NotificationId { get; set; }
        public long NotificationType { get; set; }
        public long SenderProfileId { get; set; }
        public string SenderProfileName { get; set; }
        public long ReceiverProfileId { get; set; }
        public long StatusId { get; set; }
        public string Message { get; set; }
        public long SubjectRowID { get; set; }
    }
}
