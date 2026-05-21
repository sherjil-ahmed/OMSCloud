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
    public class PayOptionMatrixController : BaseMvcController
    {
        private PayOptionMatrixControllerProxy proxy = new PayOptionMatrixControllerProxy(); 
        // GET: Admin/PayOptionMatrix
        public ActionResult Index()
        {
            return View(proxy.GetPayOptionMatrixList());
        }

        // GET: Admin/PayOptionMatrix/Details/5
        public ActionResult Details(int id)
        {
            return View(proxy.GetById(id));
        }

        // GET: Admin/PayOptionMatrix/Create
        public ActionResult Create()
        {
            PrepareViewBag();
            return View();
        }

        // POST: Admin/PayOptionMatrix/Create
        [HttpPost]
        public ActionResult Create(PayOptionMatrixModel model, FormCollection collection)
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

        // GET: Admin/PayOptionMatrix/Edit/5
        public ActionResult Edit(int id)
        {
            PrepareViewBag();

            return View(proxy.GetById(id));
        }

        private void PrepareViewBag()
        {
            var payTypeProxy = new PayTypeControllerProxy();
            var payTypeList = payTypeProxy.GetList();
            ViewBag.PayTypeList = new SelectList(payTypeList, "PayTypeID", "PayTypeTitle");

            var payModeProxy = new PayModeControllerProxy();
            var payModeList = payModeProxy.GetList();
            ViewBag.PayModeList = new SelectList(payModeList, "PayModeID", "PayModeTitle");
        }

        // POST: Admin/PayOptionMatrix/Edit/5
        [HttpPost]
        public ActionResult Edit(PayOptionMatrixModel model, int id, FormCollection collection)
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

        // GET: Admin/PayOptionMatrix/Delete/5
        public ActionResult Delete(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/PayOptionMatrix/Delete/5
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
