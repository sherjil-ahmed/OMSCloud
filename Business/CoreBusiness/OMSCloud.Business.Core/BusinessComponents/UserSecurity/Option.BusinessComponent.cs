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
    public partial class OptionBusinessComponent
    {
        public List<OptionModel> GetOptionList()
        {
            return adapter.GetOptionList();
        }
        public OptionModel GetOptionById(long Id)
        {
            return adapter.GetOptionById(Id);
        }
        public long? AddOption(OptionModel Option)
        {
            return adapter.AddOption(Option);
        }
        public bool UpdateOption(OptionModel Option)
        {
            return adapter.UpdateOption(Option);
        }
        public bool DeleteOption(OptionModel Option)
        {
            return adapter.DeleteOption(Option);
        }
    }
}
