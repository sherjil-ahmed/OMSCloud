using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class CartController //: ApiController//, IOrderController
    {
        [ReturnType(DataType = typeof(CartModel))]
        public IHttpActionResult GetCurrentUserCart(long Id)//ProfileId
        {
            var model = comp.GetCurrentUserCart(Id);
            if (model == null)
                return NotFound();
            return Ok<CartModel>(model);
        }
        
        [ReturnType(DataType = typeof(CartDetailModel))]
        public IHttpActionResult GetCartDetailsByProfileId(long Id)//ProfileId
        {
            var model = comp.GetCartDetails(Id);
            if (model == null)
                return NotFound();
            return Ok<CartDetailModel>(model);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult UpdateCartDetail(CartDetailModel model)
        {
            return Ok<bool>(comp.UpdateCartDetail(model));
        }

        [ReturnType(DataType = typeof(List<CartExtendedModel>))]
        public IHttpActionResult GetCartList()
        {
            return Ok<List<CartExtendedModel>>(comp.GetCartList());
        }

        [ReturnType(DataType = typeof(CartExtendedModel))]
        public IHttpActionResult GetCartById(long Id)
        {
            return Ok<CartExtendedModel>(comp.GetCartById(Id));
        }
    }
}
