using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class ProductCategoryPairController : BaseMvcController
    {
        private ProductControllerProxy proxy = new ProductControllerProxy();

        // GET: Admin/ProductCategoryPair
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/ProductCategoryPair/Details/5
        public ActionResult Details(long Id)
        {
            return View();
        }

        // GET: Admin/ProductCategoryPair/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductCategoryPair/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ProductCategoryPair/Edit/5
        public ActionResult Edit(long Id)
        {
            return View();
        }

        // POST: Admin/ProductCategoryPair/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ProductCategoryPair/Delete/5
        public ActionResult Delete(long Id)
        {
            return View();
        }

        // POST: Admin/ProductCategoryPair/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public JsonResult AssociateCategoryWithProduct(ProductCategoryPairModel model)
        {
            try
            {
                JsonResult json = new JsonResult();
                var Id = proxy.AddProductCategoryPair(model);
                if (Id.HasValue)
                {
                    json.Data = Id.Value;
                }
                return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        [HttpGet]
        public JsonResult GetParentCategoryListByChildCategoryId(long Id) 
        {
            try
            {
                JsonResult json = new JsonResult();
                var result = proxy.GetParentCategoryListByChildCategoryId(Id);
                json.Data = result;
                return Json(new { data = result}, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
        [HttpGet]
        public JsonResult GetAllNonExistingCategoryList(ProductCategoryPairModel model) 
        {
            try
            {
                var result = proxy.GetAllNonExistingCategoryList(model);
                return Json(new { data = result }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
