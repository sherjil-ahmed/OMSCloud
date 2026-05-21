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
    public partial class CategoryAdapter
    {
        #region Select

        public CategorySearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder)
        {
            var categoryResult = new CategorySearchResultAdminModel();
            var result = (from c in uow.OMSContext.Category
                          join pc in uow.OMSContext.Category on c.CategoryParentID equals pc.CategoryID into pcx
                          from pc in pcx.DefaultIfEmpty()
                              //join ct in uow.OMSContext.CategoryType on c.CategoryTypeID equals ct.CategoryTypeID
                          join s in uow.OMSContext.Status on c.StatusID equals s.StatusID
                          select new CategoryModel
                          {
                              CategoryID = c.CategoryID,
                              CategoryTitle = c.CategoryTitle,
                              CategoryParentTitle = pc.CategoryTitle,
                              StatusID = c.StatusID,
                              CategoryParentID = c.CategoryParentID,
                              CategoryTypeID = c.CategoryTypeID,
                              CategoryTypeTitle = c.CategoryType.Title,
                              StatusName = s.StatusName,
                              LogoPath = c.LogoPath,
                              Description = c.Description,
                              IsSystem = c.IsSystem,
                              CreatedBy = c.CreatedByUserID,
                              CreatedOn = c.CreatedDateTime,
                              ModifiedBy = c.LastModifiedByUserID,
                              ModifiedOn = c.LastModifiedDateTime,// ?? DateTime.MinValue
                          });
            #region // Searching Products
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower().Trim();
                result = result.Where(x => x.CategoryTitle.ToLower().Trim().Contains(searchString) || x.CategoryParentTitle.ToLower().Trim().Contains(searchString) || x.Description.ToLower().Trim().Contains(searchString));
            }
            #endregion

            #region // Sorting Products
            result = SortCategory(sortOrder, result);
            #endregion

            #region NewCodePaging
            var total = result.Count();
            if (total > 0)
            {
                var pages = (int)Math.Ceiling((double)total / PageSize_RowCount);
                pages = pages == 0 ? 1 : pages;
                var skip = PageSize_RowCount * (PageNum - 1);
                if (skip > total)
                    skip = total;
                var categoryList1 = result.Skip(skip).Take(PageSize_RowCount);//.ToList();
                var categoryList = categoryList1.ToList();
                var MaxPrice = 0.0d;
                var MinPrice = 0.0d;
                categoryResult = new CategorySearchResultAdminModel
                {
                    NumberOfPages = pages,
                    GrandRecordsCount = total,
                    CurrentPageMinIndex = skip + 1,
                    CurrentPageMaxIndex = categoryList.Count + skip,
                    MaxPrice = MaxPrice,
                    MinPrice = MinPrice,
                    CategoryList = categoryList,
                };
            }
            return categoryResult;

            #endregion
        }

        private static IQueryable<CategoryModel> SortCategory(string sortOrder, IQueryable<CategoryModel> returnCategorylist)
        {
            switch (sortOrder)
            {
                case "Category":
                    returnCategorylist = returnCategorylist.OrderBy(s => s.CategoryTitle);
                    break;
                case "Category_desc":
                    returnCategorylist = returnCategorylist.OrderByDescending(s => s.CategoryTitle);
                    break;
                case "CategoryType":
                    returnCategorylist = returnCategorylist.OrderBy(x => x.CategoryTypeID);
                    break;
                case "CategoryType_desc":
                    returnCategorylist = returnCategorylist.OrderByDescending(x => x.CategoryTypeID);
                    break;
                case "ParentCategory":
                    returnCategorylist = returnCategorylist.OrderBy(s => s.CategoryParentTitle);
                    break;
                case "ParentCategory_desc":
                    returnCategorylist = returnCategorylist.OrderByDescending(s => s.CategoryParentTitle);
                    break;
                case "Status":
                    returnCategorylist = returnCategorylist.OrderBy(s => s.StatusName);
                    break;
                case "Status_desc":
                    returnCategorylist = returnCategorylist.OrderByDescending(s => s.StatusName);
                    break;
                case "IsSystem":
                    returnCategorylist = returnCategorylist.OrderBy(s => s.IsSystem);
                    break;
                case "IsSystem_desc":
                    returnCategorylist = returnCategorylist.OrderByDescending(s => s.IsSystem);
                    break;
                default:
                    returnCategorylist = returnCategorylist.OrderBy(s => s.CategoryTitle);
                    break;
            }
            return returnCategorylist;
        }

        public List<CategoryModel> GetCategoryList()
        {
            var result = (from c in uow.OMSContext.Category
                          where c.StatusID <= (long)DBStatusEnum.Active
                          orderby c.CreatedDateTime
                          select new CategoryModel
                          {
                              CategoryID = c.CategoryID,
                              CategoryTitle = c.CategoryTitle,
                              CategoryParentID = c.CategoryParentID,
                              CategoryTypeID = c.CategoryTypeID,
                              Description = c.Description,
                              IsSystem = c.IsSystem,
                              LogoPath = c.LogoPath,
                              StatusID = c.StatusID,
                              ModifiedOn = c.LastModifiedDateTime,
                          });
            var categoryList = result.ToList();
            return categoryList;
        }

        /// <summary>
        /// It returns TOP LEVEL Lookup Model for categories which are active (i.e. available for Front End)
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CategoryLookupModel> GetCategoryListLookup()
        {
            var categoryList = (from c in uow.OMSContext.Category
                                where
                                    c.StatusID <= (int)DBStatusEnum.Active
                                    //&&
                                    //c.CategoryParentID == null
                                orderby c.CategoryTitle
                                select new CategoryLookupModel
                                {
                                    CategoryID = c.CategoryID,
                                    CategoryTitle = c.CategoryTitle,
                                    ParentCategoryID = c.CategoryParentID
                                    //Description = c.Description,
                                    //LogoPath = c.LogoPath,
                                    //CategoryTypeID = c.CategoryTypeID,
                                    //CategoryTypeTitle = c.CategoryType.Title
                                }).ToList();

            return categoryList;
        }

        public CategoryModel GetCategoryById(long Id)
        {
            var category = uow.CategoryRepository.GetById(Id);
            CategoryModel categorieModel = GetCategoryModel(category);
            return categorieModel;
        }

        public List<CategoryModel> GetCategoryByStatus(DBStatusEnum status)
        {
            var result = from category in uow.CategoryRepository.OMSContext.Category
                         where category.StatusID == (int)status
                         orderby category.CategoryTitle
                         select GetCategoryModel(category);
            return result.ToList();
        }

        public List<CategoryLookupModel> GetCategoryListNotAssociatedWithProductId(long Id)
        {
            var categoryList = (from c in uow.OMSContext.Category
                                where c.StatusID <= (int)DBStatusEnum.Active
                                //orderby c.CategoryTitle
                                select new CategoryLookupModel
                                {
                                    CategoryID = c.CategoryID,
                                    CategoryTitle = c.CategoryTitle
                                });

            var productCategoryList = (from pc in uow.OMSContext.ProductCategoryPair
                                       where pc.ProductID == Id
                                       select new CategoryLookupModel
                                       {
                                           CategoryID = pc.CategoryID,
                                           CategoryTitle = pc.Category.CategoryTitle
                                       });
            var result = categoryList.Except(productCategoryList).OrderBy(o => o.CategoryTitle).ToList();

            return result;
        }

        #endregion Select

        #region Update

        public bool UpdateCategory(CategoryModel categoryModel)
        {
            try
            {
                var Category = UpdateConcurrency(GetEntity(categoryModel), categoryModel);

                var recordsCount = uow.OMSContext.Category_Update(Category);

                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion Update

        #region Add

        public long? AddCategory(CategoryModel categoryModel)
        {
            try
            {
                var Category = UpdateConcurrency(GetEntity(categoryModel), categoryModel, false);

                var outParam = new ObjectParameter("CategoryID", typeof(int));


                var recordsCount = uow.OMSContext.Category_Insert(Category, outParam);

                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception EX)
            {
                return null;
            }
            finally
            {
            }
        }

        #endregion Add

        #region Delete
        public bool DeleteCategory(CategoryModel category)
        {
            try
            {
                var Category = GetCategoryEntity(category);
                uow.CategoryRepository.Delete(Category);
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

        public bool DeleteCategory(long Id)
        {
            try
            {
                uow.CategoryRepository.Delete(a => a.CategoryID == Id);
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
        private CategoryModel GetCategoryModel(Category category)
        {
            return new CategoryModel
            {
                CategoryID = category.CategoryID,
                CategoryTitle = category.CategoryTitle,
                CategoryParentID = category.CategoryParentID,
                CategoryTypeID = category.CategoryTypeID,
                Description = category.Description,
                IsSystem = category.IsSystem,
                LogoPath = category.LogoPath,
                StatusID = category.StatusID,
                ModifiedOn = category.LastModifiedDateTime,
            };
        }
        private Category GetCategoryEntity(CategoryModel categoryModel, bool isUpdate = true)
        {
            return new Category()
            {
                CategoryID = categoryModel.CategoryID,
                CategoryTitle = categoryModel.CategoryTitle,
                CategoryParentID = categoryModel.CategoryParentID,
                CategoryTypeID = categoryModel.CategoryTypeID,
                //CreatedByUserID = categoryModel.CreatedBy,
                //CreatedDateTime = categoryModel.CreatedOn,
                Description = categoryModel.Description,
                IsSystem = categoryModel.IsSystem,
                //LastModifiedByUserID = categoryModel.ModifiedBy,
                //LastModifiedDateTime = categoryModel.ModifiedOn,
                LogoPath = categoryModel.LogoPath,
                StatusID = categoryModel.StatusID
            };
        }
        #endregion Private

    }
}
