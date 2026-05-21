using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OMSCloud.Web.MVC.Net
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "default",
                "{controller}/{action}/{Id}",
                new { controller = "Home", action = "Index", Id = UrlParameter.Optional },
                new string[] { "OMSCloud.Web.MVC.Net.Areas.Global.Controllers" }
            );
            routes.MapRoute(
                "GetProductByTitle",
                "Admin/Product/{productName}/Shop/{shopName}",
                new { controller = "Product", action = "GetProductByTitle" });
        }
    }
}
