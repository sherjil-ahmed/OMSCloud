using static OMSCloud.Contracts.Common.CommonUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Common.DBEnums;
using System.Configuration;
using System.IO;
using OMSCloud.Contracts.Common;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class MediaContentTypeController : BaseMvcController
    {

        private MediaContentTypeControllerProxy proxy = new MediaContentTypeControllerProxy();
        // GET: Admin/MediaContentType

        #region JSON

        public ActionResult ShowMediaContentTypeList(long Id)
        {
            ViewBag.List = new SelectList(proxy.GetList(), "MediaContentTypeID", "DisplayText");

            return PartialView("partial/_AttachMediaContent");
        }
        public ActionResult ShowMediaContentTypeAddEdit(long Id)
        {
            ViewBag.List = new SelectList(proxy.GetList(), "MediaContentTypeID", "DisplayText");

            return PartialView("partial/_AttachMediaContent");
        }

        [HttpPost]
        public JsonResult CreateMediaContentDetail(MediaContentTypeModel model)
        {
            try
            {
                JsonResult json = new JsonResult();
                MediaContentTypeControllerProxy mediaContentDetail = new MediaContentTypeControllerProxy();
                var Id = mediaContentDetail.Put(model);
                if (Id.HasValue)
                {
                    json.Data = Id.Value;
                    return json;
                }
                return json;
            }
            catch
            {
                return null;
            }
        }
        #endregion


        public ActionResult Index()
        {
            var mediaContentTypeList = proxy.GetList();

            var result = from m in mediaContentTypeList
                         select new MediaContentTypeModel
                         {
                             MediaContentTypeID = m.MediaContentTypeID,
                             DisplayText = m.DisplayText,
                             HTMLContentTypeText = m.HTMLContentTypeText,
                             Description = m.Description,
                             IconPath = m.IconPath,
                             IsSystem = m.IsSystem
                         };
            return View(result.ToList());
        }

        // GET: Admin/MediaContentType/Details/5
        public ActionResult Details(long Id)
        {
            var mediaContentTypeById = proxy.GetById(Id);
            ViewBag.IconPath = ConvertToWebPath(mediaContentTypeById.IconPath);
            return View(mediaContentTypeById);
        }

        // GET: Admin/MediaContentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MediaContentType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, MediaContentTypeModel model, FormCollection collection)
        {
            try
            {
                var mediaContentTypeId = proxy.Put(model);
                if (mediaContentTypeId.HasValue)
                {
                    var modelById = proxy.GetById(mediaContentTypeId.Value);
                    modelById.IconPath = SaveFile(file, Server.MapPath("~/"), ImageRoute.MediaContentType, mediaContentTypeId.Value);
                    if (proxy.Post(modelById))
                    {
                        ViewBag.Message = "File uploaded successfully";
                        return RedirectToAction("Index");
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
                return View(model);
            }
        }

        public ActionResult Edit(long Id)
        {
            var mediaContentTypeById = proxy.GetById(Id);
            ViewBag.IconPath = ConvertToWebPath(mediaContentTypeById.IconPath);
            return View(mediaContentTypeById);
        }

        // POST: Admin/MediaContentType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, MediaContentTypeModel model, FormCollection collection)
        {

            try
            {
                model.IconPath = SaveFile(file, Server.MapPath("~/"), ImageRoute.MediaContentType, model.MediaContentTypeID);
                ViewBag.Message = "File uploaded successfully";
                if (proxy.Post(model))
                    return RedirectToAction("Index");
                else
                    return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
                return View(model);
            }
        }

        // GET: Admin/MediaContentType/Delete/5
        public ActionResult Delete(long Id)
        {
            var mediaContentTypeById = proxy.GetById(Id);
            ViewBag.IconPath = ConvertToWebPath(mediaContentTypeById.IconPath);
            return View(mediaContentTypeById);
        }

        // POST: Admin/MediaContentType/Delete/5
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
