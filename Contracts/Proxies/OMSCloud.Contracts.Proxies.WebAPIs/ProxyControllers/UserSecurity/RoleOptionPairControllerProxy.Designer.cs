using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class RoleOptionPairControllerProxy : BaseControllerProxy//, IRoleOptionPairController
	{
		public List<RoleOptionPairModel> GetList()
		{
			string uri = "api/RoleOptionPair/GetList";

			var result =  WebApiClient.Get<List<RoleOptionPairModel>>(uri);
			return result;

		}
		public RoleOptionPairModel GetById(Int64 Id)
		{
			string uri = "api/RoleOptionPair/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<RoleOptionPairModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(RoleOptionPairModel model)
		{
			string uri = "api/RoleOptionPair/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(RoleOptionPairModel model)
		{
			string uri = "api/RoleOptionPair/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(RoleOptionPairModel model)
		{
			string uri = "api/RoleOptionPair/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/RoleOptionPair/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
        public List<RoleOptionPairModel> GetByRoleId(Int64 RoleId)
        {
            string uri = "api/RoleOptionPair/GetByRoleID?RoleId=" + RoleId.ToString() + "";

            var result = WebApiClient.Get<List<RoleOptionPairModel>>(uri);
            return result;

        }
        public List<RoleOptionPairModel> GetByRoleIds(List<Int64> RoleIds)
        {
            string uri = "api/RoleOptionPair/GetByRoleIDs";

            var result = WebApiClient.Post<List<RoleOptionPairModel>>(uri, RoleIds);
            return result;

        }
    }
}
