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
    public class LogController : BaseMvcController
    {
        private LogControllerProxy proxy = new LogControllerProxy();
        // GET: Admin/Log
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/Log/Details/5
        public ActionResult Details(int id)
        {
            return View(proxy.GetById(id));
        }

        // GET: Admin/Log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Log/Create
        [HttpPost]
        public ActionResult Create(LogModel model,FormCollection collection)
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

        // GET: Admin/Log/Edit/5
        public ActionResult Edit(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/Log/Edit/5
        [HttpPost]
        public ActionResult Edit(LogModel model,int id, FormCollection collection)
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

        // GET: Admin/Log/Delete/5
        public ActionResult Delete(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/Log/Delete/5
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
