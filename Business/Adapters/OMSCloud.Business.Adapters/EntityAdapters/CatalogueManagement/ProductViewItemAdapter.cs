using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.UnitofWork;
using OMSCloud.DataStore.EF.OMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.Common.DBEnums;
using System.Data.Entity.Core.Objects;

namespace OMSCloud.Business.Adapters
{
    public partial class ProductViewItemAdapter
    {



        #region Select
        public List<ProductViewItemModel> GetProductViewItemList()
        {
            var productViewItemList = uow.ProductViewItemRepository.GetAll().OrderBy(o => o.Product.ProductTitle).Select(a => GetProductViewItemModel(a)).ToList();
            return productViewItemList;
        }

        public ProductViewItemModel GetProductViewItemById(long Id)
        {
            var productViewItem = uow.ProductViewItemRepository.GetById(Id);
            ProductViewItemModel producViewItemModel = GetProductViewItemModel(productViewItem);
            return producViewItemModel;
        }

        #endregion Select

        #region Update

        public bool UpdateProductViewItem(ProductViewItemModel productViewItemModel)
        {
            try
            {
                var productViewItem = UpdateConcurrency(GetEntity(productViewItemModel), productViewItemModel);
                var recordsCount = uow.OMSContext.ProductViewItem_Update(productViewItem);
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        #endregion Update

        #region Add

        public long? AddProductViewItem(ProductViewItemModel productViewItemModel)
        {
            try
            {
                var productViewItem = UpdateConcurrency(GetEntity(productViewItemModel), productViewItemModel, false);
                var outParam = new ObjectParameter("ProductViewProductID", typeof(int));
                var recordsCount = uow.OMSContext.ProductViewItem_Insert(productViewItem, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        #endregion Add

        #region Delete
        public bool DeleteProductViewItem(ProductViewItemModel productViewItemModel)
        {
            try
            {
                var productViewItem = GetProductViewItemEntity(productViewItemModel);
                uow.ProductViewItemRepository.Delete(productViewItem);
                uow.Commit();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion Delete

        #region Private
        private ProductViewItemModel GetProductViewItemModel(ProductViewItem productViewItem)
        {
            return new ProductViewItemModel()
            {
                ProductViewProductID = productViewItem.ProductViewProductID,
                ProductViewID = productViewItem.ProductViewID,
                ProductID = productViewItem.ProductID,
                ProductMediaID = productViewItem.ProductMediaID
            };
        }
        private ProductViewItem GetProductViewItemEntity(ProductViewItemModel productViewItemModel)
        {
            return new ProductViewItem()
            {
                ProductViewProductID = productViewItemModel.ProductViewProductID,
                ProductViewID = productViewItemModel.ProductViewID,
                ProductID = productViewItemModel.ProductID,
                ProductMediaID = productViewItemModel.ProductMediaID
            };
        }
        #endregion Private

    }
}