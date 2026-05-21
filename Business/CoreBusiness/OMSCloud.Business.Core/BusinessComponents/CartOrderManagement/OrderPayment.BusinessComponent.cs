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
    public partial class OrderPaymentBusinessComponent
    {
        public List<OrderPaymentModel> GetOrderPaymentList()
        {
            return adapter.GetOrderPaymentList();
        }
        public OrderPaymentModel GetOrderPaymentById(long Id)
        {
            return adapter.GetOrderPaymentById(Id);
        }
        public long? AddOrderPayment(OrderPaymentModel OrderPayment)
        {
            return adapter.AddOrderPayment(OrderPayment);
        }
        public bool UpdateOrderPayment(OrderPaymentModel OrderPayment)
        {
            return adapter.UpdateOrderPayment(OrderPayment);
        }
        public bool DeleteOrderPayment(OrderPaymentModel OrderPayment)
        {
            return adapter.DeleteOrderPayment(OrderPayment);
        }
    }
}
