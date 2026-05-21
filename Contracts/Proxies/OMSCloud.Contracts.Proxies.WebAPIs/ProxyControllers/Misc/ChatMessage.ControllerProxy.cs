using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class ChatMessageControllerProxy : BaseControllerProxy
    {
        public long GetUnreadMessageCountByChatId(long Id)
        {
            string uri = "api/ChatMessage/GetUnreadMessageCountByChatId/" + Id.ToString() + "";

            var result = WebApiClient.GetForValueType<long>(uri);
            return result;
        }

        public List<ChatMessageModel> GetChatMessageListByChatId(long Id)
        {
            string uri = "api/ChatMessage/GetChatMessageListByChatId?Id=" + Id.ToString() + "&profileId=-1";

            var result = WebApiClient.Get<List<ChatMessageModel>>(uri);
            return result;
        }
        public List<ChatMessageModel> GetList()
        {
            string uri = "api/ChatMessage/GetList";

            var result = WebApiClient.Get<List<ChatMessageModel>>(uri);
            return result;

        }
        public ChatMessageModel GetById(Int64 Id)
        {
            string uri = "api/ChatMessage/GetById/" + Id.ToString() + "";

            var result = WebApiClient.Get<ChatMessageModel>(uri);
            return result;

        }
        public Nullable<Int64> Put(ChatMessageModel model)
        {
            string uri = "api/ChatMessage/Put";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;

        }
        public Boolean Post(ChatMessageModel model)
        {
            string uri = "api/ChatMessage/Post";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;

        }
        public Boolean Delete(ChatMessageModel model)
        {
            string uri = "api/ChatMessage/Delete";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public Boolean Delete(Int64 Id)
        {
            string uri = "api/ChatMessage/Delete/" + Id.ToString() + "";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
    }
}
