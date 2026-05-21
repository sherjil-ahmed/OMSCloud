using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class InvoiceController : BaseMvcController
    {
        // GET: Admin/Invoice
        public ActionResult Index(long Id)
        {
            var itemProxy = new CartItemControllerProxy();
            var cartOrderProxy = new OrderControllerProxy();
            var addressProxy = new AddressControllerProxy();
            var paymentProxy = new PaymentControllerProxy();

            var cartOrder = cartOrderProxy.GetOrderDetailByOrderId(Id);
        
            var model = new OrderDetailModel()
            {
                AddressList = addressProxy.GetList(),
                ItemList = itemProxy.GetCartItemListByCartOrderId(Id),
                //PaymentList = new List<OrderPaymentModel>(),
                PaymentList = paymentProxy.GetList(),
                OrderID = cartOrder.OrderID,
                OrderNumber = cartOrder.OrderNumber,
                //IsOrder = c.IsOrder,
                //IsPaid = c.IsPaid,
                OrderStatusId = cartOrder.OrderStatusId,
                OrderStatusTitle = cartOrder.OrderStatusTitle,
                //PayModeId = c.PayModeId,
                //PayModeTitle = c.PayModeTitle,
                //PayTypeId = c.PayTypeId,
                //PayTypeTitle = c.PayTypeTitle,
                BuyerProfileID = cartOrder.BuyerProfileID,
                StatusId = cartOrder.StatusId,
                StatusTitle = cartOrder.StatusTitle,
                //SubTotal_ExclTax = c.SubTotal_ExclTax,
                TaxTotal = cartOrder.TaxTotal,
                //Total_InclTax = c.Total_InclTax,
                BuyerName = cartOrder.BuyerName,
                RequestedByProfileId = cartOrder.RequestedByProfileId,
            };
            return View(model);
        }
    }
}


/*
new List<CartItemModel>() {
    new CartItemModel(){
        CartItemID = 1,
        CartOrderID = 1,
        CartOrderTitle = "dummy cart",
        ProductID = 1,
        ProductTitle = "Product 1",
        ItemTotalPrice = 100,
        Quantity = 2,
        StatusID = 1,
        StatusTitle = "Active",
        CreatedBy = 1,
        CreatedOn = DateTime.Now,
        ModifiedBy = 1,
        ModifiedOn = DateTime.Now,
        RequestedByProfileId = 1
    },
    new CartItemModel(){
        CartItemID = 2,
        CartOrderID = 1,
        CartOrderTitle = "dummy cart",
        ProductID = 2,
        ProductTitle = "Product 2",
        ItemTotalPrice = 162,
        Quantity = 3,
        StatusID = 1,
        StatusTitle = "Active",
        CreatedBy = 1,
        CreatedOn = DateTime.Now,
        ModifiedBy = 1,
        ModifiedOn = DateTime.Now,
        RequestedByProfileId = 1
    },
    new CartItemModel(){
        CartItemID = 3,
        CartOrderID = 1,
        CartOrderTitle = "dummy cart",
        ProductID = 3,
        ProductTitle = "Product 3",
        ItemTotalPrice = 79,
        Quantity = 6,
        StatusID = 1,
        StatusTitle = "Active",
        CreatedBy = 1,
        CreatedOn = DateTime.Now,
        ModifiedBy = 1,
        ModifiedOn = DateTime.Now,
        RequestedByProfileId = 1
    },
},
*/
