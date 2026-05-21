using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Business.Core
{
    public partial class AddressBusinessComponent
    {
        public List<UsedAddress> GetNonEditableAddressList() 
        {
            return adapter.GetNonEditableAddressList();
        }
        public List<AddressViewModel> GetAddressList()
        {
            return adapter.GetAddressList();
        }
        public AddressModel GetAddressById(long AddressId)
        {
            return adapter.GetAddressById(AddressId);
        }
        public List<AddressModel> GetDeliveryAddressByCartId(long Id) //CartOrder 
        {
            return adapter.GetDeliveryAddressByCartId(Id);
        }
        public List<AddressModel> GetAddressListByProfileId(long Id, long? AddressTypeID = null) //CartOrder 
        {
            return adapter.GetAddressListByProfileId(Id, AddressTypeID);
        }

        public long? AddAddress(AddressModel Address)
        {
            return adapter.AddAddress(Address);
        }
        public bool UpdateAddress(AddressModel Address)
        {
            return adapter.UpdateAddress(Address);
        }
        public bool DeleteAddress(long Id)
        {
            return adapter.Delete(Id);
        }
    }
}
