using Microsoft.Owin.Security.OAuth;
using OMSCloud.Contracts.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace OMSCloud.Services.WebAPIs
{
    public class ApplicationAuthBearerProvider : OAuthBearerAuthenticationProvider
    {
        //public static ConcurrentDictionary<string, string> validTokenForUser = new ConcurrentDictionary<string, string>();
        public override Task RequestToken(OAuthRequestTokenContext context)
        {
            return base.RequestToken(context);
        }        
        public override Task ValidateIdentity(OAuthValidateIdentityContext context)
        {
            //Claim claim = context.Ticket.Identity.Claims.Where(x => x.Type == "UserName").First();
            //if(!validTokenForUser.ContainsKey(claim.Value))
            //{
            //    context.Rejected();
            //    context.SetError("invalid_grant", "User does not exists");
            //    return base.ValidateIdentity(context);
            //}
            //else if(validTokenForUser[claim.Value] != context.Ticket.ToString())
            //{
            //    context.Rejected();
            //    context.SetError("invalid_grant", "Token Invalid");
            //    return base.ValidateIdentity(context);
            //}


            if (context.Ticket.Properties.Dictionary.ContainsKey("IP"))
            {
                //NLogger.Log.Debug("Security Token verification phase, context.OwinContext.Request.RemoteIpAddress: " + context.OwinContext.Request.RemoteIpAddress);
                //NLogger.Log.Debug("Security Token verification phase, context.Ticket.Properties.Dictionary[\"IP\"]: " + context.Ticket.Properties.Dictionary["IP"]);
                if (context.OwinContext.Request.RemoteIpAddress != context.Ticket.Properties.Dictionary["IP"])
                {
                    //NLogger.Log.Debug("Security Token verification phase, invalid_grant The host is invalid");
                    context.Rejected();
                    context.SetError("invalid_grant", "The host is invalid");
                }
            }
            else
            {
                //NLogger.Log.Debug("Security Token verification phase, context.Ticket.Properties.Dictionary does not ContainsKey IP " );
                context.Rejected();
            }

            return base.ValidateIdentity(context);
        }
    }
}