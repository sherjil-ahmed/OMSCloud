using Microsoft.Owin.Security.Infrastructure;
using OMSCloud.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OMSCloud.Services.WebAPIs
{
    public class ApplicationTokenProvider : AuthenticationTokenProvider
    {
        public override void Create(AuthenticationTokenCreateContext _context)
        {
            string remoteIp = string.Empty;
            if (_context.OwinContext.Request.RemoteIpAddress == _context.OwinContext.Request.LocalIpAddress)
            {
                //NLogger.Log.Debug("Security Token Generation phase(Pick IP), RemoteIpAddress & LocalIpAddress are same");
                if (_context.Request.Headers.ContainsKey("RemoteIP"))
                {
                    {                        
                        remoteIp = _context.Request.Headers["RemoteIP"];
                        //NLogger.Log.Debug("Security Token Generation phase(Pick IP), _context.Request.Headers[\"RemoteIP\"]" + remoteIp);
                    }
                }
            }
            if (string.IsNullOrEmpty(remoteIp))
            {
                //NLogger.Log.Debug("Security Token Generation phase(Pick IP), either RemoteIpAddress & LocalIpAddress are different or RemoteIP header not found.");
                remoteIp = _context.OwinContext.Request.RemoteIpAddress;
            }
            //NLogger.Log.Debug("Security Token Generation phase, _context.OwinContext.Request.RemoteIP: " + remoteIp);
            _context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddMinutes(30));
            if (!_context.Ticket.Properties.Dictionary.ContainsKey("IP"))
                _context.Ticket.Properties.Dictionary.Add("IP", remoteIp);
            //NLogger.Log.Debug("Security Token Generation phase, _context.Ticket.Properties.Dictionary KEY IP: " + _context.Ticket.Properties.Dictionary["IP"]);
            _context.SetToken(_context.SerializeTicket());
        }        
        public override void Receive(AuthenticationTokenReceiveContext _context)
        {
            _context.DeserializeTicket(_context.Token);            
        }        
    }
}