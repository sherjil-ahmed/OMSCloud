using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.UnitofWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class GroupAdapter
    {


        #region Select
        public List<GroupModel> GetGroupList()
        {
            var groupList = uow.GroupRepository.GetAll().Select(a => GetGroupModel(a)).ToList();
            return groupList;
        }
        public GroupModel GetGroupById(long Id)
        {
            var group = uow.GroupRepository.GetById(Id);
            GroupModel groupModel = GetGroupModel(group);
            return groupModel;
        }
        public List<GroupModel> GetGroupModelByStatus(DBStatusEnum status)
        {
            var result = from groups in uow.GroupRepository.OMSContext.Group
                         where groups.StatusID == (int)status
                         select GetGroupModel(groups);
            return result.ToList();
        }
        #endregion Select

        #region Update

        public bool UpdateGroup(GroupModel groupModel)
        {
            try
            {
                var group = UpdateConcurrency(GetEntity(groupModel), groupModel);
                var recordsCount = uow.OMSContext.Group_Update(group);

                return recordsCount > 0;
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion Update

        #region Add
        public long? AddGroup(GroupModel groupModel)
        {
            try
            {
                var outParam = new ObjectParameter("GroupID", typeof(int));

                var group = UpdateConcurrency(GetEntity(groupModel), groupModel);
                var recordsCount = uow.OMSContext.Group_Insert(group, outParam);

                return recordsCount > 0 ? (long?)outParam.Value : null;

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add

        #region Delete
        public bool DeleteGroup(GroupModel groupModel)
        {
            try
            {
                var groups = GetGroupEntity(groupModel);
                uow.GroupRepository.Delete(groups);
                uow.Commit();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion Delete

        #region Private
        private GroupModel GetGroupModel(Group group)
        {
            return new GroupModel()
            {
                GroupID = group.GroupID,
                GroupTitle = group.GroupTitle,
                Description = group.Description,
                IconPath = group.IconPath,
                StatusID = group.StatusID,
                IsSystem = group.IsSystem
            };
        }
        private Group GetGroupEntity(GroupModel groupModel)
        {
            return new Group()
            {
                GroupID = groupModel.GroupID,
                GroupTitle = groupModel.GroupTitle,
                Description = groupModel.Description,
                IconPath = groupModel.IconPath,
                StatusID = groupModel.StatusID,
                IsSystem = groupModel.IsSystem
            };
        }
        #endregion Private
    }
}
