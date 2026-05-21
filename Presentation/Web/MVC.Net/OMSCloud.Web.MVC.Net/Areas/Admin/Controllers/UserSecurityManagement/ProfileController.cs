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
using Microsoft.AspNet.Identity;
using OMSCloud.Web.MVC.Net.Areas.Security;
using System.Web.Routing;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class ProfileController : BaseMvcController
    {
        #region DataMember
        private ProfileControllerProxy proxy = new ProfileControllerProxy();
        //private UserControllerProxy userProxy = new UserControllerProxy();
        #endregion DataMember

        #region Default

        // GET: Admin/Profile
        public ActionResult Index()
        {
            var profileList = proxy.GetActiveProfileList();
            var userList = ApplicationUserManager.GetUsers();

            var result = from p in profileList
                         join u in userList on p.UserID equals u.Id
                         select new ProfileModel
                         {
                             ProfileID = p.ProfileID,
                             IsVerified = p.IsVerified,
                             UserName = u.UserName,
                             FirstName = p.FirstName,
                             MiddleName = p.MiddleName,
                             LastName = p.LastName,
                             FatherName = p.FatherName,
                             EMail_2FA = p.EMail_2FA,
                             SMS_2FA = p.SMS_2FA,
                             Nationality = p.Nationality,
                             UserTypeID = p.UserTypeID,
                             AdminUserTypeID = p.UserTypeID != (int)DBUserTypeEnum.Admin ? ( (p.ShopId.HasValue && p.ShopId != 0) ? DBUserTypeEnum.Seller : DBUserTypeEnum.Buyer) : DBUserTypeEnum.Admin,
                             // (DBUserTypeEnum)p.UserTypeID,
                             CreatedOn = p.CreatedOn,
                             LastLogin = u.LastModified,
                             ShopId = p.ShopId,
                             UserID = p.UserID,
                             
                         };

            return View(result);
        }

        // GET: Admin/Profile/Details/5
        public ActionResult Details(long Id)
        {
            var profileById = proxy.GetById(Id);
            profileById.UserName = ApplicationUserManager.GetUser(profileById.UserID)?.UserName;

            ViewBag.ImagePath = ConvertToWebPath(profileById.ImagePath);
            profileById.AdminUserTypeID = (DBUserTypeEnum)profileById.UserTypeID;
            return View(profileById);
        }

        // GET: Admin/Profile/Create
        public ActionResult Create()
        {
            PrepareViewBagForCreate();
            return View();
        }

        private void PrepareViewBagForCreate()
        {
            var userList = ApplicationUserManager.GetUsers();
            var profile = new ProfileControllerProxy();
            var profilelist = profile.GetList();

            var result = (from u in userList
                         where !(from p in profilelist
                                select p.UserID).Contains(u.Id)
                         select new {u.Id, u.UserName }).ToList();

            ViewBag.user = new SelectList(result, "Id", "UserName");

            ViewBag.Verify = false;
        }

        // POST: Admin/Profile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, ProfileModel model, FormCollection collection)
        {
            try
            {
                if (file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    model.ImagePath = file.FileName;// SaveFile(file, Server.MapPath("~/"), ImageRoute.Profile, model.ProfileID);
                    ViewBag.Message = "File uploaded successfully";
                }
                model.UserTypeID = (int)model.AdminUserTypeID;
                var newProfileId = proxy.Put(model);
                if (newProfileId.HasValue)
                {
                    if (file != null && !string.IsNullOrEmpty(file.FileName))
                    {
                        if (proxy.PutImageByProfileId(newProfileId.Value, file))
                        {
                            ViewBag.Message = "File uploaded successfully";
                        }
                    }
                    var list = new RouteValueDictionary();
                    list.Add("Id", newProfileId.Value);
                    var enumValue = model.PublicUserType;
                    var userId = model.UserID;

                    ApplicationUserManager.SyncUserRole(enumValue, userId);
                    PrepareViewBagForCreate();
                    return RedirectToAction("Edit", list);
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
                PrepareViewBagForCreate();
                return View(model);
            }
        }

        // GET: Admin/Profile/Edit/5
        public ActionResult Edit(long Id)
        {
            var ProfileById = proxy.GetById(Id);
            if (ProfileById == null)
            {
                return View("Index");
            }
            else
            {
                PreparViewBagForEdit(ProfileById);
                ProfileById.UserName = ApplicationUserManager.GetUser(ProfileById.UserID)?.UserName;
                return View(ProfileById);
            }
        }

        private void PreparViewBagForEdit(ProfileModel ProfileById)
        {
            ViewBag.ImagePath = ConvertToWebPath(ProfileById.ImagePath);
            ProfileById.AdminUserTypeID = (DBUserTypeEnum)ProfileById.UserTypeID;
        }

        // POST: Admin/Profile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, ProfileModel model, FormCollection collection)
        {
            try
            {
                if (file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    model.ImagePath = file.FileName;// SaveFile(file, Server.MapPath("~/"), ImageRoute.Profile, model.ProfileID);
                    ViewBag.Message = "File uploaded successfully";
                }
                model.UserTypeID = (int)model.AdminUserTypeID;
                if (proxy.Post(model))
                {
                    if (file != null && !string.IsNullOrEmpty(file.FileName))
                    {
                        proxy.PutImageByProfileId(model.ProfileID, file);
                    }
                    var enumValue = model.PublicUserType;
                    long userId = model.UserID;

                    ApplicationUserManager.SyncUserRole(enumValue, userId);
                    return RedirectToAction("Index", "Profile");
                }
                PreparViewBagForEdit(model);
                return RedirectToAction("Edit", "Profile", new { id = model.ProfileID });
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
                PreparViewBagForEdit(model);
                return RedirectToAction("Edit", "Profile", new { id = model.ProfileID });
            }
        }

        // GET: Admin/Profile/Delete/5
        public ActionResult Delete(long Id)
        {
            var profileById = proxy.GetById(Id);
            profileById.UserName = ApplicationUserManager.GetUser(profileById.UserID)?.UserName;

            ViewBag.ImagePath = ConvertToWebPath(profileById.ImagePath);
            profileById.AdminUserTypeID = (DBUserTypeEnum)profileById.UserTypeID;
            return View(profileById);
        }

        // POST: Admin/Profile/Delete/5
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
        #endregion Default

        #region ProfileByUserId

        #region Edit
        // GET: Admin/Profile/EditProfileByUserId/5
        public ActionResult EditProfileByUserId(long Id)
        {
            ViewBag.Layout = (Id == this.User.Identity.GetUserId<long>()) ? "_AuthLayout" : "_AdminLayout";
            ViewBag.AuthTitle = "Profile";
            var ProfileByUserId = proxy.GetProfileByUserId(Id);

            if (ProfileByUserId == null)
            {
                return RedirectToAction("CreateProfileByUserId", new { Id = Id });
            }
            ViewBag.ImagePath = ConvertToWebPath(ProfileByUserId.ImagePath);
            ProfileByUserId.AdminUserTypeID = (DBUserTypeEnum)ProfileByUserId.UserTypeID;
            return View(ProfileByUserId);
        }

        // POST: Admin/Profile/EditProfileByUserId/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfileByUserId(HttpPostedFileBase file, ProfileModel model, FormCollection collection)
        {
            try
            {
                model.ImagePath = SaveFile(file, Server.MapPath("~/"), ImageRoute.Profile, model.ProfileID);
                ViewBag.Message = "File uploaded successfully";
                if (proxy.Post(model))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ImagePath = ConvertToWebPath(model.ImagePath);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
                ViewBag.ImagePath = ConvertToWebPath(model.ImagePath);
                return View(model);
            }
        }
        #endregion Edit

        #region Create
        // GET: Admin/Profile/EditProfileByUserId/5
        public ActionResult CreateProfileByUserId(long Id)
        {
            ViewBag.Layout = (Id == this.User.Identity.GetUserId<long>()) ? "_AuthLayout" : "_AdminLayout";
            ViewBag.AuthTitle = "Profile";
            ProfileModel model = new ProfileModel();
            model.UserID = Id;
            return View(model);
        }

        // POST: Admin/Profile/EditProfileByUserId/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProfileByUserId(long Id, HttpPostedFileBase file, ProfileModel model, FormCollection collection)
        {
            try
            {
                model.UserID = Id;
                model.UserTypeID = (int)model.AdminUserTypeID;

                model.ImagePath = SaveFile(file, Server.MapPath("~/"), ImageRoute.Profile, model.ProfileID);
                ViewBag.Message = "File uploaded successfully";


                //model.UserTypeID = (int)model.PublicUserType;
                var newProfileId = proxy.Put(model);
                if (newProfileId.HasValue)
                {
                    var list = new RouteValueDictionary();
                    list.Add("Id", newProfileId.Value);

                    return RedirectToAction("Edit", list);
                }
                model.UserID = Id;
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message.ToString();
                model.UserID = Id;
                return View(model);
            }
        }
        #endregion Create

        public ActionResult InActiveShops()
        {
            var model = proxy.GetInactiveShopList();
            return View(model);
        }

        #endregion ProfileByUserId

        #region PartialViewAction

        private AddressControllerProxy AddressProxy = new AddressControllerProxy();
        public PartialViewResult AttachAddress(long Id)
        {
            AddressTypeControllerProxy AddressTypeProxy = new AddressTypeControllerProxy();
            LocationTreeControllerProxy LocationTreeProxy = new LocationTreeControllerProxy();
            ViewBag.AddressType = new SelectList(AddressTypeProxy.GetList(), "AddressTypeID", "AddressTypeTitle");
            ViewBag.Location = new SelectList(LocationTreeProxy.GetList(), "LocationID", "LocationTitle");

            return PartialView("Partial/_Address");
        }

        public PartialViewResult AddressList(long Id)
        {
            AddressTypeControllerProxy AddressTypeProxy = new AddressTypeControllerProxy();
            LocationTreeControllerProxy LocationTreeProxy = new LocationTreeControllerProxy();
            AddressControllerProxy AddressProxy = new AddressControllerProxy();
            ProfileControllerProxy ProfileProxy = new ProfileControllerProxy();
            var result = (from Add in AddressProxy.GetList()
                          join city in LocationTreeProxy.GetList() on Add.CityID equals city.LocationID
                          join province in LocationTreeProxy.GetList() on Add.ProvinceID equals province.LocationID
                          join ATP in AddressTypeProxy.GetList() on Add.AddressTypeID equals ATP.AddressTypeID
                          join p in ProfileProxy.GetList() on Add.ProfileID equals p.ProfileID
                          where Add.ProfileID == Id
                          select new AddressViewModel
                          {
                              AddressID = Add.AddressID,
                              AddressTypeID = Add.AddressTypeID,
                              AddressTypeName = ATP.AddressTypeTitle,
                              LocationID = Add.LocationID,
                              OperatingCityTitle = city.LocationTitle,
                              OperatingProvinceTitle = province.LocationTitle,
                              NearestLandmark = Add.NearestLandmark,
                              PlotNumber = Add.PlotNumber,
                              PostalCode = Add.PostalCode,
                              ProfileID = Add.ProfileID,
                              ProfileName = p.FirstName + p.LastName,
                              StreetNumber = Add.StreetNumber
                          }).ToList();
            return PartialView("Partial/_ListoffAddress", result);
        }
        public ActionResult GetReviewList(long Id)
        {
            ViewData["ShopID"] = Id;
            CustomerReviewControllerProxy reviewProxy = new CustomerReviewControllerProxy();
            var model = reviewProxy.GetCustomerReviewList(Id);
            return PartialView("partial/_ProfileReview", model);
        }

        [HttpPost]
        public JsonResult insertNewRecord(AddressModel model)
        {
            var AttachAddressToProfile = AddressProxy.Put(model);
            if (AttachAddressToProfile.HasValue)
            {
                var jsonresult = new JsonResult();
                jsonresult.Data = AttachAddressToProfile.Value;
                return jsonresult;
            }
            return null;
        }
        #endregion
    }
}
