using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Business.Adapters;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Business.Core
{
    public partial class OrderBusinessComponent
    {

        public List<OrderDetailModel> GetOrderList(long? buyerProfileId = null, long? shopId = null, long? orderStatusId = null, long? parentCartId = null)
        {
            return orderAdapter.GetOrderList(buyerProfileId, shopId, orderStatusId, parentCartId);
        }

        public List<CartOrderLookupModel> GetCartOrderLookupList(long? OrderType = null)
        {
            return orderAdapter.GetCartOrderLookupList(OrderType);
        }

        public OrderDetailModel GetOrderByOrderId(long Id)
        {
            var order = orderAdapter.GetOrderByOrderId(Id);
            return order;
        }

        public OrderDetailModel GetOrderDetailByOrderId(long Id)
        {
            var order = orderAdapter.GetOrderDetailByOrderId(Id);
            if (order != null && order.ItemList != null && order.ItemList.Count > 0)
                CartBusinessComponent.UpdateExpectedDeliveryInfo(order.ItemList);
            return order;
        }

        public long GetCountByFilter(OrderAdminStatsModel statsRequestModel)
        {
            return orderAdapter.GetCountByFilter(statsRequestModel);
        }

        public OrderSearchResultAdminModel GetListByPage(OrderAdminSearchModel searchRequestModel)
        {
            return orderAdapter.GetListByPage(searchRequestModel);
        }
        public bool UpdateOrderDetail(OrderDetailModel model)
        {
            var order = model as OrderModel;
            order.DiscountTotal = 0.0;
            //order.DeliveryTotal = 0.0;
            order.TaxTotal = 0.0;
            order.OrderTotal = 0.0;
            order.PaymentTotal = 0.0;

            CartItemBusinessComponent itemComp = new CartItemBusinessComponent();
            foreach (var item in model.ItemList)
            {
                itemComp.UpdateCartItem(item);
                if (item.StatusID != (int)DBStatusEnum.Deleted)
                {
                    order.DiscountTotal += item.DiscountAmount;
                    order.TaxTotal += item.TaxAmount;
                    order.OrderTotal += item.ItemTotalPrice;
                }
            }
            order.PaymentTotal = order.OrderTotal + order.DeliveryTotal;
            //order.CalculatedPayIn = order.PaymentTotal - order.PaymentTotal * 0.05;
            //order.CalculatedPayout = order.PaymentTotal - order.PaymentTotal * 0.05;
            //order.ActualPayIn = order.CalculatedPayIn;
            //order.ActualPayout = order.CalculatedPayout;
            return orderAdapter.UpdateOrder(order);
        }
        public bool UpdateOrderStatus(OrderModel model)
        {            
            return orderAdapter.UpdateOrderStatus(model);
        }
        public bool UpdateOrderStatusAuto()
        {
            return orderAdapter.UpdateOrderStatusAuto();
        }

        public bool UpdateOrderStatus(List<long> orderList, DBOrderStatusEnum orderStatus)
        {
            return orderAdapter.UpdateOrderStatus(orderList, orderStatus);
        }
        public List<OrderDetailModel> GetCartOrderByOrderStatus(long? OrderStatusId = null, bool IsOrder = true)
        {
            return orderAdapter.GetCartOrderByOrderStatus(OrderStatusId, IsOrder);
        }
        public List<AddressViewModel> GetAddressListByCartOrderId(long CartOrderId, long? AddressTypeId = null, string AddressTypePartialName = null)
        {
            return orderAdapter.GetAddressListByCartOrderId(CartOrderId, AddressTypeId, AddressTypePartialName);
        }
        public List<AddressViewModel> GetDeliveryAddressList(long CartOrderId)
        {
            return GetAddressListByCartOrderId(CartOrderId, null, "Shipping");
        }
        public List<AddressViewModel> GetBillingAddressList(long CartOrderId)
        {
            return GetAddressListByCartOrderId(CartOrderId, null, "Billing");
        }

        public virtual List<ConvertCartToOrders_ResultModel> Sp_ConvertCartToOrders(ConvertCartToOrders_SpParams paramModel)
        {
            return orderAdapter.Sp_ConvertCartToOrders(paramModel);
        }
        public long? AddCartOrder(OrderModel CartOrder)
        {
            return orderAdapter.AddCartOrder(CartOrder);
        }
        public bool UpdateCartOrder(OrderModel CartOrder)
        {
            return orderAdapter.UpdateCartOrder(CartOrder);
        }
        public List<ChangeOrderStatusModel> GetNextOrderStatusList(long profileId, long orderId, long currentOrderStatus, short RequestedBy)
        {
            return orderAdapter.GetNextOrderStatusList(profileId, orderId, currentOrderStatus, RequestedBy);
        }
    }
}
