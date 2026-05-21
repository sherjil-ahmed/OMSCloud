using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Global.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseMvcController
    {
        // GET: Home
        public ActionResult Index()
        {
            return Redirect("/admin");
        }

    }
}