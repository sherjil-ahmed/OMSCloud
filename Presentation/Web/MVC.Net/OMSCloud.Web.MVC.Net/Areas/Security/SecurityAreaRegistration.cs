using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Security
{
    public class SecurityAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Security";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Security_default",
                "Security/{controller}/{action}/{Id}",
                new { controller = "Home", action = "Index", Id = UrlParameter.Optional },
                new string[] { "OMSCloud.Web.MVC.Net.Areas.Security.Controllers" }
            );
        }
    }
}