using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class ProductViewControllerProxy : BaseControllerProxy//, IProductViewController
	{
		public List<ProductViewModel> GetList()
		{
			string uri = "api/ProductView/GetList";

			var result =  WebApiClient.Get<List<ProductViewModel>>(uri);
			return result;

		}
		public ProductViewModel GetById(Int64 Id)
		{
			string uri = "api/ProductView/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ProductViewModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(ProductViewModel model)
		{
			string uri = "api/ProductView/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
		public Boolean Post(ProductViewModel model)
		{
			string uri = "api/ProductView/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(ProductViewModel model)
		{
			string uri = "api/ProductView/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/ProductView/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public ProductViewAndItems GetProductViewListByName(String Id)
		{
			string uri = "api/ProductView/GetProductViewListByName/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ProductViewAndItems>(uri);
			return result;

		}
	}
}
