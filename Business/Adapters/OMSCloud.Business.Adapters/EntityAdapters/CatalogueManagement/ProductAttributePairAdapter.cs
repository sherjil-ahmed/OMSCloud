
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
    public partial class ProductAttributePairAdapter
    {
        #region Select
        public List<ProductAttributePairModel> GetListByPage(int PageNum, int PageSize_RowCount, string searchString)
        {
            string[] filters = searchString.Split(',');


            var total = uow.OMSContext.ProductAttributePair.Select(p => p.ProductAttributePairID).Count();
            var skip = PageSize_RowCount * (PageNum - 1);
            var cantPage = skip > total;

            if (cantPage) // do what you wish if you can page no further
                return new List<ProductAttributePairModel>();
            var productAttributePairList = uow.OMSContext.ProductAttributePair.Select(a => a)
                .OrderBy(a => a.ProductAttributePairID)
                .Skip(skip)
                .Take(PageSize_RowCount)
                .ToList();

            var result = (from a in productAttributePairList select GetProductAttributePairModel(a)).ToList();

            return result;
        }

        public List<ProductAttributePairModel> GetProductAttributePairList()
        {
            var result = (from pa in uow.OMSContext.ProductAttributePair
                          select new ProductAttributePairModel
                          {
                              ProductAttributePairID = pa.ProductAttributePairID,
                              ProductID = pa.ProductID,
                              AttributeID = pa.AttributeID,
                              AttributeValue = pa.AttributeValue,
                              AttributeName = pa.Attribute.AttributeTitle,
                              ProductName = pa.Product.ProductTitle,
                              DisplayOrder = pa.DisplayOrder ?? 0,
                              IsAssigned = pa.IsAssigned,
                              IsSelectedForVariation = pa.IsSelectedForVariation,
                              VariationInPrice = pa.VariationInPrice
                          }).ToList();
            return result;
        }

        public List<ProductAttributePairModel> GetListByProductId(long Id)
        {//it is called by admin on Product edit page - attribute tab
            var listByProductId = (from pa in uow.OMSContext.ProductAttributePair
                                   where pa.ProductID == Id //&& pa.IsAssigned == true
                                   orderby pa.DisplayOrder
                                   select new ProductAttributePairModel
                                   {
                                       ProductAttributePairID = pa.ProductAttributePairID,
                                       ProductID = pa.ProductID,
                                       AttributeID = pa.AttributeID,
                                       AttributeValue = pa.AttributeValue,
                                       AttributeName = pa.Attribute.AttributeTitle,
                                       ProductName = pa.Product.ProductTitle,
                                       DisplayOrder = pa.DisplayOrder ?? 0,
                                       IsAssigned = pa.IsAssigned,
                                       IsSelectedForVariation = pa.IsSelectedForVariation,
                                       VariationInPrice = pa.VariationInPrice
                                   }).ToList();
            return listByProductId;
        }

        public List<ProductAttributePairModel> GetAllAttributesByProductId(long Id, DBAttributeTypeEnum? attributeType = null, bool ? isAssigned = null)
        {//it is called by public site , product creation wizaard - Attribute Tab
            var listByProductId = (from pa in uow.OMSContext.ProductAttributePair
                                   where pa.ProductID == Id 
                                   select new ProductAttributePairModel
                                   {
                                       ProductAttributePairID = pa.ProductAttributePairID,
                                       ProductID = pa.ProductID,
                                       AttributeID = pa.AttributeID,
                                       AttributeValue = pa.AttributeValue,
                                       AttributeName = pa.Attribute.AttributeTitle,
                                       ProductName = pa.Product.ProductTitle,
                                       DisplayOrder = pa.DisplayOrder ?? 0,
                                       IsAssigned = pa.IsAssigned,
                                       IsSelectedForVariation = pa.IsSelectedForVariation,
                                       VariationInPrice = pa.VariationInPrice,
                                       AttributeTypeID = pa.Attribute.AttributeTypeID,
                                   });
            if (attributeType.HasValue)
            {
                listByProductId = listByProductId.Where(pa => pa.AttributeTypeID == (int)attributeType.Value);
            }
            if (isAssigned.HasValue)
            {
                listByProductId = listByProductId.Where(pa => pa.IsAssigned == isAssigned.Value);
            }
            return listByProductId.ToList();
        }

        //public List<ProductAttributePairModel> GetAssignedAttributesByProductId(long Id, DBAttributeTypeEnum? attributeType = null, bool? isAssigned = null)
        //{
        //    var listByProductId = (from pa in uow.OMSContext.ProductAttributePair
        //                           where
        //                                pa.ProductID == Id &&
        //                                pa.IsAssigned == true
        //                           select new ProductAttributePairModel
        //                           {
        //                               ProductAttributePairID = pa.ProductAttributePairID,
        //                               ProductID = pa.ProductID,
        //                               AttributeID = pa.AttributeID,
        //                               AttributeValue = pa.AttributeValue,
        //                               AttributeName = pa.Attribute.AttributeTitle,
        //                               ProductName = pa.Product.ProductTitle,
        //                               DisplayOrder = pa.DisplayOrder ?? 0,
        //                               IsAssigned = pa.IsAssigned,
        //                               IsSelectedForVariation = pa.IsSelectedForVariation,
        //                               VariationInPrice = pa.VariationInPrice,
        //                               AttributeTypeID = pa.Attribute.AttributeTypeID,
        //                           });
        //    if (attributeType.HasValue)
        //    {
        //        listByProductId = listByProductId.Where(pa => pa.AttributeTypeID == (int)attributeType);
        //    }
        //    if (isAssigned.HasValue)
        //    {
        //        listByProductId = listByProductId.Where(pa => pa.IsAssigned == isAssigned.Value);
        //    }
        //    return listByProductId.ToList();
        //}
        #endregion Select

        #region Update

        public bool UpdateProductAttributePair(ProductAttributePairModel productAttributePairModel)
        {
            try
            {
                var productAttributePair = UpdateConcurrency(GetEntity(productAttributePairModel), productAttributePairModel);
                var recordsCount = uow.OMSContext.ProductAttributePair_Update(productAttributePair);
                return recordsCount > 0;
            }
            catch(Exception ex)
            {

                return false;
            }
            finally
            {
            }
        }
        public bool UpdateIsAssigned(ProductAttributePairModel productAttributePairModel)
        {
            try
            {//saves attribute in product
                var productAttributePair = UpdateConcurrency(GetEntity(productAttributePairModel), productAttributePairModel);
                var recordsCount = uow.OMSContext.ProductAttributePair_UpdateIsAssigned(productAttributePair);
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

        public long? AddProductAttributePair(ProductAttributePairModel productAttributePairModel)
        {
            try
            {
                var outParam = new ObjectParameter("ProductAttributePairID", typeof(int));

                var productAttributePair = UpdateConcurrency(GetEntity(productAttributePairModel), productAttributePairModel);
                var recordsCount = uow.OMSContext.ProductAttributePair_Insert(productAttributePair, outParam);
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

        #region Private
        private ProductAttributePairModel GetProductAttributePairModel(ProductAttributePair productModel)
        {
            return new ProductAttributePairModel()
            {
                ProductAttributePairID = productModel.ProductAttributePairID,
                ProductID = productModel.ProductID,
                AttributeID = productModel.AttributeID,
                AttributeValue = productModel.AttributeValue,
                DisplayOrder = productModel.DisplayOrder ?? 0,
                IsAssigned = productModel.IsAssigned,
                IsSelectedForVariation = productModel.IsSelectedForVariation,
                VariationInPrice = productModel.VariationInPrice
            };
        }
        private ProductAttributePair GetProductAttributePairEntity(ProductAttributePairModel product)
        {
            return new ProductAttributePair()
            {
                AttributeID = product.AttributeID,
                AttributeValue = product.AttributeValue,
                ProductAttributePairID = product.ProductAttributePairID,
                ProductID = product.ProductID,
                DisplayOrder = product.DisplayOrder,
                IsAssigned = product.IsAssigned,
                IsSelectedForVariation = product.IsSelectedForVariation,
                VariationInPrice = product.VariationInPrice
            };
        }
        #endregion
    }
}
