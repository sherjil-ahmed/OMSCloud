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
    public class PayModeController : BaseMvcController
    {
        private PayModeControllerProxy proxy = new PayModeControllerProxy();
        // GET: Admin/PayMode
        public ActionResult Index()
        {
            var payModeList = proxy.GetList();

            var result = from p in payModeList
                         select new PayModeModel
                         {
                             PayModeID = p.PayModeID,
                             Description = p.Description,
                             PayModeTitle = p.PayModeTitle,
                             IsSystem = p.IsSystem

                         };
            return View(result.ToList());
        }

        // GET: Admin/PayMode/Details/5
        public ActionResult Details(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // GET: Admin/PayMode/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Admin/PayMode/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PayModeModel model, FormCollection collection)
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

        // GET: Admin/PayMode/Edit/5
        public ActionResult Edit(long Id)
        {
            return View(proxy.GetById(Id));

        }

        // POST: Admin/PayMode/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PayModeModel model, FormCollection collection)
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

        // GET: Admin/PayMode/Delete/5
        public ActionResult Delete(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/PayMode/Delete/5
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
