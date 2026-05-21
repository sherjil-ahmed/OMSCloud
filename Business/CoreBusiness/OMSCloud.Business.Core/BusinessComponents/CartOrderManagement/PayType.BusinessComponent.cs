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
    public partial class PayTypeBusinessComponent
    {
        public List<PayTypeModel> GetPayTypeList()
        {
            return adapter.GetPayTypeList();
        }
        public PayTypeModel GetPayTypeById(long Id)
        {
            return adapter.GetPayTypeById(Id);
        }
        public long? AddPayType(PayTypeModel Address)
        {
            return adapter.AddPayType(Address);
        }
        public bool UpdatePayType(PayTypeModel Address)
        {
            return adapter.UpdatePayType(Address);
        }
        public bool DeletePaytype(PayTypeModel Address)
        {
            return adapter.DeletePayType(Address);
        }
    }
}
