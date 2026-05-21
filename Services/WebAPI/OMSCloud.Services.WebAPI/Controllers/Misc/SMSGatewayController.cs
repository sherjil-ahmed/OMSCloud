using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public class SMSGatewayController : ApiController
    {
        private SMSGatewayBusinessComponent comp = new SMSGatewayBusinessComponent();

        [HttpPost]
        [ReturnType(DataType = typeof(SMSResponseModel))]
        public IHttpActionResult SendSMS(SMSRequestModel model)
        {
            return Ok<SMSResponseModel>(comp.SendSMS(model));
        }
    }
}
