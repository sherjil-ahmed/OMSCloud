using Microsoft.AspNet.SignalR;
using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Services.WebAPIs.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static OMSCloud.Contracts.Common.NLogger;

namespace OMSCloud.Services.WebAPIs.Hubs
{
    public class ChatHub : Hub
    {
        private static IHubContext hubContext =
        GlobalHost.ConnectionManager.GetHubContext<ChatHub>();

        public static void SendChat(NotificationModel message)
        {
            if (message == null || message.ChatID <= 0 || message.ReceiverProfileID <= 0 || message.SenderProfileID <= 0)
            {
                throw new ArgumentException("either message == null || message.ChatID <= 0 || message.ReceiverProfileID <= 0 || message.SenderProfileID <= 0");
            }
            message.NotificationType = NotificationTypeEnum.Chat;
            NotificationHub.UpdateNotification(message);
            List<string> connections = ActiveChatClients.Instance.GetClientID(message.ReceiverProfileID);
            foreach (string connectionID in connections)
            {
                hubContext.Clients.Client(connectionID).chatMessage(message);
            }
            ExpoNotificationHub.SendPushNotification(message.ReceiverProfileID, message);// "You received a new chat message in Zvonr", message.Message, message.ChatTime);
            NotificationHub.AddChatMessage(message);
            //SendChatMessageOverEmail(message);
        }

        private static void SendChatMessageOverEmail(NotificationModel message)
        {
            Log.Debug("sending chat message over email. message.SenderProfileID : " + message.SenderProfileID);
            try
            {
                ProfileBusinessComponent pbc = new ProfileBusinessComponent();
                ProfileModel sender = pbc.GetProfileByProfileId(message.SenderProfileID);
                if (sender != null)
                {
                    NotificationHub.SendEmail("You received a new chat message in Zvonr", message.ReceiverProfileID, message.Message);
                }
                else
                {
                    ErrorLog.Error("chat send message - sender is null. message.SenderProfileID: " + message.SenderProfileID + ", receiverProfileID : " + message.ReceiverProfileID + ",  message.ReceiverProfileID" + message.ReceiverProfileID);
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "ExceptionMessage : chat send message - sender is null. message.SenderProfileID: " + message.SenderProfileID + ", receiverProfileID : " + message.ReceiverProfileID + ",  message.ReceiverProfileID" + message.ReceiverProfileID);
            }
            finally
            {

            }
        }

        public static void SendChat(NotificationModel message, List<long> list)
        {
            if (message == null || message.ChatID <= 0 || message.ReceiverProfileID <= 0 || message.SenderProfileID <= 0)
            {
                throw new ArgumentException("either message == null || message.ChatID <= 0 || message.ReceiverProfileID <= 0 || message.SenderProfileID <= 0");
            }
            foreach (long profileID in list)
            {
                message.ReceiverProfileID = profileID;
                SendChat(message);
            }
        }        
        public void ReceiveMessage(NotificationModel message, long recieverProfileID)
        {
            if (message == null || message.ChatID <= 0 || message.ReceiverProfileID <= 0 || message.SenderProfileID <= 0)
            {
                throw new ArgumentException("either message == null || message.ChatID <= 0 || message.ReceiverProfileID <= 0 || message.SenderProfileID <= 0");
            }
            string connectionID = Context.ConnectionId;
            if (recieverProfileID > 0)
            {
                message.NotificationTime = DateTime.Now;
                message.NotificationType = NotificationTypeEnum.Chat;
                message.ReceiverProfileID = recieverProfileID;
                SendChat(message);
            }
        }        
        public override Task OnConnected()
        {
            if (Context.QueryString["ProfileID"] != null)
            {
                long profileID = Convert.ToInt64(Context.QueryString["ProfileID"]);                
                string connectionID = Context.ConnectionId;

                ActiveChatClients.Instance.AddClient(profileID, connectionID);                

                return base.OnConnected();
            }
            else
            {
                return base.OnDisconnected(false);
            }
        }
        public override Task OnDisconnected(bool stopCalled)
        {            
            string connectionID = Context.ConnectionId;

            ActiveChatClients.Instance.RemoveClient(connectionID);            

            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected()
        {
            if (Context.QueryString["ProfileID"] != null)
            {
                long? profileID = Convert.ToInt64(Context.QueryString["ProfileID"]);
                string connectionID = Context.ConnectionId;

                if (profileID.HasValue)
                    ActiveChatClients.Instance.AddClient(profileID.Value, connectionID);
                else
                    return base.OnDisconnected(false);

                return base.OnReconnected();
            }
            else
            {
                return base.OnDisconnected(false);
            }
        }
    }
} 