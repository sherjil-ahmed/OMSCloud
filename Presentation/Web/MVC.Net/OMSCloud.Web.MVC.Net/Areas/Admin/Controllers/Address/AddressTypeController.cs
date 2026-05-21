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
    public class AddressTypeController : BaseMvcController
    {
        private AddressTypeControllerProxy proxy = new AddressTypeControllerProxy();
        // GET: Admin/AddressType
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/AddressType/Details/5
        public ActionResult Details(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // GET: Admin/AddressType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AddressType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressTypeModel model, FormCollection collection)
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

        // GET: Admin/AddressType/Edit/5
        public ActionResult Edit(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/AddressType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AddressTypeModel model, FormCollection collection)
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

        // GET: Admin/AddressType/Delete/5
        public ActionResult Delete(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/AddressType/Delete/5
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
