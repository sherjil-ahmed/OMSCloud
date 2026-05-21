using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ProductAttributePairSaveModel : ProductAttributePairModel
    {
        public bool IsInsertOrUpdate { get; set; }
    }
    public class ProductAttributePairModel : BaseModel
    {
        public long ProductAttributePairID { get; set; }

        [Display(Name = "Product ID")]
        public long ProductID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Attribute ID")]
        public long AttributeID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Attribute Name")]
        public string AttributeName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Attribute Value")]
        public string AttributeValue { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }
        public bool IsAssigned { get; set; }
        public bool IsSelectedForVariation { get; set; }
        public double VariationInPrice { get; set; }
        public long AttributeTypeID { get; set; }
    }

    public class ProductAttributePairLookupModel : BaseModel
    {
        public long ProductAttributePairID { get; set; }
        public long ProductID { get; set; }
        public long AttributeID { get; set; }
        public long AttributeTypeID { get; set; }
        public string AttributeName { get; set; }
        public string AttributeValue { get; set; }
        public long DisplayOrder { get; set; }
        public bool IsSystemAttributeType { get; set; }
    }
}
