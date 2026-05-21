using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class SearchTermControllerProxy : BaseControllerProxy//, ISearchTermController
	{
		public List<SearchTermModel> GetList()
		{
			string uri = "api/SearchTerm/GetList";

			var result =  WebApiClient.Get<List<SearchTermModel>>(uri);
			return result;

		}
		public SearchTermModel GetById(Int64 Id)
		{
			string uri = "api/SearchTerm/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<SearchTermModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(SearchTermModel model)
		{
			string uri = "api/SearchTerm/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(SearchTermModel model)
		{
			string uri = "api/SearchTerm/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(SearchTermModel model)
		{
			string uri = "api/SearchTerm/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/SearchTerm/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
