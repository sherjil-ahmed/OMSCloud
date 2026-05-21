using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class OrderStatusController : BaseMvcController
    {
        private OrderStatusControllerProxy proxy = new OrderStatusControllerProxy();

        // GET: Admin/OrderStatus
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/OrderStatus/Details/5
        public ActionResult Details(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // GET: Admin/OrderStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/OrderStatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderStatusModel model, FormCollection collection)
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

        // GET: Admin/OrderStatus/Edit/5
        public ActionResult Edit(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/OrderStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderStatusModel model, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                proxy.Post(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Admin/OrderStatus/Delete/5
        public ActionResult Delete(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/OrderStatus/Delete/5
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
