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
    public partial class OrderDeliveryDetailBusinessComponent
    {
        public List<OrderDeliveryDetailModel> GetOrderDeliveryDetailList()
        {
            return adapter.GetOrderDeliveryDetailList();
        }
        public OrderDeliveryDetailModel GetOrderDeliveryDetailById(long Id)
        {
            return adapter.GetOrderDeliveryDetailById(Id);
        }
        public long? AddOrderDeliveryDetail(OrderDeliveryDetailModel OrderDeliverDetail)
        {
            return adapter.AddOrderDeliveryDetail(OrderDeliverDetail);
        }
        public bool UpdateOrderDeliveryDetail(OrderDeliveryDetailModel OrderDeliverDetail)
        {
            return adapter.UpdateOrderDeliveryDetail(OrderDeliverDetail);
        }
        public bool DeleteOrderDeliveryDetail(OrderDeliveryDetailModel OrderDeliverDetail)
        {
            return adapter.DeleteOrderDeliveryDetail(OrderDeliverDetail);
        }
    }
}
