using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class UnauthorisedController : BaseMvcController
    {

        // GET: Unauthorised
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Error(string _errorMsg)
        {
            ViewBag.ErrorMsg = _errorMsg;
            return View();
        }
    }
}