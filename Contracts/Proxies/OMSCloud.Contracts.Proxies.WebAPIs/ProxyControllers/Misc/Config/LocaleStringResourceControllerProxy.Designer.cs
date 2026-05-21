using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class LocaleStringResourceControllerProxy : BaseControllerProxy//, ILocaleStringResourceController
	{
		public List<LocaleStringResourceModel> GetList()
		{
			string uri = "api/LocaleStringResource/GetList";

			var result =  WebApiClient.Get<List<LocaleStringResourceModel>>(uri);
			return result;

		}
		public LocaleStringResourceModel GetById(Int64 Id)
		{
			string uri = "api/LocaleStringResource/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<LocaleStringResourceModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(LocaleStringResourceModel model)
		{
			string uri = "api/LocaleStringResource/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(LocaleStringResourceModel model)
		{
			string uri = "api/LocaleStringResource/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(LocaleStringResourceModel model)
		{
			string uri = "api/LocaleStringResource/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/LocaleStringResource/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
