using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class CartItemControllerProxy : BaseControllerProxy//, ICartItemController
    {
        public List<CartItemModel> GetList()
        {
            string uri = "api/CartItem/GetList";

            var result = WebApiClient.Get<List<CartItemModel>>(uri);
            return result;

        }

        public List<CartItemWithAttributesModel> GetCartItemListByCartOrderId(long CartOrderId)
        {
            string uri = "api/CartItem/GetCartItemListByCartOrderId/" + CartOrderId.ToString() + "";

            var result = WebApiClient.Get<List<CartItemWithAttributesModel>>(uri);
            return result;

        }

        public CartItemModel GetCartItemById(long CartOrderId)
        {
            string uri = "api/CartItem/GetCartItemById/" + CartOrderId.ToString() + "";

            var result = WebApiClient.Get<CartItemModel>(uri);
            return result;

        }
        public CartItemModel GetById(Int64 Id)
        {
            string uri = "api/CartItem/GetById/" + Id.ToString() + "";

            var result = WebApiClient.Get<CartItemModel>(uri);
            return result;

        }
        public Nullable<Int64> Put(CartItemModel model)
        {
            string uri = "api/CartItem/Put";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;

        }
        public Boolean Post(CartItemModel model)
        {
            string uri = "api/CartItem/Post";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;

        }
        public Boolean Delete(CartItemModel model)
        {
            string uri = "api/CartItem/Delete";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public Boolean Delete(Int64 Id)
        {
            string uri = "api/CartItem/Delete/" + Id.ToString() + "";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
    }
}
