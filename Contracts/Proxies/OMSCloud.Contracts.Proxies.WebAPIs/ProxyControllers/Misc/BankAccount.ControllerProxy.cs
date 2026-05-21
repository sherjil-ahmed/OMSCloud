using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class BankAccountControllerProxy : BaseControllerProxy
    {
        public BankAccountModel GetBankAccountByShopId(long Id)
        {
            string uri = "api/BankAccount/GetBankAccountByShopId/" + Id;

            var result = WebApiClient.Get<BankAccountModel>(uri);
            return result;

        }
        public List<BankAccountModel> GetBankAccountList()
        {
            string uri = "api/BankAccount/GetBankAccountList";

            var result = WebApiClient.Get<List<BankAccountModel>>(uri);
            return result;

        }

        public List<BankAccountModel> GetList()
        {
            string uri = "api/BankAccount/GetList";

            var result = WebApiClient.Get<List<BankAccountModel>>(uri);
            return result;

        }
        public BankAccountModel GetById(Int64 Id)
        {
            string uri = "api/BankAccount/GetById/" + Id.ToString() + "";

            var result = WebApiClient.Get<BankAccountModel>(uri);
            return result;

        }
        public Nullable<Int64> Put(BankAccountModel model)
        {
            string uri = "api/BankAccount/Put";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;

        }
        public Boolean Post(BankAccountModel model)
        {
            string uri = "api/BankAccount/Post";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;

        }
        public Boolean Delete(BankAccountModel model)
        {
            string uri = "api/BankAccount/Delete";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public Boolean Delete(Int64 Id)
        {
            string uri = "api/BankAccount/Delete/" + Id.ToString() + "";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
    }
}
