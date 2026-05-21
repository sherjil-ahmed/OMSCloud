using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers.Misc
{
    public class LocalizedPropertyController : BaseMvcController
    {
        private LocalizedPropertyControllerProxy proxy = new LocalizedPropertyControllerProxy();
        // GET: Admin/LocalizedProperty
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/LocalizedProperty/Details/5
        public ActionResult Details(int id)
        {
            return View(proxy.GetById(id));
        }

        // GET: Admin/LocalizedProperty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/LocalizedProperty/Create
        [HttpPost]
        public ActionResult Create(LocalizedPropertyModel model,FormCollection collection)
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

        // GET: Admin/LocalizedProperty/Edit/5
        public ActionResult Edit(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/LocalizedProperty/Edit/5
        [HttpPost]
        public ActionResult Edit(LocalizedPropertyModel model,int id, FormCollection collection)
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

        // GET: Admin/LocalizedProperty/Delete/5
        public ActionResult Delete(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/LocalizedProperty/Delete/5
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
