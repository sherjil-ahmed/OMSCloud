using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class PackagedProductModel : BaseModel
    {
        public long PackageID { get; set; }


        [DisplayName("Product ID")]
        public long ProductID { get; set; }


        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [DisplayName("Product Name")]
        public string ProductTitle { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Sub Product ID")]
        public long ChildProductID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [DisplayName("Sub Product Name")]
        public string ChildProductTitle { get; set; }


        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [DisplayName("Quantity")]
        public long Quantity { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [DisplayName("Included By Default")]
        public bool IncludedByDefault { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        [DisplayName("Percentage Price")]
        public double? PercentagePrice { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [DisplayName("Other Details")]
        public string OtherDetails { get; set; }
    }
}
