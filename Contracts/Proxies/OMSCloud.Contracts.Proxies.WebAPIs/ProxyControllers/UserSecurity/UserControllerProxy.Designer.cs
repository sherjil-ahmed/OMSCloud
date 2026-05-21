using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class UserControllerProxy : BaseControllerProxy//, IUserController
	{
		public List<UserModel> GetList()
		{
			string uri = "api/User/GetList";

			var result =  WebApiClient.Get<List<UserModel>>(uri);
			return result;

		}
		public UserModel GetById(Int64 Id)
		{
			string uri = "api/User/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<UserModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(UserModel model)
		{
			string uri = "api/User/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(UserModel model)
		{
			string uri = "api/User/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(UserModel model)
		{
			string uri = "api/User/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/User/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public UserModel LoginUser(LoginModel model)
		{
			string uri = "api/User/LoginUser";

			var result =  WebApiClient.Post<UserModel>(uri, model);
			return result;

		}
		public Boolean ChangePassword(ChangePasswordModel model)
		{
			string uri = "api/User/ChangePassword";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
	}
}
