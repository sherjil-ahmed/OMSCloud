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
    public partial class PayOptionMatrixBusinessComponent
    {
        public List<PayOptionMatrixModel> GetPayOptionMatrixList()
        {
            return adapter.GetPayOptionMatrixList();
        }
        public PayOptionMatrixModel GetPayOptionMatrixById(long Id)
        {
            return adapter.GetPayOptionMatrixById(Id);
        }
        public long? GetIdBy(long payTypeId, long payModeId)
        {
            return adapter.GetIdBy(payTypeId, payModeId);
        }
    }
}
