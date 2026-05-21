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
    public partial class ProductAttributePairBusinessComponent
    {
        public List<ProductAttributePairModel> GetProductAttributePairList()
        {
            return adapter.GetProductAttributePairList();
        }
        public List<ProductAttributePairModel> GetAllAttributesByProductId(long Id)
        {
            return adapter.GetAllAttributesByProductId(Id);
        }
        public List<ProductAttributePairModel> GetAssignedAttributesByProductId(long Id)
        {
            return adapter.GetAllAttributesByProductId(Id, null, true);
        }
        //public ProductAttributePairModel GetProductAttributePairById(long Id)
        //{
        //    return ProductAttributePairAdapter.GetProductAttributePairById(Id);
        //}
        public List<ProductAttributePairModel> GetListByProductId(long Id)
        {
            return adapter.GetListByProductId(Id);
        }
        public long? AddProductAttributePair(ProductAttributePairModel productAttributePair)
        {
            return adapter.AddProductAttributePair(productAttributePair);
        }
        public bool UpdateProductAttributePair(ProductAttributePairModel productAttributePair)
        {
            return adapter.UpdateProductAttributePair(productAttributePair);
        }
        //public bool DeleteProductAttributePair(ProductAttributePairModel productAttributePair)
        //{
        //    return ProductAttributePairAdapter.DeleteProductAttributePair(productAttributePair);
        //}
        public bool UpdateIsAssigned(ProductAttributePairModel model)
        {
            return adapter.UpdateIsAssigned(model);
        }
    }
}
