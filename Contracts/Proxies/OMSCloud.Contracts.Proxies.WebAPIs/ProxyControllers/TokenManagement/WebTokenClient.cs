using Newtonsoft.Json;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OMSCloud.Contracts.Common.NLogger;

namespace OMSCloud.Contracts.Proxies.WebAPIs.ProxyControllers.TokenManagement
{
    public class WebTokenClient
    {       
        private static ConcurrentDictionary<string, TokenResponseModel> tokenDictionary = new ConcurrentDictionary<string, TokenResponseModel>();
        public static TokenResponseModel CallWebTokenRequest()
        {
            try
            {
                TokenRequestModel requestModel = new TokenRequestModel(Config.WebAPIUser, Config.WebAPIUserPassword);
                var c = BaseControllerProxy.Country;
                Log.Info("CallWebTokenRequest:: Country: " + c);
                var apiHost = Config.GetWebAPIHost(c);
                Log.Info("CallWebTokenRequest:: API Host" + apiHost);
                var client = new RestClient(apiHost + "/token");
                var request = new RestRequest(Method.POST);
                //var IP = CommonUtilities.GetClientIp(Request);
                //request.AddHeader("RemoteIP", IP);
                request.AddHeader("cache-control", "no-cache");
                request.AddHeader("content-type", "application/x-www-form-urlencoded");
                string data = "UserName=" + requestModel.UserName + "&password=" + requestModel.Password + "&grant_type=" + requestModel.grant_type;
                request.AddParameter("application/x-www-form-urlencoded", data, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TokenResponseModel responeModel = JsonConvert.DeserializeObject<TokenResponseModel>(response.Content);
                    //Add token expiry date into response model
                    responeModel.expiredTime = DateTime.UtcNow.AddMinutes(30);
                    return responeModel;
                }
                else
                {
                    ErrorLog.Error(response.ErrorException, 
                        "Status Code == " + response.StatusCode + "(" + response.StatusDescription + ")" + 
                        Environment.NewLine + 
                        "Response ErrorException: " + response.ErrorMessage);
                    //write error log here
                }

                return null;
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex);
                throw;
            }
        }        
        public static TokenResponseModel GetToken()
        {
            TokenResponseModel token = null;
            if (!tokenDictionary.TryGetValue(BaseControllerProxy.Country, out token))
            {
                token = CallWebTokenRequest();
                if (token != null)
                {
                    //add the new token into dictionary for further use
                    tokenDictionary.TryAdd(BaseControllerProxy.Country, token);
                    //set the token into Base Controller Proxy
                    BaseControllerProxy.ApiToken = token;
                }                
            }
            else
            {
                //if token exists then check the expiry that we have set at the time of new token
                DateTime current = DateTime.Now.ToUniversalTime().AddMinutes(1);
                if (token.expiredTime <= current)
                {
                    //if token expired then request for new token
                    token = CallWebTokenRequest();
                    //update the token into dictionary for further use
                    tokenDictionary[BaseControllerProxy.Country] = token;
                    //set the token into Base Controller Proxy
                    BaseControllerProxy.ApiToken = token;
                }
            }
            return token;                
        }        
    }
}
