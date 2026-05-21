using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Common.DBEnums;
using static OMSCloud.Contracts.Common.NLogger;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class LocationTreeController : BaseMvcController
    {
        private LocationTreeControllerProxy proxyLT = new LocationTreeControllerProxy();
        private LocationLevelControllerProxy proxyLL = new LocationLevelControllerProxy();

        // GET: Admin/LocationTree
        public ActionResult Index()
        {
            var model = proxyLT.GetLocationTreeList();
            return View(model);
        }

        // GET: Admin/LocationTree/Create
        public ActionResult Create()
        {
            ViewBag.LocationLevel = new SelectList(proxyLL.GetList(), "LocationLevelID", "LocationLevelTitle");
            ViewBag.ParentLocationTree = new SelectList(proxyLT.GetList(), "LocationID", "LocationTitle");
            return View();
        }

        // POST: Admin/LocationTree/Create
        [HttpPost]
        public ActionResult Create(LocationTreeModel model, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                proxyLT.Put(model);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ErrorLog.Error(ex, "occured while Inserting new Location in LocationTree from Create Location Tree Page");
                ViewBag.LocationLevel = new SelectList(proxyLL.GetList(), "LocationLevelID", "LocationLevelTitle");
                ViewBag.ParentLocationTree = new SelectList(proxyLT.GetList(), "LocationID", "LocationTitle");
                return View(model);
            }
        }

        // GET: Admin/LocationTree/Edit/5
        public ActionResult Edit(int id)
        {
            var model = proxyLT.GetById(id);
            ViewBag.LocationLevel = new SelectList(proxyLL.GetList(), "LocationLevelID", "LocationLevelTitle");
            ViewBag.ParentLocationTree = new SelectList(proxyLT.GetList(), "LocationID", "LocationTitle");
            return View(model);
        }

        // POST: Admin/LocationTree/Edit/5
        [HttpPost]
        public ActionResult Edit(LocationTreeModel model, int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                proxyLT.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult LocationLevelList()
        {
            var model = proxyLL.GetList();
            return View(model);
        }
    }
}
