using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class LocationLevelControllerProxy : BaseControllerProxy//, ILocationLevelController
	{
		public List<LocationLevelModel> GetList()
		{
			string uri = "api/LocationLevel/GetList";

			var result =  WebApiClient.Get<List<LocationLevelModel>>(uri,true);
			return result;

		}
		public LocationLevelModel GetById(Int64 Id)
		{
			string uri = "api/LocationLevel/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<LocationLevelModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(LocationLevelModel model)
		{
			string uri = "api/LocationLevel/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(LocationLevelModel model)
		{
			string uri = "api/LocationLevel/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(LocationLevelModel model)
		{
			string uri = "api/LocationLevel/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/LocationLevel/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
