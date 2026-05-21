using System;
using System.Collections.Generic;
using System.Text;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class OrderControllerProxy : BaseControllerProxy//, IOrderController
    {
        #region CartOrder
        public List<OrderModel> GetList()
        {
            string uri = "api/Order/GetList";

            var result = WebApiClient.Get<List<OrderModel>>(uri);
            return result;

        }

        public List<OrderDetailModel> GetOrderList(long? buyerProfileId = null, long? shopId = null, long? orderStatusId = null, long? parentCartId = null)
        {
            
               var sb = new StringBuilder();
            if (buyerProfileId.HasValue) sb.Append("&buyerProfileId=" + buyerProfileId.Value);
            if (shopId.HasValue) sb.Append("&shopId=" + shopId.Value);
            if (orderStatusId.HasValue) sb.Append("&orderStatusId=" + orderStatusId.Value);
            if (parentCartId.HasValue) sb.Append("&parentCartId=" + parentCartId.Value);
            var queryStr = sb.ToString();
            if (queryStr.Length > 0 && queryStr[0] == '&')
                queryStr = queryStr.Remove(0,1);
            string uri = "api/Order/GetOrderList/?" + queryStr;
            // + profileId?.ToString() + "/" + statusId?.ToString() + "/" + orderStatusId?.ToString() + "/" + parentCartId?.ToString() + "";

            var result = WebApiClient.Get<List<OrderDetailModel>>(uri);
            return result;

        }

        public List<CartOrderLookupModel> GetCartOrderLookupList(long? OrderType = null)
        {
            string uri = "api/Order/GetCartOrderLookupList/" + OrderType.ToString() + "";

            var result = WebApiClient.Get<List<CartOrderLookupModel>>(uri);
            return result;

        }

        public List<OrderDetailModel> GetOrderListByOrderStatus(long? OrderStatusId = null)
        {
            string uri = "api/Order/GetOrderListByOrderStatus/" + OrderStatusId.ToString() + "";

            var result = WebApiClient.Get<List<OrderDetailModel>>(uri);
            return result;

        }

        public List<OrderDetailModel> GetCartListByCartStatus(long? OrderStatusId = null)
        {
            string uri = "api/Order/GetCartListByCartStatus/" + OrderStatusId.ToString() + "";

            var result = WebApiClient.Get<List<OrderDetailModel>>(uri);
            return result;

        }

        public OrderDetailModel GetOrderByOrderId(Int64 Id)
        {
            string uri = "api/Order/GetOrderByOrderId/" + Id.ToString() + "";

            var result = WebApiClient.Get<OrderDetailModel>(uri);
            return result;

        }

        public OrderDetailModel GetOrderDetailByOrderId(Int64 Id)
        { 
            string uri = "api/Order/GetOrderDetailByOrderId/" + Id.ToString() + "";

            var result = WebApiClient.Get<OrderDetailModel>(uri);
            return result;

        }

        public long GetCountByFilter(OrderAdminStatsModel statsRequestModel)
        {
            string uri = "api/Order/GetCountByFilter/";

            var result = WebApiClient.Post<long>(uri, statsRequestModel);
            return result;
        }

        public OrderSearchResultAdminModel GetListByPage(OrderAdminSearchModel searchRequestModel)
        {
            string uri = "api/Order/GetListByPage/";

            var result = WebApiClient.Post<OrderSearchResultAdminModel>(uri, searchRequestModel);
            return result;
        }

        public OrderModel GetById(Int64 Id)
        {
            string uri = "api/Order/GetById/" + Id.ToString() + "";

            var result = WebApiClient.Get<OrderModel>(uri);
            return result;

        }
        public Nullable<Int64> Put(OrderModel model)
        {
            string uri = "api/Order/Put";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;

        }
        public Boolean Post(OrderModel model)
        {
            string uri = "api/Order/Post";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;

        }
        public Boolean Delete(OrderModel model)
        {
            string uri = "api/Order/Delete";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public Boolean Delete(Int64 Id)
        {
            string uri = "api/Order/Delete/" + Id.ToString() + "";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        #endregion CartOrder

        #region Address
        public List<AddressViewModel> GetAddressListByCartOrderId(long CartOrderId, long? AddressTypeId = null, string AddressTypePartialName = null)
        {
            string uri = "api/Order/GetAddressListByCartOrderId/" + CartOrderId.ToString() + "";

            var result = WebApiClient.Get<List<AddressViewModel>>(uri);
            return result;
        }
        public List<AddressViewModel> GetDeliveryAddressList(long CartOrderId)
        {
            string uri = "api/Order/GetDeliveryAddressList/" + CartOrderId.ToString() + "";

            var result = WebApiClient.Get<List<AddressViewModel>>(uri);
            return result;
        }
        public List<AddressViewModel> GetBillingAddressList(long CartOrderId)
        {
            string uri = "api/Order/GetBillingAddressList/" + CartOrderId.ToString() + "";

            var result = WebApiClient.Get<List<AddressViewModel>>(uri);
            return result;
        }
        #endregion Address
    }
}
