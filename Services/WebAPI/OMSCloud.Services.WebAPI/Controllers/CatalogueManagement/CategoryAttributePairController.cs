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
    public partial class CategoryAttributePairController : ApiController, ICategoryAttributePairController
    {
        // GET: api/CategoryAttributePair
        [ReturnType(DataType = typeof(List<CategoryAttributePairModel>))]
        public IHttpActionResult GetCategoryAttributePairList()
        {
            return Ok<List<CategoryAttributePairModel>>(comp.GetCategoryAttributePairList());
        }

        [ReturnType(DataType = typeof(List<CategoryAttributePairLookupModel>))]
        public IHttpActionResult GetListByCategoryId(long Id)
        {
            return Ok<List<CategoryAttributePairLookupModel>>(comp.GetListByCategoryId(Id));
        }


        [HttpPost]
        [ReturnType(DataType = typeof(List<AttributeValueResponseModel>))]
        public IHttpActionResult GetCategoryAttrobutePairList(AttributeValueRequestModel model)
        {
            return Ok<List<AttributeValueResponseModel>>(comp.GetCategoryAttrobutePairList(model.CategoryId, model.AttributeId));
        }
    }
}
