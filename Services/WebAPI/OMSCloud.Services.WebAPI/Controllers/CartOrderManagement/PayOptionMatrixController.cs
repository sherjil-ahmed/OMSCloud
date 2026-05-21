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
    public partial class PayOptionMatrixController : ApiController, IPayOptionMatrixController
    {
        [ReturnType(DataType = typeof(List<PayOptionMatrixModel>))]
        public IHttpActionResult GetPayOptionMatrixList()
        {
            return Ok<List<PayOptionMatrixModel>>(comp.GetPayOptionMatrixList());
        }
        [ReturnType(DataType = typeof(PayOptionMatrixModel))]
        public IHttpActionResult GetPayOptionMatrixById(long Id)
        {
            var model = comp.GetPayOptionMatrixById(Id);
            if (model != null)
                return Ok<PayOptionMatrixModel>(model);
            else
                return NotFound();
        }
        [ReturnType(DataType = typeof(long))]
        public IHttpActionResult GetIdBy(long Id, long Id1)//(long payTypeId, long payModeId)//
        {
            var PayOptionMatrixId = comp.GetIdBy(Id, Id1);
            if (PayOptionMatrixId.HasValue)
                return Ok<long>(PayOptionMatrixId.Value);
            else
                return NotFound();
        }
    }
}