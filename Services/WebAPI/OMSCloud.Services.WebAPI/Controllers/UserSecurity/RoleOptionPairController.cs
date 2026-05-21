using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class RoleOptionPairController : ApiController, IRoleOptionPairController
    {        
        [ReturnType(DataType = typeof(List<RoleOptionPairModel>))]
        public IHttpActionResult GetByRoleID(long RoleId)
        {
            return Ok<List<RoleOptionPairModel>>(comp.GetRoleOptionPairByRoleId(RoleId));
        }


        [HttpPost]
        [ReturnType(DataType = typeof(List<RoleOptionPairModel>))]
        public IHttpActionResult GetByRoleIDs(List<long> RoleIds)
        {
            return Ok<List<RoleOptionPairModel>>(comp.GetRoleOptionPairByRoleId(RoleIds));
        }
    }
}
