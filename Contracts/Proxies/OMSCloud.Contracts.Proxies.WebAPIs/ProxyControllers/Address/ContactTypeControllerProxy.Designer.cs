using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class ContactTypeControllerProxy : BaseControllerProxy//, IContactTypeController
	{
		public List<ContactTypeModel> GetList()
		{
			string uri = "api/ContactType/GetList";

			var result =  WebApiClient.Get<List<ContactTypeModel>>(uri);
			return result;

		}
		public ContactTypeModel GetById(Int64 Id)
		{
			string uri = "api/ContactType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ContactTypeModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(ContactTypeModel model)
		{
			string uri = "api/ContactType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(ContactTypeModel model)
		{
			string uri = "api/ContactType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(ContactTypeModel model)
		{
			string uri = "api/ContactType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/ContactType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
