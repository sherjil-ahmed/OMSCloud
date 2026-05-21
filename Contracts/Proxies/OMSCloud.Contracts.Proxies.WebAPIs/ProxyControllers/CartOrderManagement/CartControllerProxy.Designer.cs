using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class CartControllerProxy : BaseControllerProxy//, ICartController
    {
        #region Cart
        public List<CartExtendedModel> GetCartList()
        {
            string uri = "api/Cart/GetCartList/";

            var result = WebApiClient.Get<List<CartExtendedModel>>(uri);
            return result;
        }

        public CartExtendedModel GetCartById(long Id)
        {
            string uri = "api/Cart/GetCartById/" + Id.ToString() + "";

            var result = WebApiClient.Get<CartExtendedModel>(uri);
            return result;
        }

        public CartModel GetCurrentUserCart(long ProfileId)
        {
            string uri = "api/Cart/GetCurrentUserCart/" + ProfileId.ToString() + "";

            var result = WebApiClient.Get<CartModel>(uri);
            return result;
        }
        /*
        public List<CartOrderLookupModel> GetCartLookupList(long? OrderType = null)
        {
            string uri = "api/Cart/GetCartLookupList/" + OrderType.ToString() + "";

            var result = WebApiClient.Get<List<CartOrderLookupModel>>(uri);
            return result;
        }

        public List<CartOrderComposedModel> GetOrderListByOrderStatus(long? OrderStatusId = null)
        {
            string uri = "api/Cart/GetOrderListByOrderStatus/" + OrderStatusId.ToString() + "";

            var result = WebApiClient.Get<List<CartOrderComposedModel>>(uri);
            return result;
        }

        public List<CartOrderComposedModel> GetCartListByCartStatus(long? OrderStatusId = null)
        {
            string uri = "api/Cart/GetCartListByCartStatus/" + OrderStatusId.ToString() + "";

            var result = WebApiClient.Get<List<CartOrderComposedModel>>(uri);
            return result;
        }

        public CartOrderComposedModel GetCartComposedById(Int64 Id)
        {
            string uri = "api/Cart/GetCartComposedById/" + Id.ToString() + "";

            var result = WebApiClient.Get<CartOrderComposedModel>(uri);
            return result;
        }*/
        #endregion Cart

        #region Default
        public List<CartModel> GetList()
        {
            string uri = "api/Cart/GetList";
            var result = WebApiClient.Get<List<CartModel>>(uri);
            return result;
        }
        public CartModel GetById(Int64 Id)
        {
            string uri = "api/Cart/GetById/" + Id.ToString() + "";
            var result = WebApiClient.Get<CartModel>(uri);
            return result;
        }
        public Nullable<Int64> Put(CartModel model)
        {
            string uri = "api/Cart/Put";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;
        }
        public Boolean Post(CartModel model)
        {
            string uri = "api/Cart/Post";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;
        }
        public Boolean Delete(CartModel model)
        {
            string uri = "api/Cart/Delete";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;
        }
        public Boolean Delete(Int64 Id)
        {
            string uri = "api/Cart/Delete/" + Id.ToString() + "";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;
        }
        #endregion Default
    }
}
