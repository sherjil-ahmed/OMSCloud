using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class OrderPaymentControllerProxy : BaseControllerProxy//, IOrderPaymentController
	{
		public List<OrderPaymentModel> GetList()
		{
			string uri = "api/OrderPayment/GetList";

			var result =  WebApiClient.Get<List<OrderPaymentModel>>(uri);
			return result;

		}
		public OrderPaymentModel GetById(Int64 Id)
		{
			string uri = "api/OrderPayment/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<OrderPaymentModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(OrderPaymentModel model)
		{
			string uri = "api/OrderPayment/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(OrderPaymentModel model)
		{
			string uri = "api/OrderPayment/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(OrderPaymentModel model)
		{
			string uri = "api/OrderPayment/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/OrderPayment/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
