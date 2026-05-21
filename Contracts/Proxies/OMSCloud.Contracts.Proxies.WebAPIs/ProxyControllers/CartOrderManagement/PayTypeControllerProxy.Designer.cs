using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class PayTypeControllerProxy : BaseControllerProxy//, IPayTypeController
	{
		public List<PayTypeModel> GetList()
		{
			string uri = "api/PayType/GetList";

			var result =  WebApiClient.Get<List<PayTypeModel>>(uri);
			return result;

		}
		public PayTypeModel GetById(Int64 Id)
		{
			string uri = "api/PayType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<PayTypeModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(PayTypeModel model)
		{
			string uri = "api/PayType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(PayTypeModel model)
		{
			string uri = "api/PayType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(PayTypeModel model)
		{
			string uri = "api/PayType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/PayType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
