using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Services.WebAPIs.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;

namespace OMSCloud.Services.WebAPIs
{
    public class SendNotificationQueue
    {
        private static SendNotificationQueue instance = new SendNotificationQueue();
        private List<NotificationModel> notificationList; 
        object mutex;
        private Timer refreshDataTimer;

        private SendNotificationQueue()
        {
            notificationList = new List<NotificationModel>();
            mutex = new object();

            refreshDataTimer = new Timer();
            refreshDataTimer.Interval = 5000;
            refreshDataTimer.Elapsed += refreshDataTimer_Elapsed;
            refreshDataTimer.AutoReset = true;
        }

        public static SendNotificationQueue Instance
        {
            get
            {
                return instance;
            }
        }
        void refreshDataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StopRefreshDataTimer();
            try
            {
                List<NotificationModel> tempList = new List<NotificationModel>();
                lock (mutex)
                {
                    tempList = new List<NotificationModel>(notificationList);
                    notificationList.Clear();
                }
                if (tempList.Count > 0)
                {
                    foreach (var notification in tempList)
                    {
                        NotificationHub.SendNotification(notification.NotificationType, notification.SubjectRowID);
                    }
                }
            }
            catch (Exception ex)
            {
                NLogger.ErrorLog.Error(ex);
            }
            StartRefreshDataTimer();

        }
        public void StartRefreshDataTimer()
        {
            refreshDataTimer.Start();
        }
        public void StopRefreshDataTimer()
        {
            refreshDataTimer.Stop();
        }
        public void SendNotification(NotificationTypeEnum notificationType, long transactionID)
        {
            lock (mutex)
            {
                NotificationModel model = new NotificationModel();
                model.NotificationType = notificationType;
                model.SubjectRowID = transactionID;
                notificationList.Add(model);
            }
        }       
    }
}