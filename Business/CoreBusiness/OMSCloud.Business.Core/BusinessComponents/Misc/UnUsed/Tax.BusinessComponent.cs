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
    public partial class TaxBusinessComponent
    {
        public List<TaxModel> GetTaxList()
        {
            return adapter.GetTaxList();
        }
        public TaxModel GetTaxById(long Id)
        {
            return adapter.GetTaxById(Id);
        }
        public long? AddTax(TaxModel Tax)
        {
            return adapter.AddTax(Tax);
        }
        public bool UpdateTax(TaxModel Tax)
        {
            return adapter.UpdateTax(Tax);
        }
        public bool DeleteTax(TaxModel Tax)
        {
            return adapter.DeleteTax(Tax);
        }
    }
}
