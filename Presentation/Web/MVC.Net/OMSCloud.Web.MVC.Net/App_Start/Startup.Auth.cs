using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using OMSCloud.Web.MVC.Net.Areas.Security.Models;
using OMSCloud.Web.MVC.Net.Areas.Security;
using static Security_ExtendedMethods;

namespace OMSCloud.Web.MVC.Net
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(SecurityDbContext.CreateInstance);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);


            var DefaultAccountSessionTimeSpan = GetConfigSettingAsDouble(cKey_AccountSessionTimeSpan, 3);


            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Public/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator
                                            .OnValidateIdentity<ApplicationUserManager, ApplicationUser, long>(
                                                    validateInterval: TimeSpan.FromMinutes(DefaultAccountSessionTimeSpan),
                                                    regenerateIdentityCallback: (manager, user) => user.GenerateUserIdentityAsync(manager),
                                                    getUserIdCallback: (Id) => (Id.GetUserId<long>()))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }

        //private void F()
        //{
        //    var actionDescriptor = filterContext.ActionDescriptor;
        //    var controllerType = actionDescriptor.ControllerDescriptor.ControllerType;
        //    var controllerName = actionDescriptor.ControllerDescriptor.ControllerName;
        //    var actionName = actionDescriptor.ActionName;

        //    var area = string.Empty;
        //    var parts = controllerType.Namespace.Split('.');
        //    if (parts.Length > 1)
        //        area = parts[parts.Length - 2];
        //}
    }
}