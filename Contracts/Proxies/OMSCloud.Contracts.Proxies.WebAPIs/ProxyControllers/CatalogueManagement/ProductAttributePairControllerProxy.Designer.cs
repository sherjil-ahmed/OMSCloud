using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class ProductAttributePairControllerProxy : BaseControllerProxy//, IProductAttributePairController
	{
		public List<ProductAttributePairModel> GetList()
		{
			string uri = "api/ProductAttributePair/GetList";

			var result =  WebApiClient.Get<List<ProductAttributePairModel>>(uri);
			return result;

		}
		public ProductAttributePairModel GetById(Int64 Id)
		{
			string uri = "api/ProductAttributePair/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ProductAttributePairModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(ProductAttributePairModel model)
		{
			string uri = "api/ProductAttributePair/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(ProductAttributePairModel model)
		{
			string uri = "api/ProductAttributePair/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(ProductAttributePairModel model)
		{
			string uri = "api/ProductAttributePair/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/ProductAttributePair/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public List<ProductAttributePairModel> GetProductAttributePairList()
		{
			string uri = "api/ProductAttributePair/GetProductAttributePairList";

			var result =  WebApiClient.Get<List<ProductAttributePairModel>>(uri);
			return result;

		}
		public List<ProductAttributePairModel> GetListByProductID(Int64 Id)
		{
			string uri = "api/ProductAttributePair/GetListByProductID/" + Id.ToString() + "";

			var result =  WebApiClient.Get<List<ProductAttributePairModel>>(uri);
			return result;

		}
	}
}
