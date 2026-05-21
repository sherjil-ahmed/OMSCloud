using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class ProductViewItemControllerProxy : BaseControllerProxy//, IProductViewItemController
	{
		public List<ProductViewItemModel> GetList()
		{
			string uri = "api/ProductViewItem/GetList";

			var result =  WebApiClient.Get<List<ProductViewItemModel>>(uri);
			return result;

		}
		public ProductViewItemModel GetById(Int64 Id)
		{
			string uri = "api/ProductViewItem/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ProductViewItemModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(ProductViewItemModel model)
		{
			string uri = "api/ProductViewItem/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(ProductViewItemModel model)
		{
			string uri = "api/ProductViewItem/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(ProductViewItemModel model)
		{
			string uri = "api/ProductViewItem/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/ProductViewItem/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
