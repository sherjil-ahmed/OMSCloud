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
    public class OrderPaymentController : BaseMvcController
    {
        private OrderPaymentControllerProxy proxy = new OrderPaymentControllerProxy();
        // GET: Admin/OrderPayment
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/OrderPayment/Details/5
        public ActionResult Details(int id)
        {
            return View(proxy.GetById(id));
        }

        // GET: Admin/OrderPayment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OrderPayment/Create
        [HttpPost]
        public ActionResult Create(OrderPaymentModel model,FormCollection collection)
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

        // GET: Admin/OrderPayment/Edit/5
        public ActionResult Edit(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/OrderPayment/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderPaymentModel model,int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/OrderPayment/Delete/5
        public ActionResult Delete(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/OrderPayment/Delete/5
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
