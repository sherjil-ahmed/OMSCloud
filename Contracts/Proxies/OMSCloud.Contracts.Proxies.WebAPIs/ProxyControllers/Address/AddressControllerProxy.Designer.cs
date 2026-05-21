using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class AddressControllerProxy : BaseControllerProxy//, IAddressController
	{
        public List<AddressModel> GetDeliveryAddressByCartId(long CartId) // 
        {
            string uri = "api/Address/GetDeliveryAddressByCartId/" + CartId.ToString() + "";
            var result = WebApiClient.Get<List<AddressModel>>(uri);
            return result;
        }
        public List<UsedAddress> GetNonEditableAddressList() 
		{
            string uri = "api/Address/GetNonEditableAddressList";
			var result = WebApiClient.Get<List<UsedAddress>>(uri);
			return result;
		}
		public List<AddressViewModel> GetAddressList() 
		{
			string uri = "api/Address/GetAddressList";
			return WebApiClient.Get<List<AddressViewModel>>(uri);
		}
		public List<AddressModel> GetList()
		{
			string uri = "api/Address/GetList";

			var result =  WebApiClient.Get<List<AddressModel>>(uri);
			return result;

		}
		public AddressModel GetById(Int64 Id)
		{
			string uri = "api/Address/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<AddressModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(AddressModel model)
		{
			string uri = "api/Address/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(AddressModel model)
		{
			string uri = "api/Address/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(AddressModel model)
		{
			string uri = "api/Address/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/Address/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
