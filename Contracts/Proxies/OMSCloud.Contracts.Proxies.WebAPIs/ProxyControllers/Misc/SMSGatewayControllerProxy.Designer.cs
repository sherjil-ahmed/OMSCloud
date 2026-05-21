using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class SMSGatewayControllerProxy : BaseControllerProxy
    {
        public SMSResponseModel SendSMS(SMSRequestModel model)
        {
            string uri = "api/SMSGateway/SendSMS";

            var result = WebApiClient.Post<SMSResponseModel>(uri, model);
            return result;
        }
    }
}
