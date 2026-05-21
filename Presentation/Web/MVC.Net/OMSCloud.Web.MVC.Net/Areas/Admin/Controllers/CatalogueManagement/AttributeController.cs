using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class AttributeController : BaseMvcController
    {
        #region Data Memeber
        private AttributeControllerProxy proxy = new AttributeControllerProxy();
        private DataTypeControllerProxy dataTypeProxy = new DataTypeControllerProxy();
        private StatusControllerProxy statusProxy = new StatusControllerProxy();
        private AttributeTypeControllerProxy attributeTypeProxy = new AttributeTypeControllerProxy();
        #endregion Data Memeber

        #region Default Actions

        public ActionResult Index(int PageNum = 1, int PageSize_RowCount = 50, string searchString = "", string sortOrder = "")
        {
            
            #region Sorting Region With ViewBag
            ViewBag.AttributeNameSortParm = sortOrder == "AttributeName" ? "AttributeName_desc" : "AttributeName";
            ViewBag.DescriptionSortParm = sortOrder == "Description" ? "Description_desc" : "Description";
            ViewBag.DataTypeSortParm = sortOrder == "DataType" ? "DataType_desc" : "DataType";
            ViewBag.AttributeTypeSortParm = sortOrder == "AttributeType" ? "AttributeType_desc" : "AttributeType";
            ViewBag.IsMultiSelectSortParm = sortOrder == "IsMultiSelect" ? "IsMultiSelect_desc" : "IsMultiSelect";
            ViewBag.IsSystemSortParm = sortOrder == "IsSystem" ? "IsSystem_desc" : "IsSystem";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "Status_desc" : "Status";
            #endregion

            var result = proxy.GetListByPage(PageNum, PageSize_RowCount, searchString, sortOrder);
            ViewBag.PageCount = result.NumberOfPages;
            ViewBag.CurrentPageIndex = PageNum;
            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;
            return View(result.AttributeList);
        }

        // GET: Admin/Attributes/Details/5
        public ActionResult Details(long Id)
        {
            var statusList = statusProxy.GetList();
            var dataTypeList = dataTypeProxy.GetList();
            var attributeById = proxy.GetById(Id);

            var attributeType = attributeTypeProxy.GetList();

            attributeById.AttributeTypeTitle = (from at in attributeType
                                                where at.AttributeTypeID == attributeById.AttributeTypeID
                                                select at.AttributeTypeTitle).First();

            attributeById.DataTypeTitle = (from d in dataTypeList
                                           where d.DataTypeID == attributeById.DataTypeID
                                           select d.ClassName).First();
            attributeById.StatusTitle = (from s in statusList
                                         where s.StatusID == attributeById.StatusID
                                         select s.StatusName).First();
            return View(attributeById);
        }


        // GET: Admin/Attributes/Create
        public ActionResult Create()
        {
            PrepareViewBagForCreate();
            return View();
        }

        private void PrepareViewBagForCreate()
        {
            var dataTypeList = dataTypeProxy.GetList();
            ViewBag.DataTypeList = new SelectList(dataTypeList, "DataTypeID", "ClassName");

            ViewBag.attributeType = new SelectList(attributeTypeProxy.GetList(), "AttributeTypeID", "AttributeTypeTitle");

            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
        }

        // POST: Admin/Attributes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AttributeModel model, FormCollection collection, CategoryModel catmodel)
        {
            try
            {
                //model.AttributeTypeID = (int)model.AttributeType;
                proxy.Put(model);
                return RedirectToAction("Index");

            }
            catch
            {
                PrepareViewBagForCreate();
                return View(model);
            }
        }

        // GET: Admin/Attributes/Edit/5
        public ActionResult Edit(long Id)
        {
            var model = proxy.GetById(Id);
            if (model == null)
                return RedirectToAction("Index");
            PrepareViewBagForEdit();
            //model.AttributeType = (DBAttributeTypeEnum)model.AttributeTypeID;
            return View(model);
        }

        private void PrepareViewBagForEdit()
        {
            var dataTypeList = dataTypeProxy.GetList();
            ViewBag.DataTypeList = new SelectList(dataTypeList, "DataTypeID", "ClassName");

            ViewBag.attributeType = new SelectList(attributeTypeProxy.GetList(), "AttributeTypeID", "AttributeTypeTitle");

            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
        }

        // POST: Admin/Attributes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AttributeModel model, FormCollection collection)
        {
            try
            {
                //model.AttributeTypeID = (int)model.AttributeType;
                var ticks = collection["ModifiedOn.Ticks"];
                DateTime modifiedOn = new DateTime(Convert.ToInt64(ticks));
                model.ModifiedOn = modifiedOn;
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBagForEdit();
                return View(model);
            }
        }

        // GET: Admin/Attributes/Delete/5
        public ActionResult Delete(long Id)
        {
            var attributeById = proxy.GetAttributeById(Id);
            return View(attributeById);
        }

        // POST: Admin/Attributes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            proxy.Delete(Id);
            return RedirectToAction("Index");
        }

        #endregion Default Actions

        #region Custom Actions

        // GET: Admin/Attributes/Create
        public ActionResult CreateAttribute(long Id)
        {
            var dataTypeList = dataTypeProxy.GetList();
            ViewBag.DataTypeList = new SelectList(dataTypeList, "DataTypeID", "ClassName");

            //ViewBag.CategoryID = Id.ToString();
            ViewBag.attributeType = new SelectList(attributeTypeProxy.GetList(), "AttributeTypeID", "AttributeTypeTitle");

            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
            return PartialView("Partial/_CreateAttribute");

        }

        [HttpPost]
        public JsonResult CreateAttribute(long Id, AttributeModel model, FormCollection collection)
        {
            try
            {
                long categoryId = Id;
                model.AttributeTypeID = model.AttributeTypeID;
                var jsonResult = new JsonResult();
                var attributeNewId = proxy.Put(model);
                if (attributeNewId.HasValue)
                {
                    AttributeLookupModel attribute = new AttributeLookupModel()
                    {
                        AttributeID = attributeNewId.Value,
                        AttributeTitle = model.AttributeTitle
                    };

                    jsonResult.Data = attribute;

                    //CategoryAttributePairControllerProxy caProxy = new CategoryAttributePairControllerProxy();
                    //var caModel = new CategoryAttributePairModel()
                    //{
                    //    AttributeID = attributeNewId.Value,
                    //    CategoryID = categoryId
                    //};
                    //int? caNewId = caProxy.Put(caModel);
                    //if (caNewId.HasValue)
                    //{
                    //    caModel.AttributeTitle = model.AttributeTitle;
                    //    caModel.CategoryAttributePairID = caNewId.Value;

                    //    jsonResult.Data = caModel;
                    //}
                }
                return jsonResult;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateAttributePartial(AttributeModel model, FormCollection collection)
        //{
        //  throw new Exception();
        //proxy.Put(model);
        //ProductAttributePairModel papModel = new ProductAttributePairModel();
        //papModel.ProductID = Convert.ToInt32(collection["txtProductID"]?.ToString());
        //papModel.AttributeID = model.AttributeID;
        //papModel.AttributeValue = model.DefaultValue;
        //ProductAttributePairControllerProxy papProxy = new ProductAttributePairControllerProxy();
        //papProxy.Put(papModel);
        //TempData["activeTab"] = "attribute";
        //return RedirectToAction("Edit", "Product", new { id = papModel.ProductID });// ,"attribute-tab");
        //}

        //public ActionResult CreateAttribute(long Id)
        //{
        //    var dataTypeList = dataTypeProxy.GetList();
        //    ViewBag.DataTypeList = new SelectList(dataTypeList, "DataTypeID", "ClassName");

        //    var statusList = statusProxy.GetList();
        //    ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
        //    ViewBag.ID = ViewBag.ProductId;
        //    return PartialView("partial/_CreateAttribute");
        //}

        #endregion Custom Actions

    }
}
