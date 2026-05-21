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
    public class OrderDeliveryDetailController : BaseMvcController
    {
        private OrderDeliveryDetailControllerProxy proxy = new OrderDeliveryDetailControllerProxy();
        // GET: Admin/OrderDeliveryDetail
        public ActionResult Index()
        {
            return View(proxy.GetOrderDeliveryDetailList());
        }

        // GET: Admin/OrderDeliveryDetail/Details/5
        public ActionResult Details(int id)
        {
            return View(proxy.GetOrderDeliveryDetailById(id));
        }

        // GET: Admin/OrderDeliveryDetail/Create
        public ActionResult Create(long? Id = null)
        {
            var cartOrderProxy = new OrderControllerProxy();
            var cartOrderList = cartOrderProxy.GetCartOrderLookupList();
            ViewBag.CartOrderList = new SelectList(cartOrderList, "CartOrderID", "OrderNumber");

            PrepareViewBag(Id);
            var model = new OrderDeliveryDetailModel();
            if (Id.HasValue)
                model.CartOrderID = Id.Value;
            return View(model);
        }

        // POST: Admin/OrderDeliveryDetail/Create
        [HttpPost]
        public ActionResult Create(OrderDeliveryDetailModel model,FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                proxy.Put(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/OrderDeliveryDetail/Edit/5
        public ActionResult Edit(int id)
        {
            PrepareViewBag();

            return View(proxy.GetOrderDeliveryDetailById(id));
        }
        private class ProductLookup
        {
            public long DeliveryProductID { get; set; }
            public string ProductTitle { get; set; }
        }
        private void PrepareViewBag(long? Id = null)
        {
            if (Id.HasValue) ViewBag.CartOrderId = Id;
            var p = new ProductControllerProxy();
            var dp = p.GetDeliveryProductList();
            var x = dp.Select(product => new ProductLookup { DeliveryProductID  = product.ProductID, ProductTitle = product.ProductTitle}).ToList();

            ViewBag.DeliveryProductList = new SelectList(x, "DeliveryProductID", "ProductTitle");
            var co = new OrderControllerProxy();
            var da = co.GetDeliveryAddressList(1);
            var y = da.Select(
                cartOrder => new {
                    DeliveryAddressID = cartOrder.AddressID,
                    DeliveryAddress = cartOrder.PlotNumber + cartOrder.StreetNumber + 
                                        //not available in cartOrder
                                        cartOrder.LocationName + 
                                        cartOrder.PostalCode + cartOrder.NearestLandmark
            }).ToList();
            ViewBag.DeliveryAddressList = new SelectList(y, "DeliveryAddressID", "DeliveryAddress");
        }

        // POST: Admin/OrderDeliveryDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderDeliveryDetailModel model, int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/OrderDeliveryDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View(proxy.GetOrderDeliveryDetailById(id));
        }

        // POST: Admin/OrderDeliveryDetail/Delete/5
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
    }
}
