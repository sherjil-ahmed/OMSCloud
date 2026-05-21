using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;


namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class DataTypeController : BaseMvcController
    {
        private DataTypeControllerProxy proxy = new DataTypeControllerProxy();

        // GET: Admin/DataType
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/DataType/Details/5
        public ActionResult Details(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // GET: Admin/DataType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DataType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DataTypeModel model, FormCollection collection)
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

        // GET: Admin/DataType/Edit/5
        public ActionResult Edit(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/DataType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DataTypeModel model, FormCollection collection)
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

        // GET: Admin/DataType/Delete/5
        public ActionResult Delete(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/DataType/Delete/5
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
                return RedirectToAction("Index");
            }
        }
    }
}
