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
    public partial class ExecActionParamAdapter
    {


        #region Select
        public List<ExecActionParamModel> GetExecActionParamList()
        {
            var execActionParamList = uow.ExecActionParamRepository.GetAll().Select(a => GetExecActionParamModel(a)).ToList();
            return execActionParamList;
        }
        public ExecActionParamModel GetExecActionParamById(long Id)
        {
            var execActionParam = uow.ExecActionParamRepository.GetById(Id);
            ExecActionParamModel execActionParamModel = GetExecActionParamModel(execActionParam);
            return execActionParamModel;
        }
        #endregion Select

        #region Update

        public bool UpdateExecActionParam(ExecActionParamModel execActionParamModel)
        {
            try
            {
                var execActionParam = UpdateConcurrency(GetEntity(execActionParamModel), execActionParamModel);
                var recordsCount = uow.OMSContext.ExecActionParam_Update(execActionParam);

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
        public long? AddExecActionParam(ExecActionParamModel execActionParamModel)
        {
            try
            {
                var outParam = new ObjectParameter("ExecActionParamID", typeof(int));

                var execActionParam = UpdateConcurrency(GetEntity(execActionParamModel), execActionParamModel);
                var recordsCount = uow.OMSContext.ExecActionParam_Insert(execActionParam, outParam);

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
        public bool DeleteExecActionParam(ExecActionParamModel execActionParam)
        {
            try
            {
                var ExecActionParam = GetExecActionParamEntity(execActionParam);
                uow.ExecActionParamRepository.Delete(ExecActionParam);
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
        private ExecActionParamModel GetExecActionParamModel(ExecActionParam execActionParam)
        {
            return new ExecActionParamModel()
            {
                DataTypeID = execActionParam.DataTypeID,
                ExecActionID = execActionParam.ExecActionID,
                ExecActionParamID = execActionParam.ExecActionParamID,
                ParamName = execActionParam.ParamName
            };
        }
        private ExecActionParam GetExecActionParamEntity(ExecActionParamModel execActionParamModel)
        {
            return new ExecActionParam()
            {
                DataTypeID = execActionParamModel.DataTypeID,
                ExecActionID = execActionParamModel.ExecActionID,
                ExecActionParamID = execActionParamModel.ExecActionParamID,
                ParamName = execActionParamModel.ParamName
            };
        }
        #endregion Private
    }
}
