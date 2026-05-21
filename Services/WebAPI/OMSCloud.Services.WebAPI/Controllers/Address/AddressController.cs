using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class AddressController : ApiController, IAddressController
    {
        [ReturnType(DataType = typeof(List<UsedAddress>))]
        public IHttpActionResult GetNonEditableAddressList()
        {
            return Ok<List<UsedAddress>>(comp.GetNonEditableAddressList());
        }

        [ReturnType(DataType = typeof(List<AddressViewModel>))]
        public IHttpActionResult GetAddressList() 
        {
            return Ok<List<AddressViewModel>>(comp.GetAddressList());
        }

        [ReturnType(DataType = typeof(List<AddressModel>))]
        public IHttpActionResult GetDeliveryAddressByCartId(long Id)
        {
            return Ok<List<AddressModel>>(comp.GetDeliveryAddressByCartId(Id));
        }

        [ReturnType(DataType = typeof(List<AddressModel>))]
        public IHttpActionResult GetAddressListByProfileId(long Id, long? AddressTypeID = null)
        {
            return Ok<List<AddressModel>>(comp.GetAddressListByProfileId(Id, AddressTypeID));
        }

        [ReturnType(DataType = typeof(AddressModel))]
        public IHttpActionResult GetAddressById(long Id)
        {
            return Ok<AddressModel>(comp.GetAddressById(Id));
        }

    }
}
