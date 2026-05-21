using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ProductMediaDetailModel : ConcurrencyBaseModel
    {
        public long ProductMediaID { get; set; }
        public bool IsDefault { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product Media")]
        public string ProductMediaTitle { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Media Content Type ID")]
        public long MediaContentTypeID { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Media Content Type")]
        public string MediaContentTypeTitle { get; set; }


        [Display(Name = "Media File/URL")]
        public string MediaFilePath { get; set; }


        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product ID")]
        public long ProductID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product")]
        public string ProductTitle { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Media Content Width")]
        public int Width { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Media Content Height")]
        public int Height { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Transparency Level")]
        public int TransparencyLevel { get; set; }

        public long StatusID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status")]
        public string StatusTitle { get; set; }

        [Display(Name = "Approved By")]
        public long? ApprovedByUserID { get; set; }

        [Display(Name = "Approved On")]
        public DateTime? ApprovedDateTime { get; set; }
    }
    public class ProductImageDetailModel : ConcurrencyBaseModel
    {
        public long ProductMediaID { get; set; }
        public string ImageFileName { get; set; }
        public long ProductID { get; set; }
        public long StatusID { get; set; }
        public bool IsDefault { get; set; }
    }

    public class ProductMediaDetailLookupModel : BaseModel
    {
        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product Media ID")]
        public long ProductMediaID { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product Media")]
        public string ProductMediaTitle { get; set; }
    }

    public class ProductImageModel : BaseModel
    {
        public long ProductId { get; set; }
        public string ImageFileName { get; set; }
        public bool IsDefault { get; set; } = false;

    }
}
