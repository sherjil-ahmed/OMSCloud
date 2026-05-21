using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class StatusControllerProxy : BaseControllerProxy//, IStatusController
	{
		public List<StatusModel> GetList()
		{
			string uri = "api/Status/GetList";

			var result =  WebApiClient.Get<List<StatusModel>>(uri,true);
			return result;

		}
		public StatusModel GetById(Int64 Id)
		{
			string uri = "api/Status/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<StatusModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(StatusModel model)
		{
			string uri = "api/Status/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(StatusModel model)
		{
			string uri = "api/Status/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(StatusModel model)
		{
			string uri = "api/Status/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Status/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
