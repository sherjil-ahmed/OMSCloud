using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Web.Cors;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Services.WebAPIs.Models;
using Owin;

[assembly: OwinStartup(typeof(OMSCloud.Services.WebAPIs.Startup))]

namespace OMSCloud.Services.WebAPIs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(SecurityDbContext.CreateInstance);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);


            var DefaultAccountSessionTimeSpan = 30; //GetConfigSettingAsDouble(cKey_AccountSessionTimeSpan, 3);


            // For more information on how to configure your application, //visit http://go.microsoft.com/fwlink/?LinkID=316888
            #region Cors Implementation            
            var allowedOriginsConfig = Config.Origins;
            var allowedOrigins = allowedOriginsConfig
                .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var corsPolicy = new CorsPolicy()
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                SupportsCredentials = true,
                AllowAnyOrigin = false
            };

            //corsPolicy.Methods.Add("GET");
            //corsPolicy.Methods.Add("PUT");
            //corsPolicy.Methods.Add("POST");
            //corsPolicy.Methods.Add("DELETE");
            //corsPolicy.Methods.Add("OPTIONS");

            foreach (var origin in allowedOrigins)
                corsPolicy.Origins.Add(origin);

            var policyProvider = new CorsPolicyProvider()
            {
                PolicyResolver = (context) => Task.FromResult(corsPolicy)
            };
            var corsOptions = new CorsOptions()
            {
                PolicyProvider = policyProvider
            };

            app.UseCors(corsOptions);
            //app.UseCors(CorsOptions.AllowAll);
            #endregion

            app.MapSignalR("/signalr", new HubConfiguration() { EnableJSONP = true  });

            OAuthAuthorizationServerOptions option = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new ApplicationAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(DefaultAccountSessionTimeSpan),
//#if DEBUG
                AllowInsecureHttp = true,
//#endif
                RefreshTokenProvider = new ApplicationRefreshTokenProvider(),
                AccessTokenProvider = new ApplicationTokenProvider()
            };
            app.UseOAuthAuthorizationServer(option);
            OAuthBearerAuthenticationOptions optionBearer = new OAuthBearerAuthenticationOptions
            {
                AccessTokenProvider = new ApplicationTokenProvider(),
                Provider = new ApplicationAuthBearerProvider()
            };
            app.UseOAuthBearerAuthentication(optionBearer);
        }
    }
}
