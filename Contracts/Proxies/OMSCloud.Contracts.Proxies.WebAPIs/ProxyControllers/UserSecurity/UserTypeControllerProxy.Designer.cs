using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class UserTypeControllerProxy : BaseControllerProxy//, IUserTypeController
	{
		public List<UserTypeModel> GetList()
		{
			string uri = "api/UserType/GetList";

			var result =  WebApiClient.Get<List<UserTypeModel>>(uri, true);
			return result;

		}
		public UserTypeModel GetById(Int64 Id)
		{
			string uri = "api/UserType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<UserTypeModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(UserTypeModel model)
		{
			string uri = "api/UserType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(UserTypeModel model)
		{
			string uri = "api/UserType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(UserTypeModel model)
		{
			string uri = "api/UserType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/UserType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
