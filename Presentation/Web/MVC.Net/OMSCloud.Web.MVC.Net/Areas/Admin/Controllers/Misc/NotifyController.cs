using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Proxies.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class NotifyController : BaseMvcController
    {
        private NotificationControllerProxy Proxy = new NotificationControllerProxy();
        // GET: Admin/Notify
        public ActionResult Index()
        {
            var id = ApplicationSession.Secure_UserId;
            var userId = ((id == null) ? 0 : Int64.Parse(id.ToString()));
            var model = Proxy.GetNotifyList(userId);// userId, (long)NotificationTypeEnum.Product);
            return View(model);
        }
    }
}