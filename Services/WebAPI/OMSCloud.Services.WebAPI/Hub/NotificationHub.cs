using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Services.WebAPIs.Collections;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static OMSCloud.Contracts.Common.NLogger;

namespace OMSCloud.Services.WebAPIs.Hubs
{
    public class NotificationHub : Hub
    {
        private static IHubContext hubContext =
        GlobalHost.ConnectionManager.GetHubContext<NotificationHub>();

        public static void SendNotification(NotificationTypeEnum notificationType, long transactionID)
        {
            try
            {
                if (notificationType == NotificationTypeEnum.Order)
                {
                    #region Order
                    OrderNotification(transactionID);
                    #endregion
                }
                else if (notificationType == NotificationTypeEnum.Review)
                {
                    #region Review
                    ReviewNotification(transactionID);
                    #endregion
                }
                else if (notificationType == NotificationTypeEnum.Product)
                {
                    #region Product
                    ProductNotification(transactionID);
                    #endregion
                }
                else if (notificationType == NotificationTypeEnum.Shop)
                {
                    #region Shop
                    ShopNotification(transactionID);
                    #endregion
                }
            }
            catch(Exception ex)
            {
                NLogger.ErrorLog.Error(ex);
            }
        }
        private static void OrderNotification(long transactionID)
        {
            var obc = new OrderBusinessComponent();
            var order = obc.GetById(transactionID);
            if (order == null)
                return;

            #region Message for Buyer
            string messageForBuyer = "Order " + (string.IsNullOrEmpty(order.OrderNumber) ? order.OrderID.ToString() : order.OrderNumber);
            switch (order.OrderStatusId)
            {
                case (long)DBOrderStatusEnum.NewOrder:
                    messageForBuyer += " has been initiated";
                    break;
                case (long)DBOrderStatusEnum.OrderInProcess:
                    messageForBuyer += " is in process state";
                    break;
                case (long)DBOrderStatusEnum.OrderPlaced:
                    messageForBuyer += " has been placed";
                    break;
                case (long)DBOrderStatusEnum.OrderDispatched_ReadyforPickup:
                    messageForBuyer += " has been dispatched or ready for pickup";
                    break;
                case (long)DBOrderStatusEnum.OrderCompleted:
                    messageForBuyer += " has been completed";
                    break;
                case (long)DBOrderStatusEnum.Order_Delivered_Pickedup:
                    messageForBuyer += " has been delivered or picked up";
                    break;
                case (long)DBOrderStatusEnum.OrderIssueRaisedByBuyer:
                    messageForBuyer += " has some issues raised by buyer.";
                    break;
                case (long)DBOrderStatusAdminEnum.OrderFailed:
                case (long)DBOrderStatusAdminEnum.OrderIssues:
                case (long)DBOrderStatusAdminEnum.Order_Delivery_Pickup_Failed:
                    messageForBuyer += " has some issue which is in failed state";
                    break;
                default:
                    messageForBuyer = "";
                    break;

            }
            #endregion

            #region Message For Shop
            string messageForShop = "Order " + (string.IsNullOrEmpty(order.OrderNumber) ? order.OrderID.ToString() : order.OrderNumber);
            switch (order.OrderStatusId)
            {
                case (long)DBOrderStatusEnum.NewOrder:
                    messageForShop += " has been initiated";
                    break;
                case (long)DBOrderStatusEnum.OrderInProcess:
                    messageForShop += " is in process state";
                    break;
                case (long)DBOrderStatusEnum.OrderPlaced:
                    messageForShop += " has been placed";
                    break;
                case (long)DBOrderStatusEnum.OrderDispatched_ReadyforPickup:
                    messageForShop += " has been dispatched or ready for pickup";
                    break;
                case (long)DBOrderStatusEnum.OrderCompleted:
                    messageForShop += " has been completed";
                    break;
                case (long)DBOrderStatusEnum.Order_Delivered_Pickedup:
                    messageForShop += " has been delivered or picked up";
                    break;
                case (long)DBOrderStatusEnum.OrderIssueRaisedByBuyer:
                    messageForShop += " has some issues raised by buyer.";
                    break;
                case (long)DBOrderStatusAdminEnum.OrderFailed:
                    messageForShop += " has been failed";
                    break;
                case (long)DBOrderStatusAdminEnum.OrderIssues:
                    messageForShop += " has some issues";
                    break;
                case (long)DBOrderStatusAdminEnum.Order_Delivery_Pickup_Failed:
                    messageForShop += " has some issue in delivery or pick up";
                    break;
                default:
                    messageForShop = "";
                    break;
            }
            #endregion

            if (string.IsNullOrEmpty(messageForShop))
                return;
            if (string.IsNullOrEmpty(messageForBuyer))
                return;

            var pbc = new ProfileBusinessComponent();
            var buyerProfile = pbc.GetProfileByProfileId(order.BuyerProfileID);
            if (buyerProfile != null)
            {
                SendEmail("Order Update", buyerProfile.UserID, messageForBuyer);
                SendNotification(NotificationTypeEnum.Order, order.BuyerProfileID, 0, messageForBuyer, transactionID);
            }
            var sbc = new SupplierBusinessComponent();
            var shop = sbc.GetSupplierById(order.ShopID.Value);
            if (shop != null)
            {
                var shopProfile = pbc.GetProfileByProfileId(shop.ProfileID);
                if (shopProfile != null)
                {

                    SendEmail("Order Update", shopProfile.UserID, messageForShop);
                    SendNotification(NotificationTypeEnum.Order, shopProfile.ProfileID, 0, messageForShop, transactionID);
                }
            }
            long marketPlaceProfileID = Convert.ToInt64(Config.MarketPlaceProfileID);
            var marketPlaceProfile = pbc.GetProfileByProfileId(marketPlaceProfileID);
            if (marketPlaceProfile != null)
            {
                SendEmail("Order Update", marketPlaceProfile.UserID, messageForShop);
                SendNotification(NotificationTypeEnum.Order, marketPlaceProfileID, 0, messageForShop, transactionID);
            }
        }
        private static void ReviewNotification(long transactionID)
        {
            var crbc = new CustomerReviewBusinessComponent();
            var review = crbc.GetById(transactionID);
            if (review == null)
                return;

            if (review.SubjectID == (long)CustomerReviewSubjectEnum.Product)
            {
                #region Product Review
                var prbc = new ProductBusinessComponent();
                var product = prbc.GetById(review.SubjectRowID);
                if (product == null)
                    return;

                #region Message for Buyer and Shop
                string messageForBuyer = "Product " + product.ProductTitle;
                string messageForShop = "Product " + product.ProductTitle;
                string messageForMarketPlace = "Product " + product.ProductTitle;
                bool iscont = false;
                switch (review.StatusID)
                {
                    case (long)DBStatusEnum.New:
                        messageForBuyer += " review has been sent to admin for approval";
                        messageForShop += " review has been sent to admin for approval by {0}";
                        messageForMarketPlace += " review has been recieved for approval from {0}";
                        iscont = true;
                        break;
                    case (long)DBStatusEnum.Active:
                        messageForBuyer += " review has been approved by admin";
                        messageForShop += " review of {0} has been approved by admin";
                        messageForMarketPlace += " review of {0} has been approved";
                        iscont = true;
                        break;
                    case (long)DBStatusEnum.InActive:
                        messageForBuyer += " review has been rejected by admin";
                        messageForShop += " review of {0} has been rejected by admin";
                        messageForMarketPlace += " review of {0} has been rejected";
                        iscont = true;
                        break;
                }
                #endregion

                if (!iscont)
                    return;

                var pbc = new ProfileBusinessComponent();

                var buyerProfile = pbc.GetProfileByUserId(review.CreatedBy);
                if (buyerProfile != null)
                {
                    SendEmail("Product Review Update", buyerProfile.UserID, messageForBuyer);
                    SendNotification(NotificationTypeEnum.Review, buyerProfile.ProfileID, 0, messageForBuyer, transactionID);
                }

                var sbc = new SupplierBusinessComponent();
                var shop = sbc.GetSupplierById(product.SupplierID);
                if (shop != null)
                {
                    var shopProfile = pbc.GetProfileByProfileId(shop.ProfileID);
                    if (shopProfile != null)
                    {
                        messageForShop = string.Format(messageForShop, pbc.GetDisplayDescription(buyerProfile));
                        SendEmail("Product Review Update", shopProfile.UserID, messageForShop);
                        SendNotification(NotificationTypeEnum.Review, shopProfile.ProfileID, 0, messageForShop, transactionID);
                    }
                }
                long marketPlaceProfileID = Convert.ToInt64(Config.MarketPlaceProfileID);
                var marketPlaceProfile = pbc.GetProfileByProfileId(marketPlaceProfileID);
                if (marketPlaceProfile != null)
                {
                    messageForMarketPlace = string.Format(messageForMarketPlace, pbc.GetDisplayDescription(buyerProfile));
                    SendEmail("Product Review Update", marketPlaceProfile.UserID, messageForMarketPlace);
                    SendNotification(NotificationTypeEnum.Review, marketPlaceProfileID, 0, messageForMarketPlace, transactionID);
                }
                #endregion
            }
            else if (review.SubjectID == (long)CustomerReviewSubjectEnum.Shop)
            {
                #region Shop Review
                var sbc = new SupplierBusinessComponent();
                var supplier = sbc.GetById(review.SubjectRowID);
                if (supplier == null)
                    return;

                #region Message for Buyer and Shop
                string messageForBuyer = "Shop " + supplier.SupplierName;
                string messageForShop = "Shop " + supplier.SupplierName;
                string messageForMarketPlace = "Shop " + supplier.SupplierName;
                bool iscont = false;
                switch (review.StatusID)
                {
                    case (long)DBStatusEnum.New:
                        messageForBuyer += " review has been sent to admin for approval";
                        messageForShop += " review has been sent to admin for approval from {0}";
                        messageForMarketPlace += " review has been recieved for approval from {0}";
                        iscont = true;
                        break;
                    case (long)DBStatusEnum.Active:
                        messageForBuyer += " review has been approved by admin";
                        messageForShop += " review of {0} has been approved by admin";
                        messageForMarketPlace += " review of {0} has been approved";
                        iscont = true;
                        break;
                    case (long)DBStatusEnum.InActive:
                        messageForBuyer += " review has been rejected by admin";
                        messageForShop += " review of {0} has been rejected by admin";
                        messageForMarketPlace += " review of {0} has been rejected";
                        iscont = true;
                        break;

                }
                #endregion

                if (!iscont)
                    return;

                var pbc = new ProfileBusinessComponent();

                var buyerProfile = pbc.GetProfileByUserId(review.CreatedBy);
                if (buyerProfile != null)
                {
                    SendEmail("Shop Review Update", buyerProfile.UserID, messageForBuyer);
                    SendNotification(NotificationTypeEnum.Review, buyerProfile.ProfileID, 0, messageForBuyer, transactionID);
                }

                var shopProfile = pbc.GetProfileByProfileId(supplier.ProfileID);
                if (shopProfile != null)
                {
                    messageForShop = string.Format(messageForShop, pbc.GetDisplayDescription(buyerProfile));
                    SendEmail("Shop Review Update", shopProfile.UserID, messageForShop);
                    SendNotification(NotificationTypeEnum.Review, shopProfile.ProfileID, 0, messageForShop, transactionID);
                }

                long marketPlaceProfileID = Convert.ToInt64(Config.MarketPlaceProfileID);
                var marketPlaceProfile = pbc.GetProfileByProfileId(marketPlaceProfileID);
                if (marketPlaceProfile != null)
                {
                    messageForMarketPlace = string.Format(messageForMarketPlace, pbc.GetDisplayDescription(buyerProfile));
                    SendEmail("Shop Review Update", marketPlaceProfile.UserID, messageForMarketPlace);
                    SendNotification(NotificationTypeEnum.Review, marketPlaceProfileID, 0, messageForMarketPlace, transactionID);
                }
                #endregion
            }
            else if (review.SubjectID == (long)CustomerReviewSubjectEnum.Order)
            {
                #region Order Review
                var obc = new OrderBusinessComponent();
                var order = obc.GetById(review.SubjectRowID);
                if (order == null)
                    return;

                #region Message for Buyer and Shop
                string messageForBuyer = "Order " + (string.IsNullOrEmpty(order.OrderNumber) ? order.OrderID.ToString() : order.OrderNumber);
                string messageForShop = "Order " + (string.IsNullOrEmpty(order.OrderNumber) ? order.OrderID.ToString() : order.OrderNumber);
                string messageForMarketPlace = "Order " + (string.IsNullOrEmpty(order.OrderNumber) ? order.OrderID.ToString() : order.OrderNumber);
                bool iscont = false;
                switch (review.StatusID)
                {
                    case (long)DBStatusEnum.New:
                        messageForBuyer += " review has been sent to admin for approval";
                        messageForShop += " review has been sent to admin for approval by {0}";
                        messageForMarketPlace += " review has been recieved for approval from {0}";
                        iscont = true;
                        break;
                    case (long)DBStatusEnum.Active:
                        messageForBuyer += " review has been approved by admin";
                        messageForShop += " review of {0} has been approved by admin";
                        messageForMarketPlace += " review of {0} has been approved";
                        iscont = true;
                        break;
                    case (long)DBStatusEnum.InActive:
                        messageForBuyer += " review has been rejected by admin";
                        messageForShop += " review of {0} has been rejected by admin";
                        messageForMarketPlace += " review of {0} has been rejected";
                        iscont = true;
                        break;

                }
                #endregion

                if (!iscont)
                    return;

                var pbc = new ProfileBusinessComponent();

                var buyerProfile = pbc.GetProfileByProfileId(order.BuyerProfileID);
                if (buyerProfile != null)
                {
                    SendEmail("Order Review Update", buyerProfile.UserID, messageForBuyer);
                    SendNotification(NotificationTypeEnum.Review, order.BuyerProfileID, 0, messageForBuyer, transactionID);
                }

                var sbc = new SupplierBusinessComponent();
                var shop = sbc.GetSupplierById(order.ShopID.Value);
                if (shop != null)
                {
                    var shopProfile = pbc.GetProfileByProfileId(shop.ProfileID);
                    if (shopProfile != null)
                    {
                        messageForShop = string.Format(messageForShop, pbc.GetDisplayDescription(buyerProfile));
                        SendEmail("Order Review Update", shopProfile.UserID, messageForShop);
                        SendNotification(NotificationTypeEnum.Review, shopProfile.ProfileID, 0, messageForShop, transactionID);
                    }
                }

                long marketPlaceProfileID = Convert.ToInt64(Config.MarketPlaceProfileID);
                var marketPlaceProfile = pbc.GetProfileByProfileId(marketPlaceProfileID);
                if (marketPlaceProfile != null)
                {
                    messageForMarketPlace = string.Format(messageForMarketPlace, pbc.GetDisplayDescription(buyerProfile));
                    SendEmail("Order Review Update", marketPlaceProfile.UserID, messageForMarketPlace);
                    SendNotification(NotificationTypeEnum.Review, marketPlaceProfileID, 0, messageForMarketPlace, transactionID);
                }
                #endregion
            }
        }
        private static void ProductNotification(long transactionID)
        {
            var prbc = new ProductBusinessComponent();
            var product = prbc.GetById(transactionID);
            if (product == null)
                return;

            #region Message for Shop and Market Place
            string messageForShop = "Product " + product.ProductTitle;
            string messageForMarketPlace = "Product " + product.ProductTitle;
            bool iscont = false;
            switch (product.StatusID)
            {
                case (long)DBStatusEnum.New:
                    messageForShop += " has been sent for approval";
                    messageForMarketPlace += " has been recieved for approval";
                    iscont = true;
                    break;
                case (long)DBStatusEnum.Active:
                    messageForShop += " has been approved";
                    messageForMarketPlace += " has been approved";
                    iscont = true;
                    break;
                case (long)DBStatusEnum.InActive:
                    messageForShop += " has been deactivated";
                    messageForMarketPlace += " has been deactivated";
                    iscont = true;
                    break;
            }
            #endregion

            if (!iscont)
                return;

            var pbc = new ProfileBusinessComponent();
            var sbc = new SupplierBusinessComponent();
            var shop = sbc.GetSupplierById(product.SupplierID);
            if (shop != null)
            {
                var shopProfile = pbc.GetProfileByProfileId(shop.ProfileID);
                if (shopProfile != null)
                {
                    SendEmail("Product Update", shopProfile.UserID, messageForShop);
                    SendNotification(NotificationTypeEnum.Product, shopProfile.ProfileID, 0, messageForShop, transactionID);
                }
            }
            long marketPlaceProfileID = Convert.ToInt64(Config.MarketPlaceProfileID);
            var marketPlaceProfile = pbc.GetProfileByProfileId(marketPlaceProfileID);
            if (marketPlaceProfile != null)
            {
                SendEmail("Product Update", marketPlaceProfile.UserID, messageForMarketPlace);
                SendNotification(NotificationTypeEnum.Product, marketPlaceProfileID, 0, messageForMarketPlace, transactionID);
            }
        }
        private static void ShopNotification(long transactionID)
        {
            var sbc = new SupplierBusinessComponent();
            var supplier = sbc.GetById(transactionID);
            if (supplier == null)
                return;

            #region Message for Shop and Market Place
            string messageForShop = "Shop " + supplier.SupplierName;
            string messageForMarketPlace = "Shop " + supplier.SupplierName;
            bool iscont = false;
            switch (supplier.StatusID)
            {
                case (long)DBStatusEnum.New:
                    messageForShop += " has been sent for approval";
                    messageForMarketPlace += " has been received for approval";
                    iscont = true;
                    break;
                case (long)DBStatusEnum.Active:
                    messageForShop += " has been approved.";
                    messageForMarketPlace += " has been approved";
                    iscont = true;
                    break;
                case (long)DBStatusEnum.InActive:
                    messageForShop += " has been deactivated";
                    messageForMarketPlace += " has been deactivated";
                    iscont = true;
                    break;
            }
            #endregion

            if (!iscont)
                return;

            var pbc = new ProfileBusinessComponent();

            var shopProfile = pbc.GetProfileByProfileId(supplier.ProfileID);
            if (shopProfile != null)
            {
                SendEmail("Shop Update", shopProfile.UserID, messageForShop);
                SendNotification(NotificationTypeEnum.Shop, supplier.ProfileID, 0, messageForShop, transactionID);
            }
            
            long marketPlaceProfileID = Convert.ToInt64(Config.MarketPlaceProfileID);
            var marketPlaceProfile = pbc.GetProfileByProfileId(marketPlaceProfileID);
            if (marketPlaceProfile != null)
            {
                SendEmail("Product Update", marketPlaceProfile.UserID, messageForMarketPlace);
                SendNotification(NotificationTypeEnum.Shop, marketPlaceProfileID, 0, messageForMarketPlace, transactionID);
            }
        }
        public static bool SendEmail(string subject, long userid, string body)
        {
            var es = new EmailService();
            try
            {
                var user = ApplicationUserManager.GetUser(userid);
                if (user != null)
                {
                    var emailMessage = new IdentityMessage();
                    emailMessage.Body = body;
                    emailMessage.Destination = user.Email;
                    emailMessage.Subject = subject;
                    es.Send(emailMessage);
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                NLogger.ErrorLog.Error(ex);
                return false;
            }

        }
        private static bool SendNotification(NotificationTypeEnum notificationType, long receiverProfileID, long senderProfileID, string message, long transactionID)
        {            
            try
            {
                var realtimeNotification = new NotificationModel();
                realtimeNotification.Message = message;
                realtimeNotification.ReceiverProfileID = receiverProfileID;
                if (senderProfileID == 0)
                {
                    long marketPlaceProfileID = Convert.ToInt64(Config.MarketPlaceProfileID);
                    senderProfileID = marketPlaceProfileID;                    
                }
                realtimeNotification.SenderProfileID = senderProfileID;
                realtimeNotification.NotificationTime = DateTime.Now;
                realtimeNotification.NotificationType = notificationType;
                realtimeNotification.SubjectRowID = transactionID;
                SendNotification(realtimeNotification, receiverProfileID);
                return true;
            }
            catch (Exception ex)
            {
                NLogger.ErrorLog.Error(ex);
                return false;
            }

        }
        public static void SendNotification(NotificationModel message)
        {
            Log.Info("SendNotification(NotificationModel message). Msg: " + message.Message);
            message = UpdateNotification(message);
            hubContext.Clients.All.broadCastMessage(message);
            ExpoNotificationHub.SendPushNotification(message);
            ActiveNotification.Instance.AddNotificationToAll(message);
            AddChatMessage(message);
            AddNotification(message);
        }
        public static void SendNotification(NotificationModel message, long receiverProfileID)
        {
            Log.Info("SendNotification(NotificationModel message, long receiverProfileID). Msg: " + message.Message);
            message = UpdateNotification(message);

            ExpoNotificationHub.SendPushNotification(message.ReceiverProfileID, message);
            List<string> connections = ActiveNotificationClients.Instance.GetClientID(receiverProfileID);
            foreach (string connectionID in connections)
            {
                hubContext.Clients.Client(connectionID).broadCastMessage(message);
                ActiveNotification.Instance.AddNotification(receiverProfileID, message);
            }            
            AddChatMessage(message);
            AddNotification(message);
        }
        public static void SendNotification(NotificationModel message, List<long> list)
        {
            foreach (long profileID in list)
            {
                SendNotification(message, profileID);
            }
        }
        public static void SendNotificationToMarketPlace(NotificationTypeEnum notificationType, string message, long transactionID)
        {
            var pbc = new ProfileBusinessComponent();

            long marketPlaceProfileID = Convert.ToInt64(Config.MarketPlaceProfileID);
            ProfileModel marketPlaceProfile = pbc.GetProfileByProfileId(marketPlaceProfileID);
            if (marketPlaceProfile == null)
                return;

            SendNotification(notificationType, marketPlaceProfileID, 0, message, transactionID);
        }
        public static List<NotificationModel> GetNotification(long ProfileID)
        {
            return ActiveNotification.Instance.GetNotification(ProfileID);            
        }
        public void ReceiveMessage(NotificationModel message)
        {
            Log.Info("ReceiveMessage(NotificationModel message). Msg: " + message.Message);
            //if (Context.QueryString["ProfileID"] != null && !string.IsNullOrEmpty(Context.QueryString["ProfileID"]))
            //{
                //long? profileID = Convert.ToInt64(Context.QueryString["ProfileID"]);
                //string connectionID = Context.ConnectionId;

                if (message.ReceiverProfileID > 0)
                {
                    message.NotificationTime = DateTime.Now;
                    SendNotification(message, message.ReceiverProfileID);                   
                }
                else
                {
                    message.NotificationTime = DateTime.Now;
                    SendNotification(message);
                }
            //}
        }        
        public override Task OnConnected()
        {
            if (Context.QueryString["ProfileID"] != null && !string.IsNullOrEmpty(Context.QueryString["ProfileID"]))
            {
                long? profileID = Convert.ToInt64(Context.QueryString["ProfileID"]);
                string connectionID = Context.ConnectionId;

                if (profileID.HasValue)
                {
                    ActiveNotificationClients.Instance.AddClient(profileID.Value, connectionID);
                    ActiveNotification.Instance.AddNotificationProfile(profileID.Value);
                }
                else
                    return base.OnDisconnected(false);

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

            ActiveNotificationClients.Instance.RemoveClient(connectionID);            

            return base.OnDisconnected(stopCalled);
        }
        public override Task OnReconnected()
        {
            if (Context.QueryString["ProfileID"] != null && !string.IsNullOrEmpty(Context.QueryString["ProfileID"]))
            {
                long? profileID = Convert.ToInt64(Context.QueryString["ProfileID"]);
                string connectionID = Context.ConnectionId;

                if (profileID.HasValue)
                    ActiveNotificationClients.Instance.AddClient(profileID.Value, connectionID);
                else
                    return base.OnDisconnected(false);

                return base.OnReconnected();
            }
            else
            {
                return base.OnDisconnected(false);
            }
        }
        private static bool SendChatMessageOverEmail(NotificationModel message)
        {
            Log.Debug("sending chat message over email. message.SenderProfileID : " + message.SenderProfileID);
            try
            {
                var pbc = new ProfileBusinessComponent();
                ProfileModel sender = pbc.GetProfileByProfileId(message.SenderProfileID);
                if (sender != null)
                {
                    var ReceiverProfile = pbc.GetProfileByProfileId(message.ReceiverProfileID);
                    return NotificationHub.SendEmail(
                        "You received a new chat message in Zvonr by (" + message.SenderName + ")", //(" + message.ReceiverName + ")
                        ReceiverProfile.UserID, message.Message);
                }
                else
                {
                    ErrorLog.Error("chat send message - sender is null. message.SenderProfileID: " + message.SenderProfileID + ",  message.ReceiverProfileID" + message.ReceiverProfileID);
                    return false;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "ExceptionMessage : chat send message - sender is null. message.SenderProfileID: " + message.SenderProfileID + ",  message.ReceiverProfileID" + message.ReceiverProfileID);
                return false;
            }
            finally
            {

            }
        }
        public static long? AddChatMessage(NotificationModel message)
        {
            if (message.NotificationType == NotificationTypeEnum.Chat)
            {
                if (message.ChatID > 0)
                {
                    if( ! SendChatMessageOverEmail(message))
                    {
                        Log.Error("SendChatMessageOverEmail failed" + message.Message);
                    }
                    var model = new ChatMessageModel
                    {
                        ChatId = message.ChatID,
                        IsRead = false,
                        IsReceived = false,
                        Message = message.Message,
                        MessageCode = "",
                        ReceiverProfileId = message.ReceiverProfileID,
                        SenderProfileId = message.SenderProfileID,
                        StatusId = 2,
                        RequestedByProfileId = message.SenderProfileID
                    };
                    var comp = new ChatMessageBusinessComponent();
                    return comp.SendMessage(model);
                }
            }
            return null;
        }
        private static long? AddNotification(NotificationModel message)
        {
            if (message.NotificationType != NotificationTypeEnum.Chat)
            {
                var model = new NotifyModel
                {
                    NotificationType = (long)message.NotificationType,
                    Message = message.Message,
                    ReceiverProfileId = message.ReceiverProfileID,
                    SenderProfileId = message.SenderProfileID,
                    StatusId = 2,
                    RequestedByProfileId = message.SenderProfileID,
                    SubjectRowID = message.SubjectRowID,
                };
                var comp = new NotifyBusinessComponent();
                return comp.AddNotify(model);
            }
            return null;
        }
        public static NotificationModel UpdateNotification(NotificationModel message)
        {
            try
            {
                message.NotificationTypeString = message.NotificationType.GetDescription();

                var pbc = new ProfileBusinessComponent();
                if (message.SenderProfileID > 0)
                {
                    var senderProfile = pbc.GetProfileByProfileId(message.SenderProfileID);
                    message.SenderName = pbc.GetDisplayDescription(senderProfile);
                }
                if (message.ReceiverProfileID > 0)
                {
                    var receiverProfile = pbc.GetProfileByProfileId(message.ReceiverProfileID);
                    message.ReceiverName = pbc.GetDisplayDescription(receiverProfile);
                }
            }
            catch (Exception ex)
            {
                NLogger.ErrorLog.Error(ex);
            }
            return message;
        }
    }
}