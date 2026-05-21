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

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class CartItemController : ApiController, ICartItemController
    {
        [ReturnType(DataType = typeof(List<CartItemWithAttributesModel>))]
        public IHttpActionResult GetCartItemListByCartOrderId(long Id)//CartOrderId
        {
            return Ok<List<CartItemWithAttributesModel>>(comp.GetCartItemListByCartOrderId(Id));
        }

        [ReturnType(DataType = typeof(CartItemModel))]
        public IHttpActionResult GetCartItemById(long Id)//CartOrderId
        {
            return Ok<CartItemModel>(comp.GetCartItemById(Id));
        }

        [HttpPost]
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult AddToCartByProductId(CartItemModel cartItem)
        {
            return Ok<long?>(comp.AddToCartByProductId(cartItem));
        }

        [HttpPost]
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult AddToCartWithAttributesByProductId(CartItemWithAttributesModel cartItem)
        {
            return Ok<long?>(comp.AddToCartWithAttributesByProductId(cartItem));
        }
    }
}
