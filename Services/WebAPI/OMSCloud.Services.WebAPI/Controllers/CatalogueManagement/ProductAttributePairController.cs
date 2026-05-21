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
    public partial class ProductAttributePairController : ApiController, IProductAttributePairController
    {
        [ReturnType(DataType = typeof(List<ProductAttributePairModel>))]
        public IHttpActionResult GetProductAttributePairList()
        {
            return Ok<List<ProductAttributePairModel>>(comp.GetProductAttributePairList());
        }

        [ReturnType(DataType = typeof(List<ProductAttributePairModel>))]
        public IHttpActionResult GetListByProductID(long Id)
        {
            return Ok<List<ProductAttributePairModel>>(comp.GetListByProductId(Id));
        }

        [ReturnType(DataType = typeof(List<ProductAttributePairModel>))]
        public IHttpActionResult GetAllAttributesByProductId(long Id)
        {
            return Ok<List<ProductAttributePairModel>>(comp.GetAllAttributesByProductId(Id));
        }

        [ReturnType(DataType = typeof(List<ProductAttributePairModel>))]
        public IHttpActionResult GetAssignedAttributesByProductId(long Id)
        {
            return Ok<List<ProductAttributePairModel>>(comp.GetAssignedAttributesByProductId(Id));
        }

        [ReturnType(DataType = typeof(Boolean))]
        public IHttpActionResult UpdateIsAssigned(ProductAttributePairModel model)
        {
            return Ok<bool>(comp.UpdateIsAssigned(model));
        }
    }
}
