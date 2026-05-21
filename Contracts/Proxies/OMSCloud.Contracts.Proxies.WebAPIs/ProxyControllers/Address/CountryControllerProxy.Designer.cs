using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class CountryControllerProxy : BaseControllerProxy//, ICountryController
	{
		public List<CountryModel> GetList()
		{
			string uri = "api/Country/GetList";

			var result =  WebApiClient.Get<List<CountryModel>>(uri);
			return result;

		}
		public CountryModel GetById(Int64 Id)
		{
			string uri = "api/Country/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<CountryModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(CountryModel model)
		{
			string uri = "api/Country/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(CountryModel model)
		{
			string uri = "api/Country/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(CountryModel model)
		{
			string uri = "api/Country/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Country/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
