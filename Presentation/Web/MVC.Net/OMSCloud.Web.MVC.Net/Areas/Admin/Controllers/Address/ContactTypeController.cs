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
    public class ContactTypeController : BaseMvcController
    {
        private ContactTypeControllerProxy proxy = new ContactTypeControllerProxy();
        // GET: Admin/ContactType
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/ContactType/Details/5
        public ActionResult Details(int id)
        {
            return View(proxy.GetById(id));
        }

        // GET: Admin/ContactType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ContactType/Create
        [HttpPost]
        public ActionResult Create(ContactTypeModel model, FormCollection collection)
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

        // GET: Admin/ContactType/Edit/5
        public ActionResult Edit(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/ContactType/Edit/5
        [HttpPost]
        public ActionResult Edit(ContactTypeModel model, int id, FormCollection collection)
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

        // GET: Admin/ContactType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ContactType/Delete/5
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
