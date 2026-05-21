using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class SearchTermController : BaseMvcController
    {
        private SearchTermControllerProxy proxy = new SearchTermControllerProxy();
        // GET: Admin/SearchTerm
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/SearchTerm/Details/5
        public ActionResult Details(int id)
        {
            return View(proxy.GetById(id));
        }

        // GET: Admin/SearchTerm/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/SearchTerm/Create
        [HttpPost]
        public ActionResult Create(SearchTermModel model,FormCollection collection)
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

        // GET: Admin/SearchTerm/Edit/5
        public ActionResult Edit(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/SearchTerm/Edit/5
        [HttpPost]
        public ActionResult Edit(SearchTermModel model, int id, FormCollection collection)
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

        // GET: Admin/SearchTerm/Delete/5
        public ActionResult Delete(int id)
        {
            return View(proxy.GetById(id));
        }

        // POST: Admin/SearchTerm/Delete/5
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
