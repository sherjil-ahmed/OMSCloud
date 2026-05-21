using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class LocationController : BaseMvcController
    {
        private LocationTreeControllerProxy locationProxy = new LocationTreeControllerProxy();
        
        //[ChildActionOnly]
        [HttpGet]
        // GET: Admin/Location
        public PartialViewResult Index()
        {
            return PartialView();
        }
        
       
        public PartialViewResult Edit(LocationModel model)
        {
            if (model == null)
            {
                model = new LocationModel
                {
                    OperatingCityID = ApplicationSession.CityId,
                    OperatingProvinceID = ApplicationSession.ProvinceId,
                };
            }
            if (!(model.OperatingCityID <= 0))
            { 
                // case for editing exisitng record

                var locationModel = locationProxy.GetLocationTreeByLocationId(model.OperatingCityID);
                
                //var countryList = locationProxy.GetLocationList(DBLocationLevelEnum.Country);
                //ViewBag.Countries = new SelectList(countryList, "LocationID", "LocationName");

                var provinceList = locationProxy.GetLocationList(DBLocationLevelEnum.Province, locationModel.OperatingCountryID);
                ViewBag.Provinces = new SelectList(provinceList, "LocationID", "LocationName");

                var cityList = locationProxy.GetLocationList(DBLocationLevelEnum.City, locationModel.OperatingProvinceID);
                ViewBag.Cities = new SelectList(cityList, "LocationID", "LocationName");

                //var areaList = locationProxy.GetLocationList(DBLocationLevelEnum.Area, locationModel.OperatingCityID);
                //ViewBag.Areas = new SelectList(areaList, "LocationID", "LocationName");

                return PartialView("Edit", locationModel );
            }
            else 
            {
                // Case for New Record - Create
                var provinceList = locationProxy.GetLocationList(DBLocationLevelEnum.Province, 0);//LocationTree '0' is Country
                ViewBag.Provinces = new SelectList(provinceList, "LocationID", "LocationName");
                ViewBag.Cities = new SelectList(new List<LocationLookup>(), "LocationID", "LocationName");
                //ViewBag.Areas = new SelectList(new List<LocationLookup>(), "LocationID", "LocationName");
                var locationModel = new LocationModel() { OperatingCountryID = -1, OperatingProvinceID = ApplicationSession.ProvinceId, OperatingCityID = ApplicationSession.CityId };
                if (ApplicationSession.ProvinceId > 0)
                {
                    var cityList = locationProxy.GetLocationList(DBLocationLevelEnum.City, locationModel.OperatingProvinceID);
                    ViewBag.Cities = new SelectList(cityList, "LocationID", "LocationName");
                }
                return PartialView("Edit", locationModel);
            }
        }

        public PartialViewResult Details(LocationModel model) 
        {
            return PartialView(locationProxy.GetLocationTreeByLocationId(model.OperatingCityID));
        }
        public JsonResult ProvinceList(long id)
        {
            var ProvinceList = locationProxy.GetLocationList(DBLocationLevelEnum.Province, id );
            
            return Json(new { ProvinceList }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CityList(long id)
        {
            var CityList = locationProxy.GetLocationList(DBLocationLevelEnum.City, id);
            ApplicationSession.ProvinceId = id;
            ApplicationSession.CityId = -1;
            return Json(new { CityList }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AreaList(long id)
        {
            var AreaList = locationProxy.GetLocationList(DBLocationLevelEnum.Area, id);
            ApplicationSession.CityId = id;
            return Json(new { AreaList }, JsonRequestBehavior.AllowGet);
        }
    }
}