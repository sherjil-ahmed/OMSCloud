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
    public partial class AttributeTypeBusinessComponent 
    {
        public List<AttributeTypeModel> GetAttributeTypeList()
        {
            return adapter.GetAttributeTypeList();
        }
        public AttributeTypeModel GetAttributeTypeById(long Id)
        {
            return adapter.GetAttributeTypeById(Id);
        }
        public long? AddAttributeType(AttributeTypeModel attributeTypeModel)
        {
            return adapter.AddAttributeType(attributeTypeModel);
        }
        public bool UpdateAttributeType(AttributeTypeModel attributeTypeModel)
        {
            return adapter.UpdateAttributeType(attributeTypeModel);
        }
        public bool DeleteAttributeType(AttributeTypeModel attributeTypeModel)
        {
            return adapter.DeleteAttributeType(attributeTypeModel);
        }
    }
}
