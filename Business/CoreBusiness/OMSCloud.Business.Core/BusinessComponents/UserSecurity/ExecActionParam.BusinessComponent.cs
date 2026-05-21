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
    public partial class ExecActionParamBusinessComponent
    {
        public List<ExecActionParamModel> GetExecActionParamList()
        {
            return adapter.GetExecActionParamList();
        }
        public ExecActionParamModel GetExecActionParamById(long Id)
        {
            return adapter.GetExecActionParamById(Id);
        }
        public long? AddExecActionParam(ExecActionParamModel ExecActionParam)
        {
            return adapter.AddExecActionParam(ExecActionParam);
        }
        public bool UpdateExecActionParam(ExecActionParamModel ExecActionParam)
        {
            return adapter.UpdateExecActionParam(ExecActionParam);
        }
        public bool DeleteExecActionParam(ExecActionParamModel ExecActionParam)
        {
            return adapter.DeleteExecActionParam(ExecActionParam);
        }
    }
}
