using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class BankAccountAdapter
    {
        public BankAccountModel GetBankAccountByShopId(long Id)
        {
            var result = (from b in uow.OMSContext.BankAccount
                          where b.SupplierId == Id
                          select new BankAccountModel {
                              BankId = b.BankId,
                              Name = b.Name,
                              SupplierId = b.SupplierId,
                              AccountNumber = b.AccountNumber,
                              AccountTitle = b.AccountTitle,
                              Address = b.Address,
                              IBAN = b.IBAN,
                              AccountTypeId = b.AccountTypeId
                          });
            return result.FirstOrDefault();
        }

        public List<BankAccountModel> GetBankAccountList()
        {
            var result = (from b in uow.OMSContext.BankAccount
                          
                          select new BankAccountModel {
                              BankId = b.BankId,
                              Name = b.Name,
                              SupplierId = b.SupplierId,
                              ShopName = b.Supplier.SupplierName,
                              AccountNumber = b.AccountNumber,
                              AccountTitle = b.AccountTitle,
                              Address = b.Address,
                              IBAN = b.IBAN,
                              AccountTypeId = b.AccountTypeId
                          });
            return result.ToList();
        }
    }
}
