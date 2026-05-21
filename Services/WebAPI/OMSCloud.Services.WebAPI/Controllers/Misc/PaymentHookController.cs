using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;

using Stripe;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

using static OMSCloud.Contracts.Common.NLogger;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public class PaymentHookController : ApiController
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> StripeHook()
        {
            Log.Debug("StripeHook Called");
            var json = await new StreamReader(HttpContext.Current.Request.InputStream).ReadToEndAsync();
            if (string.IsNullOrEmpty(json.Trim()))
            {
                Log.Debug("json is empty");
                throw new Exception("json is empty");
            }
            try
            {
                var stripeEvent = EventUtility.ParseEvent(json);
                if (stripeEvent == null)
                {
                    Log.Debug("stripeEvent is NULL");
                    throw new Exception("stripeEvent is NULL");
                }
                // Handle the event
                if (stripeEvent.Type == "payment_intent.succeeded")
                {
                    var p = stripeEvent.Data.Object as PaymentIntent;
                    // Then define and call a method to handle the successful payment intent.
                    // handlePaymentIntentSucceeded(paymentIntent);
                }
                else if (stripeEvent.Type == "payment_method.attached")
                {
                    var p = stripeEvent.Data.Object as PaymentMethod;
                    // Then define and call a method to handle the successful attachment of a PaymentMethod.
                    // handlePaymentMethodAttached(paymentMethod);
                }
                else if (stripeEvent.Type == "payment_intent.created")
                {
                    var p = stripeEvent.Data.Object as PaymentIntent;
                }
                else if (stripeEvent.Type == "checkout.session.completed")//"Events.CheckoutSessionCompleted)
                {
                    Log.Debug("Stripe Event CheckoutSessionCompleted occured");
                    var p = stripeEvent.Data.Object as Stripe.Checkout.Session;
                    if (p.PaymentStatus == "paid")
                    {
                        Log.Debug("Stripe Event CheckoutSessionCompleted occured with payment status PAID");
                        var metaData = p.Metadata;
                        var orderId = Convert.ToInt64(metaData["OrderId"]);
                        var comp = new PaymentGatewayBusinessComponent();
                        Log.Debug(string.Format("PaymentId: {0}, customer Email: {1}, OrderId: {2}, Total Amount: {3}, ProfileId: {4}", 
                            p.Id,p.CustomerDetails.Email, orderId, p.AmountTotal, metaData["RequestedByProfileId"]) );
                        var result = comp.StripeExecutePayment(
                            p.Id,
                            "NA",
                            p.CustomerDetails.Email,
                            orderId,
                            (Convert.ToDouble(p.AmountTotal) / 100),  //why divide by 100 ???
                                                                      //Strip is sending back with extra 00 e.g if amount is 700 then   stripe sending 70000 with last 2 00's for decimal
                            Convert.ToInt64(metaData["RequestedByProfileId"])
                        );
                        Log.Debug("Result: {0}", result.StatusMessage);
                        if (result.StatusCode == StatusMessage.Successful)
                        {
                            Log.Debug("result successfull, sneding notification now.");
                            SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Order, orderId);
                        }
                    }
                    Log.Debug("Stripe Event CheckoutSessionCompleted exit");
                }
                else if (stripeEvent.Type == "checkout.session.async_payment_succeeded")
                {
                    var p = stripeEvent.Data.Object as PaymentIntent;
                }
                else if (stripeEvent.Type == "checkout.session.async_payment_failed")
                {
                    var p = stripeEvent.Data.Object as PaymentIntent;
                }
                // ... handle other event types
                else
                {
                    // Unexpected event type
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }
                return Ok();
            }
            catch (StripeException e)
            {
                var stripeDetail = string.Empty;
                if (e.StripeError != null)
                    stripeDetail = Environment.NewLine + "StripeError.Message : " + e.StripeError.Message + Environment.NewLine + "StripeError.ErrorDescription : " + e.StripeError.ErrorDescription + Environment.NewLine + "StripeError.Error : " + e.StripeError.Error;
                ErrorLog.Error(e, stripeDetail);
                throw;
                //return BadRequest();
            }
            catch (Exception ex)
            {
                ErrorLog.Error(ex);
                throw;
                //return BadRequest();
            }
        }
    }
}
