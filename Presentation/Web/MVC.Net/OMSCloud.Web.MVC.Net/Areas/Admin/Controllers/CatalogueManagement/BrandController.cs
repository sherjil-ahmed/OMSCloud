using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class BrandController : BaseMvcController
    {
        private BrandControllerProxy proxy = new BrandControllerProxy();
        private StatusControllerProxy statusProxy = new StatusControllerProxy();
        public ActionResult Index()
        {
            var brandList = proxy.GetList();

            var statusList = statusProxy.GetList();

            var result = from a in brandList
                         join s in statusList on a.StatusID equals s.StatusID

                         select new BrandModel
                         {
                             BrandName = a.BrandName,
                             BrandID = a.BrandID,
                             Description = a.Description,
                             ManufacturerName = a.ManufacturerName,
                             StatusID = a.StatusID,
                             StatusName = s.StatusName,
                             ModifiedBy = a.ModifiedBy,
                             ModifiedOn = a.ModifiedOn,
                             CreatedBy = a.CreatedBy,
                             CreatedOn = a.CreatedOn,
                             IsSystem = a.IsSystem
                         };


            return View(result.ToList());
        }
        public ActionResult Details(long Id)
        {
            var brandById = proxy.GetById(Id);
            var statusList = statusProxy.GetList();
            brandById.StatusName = (from a in statusList
                                    where
                                    a.StatusID == brandById.StatusID
                                    select a.StatusName).First();
            return View(brandById);
        }
        public ActionResult Create()
        {
            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BrandModel model, FormCollection from) //FormCollection collection
        {
            try
            {
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                var statusList = statusProxy.GetList();
                ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
                return View(model);
            }
        }
        public ActionResult Edit(long Id)
        {
            var brandById = proxy.GetById(Id);
            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
            return View(brandById);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(BrandModel model, FormCollection collection)
        {
            try
            {
                model.ModifiedOn = new DateTime(Convert.ToInt64(collection["ModifiedOn.Ticks"]));
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                var statusList = statusProxy.GetList();
                ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
                return View(model);
            }
        }
        public ActionResult Delete(long Id)
        {
            var brandById = proxy.GetById(Id);
            var statusList = statusProxy.GetList();
            brandById.StatusName = (from a in statusList
                                    where
                                    a.StatusID == brandById.StatusID
                                    select a.StatusName).First();
            return View(brandById);
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
