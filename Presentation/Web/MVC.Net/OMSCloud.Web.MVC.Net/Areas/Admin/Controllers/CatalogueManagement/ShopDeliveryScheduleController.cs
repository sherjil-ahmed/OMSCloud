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
    public class ShopDeliveryScheduleController : Controller
    {
        ScheduleControllerProxy ScheduleProxy = new ScheduleControllerProxy();

        // GET: Admin/ShopDeliverySchedule
        public ActionResult Index(long Id = -1)
        {
            List<ScheduleDisplayModel> model = null;
            ViewData["SupplierID"] = Id;
            if (Id == -1)
            {
                model = ScheduleProxy.GetScheduleList();
            }
            else if (Id > -1)
            {
                model = ScheduleProxy.GetScheduleListBySupplierId(Id);
            }
            return View(model);
        }
        public ActionResult GetShopSchedule(long Id)
        {
            ViewData["SupplierID"] = Id;
            var model = ScheduleProxy.GetScheduleListBySupplierId(Id);
            return PartialView("partial/_Index", model);
        }
        // GET: Admin/ShopDeliverySchedule/Create
        public ActionResult Create(long Id)
        {
            PrepareViewbag();
            if (Id <= 0)
            {
                SupplierControllerProxy supplier = new SupplierControllerProxy();
                var supplierList = supplier.GetList();
                ViewBag.Supplier = new SelectList(supplierList, "SupplierID", "SupplierName");
            }
            ScheduleDisplayModel model = new ScheduleDisplayModel()
            {
                ScheduleTypeID = (int)DBScheduleTypeEnum.Weekly,
                StatusID = (int)DBStatusEnum.Active,
                ShopID = Id
            };

            return View(model);
        }

        // POST: Admin/ShopDeliverySchedule/Create
        [HttpPost]
        public ActionResult Create(ScheduleDisplayModel model, FormCollection collection)
        {
            try
            {
                if (model.ShopID == null || model.ScheduleTypeID == null)
                {
                    PrepareViewbag();
                    return View(model);
                }
                // TODO: Add insert logic here
                SetWeekDays(model);

                ScheduleProxy.Put(model);

                return RedirectToAction("Index", new { Id = model.ShopID });// model.ShopID);
            }
            catch
            {
                PrepareViewbag();
                return View(model);
            }
        }

        private static void SetWeekDays(ScheduleDisplayModel model)
        {
            model.WeekDays = model.Monday ? "Mon," : "";
            model.WeekDays += model.Tuesday ? "Tue," : "";
            model.WeekDays += model.Wednesday ? "Wed," : "";
            model.WeekDays += model.Thursday ? "Thu," : "";
            model.WeekDays += model.Friday ? "Fri," : "";
            model.WeekDays += model.Saturday ? "Sat," : "";
            model.WeekDays += model.Sunday ? "Sun" : "";
        }

        // GET: Admin/ShopDeliverySchedule/Edit/5
        public ActionResult Edit(long id)
        {
            var model = ScheduleProxy.GetScheduleById(id);
            PrepareViewbag();

            return View(model);
        }

        private void PrepareViewbag()
        {
            StatusControllerProxy statusProxy = new StatusControllerProxy();
            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
            //ViewBag.Months = new SelectList(new List<>())
            List<SelectListItem> monthEnumList = new List<SelectListItem>();

            foreach (int i in Enum.GetValues(typeof(DBMonthsEnum)))
            {
                var monthName = Enum.GetName(typeof(DBMonthsEnum), i);
                monthEnumList.Add(new SelectListItem() { Text = monthName, Value = i.ToString() });
            }
            //var months = Enum.GetNames(typeof(DBMonthsEnum)).Select(name => new SelectListItem()
            //{
            //    Text = name,
            //    Value = name
            //});
            SelectList MonthList = new SelectList(monthEnumList, "Value", "Text");

            ViewBag.monthsList = MonthList;
        }

        // POST: Admin/ShopDeliverySchedule/Edit/5
        [HttpPost]
        public ActionResult Edit(ScheduleDisplayModel model, FormCollection collection)
        {
            try
            {
                SetWeekDays(model);
                var ticks = collection["ModifiedOn.Ticks"];
                DateTime modifiedOn = new DateTime(Convert.ToInt64(ticks));
                model.ModifiedOn = modifiedOn;

                ScheduleProxy.Post(model);
                return RedirectToAction("Index", new { Id = model.ShopID });
            }
            catch
            {
                StatusControllerProxy statusProxy = new StatusControllerProxy();
                var statusList = statusProxy.GetList();
                ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
                return View(model);
            }
        }
        /*
        // GET: Admin/ShopDeliverySchedule/Details/5
        public ActionResult Details(int id)
        {
            var model = (ScheduleDisplayModel)ScheduleProxy.GetById(id);
            //var weekdays = model.WeekDays.Split(',');
            //for (int i = 0; i < weekdays.Length; i++)
            //{
            //    if (weekdays[i] == "Mon")
            //        model.Monday = true;
            //    else if (weekdays[i] == "Tue")
            //        model.Tuesday = true;
            //    else if (weekdays[i] == "Wed")
            //        model.Wednesday = true;
            //    else if (weekdays[i] == "Thu")
            //        model.Thursday = true;
            //    else if (weekdays[i] == "Fri")
            //        model.Friday = true;
            //    else if (weekdays[i] == "Sat")
            //        model.Saturday = true;
            //    else if (weekdays[i] == "Sun")
            //        model.Sunday = true;
            //}
            return View(model);
        }

        // GET: Admin/ShopDeliverySchedule/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ShopDeliverySchedule/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }*/
    }
}
