using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Business.Adapters;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Business.Core
{
    public partial class ProductBusinessComponent
    {
        public ProductSearchResultModel ProductSearchByPage(ProductSearchModel model)
        {
            var search = new ProductSearchAdapter();
            return search.ProductSearchByPage(model);
        }
        public ProductDetailModel GetProductDetail(long productId, long profileId, bool isShop)
        {
            var product = adapter.GetProductDetail(productId, profileId, isShop);
            CartBusinessComponent.UpdateExpectedDeliveryInfo(product);
            return product;
        }
        public ProductDetailModel GetProductByTitle(string productName, string shopName)
        {
            var product = adapter.GetProductByTitle(productName, shopName);
            CartBusinessComponent.UpdateExpectedDeliveryInfo(product);
            return product;

        }

        public List<AllNonExistingParentsByChildCategoryModel> GetAllNonExistingCategoryList(long CategoryId, long ProductId) 
        {
            return adapter.GetAllNonExistingCategoryList(CategoryId, ProductId);
        }
        public List<AllParentsByChildCategoryModel> GetParentCategoryListByChildCategoryId(long Id) 
        {
            return adapter.GetParentCategoryListByChildCategoryId(Id);
        }
        public List<ProductLookupModel> GetLookupList()
        {
            return adapter.GetLookupList();
        }
        public List<ProductLookupModel> GetLookupByShopId(long Id)
        {
            return adapter.GetLookupByShopId(Id);
        }
        public CartItemProductModel GetCartItemProduct(long productId)
        {
            return adapter.GetCartItemProduct(productId);
        }
        public List<ProductCategoryPairModel> ShowCategoryListByProductId(long Id)
        {
            return adapter.ShowCategoryListByProductId(Id);
        }
        public List<ProductModel> GetProductListByType(long? ProductTypeId = null, string ProductTypePartialName = null)
        {
            return adapter.GetProductListByType(ProductTypeId, ProductTypePartialName);
        }
        public List<ProductBoxModel> GetPopularProductList()
        {
            return adapter.GetPopularProductList();
        }
        
        public List<ProductModel> GetDeliveryProductList()
        {
            return adapter.GetProductListByType(null, "Delivery");
        }
        public List<ProductModel> GetTaxProductList()
        {
            return adapter.GetProductListByType(null, "Tax");
        }
        public long? AddProduct(ProductModel product)
        {
            return adapter.AddProduct(product);
        }
        public long? AddProductBasicInfo(ProductBasicInfoModel product)
        {
            return adapter.AddProductBasicInfo(product);
        }
        public long? AddProductCategoryPair(ProductCategoryPairModel model)
        {
            return adapter.AddProductCategoryPair(model);
        }
        public bool UpdateProduct(ProductModel product)
        {
            return adapter.UpdateProduct(product);
        }
        public bool UpdateProductBasicInfo(ProductBasicInfoModel product)
        {
            return adapter.UpdateProductBasicInfo(product);
        }
        public bool UpdateProductPricing(ProductPricingModel product)
        {
            product.BasePrice = 0;
            return adapter.UpdateProductPricing(product);
        }
        public bool UpdateProductImages(ProductImagesModel product)
        {
            return adapter.UpdateProductImages(product);
        }
        public ProductSearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder = "", int? shopId = null)
        {
            var search = new ProductSearchAdapter();
            return search.GetListByPage(PageNum, PageSize_RowCount, searchString, sortOrder, shopId);
        }
        public bool UpdateForAnalysisRank()
        {
            return adapter.UpdateForAnalysisRank();
        }
        public bool ApproveProductList(List<long> ProductList)
        {
            return adapter.ApproveProductList(ProductList);
        }
        public bool UpdateProductStatus(long ProductId, DBStatusEnum status)
        {
            return adapter.UpdateProductStatus(ProductId, status);
        }
    }
}
