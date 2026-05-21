using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class LanguageControllerProxy : BaseControllerProxy//, ILanguageController
	{
		public List<LanguageModel> GetList()
		{
			string uri = "api/Language/GetList";

			var result =  WebApiClient.Get<List<LanguageModel>>(uri);
			return result;

		}
		public LanguageModel GetById(Int64 Id)
		{
			string uri = "api/Language/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<LanguageModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(LanguageModel model)
		{
			string uri = "api/Language/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(LanguageModel model)
		{
			string uri = "api/Language/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(LanguageModel model)
		{
			string uri = "api/Language/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Language/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
