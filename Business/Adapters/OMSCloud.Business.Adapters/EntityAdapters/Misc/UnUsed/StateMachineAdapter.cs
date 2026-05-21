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
    public partial class StateMachineAdapter
    {
        #region Select
        public List<StateMachineModel> GetStateMachineList()
        {
            var stateMachineList = uow.StateMachineRepository.GetAll().Select(a => GetStateMachineModel(a)).ToList();
            return stateMachineList;
        }

        public StateMachineModel GetStateMachineById(long Id)
        {
            var stateMachine = uow.StateMachineRepository.GetById(Id);
            StateMachineModel stateMachineModel = GetStateMachineModel(stateMachine);
            return stateMachineModel;
        }

        #endregion Select

        #region Update

        public bool UpdateStateMachine(StateMachineModel stateMachineModel)
        {
            try
            {
                var stateMachine = UpdateConcurrency(GetEntity(stateMachineModel), stateMachineModel);
                var recordsCount = uow.OMSContext.StateMachine_Update(stateMachine);
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

        public long? AddStateMachine(StateMachineModel stateMachineModel)
        {
            try
            {
                var stateMachine = UpdateConcurrency(GetEntity(stateMachineModel), stateMachineModel, false);
                var outParam = new ObjectParameter("StateMachineID", typeof(int));
                var recordsCount = uow.OMSContext.StateMachine_Insert(stateMachine, outParam);
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
        public bool DeleteStateMachine(StateMachineModel stateMachineModel)
        {
            try
            {
                var stateMachine = GetStateMachineEntity(stateMachineModel);
                uow.StateMachineRepository.Delete(stateMachine);
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
        private StateMachineModel GetStateMachineModel(StateMachine stateMachine)
        {
            return new StateMachineModel()
            {
                StateMachineID = stateMachine.StateMachineID,
                StartStateID = stateMachine.StartStateID,
                StateMachineTitle = stateMachine.StateMachineTitle,
                StateMachineDescription = stateMachine.StateMachineDescription
            };
        }
        private StateMachine GetStateMachineEntity(StateMachineModel stateMachineModel)
        {
            return new StateMachine()
            {
                StateMachineID = stateMachineModel.StateMachineID,
                StartStateID = stateMachineModel.StartStateID,
                StateMachineTitle = stateMachineModel.StateMachineTitle,
                StateMachineDescription = stateMachineModel.StateMachineDescription
            };
        }
        #endregion Private

    }
}