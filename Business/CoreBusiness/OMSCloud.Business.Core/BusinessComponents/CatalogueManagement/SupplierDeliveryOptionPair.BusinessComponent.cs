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
    public partial class SupplierDeliveryOptionPairBusinessComponent
    {
        //public List<SupplierModel> GetSupplierList()
        //{
        //    return adapter.GetSupplierList();
        //}
        public List<LocationLookup> GetSurroundingCities(long id)
        {
            return adapter.GetSurroundingCities(id);
        }

        public List<SupplierDeliveryOptionPairModel> GetSupplierDeliveryOptionList()
        {
            return adapter.GetSupplierDeliveryOptionList();
        }
        public SupplierDeliveryOptionPairModel GetSupplierDeliveryOptionById(long Id)
        {
            return adapter.GetSupplierDeliveryOptionById(Id);
        }
        public List<SupplierDeliveryOptionPairModel> GetSupplierDeliveryOptionBySupplierId(long Id)
        {
            return adapter.GetSupplierDeliveryOptionBySupplierId(Id);
        }

    }
}
