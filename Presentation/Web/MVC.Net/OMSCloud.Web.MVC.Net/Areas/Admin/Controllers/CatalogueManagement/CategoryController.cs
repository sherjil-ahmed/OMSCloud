using static OMSCloud.Contracts.Common.CommonUtilities;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Common;
using System.Web.Routing;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class CategoryController : BaseMvcController
    {
        private CategoryControllerProxy proxy = new CategoryControllerProxy();
        private CategoryTypeControllerProxy categoryTypeProxy = new CategoryTypeControllerProxy();
        private StatusControllerProxy statusProxy = new StatusControllerProxy();

        public ActionResult AssociateCategoryWithAttribute(long Id)
        {
            AttributeControllerProxy attributeProxy = new AttributeControllerProxy();
            var attributeProxyList = attributeProxy.GetAttributeListNotAssociatedWithCategoryId(Id);
            ViewBag.attributeList = new SelectList(attributeProxyList, "AttributeID", "AttributeTitle");

            //ViewBag.CategoryId = id;

            return PartialView("partial/_AssociateCategoryWithAttribute");
        }

        public ActionResult CreateAttribute(long Id)
        {
            DataTypeControllerProxy dataTypeProxy = new DataTypeControllerProxy();

            var dataTypeList = dataTypeProxy.GetList();
            ViewBag.DataTypeList = new SelectList(dataTypeList, "DataTypeID", "ClassName");

            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");

            ViewBag.CategoryID = Id;

            return PartialView("partial/_CreateAttribute");
        }

        // GET: Admin/Category
        public ActionResult Index(int PageNum = 1, int PageSize_RowCount = 50, string searchString = "", string sortOrder = "")
        {
            #region Sorting Region With ViewBag
            ViewBag.CategorySortParm = sortOrder == "Category" ? "Category_desc" : "Category";
            ViewBag.CategoryTypeSortParm = sortOrder == "CategoryType" ? "CategoryType_desc" : "CategoryType";
            ViewBag.ParentCategorySortParm = sortOrder == "ParentCategory" ? "ParentCategory_desc" : "ParentCategory";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "Status_desc" : "Status";
            ViewBag.IsSystemSortParm = sortOrder == "IsSystem" ? "IsSystem_desc" : "IsSystem";
            #endregion
            //PageSize_RowCount = 50;

            var categoryList = proxy.GetListByPage(PageNum, PageSize_RowCount, searchString, sortOrder);
            ViewBag.PageCount = categoryList.NumberOfPages;
            ViewBag.CurrentPageIndex = PageNum;
            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;
            return View(categoryList.CategoryList);
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(long Id)
        {
            var categoryById = proxy.GetById(Id);
            var categoryTypeList = categoryTypeProxy.GetList();
            var statusList = statusProxy.GetList();

            categoryById.CategoryTypeTitle = (from c in categoryTypeList
                                              where c.CategoryTypeID == categoryById.CategoryTypeID
                                              select c.Title).First();
            categoryById.StatusName = (from s in statusList
                                       where s.StatusID == categoryById.StatusID
                                       select s.StatusName).First();
            ViewBag.LogoPath = ConvertToWebPath(categoryById.LogoPath);
            return View(categoryById);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            PrepareViewBagForCreate();
            return View();
        }

        private void PrepareViewBagForCreate()
        {
            var categoryTypeList = categoryTypeProxy.GetList();
            ViewBag.categoryParent = new SelectList(categoryTypeList, "CategoryTypeID", "Title");

            var categoryList = proxy.GetList();
            ViewBag.categoryType = new SelectList(categoryList, "CategoryID", "CategoryTitle");

            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, CategoryModel model, FormCollection collection)
        {
            try
            {

                ViewBag.Message = "File uploaded successfully";

                if (file != null)
                    model.LogoPath = file.FileName;

                var Id = proxy.Put(model);
                if (Id.HasValue)
                {

                    if (file != null)
                    {
                        proxy.PostImage(Id.Value, file);
                        ViewBag.Message = "File uploaded successfully.";
                    }
                    var list = new RouteValueDictionary();
                    list.Add("Id", Id.Value);
                    return RedirectToAction("Edit", list);

                }
                ViewBag.Message = "Unable to save category and/or its image";
                PrepareViewBagForCreate();
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message;
                PrepareViewBagForCreate();
                return View(model);
            }
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(long Id)
        {
            var category = proxy.GetById(Id);
            if (category == null)
                return RedirectToAction("Index");

            PrepareViewBagForEdit(category);

            return View(category);
        }

        private void PrepareViewBagForEdit(CategoryModel category)
        {
            var categoryTypeList = categoryTypeProxy.GetList();
            ViewBag.categoryParent = new SelectList(categoryTypeList, "CategoryTypeID", "Title");

            var categoryList = proxy.GetList();
            ViewBag.categoryType = new SelectList(categoryList, "CategoryID", "CategoryTitle");

            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");

            ViewBag.LogoPath = ConvertToWebPath(category.LogoPath);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, long Id, CategoryModel model, FormCollection collection, CategoryAttributePairModel CategoryAttibutePairModel)
        {
            try
            {

                var ticks = collection["ModifiedOn.Ticks"];
                DateTime ModifiedOn = new DateTime(Convert.ToInt64(ticks));
                model.ModifiedOn = ModifiedOn;

                if (file != null)
                    model.LogoPath = file.FileName;

                
                if (proxy.Post(model))
                {
                    if (file != null)
                    {
                        proxy.PostImage(model.CategoryID, file);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.Message = "Unable to save category and/or its image";
                PrepareViewBagForEdit(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message;
                PrepareViewBagForEdit(model);
                return View(model);
            }
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(long Id)
        {
            var categoryById = proxy.GetById(Id);
            var categoryTypeList = categoryTypeProxy.GetList();
            var statusList = statusProxy.GetList();

            categoryById.CategoryTypeTitle = (from c in categoryTypeList
                                              where c.CategoryTypeID == categoryById.CategoryTypeID
                                              select c.Title).First();
            categoryById.StatusName = (from s in statusList
                                       where s.StatusID == categoryById.StatusID
                                       select s.StatusName).First();
            ViewBag.LogoPath = ConvertToWebPath(categoryById.LogoPath);
            return View(categoryById);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here 
                proxy.Delete(Id);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
