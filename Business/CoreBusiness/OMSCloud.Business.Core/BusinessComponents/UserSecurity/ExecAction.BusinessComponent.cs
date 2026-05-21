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
    public partial class ExecActionBusinessComponent
    {
        public List<ExecActionModel> GetExecActionList()
        {
            return adapter.GetExecActionList();
        }
        public ExecActionModel GetExecActionById(long Id)
        {
            return adapter.GetExecActionById(Id);
        }
        public long? AddExecAction(ExecActionModel ExecAction)
        {
            return adapter.AddExecAction(ExecAction);
        }
        public bool UpdateExecAction(ExecActionModel ExecAction)
        {
            return adapter.UpdateExecAction(ExecAction);
        }
        public bool DeleteExecAction(ExecActionModel ExecAction)
        {
            return adapter.DeleteExecAction(ExecAction);
        }
    }
}
