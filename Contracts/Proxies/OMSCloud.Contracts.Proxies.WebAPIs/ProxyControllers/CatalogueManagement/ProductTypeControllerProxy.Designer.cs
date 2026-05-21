using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class ProductTypeControllerProxy : BaseControllerProxy//, IProductTypeController
	{
		public List<ProductTypeModel> GetList()
		{
			string uri = "api/ProductType/GetList";

			var result =  WebApiClient.Get<List<ProductTypeModel>>(uri, true);
			return result;

		}
		public ProductTypeModel GetById(Int64 Id)
		{
			string uri = "api/ProductType/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ProductTypeModel>(uri, true);
			return result;

		}
		public Nullable<Int64> Put(ProductTypeModel model)
		{
			string uri = "api/ProductType/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(ProductTypeModel model)
		{
			string uri = "api/ProductType/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(ProductTypeModel model)
		{
			string uri = "api/ProductType/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/ProductType/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
