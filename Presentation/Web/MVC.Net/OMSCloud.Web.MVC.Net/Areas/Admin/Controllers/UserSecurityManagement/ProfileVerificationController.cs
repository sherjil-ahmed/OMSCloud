using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using static OMSCloud.Contracts.Common.CommonUtilities;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.DBEnums;
//using OMSCloud.Contracts.Common.Utilities;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class ProfileVerificationController : BaseMvcController
    {
        ProfileVerificationControllerProxy proxy = new ProfileVerificationControllerProxy();
        DocumentTypeControllerProxy documentTypeProxy = new DocumentTypeControllerProxy();


        // GET: Admin/ProfileVerification
        public ActionResult Index()
        {
            var documentTypeTitle = documentTypeProxy.GetList();

            var result = (from pv in proxy.GetList()
                          join dt in documentTypeTitle on pv.DocumentTypeID equals dt.DocumentTypeID
                          select new ProfileVerificationModel
                          {
                              Comments = pv.Comments,
                              DocumentImagePath = pv.DocumentImagePath,
                              DocumentNumberByUser = pv.DocumentNumberByUser,
                              DocumentNumberByVerifier = pv.DocumentNumberByVerifier,
                              DocumentTypeID = pv.DocumentTypeID,
                              DocumentTypeTitle = dt.DocumentTypeTitle,
                              FullName = pv.FullName,
                              ProfileID = pv.ProfileID,
                              RequestedByProfileId = pv.RequestedByProfileId,
                              VerificationID = pv.VerificationID,
                              VerificationStatusID = pv.VerificationStatusID,
                              VerificationStatusTitle = pv.VerificationStatusTitle,
                              VerifiedBy = pv.VerifiedBy,
                              VerifiedOn = pv.VerifiedOn
                          }).ToList();
            return View(result);
        }

        #region AdminVerifier
        // GET: Admin/ProfileVerification/IndexAdmin
        public ActionResult IndexAdmin()
        {
            var documentTypeTitle = documentTypeProxy.GetList();
            var result = (from pv in proxy.GetListForAdmin()
                          join dt in documentTypeTitle on pv.DocumentTypeID equals dt.DocumentTypeID
                          select new ProfileVerificationModelForAdmin
                          {
                              Comments = pv.Comments,
                              DocumentImagePath = pv.DocumentImagePath,
                              DocumentNumberByVerifier = pv.DocumentNumberByVerifier,
                              DocumentTypeID = pv.DocumentTypeID,
                              DocumentTypeTitle = dt.DocumentTypeTitle,
                              FullName = pv.FullName,
                              RequestedByProfileId = pv.RequestedByProfileId,
                              VerificationID = pv.VerificationID,
                              VerificationStatus = pv.VerificationStatus,
                              VerificationStatusTitle = pv.VerificationStatusTitle,
                              Verified = pv.Verified
                          }).ToList();
            return View(result);
        }

        // GET: Admin/ProfileVerification/DetailsAdmin/5
        private ActionResult DetailsAdmin(long Id)
        {
            var result = proxy.GetById(Id);
            result.DocumentTypeTitle = (from dt in documentTypeProxy.GetList()
                                        where result.DocumentTypeID == dt.DocumentTypeID
                                        select dt.DocumentTypeTitle).First();
            return View(result);
        }

        // GET: Admin/ProfileVerification/CreateAdmin
        private ActionResult CreateAdmin()
        {
            return View();
        }

        // POST: Admin/ProfileVerification/CreateAdmin
        [HttpPost]
        [ValidateAntiForgeryToken]
        private ActionResult CreateAdmin(HttpPostedFileBase file, ProfileVerificationModelForAdmin model, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //int? id = proxy.Put(model);
                //if (Id.HasValue)
                //    return RedirectToAction("Create", id.Value);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/ProfileVerification/EditAdmin/5
        public ActionResult EditAdmin(long Id)
        {
            ViewBag.DocumentType = new SelectList(documentTypeProxy.GetList(), "DocumentTypeID", "DocumentTypeTitle");
            //ViewBag.Layout = (id == this.User.Identity.GetUserId<long>()) ? "_AuthLayout" : "_AdminLayout";
            var model = proxy.GetByIdForAdmin(Id); // GetListForAdminByProfileId(id);
            if (model == null)
            {
                return RedirectToAction("IndexAdmin");
            }
            ViewBag.DocumentImagePath = model.DocumentImagePath;
            return View(model);
        }

        // POST: Admin/ProfileVerification/EditAdmin/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAdmin(ProfileVerificationModelForAdmin model, FormCollection collection)
        {
            try
            {
                var docType = collection["DocumentTypeTitle"];
                var fullName = collection["FullName"];
                if (proxy.PostForAdmin(model))
                    return RedirectToAction("IndexAdmin");
                ViewBag.DocumentType = new SelectList(documentTypeProxy.GetList(), "DocumentTypeID", "DocumentTypeTitle");
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.DocumentType = new SelectList(documentTypeProxy.GetList(), "DocumentTypeID", "DocumentTypeTitle");
                return View(model);
            }
        }

        // GET: Admin/ProfileVerification/DeleteAdmin/5
        private ActionResult DeleteAdmin(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/ProfileVerification/DeleteAdmin/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        private ActionResult DeleteAdmin(long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                proxy.Delete(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion AdminVerifier

        #region PublicUser
        // GET: Admin/ProfileVerification/IndexPublic
        public ActionResult IndexPublic(long Id)
        {

            ViewBag.Layout = "_AdminLayout";// (Id == this.User.Identity.GetUserId<long>()) ? "_AuthLayout" : "_AdminLayout";
            ViewBag.AuthTitle = "Profile Verification";
            var publicList = (from pl in proxy.GetListForPublic(Id)
                              join dt in documentTypeProxy.GetList() on pl.DocumentTypeID equals dt.DocumentTypeID
                              select new ProfileVerificationModelForUser
                              {
                                  DocumentImagePath = pl.DocumentImagePath,
                                  DocumentNumberByUser = pl.DocumentNumberByUser,
                                  DocumentTypeID = pl.DocumentTypeID,
                                  DocumentTypeTitle = dt.DocumentTypeTitle,
                                  FullName = pl.FullName,
                                  ProfileID = pl.ProfileID,
                                  RequestedByProfileId = pl.RequestedByProfileId,
                                  VerificationID = pl.VerificationID,
                                  VerificationStatusTitle = pl.VerificationStatusTitle
                              }).ToList();
            return View(publicList);
        }

        // GET: Admin/ProfileVerification/DetailsPublic/5
        private ActionResult DetailsPublic(long Id)
        {
            ViewBag.Layout = "_AdminLayout"; //(Id == this.User.Identity.GetUserId<long>()) ? "_AuthLayout" : "_AdminLayout";
            ViewBag.AuthTitle = "Profile Verification";

            var result = proxy.GetById(Id);

            result.DocumentTypeTitle = (from dt in documentTypeProxy.GetList()
                                        where result.DocumentTypeID == dt.DocumentTypeID
                                        select dt.DocumentTypeTitle).First();

            return View(result);
        }

        // GET: Admin/ProfileVerification/CreatePublic
        public ActionResult CreatePublic(long Id)
        {
            ViewBag.Layout = "_AdminLayout";// (Id == this.User.Identity.GetUserId<long>()) ? "_AuthLayout" : "_AdminLayout";
            ViewBag.AuthTitle = "Profile Verification";
            var profileProxy = new ProfileControllerProxy();
            var profileModel = profileProxy.GetById(Id);
            //ViewBag.FullName = profileModel.FirstName + " " + profileModel.MiddleName + " " + profileModel.LastName;
            ViewBag.DocumentType = new SelectList(documentTypeProxy.GetList(), "DocumentTypeID", "DocumentTypeTitle");
            var model = new ProfileVerificationModelForUser();
            model.FullName = profileModel.FirstName + " " + profileModel.MiddleName + " " + profileModel.LastName;
            return View(model);
        }

        // POST: Admin/ProfileVerification/CreatePublic
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePublic(long Id, HttpPostedFileBase file, ProfileVerificationModelForUser model, FormCollection collection)
        {
            try
            {
                if (file != null)
                    model.DocumentImagePath = file.FileName;

                model.ProfileID = Id;
                var pv_id = proxy.PutForUser(model);
                if (pv_id.HasValue)
                {
                    if (file != null)
                    {
                        proxy.PutVerificationDocument(pv_id.Value, file);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    //return RedirectToAction("IndexPublic", new { id = model.ProfileID });
                    return RedirectToAction("EditPublic", new { Id = pv_id.Value });
                }
                return RedirectToAction("IndexPublic", new { Id = model.ProfileID });
            }
            catch(Exception ex)
            {
                return RedirectToAction("IndexPublic", new { id = model.ProfileID });
            }
        }

        // GET: Admin/ProfileVerification/EditPublic/5
        public ActionResult EditPublic(long Id)
        {
            ViewBag.DocumentType = new SelectList(documentTypeProxy.GetList(), "DocumentTypeID", "DocumentTypeTitle");
            ViewBag.Layout = "_AdminLayout"; //(Id == this.User.Identity.GetUserId<long>()) ? "_AuthLayout" : "_AdminLayout";
            ViewBag.AuthTitle = "Profile Verification";
            var model = proxy.GetById(Id);
            model.DocumentTypeTitle = (from d in documentTypeProxy.GetList()
                                       where model.DocumentTypeID == d.DocumentTypeID
                                       select d.DocumentTypeTitle).First();
            var profileProxy = new ProfileControllerProxy();
            var profileModel = profileProxy.GetById(model.ProfileID);
            if (profileModel == null)
            {
            //    return RedirectToAction("CreatePublic", new { id = Id });
            }
            ViewBag.FullName = profileModel.FirstName + " " + profileModel.MiddleName + " " + profileModel.LastName;
            ViewBag.DocumentImagePath = model.DocumentImagePath;
            var _model = new ProfileVerificationModelForUser()
            {
                VerificationID = model.VerificationID,
                ProfileID = model.ProfileID,
                FullName = ViewBag.FullName,
                DocumentTypeID = model.DocumentTypeID,
                DocumentTypeTitle = model.DocumentTypeTitle,
                DocumentNumberByUser = model.DocumentNumberByUser,
                DocumentImagePath = model.DocumentImagePath,
                VerificationStatusTitle = model.VerificationStatusTitle
            };
            return View(_model);
        }

        // POST: Admin/ProfileVerification/EditPublic/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPublic(long Id, HttpPostedFileBase file, ProfileVerificationModelForUser model, FormCollection collection)
        {
            try
            {
                if (file != null)
                    model.DocumentImagePath = file.FileName;

                var _model = new ProfileVerificationModel()
                {
                    VerificationID = model.VerificationID,
                    ProfileID = model.ProfileID,
                    FullName = ViewBag.FullName,
                    DocumentTypeID = model.DocumentTypeID,
                    DocumentTypeTitle = model.DocumentTypeTitle,
                    DocumentNumberByUser = model.DocumentNumberByUser,
                    DocumentImagePath = model.DocumentImagePath,
                    VerificationStatusTitle = model.VerificationStatusTitle
                };

                if (proxy.Post(_model))
                {
                    if (file != null)
                    {
                        proxy.PutVerificationDocument(model.VerificationID, file);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    return RedirectToAction("IndexPublic", new { id = model.ProfileID });
                }
                return RedirectToAction("EditPublic", new { id = model.VerificationID });
            }
            catch(Exception ex)
            {
                //ViewBag.DocumentImagePath = model.DocumentImagePath;
                return RedirectToAction("IndexPublic");
            }
        }

        // GET: Admin/ProfileVerification/DeletePublic/5
        private ActionResult DeletePublic(long Id)
        {
            ViewBag.Layout = "_AdminLayout";// (Id == this.User.Identity.GetUserId<long>()) ? "_AuthLayout" : "_AdminLayout";
            ViewBag.AuthTitle = "Profile Verification";
            var model = proxy.GetById(Id);
            model.DocumentTypeTitle = (from d in documentTypeProxy.GetList()
                                       where model.DocumentTypeID == d.DocumentTypeID
                                       select d.DocumentTypeTitle).First();

            return View(model);
        }

        // POST: Admin/ProfileVerification/DeletePublic/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        private ActionResult DeletePublic(long Id, FormCollection collection)
        {
            try
            {
                proxy.Delete(Id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion PublicUser
    }
}
