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

    public partial class OrderStatusController : ApiController, IOrderStatusController
    {
        [ReturnType(DataType = typeof(List<ChangeOrderStatusModel>))]
        public IHttpActionResult GetNextOrderStatusList(int Id)//CurrentStatusId
        {
            return Ok<List<ChangeOrderStatusModel>>(comp.GetNextOrderStatusList(Id));
        }

        
        [ReturnType(DataType = typeof(List<OrderStatusModel>))]
        public IHttpActionResult GetRootOrderStatus()
        {
            return Ok<List<OrderStatusModel>>(comp.GetRootOrderStatus());
        }
    }
}
