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
    public partial class ProductTypeAdapter
    {
        #region Select
        public List<ProductTypeModel> GetProductTypeList()
        {
            var productTypeList = uow.ProductTypeRepository.GetAll().Select(a => GetProductTypeModel(a)).OrderBy(o => o.ProductTypeTitle).ToList();
            return productTypeList;
        }

        public ProductTypeModel GetProductTypeById(long Id)
        {
            var productType = uow.ProductTypeRepository.GetById(Id);
            ProductTypeModel productTypeModel = GetProductTypeModel(productType);
            return productTypeModel;
        }

        public List<ProductTypeModel> GetProductTypeByStatus(DBStatusEnum status)
        {
            var result = from productType in uow.ProductTypeRepository.OMSContext.ProductType
                         where productType.StatusID == (int)status
                         orderby productType.ProductTypeTitle
                         select GetProductTypeModel(productType);
            return result.ToList();
        }
        #endregion Select

        #region Update

        public bool UpdateProductType(ProductTypeModel productTypeModel)
        {
            try
            {
                var productType = UpdateConcurrency(GetEntity(productTypeModel), productTypeModel);
                var recordsCount = uow.OMSContext.ProductType_Update(productType);
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

        public long? AddProductType(ProductTypeModel productTypeModel)
        {
            try
            {
                var productType = UpdateConcurrency(GetEntity(productTypeModel), productTypeModel, false);
                var outParam = new ObjectParameter("ProductTypeID", typeof(int));
                var recordsCount = uow.OMSContext.ProductType_Insert(productType, outParam);
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
        public bool DeleteProductType(ProductTypeModel productTypeModel)
        {
            try
            {
                var productType = GetProductTypeEntity(productTypeModel);
                uow.ProductTypeRepository.Delete(productType);
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
        private ProductTypeModel GetProductTypeModel(ProductType productType)
        {
            return new ProductTypeModel()
            {
                ProductTypeID = productType.ProductTypeID,
                ProductTypeTitle = productType.ProductTypeTitle,
                ProductTypeDescription = productType.ProductTypeDescription,
                StatusID = productType.StatusID               
            };
        }
        private ProductType GetProductTypeEntity(ProductTypeModel productTypeModel)
        {
            return new ProductType()
            {
                ProductTypeID = productTypeModel.ProductTypeID,
                ProductTypeTitle = productTypeModel.ProductTypeTitle,
                ProductTypeDescription = productTypeModel.ProductTypeDescription,
                StatusID = productTypeModel.StatusID
            };
        }
        #endregion Private

    }
}