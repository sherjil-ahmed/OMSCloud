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
    public partial class StatusAdapter
    {
        #region Select
        public List<StatusModel> GetStatusList()
        {
            var StatusList = uow.StatusRepository.GetAll().Select(a => GetStatusModel(a)).OrderBy(o => o.StatusName).ToList();
            return StatusList;
        }

        public StatusModel GetStatusById(long Id)
        {
            var status = uow.StatusRepository.GetById(Id);
            StatusModel StatusModel = GetStatusModel(status);
            return StatusModel;
        }

        public List<StatusModel> GetStatusByStatus(DBStatusEnum status)
        {
            var result = from Status in uow.StatusRepository.OMSContext.Status
                         where Status.StatusID == (int)status
                         select GetStatusModel(Status);
            return result.ToList();
        }
        #endregion Select

        #region Update

        public bool UpdateStatus(StatusModel statusModel)
        {
            try
            {
                var status = UpdateConcurrency(GetEntity(statusModel), statusModel);
                var recordsCount = uow.OMSContext.Status_Update(status);
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        #endregion Update

        #region Add

        public long? AddStatus(StatusModel statusModel)
        {
            try
            {
                var status = UpdateConcurrency(GetEntity(statusModel), statusModel, false);
                var outParam = new ObjectParameter("StatusID", typeof(int));
                var recordsCount = uow.OMSContext.Status_Insert(status, outParam);
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
        public bool DeleteStatus(StatusModel statusModel)
        {
            try
            {
                var status = GetStatusEntity(statusModel);
                uow.StatusRepository.Delete(status);
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
        private StatusModel GetStatusModel(Status status)
        {
            return new StatusModel()
            {
                StatusID = status.StatusID,
                StatusName = status.StatusName,
                Description = status.Description
            };
        }
        private Status GetStatusEntity(StatusModel statusModel)
        {
            return new Status()
            {
                StatusID = statusModel.StatusID,
                StatusName = statusModel.StatusName,
                Description = statusModel.Description
            };
        }
        #endregion Private





    }
}