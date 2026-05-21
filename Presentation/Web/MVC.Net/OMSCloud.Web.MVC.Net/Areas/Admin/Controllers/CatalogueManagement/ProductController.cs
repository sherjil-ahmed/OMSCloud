using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Proxy.WebAPI;
using static OMSCloud.Contracts.Common.CommonUtilities;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.Common.ConfigMgmt;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class ProductController : BaseMvcController
    {
        #region DataMembers
        private ProductControllerProxy proxy = new ProductControllerProxy();
        private TaxTypeControllerProxy taxTypeProxy = new TaxTypeControllerProxy();
        private CategoryControllerProxy categoryProxy = new CategoryControllerProxy();
        private ProductTypeControllerProxy ProductTypeProxy = new ProductTypeControllerProxy();
        private BrandControllerProxy BrandProxy = new BrandControllerProxy();
        private SupplierControllerProxy SupplierProxy = new SupplierControllerProxy();
        private StatusControllerProxy statusProxy = new StatusControllerProxy();
        #endregion DataMembers

        #region Default

        // GET: Admin/Product
        public ActionResult Index(int PageNum = 1, int PageSize_RowCount = 50, string searchString = "", string sortOrder = "", int? shopId = null)
        {
            #region Sorting Region With ViewBag
            ViewBag.ProductTitleSortParm = String.IsNullOrEmpty(sortOrder) ? "ProductTitle_desc" : "";
            ViewBag.SellingPriceSortParm = sortOrder == "SellingPrice" ? "SellingPrice_desc" : "SellingPrice";
            ViewBag.DiscountSortParm = sortOrder == "Discount" ? "Discount_desc" : "Discount";
            ViewBag.UserRatingSortParm = sortOrder == "UserRating" ? "UserRating_desc" : "UserRating";
            ViewBag.AnalysisRankSortParm = sortOrder == "AnalysisRank" ? "AnalysisRank_desc" : "AnalysisRank";
            ViewBag.CategoryNameSortParm = sortOrder == "Category" ? "Category_desc" : "Category";
            ViewBag.ProductTypeNameSortParm = sortOrder == "ProductTypeName" ? "ProductTypeName_desc" : "ProductTypeName";
            ViewBag.SupplierNameSortParm = sortOrder == "SupplierName" ? "SupplierName_desc" : "SupplierName";
            ViewBag.StatusNameSortParm = sortOrder == "StatusName" ? "StatusName_desc" : "StatusName";
            #endregion

            var result = proxy.GetListByPage(PageNum, PageSize_RowCount, searchString, sortOrder, shopId );
            ViewBag.PageCount = result.NumberOfPages;
            ViewBag.CurrentPageIndex = PageNum;
            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;
            return View(result.ProductList);
        }

        // GET: Admin/Product/GetProductByTitle?productName=abc&shopName=xyz
        //Admin/Product/productName/Shop/shopName
        //[Route(template:"Admin/Product/{productName}/Shop/{shopName}")]
        public ActionResult GetProductByTitle(string productName, string shopName)
        {
            var product = ProductModelByTitle(productName, shopName);
            return View("~/Areas/Admin/Views/Product/Details.cshtml", product);/*
			return View("Details.cshtml", product);
			return View("Details", product);
			return View("~/Area/Admin/Views/Product/GetProductByTitle.cshtml", product);
			return View("GetProductByTitle.cshtml", product);
			return View("GetProductByTitle", product);*/
		}
		// GET: Admin/Product/Details/5
		public ActionResult Details(long Id)
        {
            var product = ViewById(Id);
            return View(product);
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            this.PrepareViewBagForEditing();
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileRoute"></param>
        /// <param name="fileType"></param>
        /// <param name="recordId"></param>
        /// <returns></returns>

        // POST: Admin/Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*HttpPostedFileBase productActualIamgeFile, HttpPostedFileBase productImageFile,*/ 
            ProductModel model, FormCollection collection)
        {
            try
            {
                model.BasePrice = Math.Round( GetBasePrice(model), 2);
                var newProductId = proxy.Put(model);
                if (newProductId.HasValue == true)
                {
                    /*var modelById = proxy.GetById(newProductId.Value);
                    //success
                    if(productActualIamgeFile != null)
                        modelById.ProductActualImagePath = SaveFile(productActualIamgeFile, Server.MapPath("~/"), ImageRoute.Product, newProductId.Value);
                    if(productImageFile != null)
                        modelById.ProductImagePath = SaveFile(productImageFile, Server.MapPath("~/"), ImageRoute.Product, newProductId.Value);
                    if (proxy.Post(modelById))
                    {*/
                        var list = new RouteValueDictionary();
                        list.Add("Id", newProductId.Value);
                        return RedirectToAction("Edit", list);
                    /*}*/
                }
                //failure == Still No sucess
                // Show Message and then redirect to Index Page or stay on the Create Page
                this.PrepareViewBagForEditing();
                return View(model);// RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
                this.PrepareViewBagForEditing();
                return View(model);
            }
        }

        // GET: Admin/Product/Edit/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(long Id)
        {
            PrepareViewBagForEditing();
            var product = ViewById(Id);
            return View(product);
        }


        // POST: Admin/Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*HttpPostedFileBase productActualIamgeFile, HttpPostedFileBase productImageFile,*/ 
            ProductModel model, FormCollection collection)
        {
            var ticks = collection["ModifiedOn.Ticks"];
            DateTime modifiedOn = new DateTime(Convert.ToInt64(ticks));
            model.ModifiedOn = modifiedOn;

            model.BasePrice = Math.Round(GetBasePrice(model), 2);

            try
            {
                //if (productActualIamgeFile != null)
                    //model.ProductActualImagePath = SaveFile(productActualIamgeFile, Server.MapPath("~/"), ImageRoute.Product, model.ProductID);
                //if (productImageFile != null)
                    //model.ProductImagePath = SaveFile(productImageFile, Server.MapPath("~/"), ImageRoute.Product, model.ProductID);

                if (proxy.Post(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.title = model.ProductTitle;
                    PrepareViewBagForEditing();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
                ViewBag.title = model.ProductTitle;
                PrepareViewBagForEditing();
                return View(model);
            }
        }

        private static double GetBasePrice(ProductModel model)
        {
            var zvonrFee = AppSession.IsProcessingFeePercentage ? model.SellingPrice * AppSession.ZvonrProcessingFee / 100 : AppSession.ZvonrProcessingFee;
            var gatewayFee = AppSession.IsPaymentGatewayFeePercentage ? model.SellingPrice * AppSession.PaymentGatewayFee / 100 : AppSession.PaymentGatewayFee;
            var discount = 0.0d;
            if (model.IsDiscountPercentage)
                discount = (((model.DiscountValue ?? 0) / 100) * model.SellingPrice);
            else
                discount = model.DiscountValue ?? 0;
            return model.SellingPrice - zvonrFee - gatewayFee - discount;
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(long Id)
        {
			var product = ViewById(Id);
			return View(product);
		}


		// POST: Admin/Product/Delete/5
		[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            try
            {
                ProductModel productModel = proxy.GetById(Id);
                productModel.StatusID = (int)DBStatusEnum.Deleted;
                proxy.Post(productModel);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        #endregion Default

        public ActionResult ShowProductReviewTab(long Id)
        {
            ViewData["ShopID"] = Id;
            CustomerReviewControllerProxy reviewProxy = new CustomerReviewControllerProxy();
            var model = reviewProxy.GetCustomerReviewList(null, CustomerReviewSubjectEnum.Product, Id, null);
            return PartialView("partial/_ProductReview", model);
        }
        
        #region JSON

        [HttpGet]
        public ActionResult ShowProductAttributeTabJson(long Id)
        {
            AttributeControllerProxy attributeProxy = new AttributeControllerProxy();
            var attributeProxyList = attributeProxy.GetAttributeListNotAssociatedWithProductId(Id);
            ViewBag.attributeList = new SelectList(attributeProxyList, "AttributeID", "AttributeTitle");


            string Data = RenderViewToString(ControllerContext, "~/Areas/Admin/Views/Product/partial/_ProductAttributeTab.cshtml", null, true);
            return Content(Data);
        }

        // GET: Admin/ProductAttributes/Create
        public ActionResult ShowProductAttributeTab(long Id)
        {
            AttributeControllerProxy attributeProxy = new AttributeControllerProxy();
            var attributeProxyList = attributeProxy.GetAttributeListNotAssociatedWithProductId(Id);
            ViewBag.attributeList = new SelectList(attributeProxyList, "AttributeID", "AttributeTitle");

            string Data = RenderViewToString(ControllerContext, "~/Areas/Admin/Views/Product/partial/_ProductAttributeTab.cshtml", null, true);
            return Content(Data);

            //return PartialView("partial/_ProductAttributeTab");//.View.Render
            //ControllerContext.=  ParentActionViewContext
            //http://www.codemag.com/Article/1312081

        }

        public ActionResult ShowCategoryListByProductId(long Id)
        {
            ProductControllerProxy categoryProxy = new ProductControllerProxy();
            var categoryList = categoryProxy.ShowCategoryListByProductId(Id);


            return PartialView("partial/_ProductCategoryList", categoryList);
        }

        public ActionResult ShowProductCategory(long Id)
        {
            CategoryControllerProxy categoryProxy = new CategoryControllerProxy();
            var categoryList = categoryProxy.GetCategoryListNotAssociatedWithProductId(Id);
            ViewBag.categoryList = new SelectList(categoryList, "CategoryID", "CategoryTitle");

            string Data = RenderViewToString(ControllerContext, "~/Areas/Admin/Views/Product/partial/_ProductCategoryTab.cshtml", null, true);
            return Content(Data);

            //return PartialView("partial/_ProductCategoryTab");
        }

        public ActionResult ShowPackagedProduct(long Id)
        {
            string Data = RenderViewToString(ControllerContext, "~/Areas/Admin/Views/Product/partial/_PackagedProductTab.cshtml", null, true);
            return Content(Data);

            //return PartialView("partial/_PackagedProductTab");
        }

        public ActionResult ShowProductMediaDetail(long Id)
        {
            ViewBag.Title = proxy.GetById(Id).ProductTitle;

            string Data = RenderViewToString(ControllerContext, "~/Areas/Admin/Views/Product/partial/_ProductMediaDetailTab.cshtml", null, true);
            return Content(Data);

            //return PartialView("partial/_PackagedProductTab");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ApproveProductList(string ProductCSV)
        {
            if(string.IsNullOrEmpty(ProductCSV))
                return new JsonResult() { Data = "" };
            var result = proxy.ApproveProductList(ProductCSV);
            return new JsonResult() { Data = result };
        }
        #endregion JSON

        #region Private


        private IEnumerable<ProductModel> GetList()
        {
            var Product = proxy.GetList();
            var category = categoryProxy.GetList();
            var producttype = ProductTypeProxy.GetList();
            var brand = BrandProxy.GetList();
            var supplier = SupplierProxy.GetList();
            var status = statusProxy.GetList();

            var result = from p in Product
                             //join c in category on p.CategoryID equals c.CategoryID
                         join pt in producttype on p.ProductTypeID equals pt.ProductTypeID
                         join b in brand on p.BrandID equals b.BrandID
                         join suplier in supplier on p.SupplierID equals suplier.SupplierID
                         join s in status on p.StatusID equals s.StatusID
                         select new ProductModel
                         {
                             AnalysisRank = p.AnalysisRank,
                             BasePrice = p.BasePrice,
                             BrandID = p.BrandID,
                             BrandName = b.BrandName,
                             BrifeDescription = p.BrifeDescription,
                             //CategoryID = p.CategoryID,
                             //CategoryName = c.CategoryTitle,
                             CreatedBy = p.CreatedBy,
                             CreatedOn = p.CreatedOn,
                             Description = p.Description,
                             ModifiedBy = p.ModifiedBy,
                             ModifiedOn = p.ModifiedOn,
                             ProductActualImagePath = p.ProductActualImagePath,
                             ProductID = p.ProductID,
                             ProductTitle = p.ProductTitle,
                             ProductImagePath = p.ProductImagePath,
                             ProductTypeID = p.ProductTypeID,
                             ProductTypeName = pt.ProductTypeTitle,
                             SellingPrice = p.SellingPrice,
                             StatusID = p.StatusID,
                             StatusName = s.StatusName,
                             StockCount = p.StockCount,
                             SupplierID = p.SupplierID,
                             SupplierName = suplier.SupplierName,
                             UserRating = p.UserRating,
                             WebLink = p.WebLink
                         };
            return result;
        }

        private ProductModel ViewById(long Id)
		{
			var productById = proxy.GetById(Id);
			return PrepareProductModel(productById);
		}

		private ProductModel ProductModelByTitle(string productName, string shopName)
        {
            var product = proxy.GetProductByTitle(productName, shopName);
			return PrepareProductModel(product);
		}

		private ProductModel PrepareProductModel(ProductModel productModel, string viewName = "Details")
		{
			//if (productModel == null)
				//return RedirectToAction("Index");
            //ViewBag.Title = productById.ProductTitle;
            //var categoryList = categoryProxy.GetList();
            var productTypeList = ProductTypeProxy.GetList();
            var brandList = BrandProxy.GetList();
            var supplierList = SupplierProxy.GetList();
            var statusList = statusProxy.GetList();

            //productById.CategoryName = (from c in categoryList
            //                            where c.CategoryID == productById.CategoryID
            //                            select c.CategoryTitle).First();

            productModel.ProductTypeName = (from pt in productTypeList
                                            where pt.ProductTypeID == productModel.ProductTypeID
                                            select pt.ProductTypeTitle).First();

            productModel.BrandName = (from b in brandList
                                      where b.BrandID == productModel.BrandID
                                      select b.BrandName).First();

            productModel.SupplierName = (from s in supplierList
                                         where s.SupplierID == productModel.SupplierID
                                         select s.SupplierName).First();

            productModel.StatusName = (from s in statusList
                                       where s.StatusID == productModel.StatusID
                                       select s.StatusName).First();
            ViewBag.ProductActualImagePath = ConvertToWebPath(productModel.ProductActualImagePath);
			ViewBag.ProductImagePath = ConvertToWebPath(productModel.ProductImagePath);
            return productModel;
		}


        private void PrepareViewBagForEditing()
        {
            var taxTypeList = taxTypeProxy.GetList();
            ViewBag.taxType = new SelectList(taxTypeList, "TaxTypeID", "TaxTypeTitle");

            var categoryList = categoryProxy.GetList();
            ViewBag.category = new SelectList(categoryList, "CategoryID", "CategoryTitle");

            var productTypeList = ProductTypeProxy.GetList();
            ViewBag.ProductType = new SelectList(productTypeList, "ProductTypeID", "ProductTypeTitle");

            var brandList = BrandProxy.GetList();
            ViewBag.Brand = new SelectList(brandList, "BrandID", "BrandName");

            var supplierList = SupplierProxy.GetList();
            ViewBag.Supplier = new SelectList(supplierList, "SupplierID", "SupplierName");

            var statusList = statusProxy.GetList();
            ViewBag.Status = new SelectList(statusList, "StatusID", "StatusName");

            var responseTimeUnit = Enum.GetValues(typeof(DBResponseTimeUnitEnum))
                .Cast<DBResponseTimeUnitEnum>().Select(v => new SelectListItem
                {
                    Text = v.ToString(),
                    Value = ((int)v).ToString()
                }).ToList();
            ViewBag.ResponseTimeUnit = new SelectList(responseTimeUnit, "Value", "Text");
        }



        #endregion Private

    }
}
