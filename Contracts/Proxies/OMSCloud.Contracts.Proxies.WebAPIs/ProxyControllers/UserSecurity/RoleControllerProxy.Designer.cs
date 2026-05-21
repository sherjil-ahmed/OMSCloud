using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class RoleControllerProxy : BaseControllerProxy//, IRoleController
	{
		public List<RoleModel> GetList()
		{
			string uri = "api/Role/GetList";

			var result =  WebApiClient.Get<List<RoleModel>>(uri);
			return result;

		}
		public RoleModel GetById(Int64 Id)
		{
			string uri = "api/Role/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<RoleModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(RoleModel model)
		{
			string uri = "api/Role/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(RoleModel model)
		{
			string uri = "api/Role/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(RoleModel model)
		{
			string uri = "api/Role/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Role/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
