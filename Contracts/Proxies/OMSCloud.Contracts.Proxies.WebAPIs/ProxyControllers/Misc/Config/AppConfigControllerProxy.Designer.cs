using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class AppConfigControllerProxy : BaseControllerProxy//, IAppConfigController
	{
		public List<AppConfigModel> GetList()
		{
			string uri = "api/AppConfig/GetList";

			var result =  WebApiClient.Get<List<AppConfigModel>>(uri, true);
			return result;

		}
		public AppConfigModel GetById(Int64 Id)
		{
			string uri = "api/AppConfig/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<AppConfigModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(AppConfigModel model)
		{
			string uri = "api/AppConfig/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(AppConfigModel model)
		{
			string uri = "api/AppConfig/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(AppConfigModel model)
		{
			string uri = "api/AppConfig/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/AppConfig/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
