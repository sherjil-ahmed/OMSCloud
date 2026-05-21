using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class OrderControllerProxy : BaseControllerProxy//, IOrderController
    {
        public virtual long? Sp_ConvertCartToOrders(ConvertCartToOrders_SpParams paramModel)
        {
            string uri = "api/Order/Sp_ConvertCartToOrders/";

            var result = WebApiClient.Post<long>(uri, paramModel);
            return result; 
        }
    }
}
