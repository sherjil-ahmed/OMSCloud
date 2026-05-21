using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Core
{
    public partial class ChatMessageBusinessComponent
    {
        public long GetUnreadMessageCountByChatId(long Id)
        {
            return adapter.GetUnreadMessageCountByChatId(Id);
        }
        public long GetUnreadMessageCountByProfileId(long Id)
        {
            return adapter.GetUnreadMessageCountByProfileId(Id);
        }

        public List<ChatMessageModel> GetChatMessageListByChatId(long Id, long ProfileId)
        {
            return adapter.GetChatMessageListByChatId(Id, ProfileId);
        }
    }
}
