using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseMvcController
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        [Secure]
        public ActionResult Reports()
        {
            return View();
        }
    }
}