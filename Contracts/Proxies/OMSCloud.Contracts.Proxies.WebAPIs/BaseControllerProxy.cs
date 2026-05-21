using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ApiExplorerEnums;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public class BaseControllerProxy
    {
        public static Dictionary<string, ApiDescriptorModel> apiDictionary { get; set; }
        public static long ProfileId { get; set; }
        public static string Country { get; set; }
        //public static HttpContextBase HttpCurrentContext { get; set; }
        private IWebApiClient webApiClient = null;
        public IWebApiClient WebApiClient
        {
            get
            {
                if (webApiClient == null)
                {
                    webApiClient = WebApiClientFactory.Instance(WebAPIFormaterEnum.json);
                    webApiClient.OnApiExecuted += WebApiClient_OnApiExecuted;
                    webApiClient.OnApiExecuting += WebApiClient_OnApiExecuting;
                    webApiClient.OnApiException += WebApiClient_OnApiException;
                }
                webApiClient.ProfileId = ProfileId;
                webApiClient.Country = Country;
                webApiClient.ApiToken = ApiToken;
                //webApiClient.HttpCurrentContext = HttpCurrentContext;
                return webApiClient;
            }
        }

        public static TokenResponseModel ApiToken { get; internal set; }

        private void WebApiClient_OnApiException(Exception ex, string Uri, WebAPIVerbEnum Verb, WebAPIFormaterEnum formater, object requestModel)
        {
            //throw new NotImplementedException();
        }

        private void WebApiClient_OnApiExecuting(string Uri, WebAPIVerbEnum Verb, WebAPIFormaterEnum formater, object requestModel)
        {
            //throw new NotImplementedException();
        }

        private void WebApiClient_OnApiExecuted(string Uri, WebAPIVerbEnum Verb, WebAPIFormaterEnum formater, object requestModel)
        {
            //throw new NotImplementedException();
        }

    }
}
