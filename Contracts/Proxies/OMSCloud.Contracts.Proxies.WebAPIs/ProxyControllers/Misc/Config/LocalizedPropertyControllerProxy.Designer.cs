using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class LocalizedPropertyControllerProxy : BaseControllerProxy//, ILocalizedPropertyController
	{
		public List<LocalizedPropertyModel> GetList()
		{
			string uri = "api/LocalizedProperty/GetList";

			var result =  WebApiClient.Get<List<LocalizedPropertyModel>>(uri);
			return result;

		}
		public LocalizedPropertyModel GetById(Int64 Id)
		{
			string uri = "api/LocalizedProperty/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<LocalizedPropertyModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(LocalizedPropertyModel model)
		{
			string uri = "api/LocalizedProperty/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(LocalizedPropertyModel model)
		{
			string uri = "api/LocalizedProperty/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(LocalizedPropertyModel model)
		{
			string uri = "api/LocalizedProperty/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/LocalizedProperty/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
