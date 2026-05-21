using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.UnitofWork;
using OMSCloud.DataStore.EF.OMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.Common.DBEnums;
using System.Data.Entity.Core.Objects;

namespace OMSCloud.Business.Adapters
{
    public partial class RoleOptionPairAdapter
    {


        #region Select
        public List<RoleOptionPairModel> GetRoleOptionPairList()
        {
            var roleOptionPairList = uow.RoleOptionPairRepository.GetAll().Select(a => GetRoleOptionPairModel(a)).ToList();
            return roleOptionPairList;
        }

        public RoleOptionPairModel GetRoleOptionPairById(long Id)
        {
            var roleOptionPair = uow.RoleOptionPairRepository.GetById(Id);
            RoleOptionPairModel roleOptionPairModel = GetRoleOptionPairModel(roleOptionPair);
            return roleOptionPairModel;
        }

        public List<RoleOptionPairModel> GetRoleOptionPairsByStatus(DBStatusEnum status)
        {
            var result = from roleOptionPair in uow.RoleOptionPairRepository.OMSContext.RoleOptionPair
                         where roleOptionPair.StatusID == (int)status
                         select GetRoleOptionPairModel(roleOptionPair);
            return result.ToList();
        }
        public List<RoleOptionPairModel> GetRoleOptionPairByRoleId(long RoleId)
        {
            var roleOptionPairList = uow.RoleOptionPairRepository.GetAll().Where(x=>x.RoleID==RoleId).Select(a => GetRoleOptionPairModel(a)).ToList();
            return roleOptionPairList;
            //var result = from roleOptionPair in uow.RoleOptionPairRepository.OMSContext.RoleOptionPair
            //             where roleOptionPair.RoleID == RoleId
            //             select GetRoleOptionPairModel(roleOptionPair);
            //return result.ToList(); 
        }
        public List<RoleOptionPairModel> GetRoleOptionPairByRoleId(List<long> RoleIds)
        {
            //var roleOptionPairList = uow.RoleOptionPairRepository.GetAll().Where(x => x.RoleID == RoleId).Select(a => GetRoleOptionPairModel(a)).ToList();
            //return roleOptionPairList;
            var result = from roleOptionPair in uow.RoleOptionPairRepository.OMSContext.RoleOptionPair
                         where RoleIds.Contains(roleOptionPair.RoleID) //&& roleOptionPair.Option.ModuleID == 2
                         && roleOptionPair.Option.StatusID <= (long)DBStatusEnum.Active
                         select new RoleOptionPairModel()
                         {
                             RoleOptionPairID = roleOptionPair.RoleOptionPairID,
                             OptionID = roleOptionPair.OptionID,
                             RoleID = roleOptionPair.RoleID,
                             IsAssigned = roleOptionPair.IsAssigned,
                             IsSystem = roleOptionPair.IsSystem,
                             StatusID = roleOptionPair.StatusID,                             
                         };
            return result.ToList();
        }
        #endregion Select

        #region Update

        public bool UpdateRoleOptionPair(RoleOptionPairModel roleOptionPairModel)
        {
            try
            {
                var roleOptionPair = UpdateConcurrency(GetEntity(roleOptionPairModel), roleOptionPairModel);
                var recordsCount = uow.OMSContext.RoleOptionPair_Update(roleOptionPair);
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

        public long? AddRoleOptionPair(RoleOptionPairModel roleOptionPairModel)
        {
            try
            {
                var roleOptionPair = UpdateConcurrency(GetEntity(roleOptionPairModel), roleOptionPairModel, false);
                var outParam = new ObjectParameter("RoleOptionPairID", typeof(int));
                var recordsCount = uow.OMSContext.RoleOptionPair_Insert(roleOptionPair, outParam);
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
        public bool DeleteRoleOptionPair(RoleOptionPairModel roleOptionPairModel)
        {
            try
            {
                var roleOptionPair = GetRoleOptionPairsEntity(roleOptionPairModel);
                uow.RoleOptionPairRepository.Delete(roleOptionPair);
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
        private RoleOptionPairModel GetRoleOptionPairModel(RoleOptionPair roleOptionPair)
        {
            return new RoleOptionPairModel()
            {
                RoleOptionPairID = roleOptionPair.RoleOptionPairID,
                OptionID = roleOptionPair.OptionID,
                RoleID = roleOptionPair.RoleID,
                IsAssigned = roleOptionPair.IsAssigned,
                IsSystem = roleOptionPair.IsSystem,
                StatusID = roleOptionPair.StatusID,
                //CreatedByUserID = roleOptionPair.CreatedByUserID,
                //CreatedDateTime = roleOptionPair.CreatedDateTime,
                //LastModifiedByUserID = roleOptionPair.LastModifiedByUserID,
                //LastModifiedDateTime = roleOptionPair.LastModifiedDateTime
            };
        }
        private RoleOptionPair GetRoleOptionPairsEntity(RoleOptionPairModel roleOptionPairModel)
        {
            return new RoleOptionPair()
            {
                RoleOptionPairID = roleOptionPairModel.RoleOptionPairID,
                OptionID = roleOptionPairModel.OptionID,
                RoleID = roleOptionPairModel.RoleID,
                IsAssigned = roleOptionPairModel.IsAssigned,
                IsSystem = roleOptionPairModel.IsSystem,
                StatusID = roleOptionPairModel.StatusID,
                //CreatedByUserID = roleOptionPairModel.CreatedByUserID,
                //CreatedDateTime = roleOptionPairModel.CreatedDateTime,
                //LastModifiedByUserID = roleOptionPairModel.LastModifiedByUserID,
                //LastModifiedDateTime = roleOptionPairModel.LastModifiedDateTime
            };
        }
        #endregion Private



    }
}