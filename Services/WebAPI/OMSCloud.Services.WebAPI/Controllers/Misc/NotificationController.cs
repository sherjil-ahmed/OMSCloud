using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Services.WebAPIs.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using static OMSCloud.Contracts.Common.NLogger;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class NotificationController : ApiController
    {

        [ReturnType(DataType = typeof(bool))]
        [HttpPost]
        public IHttpActionResult SendNotification(NotificationModel model)
        {
            //Log.Info("public IHttpActionResult SendNotification(NotificationModel model). Msg: " + model.Message);
            model.NotificationTime = DateTime.Now;
            if (model.ReceiverProfileID > 0)
                NotificationHub.SendNotification(model, model.ReceiverProfileID);
            else
            {                
                NotificationHub.SendNotification(model);
            }
            return Ok<bool>(true);
        }

        [ReturnType(DataType = typeof(bool))]
        [HttpPost]
        public IHttpActionResult SendCacheRebuildNotification()
        {
            NotificationModel model = new NotificationModel();
            model.NotificationType = NotificationTypeEnum.CacheRebuild;
            model.SenderProfileID = 0;
            model.ReceiverProfileID = 0;
            model.Message = "Cache Rebuild";
            model.NotificationTime = DateTime.Now;
            model.SubjectRowID = 0;
            NotificationHub.SendNotification(model);
            
            return Ok<bool>(true);
        }

        [ReturnType(DataType = typeof(List<NotificationModel>))]
        [HttpGet]
        public IHttpActionResult GetNotification(long Id)
        {
            return Ok<List<NotificationModel>>(NotificationHub.GetNotification(Id));
        }

        //public List<NotifyModel> GetNotifyList(long? ReceiverId, long? NotificationType)
        [ReturnType(DataType = typeof(List<NotifyModel>))]
        [HttpGet]
        public IHttpActionResult GetNotifyList(long? ReceiverId, long? NotificationType)
        {
            return Ok<List<NotifyModel>>(comp.GetNotifyList(ReceiverId, NotificationType));
        }
    }
}
