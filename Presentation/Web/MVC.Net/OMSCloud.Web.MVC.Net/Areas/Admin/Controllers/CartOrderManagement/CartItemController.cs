using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class CartItemController : BaseMvcController
    {
        private CartItemControllerProxy proxy = new CartItemControllerProxy();
        // GET: Admin/CartItem
        public ActionResult Index(long Id)//CartOrderId
        {
            ViewData["CartOrderId"] = Id;
            return View(proxy.GetCartItemListByCartOrderId(Id));
        }

        public ActionResult Create(long? Id, long? Id1)
        {
            CartItemModel model = new CartItemModel();
            model.ProductID = Id ?? 0;
            if (Id.HasValue && Id.Value != -1) //ProductId
            { // On change of Product, get other details of product and calculate Total Price etc.
                ProductControllerProxy productProxy = new ProductControllerProxy();
                var p = productProxy.GetCartItemProduct(Id.Value); //GetCartItemProductByProductId
                if (p != null)
                {
                    model.Quantity = 1;
                    var baseValue = (p.UnitPrice * model.Quantity);
                    var taxAmount = baseValue * (p.TaxRateApplied / 100);
                    var discount = 0.0;
                    if (p.IsDiscountPercentage)
                        discount = baseValue * p.DiscountValue/100;
                    else
                        discount = p.DiscountValue * model.Quantity;
                    model.ProductID = p.ProductId;
                    model.ProductTitle = p.ProductName;
                    model.UnitPrice = p.UnitPrice;
                    model.DiscountAmount = discount;
                    model.TaxRateApplied = p.TaxRateApplied;
                    model.TaxAmount = taxAmount;
                    model.ItemTotalPrice = baseValue - discount + taxAmount;
                    model.DiscountAmount = 0;
                    model.DiscountValue = p.DiscountValue;
                    model.IsDiscountPercentage = p.IsDiscountPercentage;
                    
                    model.StatusID = (int)DBStatusEnum.Active;
                }
            }
            PrepareViewBag();
            if (Id1.HasValue) //CartOrderId
            {
                model.CartOrderID = Id1.Value;
            }
            else
            {
                CartControllerProxy cartProxy = new CartControllerProxy();
                //var userId = this.User.Identity.GetUserId<long>();
                var ProfileId = ApplicationSession.Secure_ProfileId;
                long profileId = 0;
                Int64.TryParse(ProfileId, out profileId);
                var cart = cartProxy.GetCurrentUserCart(profileId);
                model.CartOrderID = cart.CartID;
            }
            

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CartItemModel model, long Id, long Id1, FormCollection collection)
        {
            try
            {
                if (model.ProductID > 0)
                    proxy.Put(model);
                return RedirectToAction("Index", new { id = model.CartOrderID });
            }
            catch (Exception ex)
            {
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/CartItem/Edit/5
        public ActionResult Edit(long id) //CartItemId
        {
            var model = proxy.GetCartItemById(id);
            if (model == null)
                return RedirectToAction("Index");
            PrepareViewBag();
            return View(model);
        }

        // POST: Admin/CartItem/Edit/5
        [HttpPost]
        public ActionResult Edit(CartItemModel model, long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var ticks = collection["ModifiedOn.Ticks"];
                DateTime modifiedOn = new DateTime(Convert.ToInt64(ticks));
                model.ModifiedOn = modifiedOn;
                proxy.Post(model);
                return RedirectToAction("Index", new { Id = model.CartOrderID });
            }
            catch
            {
                PrepareViewBag();
                return View(model);
            }
        }

        private void PrepareViewBag(bool IsForCreate = false)
        {
            //CartOrderControllerProxy cartOrderProxy = new CartOrderControllerProxy();

            //var cartOrderList = cartOrderProxy.GetCartOrderLookupList();
            //ViewBag.CartOrderList = new SelectList(cartOrderList, "CartOrderID", "CartName");

            ProductControllerProxy productProxy = new ProductControllerProxy();

            var productList = productProxy.GetLookupList();
            ViewBag.ProductList = new SelectList(productList, "ProductID", "ProductTitle");

            StatusControllerProxy statusProxy = new StatusControllerProxy();

            var statusList = statusProxy.GetList();
            ViewBag.StatusList = new SelectList(statusList, "StatusID", "StatusName");
        }

        public JsonResult GetCartItemProduct(long Id, long q)
        {
            ProductControllerProxy productProxy = new ProductControllerProxy();
            var product = productProxy.GetCartItemProduct(Id); //GetCartItemProductByProductId
            product.TaxAmount = ((product.TaxRateApplied / 100) * (product.UnitPrice * q));
            product.ItemTotalPrice = (double)((product.UnitPrice * q) + product.TaxAmount - product.DiscountValue);

            var jsonObject = Json(new { product }, JsonRequestBehavior.AllowGet);
            var jsonString = jsonObject.ToString();
            return jsonObject;
        }

        #region Depricated

        // GET: Admin/CartItem/Details/5
        public ActionResult Details(long id)
        {
            return View(proxy.GetById(id));
        }

        // GET: Admin/CartItem/Delete/5
        public ActionResult Delete(long Id)
        {
            return View(proxy.GetById(Id));
        }

        // POST: Admin/CartItem/Delete/5
        [HttpPost]
        public ActionResult Delete(int Id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                proxy.Delete(Id);
                return RedirectToAction("Index", new { Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/CartItem/Create
        public ActionResult CreateX(long? Id/*ProductId*/ = null, long? Id1 /*CartOrderId*/= null) 
        {
            PrepareViewBag();

            CartItemModel model = new CartItemModel();
            if (Id1.HasValue) //CartOrderId
            {
                model.CartOrderID = Id1.Value;
            }
            else
            {
                CartControllerProxy cartProxy = new CartControllerProxy();
                //var userId = this.User.Identity.GetUserId<long>();
                var ProfileId = ApplicationSession.Secure_ProfileId;
                long profileId = 0;
                Int64.TryParse(ProfileId, out profileId);
                var cart = cartProxy.GetCurrentUserCart(profileId);
                model.CartOrderID = cart.CartID;
            }
            model.Quantity = 5;
            model.StatusID = (int)DBStatusEnum.Active;
            //model.ProductID = Id.Value;
            if (Id.HasValue && Id.Value != -1) //ProductId
            { // On change of Product, get other details of product and calculate Total Price etc.
                ProductControllerProxy productProxy = new ProductControllerProxy();
                var product = productProxy.GetById(Id.Value); //GetCartItemProductByProductId
                if (product != null)
                {
                    model.ProductID = product.ProductID;
                    model.ProductTitle = product.ProductTitle;
                    model.UnitPrice = product.SellingPrice;
                    model.ItemTotalPrice = (product.SellingPrice * model.Quantity);
                    model.DiscountAmount = product.DiscountValue.HasValue ? product.DiscountValue.Value : 0;
                    model.TaxRateApplied = 0;
                    model.TaxAmount = 0;
                }
            }
            return View(model);
        }

        // POST: Admin/CartItem/Create
        [HttpPost]
        public ActionResult CreateX(CartItemModel model, long Id, long Id1, FormCollection collection)
        {
            try
            {   
                // TODO: Add insert logic here
                proxy.Put(model);
                return RedirectToAction("Index", new { Id = model.CartOrderID });
            }
            catch (Exception ex)
            {
                PrepareViewBag();
                return RedirectToAction("Create", new { Id = -1, Id1 = model.CartOrderID });
                //return View(model);
            }
        }
        #endregion Depricated
    }
}
