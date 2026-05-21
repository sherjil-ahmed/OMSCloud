using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class NotifyAdapter
    {
        public List<NotifyModel> GetNotifyList(long? ReceiverId, long? NotificationType)
        {
            var result = (from n in uow.OMSContext.Notify
                          join p in uow.OMSContext.Profile on n.SenderProfileId equals p.ProfileID into outter
                          from sub in outter.DefaultIfEmpty()
                          select new NotifyModel {
                              NotificationId = n.NotificationId,
                              NotificationType = n.NotificationType,
                              Message = n.Message,
                              ReceiverProfileId = n.ReceiverProfileId,
                              SenderProfileId = n.SenderProfileId,
                              SenderProfileName = sub.FirstName + ", " + sub.LastName,
                              SubjectRowID = n.SubjectRowID,
                              StatusId = n.StatusId,
                              CreatedBy = n.CreatedByUserID,
                              CreatedOn = n.CreatedDateTime,
                              ModifiedBy = n.LastModifiedByUserID,
                              ModifiedOn = n.LastModifiedDateTime,
                          });
            if (ReceiverId.HasValue)
                result = result.Where(n => n.ReceiverProfileId == ReceiverId.Value);
            if (NotificationType.HasValue)
                result = result.Where(n => n.NotificationType == NotificationType.Value);
            return result.ToList();
        }
    }
}
