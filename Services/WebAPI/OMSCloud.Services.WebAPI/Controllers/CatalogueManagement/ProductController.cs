using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Services.WebAPIs.Hubs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class ProductController : ApiController, IProductController
    {
        #region GET
        [ReturnType(DataType = typeof(List<ProductLookupModel>))]
        public IHttpActionResult GetLookupList()
        {
            return Ok<List<ProductLookupModel>>(comp.GetLookupList());
        }
        [ReturnType(DataType = typeof(List<ProductLookupModel>))]
        public IHttpActionResult GetLookupByShopId(long Id)
        {
            return Ok<List<ProductLookupModel>>(comp.GetLookupByShopId(Id));
        }
        [ReturnType(DataType = typeof(CartItemProductModel))]
        public IHttpActionResult GetCartItemProduct(long Id)
        {
            return Ok<CartItemProductModel>(comp.GetCartItemProduct(Id));
        }
        [ReturnType(DataType = typeof(ProductDetailModel))]
        public IHttpActionResult GetProductDetail(long Id, long Id1 = -1)
        {
            return Ok<ProductDetailModel>(comp.GetProductDetail(Id, Id1, false));
        }
        [ReturnType(DataType = typeof(ProductDetailModel))]
        [Route("api/Product/{productName}/Shop/{shopName}")]
        public IHttpActionResult GetProductByTitle(string productName, string shopName)
        { 
            return Ok<ProductDetailModel>(comp.GetProductByTitle(productName, shopName));
        }
        [ReturnType(DataType = typeof(ProductDetailModel))]
        public IHttpActionResult GetProductDetailFromShop(long Id)
        {
            return Ok<ProductDetailModel>(comp.GetProductDetail(Id, -1, true));
        }
        [ReturnType(DataType = typeof(List<AllNonExistingParentsByChildCategoryModel>))]
        public IHttpActionResult GetAllNonExistingCategoryList(long id, long id1)
        {
            long CategoryId = id;
            long ProductId = id1;
            return Ok<List<AllNonExistingParentsByChildCategoryModel>>(comp.GetAllNonExistingCategoryList(CategoryId, ProductId));
        }
        [ReturnType(DataType = typeof(List<AllParentsByChildCategoryModel>))]
        public IHttpActionResult GetParentCategoryListByChildCategoryId(long Id) 
        {
            return Ok<List<AllParentsByChildCategoryModel>>(comp.GetParentCategoryListByChildCategoryId(Id));
        }
        [HttpGet]
        [ReturnType(DataType = typeof(List<ProductCategoryPairModel>))]
        public IHttpActionResult ShowCategoryListByProductId(long Id)
        {
            return Ok<List<ProductCategoryPairModel>>(comp.ShowCategoryListByProductId(Id));
        }
        [HttpGet]
        [ReturnType(DataType = typeof(List<ProductModel>))]
        public IHttpActionResult GetProductListByType(long? ProductTypeId = null, string ProductTypePartialName = null)
        {
            return Ok<List<ProductModel>>(comp.GetProductListByType(ProductTypeId, ProductTypePartialName));
        }
        [HttpGet]
        [ReturnType(DataType = typeof(List<ProductBoxModel>))]
        public IHttpActionResult GetPopularProductList()
        {
            return Ok<List<ProductBoxModel>>(comp.GetPopularProductList());
        }
        [HttpGet]
        [ReturnType(DataType = typeof(List<ProductModel>))]
        public IHttpActionResult GetDeliveryProductList()
        {
            return Ok<List<ProductModel>>(comp.GetDeliveryProductList());
        }
        [HttpGet]
        [ReturnType(DataType = typeof(List<ProductModel>))]
        public IHttpActionResult GetTaxProductList()
        {
            return Ok<List<ProductModel>>(comp.GetTaxProductList());
        }
        #endregion GET

        #region Put
        [HttpPut]
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult AddProductCategoryPair(ProductCategoryPairModel model)
        {
            return Ok<long?>(comp.AddProductCategoryPair(model));
        }

        [HttpPut]
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult AddProductBasicInfo(ProductBasicInfoModel model)
        {
            var Id = comp.AddProductBasicInfo(model);
            if (Id.HasValue)
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Product, Id.Value);
                return Ok<long?>(Id.Value);
            }
            return Conflict();
        }
        #endregion PUT

        #region POST
        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult UpdatePricing(ProductPricingModel model)
        {
            if (comp.UpdateProductPricing(model))
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Product, model.ProductID);
                return Ok<bool>(true);
            }
            return Conflict();
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult UpdateBasicInfo(ProductBasicInfoModel model)
        {
            if (comp.UpdateProductBasicInfo(model))
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Product, model.ProductID);
                return Ok<bool>(true);
            }
            return Conflict();
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult UpdateImages(ProductImagesModel model)
        {
            if (comp.UpdateProductImages(model))
            {
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Product, model.ProductID);
                return Ok<bool>(true);
            }
            return Conflict();
        }

        //public bool ApproveProductList()
        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult ApproveProductList(string ProductCSV)
        {
            if (string.IsNullOrEmpty(ProductCSV))
                return BadRequest("Empty list of product Ids. Nothing to process.");
            var ListString = ProductCSV.Split(',');
            List<long> ProductListLong = new List<long>();
            foreach (var id in ListString)
            {
                long x = 0;
                Int64.TryParse(id, out x);
                ProductListLong.Add(x);
            }
            if (comp.ApproveProductList(ProductListLong))
            {
                foreach (var id in ProductListLong)
                {
                    SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Product, id);
                }
                return Ok<bool>(true);
            }
            return Conflict();
        }

        #endregion POST

        #region Searching

        //public bool UpdateProductImages(ProductImagesModel product)
        [HttpPost]
        [ReturnType(DataType = typeof(ProductSearchResultModel))]
        public IHttpActionResult ProductSearchByPage(ProductSearchModel model)
        {
            return Ok<ProductSearchResultModel>(comp.ProductSearchByPage(model));
        }
        [HttpGet]
        [ReturnType(DataType = typeof(ProductSearchResultAdminModel))]
        public IHttpActionResult GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder = "", int? shopId = null)
        {
            return Ok<ProductSearchResultAdminModel>(comp.GetListByPage(PageNum, PageSize_RowCount, searchString, sortOrder, shopId ));
        }
        #endregion Searching

    }
}
