using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Services.WebAPIs.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace OMSCloud.Services.WebAPIs.Hubs
{//https://gist.github.com/danparker276/0fb73738f018f5367040acd748c40e68
    //https://docs.expo.dev/push-notifications/sending-notifications/
    public class ExpoNotificationHub
    {
        public class ExpoNotificationBody {
            public string to { get; set; }
            public string title { get; set; }
            public string body { get; set; }
            public string sound { get; set; }
            public dynamic data { get; set; }
        }
        public static dynamic SendPushNotification(NotificationModel msg )//string title, string msg)
        {
            var ExpoTokenList = AccountController.GetNotificationTokenList();
            return SendPushNotification(ExpoTokenList, msg.NotificationType.ToString(), msg.Message, msg.NotificationTime, msg.SenderProfileID);
        }
        public static dynamic SendPushNotification(long profileId, NotificationModel msg)//String title, string msg)
        {
            NLogger.Log.Debug("Expo send push notification for Profile ID: " + profileId);
            var ExpoTokenList = AccountController.GetDeviceTokenByProfileId(profileId);
            return SendPushNotification(ExpoTokenList, msg.NotificationType.ToString(), msg.Message, msg.NotificationTime, msg.SenderProfileID);
        }
        private static dynamic SendPushNotification(List<string> ExpoTokenList, String title, string msg, DateTime msgTime, long senderProfileId)
        {
            if (ExpoTokenList == null || ExpoTokenList?.Count < 1)
            {
                NLogger.Log.Debug("ExpoTokenList either null or empty");
                return null;
            }
            List<ExpoNotificationBody> list = new List<ExpoNotificationBody>();
            foreach (var token in ExpoTokenList)
            {
                list.Add(new ExpoNotificationBody
                {
                    to = token,
                    title = title,
                    body = msg,
                    sound = "default",
                    data = new { 
                        messageId = title,
                        message = msg,
                        createdAt = msgTime.ToString(),
                        from = senderProfileId
                },
                });
            }
            string response = null;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (MyWebClient client = new MyWebClient())
            {
                client.Encoding = System.Text.Encoding.UTF8;
                client.Headers.Add("accept", "application/json");
                client.Headers.Add("accept-encoding", "gzip, deflate");
                client.Headers.Add("Content-Type", "application/json");
                NLogger.Log.Debug("client for Expo Notification prepared");
                try
                {
                    var json = JsonConvert.SerializeObject(list);
                    NLogger.Log.Debug("client Expo Notification Sent. JSON: " + json);
                    response = client.UploadString(
                                    "https://exp.host/--/api/v2/push/send",
                                     json
                                 );//JsonExtensions.ToJson(body));
                    NLogger.Log.Debug(response);    
                }
                catch (Exception ex)
                {
                    NLogger.Log.Error(ex, ex.Message + " ::::" + ex.InnerException?.Message);
                    return null;
                }
            }
            ExpoResponseBulkData results = null;
            try
            {
                results = JsonConvert.DeserializeObject<ExpoResponseBulkData>(response,
                                                                new JsonSerializerSettings
                                                                {
                                                                    ContractResolver = new UnderscoreContractResolver()
                                                                }
                                                           );
                NLogger.Log.Debug("client Expo Notification JSON deserialized");
            }
            catch (Exception ex)
            {
                NLogger.Log.Error(ex, ex.Message + " ::::" + ex.InnerException?.Message);
            }
            if (results == null || results.Data == null || results.Data.Count <= 0)
            {
                NLogger.Log.Debug("Result after deserialize is empty.");
                return null;
            }
            var result = results.Data.FirstOrDefault();
            if (result.Status.ToLower() == "ok")
            {
                NLogger.Log.Debug("client Expo Notification Status: OK");
                return "ok";
            }
            else if (response.ToLower().Contains("devicenotregistered"))
            {
                NLogger.Log.Debug("client Expo Notification. Device nto Registered");
                //remove this key in your DB
                //await DeleteRegistrationExpoAsync(expoToken);
            }
            else if (response.ToLower().Contains("unable to retrieve the fcm server key"))
            {
                NLogger.Log.Debug("client Expo Notification. FCM server key error, removing");
                //await DeleteRegistrationExpoAsync(expoToken);
                return "FCM server key error, removing";
            }
            return response;
        }
    }
    public class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
    }
    internal class UnderscoreContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return Regex.Replace(propertyName, "(?<=[a-z])[A-Z]", m => "_" + m).ToLower();
        }
    }
    public class ExpoResponseData
    {
        public ExpoResponse Data { get; set; }
    }
    public class ExpoResponseBulkData
    {
        public List<ExpoResponse> Data { get; set; }
    }
    public class ExpoResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public DetailsError Details { get; set; }
    }
    public class DetailsError
    {
        public string Error { get; set; }
    }
}