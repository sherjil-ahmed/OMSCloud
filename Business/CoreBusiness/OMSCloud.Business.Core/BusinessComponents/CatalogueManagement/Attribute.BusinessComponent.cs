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
    public partial class AttributeBusinessComponent
    {
        public AttributeSearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder)
        {
            return adapter.GetListByPage(PageNum, PageSize_RowCount, searchString, sortOrder);
        }

        public List<AttributeModel> GetAttributeList()
        {
            return adapter.GetAttributeList();
        }
        public AttributeModel GetAttributeById(long Id)
        {
            return adapter.GetAttributeById(Id);
        }
        public List<AttributeLookupModel> GetAttributeListNotAssociatedWithCategoryId(long Id)
        {
            //return adapter.GetAttributeListNotAssociatedWithCategoryId(Id);
            return adapter.GetAttributeLookupList();
        }
        public List<AttributeLookupModel> GetAttributeListNotAssociatedWithProductId(long Id)
        {
            //return adapter.GetAttributeListNotAssociatedWithProductId(Id);
            return adapter.GetAttributeLookupList();
        }

        public List<AttributeLookupModel> GetAttributeLookupList()
        {
            //return adapter.GetAttributeListNotAssociatedWithProductId(Id);
            return adapter.GetAttributeLookupList();
        }

        public long? AddAttribute(AttributeModel attribute)
        {
            return adapter.AddAttribute(attribute);
        }
        public bool UpdateAttribute(AttributeModel attribute)
        {
            return adapter.UpdateAttribute(attribute);
        }

        public AttributeModel GetAttributeByName(string attributeName)
        {
            return adapter.GetAttributeByName(attributeName);
        }
    }
}
