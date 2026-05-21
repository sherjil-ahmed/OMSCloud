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
    public class AppConfigController : BaseMvcController
    {
        private AppConfigControllerProxy proxy = new AppConfigControllerProxy();
        // GET: Admin/AppConfig
        public ActionResult Index()
        {
            var appConfigList = proxy.GetList();
            //var appConfigParentList = proxy.GetList();

            var result = (from a1 in appConfigList
                          join a2 in appConfigList on a1.ParentConfigID equals a2.ConfigID into ax
                          from a2 in ax.DefaultIfEmpty()
                          select new AppConfigModel
                          {
                              ConfigID = a1.ConfigID,
                              ConfigTitle = a1.ConfigTitle,
                              ConfigValue = a1.ConfigValue,
                              Description = a1.Description,
                              DisplayText = a1.DisplayText,
                              ParentConfigID = a1.ParentConfigID,
                              ParentConfigTitle = a2?.ConfigTitle,
                              IsSystem = a1.IsSystem
                          });
            return View(result.ToList());
        }

        // GET: Admin/AppConfig/Details/5
        public ActionResult Details(long Id)
        {

            return View(proxy.GetById(Id));
        }

        // GET: Admin/AppConfig/Create
        public ActionResult Create()
        {
            var appConfigList = proxy.GetList();
            ViewBag.appConfig = new SelectList(appConfigList, "ConfigID", "ConfigTitle");
            return View();
        }

        // POST: Admin/AppConfig/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppConfigModel model, FormCollection collection)
        {
            try
            {
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                var appConfigList = proxy.GetList();
                ViewBag.appConfig = new SelectList(appConfigList, "ConfigID", "ConfigTitle");
                return View(model);
            }
        }

        // GET: Admin/AppConfig/Edit/5
        public ActionResult Edit(long Id)
        {
            var appConfigList = proxy.GetList();
            ViewBag.appConfig = new SelectList(appConfigList, "ConfigID", "ConfigTitle");
            return View(proxy.GetById(Id));
        }

        // POST: Admin/AppConfig/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppConfigModel model, FormCollection collection)
        {
            try
            {
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                var appConfigList = proxy.GetList();
                ViewBag.appConfig = new SelectList(appConfigList, "ConfigID", "ConfigTitle");
                return View(model);
            }
        }

        // GET: Admin/AppConfig/Delete/5
        public ActionResult Delete(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/AppConfig/Delete/5
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
