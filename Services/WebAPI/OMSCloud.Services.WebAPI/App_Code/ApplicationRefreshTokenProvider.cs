using Microsoft.Owin.Security.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OMSCloud.Services.WebAPIs
{    
    public class ApplicationRefreshTokenProvider : AuthenticationTokenProvider
    {
        public override void Create(AuthenticationTokenCreateContext _context)
        {
            _context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddMinutes(35)); 
            _context.SetToken(_context.SerializeTicket());
        }
       
        public override void Receive(AuthenticationTokenReceiveContext _context)
        {
            _context.DeserializeTicket(_context.Token);
        }            
    }
}