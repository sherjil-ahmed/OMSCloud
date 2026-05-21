using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMSCloud.Services.WebAPIs.Collections
{
    public class ActiveNotification
    {
        private static ActiveNotification instance = new ActiveNotification();
        private Dictionary<long, List<NotificationModel>> notificationList; //Key = ProfileID, Value List of Messages
        object mutex;

        private ActiveNotification()
        {
            notificationList = new Dictionary<long, List<NotificationModel>>();
            mutex = new object();
        }

        public static ActiveNotification Instance
        {
            get
            {
                return instance;
            }
        }

        public void AddNotificationProfile(long ProfileID)
        {
            lock (mutex)
            {
                if (!notificationList.ContainsKey(ProfileID))
                    notificationList.Add(ProfileID, new List<NotificationModel>());
            }
        }
        public void AddNotificationToAll(NotificationModel Message)
        {
            lock (mutex)
            {
                foreach(KeyValuePair<long,List<NotificationModel>> kvp in notificationList)
                {
                    kvp.Value.Add(Message);
                }
            }            
        }
        public bool AddNotification(long ProfileID, NotificationModel Message)
        {
            lock (mutex)
            {
                if (notificationList.ContainsKey(ProfileID))
                {
                    notificationList[ProfileID].Add(Message);
                    return true;
                }
                else
                {
                    notificationList.Add(ProfileID, new List<NotificationModel>() { Message });
                    return true;
                }
            }            
        }
        public bool RemoveNotificationForProfile(long ProfileID)
        {
            bool removed = false;
            lock (mutex)
            {
                removed = notificationList.Remove(ProfileID);
            }
            return removed;
        }
        
        public List<NotificationModel> GetNotification(long ProfileID)
        {
            lock (mutex)
            {
                if (notificationList.ContainsKey(ProfileID))                
                    return notificationList[ProfileID];
            }
            return new List<NotificationModel>();
        }
    }
}