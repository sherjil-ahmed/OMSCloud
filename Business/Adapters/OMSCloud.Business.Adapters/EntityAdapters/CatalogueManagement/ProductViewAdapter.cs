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
    public partial class ProductViewAdapter
    {
        #region Select
        public List<ProductViewModel> GetProductViewList()
        {
            var productViewList = uow.ProductViewRepository.GetAll().Select(a => GetProductViewModel(a)).OrderBy(o => o.ProductViewTitle).ToList();
            return productViewList;
        }

        public ProductViewModel GetProductViewById(long Id)
        {
            var productView = uow.ProductViewRepository.GetById(Id);
            ProductViewModel productModel = GetProductViewModel(productView);
            return productModel;
        }

        public List<ProductViewModel> GetProductViewByStatus(DBStatusEnum status)
        {
            var result = from productView in uow.ProductViewRepository.OMSContext.ProductView
                         where productView.StatusID == (int)status
                         orderby productView.ProductViewTitle
                         select GetProductViewModel(productView);
            return result.ToList();
        }

        public ProductViewAndItems GetProductViewList(string productViewTitle)
        {
            var productViewAndItems = new ProductViewAndItems();
            var list = (from pv in uow.OMSContext.ProductView select pv).ToList();
            productViewAndItems.ProductViewList = (from pv in uow.OMSContext.ProductView
                                                   where pv.StatusID <= (long)DBStatusEnum.Active && pv.ProductViewTitle.ToLower().Contains(productViewTitle.ToLower())
                                                   select pv.ProductViewTitle + "#$" + pv.ProductViewID).Distinct().ToList();
            productViewAndItems.ProductViewItemList = (from pv in uow.OMSContext.ProductView
                                                       join pvi in uow.OMSContext.ProductViewItem on pv.ProductViewID equals pvi.ProductViewID
                                                       join pa in uow.OMSContext.ProductAttributePair on pvi.ProductID equals pa.ProductID
                                                       join a in uow.OMSContext.Attribute on pa.AttributeID equals a.AttributeID
                                                       where
                                                           pv.StatusID <= (int)DBStatusEnum.Active
                                                           &&
                                                           pv.ProductViewTitle.ToLower().Contains(productViewTitle.ToLower())
                                                           &&
                                                           a.AttributeTitle.ToLower().Contains("address")
                                                       orderby pv.ProductViewTitle, pvi.Product.ProductTitle
                                                       select new ProductViewItemWithMediaDetailModel
                                                       {
                                                           ProductViewID = pv.ProductViewID,
                                                           ProductViewTitle = pv.ProductViewTitle,
                                                           ProductID = pvi.ProductID,
                                                           ProductViewItemID = pvi.ProductViewProductID,
                                                           ProductMediaID = pvi.ProductMediaID,
                                                           ProductName = pvi.Product.ProductTitle,
                                                           ProductPriceRange = (pvi.Product.BasePrice ?? 0) + " - " + (pvi.Product.SellingPrice ?? 0),
                                                           ProductRating = pvi.Product.UserRating ?? 0,
                                                           ProductMainImagePath = pvi.Product.ProductImagePath,
                                                           ProductAddress = pa.AttributeValue,
                                                           ProductMediaImagePath = pvi.ProductMediaDetail.MediaFilePath
                                                       }).ToList();
            return productViewAndItems;
        }

        #endregion Select

        #region Update

        public bool UpdateProductView(ProductViewModel productViewModel)
        {
            try
            {
                var productView = UpdateConcurrency(GetEntity(productViewModel), productViewModel);
                var recordsCount = uow.OMSContext.ProductView_Update(productView);
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

        public long? AddProductView(ProductViewModel productViewModel)
        {
            try
            {
                var productView = UpdateConcurrency(GetEntity(productViewModel), productViewModel, false);
                var outParam = new ObjectParameter("ProductViewID", typeof(int));
                var recordsCount = uow.OMSContext.ProductView_Insert(productView, outParam);
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
        public bool DeleteProductView(ProductViewModel productViewModel)
        {
            try
            {
                var productView = GetProductViewEntity(productViewModel);
                uow.ProductViewRepository.Delete(productView);
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
        private ProductViewModel GetProductViewModel(ProductView productView)
        {
            return new ProductViewModel()
            {
                ProductViewID = productView.ProductViewID,
                ProductViewTitle = productView.ProductViewTitle,
                Description = productView.Description,
                StatusID = productView.StatusID
            };
        }
        private ProductView GetProductViewEntity(ProductViewModel productViewModel)
        {
            return new ProductView()
            {
                ProductViewID = productViewModel.ProductViewID,
                ProductViewTitle = productViewModel.ProductViewTitle,
                Description = productViewModel.Description,
                StatusID = productViewModel.StatusID
            };
        }
        #endregion Private

    }
}