using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.Repositories;
using OMSCloud.DataStore.EF.UnitofWork;
using static OMSCloud.Contracts.Common.DBEnums.SortByEnum;
using OMSCloud.Contracts.Common;

namespace OMSCloud.Business.Adapters
{
    public partial class ProductAdapter
    {
        #region Select

        public ProductDetailModel GetProductByTitle(string product, string supplier)
        {
            var productId = (from p in uow.ProductRepository.OMSContext.Product
                             where p.ProductTitle == product && p.Supplier.SupplierName == supplier
                             select p.ProductID).FirstOrDefault();
            ProductDetailModel productModel = GetProductDetail(productId, -1);
            return productModel;
        }
        public ProductModel GetProductById(long Id)
        {
            var products = uow.ProductRepository.GetById(Id);
            ProductModel productModel = GetProductModel(products);
            return productModel;
        }
        public List<AllNonExistingParentsByChildCategoryModel> GetAllNonExistingCategoryList(long CategoryId, long ProductId)
        {
            var result = uow.OMSContext.sp_Catalogue_AllNonExistingParentsByChildCategory_Attributes((int)CategoryId, (int)ProductId).ToList();
            return (from r in result
                    join cat in uow.OMSContext.Category on r.CategoryID.GetValueOrDefault() equals cat.CategoryID
                    into ps
                    from cat in ps.DefaultIfEmpty()
                    select new AllNonExistingParentsByChildCategoryModel
                    {
                        CategoryID = r.CategoryID,
                        CategoryTitle = cat == null ? "noCategory" : cat.CategoryTitle,
                        ProductID = r.ProductID,
                        AttributeID = r.AttributeID,
                        AttributeValue = r.AttributeValue
                    }).ToList();
        }

        public List<AllParentsByChildCategoryModel> GetParentCategoryListByChildCategoryId(long Id)
        {
            var result = uow.OMSContext.sp_Catalogue_AllParentsByChildCategory((int)Id).ToList();
            var result1 = (from r in result
                           select new AllParentsByChildCategoryModel
                           {
                               CategoryID = r.CategoryID,
                               CategoryParentID = r.CategoryParentID,
                               CategoryTitle = r.CategoryTitle
                           }).ToList();
            return result1;
        }

        public List<AllInheritedAttributesByCategoryModel> GetAllInheritedAttributesByCategoryId(long Id)
        {
            var result = uow.OMSContext.sp_Catalogue_AllInheritedAttributesByCategory((int)Id).ToList();
            var result1 = (from r in result
                           select new AllInheritedAttributesByCategoryModel
                           {
                               AttributeID = r.AttributeID,
                               AttributeTitle = r.AttributeTitle,
                               AttributeValue = r.AttributeValue
                           }).ToList();
            return result1;
        }

        public ProductDetailModel GetProductDetail(long productId, long profileId, bool isShop = false)
        {
            if (productId <= 0)
                return new ProductDetailModel();
			var IsReviewInputAllowed = false;
            if (profileId > -1)
            {
                IsReviewInputAllowed = (from pd in uow.OMSContext.Product
                                        join oi in uow.OMSContext.CartItem on pd.ProductID equals oi.ProductID
                                        join o in uow.OMSContext.CartOrder on oi.CartOrderID equals o.CartOrderID
                                        //join pf in uow.OMSContext.Profile 
                                        where o.BuyerProfileID == profileId
                                        &&
                                        o.OrderStatusID >= (long)DBOrderStatusEnum.OrderPlaced
                                        &&
                                        oi.ProductID == productId
                                        select true
                       ).Any();
            }


            var result = (from p in uow.OMSContext.Product
                          where p.ProductID == productId
                          select new ProductDetailModel
                          {
                              ProductID = p.ProductID,
                              ProductTitle = p.ProductTitle,
                              BasePrice = p.BasePrice ?? 0,
                              SellingPrice = p.SellingPrice ?? 0,
                              UserRating = p.UserRating ?? 0,
                              //AnalysisRank = p.AnalysisRank ?? 0,
                              //StockCount = p.StockCount,
                              //ProductImagePath = p.ProductImagePath,
                              //ProductActualImagePath = p.ProductActualImagePath,
                              BrandID = p.BrandID,
                              BrandName = p.Brand.BrandName,
                              SupplierID = p.SupplierID,
                              SupplierName = p.Supplier.SupplierName,
                              ShopStatusId = p.Supplier.StatusID,
                              BrifeDescription = p.BrifeDescription,
                              Description = p.Description,
                              ProductTypeID = p.ProductTypeID,
                              ProductTypeName = p.ProductType.ProductTypeTitle,
                              DiscountValue = p.DiscountValue,
                              IsDiscountPercentage = p.IsDiscountPercentage ?? true,
                              OrderResponseTime = p.OrderResponseTime,
                              OrderResponseTimeUnitID = p.OrderResponseTimeUnitID,
                              StatusID = p.StatusID,
                              //StatusName = p.STAT
                              TaxTypeID = p.TaxTypeID,
                              TaxTypeTitle = p.TaxType.TaxTypeTitle,
                              WebLink = p.WebLink,
                              IsReviewInputAllowed = IsReviewInputAllowed,
                              ModifiedOn = p.LastModifiedDateTime,//.HasValue ? p.LastModifiedDateTime.Value : DateTime.Now,
                              AttributeList = (from pa in uow.OMSContext.ProductAttributePair
                                               where pa.ProductID == productId //&& pa.IsAssigned == true
                                               orderby pa.DisplayOrder
                                               select new ProductAttributePairModel
                                               {
                                                   ProductAttributePairID = pa.ProductAttributePairID,
                                                   ProductID = pa.ProductID,
                                                   AttributeID = pa.AttributeID,
                                                   AttributeValue = pa.AttributeValue,
                                                   AttributeName = pa.Attribute.AttributeTitle,
                                                   ProductName = pa.Product.ProductTitle,
                                                   DisplayOrder = pa.DisplayOrder ?? 0,
                                                   IsAssigned = pa.IsAssigned,
                                                   IsSelectedForVariation = pa.IsSelectedForVariation,
                                                   VariationInPrice = pa.VariationInPrice,
                                                   AttributeTypeID = pa.Attribute.AttributeTypeID,
                                               }).ToList(),
                              CategoryList = (from c in uow.OMSContext.ProductCategoryPair
                                              where c.ProductID == productId
                                              select new CategoryLookupDetailModel
                                              {
                                                  CategoryID = c.CategoryID,
                                                  CategoryTitle = c.Category.CategoryTitle,
                                                  CategoryTypeID = c.Category.CategoryTypeID,
                                                  LogoPath = c.Category.LogoPath,
                                                  CategoryTypeTitle = c.Category.CategoryType.Title,
                                                  Description = c.Category.Description,
                                                  IsDefault = c.IsDefault,
                                              }).ToList(),
                              ProductImages = (from m in uow.OMSContext.ProductMediaDetail
                                               where m.ProductID == productId
                                               select new ProductImageDetailModel
                                               {
                                                   ProductMediaID = m.ProductMediaID,
                                                   ImageFileName = m.MediaFilePath,
                                                   ProductID = m.ProductID,
                                                   StatusID = m.StatusID,
                                                   ModifiedOn = m.LastModifiedDateTime,//.HasValue ? m.LastModifiedDateTime.Value : DateTime.Now,
                                                   IsDefault = m.Description.ToLower() == "default",
                                                   ModifiedBy = m.LastModifiedByUserID,//.HasValue ? m.LastModifiedByUserID.Value : -1,
                                                   CreatedBy = m.CreatedByUserID,
                                                   CreatedOn = m.CreatedDateTime,
                                               }).ToList(),
                              Category = (from pcp in uow.OMSContext.ProductCategoryPair
                                          where pcp.ProductID == p.ProductID && pcp.IsDefault == true
                                          select new CategoryLookupModel
                                          {
                                              CategoryID = pcp.CategoryID,
                                              CategoryTitle = pcp.Category.CategoryTitle,
                                              ParentCategoryID = pcp.Category.CategoryParentID,
                                          }).FirstOrDefault(),
                              //ProductDetailBannerList = (from m in uow.OMSContext.ProductMediaDetail
                              //                           where m.ProductID == Id && m.ProductMediaTitle.ToLower().Contains("productdetailbanner")
                              //                           select m.MediaFilePath).ToList()
                          });
            if (isShop)
            {
                result = result.Where(p => 
                p.StatusID != (int)DBStatusEnum.Deleted 
                &&
                p.ShopStatusId != (long)DBStatusEnum.Deleted);
            }
            else
            {
                result = result.Where(p => 
                p.StatusID == (int)DBStatusEnum.Active 
                &&
                (p.ShopStatusId == (long)DBStatusEnum.Active || p.ShopStatusId == (long)DBStatusEnum.InActive));
            }

            var Product = result.FirstOrDefault();
            
            return Product;
        }

        public List<ProductModel> GetProductByStatus(DBStatusEnum status)
        {
            var result = from product in uow.ProductRepository.OMSContext.Product
                         where product.StatusID == (int)status
                         select GetProductModel(product);
            return result.ToList();
        }

        public List<ProductCategoryPairModel> ShowCategoryListByProductId(long Id)
        {
            var result = (from pc in uow.OMSContext.ProductCategoryPair
                          where pc.ProductID == Id
                          select new ProductCategoryPairModel
                          {
                              ProductCategoryPairID = pc.ProductCategoryPairID,
                              ProductID = pc.ProductID,
                              CategoryID = pc.CategoryID,
                              CategoryTitle = pc.Category.CategoryTitle
                          });
            return result.ToList();
        }

        public List<ProductLookupModel> GetLookupList()
        {
            var result = (from p in uow.OMSContext.Product
                          where p.StatusID <= (int)DBStatusEnum.Active
                          orderby p.ProductTitle
                          select new ProductLookupModel
                          {
                              ProductID = p.ProductID,
                              ProductTitle = p.ProductTitle
                          }).ToList();
            return result;
        }

        public List<ProductLookupModel> GetLookupByShopId(long Id)
        {
            var result = (from p in uow.OMSContext.Product
                          where p.StatusID <= (int)DBStatusEnum.InActive && p.SupplierID == Id
                          orderby p.ProductTitle
                          select new ProductLookupModel
                          {
                              ProductID = p.ProductID,
                              ProductTitle = p.ProductTitle,
                              StatusId = p.StatusID,
                              ThumbnailImage = (from pmd in uow.OMSContext.ProductMediaDetail
                                                where pmd.ProductID == p.ProductID && pmd.Description.ToLower() == "default"
                                                select pmd.MediaFilePath).FirstOrDefault()
                          });
            return result.ToList();
        }

        public CartItemProductModel GetCartItemProduct(long productId)
        {
            var result = (from p in uow.OMSContext.Product
                              //join s in uow.OMSContext.Supplier on p.SupplierID equals s.SupplierID
                          join s in uow.OMSContext.Status on p.StatusID equals s.StatusID
                          where p.ProductID == productId
                          && p.StatusID == (long)DBStatusEnum.Active
                          select new CartItemProductModel()
                          {
                              ProductId = p.ProductID,
                              ProductName = p.ProductTitle,
                              UnitPrice = p.SellingPrice.HasValue ? p.SellingPrice.Value : 0,
                              TaxTypeID = p.TaxTypeID,
                              //TaxRateApplied = 0,
                              //TaxAmount = 0,
                              IsTaxPercentage = false,
                              DiscountValue = p.DiscountValue.HasValue ? p.DiscountValue.Value : 0,
                              IsDiscountPercentage = p.IsDiscountPercentage.HasValue ? p.IsDiscountPercentage.Value : false,
                              ItemTotalPrice = 0,
                              ShopProfileID = p.Supplier.ProfileID,
                              ShopId = p.Supplier.SupplierID,
                              ShopName = p.Supplier.SupplierName,
                              ShopCountryId = p.Supplier.CountryID ?? -1,
                              ShopProvinceId = p.Supplier.ProvinceID ?? -1,
                              ShopCityId = p.Supplier.CityID ?? -1,
                              BrandName = p.Brand.BrandName,
                              BrifeDescription = p.BrifeDescription,
                              ProductTypeName = p.ProductType.ProductTypeTitle,
                              StatusName = s.StatusName,
                          }).ToList();
            if (result != null && result.Count > 0)
            {
                List<Tax> listOfTax = GetTaxInfo();

                var product = result.FirstOrDefault();
                ProductTaxInfoModel productTaxInfo = new ProductTaxInfoModel {
                    ShopCityId = product.ShopCityId,
                    ShopProvinceId = product.ShopProvinceId,
                    ShopCountryId = product.ShopCountryId,
                    TaxTypeID = product.TaxTypeID,
                };
                if (product != null)
                {
                    GetProductTaxInfo(productTaxInfo, listOfTax);
                    product.IsTaxPercentage = productTaxInfo.IsTaxPercentage;
                    product.TaxRateApplied = productTaxInfo.TaxRateApplied;
                    return product;
                }
            }
            return null;
        }

        public void GetProductTaxInfo(ProductTaxInfoModel productTaxInfo, List<Tax> listOftax)
        {
            if (productTaxInfo != null)
            {
                var taxResult = listOftax.Where(x => x.TaxTypeID == productTaxInfo.TaxTypeID).ToList();

                //Use TaxRateApplied default as ZERO
                productTaxInfo.IsTaxPercentage = false;
                productTaxInfo.TaxRateApplied = 0;

                var taxFilter = (from t in taxResult
                                 where t.LocationId == productTaxInfo.ShopCountryId || t.LocationId == productTaxInfo.ShopProvinceId || t.LocationId == productTaxInfo.ShopCityId
                                 orderby t.EffectiveDate descending, t.LocationLevelId descending
                                 select t).ToList();

                //Following logic of Tax need to fixed/checked
                foreach (var tax in taxFilter)
                {
                    if (tax.LocationLevelId == (long)DBLocationLevelEnum.City)
                    {
                        if (productTaxInfo.ShopCityId == tax.LocationId)
                        {
                            productTaxInfo.IsTaxPercentage = tax.IsPercentage;
                            productTaxInfo.TaxRateApplied = tax.TaxValue;
                            break;
                        }
                    }
                    if (tax.LocationLevelId == (long)DBLocationLevelEnum.Province)
                    {
                        if (productTaxInfo.ShopProvinceId == tax.LocationId)
                        {
                            productTaxInfo.IsTaxPercentage = tax.IsPercentage;
                            productTaxInfo.TaxRateApplied = tax.TaxValue;
                            break;
                        }
                    }
                    if (tax.LocationLevelId == (long)DBLocationLevelEnum.Country)
                    {
                        if (productTaxInfo.ShopCountryId == tax.LocationId)
                        {
                            productTaxInfo.IsTaxPercentage = tax.IsPercentage;
                            productTaxInfo.TaxRateApplied = tax.TaxValue;
                            break;
                        }
                        else
                        {   //Use Country Level Tax if nothing matched
                            productTaxInfo.IsTaxPercentage = false;// tax.IsPercentage;
                            productTaxInfo.TaxRateApplied = 0;// tax.TaxValue;
                            break;
                        }
                    }
                }
            }
        }
        public List<Tax> GetTaxInfo()
        {
            List<Tax> listOftax = new List<Tax>();
            listOftax = (from t in uow.OMSContext.Tax
                         where
                         t.EffectiveDate <= DateTime.Now
                         orderby t.EffectiveDate descending, t.LocationLevelId descending
                         select t).ToList();
            return listOftax;
        }
        public List<ProductBoxModel> GetPopularProductList()
        {
            try
            {
                var ps = new ProductSearchAdapter();
                var filter = ps.ApplySearchFilter(new ProductSearchModel { CountryId = -1 });
                var result = ps.GetProductBoxModel(filter.OrderBy(x => x.AnalysisRank), true);
                return result.Take(20).ToList();
            }
            catch (Exception ex)
            {
                var s = ex.Message;
                return null;
            }
        }

        public bool IsShopAvailable(long productId)
        {
            var result = (from p in uow.OMSContext.Product
                          where p.ProductID == productId && p.StatusID == (long)DBStatusEnum.Active
                          select p.Supplier.StatusID == (long)DBStatusEnum.Active).FirstOrDefault();
            return result;
        }

        /// <summary>
        /// to get special products like TAX and Delivery Products
        /// </summary>
        /// <param name="ProductTypeId"></param>
        /// <param name="ProductTypePartialName">if product type is unknown, then part of the product type name can be used to </param>
        /// <returns></returns>
        public List<ProductModel> GetProductListByType(long? ProductTypeId = null, string ProductTypePartialName = null)
        {
            ProductTypePartialName = ProductTypePartialName.ToLower();
            var result = (from p in uow.OMSContext.Product
                          where p.ProductType.ProductTypeTitle.ToLower().Contains(ProductTypePartialName)
                          select new ProductModel
                          {
                              ProductID = p.ProductID,
                              ProductTitle = p.ProductTitle,
                              BrifeDescription = p.BrifeDescription,
                              ProductActualImagePath = p.ProductActualImagePath,
                              ProductImagePath = p.ProductImagePath,
                              StockCount = p.StockCount ?? 0,
                              WebLink = p.WebLink,
                              BasePrice = p.BasePrice ?? 0,
                              SellingPrice = p.SellingPrice ?? 0,
                              UserRating = p.UserRating ?? 0,
                              AnalysisRank = p.AnalysisRank ?? 0,
                              Description = p.Description,
                              ProductTypeID = p.ProductTypeID,
                              BrandID = p.BrandID,
                              SupplierID = p.SupplierID,
                              StatusID = p.StatusID,
                              ProductTypeName = p.ProductType.ProductTypeTitle,
                              SupplierName = p.Supplier.SupplierName,
                              BrandName = p.Brand.BrandName,
                          });
            if (ProductTypeId.HasValue)
                result.Where(p => p.ProductTypeID == ProductTypeId.Value);

            return result.ToList();
        }

        #endregion Select

        #region Update

        public bool UpdateProduct(ProductModel productModel)
        {
            try
            {
                var product = UpdateConcurrency(GetEntity(productModel), productModel);
                var recordsCount = uow.OMSContext.Product_Update(product);
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }

        public bool UpdateProductBasicInfo(ProductBasicInfoModel productModel)
        {
            try
            {
                var product = UpdateConcurrency(GetProductEntity(productModel), productModel);
                var recordsCount = uow.OMSContext.Product_UpdateBasicInfo(product);
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }

        public bool UpdateProductPricing(ProductPricingModel productModel)
        {
            try
            {
                var product = UpdateConcurrency(GetProductEntity(productModel), productModel);
                var recordsCount = uow.OMSContext.Product_UpdatePricing(product);
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }

        public bool UpdateProductImages(ProductImagesModel productModel)
        {
            try
            {
                var product = new Product
                {
                    ProductID = productModel.ProductID,
                    ProductActualImagePath = productModel.ProductActualImagePath,
                    ProductImagePath = productModel.ProductImagePath
                };
                //UpdateConcurrency(GetEntity(productModel), productModel);
                var recordsCount = uow.OMSContext.Product_UpdateImages(product);
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }
        public bool UpdateForAnalysisRank()
        {
            try
            {
                var recordsCount = uow.OMSContext.Product_UpdateForAnalysisRank();

                return recordsCount > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }

        public bool UpdateProductStatus(long ProductId, DBStatusEnum status)
        {
            try
            {
                var productIds = ProductId.ToString();
                var recordsCount = uow.OMSContext.Bulk_Update("product", "productid", productIds, "statusid", ((int)status).ToString());
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        public bool ApproveProductList(List<long> ProductList)
        {
            try
            {
                var productIds = string.Join(",", ProductList.Select(n => n.ToString()).ToArray());
                var recordsCount = uow.OMSContext.Bulk_Update("product", "productid", productIds, "statusid", ((int)DBStatusEnum.Active).ToString());
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        #endregion Update

        #region Add

        public long? AddProduct(ProductModel productModel)
        {
            try
            {
                var outParam = new ObjectParameter("ProductID", typeof(long));

                var product = UpdateConcurrency(GetEntity(productModel), productModel);
                var recordsCount = uow.OMSContext.Product_Insert(product, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }

        public long? AddProductBasicInfo(ProductBasicInfoModel productModel)
        {
            try
            {
                var outParam = new ObjectParameter("ProductID", typeof(long));

                var product = UpdateConcurrency(GetProductEntity(productModel), productModel);
                var recordsCount = uow.OMSContext.Product_InsertBasicInfo(product, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }

        public long? AddProductCategoryPair(ProductCategoryPairModel model)
        {

            try
            {
                var outParam = new ObjectParameter("ProductCategoryPairID", typeof(int));
                ProductCategoryPair productCategoryPair = new ProductCategoryPair()
                {
                    CategoryID = model.CategoryID,
                    ProductID = model.ProductID
                };
                var recordsCount = uow.OMSContext.ProductCategoryPair_Insert(productCategoryPair, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add

        #region Delete
        public bool DeleteProduct(ProductModel productModel)
        {
            try
            {
                var product = GetProductEntity(productModel);
                uow.ProductRepository.Delete(product);
                uow.Commit();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion Delete

        #region Private
        protected ProductModel GetProductModel(Product productModel)
        {
            return new ProductModel()
            {
                ProductID = productModel.ProductID,
                ProductTitle = productModel.ProductTitle,
                BrifeDescription = productModel.BrifeDescription,
                ProductActualImagePath = productModel.ProductActualImagePath,
                ProductImagePath = productModel.ProductImagePath,
                StockCount = productModel.StockCount ?? 0,
                WebLink = productModel.WebLink,
                BasePrice = productModel.BasePrice ?? 0,
                SellingPrice = productModel.SellingPrice ?? 0,
                OrderResponseTime = productModel.OrderResponseTime,
                OrderResponseTimeUnitID = productModel.OrderResponseTimeUnitID,
                TaxTypeID = productModel.TaxTypeID,
                UserRating = productModel.UserRating ?? 0,
                AnalysisRank = productModel.AnalysisRank ?? 0,
                Description = productModel.Description,
                ProductTypeID = productModel.ProductTypeID,
                BrandID = productModel.BrandID,
                SupplierID = productModel.SupplierID,
                StatusID = productModel.StatusID,
                ProductTypeName = productModel.ProductType.ProductTypeTitle,
                SupplierName = productModel.Supplier.SupplierName,
                BrandName = productModel.Brand.BrandName,
                IsDiscountPercentage = productModel.IsDiscountPercentage.HasValue ? productModel.IsDiscountPercentage.Value : true,
                DiscountValue = productModel.DiscountValue,
                CreatedBy = productModel.CreatedByUserID,
                CreatedOn = productModel.CreatedDateTime,
                ModifiedBy = productModel.LastModifiedByUserID,//.HasValue ? productModel.LastModifiedByUserID.Value : -1,
                ModifiedOn = productModel.LastModifiedDateTime,//.HasValue ? productModel.LastModifiedDateTime.Value : DateTime.Now,
            };
        }
        protected Product GetProductEntity(ProductModel product)
        {
            return new Product()
            {
                ProductID = product.ProductID,
                ProductTitle = product.ProductTitle,
                BrifeDescription = product.BrifeDescription,
                ProductActualImagePath = product.ProductActualImagePath,
                ProductImagePath = product.ProductImagePath,
                StockCount = product.StockCount,
                WebLink = product.WebLink,
                BasePrice = product.BasePrice,
                SellingPrice = product.SellingPrice,
                UserRating = product.UserRating,
                AnalysisRank = product.AnalysisRank,
                Description = product.Description,
                ProductTypeID = product.ProductTypeID,
                BrandID = product.BrandID,
                SupplierID = product.SupplierID,
                StatusID = product.StatusID,
            };
        }
        protected Product GetProductEntity(ProductBasicInfoModel product)
        {
            return new Product()
            {
                ProductID = product.ProductID,
                ProductTitle = product.ProductTitle,
                BrifeDescription = product.BrifeDescription,
                Description = product.Description,
                ProductTypeID = product.ProductTypeID,
                BrandID = product.BrandID,
                SupplierID = product.SupplierID,
                StatusID = product.StatusID,
            };
        }
        protected Product GetProductEntity(ProductPricingModel model)
        {
            return new Product()
            {
                ProductID = model.ProductID,
                BasePrice = model.BasePrice,
                SellingPrice = model.SellingPrice,
                DiscountValue = model.DiscountValue,
                IsDiscountPercentage = model.IsDiscountPercentage,
                TaxTypeID = model.TaxTypeID,
                OrderResponseTime = model.OrderResponseTime,
                OrderResponseTimeUnitID = model.OrderResponseTimeUnitID

            };
        }
        #endregion
    }
}