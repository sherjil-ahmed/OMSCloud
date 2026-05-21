using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMSCloud.Services.WebAPIs.Collections
{
    public class ActiveNotificationClients
    {
        private static ActiveNotificationClients instance = new ActiveNotificationClients();
        private Dictionary<long, List<string>> clientList; //Key = ProfileID, Value List of SignalR Client Ids
        object mutex;

        private ActiveNotificationClients()
        {
            clientList = new Dictionary<long, List<string>>();
            mutex = new object();
        }

        public static ActiveNotificationClients Instance
        {
            get
            {
                return instance;
            }
        }

        public bool AddClient(long ProfileID, string ClientID)
        {
            lock (mutex)
            {
                if (clientList.ContainsKey(ProfileID))
                {
                    if (!clientList[ProfileID].Contains(ClientID))
                    {
                        clientList[ProfileID].Add(ClientID);
                        return true;                        
                    }
                }
                else
                {
                    clientList.Add(ProfileID, new List<string>() { ClientID });
                    return true;                    
                }
            }
            return false;
        }
        public bool RemoveClient(string ClientID)
        {
            bool removed = false;
            lock (mutex)
            {
                foreach(KeyValuePair<long,List<string>> kvp in clientList)
                {
                    removed = kvp.Value.Remove(ClientID);
                }
            }
            return removed;
        }

        public long? GetProfileID(string ClientID)
        {
            lock (mutex)
            {
                foreach (KeyValuePair<long, List<string>> kvp in clientList)
                {
                    if (kvp.Value.Contains(ClientID))
                        return kvp.Key;
                }
            }
            return null;
        }
        public List<string> GetClientID(long ProfileID)
        {
            lock (mutex)
            {
                if (clientList.ContainsKey(ProfileID))
                    return clientList[ProfileID];
            }
            return new List<string>();
        }
    }
}