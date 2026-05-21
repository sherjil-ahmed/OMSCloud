using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class CartItemAttributePairModel : BaseModel
    {
        public long CartItemAttributeID { get; set; }
        public long CartItemID { get; set; }
        public long AttributeID { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public string AttributeTypeName { get; set; }
        public long AttributeTypeId { get; set; }
        public double VariationInPrice { get; set; }
    }
}
