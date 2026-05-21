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
    public partial class OptionTypeBusinessComponent
    {
        public List<OptionTypeModel> GetOptionTypeList()
        {
            return adapter.GetOptionTypeList();
        }
        public OptionTypeModel GetOptionTypeById(long Id)
        {
            return adapter.GetOptionTypeById(Id);
        }
        public long? AddOptionType(OptionTypeModel OptionType)
        {
            return adapter.AddOptionType(OptionType);
        }
        public bool UpdateOptionType(OptionTypeModel OptionType)
        {
            return adapter.UpdateOptionType(OptionType);
        }
        public bool DeleteOptionType(OptionTypeModel OptionType)
        {
            return adapter.DeleteOptionType(OptionType);
        }
    }
}
