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
    public partial class ProductViewItemBusinessComponent
    {
        public List<ProductViewItemModel> GetProductViewItemList()
        {
            return adapter.GetProductViewItemList();
        }
        public ProductViewItemModel GetProductViewItemById(long Id)
        {
            return adapter.GetProductViewItemById(Id);
        }
        public long? AddProductViewItem(ProductViewItemModel ProductViewItem)
        {
            return adapter.AddProductViewItem(ProductViewItem);
        }
        public bool UpdateProductViewItem(ProductViewItemModel ProductViewItem)
        {
            return adapter.UpdateProductViewItem(ProductViewItem);
        }
        public bool DeleteProductViewItem(ProductViewItemModel ProductViewItem)
        {
            return adapter.DeleteProductViewItem(ProductViewItem);
        }
    }
}
