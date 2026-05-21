using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class SupplierDeliveryOptionPairController : ApiController, ISupplierDeliveryOptionPairController
    {
        //SupplierDeliveryOptionPairController
        [ReturnType(DataType = typeof(List<LocationLookup>))]
        public IHttpActionResult GetSurroundingCities(long Id)
        {
            var result = comp.GetSurroundingCities(Id);
            return Ok<List<LocationLookup>>(result);
        }

        [ReturnType(DataType = typeof(List<SupplierDeliveryOptionPairModel>))]
        public IHttpActionResult GetSupplierDeliveryOptionList()
        {
            var result = comp.GetSupplierDeliveryOptionList();
            return Ok<List<SupplierDeliveryOptionPairModel>>(result);
        }

        [ReturnType(DataType = typeof(SupplierDeliveryOptionPairModel))]
        public IHttpActionResult GetSupplierDeliveryOptionById(long Id)
        {
            var result = comp.GetSupplierDeliveryOptionById(Id);
            return Ok<SupplierDeliveryOptionPairModel>(result);
        }

        [ReturnType(DataType = typeof(List<SupplierDeliveryOptionPairModel>))]
        public IHttpActionResult GetSupplierDeliveryOptionBySupplierId(long Id)
        {
            var result = comp.GetSupplierDeliveryOptionBySupplierId(Id);
            return Ok<List<SupplierDeliveryOptionPairModel>>(result);
        }

        [ReturnType(DataType = typeof(List<SupplierDeliveryOptionPairModel>))]
        public IHttpActionResult PutSupplierDeliveryOptionList(List<SupplierDeliveryOptionPairModel> list)
        {
            var result1 = comp.UpdateSuplierDeliveryOptionPair(list);
            return Ok<List<SupplierDeliveryOptionPairModel>>(result1);
        }
    }
}
