using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class ChatMessageController : ApiController, IChatMessageController
    {
        [ReturnType(DataType = typeof(long))]
        public IHttpActionResult GetUnreadMessageCountByChatId(long Id)
        {
            return Ok( comp.GetUnreadMessageCountByChatId(Id));
        }

        [ReturnType(DataType = typeof(List<ChatMessageModel>))]
        public IHttpActionResult GetChatMessageListByChatId(long Id, long ProfileId)
        {
            return Ok(comp.GetChatMessageListByChatId(Id, ProfileId));
        }
    }
}