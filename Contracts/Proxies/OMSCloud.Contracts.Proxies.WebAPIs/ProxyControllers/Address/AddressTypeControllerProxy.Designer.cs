using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class AddressTypeControllerProxy : BaseControllerProxy//, IAddressTypeController
	{
		public List<AddressTypeModel> GetList()
		{
			string uri = "api/AddressType/GetList";

			var result =  WebApiClient.Get<List<AddressTypeModel>>(uri,true);
			return result;

		}
		public AddressTypeModel GetById(Int64 Id)
		{
			string uri = "api/AddressType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<AddressTypeModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(AddressTypeModel model)
		{
			string uri = "api/AddressType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(AddressTypeModel model)
		{
			string uri = "api/AddressType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(AddressTypeModel model)
		{
			string uri = "api/AddressType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/AddressType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
