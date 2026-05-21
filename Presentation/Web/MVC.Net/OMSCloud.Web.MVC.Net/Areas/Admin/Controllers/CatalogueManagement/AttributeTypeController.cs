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
    public class AttributeTypeController : BaseMvcController
    {
        private AttributeTypeControllerProxy proxy = new AttributeTypeControllerProxy();
        // GET: Admin/AttributeType
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/AttributeType/Details/5
        public ActionResult Details(long Id)
        {
            var result = proxy.GetById(Id);
            return View(result);
        }

        // GET: Admin/AttributeType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AttributeType/Create
        [HttpPost]
        public ActionResult Create(AttributeTypeModel attributeTypeModel)
        {
            try
            {
                // TODO: Add insert logic here
                proxy.Put(attributeTypeModel);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }

        // GET: Admin/AttributeType/Edit/5
        public ActionResult Edit(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/AttributeType/Edit/5
        [HttpPost]
        public ActionResult Edit(AttributeTypeModel attributeTypeModel,long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                proxy.Post(attributeTypeModel);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex.Message);
            }
        }

        // GET: Admin/AttributeType/Delete/5
        public ActionResult Delete(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/AttributeType/Delete/5
        [HttpPost]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                proxy.Delete(Id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }
    }
}
