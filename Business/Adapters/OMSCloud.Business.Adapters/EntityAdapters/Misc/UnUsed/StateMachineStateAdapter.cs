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
    public partial class StateMachineStateAdapter
    {


        #region Select
        public List<StateMachineStateModel> GetStateMachineStateList()
        {
            var stateMachineStateList = uow.StateMachineStateRepository.GetAll().Select(a => GetStateMachineStateModel(a)).ToList();
            return stateMachineStateList;
        }

        public StateMachineStateModel GetStateMachineStateById(long Id)
        {
            var stateMachineState = uow.StateMachineStateRepository.GetById(Id);
            StateMachineStateModel stateMachineStateModel = GetStateMachineStateModel(stateMachineState);
            return stateMachineStateModel;
        }


        #endregion Select

        #region Update

        public bool UpdateStateMachineState(StateMachineStateModel stateMachineStateModel)
        {
            try
            {
                var stateMachineState = UpdateConcurrency(GetEntity(stateMachineStateModel), stateMachineStateModel);
                var recordsCount = uow.OMSContext.StateMachineState_Update(stateMachineState);
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

        public long? AddStateMachineState(StateMachineStateModel stateMachineStateModel)
        {
            try
            {
                var stateMachineState = UpdateConcurrency(GetEntity(stateMachineStateModel), stateMachineStateModel, false);
                var outParam = new ObjectParameter("StateMachineStateID", typeof(int));
                var recordsCount = uow.OMSContext.StateMachineState_Insert(stateMachineState, outParam);
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
        public bool DeleteStateMachineState(StateMachineStateModel stateMachineStateModel)
        {
            try
            {
                var stateMachineState = GetStateMachineStateEntity(stateMachineStateModel);
                uow.StateMachineStateRepository.Delete(stateMachineState);
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
        private StateMachineStateModel GetStateMachineStateModel(StateMachineState StateMachineState)
        {
            return new StateMachineStateModel()
            {
                StateMachineStateID = StateMachineState.StateMachineStateID,
                StateID = StateMachineState.StateID,
                NextStateID = StateMachineState.NextStateID,
                NextInputString = StateMachineState.NextInputString
            };
        }
        private StateMachineState GetStateMachineStateEntity(StateMachineStateModel StateMachineStateModel)
        {
            return new StateMachineState()
            {
                StateMachineStateID = StateMachineStateModel.StateMachineStateID,
                StateID = StateMachineStateModel.StateID,
                NextStateID = StateMachineStateModel.NextStateID,
                NextInputString = StateMachineStateModel.NextInputString
            };
        }
        #endregion Private

    }
}