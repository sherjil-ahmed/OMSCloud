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
    public partial class CategoryBusinessComponent
    {
        //
        public List<CategoryModel> GetCategoryList()
        {
            return adapter.GetCategoryList();
        }

        public List<CategoryLookupModel> GetCategoryListLookup()
        {
            return adapter.GetCategoryListLookup();
        }

        public List<CategoryLookupModel> GetCategoryListNotAssociatedWithProductId(long Id)
        {
            return adapter.GetCategoryListNotAssociatedWithProductId(Id);
        }

        public long? AddCategory(CategoryModel category)
        {
            return adapter.AddCategory(category);
        }
        public bool UpdateCategory(CategoryModel category)
        {
            return adapter.UpdateCategory(category);
        }
        public CategorySearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString,string sortOrder)
        {
            return adapter.GetListByPage(PageNum, PageSize_RowCount, searchString, sortOrder);
        }
    }
}
