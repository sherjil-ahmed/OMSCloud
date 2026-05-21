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
    public partial class ProductMediaDetailBusinessComponent
    {
        public List<ProductMediaDetailModel> GetProductMediaDetailList()
        {
            return adapter.GetProductMediaDetailList();
        }
        public ProductMediaDetailModel GetProductMediaDetailById(long Id)
        {
            return adapter.GetProductMediaDetailById(Id);
        }
        public long? AddProductMediaDetail(ProductMediaDetailModel ProductMediaDetail)
        {
            return adapter.AddProductMediaDetail(ProductMediaDetail);
        }
        public bool UpdateProductMediaDetail(ProductMediaDetailModel ProductMediaDetail)
        {
            return adapter.UpdateProductMediaDetail(ProductMediaDetail);
        }
        public bool DeleteProductMediaDetail(ProductMediaDetailModel ProductMediaDetail)
        {
            return adapter.DeleteProductMediaDetail(ProductMediaDetail);
        }
    }
}
