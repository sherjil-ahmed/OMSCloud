using OMSCloud.Contracts.Proxy.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.ViewModels;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class CartController : BaseMvcController
    {
        private CartControllerProxy proxy = new CartControllerProxy();
        private OrderStatusControllerProxy orderStatusProxy = new OrderStatusControllerProxy();

        // GET: Admin/Cart
        public ActionResult Index()
        {
            var model = proxy.GetCartList();
            return View(model);
        }
        public ActionResult Create()
        {
            CartModel model = new CartModel()
            {
                CartTotal = 0,
                DiscountTotal = 0,
                TaxTotal = 0
            };

            PrepareViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(CartModel model)
        {
            try
            {
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                PrepareViewBag();
                return View(model);
            }
        }

        public ActionResult Edit(long id)
        {
            var model = proxy.GetCartById(id);
            if (model == null)
                return RedirectToAction("Index");
            PrepareViewBag();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(CartModel model, FormCollection collection)
        {
            try
            {
                var ticks = collection["ModifiedOn.Ticks"];
                DateTime modifiedOn = new DateTime(Convert.ToInt64(ticks));
                model.ModifiedOn = modifiedOn;
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                PrepareViewBag();
                return View(model);
            }
        }

        private void PrepareViewBag()
        {
            var profileProxy = new ProfileControllerProxy();
            var list = profileProxy.GetList();
            var profileList = (from p in list
                               select new
                               {
                                   BuyerProfileID = p.ProfileID,
                                   ProfileTitle = p.FirstName + " " + p.MiddleName + " " + p.LastName
                               }).ToList();
            ViewBag.ProfileList = new SelectList(profileList, "BuyerProfileID", "ProfileTitle");

            var orderStatusList = orderStatusProxy.GetList();// RootOrderStatus();
            ViewBag.OrderStatusList = new SelectList(orderStatusList, "OrderStatusID", "OrderStatusTitle");
 
            var statusProxy = new StatusControllerProxy();
            var statusList = statusProxy.GetList();
            ViewBag.StatusList = new SelectList(statusList, "StatusID", "StatusName");
        }
    }
}