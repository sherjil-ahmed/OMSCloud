using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class OrderStatusControllerProxy : BaseControllerProxy//, IOrderStatusController
	{
        
        public List<OrderStatusModel> GetList()
		{
			string uri = "api/OrderStatus/GetList";

			var result =  WebApiClient.Get<List<OrderStatusModel>>(uri,true);
			return result;
		}
        public List<ChangeOrderStatusModel> GetNextOrderStatusList(Int64 Id)
        {
            string uri = "api/OrderStatus/GetNextOrderStatusList/" + Id.ToString() + "";

            var result = WebApiClient.Get<List<ChangeOrderStatusModel>>(uri,true);
            return result;
        }
        
        public List<OrderStatusModel> GetRootOrderStatus()
        {
            string uri = "api/OrderStatus/GetRootOrderStatus/";

            var result = WebApiClient.Get<List<OrderStatusModel>>(uri, true);
            return result;
        }

        public OrderStatusModel GetById(Int64 Id)
		{
			string uri = "api/OrderStatus/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<OrderStatusModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(OrderStatusModel model)
		{
			string uri = "api/OrderStatus/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(OrderStatusModel model)
		{
			string uri = "api/OrderStatus/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(OrderStatusModel model)
		{
			string uri = "api/OrderStatus/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/OrderStatus/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
