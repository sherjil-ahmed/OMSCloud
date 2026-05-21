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
    public partial class PayModeBusinessComponent
    {
        public List<PayModeModel> GetPayModeList()
        {
            return adapter.GetPayModeList();
        }        
        public List<PayModeModel> GetPayModeListByPayTypeId(long Id)
        {
            return adapter.GetPayModeListByPayTypeId(Id);
        }
        public PayModeModel GetPayModeById(long Id)
        {
            return adapter.GetPayModeById(Id);
        }
        public long? AddPayMode(PayModeModel payMode)
        {
            return adapter.AddPayMode(payMode);
        }
        public bool UpdatePayMode(PayModeModel payMode)
        {
            return adapter.UpdatePayMode(payMode);
        }
        public bool DeletePayMode(PayModeModel payMode)
        {
            return adapter.DeletePayMode(payMode);
        }
    }
}
