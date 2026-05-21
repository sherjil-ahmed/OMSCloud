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
    public partial class StateMachineBusinessComponent
    {
        public List<StateMachineModel> GetStateMachineList()
        {
            return adapter.GetStateMachineList();
        }
        public StateMachineModel GetStateMachineById(long Id)
        {
            return adapter.GetStateMachineById(Id);
        }
        public long? AddStateMachine(StateMachineModel StateMachine)
        {
            return adapter.AddStateMachine(StateMachine);
        }
        public bool UpdateStateMachine(StateMachineModel StateMachine)
        {
            return adapter.UpdateStateMachine(StateMachine);
        }
        public bool DeleteStateMachine(StateMachineModel StateMachine)
        {
            return adapter.DeleteStateMachine(StateMachine);
        }
    }
}
