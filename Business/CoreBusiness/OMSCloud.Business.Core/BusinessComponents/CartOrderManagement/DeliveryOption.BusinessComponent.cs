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
    public partial class DeliveryOptionBusinessComponent
    {
        public List<DeliveryOptionModel> GetDeliveryOptionList()
        {
            return adapter.GetDeliveryOptionList();
        }
        public DeliveryOptionModel GetDeliveryOptionById(long Id)
        {
            return adapter.GetDeliveryOptionById(Id);
        }
        public long? AddDeliveryOption(DeliveryOptionModel DeliveryOption)
        {
            return adapter.AddDeliveryOption(DeliveryOption);
        }
        public bool UpdateDeliveryOption(DeliveryOptionModel DeliveryOption)
        {
            return adapter.UpdateDeliveryOption(DeliveryOption);
        }
        public bool DeleteDeliveryOption(DeliveryOptionModel DeliveryOption)
        {
            return adapter.DeleteDeliveryOption(DeliveryOption);
        }
    }
}
