using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using static OMSCloud.Contracts.Common.DBEnums.SortByEnum;

namespace OMSCloud.Business.Adapters
{
    public class ProductSearchAdapter : ProductAdapter
    {
        #region Searching_API
        public ProductSearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString ="", string sortOrder = "", int? shopId = null)
        {
           var productResult = new ProductSearchResultAdminModel();

            var result = (from p in uow.OMSContext.Product
                          join s in uow.OMSContext.Status on p.StatusID equals s.StatusID
                          where s.StatusID != (int)DBStatusEnum.Deleted 
                          orderby p.ProductTitle
                          select new ProductAdminModel
                          {
                              BasePrice = p.BasePrice.HasValue ? p.BasePrice.Value : 0,
                              ProductID = p.ProductID,
                              ProductName = p.ProductTitle,
                              Image = p.ProductImagePath,
                              ProductTypeID = p.ProductTypeID,
                              ProductTypeName = p.ProductType.ProductTypeTitle,
                              SellingPrice = p.SellingPrice.HasValue ? p.SellingPrice.Value : 0,
                              BriefDescription = p.BrifeDescription,
                              StatusID = p.StatusID,
                              StatusName = s.StatusName,
                              ShopId = p.SupplierID,
                              ShopName = p.Supplier.SupplierName,
                              Rating = p.UserRating ?? 0,
                              AnalysisRank = p.AnalysisRank.HasValue ? p.AnalysisRank.Value : -1,
                              Discount = p.DiscountValue ?? 0,
                              IsDiscountPercentage = p.IsDiscountPercentage.HasValue ? p.IsDiscountPercentage.Value : true,
                              Category = (from pcp in uow.OMSContext.ProductCategoryPair
                                          where pcp.ProductID == p.ProductID && pcp.IsDefault == true
                                          select new CategoryLookupModel
                                          {
                                              CategoryID = pcp.CategoryID,
                                              CategoryTitle = pcp.Category.CategoryTitle,
                                              ParentCategoryID = pcp.Category.CategoryParentID,
                                          }).FirstOrDefault(),
                          });

            result = SortProducts(sortOrder, result);
            searchString = searchString?.Trim()?.ToLower();
            if (!string.IsNullOrEmpty(searchString))
            {
                result = result.Where(x => x.ProductName.Trim().ToLower().Contains(searchString)
                || x.BriefDescription.Trim().ToLower().Contains(searchString)
                || x.ShopName.Trim().ToLower().Contains(searchString));
            }
            if (shopId.HasValue)
            {
                result = result.Where(x => x.ShopId == shopId);
            }
            var total = result.Count();
            if (total > 0)
            {
                var pages = (int)Math.Ceiling((double)total / PageSize_RowCount);
                pages = pages == 0 ? 1 : pages;
                var skip = PageSize_RowCount * (PageNum - 1);
                if (skip > total)
                    skip = total;
                var ProductList1 = result.Skip(skip).Take(PageSize_RowCount);//.ToList();
                var ProductList = ProductList1.ToList();
                var MaxPrice = 0.0d;
                var MinPrice = 0.0d;
                if (ProductList.Count > 0)
                {
                    MaxPrice = result.Max(x => x.SellingPrice);
                    MinPrice = result.Min(x => x.SellingPrice);
                }
                productResult = new ProductSearchResultAdminModel
                {
                    NumberOfPages = pages,
                    GrandRecordsCount = total,
                    CurrentPageMinIndex = skip + 1,
                    CurrentPageMaxIndex = ProductList.Count + skip,
                    MaxPrice = MaxPrice,
                    MinPrice = MinPrice,
                    ProductList = ProductList,
                };
            }
            return productResult;
        }
        private static IQueryable<ProductAdminModel> SortProducts(string sortOrder, IQueryable<ProductAdminModel> returnProductlist)
        {
            switch (sortOrder)
            {
                case "ProductTitle_desc":
                    returnProductlist = returnProductlist.OrderByDescending(s => s.ProductName);
                    break;
                case "ProductTitle":
                    returnProductlist = returnProductlist.OrderBy(s => s.ProductName);
                    break;
                case "SellingPrice":
                    returnProductlist = returnProductlist.OrderBy(s => s.SellingPrice);
                    break;
                case "SellingPrice_desc":
                    returnProductlist = returnProductlist.OrderByDescending(s => s.SellingPrice);
                    break;
                case "Discount":
                    returnProductlist = returnProductlist.OrderBy(s => s.Discount);
                    break;
                case "Discount_desc":
                    returnProductlist = returnProductlist.OrderByDescending(s => s.Discount);
                    break;
                case "UserRating":
                    returnProductlist = returnProductlist.OrderBy(s => s.Rating);
                    break;
                case "UserRating_desc":
                    returnProductlist = returnProductlist.OrderByDescending(s => s.Rating);
                    break;
                case "AnalysisRank":
                    returnProductlist = returnProductlist.OrderBy(s => s.AnalysisRank);
                    break;
                case "AnalysisRank_desc":
                    returnProductlist = returnProductlist.OrderByDescending(s => s.AnalysisRank);
                    break;
                case "Category_desc":
                    returnProductlist = returnProductlist.OrderByDescending(s => s.Category.CategoryTitle);
                    break;
                case "Category":
                    returnProductlist = returnProductlist.OrderBy(s => s.Category.CategoryTitle);
                    break;
                case "ProductTypeName":
                    returnProductlist = returnProductlist.OrderBy(s => s.ProductTypeName);
                    break;
                case "ProductTypeName_desc":
                    returnProductlist = returnProductlist.OrderByDescending(s => s.ProductTypeName);
                    break;
                case "SupplierName":
                    returnProductlist = returnProductlist.OrderBy(s => s.ShopName);
                    break;
                case "SupplierName_desc":
                    returnProductlist = returnProductlist.OrderByDescending(s => s.ShopName);
                    break;
                case "StatusName":
                    returnProductlist = returnProductlist.OrderBy(s => s.StatusName);
                    break;
                case "StatusName_desc":
                    returnProductlist = returnProductlist.OrderByDescending(s => s.StatusName);
                    break;
                //case "BrifeDescription":
                //    returnProductlist = returnProductlist.OrderBy(x => x.BrifeDescription);
                //    break;
                //case "BrifeDescription_desc":
                //    returnProductlist = returnProductlist.OrderByDescending(x => x.BriefDescription);
                //    break;
                //case "ProductActualImagePath":
                //    returnProductlist = returnProductlist.OrderBy(s => s.ProductActualImagePath);
                //    break;
                //case "ProductActualImagePath_desc":
                //    returnProductlist = returnProductlist.OrderByDescending(s => s.ProductActualImagePath);
                //    break;
                //case "ProductImagePath":
                //    returnProductlist = returnProductlist.OrderBy(s => s.ProductImagePath);
                //    break;
                //case "ProductImagePath_desc":
                //    returnProductlist = returnProductlist.OrderByDescending(s => s.ProductImagePath);
                //    break;
                //case "StockCount":
                //    returnProductlist = returnProductlist.OrderBy(s => s.StockCount);
                //    break;
                //case "StockCount_desc":
                //    returnProductlist = returnProductlist.OrderByDescending(s => s.StockCount);
                //    break;
                //case "BasePrice":
                //    returnProductlist = returnProductlist.OrderBy(s => s.BasePrice);
                //    break;
                //case "BasePrice_desc":
                //    returnProductlist = returnProductlist.OrderByDescending(s => s.BasePrice);
                //    break;
                //case "Description":
                //    returnProductlist = returnProductlist.OrderBy(s => s.Description);
                //    break;
                //case "Description_desc":
                //    returnProductlist = returnProductlist.OrderByDescending(s => s.Description);
                //    break;
                //case "BrandName":
                //    returnProductlist = returnProductlist.OrderBy(s => s.BrandName);
                //    break;
                //case "BrandName_desc":
                //    returnProductlist = returnProductlist.OrderByDescending(s => s.BrandName);
                //    break;
                default:
                    returnProductlist = returnProductlist.OrderBy(s => s.ProductName);
                    break;
            }
            return returnProductlist;
        }
        public ProductSearchResultModel ProductSearchByPage(ProductSearchModel model)
        {
            var productList = ApplySearchFilter(model);
            var searchResult = GetProductBoxModel(productList);
            var sortedResult = ApplySortFilter(searchResult, model.SortOrder, model.SortBy);
            var pagedResult = GetPagedResult(sortedResult, model.PageSize_RowCount, model.PageNum );

            if (model.CategoryId.HasValue)
            {
                pagedResult.ParentCategoryList = GetParentCategoryList(model.CategoryId.Value);
                pagedResult.AttributeList = GetAttributeList(model.CategoryId.Value);
            }
            else
            {
                CategoryAttributePairAdapter adapter = new CategoryAttributePairAdapter();
                pagedResult.AttributeList = adapter.GetAttributeLookupList();
            }
            return pagedResult;
        }
        #endregion Searching_API

        #region Searching_Private

        private List<AllInheritedAttributesByCategoryModel> GetAttributeList(long CategoryId)
        {
            ProductAdapter productAdapter = new ProductAdapter();
            var AttributeList = productAdapter.GetAllInheritedAttributesByCategoryId(CategoryId);
            return AttributeList;
        }
        private List<AllParentsByChildCategoryModel> GetParentCategoryList(long CategoryId)
        {
            ProductAdapter productAdapter = new ProductAdapter();
            var ParentCategoryList = productAdapter.GetParentCategoryListByChildCategoryId(CategoryId);
            return ParentCategoryList;
        }

        public IQueryable<Product> ApplySearchFilter(ProductSearchModel model)
        {
            var filter = (from p in uow.OMSContext.Product
                          where 
                                p.StatusID == (int)DBStatusEnum.Active 
                                && 
                                (p.Supplier.StatusID == (long)DBStatusEnum.Active || p.Supplier.StatusID == (long)DBStatusEnum.InActive)
                          select new { Product = p});
            if (model.AttributeList != null && model.AttributeList.Count > 0)
            {
                
                //List<string> listOfAttributesValues = model.AttributeList.SelectMany(d => d.Value).ToList();
                //filter = (from f in filter
                //          where f.Product.ProductAttributePair.Any(x => model.AttributeList.Keys.Contains(x.AttributeID)) && f.Product.ProductAttributePair.Any(x => listOfAttributesValues.Contains(x.AttributeValue))
                //          select f);

                foreach (KeyValuePair<long, List<string>> kvp in model.AttributeList)
                {
                    List<string> listOfAttributesValues = kvp.Value;
                    filter = (from f in filter
                              where f.Product.ProductAttributePair.Where(a => a.IsAssigned == true).Any(x => model.AttributeList.Keys.Contains(x.AttributeID)) && f.Product.ProductAttributePair.Any(x => listOfAttributesValues.Contains(x.AttributeValue))
                              select f);
                }
            }
            model.SearchString = model.SearchString?.Trim()?.ToLower();
            if (String.IsNullOrEmpty(model.SearchString?.Trim()) == false)
            {
                filter = filter.Where(f => 
                f.Product.ProductTitle.Trim().ToLower().Contains(model.SearchString) 
                || 
                f.Product.BrifeDescription.Trim().ToLower().Contains(model.SearchString));
            }
            if (model.CountryId > -1)
            {
                //No need to apply filter on Country as each deployment will have product to its own country only. 
                //filter = filter.Where(f => f.Product.Supplier.CountryID == model.CountryId.Value);
            }
            if (model.ProvinceId.HasValue)
            {
                filter = filter.Where(f => f.Product.Supplier.ProvinceID == model.ProvinceId.Value);
            }
            if (model.CityId.HasValue)
            {
                filter = filter.Where(f => f.Product.Supplier.CityID  == model.CityId.Value);
            }
            if (model.CategoryId.HasValue)
            {
                filter = (from f in filter
                          where f.Product.ProductCategoryPair.Any(x => x.CategoryID == model.CategoryId.Value)
                          select f);
            }
            if (model.ShopId.HasValue)
            {
                filter = filter.Where(f => f.Product.SupplierID == model.ShopId.Value);
            }
            if (model.MaxPrice.HasValue)
            {
                filter = filter.Where(f => f.Product.SellingPrice <= model.MaxPrice.Value);
            }
            if (model.MinPrice.HasValue)
            {
                filter = filter.Where(f => f.Product.SellingPrice >= model.MinPrice.Value);
            }
            if (model.ProductTypeId.HasValue)
            {
                filter = filter.Where(f => f.Product.ProductTypeID == model.ProductTypeId.Value);
            }
            return filter.Select(f => f.Product);
        }
        public IQueryable<ProductBoxModel> GetProductBoxModel(IQueryable<Product> list, bool flag = false)
        {
            var result = (from p in list
                          //orderby p.ProductTitle
                          select new ProductBoxModel
                          {
                              ProductID = p.ProductID,
                              ProductName = p.ProductTitle,
                              BasePrice = p.BasePrice ?? 0,
                              SellingPrice = p.SellingPrice ?? 0,
                              Rating = p.UserRating ?? 0,
                              Image = p.ProductMediaDetail.Where(pmd => pmd.ProductID == p.ProductID && pmd.Description.ToLower() == "default").Select(pmd => pmd.MediaFilePath).FirstOrDefault(),
                              ShopName = p.Supplier.SupplierName,
                              ShopId = p.Supplier.SupplierID,
                              BriefDescription = p.BrifeDescription,
                              Discount = p.DiscountValue ?? 0,
                              IsDiscountPercentage = p.IsDiscountPercentage ?? true,
                              DiscountAmount = (p.IsDiscountPercentage ?? true ) ? (((p.DiscountValue??0)/100)*(p.SellingPrice ?? 0)) : (p.DiscountValue ?? 0),
                              Category = (from pcp in uow.OMSContext.ProductCategoryPair
                                              where pcp.ProductID == p.ProductID && pcp.IsDefault == true
                                              select new CategoryLookupModel {
                                                  CategoryID = pcp.CategoryID,
                                                  CategoryTitle = pcp.Category.CategoryTitle,
                                                  ParentCategoryID = pcp.Category.CategoryParentID,
                                              }).FirstOrDefault(),
                             
                          });
            if (!flag)
                result = result.OrderBy(x => x.ProductName);
            return result;
        }

        private ProductSearchResultModel GetPagedResult(
            IQueryable<ProductBoxModel> list,
            int PageSize_RowCount,
            int PageNum)
        {
            var total = list.Count();
            
            var result = new ProductSearchResultModel
            {
                NumberOfPages = 0,
                GrandRecordsCount = 0,
                CurrentPageMaxIndex = 0,
                CurrentPageMinIndex = 0,
                MaxPrice = 0,
                MinPrice = 0,
                ProductList = null,
                AttributeList = null,
                ParentCategoryList = null,
            };
            if (total > 0)
            {
                var pages = (int)Math.Ceiling((double)total / PageSize_RowCount);
                pages = pages == 0 ? 1 : pages;
                var skip = PageSize_RowCount * (PageNum - 1);
                if (skip > total)
                    skip = total;
                var ProductList = list.Skip(skip).Take(PageSize_RowCount).ToList();
                var MaxPrice = 0.0d;
                var MinPrice = 0.0d;
                if (ProductList.Count > 0)
                {
                    MaxPrice = list.Max(x => x.SellingPrice);
                    MinPrice = list.Min(x => x.SellingPrice);
                }
                result = new ProductSearchResultModel
                {
                    NumberOfPages = pages,
                    GrandRecordsCount = total,
                    CurrentPageMinIndex = skip+1,
                    CurrentPageMaxIndex = ProductList.Count + skip,
                    MaxPrice = MaxPrice,
                    MinPrice = MinPrice,
                    ProductList = ProductList,
                    AttributeList = null,
                    ParentCategoryList = null,
                };
            }
            return result;
        }

        private IQueryable<ProductBoxModel> ApplySortFilter(
            IQueryable<ProductBoxModel> productList,
            bool SortOrder,
            SortByEnum SortBy)
        {
            if (SortOrder == false) //Ascending
            {
                switch (SortBy)
                {
                    case MinPrice:
                        productList = from p in productList orderby (p.SellingPrice -p.DiscountAmount) ascending select p;
                        break;
                    case ProductTitle:
                        productList = from p in productList orderby p.ProductName  ascending select p;
                        break;
                    case MaxPrice:
                        // Soritng by MaxPrice should be descending (even user selected sortOrder = ascending)
                        productList = from p in productList orderby (p.SellingPrice - p.DiscountAmount) descending select p; 
                        break;
                    case UserRating:
                        productList = from p in productList orderby p.Rating ascending select p;
                        break;
                }
            }
            else if (SortOrder == true) //Descending
            {
                switch (SortBy)
                {
                    case MinPrice:
                        // Soritng by MinPrice should be Ascending (even user selected sortOrder = DESCENDING)
                        productList = from p in productList orderby (p.SellingPrice - p.DiscountAmount) ascending select p;
                        break;
                    case ProductTitle:
                        productList = from p in productList orderby p.ProductName descending select p;
                        break;
                    case MaxPrice:
                        productList = from p in productList orderby (p.SellingPrice - p.DiscountAmount) descending select p;
                        break;
                    case UserRating:
                        productList = from p in productList orderby p.Rating descending select p;
                        break;
                }

            }
            return productList;
        }

        #endregion Searching_Private
    }
}
#region Lookup_TRY
//AttributeList = (Lookup<string, ProductAttributePairLookupModel>)(from pap in uow.OMSContext.ProductAttributePair
//                                                                  where pap.ProductID == p.ProductID
//                                                                  select new ProductAttributePairLookupModel
//                                                                  {
//                                                                      ProductAttributePairID = pap.ProductAttributePairID,
//                                                                      ProductID = pap.ProductID,
//                                                                      AttributeID = pap.AttributeID,
//                                                                      AttributeName = pap.Attribute.AttributeTitle,
//                                                                      AttributeValue = pap.AttributeValue,
//                                                                      DisplayOrder = pap.DisplayOrder
//                                                                  }).ToLookup(m => m.AttributeName)
#endregion Lookup_TRY