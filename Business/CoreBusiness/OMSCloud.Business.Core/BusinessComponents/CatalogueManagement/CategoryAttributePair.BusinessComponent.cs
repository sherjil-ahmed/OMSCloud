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
    public partial class CategoryAttributePairBusinessComponent
    {
        public List<CategoryAttributePairModel> GetCategoryAttributePairList()
        {
            return adapter.GetCategoryAttributePairList();
        }

        public List<CategoryAttributePairLookupModel> GetListByCategoryId(long Id)
        {
            return adapter.GetListByCategoryId(Id);
        }

        public long? AddCategoryAttributePair(CategoryAttributePairModel categoryAttributePair)
        {
            return adapter.AddCategoryAttributePair(categoryAttributePair);
        }

        public bool UpdateCategoryAttributePair(CategoryAttributePairModel categoryAttributePair)
        {
            return adapter.UpdateCategoryAttributePair(categoryAttributePair);
        }
        public List<AttributeValueResponseModel> GetCategoryAttrobutePairList(long categoryId, long attributeId)
        {
            return adapter.GetCategoryAttrobutePairList(categoryId, attributeId);
        }
    }
}
