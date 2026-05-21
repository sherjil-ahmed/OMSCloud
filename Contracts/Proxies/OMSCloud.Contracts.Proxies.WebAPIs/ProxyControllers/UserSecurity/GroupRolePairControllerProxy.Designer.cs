using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class GroupRolePairControllerProxy : BaseControllerProxy//, IGroupRolePairController
	{
		public List<GroupRolePairModel> GetList()
		{
			string uri = "api/GroupRolePair/GetList";

			var result =  WebApiClient.Get<List<GroupRolePairModel>>(uri);
			return result;

		}
		public GroupRolePairModel GetById(Int64 Id)
		{
			string uri = "api/GroupRolePair/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<GroupRolePairModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(GroupRolePairModel model)
		{
			string uri = "api/GroupRolePair/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(GroupRolePairModel model)
		{
			string uri = "api/GroupRolePair/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(GroupRolePairModel model)
		{
			string uri = "api/GroupRolePair/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/GroupRolePair/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
