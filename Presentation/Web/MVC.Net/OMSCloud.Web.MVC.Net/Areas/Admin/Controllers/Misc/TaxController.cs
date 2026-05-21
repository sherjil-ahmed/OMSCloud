using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class TaxController : BaseMvcController
    {
        #region DataMemeber
        private TaxControllerProxy proxy = new TaxControllerProxy();
        private TaxTypeControllerProxy taxTypeProxy = new TaxTypeControllerProxy();
        private StatusControllerProxy statusProxy = new StatusControllerProxy();
        private LocationLevelControllerProxy locationLevelProxy = new LocationLevelControllerProxy();
        private LocationTreeControllerProxy locationProxy = new LocationTreeControllerProxy();
        #endregion DataMemeber

        // GET: Admin/Tax
        public ActionResult Index()
        {
            var statusList = statusProxy.GetList();
            var taxTypeList = taxTypeProxy.GetList();
            var taxList = proxy.GetList();
            var locationLevelList = locationLevelProxy.GetList();
            var locationList = locationProxy.GetList();

            var result = from t in taxList
                         join tt in taxTypeList on t.TaxTypeID equals tt.TaxTypeID
                         join s in statusList on t.StatusID equals s.StatusID
                         join ll in locationLevelList on t.LocationLevelId equals ll.LocationLevelID
                         join l in locationList on t.LocationId equals l.LocationID
                         select new TaxViewModel
                         {
                             TaxID = t.TaxID,
                             TaxValue = t.TaxValue,
                             Description = t.Description,
                             StatusID = t.StatusID,
                             StatusTitle = s.StatusName,
                             TaxTypeID = t.TaxTypeID,
                             TaxTypeTitle = tt.TaxTypeTitle,
                             EffectiveDate = t.EffectiveDate,
                             IsPercentage = t.IsPercentage,
                             TaxTerritoryLevel = ll.LocationLevelTitle,
                             LocationName = l.LocationTitle,
                         };
            return View(result.ToList());
        }

        #region Create
        // GET: Admin/Tax/Create
        public ActionResult Create()
        {
            var model = new TaxViewModel()
            {
                LocationName = ApplicationSession.Country,
                LocationLevelId = 1,
                IsPercentage = true,
            };
            PrepareViewBagForCreate();
            return View(model);
        }

        // POST: Admin/Tax/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaxViewModel model, FormCollection collection)
        {
            try
            {
                TaxModel taxModel = new TaxModel()
                {
                    TaxValue = model.TaxValue,
                    TaxTypeID = model.TaxTypeID,
                    Description = model.Description,
                    StatusID = model.StatusID,
                    IsPercentage = model.IsPercentage,
                    LocationId = model.LocationLevelId == 2 ? model.LocationID : 0,
                    LocationLevelId = model.LocationLevelId,
                    EffectiveDate = model.EffectiveDate,
                };
                proxy.Put(taxModel);

                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBagForCreate();
                return View(model);
            }
        }

        private void PrepareViewBagForCreate()
        {
            var taxTypeList = taxTypeProxy.GetList();
            ViewBag.taxType = new SelectList(taxTypeList, "TaxTypeID", "TaxTypeTitle");

            var provinceList = locationProxy.GetLocationListByParentName(DBLocationLevelEnum.Province, ApplicationSession.Country);
            ViewBag.ProvinceList = new SelectList(provinceList, "LocationID", "LocationName");

            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
        }
        #endregion Create

        #region EDIT
        // GET: Admin/Tax/Edit/5
        public ActionResult Edit(long Id)
        {
            PrepareViewBagForEdit();

            var model = GetTaxViewModelById(Id);
            model.LocationName = ApplicationSession.Country;
            return View(model);
        }

        // POST: Admin/Tax/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaxViewModel model, FormCollection collection)
        {

            var ticks = collection["ModifiedOn.Ticks"];
            DateTime ModifiedOn = new DateTime(Convert.ToInt64(ticks));
            model.ModifiedOn = ModifiedOn;
            if (model.LocationLevelId == 1)
            {
                model.LocationID = 0;
            }
            try
            {
                // TODO: Add update logic here
                proxy.Post(GetTaxModel(model));

                return RedirectToAction("Index");
            }
            catch
            {
                PrepareViewBagForEdit();
                return View(model);
            }
        }

        private TaxViewModel GetTaxViewModelById(long Id)
        {
            var entityModel = proxy.GetById(Id);
            return new TaxViewModel()
            {
                TaxID = entityModel.TaxID,
                TaxValue = entityModel.TaxValue,
                TaxTypeID = entityModel.TaxTypeID,
                IsPercentage = entityModel.IsPercentage,
                EffectiveDate = entityModel.EffectiveDate,
                LocationLevelId = entityModel.LocationLevelId,
                LocationID = entityModel.LocationId,
                StatusID = entityModel.StatusID,
                Description = entityModel.Description,
                ModifiedOn = entityModel.ModifiedOn,
            };
        }

        private TaxModel GetTaxModel(TaxViewModel ViewModel)
        {
            return new TaxModel
            {
                TaxID = ViewModel.TaxID,
                TaxValue = ViewModel.TaxValue,
                TaxTypeID = ViewModel.TaxTypeID,
                IsPercentage = ViewModel.IsPercentage,
                EffectiveDate = ViewModel.EffectiveDate,
                LocationLevelId = ViewModel.LocationLevelId,
                LocationId = ViewModel.LocationID,
                StatusID = ViewModel.StatusID,
                Description = ViewModel.Description,
                ModifiedOn = ViewModel.ModifiedOn,
            };
        }
        private void PrepareViewBagForEdit()
        {
            var taxTypeList = taxTypeProxy.GetList();
            ViewBag.taxType = new SelectList(taxTypeList, "TaxTypeID", "TaxTypeTitle");

            var provinceList = locationProxy.GetLocationListByParentName(DBLocationLevelEnum.Province, ApplicationSession.Country);
            ViewBag.ProvinceList = new SelectList(provinceList, "LocationID", "LocationName");

            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
        }
        #endregion EDIT

        // GET: Admin/Tax/Details/5
        public ActionResult Details(long Id)
        {
            var statusList = statusProxy.GetList();
            var taxTypeList = taxTypeProxy.GetList();

            var model = GetTaxViewModelById(Id);
            model.TaxTypeTitle = (from t in taxTypeList
                                    where t.TaxTypeID == model.TaxTypeID
                                    select t.TaxTypeTitle).First();
            model.StatusTitle = (from s in statusList
                                   where s.StatusID == model.StatusID
                                   select s.StatusName).First();
            return View(model);
        }

        // GET: Admin/Tax/Delete/5
        public ActionResult Delete(long Id)
        {
            var statusList = statusProxy.GetList();
            var taxTypeList = taxTypeProxy.GetList();
            var model = GetTaxViewModelById(Id);
            model.TaxTypeTitle = (from t in taxTypeList
                                    where t.TaxTypeID == model.TaxTypeID
                                    select t.TaxTypeTitle).First();
            model.StatusTitle = (from s in statusList
                                   where s.StatusID == model.StatusID
                                   select s.StatusName).First();
            return View(model);
        }

        // POST: Admin/Tax/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
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
