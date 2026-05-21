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
    public partial class TaxTypeBusinessComponent
    {
        public List<TaxTypeModel> GetTaxTypeList()
        {
            return adapter.GetTaxTypeList();
        }
        public TaxTypeModel GetTaxTypeById(long Id)
        {
            return adapter.GetTaxTypeById(Id);
        }
        public long? AddTaxType(TaxTypeModel TaxType)
        {
            return adapter.AddTaxType(TaxType);
        }
        public bool UpdateTaxType(TaxTypeModel TaxType)
        {
            return adapter.UpdateTaxType(TaxType);
        }
        public bool DeleteTaxType(TaxTypeModel TaxType)
        {
            return adapter.DeleteTaxType(TaxType);
        }
    }
}
