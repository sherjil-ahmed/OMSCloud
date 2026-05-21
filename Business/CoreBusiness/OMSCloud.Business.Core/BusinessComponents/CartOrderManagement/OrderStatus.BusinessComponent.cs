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
    public partial class OrderStatusBusinessComponent
    {
        public List<OrderStatusModel> GetOrderStatusList()
        {
            return adapter.GetOrderStatusList();
        }
        
        public List<ChangeOrderStatusModel> GetNextOrderStatusList(int currentOrderStatus)
        {
            return adapter.GetNextOrderStatusList(currentOrderStatus);
        }
        public OrderStatusModel GetOrderStatusById(long Id)
        {
            return adapter.GetOrderStatusById(Id);
        }
        
        public List<OrderStatusModel> GetRootOrderStatus()
        {
            return adapter.GetRootOrderStatus();
        }
        public long? AddOrderStatus(OrderStatusModel OrderStatus)
        {
            return adapter.AddOrderStatus(OrderStatus);
        }
        public bool UpdateOrderStatus(OrderStatusModel OrderStatus)
        {
            return adapter.UpdateOrderStatus(OrderStatus);
        }
        public bool DeleteOrderStatus(OrderStatusModel OrderStatus)
        {
            return adapter.DeleteOrderStatus(OrderStatus);
        }
    }
}
