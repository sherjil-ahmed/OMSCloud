using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System.Web.Routing;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class ProductAttributePairController : BaseMvcController
    {
        #region Data Members
        ProductAttributePairControllerProxy proxy = new ProductAttributePairControllerProxy();
        private ProductControllerProxy productProxy = new ProductControllerProxy();
        private AttributeControllerProxy attributeProxy = new AttributeControllerProxy();
        #endregion Data Members

        #region Default Actions
        // GET: Admin/ProductAttributes
        public ActionResult Index()
        {
            var productAttributePairList = proxy.GetProductAttributePairList();

            return View(productAttributePairList);
        }

        // GET: Admin/ProductAttributes/Details/5
        public ActionResult Details(long Id)
        {
            var productList = productProxy.GetList();
            var attributeList = attributeProxy.GetList();
            var productAttributePairList = proxy.GetById(Id);

            productAttributePairList.ProductName = (from c in productList
                                                    where productAttributePairList.ProductID == c.ProductID
                                                    select c.ProductTitle).First();
            productAttributePairList.AttributeName = (from a in attributeList
                                                      where productAttributePairList.AttributeID == a.AttributeID
                                                      select a.AttributeTitle).First();

            return View(productAttributePairList);
        }



        // GET: Admin/ProductAttributes/Create
        public ActionResult Create(long? Id)
        {
            PrepareViewBagForCreate(Id);

            return View();
        }

        private void PrepareViewBagForCreate(long? Id)
        {
            var productList = productProxy.GetList();
            if (Id.HasValue)
            {
                ViewBag.product = new SelectList(productList, "ProductID", "ProductTitle", Id);
                ViewBag.IsProductSticky = true;
            }
            else
            {
                ViewBag.product = new SelectList(productList, "ProductID", "ProductTitle");
                ViewBag.IsProductSticky = false;
            }
            var attributeList = attributeProxy.GetList();
            ViewBag.attribute = new SelectList(attributeList, "AttributeID", "AttributeTitle");
        }

        // POST: Admin/ProductAttributes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductAttributePairModel model, FormCollection collection)
        {
            try
            {
                proxy.Put(model);
                if (collection["chkStickyProduct"].Contains("true"))
                {
                    return Create(model.ProductID);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                PrepareViewBagForCreate(model.ProductID);
                return View(model);
            }
        }

        // GET: Admin/ProductAttributes/Edit/5
        public ActionResult Edit(long Id)
        {
            PrepareViewBag();

            return View(proxy.GetById(Id));
        }

        private void PrepareViewBag()
        {
            var productList = productProxy.GetList();
            ViewBag.product = new SelectList(productList, "ProductID", "ProductTitle");

            var attributeList = attributeProxy.GetList();
            ViewBag.attribute = new SelectList(attributeList, "AttributeID", "AttributeTitle");
        }

        // POST: Admin/ProductAttributes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductAttributePairModel model, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/ProductAttributes/Delete/5
        public ActionResult Delete(long Id)
        {
            var productList = productProxy.GetList();
            var attributeList = attributeProxy.GetList();
            var productAttributePairList = proxy.GetById(Id);

            productAttributePairList.ProductName = (from c in productList
                                                    where productAttributePairList.ProductID == c.ProductID
                                                    select c.ProductTitle).First();
            productAttributePairList.AttributeName = (from a in attributeList
                                                      where productAttributePairList.AttributeID == a.AttributeID
                                                      select a.AttributeTitle).First();

            return View(productAttributePairList);
        }

        // POST: Admin/ProductAttributes/Delete/5
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

        #endregion Default Actions

        #region Custom Actions

        public ActionResult ProductAttributeListByProductId(long Id)
        {
            //productAttributePairList
            return PartialView("Partial/_ProductAttributeListByProductId", proxy.GetListByProductID(Id));
        }

        [HttpPost]
        public JsonResult AssociateAttributeWithProduct(ProductAttributePairSaveModel model, FormCollection collection)
        {
            if (model.ProductAttributePairID <= 0)
            {
                var ProductAttributePairId = proxy.Put(model);
                if (ProductAttributePairId.HasValue)
                {
                    model.ProductAttributePairID = ProductAttributePairId.Value;
                    return Json(model);
                } 
                return Json("");
            }
            else
            {
                var success = proxy.Post(model);
                return Json(model);
            }
        }

        #endregion Custom Actions
    }
}
