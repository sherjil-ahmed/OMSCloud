using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using OMSCloud.Business.Core;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Services.WebAPIs.Hubs;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class OrderController : ApiController, IOrderController
    {
        #region Order
        [ReturnType(DataType = typeof(List<OrderDetailModel>))]
        public IHttpActionResult GetOrderList(long? buyerProfileId = null, long? shopId = null, long? orderStatusId = null, long? parentCartId = null)
        {
            
            return Ok<List<OrderDetailModel>>(comp.GetOrderList(buyerProfileId, shopId, orderStatusId, parentCartId));
        }

        [ReturnType(DataType = typeof(List<CartOrderLookupModel>))]
        public IHttpActionResult GetCartOrderLookupList(long? Id = null)//OrderType [Cart == 1, Order == 2]
        {
            return Ok<List<CartOrderLookupModel>>(comp.GetCartOrderLookupList(Id));
        }
        
        [ReturnType(DataType = typeof(OrderDetailModel))]
        public IHttpActionResult GetOrderByOrderId(long Id)
        {
            return Ok<OrderDetailModel>(comp.GetOrderByOrderId(Id));
        }

        [ReturnType(DataType = typeof(OrderDetailModel))]
        public IHttpActionResult GetOrderDetailByOrderId(long Id)
        {
            return Ok<OrderDetailModel>(comp.GetOrderDetailByOrderId(Id));
        }

        [HttpPost]
        [ReturnType(DataType = typeof(long))]
        public IHttpActionResult GetCountByFilter(OrderAdminStatsModel statsRequestModel)
        {
            return Ok<long>(comp.GetCountByFilter(statsRequestModel));
        }

        [HttpPost]
        [ReturnType(DataType = typeof(OrderSearchResultAdminModel))]
        public IHttpActionResult GetListByPage(OrderAdminSearchModel searchRequestModel)
        {
            return Ok<OrderSearchResultAdminModel>(comp.GetListByPage(searchRequestModel));
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult UpdateOrderDetail(OrderDetailModel model)
        {
            return Ok<bool>(comp.UpdateOrderDetail(model));
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult UpdateOrderStatus(OrderModel model)
        {
            bool status = comp.UpdateOrderStatus(model);
            if(status)
                SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Order, model.OrderID);

            return Ok<bool>(status);
        }

        //public bool UpdateOrderStatus(List<long> orderList, DBOrderStatusEnum orderStatus)
        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult UpdateOrderStatus(string orderCSV, DBOrderStatusEnum orderStatus)
        {
            var ListString = orderCSV.Split(',');
            List<long> OrderListLong = new List<long>();
            foreach (var id in ListString)
            {
                long x = 0;
                Int64.TryParse(id, out x);
                OrderListLong.Add(x);
            }

            bool status = comp.UpdateOrderStatus(OrderListLong, orderStatus);
            if (status)
            {
                foreach (var id in OrderListLong)
                {
                    SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Order, id);
                }
                return Ok<bool>(status);
            }
            return Conflict();
        }

        [ReturnType(DataType = typeof(List<OrderDetailModel>))]
        public IHttpActionResult GetCartListByCartStatus(long? Id = null)//OrderStatusId
        {
            return Ok<List<OrderDetailModel>>(comp.GetCartOrderByOrderStatus(Id, false));
        }

        [ReturnType(DataType = typeof(List<OrderDetailModel>))]
        public IHttpActionResult GetOrderListByOrderStatus(long? Id = null)//OrderStatusId
        {
            return Ok<List<OrderDetailModel>>(comp.GetCartOrderByOrderStatus(Id, true));
        }

        [HttpPost]
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult Sp_ConvertCartToOrders(ConvertCartToOrders_SpParams paramModel)
        {
            var result = comp.Sp_ConvertCartToOrders(paramModel);
            if (result != null)
            {
                //foreach(ConvertCartToOrders_ResultModel model in result)
                    //SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Order, model.OrderId.Value);

                return Ok<long?>(result.Count());
            }
            else
                return Ok<long?>(0);
        }
        [ReturnType(DataType = typeof(List<ChangeOrderStatusModel>))]
        public IHttpActionResult GetNextOrderStatusList(long profileId, long orderId, long currentOrderStatus, short RequestedBy)
        {

            return Ok<List<ChangeOrderStatusModel>>(comp.GetNextOrderStatusList(profileId, orderId, currentOrderStatus, RequestedBy));
        }
        #endregion Order

        #region Address
        [ReturnType(DataType = typeof(List<AddressModel>))]
        public IHttpActionResult GetAddressListByCartOrderId(long CartOrderId, long? AddressTypeId = null, string AddressTypePartialName = null)
        {
            return Ok<List<AddressViewModel>>(comp.GetAddressListByCartOrderId(CartOrderId, AddressTypeId, AddressTypePartialName));            
        }

        [ReturnType(DataType = typeof(List<AddressModel>))]
        public IHttpActionResult GetDeliveryAddressList(long Id)
        {
            return Ok<List<AddressViewModel>>(comp.GetDeliveryAddressList(Id));
        }

        [ReturnType(DataType = typeof(List<AddressModel>))]
        public IHttpActionResult GetBillingAddressList(long CartOrderId)
        {
            return Ok<List<AddressViewModel>>(comp.GetBillingAddressList(CartOrderId));
        }
        #endregion Address
    }
}
