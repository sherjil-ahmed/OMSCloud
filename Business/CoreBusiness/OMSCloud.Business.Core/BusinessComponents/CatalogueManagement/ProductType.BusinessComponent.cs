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
    public partial class ProductTypeBusinessComponent
    {
        public List<ProductTypeModel> GetProductTypeList()
        {
            return adapter.GetProductTypeList();
        }
        public ProductTypeModel GetProductTypeById(long Id)
        {
            return adapter.GetProductTypeById(Id);
        }
        public long? AddProductType(ProductTypeModel productType)
        {
            return adapter.AddProductType(productType);
        }
        public bool UpdateProductType(ProductTypeModel productType)
        {
            return adapter.UpdateProductType(productType);
        }
        public bool DeleteProductType(ProductTypeModel productType)
        {
            return adapter.DeleteProductType(productType);
        }
    }
}
