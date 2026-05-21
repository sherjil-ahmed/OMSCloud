using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class OrderDeliveryDetailControllerProxy : BaseControllerProxy//, IOrderDeliveryDetailController
	{

        public List<OrderDeliveryDetailModel> GetOrderDeliveryDetailList()
        {
            string uri = "api/OrderDeliveryDetail/GetOrderDeliveryDetailList";

            var result = WebApiClient.Get<List<OrderDeliveryDetailModel>>(uri);
            return result;
        }

        public List<OrderDeliveryDetailModel> GetList()
		{
			string uri = "api/OrderDeliveryDetail/GetList";

			var result =  WebApiClient.Get<List<OrderDeliveryDetailModel>>(uri);
			return result;
		}
        
        public OrderDeliveryDetailModel GetOrderDeliveryDetailById(Int64 Id)
        {
            string uri = "api/OrderDeliveryDetail/GetOrderDeliveryDetailById/" + Id.ToString() + "";

            var result = WebApiClient.Get<OrderDeliveryDetailModel>(uri);
            return result;
        }

        public OrderDeliveryDetailModel GetById(Int64 Id)
		{
			string uri = "api/OrderDeliveryDetail/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<OrderDeliveryDetailModel>(uri);
			return result;
		}
		public Nullable<Int64> Put(OrderDeliveryDetailModel model)
		{
			string uri = "api/OrderDeliveryDetail/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;
		}
		public Boolean Post(OrderDeliveryDetailModel model)
		{
			string uri = "api/OrderDeliveryDetail/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;
		}
		public Boolean Delete(OrderDeliveryDetailModel model)
		{
			string uri = "api/OrderDeliveryDetail/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;
		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/OrderDeliveryDetail/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;
		}
	}
}
