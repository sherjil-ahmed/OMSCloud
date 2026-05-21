using System;
using System.Collections.Generic;
using System.Web;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class ProfileVerificationControllerProxy : BaseControllerProxy//, IProfileVerificationController
	{
		public List<ProfileVerificationModel> GetList()
		{
			string uri = "api/ProfileVerification/GetList";

			var result =  WebApiClient.Get<List<ProfileVerificationModel>>(uri);
			return result;

		}
		public ProfileVerificationModel GetById(Int64 Id)
		{
			string uri = "api/ProfileVerification/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ProfileVerificationModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(ProfileVerificationModel model)
		{
			string uri = "api/ProfileVerification/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(ProfileVerificationModel model)
		{
			string uri = "api/ProfileVerification/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(ProfileVerificationModel model)
		{
			string uri = "api/ProfileVerification/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/ProfileVerification/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public List<ProfileVerificationModelForAdmin> GetListForAdmin()
		{
			string uri = "api/ProfileVerification/GetListForAdmin";

			var result =  WebApiClient.Get<List<ProfileVerificationModelForAdmin>>(uri);
			return result;

		}
		public List<ProfileVerificationModelForAdmin> GetListForAdminByProfileId(Int64 Id)
		{
			string uri = "api/ProfileVerification/GetListForAdminByProfileId/" + Id.ToString() + "";

			var result =  WebApiClient.Get<List<ProfileVerificationModelForAdmin>>(uri);
			return result;

		}
		public List<ProfileVerificationModelForUser> GetListForPublic(Int64 Id)
		{
			string uri = "api/ProfileVerification/GetListForPublic/" + Id.ToString() + "";

			var result =  WebApiClient.Get<List<ProfileVerificationModelForUser>>(uri);
			return result;

		}
		public ProfileVerificationModelForAdmin GetByIdForAdmin(Int64 Id)
		{
			string uri = "api/ProfileVerification/GetByIdForAdmin/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ProfileVerificationModelForAdmin>(uri);
			return result;

		}
		public Boolean PostForAdmin(ProfileVerificationModelForAdmin model)
		{
			string uri = "api/ProfileVerification/PostForAdmin";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean PostForUser(ProfileVerificationModelForUser model)
		{
			string uri = "api/ProfileVerification/PostForUser";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Nullable<Int64> PutForUser(ProfileVerificationModelForUser model)
		{
			string uri = "api/ProfileVerification/PutForUser";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}

        public Boolean PutVerificationDocument(long Id, HttpPostedFileBase file)
        {
            string uri = "api/ProfileVerification/PutVerificationDocument/" + Id.ToString() + "";

            var result = WebApiClient.PostImage<Boolean>(uri, file);
            return result;

        }
    }
}
