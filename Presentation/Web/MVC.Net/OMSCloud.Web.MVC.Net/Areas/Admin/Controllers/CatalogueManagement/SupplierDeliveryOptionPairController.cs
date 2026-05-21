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
    public class SupplierDeliveryOptionPairController : BaseMvcController
    {
        private SupplierDeliveryOptionPairControllerProxy proxy = new SupplierDeliveryOptionPairControllerProxy();
        private SupplierControllerProxy supplier = new SupplierControllerProxy();
        private DeliveryOptionControllerProxy deliveryOption = new DeliveryOptionControllerProxy();
        private LocationTreeControllerProxy locationTreeProxy = new LocationTreeControllerProxy();
        // GET: Admin/SupplierDeliveryOptionPair
        public ActionResult Index(long? Id)
        {
            List<SupplierDeliveryOptionPairModel> model = null;
            if (Id.HasValue)
                model = proxy.GetSupplierDeliveryOptionBySupplierId(Id.Value);
            else
                model = proxy.GetSupplierDeliveryOptionList();
            return View(model);
        }

        public ActionResult IndexPartial(long? Id)
        {
            List<SupplierDeliveryOptionPairModel> model = null;
            if (Id.HasValue)
                model = proxy.GetSupplierDeliveryOptionBySupplierId(Id.Value);
            else
                model = proxy.GetSupplierDeliveryOptionList();
            return PartialView("Partial/_Index", model);
        }

        // GET: Admin/SupplierDeliveryOptionPair/Details/5
        public ActionResult Details(int id)
        {
            var model = proxy.GetById(id);
            return View(model);
        }
        private void PrepareViewBag()
        {
            var supplierList = supplier.GetList();
            ViewBag.Supplier = new SelectList(supplierList, "SupplierID", "SupplierName");
            var deliveryOptionList = deliveryOption.GetList();
            ViewBag.DeliveryOption = new SelectList(deliveryOptionList, "DeliveryOptionID", "DeliveryOptionTitle");
            ViewBag.SurroundingCities = new SelectList(new List<LocationLookup>(), "LocationID", "LocationName");
            
        }
        // GET: Admin/SupplierDeliveryOptionPair/Create
        public ActionResult Create()
        {
            PrepareViewBag();
            return View(new SupplierDeliveryOptionPairModel());
        }

        // POST: Admin/SupplierDeliveryOptionPair/Create
        [HttpPost]
        public ActionResult Create(SupplierDeliveryOptionPairModel model,FormCollection collection)
        {
            try
            {
                var outVal = string.Empty;
                if (model.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliverSurroundingCities)
                {
                    outVal = collection["cityIDs"];
                }
                model.SurroundingCitiesIDs = outVal;
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/SupplierDeliveryOptionPair/Edit/5
        public ActionResult Edit(int id)
        {
            var model = proxy.GetSupplierDeliveryOptionById(id);
            PrepareViewBag();
            if (model.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliverSurroundingCities)
            {
                var cityList = proxy.GetSurroundingCities(model.SupplierID);
                if (!string.IsNullOrEmpty(model.SurroundingCitiesIDs))
                {
                    cityList = cityList.Where(x => ! model.SurroundingCitiesIDs.Contains(x.LocationID.ToString())).ToList();
                }
                ViewBag.SurroundingCities = new SelectList(cityList, "LocationID", "LocationName");
            }
            return View(model);
        }

        // POST: Admin/SupplierDeliveryOptionPair/Edit/5
        [HttpPost]
        public ActionResult Edit(SupplierDeliveryOptionPairModel model, FormCollection collection)
        {
            try
            {
                var outVal = string.Empty;
                if (model.DeliveryOptionID == (long)DBDeliveryOptionEnum.DeliverSurroundingCities)
                {
                    outVal = collection["cityIDs"];
                }
                model.SurroundingCitiesIDs = outVal;
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/SupplierDeliveryOptionPair/Delete/5
        public ActionResult Delete(int id)
        {
            var model = proxy.GetById(id);
            return View(model);
        }

        // POST: Admin/SupplierDeliveryOptionPair/Delete/5
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
        public PartialViewResult ShowCityList(SupplierDeliveryOptionPairModel model = null) 
        {
            if (model.SurroundingCitiesIDs != null)
            {
                var cond = model.SurroundingCitiesIDs.Split(',');
                long[] arr = new long[cond.Length];
                for (int i = 0; i < arr.Length; i++) 
                {
                    arr[i] = Convert.ToInt32(cond[i]);
                }
                var locationList = locationTreeProxy.GetList().Where(a => arr.Contains(a.LocationID))
                    .Select(m => new LocationLookup 
                    {
                        LocationID = m.LocationID,
                        LocationName = m.LocationTitle
                    });
                return PartialView("Partial/_CityList", locationList);

            }
            return PartialView("Partial/_CityList", new List<LocationLookup>());
        }
        public JsonResult GetSurroundingCities(long Id) 
        {
            var cityList = proxy.GetSurroundingCities(Id);
            return Json(new { cityList}, JsonRequestBehavior.AllowGet);
        }
    }
}
