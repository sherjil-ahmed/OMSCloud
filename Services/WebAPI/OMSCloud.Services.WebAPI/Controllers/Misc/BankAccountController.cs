using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class BankAccountController : ApiController, IBankAccountController
    {
        [ReturnType(DataType = typeof(BankAccountModel))]
        public IHttpActionResult GetBankAccountByShopId(long Id)
        {
            return Ok(comp.GetBankAccountByShopId(Id));
        }

        [ReturnType(DataType = typeof(List<BankAccountModel>))]
        public IHttpActionResult GetBankAccountList()
        {
            return Ok(comp.GetBankAccountList());
        }
    }
}