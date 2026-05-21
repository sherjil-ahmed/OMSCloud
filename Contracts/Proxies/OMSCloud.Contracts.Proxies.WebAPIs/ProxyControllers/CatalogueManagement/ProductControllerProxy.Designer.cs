using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class ProductControllerProxy : BaseControllerProxy//, IProductController
    {
        public List<ProductModel> GetList()
        {
            string uri = "api/Product/GetList";

            var result = WebApiClient.Get<List<ProductModel>>(uri);
            return result;

        }
        public ProductModel GetById(Int64 Id)
        {
            string uri = "api/Product/GetById/" + Id.ToString() + "";

            var result = WebApiClient.Get<ProductModel>(uri);
            return result;
        }
        public ProductModel GetProductByTitle(string productName , string shopName)
        {            
            string uri = "api/Product/" + productName + "/Shop/" + shopName + "";

            var result = WebApiClient.Get<ProductModel>(uri);
            return result;
        }
        public CartItemProductModel GetCartItemProduct(long productId)
        {
            string uri = "api/Product/GetCartItemProduct/" + productId.ToString() + "";
            var result = WebApiClient.Get<CartItemProductModel>(uri);
            return result;
        }
        public List<AllParentsByChildCategoryModel> GetParentCategoryListByChildCategoryId(long Id)
        {
            string uri = "api/Product/GetParentCategoryListByChildCategoryId/" + Id.ToString() + "";
            var result = WebApiClient.Get<List<AllParentsByChildCategoryModel>>(uri, true);
            return result;
        }

        public List<ProductModel> GetProductListByType(long? ProductTypeId = null, string ProductTypePartialName = null)
        {
            string uri = "api/Product/GetProductListByType/" + ProductTypeId.ToString() + "/" + ProductTypePartialName.ToString() + "";

            var result = WebApiClient.Get<List<ProductModel>>(uri);
            return result;
        }
        public List<ProductModel> GetDeliveryProductList()
        {
            string uri = "api/Product/GetDeliveryProductList";

            var result = WebApiClient.Get<List<ProductModel>>(uri);
            return result;
        }
        public List<ProductModel> GetTaxProductList()
        {
            string uri = "api/Product/GetTaxProductList";

            var result = WebApiClient.Get<List<ProductModel>>(uri);
            return result;
        }
        public ProductSearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder = "", int? shopId = null)
        {
            string uri = "api/Product/GetListByPage?PageNum=" + PageNum + "&PageSize_RowCount=" + PageSize_RowCount + "&searchString=" + searchString + "&sortOrder=" + sortOrder + "&shopId=" + shopId ;

            var result = WebApiClient.Get<ProductSearchResultAdminModel>(uri);
            return result;
        }

        public Nullable<Int64> Put(ProductModel model)
        {
            string uri = "api/Product/Put";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;

        }
        public Boolean Post(ProductModel model)
        {
            string uri = "api/Product/Post";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;

        }

        public bool ApproveProductList(string ProductCSV)
        {
            string uri = "api/Product/ApproveProductList?ProductCSV=" + ProductCSV + "";

            var result = WebApiClient.Post<Boolean>(uri, ProductCSV);
            return result;
        }
        public Boolean Delete(ProductModel model)
        {
            string uri = "api/Product/Delete";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public Boolean Delete(Int64 Id)
        {
            string uri = "api/Product/Delete/" + Id.ToString() + "";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public List<ProductSearchResultModel> ProductSearchByPage(ProductSearchModel model)
        {
            string uri = "api/Product/ProductSearchByPage";

            var result = WebApiClient.Post<List<ProductSearchResultModel>>(uri, model);
            return result;

        }
        public List<ProductLookupModel> GetLookupList()
        {
            string uri = "api/Product/GetLookupList";

            var result = WebApiClient.Get<List<ProductLookupModel>>(uri);
            return result;

        }
        public List<ProductDetailModel> GetProductDetail(Int64 Id)
        {
            string uri = "api/Product/GetProductDetail/" + Id.ToString() + "";

            var result = WebApiClient.Get<List<ProductDetailModel>>(uri);
            return result;

        }
        public Nullable<Int64> AddProductCategoryPair(ProductCategoryPairModel model)
        {
            string uri = "api/Product/AddProductCategoryPair";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;

        }
        public List<AllNonExistingParentsByChildCategoryModel> GetAllNonExistingCategoryList(ProductCategoryPairModel model)
        {
            string uri = "api/Product/GetAllNonExistingCategoryList/" + model.CategoryID.ToString() + "/" + model.ProductID.ToString();
            var result = WebApiClient.Get<List<AllNonExistingParentsByChildCategoryModel>>(uri);
            return result;
        }
        public List<ProductCategoryPairModel> ShowCategoryListByProductId(Int64 Id)
        {
            string uri = "api/Product/ShowCategoryListByProductId/" + Id.ToString() + "";

            var result = WebApiClient.Get<List<ProductCategoryPairModel>>(uri);
            return result;

        }
    }
}
