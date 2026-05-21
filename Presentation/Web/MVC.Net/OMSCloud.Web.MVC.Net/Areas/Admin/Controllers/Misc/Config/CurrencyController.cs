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
    public class CurrencyController : BaseMvcController
    {
        private CurrencyControllerProxy proxy = new CurrencyControllerProxy();

        // GET: Admin/Currency
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/Currency/Details/5
        public ActionResult Details(int id)
        {
            return View(proxy.GetById(id));
        }

        // GET: Admin/Currency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Currency/Create
        [HttpPost]
        public ActionResult Create(CurrencyModel model,FormCollection collection)
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

        // GET: Admin/Currency/Edit/5
        public ActionResult Edit(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/Currency/Edit/5
        [HttpPost]
        public ActionResult Edit(CurrencyModel model,int id, FormCollection collection)
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

        // GET: Admin/Currency/Delete/5
        public ActionResult Delete(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/Currency/Delete/5
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
