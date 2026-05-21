using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Filters;
using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;
using OMSCloud.Contracts.Common.ConfigMgmt;

namespace OMSCloud.Services.WebAPIs
{
    public static class WebApiConfig
    {
        public static string UrlPrefix { get { return "api"; } }
        public static string UrlPrefixRelative { get { return "~/api"; } }

        public static void Register(HttpConfiguration config)
        {
            //Enable Cors
            //var cors = new EnableCorsAttribute("*", "*", "*");
            //config.EnableCors();
            var IsSecure = Config.IsSecure;
            if(IsSecure)
                config.Filters.Add(new SecureAttribute());
            config.Filters.Add(new ApiExceptionFilterAttribute());

            // Web API configuration and services
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}/{id1}",
                defaults: new { controller = "WebApiExplorer", action = "Explore", id = RouteParameter.Optional, id1 = RouteParameter.Optional }
                //new string[] { "OMSCloud.Web.MVC.Net.Areas.Admin.Controllers" }
            );
            //route.RouteHandler = new MyHttpControllerRouteHandler();
        }
    }

    //public class MyHttpControllerHandler : HttpControllerHandler, IRequiresSessionState
    //{
    //    public MyHttpControllerHandler(RouteData routeData) : base(routeData)
    //    { }
    //}

    //public class MyHttpControllerRouteHandler : HttpControllerRouteHandler
    //{
    //    protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
    //    {
    //        return new MyHttpControllerHandler(requestContext.RouteData);
    //    }
    //}
}
