using System;
using System.Collections.Generic;
//using System.Web.Http.Results;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class SupplierDeliveryOptionPairControllerProxy : BaseControllerProxy//, ISupplierController
	{
		public List<SupplierDeliveryOptionPairModel> GetList()
		{
			string uri = "api/SupplierDeliveryOptionPair/GetList";

			var result = WebApiClient.Get<List<SupplierDeliveryOptionPairModel>>(uri);
			return result;

		}
		public List<LocationLookup> GetSurroundingCities(long SupplierID) 
		{
			string uri = "api/SupplierDeliveryOptionPair/GetSurroundingCities/" + SupplierID.ToString() + "";
			var result = WebApiClient.Get<List<LocationLookup>>(uri);
			return result;
		}
        public List<SupplierDeliveryOptionPairModel> GetSupplierDeliveryOptionList()
        {
            string uri = "api/SupplierDeliveryOptionPair/GetSupplierDeliveryOptionList/";
            var result = WebApiClient.Get<List<SupplierDeliveryOptionPairModel>>(uri);
            return result;
        }
        public List<SupplierDeliveryOptionPairModel> GetSupplierDeliveryOptionBySupplierId(long Id)
        {
            string uri = "api/SupplierDeliveryOptionPair/GetSupplierDeliveryOptionBySupplierId/" + Id.ToString() + "";
            var result = WebApiClient.Get<List<SupplierDeliveryOptionPairModel>>(uri);
            return result;
        }
        public SupplierDeliveryOptionPairModel GetSupplierDeliveryOptionById(long Id)
        {
            string uri = "api/SupplierDeliveryOptionPair/GetSupplierDeliveryOptionById/" + Id.ToString() + "";
            var result = WebApiClient.Get<SupplierDeliveryOptionPairModel>(uri);
            return result;
        }
        
        public SupplierDeliveryOptionPairModel GetById(Int64 Id)
		{
			string uri = "api/SupplierDeliveryOptionPair/GetById/" + Id.ToString() + "";

			var result = WebApiClient.Get<SupplierDeliveryOptionPairModel>(uri);
			return result;

		}
	
		public Nullable<Int64> Put(SupplierDeliveryOptionPairModel model)
		{
			string uri = "api/SupplierDeliveryOptionPair/Put";

			var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(SupplierDeliveryOptionPairModel model)
		{
			string uri = "api/SupplierDeliveryOptionPair/Post";

			var result = WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(SupplierDeliveryOptionPairModel model)
		{
			string uri = "api/SupplierDeliveryOptionPair/Delete";

			var result = WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/SupplierDeliveryOptionPair/Delete/" + Id.ToString() + "";

			var result = WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
