using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Interfaces.IServices
{
    public interface IWebApiExplorerController
    {
        List<ApiDescriptorModel> Explore();
    }
}
