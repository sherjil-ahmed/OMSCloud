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
    public partial class PayModeController : ApiController, IPayModeController
    {
        [ReturnType(DataType = typeof(List<PayModeModel>))]
        public IHttpActionResult GetPayModeListByPayTypeId(long Id)
        {
            return Ok<List<PayModeModel>>(comp.GetPayModeListByPayTypeId(Id));
        }
    }
}
