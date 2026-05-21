using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Common.DBEnums;


namespace OMSCloud.Business.Core
{
    public partial class AddressTypeBusinessComponent
    {
        public List<AddressTypeModel> GetAddressTypeList()
        {
            return adapter.GetList();
        }
        public AddressTypeModel GetAddressTypeById(long Id)
        {
            return adapter.GetById(Id);
        }
        public long? AddAddressType(AddressTypeModel addressType)
        {
            return adapter.AddAddressType(addressType);
        }
        public bool UpdateAddressType(AddressTypeModel addressType)
        {
            return adapter.UpdateAddressType(addressType);
        }
        public bool DeleteAddressType(AddressTypeModel addressType)
        {
            return adapter.Delete(addressType);
        }
    }
}
