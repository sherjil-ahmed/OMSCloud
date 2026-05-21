using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class CategoryModel : ConcurrencyBaseModel
    {

        [Display(Name = "Category ID")]
        public long CategoryID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Category")]
        public string CategoryTitle { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Category Type ID")]
        public long CategoryTypeID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Category Type")]
        public string CategoryTypeTitle { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Display(Name = "Category Parent ID")]
        public long? CategoryParentID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Parent Category")]
        public string CategoryParentTitle { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status ID")]
        public long StatusID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status")]
        public string StatusName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is System")]
        public bool IsSystem { get; set; }
    }

    public class CategoryLookupModel : BaseModel
    {
        public long CategoryID { get; set; }

        public string CategoryTitle { get; set; }
        public long? ParentCategoryID { get; set; }
    }

    public class CategoryLookupDetailModel : BaseModel
    {
        public long CategoryID { get; set; }

        public string CategoryTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string LogoPath { get; set; }

        public long CategoryTypeID { get; set; }

        public string CategoryTypeTitle { get; set; }
        public bool IsDefault { get; set; }
    }
    public partial class AllParentsByChildCategoryModel : BaseModel
    {
        public Nullable<long> CategoryID { get; set; }
        public Nullable<long> CategoryParentID { get; set; }
        public string CategoryTitle { get; set; }
    }
    public partial class AllInheritedAttributesByCategoryModel
    {
        public long AttributeID { get; set; }
        public string AttributeTitle { get; set; }
        public string AttributeValue { get; set; }
    }

    public partial class AllNonExistingParentsByChildCategoryModel
    {
        public Nullable<int> ProductID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string CategoryTitle { get; set; }
        public Nullable<int> AttributeID { get; set; }
        public string AttributeValue { get; set; }
    }

    public class CategorySearchResultAdminModel : SearchResultModel
    {
        public List<CategoryModel> CategoryList { get; set; }
    }
}
