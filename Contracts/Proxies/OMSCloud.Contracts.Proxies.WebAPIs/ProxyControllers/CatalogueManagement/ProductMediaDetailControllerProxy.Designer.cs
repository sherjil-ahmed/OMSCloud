using System;
using System.Collections.Generic;
using System.Web;
using OMSCloud.Contracts.Common ;
using OMSCloud.Contracts.Interfaces.IServices ;
using OMSCloud.Contracts.ViewModels ;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
	public partial class ProductMediaDetailControllerProxy : BaseControllerProxy//, IProductMediaDetailController
	{
		public List<ProductMediaDetailModel> GetList()
		{
			string uri = "api/ProductMediaDetail/GetList";

			var result =  WebApiClient.Get<List<ProductMediaDetailModel>>(uri);
			return result;

		}
		public ProductMediaDetailModel GetById(Int64 Id)
		{
			string uri = "api/ProductMediaDetail/GetById/" + Id.ToString() + "";

			var result =  WebApiClient.Get<ProductMediaDetailModel>(uri);
			return result;

		}
		public Nullable<Int64> Put(ProductMediaDetailModel model)
		{
			string uri = "api/ProductMediaDetail/Put";

			var result =  WebApiClient.Put<Nullable<Int64>>(uri, model);
			return result;

		}
        public Nullable<Int64> PutImage(ProductImageModel model)
        {
            string uri = "api/ProductMediaDetail/PutImage";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;

        }
        public Boolean PostImageByProductId(long Id, HttpPostedFileBase file, bool isDefault = false)
        {
            string uri = "api/ProductMediaDetail/PutImageByProductId/" + Id.ToString() + "?isDefault=" + isDefault;

            var result = WebApiClient.PostImage<Boolean>(uri, file);
            return result;

        }

        public Boolean Post(ProductMediaDetailModel model)
		{
			string uri = "api/ProductMediaDetail/Post";

			var result =  WebApiClient.Post<Boolean>(uri, model);
			return result;

		}
		public Boolean Delete(ProductMediaDetailModel model)
		{
			string uri = "api/ProductMediaDetail/Delete";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
		public Boolean Delete(Int64 Id)
		{
			string uri = "api/ProductMediaDetail/Delete/" + Id.ToString() + "";

			var result =  WebApiClient.Delete<Boolean>(uri);
			return result;

		}
	}
}
