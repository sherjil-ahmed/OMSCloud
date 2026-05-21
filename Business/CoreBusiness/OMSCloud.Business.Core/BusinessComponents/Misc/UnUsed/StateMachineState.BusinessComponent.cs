using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Business.Adapters;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Business.Core
{
    public partial class StateMachineStateBusinessComponent
    {
        public List<StateMachineStateModel> GetStateMachineStateList()
        {
            return adapter.GetStateMachineStateList();
        }
        public StateMachineStateModel GetStateMachineStateById(long Id)
        {
            return adapter.GetStateMachineStateById(Id);
        }
        public long? AddStateMachineState(StateMachineStateModel StateMachineState)
        {
            return adapter.AddStateMachineState(StateMachineState);
        }
        public bool UpdateStateMachineState(StateMachineStateModel StateMachineState)
        {
            return adapter.UpdateStateMachineState(StateMachineState);
        }
        public bool DeleteStateMachineState(StateMachineStateModel StateMachineState)
        {
            return adapter.DeleteStateMachineState(StateMachineState);
        }
    }
}
