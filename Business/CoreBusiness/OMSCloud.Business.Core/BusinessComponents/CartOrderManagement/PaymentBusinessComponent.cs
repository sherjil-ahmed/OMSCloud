using OMSCloud.Contracts.Interfaces;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Core
{
    public partial class PaymentBusinessComponent : IBusinessComponent<PaymentModel>
    {
        public List<PaymentModel> GetPaymentList()
        {
            return adapter.GetPaymentList();
        }

        public double GetOrderSum(SearchModel model)
        {
            return adapter.GetOrderSum(model);
        }

        public PaymentModel GetPaymentByOrderId(long OrderId)
        {
            return adapter.GetPaymentByOrderId(OrderId);
        }
    }
}
