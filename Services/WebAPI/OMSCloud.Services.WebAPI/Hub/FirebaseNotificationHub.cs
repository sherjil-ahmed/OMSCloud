using Newtonsoft.Json;
using NLog.Fluent;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Services.WebAPIs.Controllers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace OMSCloud.Services.WebAPI.Hub
{
    public class FirebaseNotificationHub
    {
        //private static ConcurrentDictionary<string, TokenResponseModel> tokenDictionary = new ConcurrentDictionary<string, TokenResponseModel>();
        public static FirebaseNotificationResponseModel SendFirebaseNotification(long profileId, String title, string msg)
        {
            try
            {
                var DeviceTokenList = AccountController.GetDeviceTokenByProfileId(profileId);
                if (DeviceTokenList?.Count < 1)
                    return null;
                FirebaseNotificationRequestModel requestModel = new FirebaseNotificationRequestModel
                {
                    FirebaseAppKey = Config.FirebaseAppKey,
                    DeviceTokenList = DeviceTokenList,
                    NotificationTitle = title,
                    NotificationBody = msg
                };
                var apiHost = "https://fcm.googleapis.com/fcm/send";// Config.GetFirebaseNotificationURL();
                Log.Info("CallWebTokenRequest:: API Host" + apiHost);
                var client = new RestClient(apiHost + "https://fcm.googleapis.com/fcm/send");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", "key=" + requestModel.FirebaseAppKey);
                request.AddHeader("Content-Type", "application/json");

                //Same user could have multiple active device tokens, we have to send the same Notification to all the devices
                string data = "{\r\n \"to\" : \"" + requestModel.DeviceTokenList[0] + //  need to write logic for multiple notification 
                    "\",\r\n  \"notification\" : {\r\n     \"body\" : \"" + requestModel.NotificationBody + 
                    "\",\r\n     \"title\": \"" + requestModel.NotificationTitle + "\"\r\n } \r\n}";
                request.AddParameter("application/json", data, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    FirebaseNotificationResponseModel responeModel = JsonConvert.DeserializeObject<FirebaseNotificationResponseModel>(response.Content);
                    //Add token expiry date into response model
                    if(responeModel.success > 0)
                        return responeModel;
                    else
                        return responeModel;
                }
                else
                {/*
                    ErrorLog.Error(response.ErrorException,
                        "Status Code == " + response.StatusCode + "(" + response.StatusDescription + ")" +
                        Environment.NewLine +
                        "Response ErrorException: " + response.ErrorMessage);*/
                    //write error log here
                }

                return null;
            }
            catch (Exception ex)
            {
                //ErrorLog.Error(ex);
                throw;
            }
        }

        private static string GetFirebaseNotificationDeviceTokenByProfileId(long profileId)
        {
            return "";
        }
    }
}