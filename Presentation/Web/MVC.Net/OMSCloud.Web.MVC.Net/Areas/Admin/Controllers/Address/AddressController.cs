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
    public class AddressController : BaseMvcController
    {
        private AddressControllerProxy proxy = new AddressControllerProxy();
        private AddressTypeControllerProxy AddressTypeProxy = new AddressTypeControllerProxy();
        private ProfileControllerProxy ProfileProxy = new ProfileControllerProxy();
        private LocationTreeControllerProxy LocationTreeProxy = new LocationTreeControllerProxy();
        private StatusControllerProxy StatusProxy = new StatusControllerProxy();
        private SupplierControllerProxy SupplierProxy = new SupplierControllerProxy();
        // GET: Admin/Address
        public ActionResult Index()
        {
            //GetAddressEditable name should be change
            var result = proxy.GetAddressList();
            return View(result);
        }

        // GET: Admin/Address/Details/5
        public ActionResult Details(long Id)
        {
            try
            {
                var model = new AddressViewModel();
                var result = proxy.GetById(Id);
                model.AddressID = result.AddressID;
                model.AddressModifiedOn = result.ModifiedOn;
                model.AddressStatusID = result.StatusID;
                model.AddressTypeID = result.AddressTypeID;
                model.LocationID = result.LocationID;
                model.MapLink = result.MapLink;
                model.PlotNumber = result.PlotNumber;
                model.PostalCode = result.PostalCode;
                model.StreetNumber = result.StreetNumber;
                model.ProfileID = result.ProfileID;
                model.ProfileName = (from Por in proxy.GetList()
                                      join PF in ProfileProxy.GetList() on Por.ProfileID equals PF.ProfileID
                                      select PF.LastName).First();
                model.LocationName = (from Por in proxy.GetList()
                                       join Location in LocationTreeProxy.GetList() on Por.LocationID equals Location.LocationID
                                       select Location.LocationTitle).First();
                model.AddressTypeName = (from Por in proxy.GetList()
                                          join AddressType in AddressTypeProxy.GetList() on Por.AddressTypeID equals AddressType.AddressTypeID
                                          select AddressType.AddressTypeTitle).First();
                return View(model);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return View();

        }

        // GET: Admin/Address/Create
        public ActionResult Create()
        {
            PrepareViewBag();
            var model = new AddressViewModel();
            model.LocationID = -1;
            return View(model);
        }

        // POST: Admin/Address/Create
        [HttpPost]
        public ActionResult Create(AddressViewModel model, FormCollection collection)
        {
            try
            {
                long outVal;
                //long.TryParse(collection["OperatingCountryID"], out outVal);
                model.OperatingCountryID = 0;// outVal;
                long.TryParse(collection["OperatingProvinceID"], out outVal);
                model.OperatingProvinceID = outVal;
                long.TryParse(collection["OperatingCityID"], out outVal);
                model.OperatingCityID = outVal;
                //long.TryParse(collection["OperatingAreaID"], out outVal);
                //model.LocationID = outVal;
                var address = new AddressModel()
                {
                    AddressID = model.AddressID,
                    ProfileID = model.ProfileID,
                    AddressTypeID = model.AddressTypeID,
                    PlotNumber = model.PlotNumber,
                    StreetNumber = model.StreetNumber,
                    CountryID = model.OperatingCountryID,
                    ProvinceID = model.OperatingProvinceID,
                    CityID = model.OperatingCityID,
                    LocationID = model.OperatingCityID,
                    NearestLandmark = model.NearestLandmark,
                    PostalCode = model.PostalCode,
                    MapLink = model.MapLink,
                };

                proxy.Put(address);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/Address/Edit/5
        public ActionResult Edit(long Id)
        {
            var result = proxy.GetById(Id);
            if (result == null)
                return RedirectToAction("Index");
            PrepareViewBag();
            var model = new AddressViewModel()
            {
                AddressID = result.AddressID,
                ProfileID = result.ProfileID,
                AddressTypeID = result.AddressTypeID,
                PlotNumber = result.PlotNumber,
                StreetNumber = result.StreetNumber,
                OperatingCountryID = result.CountryID,
                OperatingProvinceID = result.ProvinceID,
                OperatingCityID = result.CityID,
                LocationID = result.LocationID,
                NearestLandmark = result.NearestLandmark,
                PostalCode = result.PostalCode,
                MapLink = result.MapLink,
                AddressStatusID = result.StatusID,
                AddressModifiedOn = result.ModifiedOn
            };

                return View(model);
        }

        private void PrepareViewBag()
        {
            var profileList = ProfileProxy.GetList();
            var list = profileList.Select(x => new { ProfileID = x.ProfileID, FullName = x.FirstName + " " + x.LastName }).ToList();
            ViewBag.profileList = new SelectList(list, "ProfileID", "FullName");

            //ViewBag.profileList = new SelectList(ProfileProxy.GetList(), "ProfileID", "FirstName");

            ViewBag.AddressType = new SelectList(AddressTypeProxy.GetList(), "AddressTypeID", "AddressTypeTitle");
            ViewBag.Location = new SelectList(LocationTreeProxy.GetList(), "LocationID", "LocationTitle");
            ViewBag.Status = new SelectList(StatusProxy.GetList(), "StatusID","StatusName");
        }

        // POST: Admin/Address/Edit/5
        [HttpPost]
        public ActionResult Edit(AddressViewModel model, FormCollection collection)
        {
            try
            {
                model.AddressModifiedOn = new DateTime(Convert.ToInt64(collection["AddressModifiedOn.Ticks"]));
                long outVal;
                //long.TryParse(collection["OperatingCountryID"], out outVal);
                model.LocationID = 0;// outVal;
                long.TryParse(collection["OperatingProvinceID"], out outVal);
                model.LocationID = outVal;
                long.TryParse(collection["OperatingCityID"], out outVal);
                model.LocationID = outVal;
                //long.TryParse(collection["OperatingAreaID"], out outVal);
                //model.LocationID = outVal;
                long.TryParse(collection["AddressStatusID"], out outVal);
                model.AddressStatusID = outVal;
                var addressModel = new AddressModel() 
                {
                    AddressID = model.AddressID,
                    ProfileID = model.ProfileID,
                    AddressTypeID = model.AddressTypeID,
                    PlotNumber = model.PlotNumber,
                    StreetNumber = model.StreetNumber,
                    CountryID = model.OperatingCountryID,
                    ProvinceID = model.OperatingProvinceID,
                    CityID = model.OperatingCityID,
                    LocationID = model.LocationID,
                    NearestLandmark = model.NearestLandmark,
                    PostalCode = model.PostalCode,
                    MapLink = model.MapLink,
                    StatusID = model.AddressStatusID,
                    ModifiedOn = model.AddressModifiedOn
                };
                proxy.Post(addressModel);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/Address/Delete/5
        public ActionResult Delete(long Id)
        {
            var model = new AddressViewModel();
            var result = proxy.GetById(Id);
            model.AddressID = result.AddressID;
            model.AddressModifiedOn = result.ModifiedOn;
            model.AddressStatusID = result.StatusID;
            model.AddressTypeID = result.AddressTypeID;
            model.LocationID = result.LocationID;
            model.MapLink = result.MapLink;
            model.PlotNumber = result.PlotNumber;
            model.PostalCode = result.PostalCode;
            model.StreetNumber = result.StreetNumber;
            model.ProfileID = result.ProfileID;
            model.ProfileName = (from Por in proxy.GetList()
                                 join PF in ProfileProxy.GetList() on Por.ProfileID equals PF.ProfileID
                                 select PF.LastName).First();
            model.LocationName = (from Por in proxy.GetList()
                                  join Location in LocationTreeProxy.GetList() on Por.LocationID equals Location.LocationID
                                  select Location.LocationTitle).First();
            model.AddressTypeName = (from Por in proxy.GetList()
                                     join AddressType in AddressTypeProxy.GetList() on Por.AddressTypeID equals AddressType.AddressTypeID
                                     select AddressType.AddressTypeTitle).First();
            return View(model);
        }

        // POST: Admin/Address/Delete/5
        [HttpPost]
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
