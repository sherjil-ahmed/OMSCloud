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
    public partial class ChatAdapter
    {
        #region Get
        public long InitiateChat(long sender, long receiver)
        {
            long chatId = -1;
            var result = (from c in uow.OMSContext.Chat
                          where
                                (c.ProfileId1 == sender && c.ProfileId2 == receiver)
                                ||
                                (c.ProfileId1 == receiver && c.ProfileId2 == sender)
                          select c).ToList();
            if (result.Count == 0)
            {
                var id = this.AddChat(new ChatModel
                {
                    ChatCode = "",
                    ProfileId1 = sender,
                    ProfileId2 = receiver,
                    RequestedByProfileId = sender,
                    StatusId = (long)DBStatusEnum.Active
                });
                chatId = id.HasValue ? id.Value : -1;
            }
            else
            {
                chatId = result.First().ChatId;
            }
            return chatId;
        }

        public List<ChatModel> GetChatListByProfileId(long Id)
        {
            var result = (from c in uow.OMSContext.Chat
                          join p1 in uow.OMSContext.Profile on c.ProfileId1 equals p1.ProfileID into x
                          from a in x.DefaultIfEmpty()
                          join p2 in uow.OMSContext.Profile on c.ProfileId2 equals p2.ProfileID into y
                          from b in y.DefaultIfEmpty()
                          //where c.ProfileId1 == Id || c.ProfileId2 == Id
                          select new ChatModel
                          {
                              ChatId = c.ChatId,
                              ChatCode = c.ChatCode,
                              ProfileId1 = c.ProfileId1,
                              ProfileId1_Name = a.FirstName + " " + a.LastName,
                              ProfileId1_Image = a.ImagePath,
                              ProfileId2 = c.ProfileId2,
                              ProfileId2_Name = b.FirstName + " " + b.LastName,
                              ProfileId2_Image = b.ImagePath,
                              StatusId = c.StatusId,
                              CreatedBy = c.CreatedByUserID,
                              CreatedOn = c.CreatedDateTime,
                              ModifiedBy = c.LastModifiedByUserID,
                              ModifiedOn = c.LastModifiedDateTime,
                              UnreadMessageCount = c.ChatMessage.Where(x=>x.ReceiverProfileId == Id && x.IsRead == false).Count()
                          });
            if (Id > 0)
            {
                result = result.Where(c => c.ProfileId1 == Id || c.ProfileId2 == Id);
            }
            return result.ToList();
        }

        public long GetUnreadChatCountByProfileId(long Id)
        {
            var result = (from cm in uow.OMSContext.ChatMessage
                          where 
                            cm.SenderProfileId == Id || cm.ReceiverProfileId == Id
                            &&
                            cm.IsRead == false
                          select cm.ChatId).Distinct().LongCount();
            return result;
        }

        #endregion
        #region Private
        protected Chat GetChatEntity(ChatModel model)
        {
            return new Chat
            {
                ChatId = model.ChatId,
                ChatCode = model.ChatCode,
                ProfileId1 = model.ProfileId1,
                ProfileId2 = model.ProfileId2,
                StatusId = model.StatusId,
            };
        }

        protected ChatModel GetChatModel(Chat entity)
        {
            return GetModelWithConcurrency(entity, new ChatModel
            {
                ChatId = entity.ChatId,
                ChatCode = entity.ChatCode,
                ProfileId1 = entity.ProfileId1,
                ProfileId2 = entity.ProfileId2,
                StatusId = entity.StatusId,
                //CreatedBy = entity.CreatedByUserID,
                //CreatedOn = entity.CreatedDateTime,
                //ModifiedBy = entity.LastModifiedByUserID,
                //ModifiedOn = entity.LastModifiedDateTime,
            });
        }
        #endregion Private
    }
}
