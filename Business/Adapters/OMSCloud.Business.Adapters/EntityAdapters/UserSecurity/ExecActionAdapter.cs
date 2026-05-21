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
    public partial class ExecActionAdapter
    {


        #region Select
        public List<ExecActionModel> GetExecActionList()
        {
            var execActionList = uow.ExecActionRepository.GetAll().Select(a => GetExecActionModel(a)).ToList();
            return execActionList;
        }
        public ExecActionModel GetExecActionById(long Id)
        {
            var execAction = uow.ExecActionRepository.GetById(Id);
            ExecActionModel execActionModel = GetExecActionModel(execAction);
            return execActionModel;
        }
        #endregion Select

        #region Update

        public bool UpdateExecAction(ExecActionModel execActionModel)
        {
            try
            {
                var execAction = UpdateConcurrency(GetEntity(execActionModel), execActionModel);
                var recordsCount = uow.OMSContext.ExecAction_Update(execAction);

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
        public long? AddExecAction(ExecActionModel execActionModel)
        {
            try
            {
                var outParam = new ObjectParameter("ExecActionID", typeof(int));

                var execAction = UpdateConcurrency(GetEntity(execActionModel), execActionModel);
                var recordsCount = uow.OMSContext.ExecAction_Insert(execAction, outParam);

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
        public bool DeleteExecAction(ExecActionModel execActionModel)
        {
            try
            {
                var ExecAction = GetExecActionEntity(execActionModel);
                uow.ExecActionRepository.Delete(ExecAction);
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
        private ExecActionModel GetExecActionModel(ExecAction execAction)
        {
            return new ExecActionModel()
            {
                DataTypeID = execAction.DataTypeID,
                ExecActionID = execAction.ExecActionID,
                Method = execAction.Method
            };
        }
        private ExecAction GetExecActionEntity(ExecActionModel execActionModel)
        {
            return new ExecAction()
            {
                DataTypeID = execActionModel.DataTypeID,
                ExecActionID = execActionModel.ExecActionID,
                Method = execActionModel.Method
            };
        }
        #endregion Private
    }
}
