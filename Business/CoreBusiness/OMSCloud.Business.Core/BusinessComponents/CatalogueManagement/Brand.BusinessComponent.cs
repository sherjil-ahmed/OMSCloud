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
    public partial class BrandBusinessComponent
    {
        public List<BrandModel> GetBrandList()
        {
            return adapter.GetBrandList();
        }
        public BrandModel GetBrandById(long Id)
        {
            return adapter.GetBrandById(Id);
        }
        public long? AddBrand(BrandModel brand)
        {
            return adapter.AddBrand(brand);
        }
        public bool UpdateBrand(BrandModel brand)
        {
            return adapter.UpdateBrand(brand);
        }
        public bool DeleteBrand(BrandModel brand)
        {
            return adapter.DeleteBrand(brand);
        }
    }
}
