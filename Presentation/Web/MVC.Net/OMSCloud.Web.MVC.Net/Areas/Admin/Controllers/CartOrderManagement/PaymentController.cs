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
    public class PaymentController : BaseMvcController
    {
        private PaymentControllerProxy proxy = new PaymentControllerProxy();
        // GET: Admin/Payment
        public ActionResult Index()
        {
            return View(proxy.GetPaymentList());
        }

        // GET: Admin/Payment/Details/5
        public ActionResult Details(int id)
        {
            return View(proxy.GetById(id));
        }

        // GET: Admin/Payment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Payment/Create
        [HttpPost]
        public ActionResult Create(PaymentModel model, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Payment/Edit/5
        public ActionResult Edit(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/Payment/Edit/5
        [HttpPost]
        public ActionResult Edit(PaymentModel model, int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var ticks = collection["ModifiedOn.Ticks"];
                DateTime modifiedOn = new DateTime(Convert.ToInt64(ticks));
                model.ModifiedOn = modifiedOn;
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Payment/Delete/5
        public ActionResult Delete(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/Payment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                proxy.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
