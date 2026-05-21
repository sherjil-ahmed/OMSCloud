using OMSCloud.Web.MVC.Net;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new SecureAttribute());
            //Anti forgery token hack for every post request
            FilterProviders.Providers.Add(new AntiForgeryTokenFilter());
        }
    }
}
