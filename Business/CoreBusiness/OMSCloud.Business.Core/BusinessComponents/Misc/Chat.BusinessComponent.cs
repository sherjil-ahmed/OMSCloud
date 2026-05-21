using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Core
{
    public partial class ChatBusinessComponent
    {
        public long InitiateChat(long sender, long receiver)
        {
            return adapter.InitiateChat(sender, receiver);
        }
        public List<ChatModel> GetChatListByProfileId(long Id)
        {
            return adapter.GetChatListByProfileId(Id);
        }
        public long GetUnreadChatCountByProfileId(long Id)
        {
            return adapter.GetUnreadChatCountByProfileId(Id);
        }

    }
}
