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
    public partial class StatusBusinessComponent
    {
        public List<StatusModel> GetStatusList()
        {
            return adapter.GetStatusList();
        }
        public StatusModel GetStatusById(long Id)
        {
            return adapter.GetStatusById(Id);
        }
        public long? AddStatus(StatusModel Status)
        {
            return adapter.AddStatus(Status);
        }
        public bool UpdateStatus(StatusModel Status)
        {
            return adapter.UpdateStatus(Status);
        }
        public bool DeleteStatus(StatusModel Status)
        {
            return adapter.DeleteStatus(Status);
        }
    }
}
