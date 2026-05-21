using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Services.WebAPIs.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class ChatController : ApiController
    {
        [ReturnType(DataType = typeof(bool))]
        [HttpPost]
        public IHttpActionResult SendChatMessage(NotificationModel model)
        {
            NotificationHub hub = new NotificationHub();
            hub.ReceiveMessage(model);
            return Ok<bool>(true);
        }


        [ReturnType(DataType = typeof(bool))]
        [HttpPost]
        public IHttpActionResult SendChat(NotificationModel model)
        {
            if (model == null || model.ChatID <= 0 || model.ReceiverProfileID <= 0 || model.SenderProfileID <= 0)
            {
                throw new ArgumentException("either message == null || message.ChatID <= 0 || message.ReceiverProfileID <= 0 || message.SenderProfileID <= 0");
            }
            model.NotificationTime = DateTime.Now;
            model.NotificationType = NotificationTypeEnum.Chat;
            if (model.ReceiverProfileID > 0)
                ChatHub.SendChat(model);

            return Ok<bool>(true);
        }

        [ReturnType(DataType = typeof(long))]
        public IHttpActionResult InitiateChat(long sender, long receiver)
        {
            return Ok(comp.InitiateChat(sender, receiver));
        }

        [ReturnType(DataType = typeof(List<ChatModel>))]
        public IHttpActionResult GetChatListByProfileId(long Id)
        {
            return Ok(comp.GetChatListByProfileId(Id));
        }

        [ReturnType(DataType = typeof(long))]
        public IHttpActionResult GetUnreadChatCountByProfileId(long Id)
        {
            return Ok(comp.GetUnreadChatCountByProfileId(Id));
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult RemoveChatMessages(string chatMessageCSV)
        {
            if (string.IsNullOrEmpty(chatMessageCSV))
                return BadRequest("Empty list of Shop Ids. Nothing to process.");
            var ListString = chatMessageCSV.Split(',');
            List<long> chatMessageListLong = new List<long>();
            foreach (var id in ListString)
            {
                long x = 0;
                Int64.TryParse(id, out x);
                chatMessageListLong.Add(x);
            }
            if (comp.RemoveChatMessages(chatMessageListLong))
            {
                //foreach (var id in chatMessageListLong)
                //{
                //    SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Shop, id);
                //}
                return Ok<bool>(true);
            }
            return Conflict();
        }
    }
}
