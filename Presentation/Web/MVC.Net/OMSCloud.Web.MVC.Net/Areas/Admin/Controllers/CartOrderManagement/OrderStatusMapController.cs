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
    public class OrderStatusMapController : BaseMvcController
    {
        private OrderStatusMapControllerProxy proxy = new OrderStatusMapControllerProxy();
        private OrderStatusControllerProxy orderStatusProxy = new OrderStatusControllerProxy();
        private StatusControllerProxy statusProxy = new StatusControllerProxy();
        // GET: Admin/OrderStatusMap
        public ActionResult Index()
        {
            var m = proxy.GetSortedList();
            return View(m);
        }

        // GET: Admin/OrderStatusMap/Details/5
        public ActionResult Details(int id)
        {
            return View(proxy.GetOrderStatusMapById(id));
        }

        // GET: Admin/OrderStatusMap/Create
        public ActionResult Create()
        {
            PrepareViewBag();
            return View();
        }

        // POST: Admin/OrderStatusMap/Create
        [HttpPost]
        public ActionResult Create(OrderStatusMapModel model, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }
        public void PrepareViewBag() 
        {
            ViewBag.StatusList = new SelectList(statusProxy.GetList(),"StatusID","StatusName");
            ViewBag.ParentOrderStatusList = new SelectList(orderStatusProxy.GetList(), "OrderStatusID", "OrderStatusTitle");
            ViewBag.ChildOrderStatusList = new SelectList(orderStatusProxy.GetList(), "OrderStatusID", "OrderStatusTitle");
        }
        // GET: Admin/OrderStatusMap/Edit/5
        public ActionResult Edit(int id)
        {
            PrepareViewBag();
            return View(proxy.GetById(id));
        }

        // POST: Admin/OrderStatusMap/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderStatusMapModel model, int id, FormCollection collection)
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

        // GET: Admin/OrderStatusMap/Delete/5
        public ActionResult Delete(int id)
        {
            var model = proxy.GetOrderStatusMapById(id);

            return View(model);
        }

        // POST: Admin/OrderStatusMap/Delete/5
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
