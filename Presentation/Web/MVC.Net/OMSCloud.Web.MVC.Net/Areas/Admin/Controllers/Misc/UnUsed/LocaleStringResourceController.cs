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
    public class LocaleStringResourceController : BaseMvcController
    {
        private LocaleStringResourceControllerProxy proxy = new LocaleStringResourceControllerProxy();
        // GET: Admin/LocaleStringResource
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/LocaleStringResource/Details/5
        public ActionResult Details(int id)
        {
            return View(proxy.GetById(id));
        }

        // GET: Admin/LocaleStringResource/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LocaleStringResource/Create
        [HttpPost]
        public ActionResult Create(LocaleStringResourceModel model,FormCollection collection)
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

        // GET: Admin/LocaleStringResource/Edit/5
        public ActionResult Edit(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/LocaleStringResource/Edit/5
        [HttpPost]
        public ActionResult Edit(LocaleStringResourceModel model,int id, FormCollection collection)
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

        // GET: Admin/LocaleStringResource/Delete/5
        public ActionResult Delete(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/LocaleStringResource/Delete/5
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
