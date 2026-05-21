using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;


namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class CategoryTypeController : BaseMvcController
    {
        private CategoryTypeControllerProxy proxy = new CategoryTypeControllerProxy();
        private StatusControllerProxy statusProxy = new StatusControllerProxy();
        // GET: Admin/CategoryType
        public ActionResult Index()
        {
            var statusList = statusProxy.GetList();
            var categoryTypeList = proxy.GetList();

            var result = from a in categoryTypeList
                         join s in statusList on a.StatusID equals s.StatusID
                         select new CategoryTypeModel
                         {
                             CategoryTypeID = a.CategoryTypeID,
                             Title = a.Title,
                             Description = a.Description,
                             StatusID = a.StatusID,
                             StatusTitle = s.StatusName,
                             IsSystem = a.IsSystem
                         };
            return View(result.ToList());
        }

        // GET: Admin/CategoryType/Details/5
        public ActionResult Details(long Id)
        {
            var categoryTypeById = proxy.GetById(Id);
            var statusList = statusProxy.GetList();
            categoryTypeById.StatusTitle = (from s in statusList
                                            where s.StatusID == categoryTypeById.StatusID
                                            select s.StatusName).First();
            return View(categoryTypeById);
        }

        // GET: Admin/CategoryType/Create
        public ActionResult Create()
        {
            PrepareViewBag();
            return View();
        }

        private void PrepareViewBag()
        {
            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryTypeModel model)
        {
            try
            {
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }
        public ActionResult Edit(long Id)
        {
            PrepareViewBag();
            return View(proxy.GetById(Id));
        }

        // POST: Admin/CategoryType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryTypeModel model)
        {
            try
            {
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }
        public ActionResult Delete(long Id)
        {
            var categoryTypeById = proxy.GetById(Id);
            var statusList = statusProxy.GetList();
            categoryTypeById.StatusTitle = (from s in statusList
                                            where s.StatusID == categoryTypeById.StatusID
                                            select s.StatusName).First();
            return View(categoryTypeById);
        }

        // POST: Admin/CategoryType/Delete/5
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
