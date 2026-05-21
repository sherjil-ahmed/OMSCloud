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
    public partial class OrderStatusMapBusinessComponent
    {
        public List<OrderStatusMapModel> GetSortedList()
        {
            return adapter.GetSortedList();
        }
        public OrderStatusMapModel GetOrderStatusMapById(long Id)
        {
            return adapter.GetOrderStatusMapById(Id);
        }
        public bool DeleteOrderStatusMap(OrderStatusMapModel OrderStatusMap)
        {
            return adapter.DeleteOrderStatusMap(OrderStatusMap);
        }
    }
}
