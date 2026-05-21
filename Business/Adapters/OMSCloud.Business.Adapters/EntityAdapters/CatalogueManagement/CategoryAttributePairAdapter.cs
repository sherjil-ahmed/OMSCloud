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
    public partial class CategoryAttributePairAdapter
    {
        #region Select

        public List<CategoryAttributePairModel> GetListByPage(int PageNum, int PageSize_RowCount, string searchString)
        {
            string[] filters = searchString.Split(',');


            var total = uow.OMSContext.CategoryAttributePair.Select(p => p.CategoryAttributePairID).Count();
            var skip = PageSize_RowCount * (PageNum - 1);
            var cantPage = skip > total;

            if (cantPage) // do what you wish if you can page no further
                return new List<CategoryAttributePairModel>();
            var categoryAttributePairList = uow.OMSContext.CategoryAttributePair.Select(a => a)
                .OrderBy(a => a.CategoryID + "" + a.AttributeID)
                .Skip(skip)
                .Take(PageSize_RowCount)
                .ToList();

            var result = (from a in categoryAttributePairList select GetCategoryAttributePairModel(a)).ToList();

            return result;
        }

        public CategoryAttributePairModel GetCategoryAttributePairById(long Id)
        {
            var categoryAttributePair = uow.CategoryAttributePairRepository.GetById(Id);
            CategoryAttributePairModel categoryAttributePairMOdel = GetCategoryAttributePairModel(categoryAttributePair);
            return categoryAttributePairMOdel;
        }

        public List<CategoryAttributePairModel> GetCategoryAttributePairList()
        {
            var result = (from ca in uow.OMSContext.CategoryAttributePair
                          orderby ca.CategoryID
                          select new CategoryAttributePairModel
                          {
                              CategoryAttributePairID = ca.CategoryAttributePairID,
                              CategoryID = ca.CategoryID,
                              AttributeID = ca.AttributeID,
                              CategoryTitle = ca.Category.CategoryTitle,
                              AttributeTitle = ca.Attribute.AttributeTitle,
                              AttributeValue = ca.AttributeValue,
                              DisplayOrder = ca.DisplayOrder,
                              IsAssigned = ca.IsAssigned
                          }).ToList();
            return result;
        }
        public List<AllInheritedAttributesByCategoryModel> GetAttributeLookupList()
        {
            var result = (from ca in uow.OMSContext.CategoryAttributePair
                          where ca.IsAssigned == true
                          orderby ca.CategoryID
                          select new AllInheritedAttributesByCategoryModel
                          {
                              AttributeID = ca.AttributeID,
                              AttributeTitle = ca.Attribute.AttributeTitle,
                              AttributeValue = ca.AttributeValue,
                              //DisplayOrder = ca.DisplayOrder.HasValue ? ca.DisplayOrder.Value : 0,
                          }).Distinct().ToList();
            return result;
        }
        
        public List<CategoryAttributePairLookupModel> GetListByCategoryId(long Id)
        {
            var listByCategoryId = from ca in uow.OMSContext.CategoryAttributePair
                                   where ca.CategoryID == Id
                                   orderby ca.Attribute.AttributeTitle
                                   select new CategoryAttributePairLookupModel()
                                   {
                                       CategoryAttributePairID = ca.CategoryAttributePairID,
                                       AttributeTitle = ca.Attribute.AttributeTitle,
                                       AttributeValue = ca.AttributeValue,
                                       DisplayOrder = ca.DisplayOrder,
                                       AttributeID = ca.AttributeID,
                                       IsAssigned = ca.IsAssigned,
                                   };
            return listByCategoryId.ToList();
        }

        public List<AttributeValueResponseModel> GetCategoryAttrobutePairList(long categoryId, long attributeId)
        {
            var listByCategoryId = (from ca in uow.OMSContext.CategoryAttributePair
                                    where ca.CategoryID == categoryId && ca.AttributeID == attributeId
                                    orderby ca.DisplayOrder ascending
                                    select new AttributeValueResponseModel()
                                    {
                                        CategoryAttributePairID = ca.CategoryAttributePairID,
                                        AttributeValue = ca.AttributeValue
                                    });
            return listByCategoryId.ToList();
        }

        #endregion Select

        #region Update

        public bool UpdateCategoryAttributePair(CategoryAttributePairModel categoryAttributePairModel)
        {
            try
            {
                var CategoryAttributePair = UpdateConcurrency(GetEntity(categoryAttributePairModel), categoryAttributePairModel);
                var recordsCount = uow.OMSContext.CategoryAttributePair_Update(CategoryAttributePair);

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
        public long? AddCategoryAttributePair(CategoryAttributePairModel categoryAttributePairModel)
        {
            try
            {
                var outParam = new ObjectParameter("CategoryAttributePairID", typeof(int));

                var categoryAttributePair = UpdateConcurrency(GetEntity(categoryAttributePairModel), categoryAttributePairModel);
                var recordsCount = uow.OMSContext.CategoryAttributePair_Insert(categoryAttributePair, outParam);

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
        public bool DeleteCategoryAttributePair(CategoryAttributePairModel categoryAttributePairModel)
        {
            try
            {
                var CategoryAttributePair = GetCategoryAttributePairEntity(categoryAttributePairModel);
                uow.CategoryAttributePairRepository.Delete(CategoryAttributePair);
                uow.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion Delete

        #region Private
        private CategoryAttributePairModel GetCategoryAttributePairModel(CategoryAttributePair categoryAttributePair)
        {
            return new CategoryAttributePairModel
            {
                AttributeID = categoryAttributePair.AttributeID,
                CategoryAttributePairID = categoryAttributePair.CategoryAttributePairID,
                CategoryID = categoryAttributePair.CategoryID,
                AttributeValue = categoryAttributePair.AttributeValue,
                DisplayOrder = categoryAttributePair.DisplayOrder,
                IsAssigned = categoryAttributePair.IsAssigned
            };
        }
        private CategoryAttributePair GetCategoryAttributePairEntity(CategoryAttributePairModel categoryAttributePairModel)
        {
            return new CategoryAttributePair()
            {
                AttributeID = categoryAttributePairModel.AttributeID,
                CategoryAttributePairID = categoryAttributePairModel.CategoryAttributePairID,
                CategoryID = categoryAttributePairModel.CategoryID,
                AttributeValue = categoryAttributePairModel.AttributeValue,
                DisplayOrder = categoryAttributePairModel.DisplayOrder,
                IsAssigned = categoryAttributePairModel.IsAssigned

            };
        }
        #endregion Private
    }
}
