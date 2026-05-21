using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace OMSCloud.Business.Core
{
    public partial class SMSGatewayBusinessComponent
    {
        public SMSResponseModel SendSMS(SMSRequestModel model)
        {
            SMSResponseModel response = new SMSResponseModel();
            response.StatusCode = StatusMessage.Failure;
            response.StatusMessage = "Invalid Request";

            if (string.IsNullOrEmpty(model.SMSText) || string.IsNullOrEmpty(model.MobileNumber))
                return response;

            if(model.MobileNumber.StartsWith("00"))
            {
                model.MobileNumber = model.MobileNumber.Remove(0, 2);
                model.MobileNumber = "+" + model.MobileNumber;
            }
            else if(model.MobileNumber.StartsWith("0"))
            {
                model.MobileNumber = model.MobileNumber.Remove(0, 1);
                model.MobileNumber = "+" + model.MobileNumber;
            }

            if(!model.MobileNumber.StartsWith("+"))
            {
                response.StatusCode = StatusMessage.Failure;
                response.StatusMessage = "Invalid Mobile Number";
                return response;
            }

            string accountSid = Config.TwilioAccountSID;
            string authToken = Config.TwilioAuthToken;

            TwilioClient.Init(accountSid, authToken);

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                                                | SecurityProtocolType.Tls11
                                                | SecurityProtocolType.Tls12
                                                | SecurityProtocolType.Ssl3;

            var message = MessageResource.Create(
                body: model.SMSText,
                from: new Twilio.Types.PhoneNumber(Config.TwilioNumber),
                to: new Twilio.Types.PhoneNumber(model.MobileNumber)
            );

            response.StatusCode = StatusMessage.Successful;
            response.StatusMessage = "Message has been sent";
            response.SMSID = message.Sid;

            return response;
        }
    }
}
