using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class OrderDeliveryDetailController : ApiController, IOrderDeliveryDetailController
    {
        [ReturnType(DataType = typeof(List<OrderDeliveryDetailModel>))]
        public IHttpActionResult GetOrderDeliveryDetailList()
        {
            return Ok<List<OrderDeliveryDetailModel>>(comp.GetOrderDeliveryDetailList());
        }

        [ReturnType(DataType = typeof(OrderDeliveryDetailModel))]
        public IHttpActionResult GetOrderDeliveryDetailById(long Id)
        {
            return Ok<OrderDeliveryDetailModel>(comp.GetOrderDeliveryDetailById(Id));
        }
    }
}
