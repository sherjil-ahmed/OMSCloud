using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.DataStore.EF.OMSModel
{
    public class ConvertCartToOrders_SpParamsEntity
    {
        public long existing_CartId { get; set; }
        public long? new_DeliveryAddressID { get; set; }
        public long? new_SupplierDeliveryOptionPairID { get; set; }
        public long? spProfileId { get; set; }
    }
}
