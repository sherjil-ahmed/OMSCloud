using OMSCloud.Contracts.Common.DBEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class AttributeModel : ConcurrencyBaseModel
    {
        [Display(Name = "Attribute ID")]
        public long AttributeID { get; set; }

        [Display(Name = "Attribute")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        public string AttributeTitle { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Data Type ID")]
        public long DataTypeID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Data Type")]
        public string DataTypeTitle { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Data Type Size")]
        public long DataTypeSize { get; set; }

        [Display(Name = "Default Value")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        public string DefaultValue { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is Mandatory")]
        public bool IsMandatory { get; set; }

        public bool IsMultiSelect { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status ID")]
        public long StatusID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status")]
        public string StatusTitle { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Attribute Type ID")]
        public long AttributeTypeID { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is System")]
        public bool IsSystem { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Attribute Type")]
        public string AttributeTypeTitle { get; set; }
    }
    public class AttributeLookupModel : BaseModel
    {

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

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Display Order")]
        public long DisplayOrder { get; set; }
    }

    public class AttributeSearchResultAdminModel : SearchResultModel
    {
        public List<AttributeModel> AttributeList { get; set; }
    }
}
