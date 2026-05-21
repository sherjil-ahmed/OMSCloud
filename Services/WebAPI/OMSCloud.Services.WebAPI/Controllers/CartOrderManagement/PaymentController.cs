using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class PaymentController : ApiController, IPaymentController
    {
        [ReturnType(DataType = typeof(List<PaymentModel>))]
        public IHttpActionResult GetPaymentList()
        {
            return Ok<List<PaymentModel>>(comp.GetPaymentList());
        }

        [HttpPost]
        [ReturnType(DataType = typeof(double))]
        public IHttpActionResult GetOrderSum(SearchModel model)
        {
            return Ok<double>(comp.GetOrderSum(model));
        }

        [ReturnType(DataType = typeof(PaymentModel))]
        public IHttpActionResult GetPaymentByOrderId(long OrderId)
        {
            return Ok<PaymentModel>(comp.GetPaymentByOrderId(OrderId));
        }
    }
}