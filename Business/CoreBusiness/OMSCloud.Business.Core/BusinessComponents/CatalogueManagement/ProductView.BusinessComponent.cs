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
    public partial class ProductViewBusinessComponent
    {
        public List<ProductViewModel> GetProductViewList()
        {
            return adapter.GetProductViewList();
        }
        public ProductViewModel GetProductViewById(long Id)
        {
            return adapter.GetProductViewById(Id);
        }

        public ProductViewAndItems GetProductViewList(string productViewTitle)
        {
            return adapter.GetProductViewList(productViewTitle);
        }

        public long? AddProductView(ProductViewModel ProductView)
        {
            return adapter.AddProductView(ProductView);
        }
        public bool UpdateProductView(ProductViewModel ProductView)
        {
            return adapter.UpdateProductView(ProductView);
        }
        public bool DeleteProductView(ProductViewModel ProductView)
        {
            return adapter.DeleteProductView(ProductView);
        }
    }
}
