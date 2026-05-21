using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ProductViewItemModel : BaseModel
    {

        [Display(Name = "Product View Item ID")]
        public long ProductViewProductID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product View ID")]
        public long ProductViewID { get; set; }

        [Display(Name = "Product View Name")]
        public string ProductViewName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Prodcut ID")]
        public long ProductID { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product Media ID")]
        public long ProductMediaID { get; set; }

        [Display(Name = "Product Media Name")]
        public string ProductMediaName { get; set; }
    }

    public class ProductViewItemWithMediaDetailModel : BaseModel
    {
        public List<string> DistinctProductViewList { get; set; }
        #region ProductView
        public long ProductViewItemID { get; set; }
        public long ProductViewID { get; set; }
        public string ProductViewTitle { get; set; }
        #endregion ProductView

        #region ProductRelatedDetail
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductMainImagePath { get; set; }
        public string ProductPriceRange { get; set; }
        public long ProductRating { get; set; }
        public string ProductAddress { get; set; }
        #endregion ProductRelatedDetail

        #region ProductMediaDetail
        public long ProductMediaID { get; set; }
        public string ProductMediaImagePath { get; set; }
        #endregion ProductMediaDetail
    }

    public class ProductViewAndItems : BaseModel
    {
        public List<string> ProductViewList { get; set; }
        public List<ProductViewItemWithMediaDetailModel> ProductViewItemList { get; set; }
    }
}
