using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class AddressContactInfoPairControllerProxy : BaseControllerProxy//, IAddressContactInfoPairController
	{
		public List<AddressContactInfoPairModel> GetList()
		{
			string uri = "api/AddressContactInfoPair/GetList";

			var result =  WebApiClient.Get<List<AddressContactInfoPairModel>>(uri);
			return result;

		}
		public AddressContactInfoPairModel GetById(Int64 Id)
		{
			string uri = "api/AddressContactInfoPair/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<AddressContactInfoPairModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(AddressContactInfoPairModel model)
		{
			string uri = "api/AddressContactInfoPair/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(AddressContactInfoPairModel model)
		{
			string uri = "api/AddressContactInfoPair/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(AddressContactInfoPairModel model)
		{
			string uri = "api/AddressContactInfoPair/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/AddressContactInfoPair/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
