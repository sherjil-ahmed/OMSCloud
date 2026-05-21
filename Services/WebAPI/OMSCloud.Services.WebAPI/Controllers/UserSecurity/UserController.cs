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
    public partial class UserController : ApiController, IUserController
    {
     
        [HttpPost]
        [ReturnType(DataType = typeof(UserModel))]
        public IHttpActionResult LoginUser(LoginModel model)
        {
            return Ok<UserModel>(comp.LoginUser(model));
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult ChangePassword(ChangePasswordModel model)
        {
            if (comp.ChangePassword(model))
                return Ok<bool>(true);
            return Conflict();
        }

    }
}
