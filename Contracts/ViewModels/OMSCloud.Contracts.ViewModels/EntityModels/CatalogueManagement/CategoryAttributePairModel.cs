using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class CategoryAttributePairModel : BaseModel
    {

        [Display(Name = "Category Attribute Pair ID")]
        public long CategoryAttributePairID { get; set; }


        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Category ID")]
        public long CategoryID { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Category")]
        public string CategoryTitle { get; set; }


        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Attribute ID")]
        public long AttributeID { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Attribute")]
        public string AttributeTitle { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Attribute Value")]
        public string AttributeValue { get; set; }

        [Display(Name = "Display Order")]
        public Nullable<long> DisplayOrder { get; set; }

        [Display(Name = "Is Assigned")]
        public bool IsAssigned { get; set; }
    }

    public class CategoryAttributePairLookupModel //: BaseModel
    {
        public long CategoryAttributePairID { get; set; }
        public long AttributeID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Attribute")]
        public string AttributeTitle { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Attribute Value")]
        public String AttributeValue { get; set; }

        [Display(Name = "Display Order")]
        [DataType(DataType.Duration)]
        public long? DisplayOrder { get; set; }

        [Display(Name = "Is Assigned")]
        public bool IsAssigned { get; set; }
    }
    public class AttributeValueResponseModel
    {
        public long CategoryAttributePairID { get; set; }
        public string AttributeValue { get; set; }
    }
    public class AttributeValueRequestModel
    {
        public long CategoryId { get; set; }
        public long AttributeId { get; set; }
    }

}
