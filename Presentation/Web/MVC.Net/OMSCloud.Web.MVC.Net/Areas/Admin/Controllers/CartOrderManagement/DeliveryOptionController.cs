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
    public class DeliveryOptionController : BaseMvcController
    {
        private DeliveryOptionControllerProxy proxy = new DeliveryOptionControllerProxy();
        // GET: Admin/DeliveryOption
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/DeliveryOption/Details/5
        public ActionResult Details(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // GET: Admin/DeliveryOption/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DeliveryOption/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeliveryOptionModel model, FormCollection collection)
        {
            try
            {
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Admin/DeliveryOption/Edit/5
        public ActionResult Edit(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/DeliveryOption/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DeliveryOptionModel model, FormCollection collection)
        {
            try
            {
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Admin/DeliveryOption/Delete/5
        public ActionResult Delete(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/DeliveryOption/Delete/5
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
                return View();
            }
        }
    }
}
