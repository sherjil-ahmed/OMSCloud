using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using OMSCloud.Services.WebAPIs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Web.Mvc;
using OMSCloud.Services.WebAPIs.Models;

namespace OMSCloud.Services.WebAPIs
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ApplicationAuthProvider : OAuthAuthorizationServerProvider
    {       
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                //Remove the comments from the below line context.SetError, and invalidate context 
                //if you want to force sending clientId/secrects once obtain access tokens. 
                context.Validated();
                //context.SetError("invalid_clientId", "ClientId should be sent.");
                //return Task.FromResult<object>(null);
            }
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {                  

            LoginViewModel model = new LoginViewModel();
            model.eMail = context.UserName;
            model.Password = context.Password;
            model.RememberMe = false;

            List<string> _errors = new List<string>();
            var userMngr = context.OwinContext.GetUserManager<ApplicationUserManager>();
            var signInMngr = context.OwinContext.Get<ApplicationSignInManager>();
            AccountStatusModel accountStatus = Security_ExtendedMethods.Login(model, userMngr, signInMngr, out _errors);
            SecurityStatus _retVal = accountStatus.StatusCode;
                    
            if (_retVal == SecurityStatus.Success)
            {
                var user = userMngr.FindByEmail(context.UserName);
                var identity = new ClaimsIdentity(context.Options.AuthenticationType, "OmsNameClaim", "OmsRoleClaim");
                identity.AddClaim(new Claim("Username", context.UserName));
                identity.AddClaim(new Claim("Password", context.Password));
                try
                {
                    identity.AddClaim(new Claim(MiscUtils.IdentityClaimForClientId , user.Id.ToString()));
                    //context.OwinContext.Authentication.User = new ClaimsPrincipal(identity);
                }
                catch (Exception ex)
                {
                    var str = ex.Message;
                }
                context.Validated(identity);
            }
            else
            {
                if (_errors.Count > 0)
                {
                    context.SetError("invalid_grant", _errors[0]);
                    context.Rejected();
                }
                else
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    context.Rejected();
                }
                return;
            }
        }
        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            return base.GrantRefreshToken(context);
        }
        public override Task ValidateAuthorizeRequest(OAuthValidateAuthorizeRequestContext context)
        {
            return base.ValidateAuthorizeRequest(context);
        }
    }
}