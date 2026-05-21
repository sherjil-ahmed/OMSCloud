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
    public partial class PackagedProductBusinessComponent
    {
        public List<PackagedProductModel> GetPackagedProductList()
        {
            return adapter.GetPackagedProductList();
        }
        public PackagedProductModel GetPackagedProductById(long Id)
        {
            return adapter.GetPackagedProductById(Id);
        }
        public List<PackagedProductModel> GetListByProductId(long Id)
        {
            return adapter.GetListByProductId(Id);
        }
        public long? AddPackagedProduct(PackagedProductModel PackagedProduct)
        {
            return adapter.AddPackagedProduct(PackagedProduct);
        }
        public bool UpdatePackagedProduct(PackagedProductModel PackagedProduct)
        {
            return adapter.UpdatePackagedProduct(PackagedProduct);
        }
        public bool DeletePackagedProduct(PackagedProductModel PackagedProduct)
        {
            return adapter.DeletePackagedProduct(PackagedProduct);
        }
    }
}
