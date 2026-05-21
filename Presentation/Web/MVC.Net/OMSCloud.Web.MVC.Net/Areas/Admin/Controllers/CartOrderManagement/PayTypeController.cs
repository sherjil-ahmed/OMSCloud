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
    public class PayTypeController : BaseMvcController
    {
        private PayTypeControllerProxy proxy = new PayTypeControllerProxy();
        private StatusControllerProxy statusProxy = new StatusControllerProxy();
        // GET: Admin/PayType
        public ActionResult Index()
        {
            var statusList = statusProxy.GetList();
            var payTypeList = proxy.GetList();

            var result = from p in payTypeList
                         join s in statusList on p.StatusID equals s.StatusID
                         select new PayTypeModel
                         {
                             PayTypeID = p.PayTypeID,
                             PayTypeTitle = p.PayTypeTitle,
                             Description = p.Description,
                             StatusID = p.StatusID,
                             StatusTitle = s.StatusName,
                             IsSystem = p.IsSystem
                         };
            return View(result.ToList());
        }

        // GET: Admin/PayType/Details/5
        public ActionResult Details(long Id)
        {
            var statusList = statusProxy.GetList();
            var payTypeById = proxy.GetById(Id);
            payTypeById.StatusTitle = (from s in statusList
                                       where s.StatusID == payTypeById.StatusID
                                       select s.StatusName).First();
            return View(payTypeById);
        }

        // GET: Admin/PayType/Create
        public ActionResult Create()
        {
            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
            return View();

        }

        // POST: Admin/PayType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PayTypeModel model, FormCollection collection)
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

        // GET: Admin/PayType/Edit/5
        public ActionResult Edit(long Id)
        {
            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
            return View(proxy.GetById(Id));
        }

        // POST: Admin/PayType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PayTypeModel model, FormCollection collection)
        {
            try
            {
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

        // GET: Admin/PayType/Delete/5
        public ActionResult Delete(long Id)
        {
            var statusList = statusProxy.GetList();
            var payTypeById = proxy.GetById(Id);
            payTypeById.StatusTitle = (from s in statusList
                                       where s.StatusID == payTypeById.StatusID
                                       select s.StatusName).First();
            return View(payTypeById);
        }

        // POST: Admin/PayType/Delete/5
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
