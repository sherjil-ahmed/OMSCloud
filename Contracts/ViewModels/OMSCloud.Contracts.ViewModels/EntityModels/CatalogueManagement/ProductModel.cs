using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ProductTaxInfoModel
    {
        public long ShopCountryId { get; set; }
        public long ShopProvinceId { get; set; }
        public long ShopCityId { get; set; }
        public bool IsTaxPercentage { get; set; }
        public long TaxTypeID { get; set; }
        public double TaxRateApplied { get; set; }
    }
    public class CartItemProductModel : BaseModel
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string BrifeDescription { get; set; }
        public double UnitPrice { get; set; }
        public bool IsTaxPercentage{ get; set; }
        public long TaxTypeID { get; set; }
        public double TaxRateApplied { get; set; }
        public double TaxAmount { get; set; }
        public double DiscountValue { get; set; }
        public bool IsDiscountPercentage { get; set; } = true;
        public double ItemTotalPrice { get; set; }
        public long ShopId { get; set; }
        public long ShopProfileID { get; set; }
        [Display(Name = "Shop Name")]
        public string ShopName { get; set; }
        public long ShopCountryId { get; set; }
        public long ShopProvinceId { get; set; }
        public long ShopCityId { get; set; }
        [Display(Name = "Brand")]
        public string BrandName { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; }
        [Display(Name = "Status")]
        public string StatusName { get; set; }
    }
    public class ProductModel : ConcurrencyBaseModel
    {
        public long ProductID { get; set; }

        [Required(ErrorMessage = "Enter Product Title Please")]
        [Display(Name = "Product")]
        public string ProductTitle { get; set; }

        //[Required(ErrorMessage = "Enter Brife Description Please")]
        [Display(Name = "Product Tags")]
        [DataType(DataType.MultilineText)]
        public string BrifeDescription { get; set; }

        public long CategoryID { get; set; }
        public string CategoryName { get; set; }
        [Display(Name = "Product Actual Image")]
        public string ProductActualImagePath { get; set; }

        [Display(Name = "Product Thumbnail")]
        public string ProductImagePath { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Enter Total Stock Please")]
        [Display(Name = "Stock Count")]
        public long StockCount { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Web Link")]
        public string WebLink { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Enter Shop Price Please")]
        [Display(Name = "Price receive by Shop")]
        public double BasePrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Enter Buyer Price Please")]
        [Display(Name = "Price for Buyer")]
        public double SellingPrice { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Enter Order Response Time Please")]
        [Display(Name = "Order Response Time Duration")]
        public long OrderResponseTime { get; set; }

        [Required(ErrorMessage = "Enter Order Response Time Unit Please")]
        [Display(Name = "Order Response Time Unit")]
        public string OrderResponseTimeUnitID { get; set; }

        [Display(Name = "Discount")]
        public double? DiscountValue { get; set; }

        [Display(Name = "Percentage?")]
        public bool IsDiscountPercentage { get; set; } = true;

        [Required(ErrorMessage = "Select Tax Type Please")]
        [Display(Name = "Tax Type")]
        public string TaxTypeTitle { get; set; }

        public long TaxTypeID { get; set; }

        [Range(0, 5, ErrorMessage = "Please enter Number between 0-5")]
        [Display(Name = "User Rating")]
        public int? UserRating { get; set; } = 0;

        [Range(0, 10, ErrorMessage = "Please enter Number between 0-10")]
        //[Required(ErrorMessage = "Enter Analysis Rank Please")]
        [Display(Name = "Analysis Rank")]
        public int? AnalysisRank { get; set; } = 0;

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product Type ID")]
        public long ProductTypeID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Brand ID")]
        public long BrandID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Shop ID")]
        public long SupplierID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Shop")]
        public string SupplierName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status ID")]
        public long StatusID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status")]
        public string StatusName { get; set; }
        public string ExpectedDeliveryInfo { get; set; }
        public long ShopStatusId { get; set; }
        public bool IsReviewInputAllowed { get; set; } = true;
    }

    public class ProductBasicInfoModel : ConcurrencyBaseModel
    {
        public long ProductID { get; set; }

        [Required(ErrorMessage = "Enter Product Title Please")]
        [Display(Name = "Product")]
        public string ProductTitle { get; set; }

        //[Required(ErrorMessage = "Enter Brife Description Please")]
        [Display(Name = "Breif Description")]
        [DataType(DataType.MultilineText)]
        public string BrifeDescription { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product Type ID")]
        public long ProductTypeID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product Type")]
        public string ProductTypeName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Brand ID")]
        public long BrandID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Brand")]
        public string BrandName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Shop ID")]
        public long SupplierID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Shop")]
        public string SupplierName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status ID")]
        public long StatusID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status")]
        public string StatusName { get; set; }
    }

    public class ProductImagesModel : BaseModel
    {
        public long ProductID { get; set; }
        [Display(Name = "Product Actual Image")]
        public string ProductActualImagePath { get; set; }

        [Display(Name = "Product Thumbnail")]
        public string ProductImagePath { get; set; }


    }

    public class ProductPricingModel : BaseModel
    {
        public long ProductID { get; set; }

        [Display(Name = "Price receive by Shop")]
        public double BasePrice { get; set; }

        [Display(Name = "Price for Buyer")]
        public double SellingPrice { get; set; }

        public long OrderResponseTime { get; set; }

        public string OrderResponseTimeUnitID { get; set; }

        public double? DiscountValue { get; set; }

        public bool IsDiscountPercentage { get; set; } = true;

        public long TaxTypeID { get; set; }
    }

    public class ProductLookupModel : BaseModel
    {
        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product ID")]
        public long ProductID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Product Name")]
        public string ProductTitle { get; set; }
        public string ThumbnailImage { get; set; }
        public long StatusId { get; set; }
    }

    public class ProductDetailModel : ProductModel
    {
        public List<CategoryLookupDetailModel> CategoryList { get; set; }
        public CategoryLookupModel Category { get; set; }
        public List<ProductAttributePairModel> AttributeList { get; set; }
        public List<ProductImageDetailModel> ProductImages { get; set; }
        
        //public List<string> ProductDetailBannerList { get; set; }
        //public string Description { get; set; }
    }

}
