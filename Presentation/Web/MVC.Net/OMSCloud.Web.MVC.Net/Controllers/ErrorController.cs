using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OMSCloud.Web.MVC.Net.Areas.Global.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        // GET: Public/Error
        public ActionResult Index()
        {
            return View();
        }

        // GET: Unauthorised
        [AllowAnonymous]
        public ActionResult Unauthorised()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult NotFound(string _errorMsg)
        {
            ViewBag.ErrorMsg = _errorMsg;
            return View();
        }


        // GET: Unauthorised
        [AllowAnonymous]
        public ActionResult Conflict()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult InternalServerError(string _errorMsg)
        {
            ViewBag.ErrorMsg = _errorMsg;
            return View();
        }
    }
}