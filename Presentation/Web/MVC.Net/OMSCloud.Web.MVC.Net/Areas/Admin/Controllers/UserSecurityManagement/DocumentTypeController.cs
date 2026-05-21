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
    public class DocumentTypeController : Controller
    {
        DocumentTypeControllerProxy proxy = new DocumentTypeControllerProxy();
        // GET: Admin/DocumentType
        public ActionResult Index()
        {
            return View(proxy.GetList());
        }

        // GET: Admin/DocumentType/Details/5
        public ActionResult Details(long Id)
        {
            var result = proxy.GetById(Id);
            return View(result);
        }

        // GET: Admin/DocumentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/DocumentType/Create
        [HttpPost]
        public ActionResult Create(DocumentTypeModel documentTypeModel, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                proxy.Put(documentTypeModel);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }

        // GET: Admin/DocumentType/Edit/5
        public ActionResult Edit(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/DocumentType/Edit/5
        [HttpPost]
        public ActionResult Edit(DocumentTypeModel documentTypeModel, long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                proxy.Post(documentTypeModel);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View(ex.Message.ToString());
            }
        }

        // GET: Admin/DocumentType/Delete/5
        public ActionResult Delete(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/DocumentType/Delete/5
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
