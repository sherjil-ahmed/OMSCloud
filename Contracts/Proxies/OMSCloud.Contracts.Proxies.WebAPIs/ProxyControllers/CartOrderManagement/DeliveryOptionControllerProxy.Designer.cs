using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class DeliveryOptionControllerProxy : BaseControllerProxy//, IDeliveryOptionController
	{
		public List<DeliveryOptionModel> GetList()
		{
			string uri = "api/DeliveryOption/GetList";

			var result =  WebApiClient.Get<List<DeliveryOptionModel>>(uri, true);
			return result;

		}
		public DeliveryOptionModel GetById(Int64 Id)
		{
			string uri = "api/DeliveryOption/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<DeliveryOptionModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(DeliveryOptionModel model)
		{
			string uri = "api/DeliveryOption/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(DeliveryOptionModel model)
		{
			string uri = "api/DeliveryOption/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(DeliveryOptionModel model)
		{
			string uri = "api/DeliveryOption/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/DeliveryOption/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
