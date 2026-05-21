using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class PaymentControllerProxy : BaseControllerProxy//, IPaymentController
	{
        public List<PaymentModel> GetPaymentList()
        {
            string uri = "api/Payment/GetPaymentList";

            var result = WebApiClient.Get<List<PaymentModel>>(uri);
            return result;

        }
        public double GetOrderSum(SearchModel model)
        {
            string uri = "api/Payment/GetOrderSum";

            var result = WebApiClient.Post<double>(uri, model);
            return result;

        }
        public PaymentModel GetPaymentByOrderId(Int64 Id)
        {
            string uri = "api/Payment/GetPaymentByOrderId/" + Id.ToString() + "";

            var result = WebApiClient.Get<PaymentModel>(uri);
            return result;

        }
        public List<PaymentModel> GetList()
		{
			string uri = "api/Payment/GetList";

			var result =  WebApiClient.Get<List<PaymentModel>>(uri);
			return result;

		}
		public PaymentModel GetById(Int64 Id)
		{
			string uri = "api/Payment/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<PaymentModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(PaymentModel model)
		{
			string uri = "api/Payment/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(PaymentModel model)
		{
			string uri = "api/Payment/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(PaymentModel model)
		{
			string uri = "api/Payment/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Payment/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
