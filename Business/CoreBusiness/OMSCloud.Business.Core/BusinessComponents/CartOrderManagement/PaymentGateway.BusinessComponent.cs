using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Business.Adapters;
using OMSCloud.Contracts.ViewModels;
using Stripe;
using System.Configuration;
using Stripe.Checkout;
using OMSCloud.Contracts.Common;
using PayPal.Api;
using Newtonsoft.Json;
using OMSCloud.Contracts.Common.ConfigMgmt;

namespace OMSCloud.Business.Core
{
    public partial class PaymentGatewayBusinessComponent
    {
        public PaymentResponseModel PayOrder(PaymentRequestModel model)
        {
            PaymentResponseModel response = new PaymentResponseModel();
            response.StatusCode = StatusMessage.Failure;
            response.StatusMessage = "Invalid parameters";
            response.RequestedByProfileId = model.RequestedByProfileId;

            OrderAdapter orders = new OrderAdapter();
            var order = orders.GetById(model.OrderID);

            if(order == null)
            {
                response.StatusCode = StatusMessage.Failure;
                response.StatusMessage = "Invalid Order";
                response.RequestedByProfileId = model.RequestedByProfileId;
                return response;
            }
            if(order.OrderStatusId >= (long)DBOrderStatusEnum.OrderPlaced)
            {
                response.StatusCode = StatusMessage.Failure;
                response.StatusMessage = "Order already placed";
                response.RequestedByProfileId = model.RequestedByProfileId;
                return response;
            }

            SupplierDeliveryOptionPairAdapter supplierDeliveryOptionPairAdapter = new SupplierDeliveryOptionPairAdapter();
            List<SupplierDeliveryOptionPairModel> listOfSupplierDeliveryOptionPair = supplierDeliveryOptionPairAdapter.GetSupplierDeliveryOptionBySupplierId(model.ShopID);
            SupplierDeliveryOptionPairModel supplierDeliveryOptionPairModel = null;

            if (model.DeliveryOption != DBDeliveryOptionEnum.SelfPickUp)
            {
                SupplierAdapter supplierAdapter = new SupplierAdapter();
                SupplierViewModel supplier = supplierAdapter.GetSupplierById(model.ShopID);

                if (supplier == null)
                {
                    response.StatusCode = StatusMessage.Failure;
                    response.StatusMessage = "Invalid Shop";
                    response.RequestedByProfileId = model.RequestedByProfileId;
                    return response;
                }
                #region New Logic
                if (model.SelectedProvinceID == supplier.OperatingProvinceID)
                {
                    if (model.SelectedCityID == supplier.OperatingCityID)
                    {
                        //Within City
                        supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.ShopDelivery).FirstOrDefault();
                        if (supplierDeliveryOptionPairModel == null)
                        {
                            //Country Wide Shipping
                            //selectedDeliveryOptionEnum = DBDeliveryOptionEnum.DeliveryAcrossCountry;
                            supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliveryAcrossCountry).FirstOrDefault();
                        }
                    }
                    else
                    {
                        //may be surrounding city
                        //lets check if it is Surrounding Cities or not
                        supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliverSurroundingCities).FirstOrDefault();
                        if (supplierDeliveryOptionPairModel != null)
                        {
                            if (supplierDeliveryOptionPairModel.SurroundingCitiesIDs.Split(',').Where(x => Convert.ToInt64(x) == model.SelectedCityID).Count() == 0)
                            {
                                supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliveryAcrossCountry).FirstOrDefault();
                            }
                        }
                        else
                        {
                             supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliveryAcrossCountry).FirstOrDefault();
                        }
                    }
                }
                else {
                    //Country Wide Shipping
                    //selectedDeliveryOptionEnum = DBDeliveryOptionEnum.DeliveryAcrossCountry;
                    supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliveryAcrossCountry).FirstOrDefault();
                }
                #endregion New Logic
                #region old logic
                /*
                if (model.SelectedProvinceID != supplier.OperatingProvinceID )
                {
                    //Country Wide Shipping
                    supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliveryAcrossCountry).FirstOrDefault();
                }
                else if(model.SelectedCityID == supplier.OperatingCityID)
                {
                    //Within City
                    supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.ShopDelivery).FirstOrDefault();
                }
                else
                {
                    //Surrounding Cities
                    supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliverSurroundingCities).FirstOrDefault();
                    if(supplierDeliveryOptionPairModel != null)
                    {
                        if (supplierDeliveryOptionPairModel.SurroundingCitiesIDs.Split(',').Where(x => Convert.ToInt64(x) == model.SelectedCityID).Count() == 0)
                        {
                            response.StatusCode = StatusMessage.Failure;
                            response.StatusMessage = "Invalid Sorrounding City";
                            response.RequestedByProfileId = model.RequestedByProfileId;
                            return response;
                        }
                    }                    
                }

                */
                #endregion old logic
                if (supplierDeliveryOptionPairModel == null)
                {
                    response.StatusCode = StatusMessage.Failure;
                    response.StatusMessage = "Invalid Delivery Option";
                    response.RequestedByProfileId = model.RequestedByProfileId;
                    return response;
                }

                if(model.DeliveryCharges != supplierDeliveryOptionPairModel.DeliveryCharges)
                {
                    response.StatusCode = StatusMessage.Failure;
                    response.StatusMessage = "Invalid Delivery Charges";
                    response.RequestedByProfileId = model.RequestedByProfileId;
                    return response;
                }

                if(model.MinOrderLimit != supplierDeliveryOptionPairModel.MinOrderLimit)
                {
                    response.StatusCode = StatusMessage.Failure;
                    response.StatusMessage = "Invalid Min Order Limit";
                    response.RequestedByProfileId = model.RequestedByProfileId;
                    return response;
                }

                if(supplierDeliveryOptionPairModel.MinOrderLimit > order.PaymentTotal)
                {
                    response.StatusCode = StatusMessage.Failure;
                    response.StatusMessage = "Payment total does not satisfy minimum order limit";
                    response.RequestedByProfileId = model.RequestedByProfileId;
                    return response;
                }

                AddressAdapter addressAdapter = new AddressAdapter();
                AddressViewModel addressModel = addressAdapter.GetAddressByAddressID(model.DeliveryAddressID);
                if (addressModel == null)
                {
                    response.StatusCode = StatusMessage.Failure;
                    response.StatusMessage = "Invalid Address";
                    response.RequestedByProfileId = model.RequestedByProfileId;
                    return response;
                }

                if(addressModel.OperatingCityID != model.SelectedCityID || addressModel.OperatingProvinceID != model.SelectedProvinceID)
                {
                    response.StatusCode = StatusMessage.Failure;
                    response.StatusMessage = "Invalid Province or City";
                    response.RequestedByProfileId = model.RequestedByProfileId;
                    return response;
                }

                order.DeliveryAddressID = model.DeliveryAddressID;
                order.DeliveryAddress = JsonConvert.SerializeObject(addressModel);
            }
            else //SelfPickup
            {
                supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.SelfPickUp).FirstOrDefault();
                if (supplierDeliveryOptionPairModel == null)
                {
                    response.StatusCode = StatusMessage.Failure;
                    response.StatusMessage = "Invalid Delivery Option";
                    response.RequestedByProfileId = model.RequestedByProfileId;
                    return response;
                }
                model.DeliveryCharges = 0;
                
            }
            order.DeliveryOptionID = supplierDeliveryOptionPairModel.SupplierDeliveryOptionPairID;
            //double PaymentTotal = (order.OrderTotal - order.DiscountTotal) + model.DeliveryCharges;
            double PaymentTotal = (order.OrderTotal) + model.DeliveryCharges;
            order.DeliveryTotal = model.DeliveryCharges;
            order.PaymentTotal = PaymentTotal;

            if (order.PaymentTotal != model.PaymentAmount)
            {
                response.StatusCode = StatusMessage.Failure;
                response.StatusMessage = "Invalid Payment Total";
                response.RequestedByProfileId = model.RequestedByProfileId;
                return response;
            }

            if (!orders.UpdateOrder(order))
            {
                response.StatusCode = StatusMessage.Failure;
                response.StatusMessage = "Unable to update order";
                response.RequestedByProfileId = model.RequestedByProfileId;
                return response;
            }

            if (model.PaymentMethod == DBPaymentMethodEnum.Cash)
            {
                OrderAdapter orders1 = new OrderAdapter();
                var order1 = orders1.GetById(model.OrderID);
                //var order1 = orders.GetById(model.OrderID);
                bool result = UpdatePaymentAndOrder(order1, PaymentTotal, DBPaymentMethodEnum.Cash, "NA", "NA", model.RequestedByProfileId);
                if(result)
                {
                    response.StatusCode = StatusMessage.Successful;
                    response.StatusMessage = "Order has been placed";
                    response.IsRedirectionRequired = false;
                    response.RequestedByProfileId = model.RequestedByProfileId;
                }
                return response;
            }
            else if(model.PaymentMethod == DBPaymentMethodEnum.Stripe)
            {
                StripeConfiguration.ApiKey = Config.StripeSecretKey;

                var domain = Config.PublicSiteURL;

                AppConfigAdapter appConfigAdapter = new AppConfigAdapter();
                AppConfigModel appConfigModel = appConfigAdapter.GetAppConfigById((long)DBAppConfigEnum.CurrencyCode);

                List<SessionLineItemOptions> LineItems = new List<SessionLineItemOptions>();
                SessionLineItemOptions sessionLineItemOptions = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        UnitAmountDecimal = (long)(PaymentTotal * 100),
                        Currency = appConfigModel.ConfigValue.ToLower(),
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = "Order #:" + model.OrderID,
                            Description = "Order #:" + model.OrderID,
                        }
                    },
                    Quantity = 1,
                };

                LineItems.Add(sessionLineItemOptions);

                //var metaData = new Dictionary<string, string>();
                ///metaData.Add("OrderID", model.OrderID.ToString());

                var options = new SessionCreateOptions
                {
                    //CustomerEmail = _authService.GetUserEmail(),
                    //ShippingAddressCollection = new SessionShippingAddressCollectionOptions
                    //{
                    //    AllowedCountries = new List<string> { "GB" }//appConfigModel.Description.ToUpper() }
                    //},
                    PaymentMethodTypes = new List<string>
                    {
                        "card",
                    },
                    LineItems = LineItems,
                    Metadata = new Dictionary<string, string>
                    {
                            { "OrderId", model.OrderID.ToString()},
                            { "RequestedByProfileId", model.RequestedByProfileId.ToString()},
                        },
                    Mode = "payment",
                    SuccessUrl = domain + "PaymentSuccess",
                    CancelUrl = domain + "PaymentCancel",
                };
                var service = new SessionService();
                Session session = service.Create(options);
                //return Json(new { id = session.Id });

                response.StatusCode = StatusMessage.Successful;
                response.StatusMessage = "Redirect to Stripe";
                response.IsRedirectionRequired = true;
                response.APIKey = Config.StripeApiKey;
                response.SessionID = session.Id;
                response.RequestedByProfileId = model.RequestedByProfileId;

                return response;
            }
            else if (model.PaymentMethod == DBPaymentMethodEnum.PayPal)
            {
                var domain = Config.PublicSiteURL;
                var payment = PayPalService.CreatePayment(domain, "sale", model, PaymentTotal);

                response.StatusCode = StatusMessage.Successful;
                response.StatusMessage = "Redirect to Paypal";
                response.IsRedirectionRequired = true;
                response.APIKey = "";
                response.SessionID = payment.GetApprovalUrl();
                response.RequestedByProfileId = model.RequestedByProfileId;

                return response;
                
            }         
            
            return response;
        }
        public PaymentResponseModel PayPalExecutePayment(string paymentId, string token, string PayerID, long OrderID, long RequestedByProfileId)
        {
            PaymentResponseModel response = new PaymentResponseModel();
            response.StatusCode = StatusMessage.Failure;
            response.StatusMessage = "Invalid parameters";
            response.RequestedByProfileId = RequestedByProfileId;

            if (string.IsNullOrEmpty(paymentId) || string.IsNullOrEmpty(PayerID))
            {
                response.StatusCode = StatusMessage.Failure;
                response.StatusMessage = "Invalid payment details";
                response.RequestedByProfileId = RequestedByProfileId;
                return response;
            }

            var payment = PayPalService.ExecutePayment(paymentId, PayerID);
            if(payment.state == "approved")
            {
                OrderAdapter orders = new OrderAdapter();
                var order = orders.GetById(OrderID);
                var AmountTotal = Convert.ToDouble(payment.transactions[0].amount.total);
                bool result = UpdatePaymentAndOrder(order, AmountTotal, DBPaymentMethodEnum.PayPal, token, payment.id, RequestedByProfileId);
                if (result)
                {
                    response.StatusCode = StatusMessage.Successful;
                    response.StatusMessage = "Payment has been successfully received";
                    response.IsRedirectionRequired = false;
                    response.APIKey = payment.id;
                    response.SessionID = (payment.transactions.Count > 0 ? payment.transactions[0].invoice_number : "");
                    response.RequestedByProfileId = RequestedByProfileId;
                }
                return response;
            }

            return response;
        }
        public PaymentResponseModel StripeExecutePayment(string paymentId, string token, string PayerID, long OrderID, double Amount, long RequestedByProfileId)
        {
            PaymentResponseModel response = new PaymentResponseModel();
            response.StatusCode = StatusMessage.Failure;
            response.StatusMessage = "Invalid parameters";
            response.RequestedByProfileId = RequestedByProfileId;

            if (string.IsNullOrEmpty(paymentId) )//|| string.IsNullOrEmpty(PayerID))
            {
                response.StatusCode = StatusMessage.Failure;
                response.StatusMessage = "Invalid payment details";
                response.RequestedByProfileId = RequestedByProfileId;
                return response;
            }

            OrderAdapter orders = new OrderAdapter();
            var order = orders.GetById(OrderID);
            if (order.PaymentTotal != Amount)
            {
                Amount = order.PaymentTotal;
            }
            bool result = UpdatePaymentAndOrder(order, Amount, DBPaymentMethodEnum.Stripe, token, paymentId, RequestedByProfileId);

            if (result)
            {
                response.StatusCode = StatusMessage.Successful;
                response.StatusMessage = "Payment has been successfully received";
                response.IsRedirectionRequired = false;
                response.APIKey = paymentId;
                response.SessionID = PayerID;
                response.RequestedByProfileId = RequestedByProfileId;
            }

            return response;
        }
        private bool UpdatePaymentAndOrder(OrderModel order, double OrderTotal, DBPaymentMethodEnum PayTypeID, string PaymentToken, string PaymentGatewayTransactionID, long RequestedByProfileId)
        {
            OrderAdapter orders = new OrderAdapter();
            PaymentModel payment = new PaymentModel
            {
                OrderID = order.OrderID,
                Amount = OrderTotal,
                IsAmountVerified = false,
                PayTypeID = (long)PayTypeID,
                PaymentToken = PaymentToken,
                PaymentGatewayTransactionID = PaymentGatewayTransactionID,
                RequestedByProfileId = RequestedByProfileId                
            };

            PaymentAdapter paymentAdapter = new PaymentAdapter();
            if (paymentAdapter.AddPayment(payment).HasValue)
            {
                order.OrderStatusId = (long)DBOrderStatusEnum.OrderPlaced;

                AppConfigBusinessComponent appconfig = new AppConfigBusinessComponent();

                bool isProcessingFeePercentage = Convert.ToBoolean(appconfig.GetAppConfigById((long)DBAppConfigEnum.IsProcessingFeePercentage).ConfigValue);
                bool isPaymentGatewayPercentage = Convert.ToBoolean(appconfig.GetAppConfigById((long)DBAppConfigEnum.IsPaymentGatewayFeePercentage).ConfigValue);

                double processingFee = Convert.ToDouble(appconfig.GetAppConfigById((long)DBAppConfigEnum.ProcessingFee).ConfigValue);
                double gatewayFee = Convert.ToDouble(appconfig.GetAppConfigById((long)DBAppConfigEnum.PaymentGatewayFee).ConfigValue);


                if (PayTypeID == DBPaymentMethodEnum.Cash)
                {                    
                    order.CalculatedPayIn = (isProcessingFeePercentage ? ((OrderTotal * processingFee) / 100) : processingFee);
                    order.CalculatedPayout = 0;

                    order.ActualPayIn = order.CalculatedPayIn;
                    order.ActualPayout = order.CalculatedPayout;
                }
                else
                {
                    order.CalculatedPayIn = 0;
                    order.CalculatedPayout = OrderTotal - ((isProcessingFeePercentage ? ((OrderTotal * processingFee) / 100) : processingFee) + (isPaymentGatewayPercentage ? ((OrderTotal * gatewayFee) / 100) : gatewayFee));

                    order.ActualPayIn = order.CalculatedPayIn;
                    order.ActualPayout = order.CalculatedPayout;
                }

                return orders.UpdateOrder(order);                    
            }

            return false;
        }

        public PaymentResponseModel ValidateOrderPlacement(PaymentRequestModel model)
        {
            PaymentResponseModel response = new PaymentResponseModel();
            response.StatusCode = StatusMessage.Failure;
            response.StatusMessage = "Successful";
            response.RequestedByProfileId = model.RequestedByProfileId;

            OrderAdapter orders = new OrderAdapter();
            var order = orders.GetById(model.OrderID);

            if (order == null)
            {
                response.StatusMessage = "Invalid Order";
            }
            if (order.OrderStatusId >= (long)DBOrderStatusEnum.OrderPlaced)
            {
                response.StatusMessage = "Order already placed";
            }

            SupplierDeliveryOptionPairAdapter supplierDeliveryOptionPairAdapter = new SupplierDeliveryOptionPairAdapter();
            List<SupplierDeliveryOptionPairModel> listOfSupplierDeliveryOptionPair = supplierDeliveryOptionPairAdapter.GetSupplierDeliveryOptionBySupplierId(model.ShopID);
            SupplierDeliveryOptionPairModel supplierDeliveryOptionPairModel = null;

            if (model.DeliveryOption != DBDeliveryOptionEnum.SelfPickUp)
            {
                SupplierAdapter supplierAdapter = new SupplierAdapter();
                SupplierViewModel supplier = supplierAdapter.GetSupplierById(model.ShopID);

                if (supplier == null)
                {
                    response.StatusMessage = "Invalid Shop";
                }
                #region New Logic
                if (model.SelectedProvinceID == supplier.OperatingProvinceID)
                {
                    if (model.SelectedCityID == supplier.OperatingCityID)
                    {
                        //Within City
                        supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.ShopDelivery).FirstOrDefault();
                        if (supplierDeliveryOptionPairModel == null)
                        {
                            //Country Wide Shipping
                            //selectedDeliveryOptionEnum = DBDeliveryOptionEnum.DeliveryAcrossCountry;
                            supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliveryAcrossCountry).FirstOrDefault();
                        }
                    }
                    else
                    {
                        //may be surrounding city
                        //lets check if it is Surrounding Cities or not
                        supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliverSurroundingCities).FirstOrDefault();
                        if (supplierDeliveryOptionPairModel != null)
                        {
                            if (supplierDeliveryOptionPairModel.SurroundingCitiesIDs.Split(',').Where(x => Convert.ToInt64(x) == model.SelectedCityID).Count() == 0)
                            {
                                supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliveryAcrossCountry).FirstOrDefault();
                            }
                        }
                        else
                        {
                            supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliveryAcrossCountry).FirstOrDefault();
                        }
                    }
                }
                else
                {
                    //Country Wide Shipping
                    supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliveryAcrossCountry).FirstOrDefault();
                }
                #endregion NewLogic

                if (supplierDeliveryOptionPairModel == null)
                {
                    response.StatusMessage = "Invalid Delivery Option";
                }

                if (model.DeliveryCharges != supplierDeliveryOptionPairModel.DeliveryCharges)
                {
                    response.StatusMessage = "Invalid Delivery Charges";
                }

                if (model.MinOrderLimit != supplierDeliveryOptionPairModel.MinOrderLimit)
                {
                    response.StatusMessage = "Invalid Min Order Limit";
                }

                if (supplierDeliveryOptionPairModel.MinOrderLimit > order.PaymentTotal)
                {
                    response.StatusMessage = "Payment total does not satisfy minimum order limit";
                }

                AddressAdapter addressAdapter = new AddressAdapter();
                AddressViewModel addressModel = addressAdapter.GetAddressByAddressID(model.DeliveryAddressID);
                if (addressModel == null)
                {
                    response.StatusMessage = "Invalid Address";
                }

                if (addressModel.OperatingCityID != model.SelectedCityID || addressModel.OperatingProvinceID != model.SelectedProvinceID)
                {
                    response.StatusMessage = "Invalid Province or City";
                }

                order.DeliveryAddressID = model.DeliveryAddressID;
                order.DeliveryAddress = JsonConvert.SerializeObject(addressModel);
            }
            else //SelfPickup
            {
                supplierDeliveryOptionPairModel = listOfSupplierDeliveryOptionPair.Where(x => x.DeliveryOptionID == (long)DBDeliveryOptionEnum.SelfPickUp).FirstOrDefault();
                if (supplierDeliveryOptionPairModel == null)
                {
                    response.StatusMessage = "Invalid Delivery Option";
                }
                model.DeliveryCharges = 0;

            }
            order.DeliveryOptionID = supplierDeliveryOptionPairModel.SupplierDeliveryOptionPairID;
            //double PaymentTotal = (order.OrderTotal - order.DiscountTotal) + model.DeliveryCharges;
            double PaymentTotal = (order.OrderTotal) + model.DeliveryCharges;
            order.DeliveryTotal = model.DeliveryCharges;
            order.PaymentTotal = PaymentTotal;

            if (order.PaymentTotal != model.PaymentAmount)
            {
                response.StatusMessage = "Invalid Payment Total";
            }

            if (!orders.UpdateOrder(order))
            {
                response.StatusMessage = "Unable to update order";
            }
            if (response.StatusMessage == "Successful")
                response.StatusCode = StatusMessage.Successful;
            return response;
        }
    }
    public static class PayPalService
    {
        public static Payment CreatePayment(string baseUrl, string intent, PaymentRequestModel order, double OrderTotal)
        {
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            
            var apiContext = PaypalConfiguration.GetAPIContext();

            // Payment Resource
            var payment = new Payment()
            {
                intent = intent,    // `sale` or `authorize`
                payer = new Payer() { payment_method = "paypal" },
                transactions = GetTransactionsList(order, OrderTotal),
                redirect_urls = GetReturnUrls(baseUrl, intent)
            };

            // Create a payment using a valid APIContext
            var createdPayment = payment.Create(apiContext);

            return createdPayment;
        }

        private static List<Transaction> GetTransactionsList(PaymentRequestModel order, double OrderTotal)
        {
            AppConfigAdapter appConfigAdapter = new AppConfigAdapter();
            AppConfigModel appConfigModel = appConfigAdapter.GetAppConfigById((long)DBAppConfigEnum.CurrencyCode);

            // A transaction defines the contract of a payment
            // what is the payment for and who is fulfilling it. 
            var transactionList = new List<Transaction>();

            // The Payment creation API requires a list of Transaction; 
            // add the created Transaction to a List
            transactionList.Add(new Transaction()
            {
                description = "Order #:"+order.OrderID,
                invoice_number = Guid.NewGuid().ToString(),
                amount = new Amount()
                {
                    currency = appConfigModel.ConfigValue,
                    total = OrderTotal.ToString(),       // Total must be equal to sum of shipping, tax and subtotal.                    
                },
                item_list = new ItemList()
                {
                    items = new List<Item>()
            {
                new Item()
                {
                    name = "Order #:"+order.OrderID,
                    currency = appConfigModel.ConfigValue,
                    price = OrderTotal.ToString(),
                    quantity = "1",
                    sku = "Order #:"+order.OrderID
                }
            }
                }
            });
            return transactionList;
        }

        private static RedirectUrls GetReturnUrls(string baseUrl, string intent)
        {
            var returnUrl = intent == "sale" ? "PaymentResponse?" : "PaymentResponse?";

            // Redirect URLS
            // These URLs will determine how the user is redirected from PayPal 
            // once they have either approved or canceled the payment.
            return new RedirectUrls()
            {
                cancel_url = baseUrl + "PaymentCancel?",
                return_url = baseUrl + returnUrl
            };
        }

        public static Payment ExecutePayment(string paymentId, string payerId)
        {
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            var apiContext = PaypalConfiguration.GetAPIContext();

            var paymentExecution = new PaymentExecution() { payer_id = payerId };
            var payment = new Payment() { id = paymentId };

            // Execute the payment.
            var executedPayment = payment.Execute(apiContext, paymentExecution);

            return executedPayment;
        }
    }
    public static class PaypalConfiguration
    {
        //Variables for storing the clientID and clientSecret key  
        public readonly static string ClientId;
        public readonly static string ClientSecret;
        public readonly static bool mode;
        //Constructor  
        static PaypalConfiguration()
        {
            //var config = GetConfig();
            ClientId = Config.PayPalclientId;
            ClientSecret = Config.PayPalclientSecret;
            mode = Config.Mode;
        }
        // getting properties from the web.config  
        public static Dictionary<string, string> GetConfig()
        {
            var sdkConfig = new Dictionary<string, string>();
            if (mode)
                sdkConfig = new Dictionary<string, string> { { "mode", "live" } };
            //else
                //sdkConfig = PayPal.Api.ConfigManager.Instance.GetProperties();
            return sdkConfig;
        }
        private static string GetAccessToken()
        {
            // getting accesstocken from paypal  
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken  
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}
