using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Proxies.WebAPI
{
    public class NotificationControllerProxy : BaseControllerProxy
    {
        public List<NotifyModel> GetNotifyList(long? ReceiverId = null, long? NotificationType = null)
        {
            string uri = "api/Notification/GetNotifyList?ReceiverId="+ ReceiverId + "&NotificationType=" + NotificationType;

            var result = WebApiClient.Get<List<NotifyModel>>(uri);
            return result;
        }
        public Boolean SendNotification(NotificationModel model)
        {
            string uri = "api/Notification/SendNotification";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;
        }
        public Boolean SendCacheRebuildNotification()
        {
            string uri = "api/Notification/SendCacheRebuildNotification";

            var result = WebApiClient.Post<Boolean>(uri, null);
            return result;
        }

        public List<NotificationModel> GetNotification(Int64 Id)
        {
            string uri = "api/Notification/GetNotification/" + Id.ToString() + "";

            var result = WebApiClient.Get<List<NotificationModel>>(uri, true);
            return result;

        }
    }
}
