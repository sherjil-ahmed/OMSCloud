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
    public partial class CategoryTypeBusinessComponent
    {
        public List<CategoryTypeModel> GetCategoryTypeList()
        {
            return adapter.GetCategoryTypeList();
        }
        public CategoryTypeModel GetCategoryTypeById(long Id)
        {
            return adapter.GetCategoryTypeById(Id);
        }
        public long? AddCategoryType(CategoryTypeModel categoryType)
        {
            return adapter.AddCategoryType(categoryType);
        }
        public bool UpdateCategoryType(CategoryTypeModel categoryType)
        {
            return adapter.UpdateCategoryType(categoryType);
        }
        public bool DeleteCategoryType(CategoryTypeModel categoryType)
        {
            return adapter.DeleteCategoryType(categoryType);
        }

    }
}
