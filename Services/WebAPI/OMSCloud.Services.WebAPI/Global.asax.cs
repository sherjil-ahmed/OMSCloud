using OMSCloud.DataStore.EF;
using OMSCloud.Services.WebAPIs.BackgroundServices;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using static OMSCloud.Contracts.Common.NLogger;

namespace OMSCloud.Services.WebAPIs
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static DatabaseLogger dbLogger = null;
        private static SqlInterceptorWebApi sqlInterceptor = new SqlInterceptorWebApi();

        public override void Init()
        {
            //this.PostAuthorizeRequest += WebApiApplication_PostAuthorizeRequest;
            base.Init();
        }

        private void WebApiApplication_PostAuthorizeRequest(object sender, EventArgs e)
        {
            //if (IsWebApiRequest())
            //HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);

        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            string path = Path.Combine(Server.MapPath("/"), "DBLog");
            if (!File.Exists(path))
                Directory.CreateDirectory(path);

            var dt = DateTime.Now;
            dbLogger = new DatabaseLogger(Path.Combine(path, "DBLog_" + dt.Day + dt.Month + dt.Year + "_" + dt.Hour + dt.Minute + dt.Second + dt.Millisecond + ".log"), true);
            dbLogger.StartLogging();

            DbInterception.Add(sqlInterceptor);

            OrderBackgroundService.Instance.StartRefreshDataTimer();
            ReviewBackgroundService.Instance.StartRefreshDataTimer();
            ProductBackgroundService.Instance.StartRefreshDataTimer();
            SendNotificationQueue.Instance.StartRefreshDataTimer();
        }

        protected void Application_Error()
        {
            foreach (var e in HttpContext.Current.AllErrors)
            {
                if (e is HttpResponseException)
                {
                    //e.
                }
                ErrorLog.Error(e, "tracked in Application_Error");
            }
            //HttpContext.Current.Response.RedirectToRoute("default", new RouteValueDictionary(new { controller = "Error", action = "Index" }));
            HttpContext.Current.ClearError();
            HttpContext.Current.Response.Redirect("errorataspnet.html", true);
        }

        protected void Application_Stop()
        {
            dbLogger.StopLogging();
            DbInterception.Remove(sqlInterceptor);
            OrderBackgroundService.Instance.StopRefreshDataTimer();
            ReviewBackgroundService.Instance.StopRefreshDataTimer();
            ProductBackgroundService.Instance.StopRefreshDataTimer();
            SendNotificationQueue.Instance.StopRefreshDataTimer();
        }

        private bool IsWebApiRequest()
        {
            return HttpContext.Current.Request.AppRelativeCurrentExecutionFilePath.StartsWith(WebApiConfig.UrlPrefixRelative);
        }
    }
}
