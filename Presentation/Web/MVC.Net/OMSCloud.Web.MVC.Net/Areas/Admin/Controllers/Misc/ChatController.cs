using OMSCloud.Contracts.Proxy.WebAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{
    public class ChatController : Controller
    {
        ChatControllerProxy chatProxy = new ChatControllerProxy();
        ChatMessageControllerProxy chatMsgProxy = new ChatMessageControllerProxy();

        [HttpGet]
        public ActionResult Index()
        {
            //var model = proxy.GetChatListByProfileId(3);
            var model = chatProxy.GetChatListByProfileId(-1);
            return View(model);
        }

        [HttpGet]
        public PartialViewResult GetChatListByProfileId(long Id)
        {
            var model = chatProxy.GetChatListByProfileId(Id);
            return PartialView("Index", model);
        }

        [HttpGet]
        public ActionResult ChatMessages(long Id)
        {
            var model = chatMsgProxy.GetChatMessageListByChatId(Id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult RemoveChatMessages(string ChatMessageCSV)
        {
            if (string.IsNullOrEmpty(ChatMessageCSV))
                return new JsonResult() { Data = "" };
            var result = chatProxy.RemoveChatMessages(ChatMessageCSV);
            return new JsonResult() { Data = result };
        }
    }
}