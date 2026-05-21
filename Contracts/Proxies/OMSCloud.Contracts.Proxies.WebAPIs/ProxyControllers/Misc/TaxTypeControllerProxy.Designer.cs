using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class TaxTypeControllerProxy : BaseControllerProxy//, ITaxTypeController
	{
		public List<TaxTypeModel> GetList()
		{
			string uri = "api/TaxType/GetList";

			var result =  WebApiClient.Get<List<TaxTypeModel>>(uri,true);
			return result;

		}
		public TaxTypeModel GetById(Int64 Id)
		{
			string uri = "api/TaxType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<TaxTypeModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(TaxTypeModel model)
		{
			string uri = "api/TaxType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(TaxTypeModel model)
		{
			string uri = "api/TaxType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(TaxTypeModel model)
		{
			string uri = "api/TaxType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/TaxType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
