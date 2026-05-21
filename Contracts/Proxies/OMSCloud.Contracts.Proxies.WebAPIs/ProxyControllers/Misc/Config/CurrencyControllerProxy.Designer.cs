using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class CurrencyControllerProxy : BaseControllerProxy//, ICurrencyController
	{
		public List<CurrencyModel> GetList()
		{
			string uri = "api/Currency/GetList";

			var result =  WebApiClient.Get<List<CurrencyModel>>(uri);
			return result;

		}
		public CurrencyModel GetById(Int64 Id)
		{
			string uri = "api/Currency/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<CurrencyModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(CurrencyModel model)
		{
			string uri = "api/Currency/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(CurrencyModel model)
		{
			string uri = "api/Currency/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(CurrencyModel model)
		{
			string uri = "api/Currency/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Currency/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
