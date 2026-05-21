using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using OMSCloud.Web.MVC.Net.Areas.Public;
using OMSCloud.Web.MVC.Net.Areas.Admin;
using OMSCloud.Contracts.Common;
using static OMSCloud.Contracts.Common.NLogger;
using System.Data.Entity.Infrastructure.Interception;
using System.IO;
using OMSCloud.DataStore.EF;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Proxies.WebAPIs.ProxyControllers.TokenManagement;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Web.MVC.Net.Areas.Admin.Controllers;

namespace OMSCloud.Web.MVC.Net
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static DatabaseLogger d = null;
        private static SqlInterceptorMvc sqlInterceptor = new SqlInterceptorMvc();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //BundleConfigPublic.RegisterBundles(BundleTable.Bundles);
            BundleConfigAdmin.RegisterBundles(BundleTable.Bundles);
            BundleConfigSecurity.RegisterBundles(BundleTable.Bundles);

            string path = Path.Combine(Server.MapPath("/"), "DBLog");//, "DBLog.log"
            if (!File.Exists(path))
                Directory.CreateDirectory(path);

            var dt = DateTime.Now;
            d = new DatabaseLogger(Path.Combine(path, "DBLog_" + dt.Day + dt.Month + dt.Year + "_" + dt.Hour + dt.Minute + dt.Second + dt.Millisecond + ".log"), true);
            d.StartLogging();
            try
            {
                HomeController.SetupAppConfig();
            }
            catch (HttpResponseException httpEx)
            {
                var additionalExceptionDetail = httpEx.Response.Content.ReadAsStringAsync().Result;
                ErrorLog.Error(httpEx, "Admin Portal MVC.NET Application_Start() : " + additionalExceptionDetail);
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex, "Admin Portal MVC.NET Application_Start()" );
            }
            DbInterception.Add(sqlInterceptor);

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
            HttpContext.Current.Response.Redirect("/errorataspnet.html", true);
        }

        protected void Application_Stop()
        {
            d.StopLogging();
            DbInterception.Remove(sqlInterceptor);
        }
    }
}
