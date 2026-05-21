using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using Stripe;
using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public class PaymentGatewayController : ApiController
    {
        private PaymentGatewayBusinessComponent comp = new PaymentGatewayBusinessComponent();
        
        [HttpPost]
        [ReturnType(DataType = typeof(PaymentResponseModel))]
        public IHttpActionResult ValidateOrderPlacement(PaymentRequestModel model)
        {
            var result = comp.ValidateOrderPlacement(model);
            return Ok<PaymentResponseModel>(result);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(PaymentResponseModel))]
        public IHttpActionResult PayOrder(PaymentRequestModel model)
        {
            var result = comp.PayOrder(model);
            if (result.StatusCode == StatusMessage.Successful && model.PaymentMethod == DBPaymentMethodEnum.Cash)
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Order, model.OrderID);
            }
            return Ok<PaymentResponseModel>(result);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(PaymentResponseModel))]
        public IHttpActionResult PayPalExecutePayment(PaymentRequestModel model)
        {
            var result = comp.PayPalExecutePayment(model.paymentId, model.token, model.PayerID, model.OrderID, model.RequestedByProfileId);
            if (result.StatusCode == StatusMessage.Successful)
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Order, model.OrderID);
            }
            return Ok<PaymentResponseModel>(result);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(PaymentResponseModel))]
        public IHttpActionResult StripeExecutePayment(PaymentRequestModel model)
        {
            var result = comp.StripeExecutePayment(model.paymentId, model.token, model.PayerID, model.OrderID, model.PaymentAmount, model.RequestedByProfileId);
            if (result.StatusCode == StatusMessage.Successful)
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Order, model.OrderID);
            }
            return Ok<PaymentResponseModel>(result);
        }
    }
}
