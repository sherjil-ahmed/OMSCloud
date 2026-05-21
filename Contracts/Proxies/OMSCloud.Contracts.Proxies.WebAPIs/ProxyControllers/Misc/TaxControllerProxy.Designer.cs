using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class TaxControllerProxy : BaseControllerProxy//, ITaxController
	{
		public List<TaxModel> GetList()
		{
			string uri = "api/Tax/GetList";

			var result =  WebApiClient.Get<List<TaxModel>>(uri);
			return result;

		}
		public TaxModel GetById(Int64 Id)
		{
			string uri = "api/Tax/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<TaxModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(TaxModel model)
		{
			string uri = "api/Tax/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(TaxModel model)
		{
			string uri = "api/Tax/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(TaxModel model)
		{
			string uri = "api/Tax/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Tax/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
