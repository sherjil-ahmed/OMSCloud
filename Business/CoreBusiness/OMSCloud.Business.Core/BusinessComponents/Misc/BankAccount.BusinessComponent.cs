using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Core
{
    public partial class BankAccountBusinessComponent
    {
        public BankAccountModel GetBankAccountByShopId(long Id)
        {
            return adapter.GetBankAccountByShopId(Id);
        }

        public List<BankAccountModel> GetBankAccountList()
        {
            return adapter.GetBankAccountList();
        }
    }
}
