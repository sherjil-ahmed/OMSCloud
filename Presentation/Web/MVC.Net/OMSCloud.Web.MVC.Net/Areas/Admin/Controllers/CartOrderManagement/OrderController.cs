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
    public class OrderController : BaseMvcController
    {
        private OrderControllerProxy proxy = new OrderControllerProxy();
        private OrderStatusControllerProxy orderStatusProxy = new OrderStatusControllerProxy();

        #region INDEX
        // GET: Admin/CartOrder
        public ActionResult Index(long? buyerProfileId = null,
            long? shopId = null,
            long? orderStatusId = null,
            long? parentCartId = null,
            int PageNum = 1,
            int PageSize_RowCount = 50,
            string searchString = "",
            string sortOrder = "CreatedOn_desc")
        {
            ViewBag.OrderNumberSortParm = sortOrder == "OrderNumber" ? "OrderNumber_desc" : "OrderNumber";
            ViewBag.BuyerNameSortParm = sortOrder == "BuyerName" ? "BuyerName_desc" : "BuyerName";
            ViewBag.OrderStatusTitleSortParm = sortOrder == "OrderStatusTitle" ? "OrderStatusTitle_desc" : "OrderStatusTitle";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "Status_desc" : "Status";
            ViewBag.ShopNameSortParm = sortOrder == "ShopName" ? "ShopName_desc" : "ShopName";
            ViewBag.TaxTotalSortParm = sortOrder == "TaxTotal" ? "TaxTotal_desc" : "TaxTotal";
            ViewBag.PaymentTotalSortParm = sortOrder == "PaymentTotal" ? "PaymentTotal_desc" : "PaymentTotal";
            ViewBag.CreatedOn = sortOrder == "CreatedOn" ? "CreatedOn_desc" : "CreatedOn";
            ViewBag.CreatedOn = sortOrder == "ModifiedOn" ? "ModifiedOn_desc" : "ModifiedOn";

            ViewBag.CreateTtitle = "Create New Order";
            var searchRequestModel = new OrderAdminSearchModel
            {
                PageNum = PageNum,
                PageSize_RowCount = PageSize_RowCount,
                SearchString = searchString,
                SortOrder = false,
                SortBy = sortOrder,
                BuyerProfileId = buyerProfileId,
                ShopId = shopId,
                OrderStatusId = orderStatusId,
                ParentCartId = parentCartId,
                CountryId = 0,
                ProvinceId = ApplicationSession.ProvinceId < 0 ? (long?)null : ApplicationSession.ProvinceId,
                CityId = ApplicationSession.CityId < 0 ? (long?)null : ApplicationSession.CityId,
            };
            var model = proxy.GetListByPage(searchRequestModel);
            ViewBag.PageCount = model.NumberOfPages;
            ViewBag.CurrentPageIndex = PageNum;
            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;
            ViewBag.CartType = searchRequestModel.OrderStatusId;
            return View(model.OrderList);
        }

        public ActionResult GetOrderListByOrderStatus(long? Id = null) //OrderStatusId
        {
            var model = proxy.GetOrderListByOrderStatus(Id);
            return View("Index", model);
        }

        public ActionResult GetOrderListByCartId(long Id)
        {
            return View();
        }
        #endregion INDEX

        #region Create
        // GET: Admin/CartOrder/Create
        public ActionResult Create()
        {
            var rootos = orderStatusProxy.GetRootOrderStatus();
            ViewBag.rootos = rootos;
            PrepareViewBag(null, null, true);

            return View();
        }

        // GET: Admin/CartOrder/ConvertCartToOrder
        public ActionResult ConvertCartToOrder(long Id)//cartId
        {
            ConvertCartToOrders_SpParams model = new ConvertCartToOrders_SpParams();
            model.existing_CartId = Id;

            AddressControllerProxy addressProxy = new AddressControllerProxy();            
            model.AddressList = addressProxy.GetDeliveryAddressByCartId(Id);

            return View(model);
        }

        [HttpPost]
        public ActionResult ConvertCartToOrder(ConvertCartToOrders_SpParams model)
        {
            proxy.Sp_ConvertCartToOrders(model);
            return RedirectToAction("Index", "Order", new { parentCartId = model.existing_CartId}); //Should be directed to List of new Orders of the this CartId
        }

        // POST: Admin/CartOrder/Create
        [HttpPost]
        public ActionResult Create(OrderDetailModel model, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                //var ticks = collection["ModifiedOn.Ticks"];
                //var pomProxy = new PayOptionMatrixControllerProxy();
                //var pomId = pomProxy.GetIdBy(model.PayTypeId, model.PayModeId);
                //model.PayOptionMatrixId = pomId;

                //proxy.Put(model);
                //return RedirectToAction("Index");
                var newId = proxy.Put(model);
                if (newId.HasValue)
                    return RedirectToAction("Index");

                //if (model.IsOrder)
                //    return RedirectToAction("Index", new { Id = 2 });
                //else
                //    return RedirectToAction("Index", new { Id = 1 });
                else
                    return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }
        #endregion Create
        
        #region Edit
        // GET: Admin/CartOrder/Edit/5
        public ActionResult Edit(long Id)
        {
            var model = proxy.GetOrderByOrderId(Id);
            if (model == null)
                return RedirectToAction("Index");
            PrepareViewBag(model.OrderStatusId);//, model.PayTypeId);
            return View(model);
        }

        // POST: Admin/CartOrder/Edit/5
        [HttpPost]
        public ActionResult Edit(OrderDetailModel model, long Id, FormCollection collection)
        {
            //if (!ModelState.IsValid)
            //{
            //    foreach (var V in ModelState.Values)
            //    {
            //        if (V.Errors.Count > 0)
            //        {
            //            foreach (var err in V.Errors)
            //            {
            //                var msg = err.ErrorMessage;
            //                var excp = err.Exception.Message;
            //            }
            //        }
            //    }
            //}
            try
            {
                var ticks = collection["ModifiedOn.Ticks"];
                DateTime modifiedOn = new DateTime(Convert.ToInt64(ticks));
                model.ModifiedOn = modifiedOn;

                var pomProxy = new PayOptionMatrixControllerProxy();

                if (proxy.Post(model))
                {
                    return RedirectToAction("Index", new { orderStatusId = model.OrderStatusId });
                }
                else
                {
                    PrepareViewBag(model.OrderStatusId);
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                PrepareViewBag(model.OrderStatusId);
                return View(model);
            }
        }
        #endregion Edit

        #region Misc
        public JsonResult FillPayMode(int payTypeId)
        {
            var payModeProxy = new PayModeControllerProxy();
            var payModeList = payModeProxy.GetPayModeListByPayTypeId(payTypeId);
                //(from pm in 
                //                     //join pro in productProxy.GetList() on pmv.ProductID equals pro.ProductID
                //                     //where pmv.ProductID == productID
                //                     select new PayModeModel
                //                     {
                //                         PayModeID = pm.PayModeID,
                //                         PayModeTitle = pm.PayModeTitle,
                //                     }).ToList();

            return Json(payModeList, JsonRequestBehavior.AllowGet);
        }

        private void PrepareViewBag(long? OrderStatusId=null, long? payTypeId=null, bool IsForCreate = false)
        {
            ViewBag.IsCreate = IsForCreate;
            if (IsForCreate)
            {
                var profileProxy = new ProfileControllerProxy();
                var list = profileProxy.GetList();
                var profileList = (from p in list
                                   select new
                                   {
                                       ProfileID = p.ProfileID,
                                       ProfileTitle = p.FirstName + " " + p.MiddleName + " " + p.LastName
                                   }).ToList();
                ViewBag.ProfileList = new SelectList(profileList, "ProfileID", "ProfileTitle");
            }

            //var payTypeProxy = new PayTypeControllerProxy();
            //var payTypeList = payTypeProxy.GetList();
            //ViewBag.PayTypeList = new SelectList(payTypeList, "PayTypeID", "PayTypeTitle");
            //if (payTypeId.HasValue)
            //{
            //    var payModeProxy = new PayModeControllerProxy();
            //    var payModeList = payModeProxy.GetPayModeListByPayTypeId(payTypeId.Value);
            //    ViewBag.PayModeList = new SelectList(payModeList, "PayModeID", "PayModeTitle");
            //}
            if (OrderStatusId.HasValue)
            {
                var orderStatusProxy = new OrderStatusControllerProxy();
                var orderStatusList = orderStatusProxy.GetNextOrderStatusList(OrderStatusId.Value);
                ViewBag.OrderStatusList = new SelectList(orderStatusList, "OrderStatusID", "OrderStatusTitle");
                int i = 1;
                ViewBag.CurrentOrderStatusIndex = -1;//default value to be checked in java script 
                ViewBag.DefaultOrderStatusIndex = -1;//default value to be checked in java script 
                foreach (var os in orderStatusList) {
                    if (os.IsCurrent)
                        ViewBag.CurrentOrderStatusIndex = i;// os.OrderStatusID;
                    if (os.IsDefault)
                        ViewBag.DefaultOrderStatusIndex = i;// os.OrderStatusID;
                    i++;
                }
            }
            else
            {
                //var orderStatusProxy = new OrderStatusControllerProxy();
                var orderStatusList = orderStatusProxy.GetRootOrderStatus();
                ViewBag.OrderStatusList = new SelectList(orderStatusList, "OrderStatusID", "OrderStatusTitle");

            }
            var statusProxy = new StatusControllerProxy();
            var statusList = statusProxy.GetList();
            ViewBag.StatusList = new SelectList(statusList, "StatusID", "StatusName");
        }
        #endregion Misc

        #region ignore
        private ActionResult GetCartListByCartStatus(long? Id = null) //OrderStatusId
        {
            var model = proxy.GetCartListByCartStatus(Id);
            return View(model);
        }

        // GET: Admin/CartOrder/Details/5
        public ActionResult Details(long Id)
        {
            return View(proxy.GetOrderDetailByOrderId(Id));
        }
        
        // GET: Admin/CartOrder/Delete/5
        public ActionResult Delete(long Id)
        {
            return View(proxy.GetOrderDetailByOrderId(Id));
        }

        // POST: Admin/CartOrder/Delete/5
        [HttpPost]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                proxy.Delete(Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(proxy.GetOrderDetailByOrderId(Id));
            }
        }
        #endregion ignore
    }
}
