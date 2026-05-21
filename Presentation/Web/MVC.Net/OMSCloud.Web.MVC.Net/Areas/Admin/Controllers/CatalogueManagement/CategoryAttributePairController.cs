using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class CategoryAttributePairController : BaseMvcController
    {
        #region DataaMembers
        private CategoryAttributePairControllerProxy proxy = new CategoryAttributePairControllerProxy();
        private CategoryControllerProxy categoryProxy = new CategoryControllerProxy();
        private AttributeControllerProxy attributeProxy = new AttributeControllerProxy();
        #endregion DataaMembers

        #region  Default Actions
        // GET: Admin/CategoryAttributePair
        public ActionResult Index()
        {
            var categoryAttributePairList = proxy.GetCategoryAttributePairList();
            return View(categoryAttributePairList);
        }

        // GET: Admin/CategoryAttributePair/Details/5
        public ActionResult Details(long Id)
        {
            var categotyList = categoryProxy.GetList();
            var attributeList = attributeProxy.GetList();
            var categoryAttributePairList = proxy.GetById(Id);

            categoryAttributePairList.CategoryTitle = (from c in categotyList
                                                       where categoryAttributePairList.CategoryID == c.CategoryID
                                                       select c.CategoryTitle).First();
            categoryAttributePairList.AttributeTitle = (from a in attributeList
                                                        where categoryAttributePairList.AttributeID == a.AttributeID
                                                        select a.AttributeTitle).First();

            return View(categoryAttributePairList);
        }

        // GET: Admin/CategoryAttributePair/Create
        public ActionResult Create()
        {
            PrepareViewBagForCreate();
            return View();
        }

        private void PrepareViewBagForCreate()
        {
            var categotyList = categoryProxy.GetList();
            ViewBag.category = new SelectList(categotyList, "CategoryID", "CategoryTitle");

            var attributeList = attributeProxy.GetList();
            ViewBag.attribute = new SelectList(attributeList, "AttributeID", "AttributeTitle");
        }

        // POST: Admin/CategoryAttributePair/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryAttributePairModel model)//FormCollection collection)
        {
            try
            {
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBagForCreate();
                return View(model);
            }
        }

        // GET: Admin/CategoryAttributePair/Edit/5
        public ActionResult Edit(long Id)
        {
            PrepareViewBagForEdit();
            return View(proxy.GetById(Id));
        }

        private void PrepareViewBagForEdit()
        {
            var categotyList = categoryProxy.GetList();
            ViewBag.category = new SelectList(categotyList, "CategoryID", "CategoryTitle");

            var attributeList = attributeProxy.GetList();
            ViewBag.attribute = new SelectList(attributeList, "AttributeID", "AttributeTitle");
        }

        // POST: Admin/CategoryAttributePair/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryAttributePairModel model)//long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBagForEdit();
                return View(model);
            }
        }

        // GET: Admin/CategoryAttributePair/Delete/5
        public ActionResult Delete(long Id)
        {
            var categotyList = categoryProxy.GetList();
            var attributeList = attributeProxy.GetList();
            var categoryAttributePairList = proxy.GetById(Id);

            categoryAttributePairList.CategoryTitle = (from c in categotyList
                                                       where categoryAttributePairList.CategoryID == c.CategoryID
                                                       select c.CategoryTitle).First();
            categoryAttributePairList.AttributeTitle = (from a in attributeList
                                                        where categoryAttributePairList.AttributeID == a.AttributeID
                                                        select a.AttributeTitle).First();

            return View(categoryAttributePairList);
        }

        // POST: Admin/CategoryAttributePair/Delete/5
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
            catch
            {
                return RedirectToAction("Index");
            }
        }

        #endregion  Default Actions

        #region Custom Actions

        public ActionResult CategoryAttributeListByCategoryId(long Id)
        {
            //ViewBag.CategoryId = id;
            return PartialView("partial/_CategoryAttributeListByCategoryId", proxy.GetListByCategoryId(Id));
        }

        [HttpPost]
        public JsonResult AssociateAttributeWithCategory(CategoryAttributePairModel model)
        {

            var CategoryAttributePairId = proxy.Put(model);
            if (CategoryAttributePairId.HasValue)
            {
                var jsonresult = new JsonResult();
                jsonresult.Data = CategoryAttributePairId.Value;
                return jsonresult;
            }
            return null;
        }

        [HttpPost]
        public JsonResult CreateCategoryAttributePair(CategoryAttributePairModel model)
        {
            var CategoryAttributePairId = proxy.Put(model);
            if (CategoryAttributePairId.HasValue)
            {
                var jsonresult = new JsonResult();
                jsonresult.Data = CategoryAttributePairId.Value;
                return jsonresult;
            }
            return null;
        }

        #endregion Custom Actions

    }
}
