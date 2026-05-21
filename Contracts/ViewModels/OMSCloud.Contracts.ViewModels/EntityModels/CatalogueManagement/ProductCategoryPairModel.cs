using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public partial class ProductCategoryPairModel : BaseModel
    {

        [Display(Name = "Product Category Pair ID")]
        public long ProductCategoryPairID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product ID")]
        public long ProductID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Category ID")]
        public long CategoryID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Category")]
        public String CategoryTitle { get; set; }
    }
}
