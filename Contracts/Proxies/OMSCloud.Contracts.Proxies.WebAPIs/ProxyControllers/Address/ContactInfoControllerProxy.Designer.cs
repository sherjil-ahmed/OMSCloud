using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class ContactInfoControllerProxy : BaseControllerProxy//, IContactInfoController
	{
		public List<ContactInfoModel> GetList()
		{
			string uri = "api/ContactInfo/GetList";

			var result =  WebApiClient.Get<List<ContactInfoModel>>(uri);
			return result;

		}
		public ContactInfoModel GetById(Int64 Id)
		{
			string uri = "api/ContactInfo/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ContactInfoModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(ContactInfoModel model)
		{
			string uri = "api/ContactInfo/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(ContactInfoModel model)
		{
			string uri = "api/ContactInfo/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(ContactInfoModel model)
		{
			string uri = "api/ContactInfo/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/ContactInfo/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
