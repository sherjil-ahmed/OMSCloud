using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class PackagedProductController : BaseMvcController
    {
        private PackagedProductControllerProxy proxy = new PackagedProductControllerProxy();
        // GET: Admin/PackagedProduct
        public ActionResult Index()
        {


            return View(proxy.GetList());
        }

        // GET: Admin/PackagedProduct/Details/5
        public ActionResult Details(long Id)
        {
            return View();
        }

        // GET: Admin/PackagedProduct/Create
        public ActionResult Create()
        {
            PrepareViewBag();

            return View();
        }

        // POST: Admin/PackagedProduct/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PackagedProductModel model)//FormCollection collection)
        {
            try
            {
                var Id = proxy.Put(model);
                if (Id.HasValue)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult CreatePackagedProduct(PackagedProductModel model)
        {
            try
            {
                JsonResult json = new JsonResult();
                if (model.PackageID < 0)
                {
                    proxy.Post(model);
                }
                else
                {
                    var Id = proxy.Put(model);
                    if (Id.HasValue)
                    {
                        model.PackageID = Id.Value;
                    }
                }
                return Json(model);
            }
            catch
            {
                return null;
            }
        }




        // GET: Admin/PackagedProduct/Edit/5
        public ActionResult Edit(long Id)
        {
            PrepareViewBag();

            var model = proxy.GetById(Id);

            return View(model);
        }

        private void PrepareViewBag()
        {
            ProductControllerProxy productProxy = new ProductControllerProxy();
            var productList = productProxy.GetList();
            ViewBag.ProductList = new SelectList(productList, "ProductID", "ProductTitle");
        }


        // POST: Admin/PackagedProduct/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PackagedProductModel model)//, long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                PackagedProductControllerProxy packagedProductController = new PackagedProductControllerProxy();
                packagedProductController.Post(model);

                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/PackagedProduct/Delete/5
        public ActionResult Delete(long Id)
        {
            return View();
        }

        // POST: Admin/PackagedProduct/Delete/5
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
                return RedirectToAction("Index");
            }
        }


        public ActionResult ShowPackagedProductAddEdit(long Id)
        {
            ProductControllerProxy productProxy = new ProductControllerProxy();
            var productList = productProxy.GetList();
            ViewBag.ProductList = new SelectList(productList, "ProductID", "ProductTitle", Id);

            //PackagedProductControllerProxy packagedProductController = new PackagedProductControllerProxy();
            //var model = packagedProductController.GetById(Id);

            return PartialView("partial/_PackagedProductAddEdit");
        }
        public ActionResult ShowPackagedProductList(long Id)
        {
            PackagedProductControllerProxy packagedProductController = new PackagedProductControllerProxy();

            var model = packagedProductController.GetListByProductId(Id);
            return PartialView("partial/_PackagedProductList", model);
        }
    }
}
