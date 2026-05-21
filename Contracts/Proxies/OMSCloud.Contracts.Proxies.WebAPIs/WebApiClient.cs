using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;

using OMSCloud.Contracts.Caching;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ApiExplorerEnums;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Proxies.WebAPIs.ProxyControllers.TokenManagement;
using OMSCloud.Contracts.Serialization;
using OMSCloud.Contracts.ViewModels;
using static OMSCloud.Contracts.Common.NLogger;

namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public delegate void ApiInterceptor(string Uri, WebAPIVerbEnum Verb, WebAPIFormaterEnum formater, object requestModel);
    public delegate void ApiExceptionInterceptor(Exception ex, string Uri, WebAPIVerbEnum Verb, WebAPIFormaterEnum formater, object requestModel);

    #region Interfaces
    public interface IWebApiClient
    {
        #region DataMember
        long ProfileId { get; set; }
        string Country { get; set; }
        TokenResponseModel ApiToken { get; set; }

        //HttpContextBase HttpCurrentContext { get; set; }
        #endregion DataMember

        #region Events
        event ApiInterceptor OnApiExecuting;
        event ApiInterceptor OnApiExecuted;
        event ApiExceptionInterceptor OnApiException;
        #endregion Events

        #region GenericMethods
        T Get<T>(string UriString, bool isCacheable = false) where T : class;
        T GetForValueType<T>(string UriString, bool isCacheable = false) where T: struct;
        T Post<T>(string UriString, object requestModels = null);
        T PostImage<T>(string UriString, object requestModels = null);
        T Put<T>(string UriString, object requestModels = null);
        T Delete<T>(string UriString);
        #endregion GenericMethods

        #region Methods
        void Get(string UriString);
        void Post(string UriString, object requestModels = null);
        void Put(string UriString, object requestModels = null);
        void Delete(string UriString);
        #endregion Methods
    }
    public interface IWebApiASyncClient : IWebApiClient { }
    public interface IWebApiSyncClient : IWebApiClient { }
    #endregion Interfaces

    #region Abstract
    public abstract class WebApiSyncClient : IWebApiSyncClient
    {
        #region DataMemeber
        private static object lockObject = new object();
        private static object httpClientLockObj = new object();

        private static HttpClient client = null;
        //private static string webAPIHost = string.Empty;

        private static string DefaultCountry = Config.DefaultCountry;

        private static Dictionary<string/*Country*/, string/*WebApiHost_URI*/> webAPIHosts = new Dictionary<string, string>();

        private static ConcurrentDictionary<string, HttpClient> countryHttpClient = new ConcurrentDictionary<string, HttpClient>();

        public static string GetWebAPIHost(string Country)
        {
            if (string.IsNullOrEmpty(Country))
                Country = Config.DefaultCountry;
            if (webAPIHosts.ContainsKey(Country))
            {
                return webAPIHosts[Country]?.ToString();
            }
            else
            {
                var webAPIHost = Config.GetWebAPIHost(Country);
                if (string.IsNullOrEmpty(webAPIHost))
                {
                    webAPIHost = Config.GetWebAPIHost("Default");
                    if (string.IsNullOrEmpty(webAPIHost))
                    {
                        webAPIHost = "";
                    }
                }
                return webAPIHost;
            }
        }
        public long ProfileId { get; set; }
        public string Country { get; set; }
        public TokenResponseModel ApiToken { get; set; }
        public HttpContextBase HttpCurrentContext { get; set; }
        #endregion DataMemeber

        #region events
        public virtual event ApiInterceptor OnApiExecuting;
        public virtual event ApiInterceptor OnApiExecuted;
        public virtual event ApiExceptionInterceptor OnApiException;
        #endregion events

        #region PrivateMethods
        /// <summary>
        /// Depricated, Do not Use this at all
        /// </summary>
        /// <typeparam name="ResponseModel"></typeparam>
        /// <param name="webApi"></param>
        /// <param name="action"></param>
        /// <param name="verb"></param>
        /// <param name="formater"></param>
        /// <param name="requestModels"></param>
        /// <returns></returns>
        private ResponseModel CallWebAPI<ResponseModel>(WebAPIControllerEnum webApi, string action, WebAPIVerbEnum verb, WebAPIFormaterEnum formater, IModel[] requestModels)
        {
            lock (lockObject)
            {
                string paramz = string.Empty;
                IOMSSerialization<ResponseModel> serializer = SerializerFactory.Instance<ResponseModel>(formater);
                if (requestModels.Length > 0)
                    paramz = "/" + serializer.Serialize(requestModels[0]);

                string URI = WebApiSyncClient.GetWebAPIHost(Country) + "api/" + webApi.GetDescription() + paramz;

                WebRequest req = WebRequest.Create(URI);
                req.Method = verb.GetDescription();
                req.ContentType = formater.GetDescription();
                WebResponse resp = req.GetResponse();

                Stream stream = resp.GetResponseStream();
                StreamReader re = new StreamReader(stream);
                String text = re.ReadToEnd();

                return serializer.Deserialize(text);
            }
        }
        private HttpResponseMessage MakeWebAPIRequest(string UriString, WebAPIVerbEnum verb, WebAPIFormaterEnum formater, object requestModel)
        {
            try
            {
                if (requestModel != null && requestModel is BaseModel)
                {
                    (requestModel as BaseModel).RequestedByProfileId = this.ProfileId;
                }

                TokenResponseModel tokenResponseModel = WebTokenClient.GetToken(); //This call check the expiry of current token as well
                if (tokenResponseModel == null)
                    throw new Exception("Token not able to generate");

                if (formater == WebAPIFormaterEnum.multipart)
                {
                    client = WebApiSyncClient.GetFileUploadHttpClient(this.Country, tokenResponseModel.access_token);                   
                }
                else
                    client = WebApiSyncClient.GetHttpClient(formater, this.Country, tokenResponseModel.access_token);
                HttpResponseMessage response = null;
                OnApiExecuting?.DynamicInvoke(UriString, verb, formater, requestModel);
                switch (verb)
                {
                    case WebAPIVerbEnum.GET:
                        response = client.GetAsync(UriString).Result;
                        break;
                    case WebAPIVerbEnum.POST:
                        if (formater == WebAPIFormaterEnum.multipart)
                        {
                            var formData = new MultipartFormDataContent();
                            HttpPostedFileBase file = (HttpPostedFileBase)requestModel;
                            //formData.Add(new ByteArrayContent(file.))
                            byte[] data;
                            using (Stream inputStream = file.InputStream)
                            {
                                MemoryStream memoryStream = inputStream as MemoryStream;
                                if (memoryStream == null)
                                {
                                    memoryStream = new MemoryStream();
                                    inputStream.CopyTo(memoryStream);
                                }
                                data = memoryStream.ToArray();
                            }
                            formData.Add(new ByteArrayContent(data), Path.GetFileName(file.FileName), Path.GetFileName(file.FileName));
                            
                            response = client.PostAsync(UriString, formData).Result;
                         }
                        else
                        {
                            response = formater == WebAPIFormaterEnum.json ?
                                client.PostAsJsonAsync<object>(UriString, requestModel).Result :
                                client.PostAsXmlAsync<object>(UriString, requestModel).Result;
                        }
                        break;
                    case WebAPIVerbEnum.PUT:
                        response = formater == WebAPIFormaterEnum.json ?
                            client.PutAsJsonAsync<object>(UriString, requestModel).Result :
                            client.PutAsXmlAsync<object>(UriString, requestModel).Result;
                        //response = client.PutAsync(UriString, new StringContent("", Encoding.UTF8, "application/xml")).Result;
                        break;
                    case WebAPIVerbEnum.DELETE:
                        response = client.DeleteAsync(UriString).Result;
                        break;
                }
                OnApiExecuted?.DynamicInvoke(UriString, verb, formater, requestModel);

                return response;
            }
            catch (AggregateException aex)
            {
                //foreach (var v in aex.Data.Values)
                //{
                //    var type = v.GetType();
                //    if (v is Exception)
                //    {
                //        var s = (v as Exception).Message;
                //        var c = s.Length;
                //    }
                //}
                foreach (var ex in aex.InnerExceptions)
                {
                    var type = ex.GetType();
                    var m = CommonUtilities.GetExceptionDetails(ex);
                    var c = m.Length;
                }
                throw aex;
            }
            catch (Exception ex)
            {
                OnApiException?.DynamicInvoke(ex, UriString, verb, formater, requestModel);
                var response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                response.ReasonPhrase = "WebApiClient_Exception";
                string callParams = "UriString: " + UriString + ", Verb: " + verb + ", formater: " + formater + ", requestModel" + requestModel;
                ErrorLog.Error(ex, callParams);
                StringContent ExceptionDetail = new StringContent(callParams + Environment.NewLine + CommonUtilities.GetExceptionDetails(ex));
                response.Content = ExceptionDetail;
                return response;
            }
        }        
        #endregion PrivateMethods

        #region PublicMethods

        public static HttpClient GetHttpClient(WebAPIFormaterEnum formater, string Country, string access_token)
        {
            lock (httpClientLockObj)
            {
                HttpClient _client = null;

                //Check if Http Client is exists aginst country
                if (countryHttpClient.TryGetValue(Country, out _client))
                {
                    _client.DefaultRequestHeaders.Accept.Clear();
                    var item = new MediaTypeWithQualityHeaderValue(formater.GetDescription());
                    if (!_client.DefaultRequestHeaders.Accept.Contains(item))
                        _client.DefaultRequestHeaders.Accept.Add(item);

                    //Update the token information becuase might be old token is expired. Parameter access_token is always a valid token not expired
                    _client.DefaultRequestHeaders.Remove("Authorization");
                    _client.DefaultRequestHeaders.Add("Authorization", "bearer " + access_token);
                    client = _client;
                    return _client;
                }
                else
                {
                    _client = new HttpClient();                    
                    _client.BaseAddress = new Uri(WebApiSyncClient.GetWebAPIHost(Country));
                    _client.DefaultRequestHeaders.Accept.Clear();
                    var item = new MediaTypeWithQualityHeaderValue(formater.GetDescription());
                    if (!_client.DefaultRequestHeaders.Accept.Contains(item))
                        _client.DefaultRequestHeaders.Accept.Add(item);

                    //Add token information for this client
                    _client.DefaultRequestHeaders.Add("Authorization", "bearer " + access_token);
                    client = _client;
                    countryHttpClient.TryAdd(Country, _client);
                }
                return client;
            }
        }
        public static HttpClient GetFileUploadHttpClient(string Country, string access_token)
        {
            lock (httpClientLockObj)
            {
                HttpClient _client = null;

                //Check if Http Client is exists aginst country
                if (countryHttpClient.TryGetValue(Country, out _client))
                {
                    _client.DefaultRequestHeaders.Accept.Clear();
                    var item = new MediaTypeWithQualityHeaderValue(WebAPIFormaterEnum.multipart.GetDescription());
                    if (!_client.DefaultRequestHeaders.Accept.Contains(item))
                        _client.DefaultRequestHeaders.Accept.Add(item);

                    //Update the token information becuase might be old token is expired. Parameter access_token is always a valid token not expired
                    _client.DefaultRequestHeaders.Remove("Authorization");
                    _client.DefaultRequestHeaders.Add("Authorization", "bearer " + access_token);
                    client = _client;
                    return _client;
                }
                else
                {
                    _client = new HttpClient();
                    _client.Timeout = new TimeSpan(0);
                    //_client
                    _client.BaseAddress = new Uri(WebApiSyncClient.GetWebAPIHost(Country));
                    _client.DefaultRequestHeaders.Accept.Clear();
                    var item = new MediaTypeWithQualityHeaderValue(WebAPIFormaterEnum.multipart.GetDescription());
                    if (!_client.DefaultRequestHeaders.Accept.Contains(item))
                        _client.DefaultRequestHeaders.Accept.Add(item);

                    //Add token information for this client
                    _client.DefaultRequestHeaders.Add("Authorization", "bearer " + access_token);
                    client = _client;
                    countryHttpClient.TryAdd(Country, _client);
                }
                return client;
            }
        }
        public R CallWebAPIAsync<R>(string UriString, WebAPIVerbEnum verb = WebAPIVerbEnum.POST, WebAPIFormaterEnum formater = WebAPIFormaterEnum.json, object requestModel = null)
        {
            HttpResponseMessage response = MakeWebAPIRequest(UriString, verb, formater, requestModel);
            return GetWebAPIResponse<R>(response);
        }

        private R GetWebAPIResponse<R>(HttpResponseMessage response)
        {//this.HttpCurrentContext.Request.UrlReferrer
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<R>().Result;// returninng Null does not throw exception
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return default(R);
            }

            //else if (response.StatusCode == HttpStatusCode.Unauthorized)
            //{
            //    return null;
            //}
            //if (response.StatusCode == HttpStatusCode.ServiceUnavailable || InternalServerError || 
            //    response.StatusCode == HttpStatusCode.ExpectationFailed )
            //{
            //    var exceptionMessage = response.Content.ReadAsStringAsync().Result;
            //    throw new Exception(exceptionMessage);
            //}
            else
                throw new HttpResponseException(response);
        }

        public void CallWebAPIAsync(string UriString, WebAPIVerbEnum verb = WebAPIVerbEnum.POST, WebAPIFormaterEnum formater = WebAPIFormaterEnum.json, object requestModel = null)
        {
            HttpResponseMessage response = MakeWebAPIRequest(UriString, verb, formater, requestModel);
        }
        #endregion PublicMethods

        #region AbstractMethods
        public abstract T Get<T>(string UriString, bool isCacheable = false) where T:class;
        public abstract T GetForValueType<T>(string UriString, bool isCacheable = false) where T : struct;
        public abstract T Post<T>(string UriString, object requestModels = null);
        public abstract T PostImage<T>(string UriString, object requestModels = null);
        public abstract T Put<T>(string UriString, object requestModels = null);
        public abstract T Delete<T>(string UriString);
        public abstract void Get(string UriString);
        public abstract void Post(string UriString, object requestModels = null);
        public abstract void Put(string UriString, object requestModels = null);
        public abstract void Delete(string UriString);
        #endregion AbstractMethods
    }
    #endregion Abstract

    #region JSON
    public class WebApiSyncJsonClient : WebApiSyncClient
    {
        #region Generic
        public override T GetForValueType<T>(string UriString, bool isCacheable = false)
        {
            var result = base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.GET, WebAPIFormaterEnum.json);
            return result;
        }

        public override T Get<T>(string UriString, bool isCacheable = false)
        {           
            if (isCacheable)
            {
                Type type = typeof(T);
                T cachedResult = null;
                var locker = CacheManager.GetThreadLockerObject(this.Country + type.FullName, UriString);
                lock (locker)
                {
                    cachedResult = CacheManager.Get<T>(this.Country + type.FullName, UriString);
                    if (!type.IsValueType && cachedResult == null)
                    {
                        var result = base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.GET, WebAPIFormaterEnum.json);
                        CacheManager.Set(this.Country + type.FullName, UriString, result);
                        return result;
                    }
                    return cachedResult;
                }
            }
            else
            {
                return base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.GET, WebAPIFormaterEnum.json);
            }
        }
        public override T Post<T>(string UriString, object requestModels = null)
        {
            var result = base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.POST, WebAPIFormaterEnum.json, requestModels);
            CacheManager.RemoveAllLike(this.Country , requestModels?.GetType()?.FullName);
            return result;
        }
        public override T PostImage<T>(string UriString, object requestModels = null)
        {
            var result = base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.POST, WebAPIFormaterEnum.multipart, requestModels);
            CacheManager.RemoveAllLike(this.Country , requestModels?.GetType()?.FullName);
            return result;
        }
        public override T Put<T>(string UriString, object requestModels = null)
        {
            var result = base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.PUT, WebAPIFormaterEnum.json, requestModels);
            CacheManager.RemoveAllLike(this.Country , requestModels?.GetType()?.FullName);
            return result;
        }
        public override T Delete<T>(string UriString)
        {
            var result = base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.DELETE, WebAPIFormaterEnum.json);
            //CacheManager.RemoveAllLike(requestModels?.GetType()?.FullName);
            return result;
        }
        #endregion Generic
        #region Normal
        public override void Get(string UriString)
        {
            base.CallWebAPIAsync(UriString, WebAPIVerbEnum.GET, WebAPIFormaterEnum.json);
        }
        public override void Post(string UriString, object requestModels = null)
        {
            base.CallWebAPIAsync(UriString, WebAPIVerbEnum.POST, WebAPIFormaterEnum.json, requestModels);
            CacheManager.RemoveAllLike(this.Country, requestModels?.GetType()?.FullName);
        }
        public override void Put(string UriString, object requestModels = null)
        {
            base.CallWebAPIAsync(UriString, WebAPIVerbEnum.PUT, WebAPIFormaterEnum.json, requestModels);
            CacheManager.RemoveAllLike(this.Country, requestModels?.GetType()?.FullName);
        }
        public override void Delete(string UriString)
        {
            base.CallWebAPIAsync(UriString, WebAPIVerbEnum.DELETE, WebAPIFormaterEnum.json);
            //CacheManager.RemoveAllLike(requestModels?.GetType()?.FullName);
        }
        #endregion Normal
    }
    #endregion JSON

    #region XML
    public class WebApiSyncXmlClient : WebApiSyncClient
    {
        #region Generic
        public override T GetForValueType<T>(string UriString, bool isCacheable = false)
        {
            var result = base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.GET, WebAPIFormaterEnum.xml);
            return result;
        }
        public override T Get<T>(string UriString, bool isCacheable = false)
        {
            return base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.GET, WebAPIFormaterEnum.xml);
        }
        public override T Post<T>(string UriString, object requestModels = null)
        {
            return base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.POST, WebAPIFormaterEnum.xml, requestModels);
        }
        public override T PostImage<T>(string UriString, object requestModels = null)
        {
            return base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.POST, WebAPIFormaterEnum.xml, requestModels);
        }
        public override T Put<T>(string UriString, object requestModels = null)
        {
            return base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.PUT, WebAPIFormaterEnum.xml, requestModels);
        }
        public override T Delete<T>(string UriString)
        {
            return base.CallWebAPIAsync<T>(UriString, WebAPIVerbEnum.DELETE, WebAPIFormaterEnum.xml);
        }
        #endregion Generic
        #region Normal
        public override void Get(string UriString)
        {
            base.CallWebAPIAsync(UriString, WebAPIVerbEnum.GET, WebAPIFormaterEnum.json);
        }
        public override void Post(string UriString, object requestModels = null)
        {
            base.CallWebAPIAsync(UriString, WebAPIVerbEnum.POST, WebAPIFormaterEnum.json, requestModels);
        }
        public override void Put(string UriString, object requestModels = null)
        {
            base.CallWebAPIAsync(UriString, WebAPIVerbEnum.PUT, WebAPIFormaterEnum.json, requestModels);
        }
        public override void Delete(string UriString)
        {
            base.CallWebAPIAsync(UriString, WebAPIVerbEnum.DELETE, WebAPIFormaterEnum.json);
        }
        #endregion Normal
    }
    #endregion XML

    #region Factory
    public class WebApiClientFactory
    {
        private static IWebApiClient WebApiClient = null;
        public static IWebApiClient Instance(WebAPIFormaterEnum formater)
        {
            if (WebApiClient == null)
            {
                if (formater == WebAPIFormaterEnum.json)
                    WebApiClient = new WebApiSyncJsonClient();
                else if (formater == WebAPIFormaterEnum.xml)
                    WebApiClient = new WebApiSyncXmlClient();
                else
                    WebApiClient = new WebApiSyncJsonClient();
            }
            return WebApiClient;
        }
    }
    #endregion Factory
}