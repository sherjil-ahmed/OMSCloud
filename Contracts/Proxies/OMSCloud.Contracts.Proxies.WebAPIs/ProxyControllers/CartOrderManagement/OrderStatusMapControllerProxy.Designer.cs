using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class OrderStatusMapControllerProxy : BaseControllerProxy//, IOrderStatusMapController
	{
		public List<OrderStatusMapModel> GetList()
		{
			string uri = "api/OrderStatusMap/GetList";

			var result =  WebApiClient.Get<List<OrderStatusMapModel>>(uri,true);
			return result;

		}

        public List<OrderStatusMapModel> GetSortedList()
        {
            string uri = "api/OrderStatusMap/GetSortedList";

            var result = WebApiClient.Get<List<OrderStatusMapModel>>(uri,true);
            return result;

        }

        public OrderStatusMapModel GetOrderStatusMapById(Int64 Id)
        {
            string uri = "api/OrderStatusMap/GetOrderStatusMapById/" + Id.ToString() + "";

            var result = WebApiClient.Get<OrderStatusMapModel>(uri, true);
            return result;

        }

        public OrderStatusMapModel GetById(Int64 Id)
		{
			string uri = "api/OrderStatusMap/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<OrderStatusMapModel>(uri,true);
			return result;

		}
		public Nullable<Int64> Put(OrderStatusMapModel model)
		{
			string uri = "api/OrderStatusMap/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(OrderStatusMapModel model)
		{
			string uri = "api/OrderStatusMap/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(OrderStatusMapModel model)
		{
			string uri = "api/OrderStatusMap/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/OrderStatusMap/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
