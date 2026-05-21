using System;
using System.Collections.Generic;
using System.Web;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class ProfileControllerProxy : BaseControllerProxy//, IProfileController
	{
		public List<ProfileModel> GetList()
		{
			string uri = "api/Profile/GetList";

			var result =  WebApiClient.Get<List<ProfileModel>>(uri, true);
			return result;

		}
        public List<ProfileModel> GetActiveProfileList()
        {
            string uri = "api/Profile/GetActiveProfileList";

            var result = WebApiClient.Get<List<ProfileModel>>(uri, true);
            return result;

        }

        public ProfileModel GetById(Int64 Id)
		{
			string uri = "api/Profile/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ProfileModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(ProfileModel model)
		{
			string uri = "api/Profile/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(ProfileModel model)
		{
			string uri = "api/Profile/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(ProfileModel model)
		{
			string uri = "api/Profile/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Profile/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public ProfileModel GetProfileByUserId(Int64 Id)
		{
			string uri = "api/Profile/GetProfileByUserId/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ProfileModel>(uri, true);
			return result;

		}
        
        public List<ShopUserModel> GetInactiveShopList()
        {
            string uri = "api/Account/GetInactiveShopList/";

            var result = WebApiClient.Get<List<ShopUserModel>>(uri);
            return result;
        }

        public long GetInactiveShopCount()
        {
            string uri = "api/Account/GetInactiveShopCount/";

            var result = WebApiClient.GetForValueType<long>(uri);
            return result;
        }

        public long GetInactiveProfileCount()
        {
            string uri = "api/Account/GetInactiveProfileCount/";

            var result = WebApiClient.GetForValueType<long>(uri);
            return result;
        }

        public long GetNewProfileCount()
        {
            string uri = "api/Account/GetNewProfileCount/";

            var result = WebApiClient.GetForValueType<long>(uri);
            return result;
        }

        public long GetAllProfileCount()
        {
            string uri = "api/Account/GetAllProfileCount/";

            var result = WebApiClient.GetForValueType<long>(uri);
            return result;
        }
        public bool PutImageByProfileId(long Id, HttpPostedFileBase file)
        {
            string uri = "api/Profile/PutImageByProfileId/" + Id.ToString() + "";

            var result = WebApiClient.PostImage<Boolean>(uri, file);
            return result;

        }
    }
}
