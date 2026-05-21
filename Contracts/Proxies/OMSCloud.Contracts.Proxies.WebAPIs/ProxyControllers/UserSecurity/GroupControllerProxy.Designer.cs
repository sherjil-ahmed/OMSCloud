using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class GroupControllerProxy : BaseControllerProxy//, IGroupController
	{
		public List<GroupModel> GetList()
		{
			string uri = "api/Group/GetList";

			var result =  WebApiClient.Get<List<GroupModel>>(uri);
			return result;

		}
		public GroupModel GetById(Int64 Id)
		{
			string uri = "api/Group/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<GroupModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(GroupModel model)
		{
			string uri = "api/Group/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(GroupModel model)
		{
			string uri = "api/Group/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(GroupModel model)
		{
			string uri = "api/Group/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Group/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
