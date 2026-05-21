using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class ChatControllerProxy : BaseControllerProxy
    {
        public bool InitiateChat(long sender, long receiver)
        {
            string uri = "api/Chat/InitiateChat&sender=" + sender + "?receiver=" + receiver;

            var result = WebApiClient.GetForValueType<Boolean>(uri);
            return result;
        }
        public List<ChatModel> GetChatListByProfileId(long Id)
        {
            string uri = "api/Chat/GetChatListByProfileId/" + Id.ToString() + "";

            var result = WebApiClient.Get<List<ChatModel>>(uri);
            return result;
        }
        public long GetUnreadChatCountByProfileId(long Id)
        {
            string uri = "api/Chat/GetUnreadChatCountByProfileId/" + Id.ToString() + "";

            var result = WebApiClient.GetForValueType<long>(uri);
            return result;
        }
        public List<ChatModel> GetList()
        {
            string uri = "api/Chat/GetList";

            var result = WebApiClient.Get<List<ChatModel>>(uri);
            return result;

        }
        public ChatModel GetById(Int64 Id)
        {
            string uri = "api/Chat/GetById/" + Id.ToString() + "";

            var result = WebApiClient.Get<ChatModel>(uri);
            return result;

        }

        public object RemoveChatMessages(string chatMessageCSV)
        {
            string uri = "api/Chat/RemoveChatMessages?chatMessageCSV=" + chatMessageCSV + "";

            var result = WebApiClient.Post<Boolean>(uri, chatMessageCSV);
            return result;
        }

        public Nullable<Int64> Put(ChatModel model)
        {
            string uri = "api/Chat/Put";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;

        }
        public Boolean Post(ChatModel model)
        {
            string uri = "api/Chat/Post";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;

        }
        public Boolean Delete(ChatModel model)
        {
            string uri = "api/Chat/Delete";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public Boolean Delete(Int64 Id)
        {
            string uri = "api/Chat/Delete/" + Id.ToString() + "";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
    }
}
