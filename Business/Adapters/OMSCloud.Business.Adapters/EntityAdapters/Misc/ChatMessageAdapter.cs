using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class ChatMessageAdapter
    {
        #region Get
        public long GetUnreadMessageCountByChatId(long Id)
        {
            var result = (from cm in uow.OMSContext.ChatMessage
                          where cm.ChatId == Id && cm.IsRead == false
                          select cm.MessageId).Count();
            return result;
        }
        public long GetUnreadMessageCountByProfileId(long Id)
        {
            var result = (from cm in uow.OMSContext.ChatMessage
                          where cm.ReceiverProfileId == Id && cm.IsRead == false
                          select cm.MessageId).Count();
            return result;
        }

        public List<ChatMessageModel> GetChatMessageListByChatId(long Id, long ProfileId)
        {
            var result = (from cm in uow.OMSContext.ChatMessage
                          join p1 in uow.OMSContext.Profile on cm.ReceiverProfileId equals p1.ProfileID into r
                          from rp in r.DefaultIfEmpty()
                          join p2 in uow.OMSContext.Profile on cm.SenderProfileId equals p2.ProfileID into s
                          from sp in s.DefaultIfEmpty()
                          where cm.ChatId == Id &&  cm.StatusId <= (long)DBStatusEnum.Active
                          select new ChatMessageModel
                          {
                              MessageId = cm.MessageId,
                              ChatId = cm.ChatId,
                              SenderProfileId = cm.SenderProfileId,
                              ReceiverProfileId = cm.ReceiverProfileId,
                              ReceiverProfileName = rp.FirstName + " " + rp.LastName,
                              SenderProfileName = sp.FirstName + " " + sp.LastName,
                              MessageCode = cm.MessageCode,
                              Message = cm.Message,
                              SentDateTime = cm.SentDateTime,
                              IsReceived = cm.IsReceived,
                              IsRead = cm.IsRead,
                              ReadDateTime = cm.ReadDateTime,
                              StatusId = cm.StatusId,
                          });
            if (ProfileId > 0)
            {
                this.MarkReadByProfileID(new ChatMessageModel { ChatId = Id, ReceiverProfileId = ProfileId });
            }
            return result.ToList();
        }

        #endregion
        #region private
        protected ChatMessage GetChatMessageEntity(ChatMessageModel model)
        {
            return new ChatMessage
            {
                MessageId = model.MessageId,
                ChatId = model.ChatId,
                SenderProfileId = model.SenderProfileId,
                ReceiverProfileId = model.ReceiverProfileId,
                MessageCode = model.MessageCode,
                Message = model.Message,
                SentDateTime = model.SentDateTime,
                IsReceived = model.IsReceived,
                IsRead = model.IsRead,
                ReadDateTime = model.ReadDateTime,
                StatusId = model.StatusId,
            };
        }

        protected ChatMessageModel GetChatMessageModel(ChatMessage entity)
        {
            return GetModelWithConcurrency(entity, new ChatMessageModel
            {
                MessageId = entity.MessageId,
                ChatId = entity.ChatId,
                SenderProfileId = entity.SenderProfileId,
                ReceiverProfileId = entity.ReceiverProfileId,
                MessageCode = entity.MessageCode,
                Message = entity.Message,
                SentDateTime = entity.SentDateTime,
                IsReceived = entity.IsReceived,
                IsRead = entity.IsRead,
                ReadDateTime = entity.ReadDateTime,
                StatusId = entity.StatusId,
            });
        }
        #endregion private
    }
}
