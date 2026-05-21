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
    public partial class GroupRolePairAdapter
    {


        #region Select
        public List<GroupRolePairModel> GetGroupRolePairList()
        {
            var groupRolePairList = uow.GroupRolePairRepository.GetAll().Select(a => GetGroupRolePairModel(a)).ToList();
            return groupRolePairList;
        }
        public GroupRolePairModel GetGroupRolePairById(long Id)
        {
            var groupRolePair = uow.GroupRolePairRepository.GetById(Id);
            GroupRolePairModel gruopRolePairModel = GetGroupRolePairModel(groupRolePair);
            return gruopRolePairModel;
        }
        #endregion Select

        #region Update

        public bool UpdateGroupRolePair(GroupRolePairModel groupRolePairModel)
        {
            try
            {
                var groupRolePair = UpdateConcurrency(GetEntity(groupRolePairModel), groupRolePairModel);
                var recordsCount = uow.OMSContext.GroupRolePair_Update(groupRolePair);

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
        public long? AddGroupRolePair(GroupRolePairModel groupRolePairModel)
        {
            try
            {
                var outParam = new ObjectParameter("GroupRolePairID", typeof(int));

                var groupRolePair = UpdateConcurrency(GetEntity(groupRolePairModel), groupRolePairModel);
                var recordsCount = uow.OMSContext.GroupRolePair_Insert(groupRolePair, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch
            {
                return null;
            }
            finally
            {
            }
        }
        #endregion Add

        #region Delete
        public bool DeleteGroupRolePair(GroupRolePairModel groupRolePairModel)
        {
            try
            {
                var groupRolePair = GetGroupRolePairEntity(groupRolePairModel);
                uow.GroupRolePairRepository.Delete(groupRolePair);
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
        private GroupRolePairModel GetGroupRolePairModel(GroupRolePair groupRolePair)
        {
            return new GroupRolePairModel()
            {
                GroupID = groupRolePair.GroupID,
                GroupRolePairID = groupRolePair.GroupRolePairID,
                IsSystem = groupRolePair.IsSystem,
                RoleID = groupRolePair.RoleID
            };
        }
        private GroupRolePair GetGroupRolePairEntity(GroupRolePairModel groupRolePairModel)
        {
            return new GroupRolePair()
            {
                GroupID = groupRolePairModel.GroupID,
                GroupRolePairID = groupRolePairModel.GroupRolePairID,
                IsSystem = groupRolePairModel.IsSystem,
                RoleID = groupRolePairModel.RoleID
            };
        }
        #endregion Private
    }
}
