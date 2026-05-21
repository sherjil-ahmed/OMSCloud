using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(OMSCloud.Web.MVC.Net.Startup))]
namespace OMSCloud.Web.MVC.Net
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
