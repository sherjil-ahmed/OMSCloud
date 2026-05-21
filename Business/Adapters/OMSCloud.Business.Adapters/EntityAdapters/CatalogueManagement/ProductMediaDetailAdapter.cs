using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.UnitofWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class ProductMediaDetailAdapter
    {
        #region Select
        public List<ProductMediaDetailModel> GetProductMediaDetailList()
        {
            var productMediaDetailList = uow.ProductMediaDetailRepository.GetAll().Select(a => GetProductMediaDetailModel(a)).ToList();
            return productMediaDetailList;
        }

        public ProductMediaDetailModel GetProductMediaDetailById(long Id)
        {
            var productMediaDetail = uow.ProductMediaDetailRepository.GetById(Id);
            if (productMediaDetail != null)
            {
                var productMediaDetailModel = GetModelWithConcurrency(productMediaDetail, GetProductMediaDetailModel(productMediaDetail));
                return productMediaDetailModel;
            }
            else
            { return null; }
        }
        public List<ProductMediaDetailModel> GetProductMediaDetailByStatus(DBStatusEnum status)
        {
            var result = from ProductMediaDetail in uow.ProductMediaDetailRepository.OMSContext.ProductMediaDetail
                         where ProductMediaDetail.StatusID == (int)status
                         select GetModelWithConcurrency(ProductMediaDetail, GetProductMediaDetailModel(ProductMediaDetail));
            return result.ToList();
        }

        #endregion Select

        #region Update

        public bool UpdateProductMediaDetail(ProductMediaDetailModel productMediaDetailModel)
        {
            try
            {
                var prodcutMediaDetail = UpdateConcurrency(GetEntity(productMediaDetailModel), productMediaDetailModel);
                var recordsCount = uow.OMSContext.ProductMediaDetail_Update(prodcutMediaDetail);
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

        public long? AddProductMediaDetail(ProductMediaDetailModel productMediaDetailModel)
        {
            try
            {
                var prodcutMediaDetail = UpdateConcurrency(GetEntity(productMediaDetailModel), productMediaDetailModel, false);
                var outParam = new ObjectParameter("ProductMediaID", typeof(int));
                var recordsCount = uow.OMSContext.ProductMediaDetail_Insert(prodcutMediaDetail, outParam);
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
        public bool DeleteProductMediaDetail(ProductMediaDetailModel productMediaDetailModel)
        {
            try
            {
                var productMediaDetail = GetProductMediaDetailEntity(productMediaDetailModel);
                uow.ProductMediaDetailRepository.Delete(productMediaDetail);
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
        private ProductMediaDetailModel GetProductMediaDetailModel(ProductMediaDetail productMediaDetail)
        {
            return new ProductMediaDetailModel()
            {
                ProductMediaID = productMediaDetail.ProductMediaID,
                ProductMediaTitle = productMediaDetail.ProductMediaTitle,
                Description = productMediaDetail.Description,
                MediaContentTypeID = productMediaDetail.MediaContentTypeID,
                MediaFilePath = productMediaDetail.MediaFilePath,
                ProductID = productMediaDetail.ProductID,
                Width = productMediaDetail.Width ?? 0,
                Height = productMediaDetail.Height ?? 0,
                TransparencyLevel = productMediaDetail.TransparencyLevel ?? 0,
                StatusID = productMediaDetail.StatusID,
                ApprovedByUserID = productMediaDetail.ApprovedByUserID,
                ApprovedDateTime = productMediaDetail.ApprovedDateTime,/*
                CreatedBy = productMediaDetail.CreatedByUserID,
                CreatedOn = productMediaDetail.CreatedDateTime,
                ModifiedBy = productMediaDetail.LastModifiedByUserID,
                ModifiedOn = productMediaDetail.LastModifiedDateTime,
                IsDefault = productMediaDetail.Description == "default",*/
            };
        }
        private ProductMediaDetail GetProductMediaDetailEntity(ProductMediaDetailModel productMediaDetail)
        {
            return new ProductMediaDetail()
            {
                ProductMediaID = productMediaDetail.ProductMediaID,
                ProductMediaTitle = productMediaDetail.ProductMediaTitle,
                Description = productMediaDetail.Description,
                MediaContentTypeID = productMediaDetail.MediaContentTypeID,
                MediaFilePath = productMediaDetail.MediaFilePath,
                ProductID = productMediaDetail.ProductID,
                Width = productMediaDetail.Width,
                Height = productMediaDetail.Height,
                TransparencyLevel = productMediaDetail.TransparencyLevel,
                StatusID = productMediaDetail.StatusID,
                ApprovedByUserID = productMediaDetail.ApprovedByUserID,
                ApprovedDateTime = productMediaDetail.ApprovedDateTime,/*
                CreatedByUserID= productMediaDetail.CreatedBy,
                CreatedDateTime = productMediaDetail.CreatedOn,
                LastModifiedByUserID = productMediaDetail.ModifiedBy,
                LastModifiedDateTime = productMediaDetail.ModifiedOn,
                //IsDefault = productMediaDetail.Description == "default",*/
            };
        }
        #endregion 
    }
}