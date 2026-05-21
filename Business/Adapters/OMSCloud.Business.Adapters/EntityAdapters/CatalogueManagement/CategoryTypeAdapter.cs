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
    public partial class CategoryTypeAdapter
    {
        #region Select
        public List<CategoryTypeModel> GetCategoryTypeList()
        {
            var categoryTypeList = uow.CategoryTypeRepository.GetAll().OrderBy(o => o.Title).Select(a => GetCategoryTypeModel(a)).ToList();
            return categoryTypeList;
        }
        public CategoryTypeModel GetCategoryTypeById(long Id)
        {
            var CategoryType = uow.CategoryTypeRepository.GetById(Id);
            CategoryTypeModel categoryTypeMOdel = GetCategoryTypeModel(CategoryType);
            return categoryTypeMOdel;
        }
        public List<CategoryTypeModel> GetCategoryTypeByStatus(DBStatusEnum status)
        {
            var result = from categoryType in uow.CategoryTypeRepository.OMSContext.CategoryType
                         where categoryType.StatusID == (int)status
                         orderby categoryType.Title
                         select GetCategoryTypeModel(categoryType);
            return result.ToList();
        }
        #endregion Select

        #region Update

        public bool UpdateCategoryType(CategoryTypeModel categoryTypeModel)
        {
            try
            {
                var categoryType = UpdateConcurrency(GetEntity(categoryTypeModel), categoryTypeModel);
                var recordsCount = uow.OMSContext.CategoryType_Update(categoryType);

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
        public long? AddCategoryType(CategoryTypeModel categoryTypeModel)
        {
            try
            {
                var outParam = new ObjectParameter("CategoryTypeID", typeof(int));

                var categoryType = UpdateConcurrency(GetEntity(categoryTypeModel), categoryTypeModel);
                var recordsCount = uow.OMSContext.CategoryType_Insert(categoryType, outParam);

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
        public bool DeleteCategoryType(CategoryTypeModel categoryTypeModel)
        {
            try
            {
                var CategoryType = GetCategoryTypeEntity(categoryTypeModel);
                uow.CategoryTypeRepository.Delete(CategoryType);
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
        private CategoryTypeModel GetCategoryTypeModel(CategoryType categoryType)
        {
            return new CategoryTypeModel()
            {
                CategoryTypeID = categoryType.CategoryTypeID,
                Description = categoryType.Description,
                StatusID = categoryType.StatusID,
                Title = categoryType.Title
            };
        }
        private CategoryType GetCategoryTypeEntity(CategoryTypeModel categoryTypeModel)
        {
            return new CategoryType()
            {
                CategoryTypeID = categoryTypeModel.CategoryTypeID,
                Description = categoryTypeModel.Description,
                StatusID = categoryTypeModel.StatusID,
                Title = categoryTypeModel.Title
            };
        }
        #endregion Private

    }
}
