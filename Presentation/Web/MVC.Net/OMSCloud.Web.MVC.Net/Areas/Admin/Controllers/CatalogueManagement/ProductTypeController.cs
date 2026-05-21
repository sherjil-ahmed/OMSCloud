using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class ProductTypeController : BaseMvcController
    {
        private ProductTypeControllerProxy proxy = new ProductTypeControllerProxy();
        private StatusControllerProxy statusProxy = new StatusControllerProxy();

        // GET: Admin/ProductType
        public ActionResult Index()
        {
            var productList = proxy.GetList();
            var statusList = statusProxy.GetList();

            var result = from p in productList
                         join s in statusList on p.StatusID equals s.StatusID
                         select new ProductTypeModel
                         {
                             ProductTypeID = p.ProductTypeID,
                             ProductTypeTitle = p.ProductTypeTitle,
                             ProductTypeDescription = p.ProductTypeDescription,
                             StatusID = p.StatusID,
                             StatusName = s.StatusName
                         };
            return View(result);
        }

        // GET: Admin/ProductType/Details/5
        public ActionResult Details(long Id)
        {
            var productTypeById = proxy.GetById(Id);
            var statusList = statusProxy.GetList();
            productTypeById.StatusName = (from s in statusList
                                          where s.StatusID == productTypeById.StatusID
                                          select s.StatusName).First();
            return View(productTypeById);
        }

        // GET: Admin/ProductType/Create
        public ActionResult Create()
        {
            PrepareViewBag();
            return View();
        }

        // POST: Admin/ProductType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductTypeModel model)//FormCollection collection)
        {
            try
            {
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }
        public ActionResult Edit(long Id)
        {
            PrepareViewBag();
            return View(proxy.GetById(Id));
        }

        private void PrepareViewBag()
        {
            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
        }

        // POST: Admin/ProductType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductTypeModel model, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                model.ModifiedOn = new DateTime(Convert.ToInt64(collection["ModifiedOn.Ticks"]));
                proxy.Post(model);

                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/ProductType/Delete/5
        public ActionResult Delete(long Id)
        {
            var productTypeList = proxy.GetById(Id);
            var statusList = statusProxy.GetList();
            productTypeList.StatusName = (from s in statusList
                                          where s.StatusID == productTypeList.StatusID
                                          select s.StatusName).First();
            return View(productTypeList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            try
            {
                proxy.Delete(Id);

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}
