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
    public partial class AttributeController : ApiController, IAttributeController
    {
        [ReturnType(DataType = typeof(AttributeSearchResultAdminModel))]
        public IHttpActionResult GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder)
        {
            return Ok<AttributeSearchResultAdminModel>(comp.GetListByPage(PageNum, PageSize_RowCount, searchString, sortOrder));
        }

        [ReturnType(DataType = typeof(List<AttributeLookupModel>))]
        public IHttpActionResult GetAttributeListNotAssociatedWithProductId(long Id)
        {
            return Ok<List<AttributeLookupModel>>(comp.GetAttributeListNotAssociatedWithProductId(Id));
        }

        [ReturnType(DataType = typeof(List<AttributeLookupModel>))]
        public IHttpActionResult GetAttributeListNotAssociatedWithCategoryId(long Id)
        {
            return Ok<List<AttributeLookupModel>>(comp.GetAttributeListNotAssociatedWithCategoryId(Id));
        }

        // GET: api/Attribute/GetAttributeList
        [ReturnType(DataType = typeof(List<AttributeLookupModel>))]
        public IHttpActionResult GetAttributeLookupList()
        {
            return Ok<List<AttributeLookupModel>>(comp.GetAttributeLookupList());
        }

        // GET: api/Attribute/GetAttributeList
        [ReturnType(DataType = typeof(List<AttributeModel>))]
        public IHttpActionResult GetAttributeList()
        {
            return Ok<List<AttributeModel>>(comp.GetAttributeList());
        }

        // GET: api/Attribute/GetAttributeById
        [ReturnType(DataType = typeof(AttributeModel))]
        public IHttpActionResult GetAttributeById(long Id)
        {
            return Ok<AttributeModel>(comp.GetAttributeById(Id));
        }

        [ReturnType(DataType = typeof(AttributeModel))]
        public IHttpActionResult GetAttributeByName(string Id)
        {
            return Ok<AttributeModel>(comp.GetAttributeByName(Id));
        }
    }
}
