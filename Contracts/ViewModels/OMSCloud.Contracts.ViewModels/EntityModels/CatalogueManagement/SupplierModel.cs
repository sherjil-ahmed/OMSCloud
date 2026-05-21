using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ShopTaxInfoModel : ConcurrencyBaseModel
    {
        public long SupplierID { get; set; }
        public bool TaxConsent { get; set; }
        public string TaxRegistration { get; set; }
    }
    public class SupplierModel : ConcurrencyBaseModel
    {
        public long SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Logo { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public long StatusID { get; set; }
        public string StatusNotes { get; set; }
        public long BusinessAddressID { get; set; }
        public bool IsBusinessAddressVisible { get; set; }
        public Nullable<long> OperatingLanguageID { get; set; }
        public Nullable<long> OperatingCurrencyID { get; set; }
        public long CountryID { get; set; }
        public long ProvinceID { get; set; }
        public long CityID { get; set; }
        public bool IsCOD { get; set; }
        public long ProfileID { get; set; }
        public double ProcessingFee { get; set; }
        public double PaymentGatewayFee { get; set; }
        public bool IsProcessingFeePercentage { get; set; }
        public bool IsPaymentGatewayFeePercentage { get; set; }
        public string WebLinksJSON { get; set; }
        public string AnnouncementHTML { get; set; }
        public string PolicyHTML { get; set; }
        public string FAQHTML { get; set; }
        public string CategoryRequests { get; set; }
        public string AttributeRequests { get; set; }
        public bool IsRequestedCategoryOrAttribute { get; set; } = false;
    }
    public class AttributeRequestModel : ConcurrencyBaseModel
    {
        public long SupplierID { get; set; }
        public string AttributeRequests { get; set; }
    }
    public class CategoryRequestModel : ConcurrencyBaseModel
    {
        public long SupplierID { get; set; }
        public string CategoryRequests { get; set; }
    }
    public class CategoryAttributeRequestModel : ConcurrencyBaseModel
    {
        public long SupplierID { get; set; }
        public string CategoryRequests { get; set; }
        public string AttributeRequests { get; set; }
    }
    public class ShopPublicProfileSummaryModel : ConcurrencyBaseModel
    {
        public long ShopID { get; set; }
        public string ShopName { get; set; }
        public long ShopOwnerProfileId { get; set; }
        public string ShopOwnerName { get; set; }
        public string ShopOwnerImage { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public bool IsBusinessAddressVisible { get; set; }
        public string Logo { get; set; }
        public string WebLinksJSON { get; set; }
        public double ShopRating { get; set; }
        public long StatusID { get; set; }
        public string Description { get; set; }
        public bool IsReviewInputAllowed { get; set; } = false;
    }
    public class ShopPublicProfileModel : ShopPublicProfileSummaryModel
    {
        public string AnnouncementHTML { get; set; }
        public string PolicyHTML { get; set; }
        public string FAQHTML { get; set; }
        //public string CategoryRequests { get; set; }
        //public string AttributeRequests { get; set; }
    }
    public class ShopPublicDetailModel : ShopPublicProfileModel
    {
        public string BusinessAddress { get; set; }
        public bool IsAcceptCashPayments { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        //public long StatusID { get; set; }
        public string StatusNotes { get; set; }
        //public long ShopOwnerProfileId { get; set; }
        
        //public List<ShopSchedule> ShopCalander { get; set; }
        //public List<CustomerReviews> CustomerReviewList{ get; set; }
    }
    public class WebLinkJSON
    {
        [Display(Name = "Facebook")]
        public string fb { get; set; }
        [Display(Name = "Shop URL")]
        public string goog { get; set; }
        [Display(Name = "Pintrest")]
        public string pinterest { get; set; }
        [Display(Name = "youTube")]
        public string youtb { get; set; }
        [Display(Name = "Twiter")]
        public string twitr { get; set; }
        [Display(Name = "Instagram")]
        public string instagrm { get; set; }
    }

    public class SupplierViewModel : AddressViewModel // ConcurrencyBaseModel indirectly inherited from base
    {
        [Display(Name = "Shop ID")]
        public long SupplierID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Shop Name")]
        public string SupplierName { get; set; }

        public string Logo { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status ID")]
        public long StatusID { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Status Notes")]
        public string StatusNotes { get; set; }

        [Display(Name = "Shop Address")]
        public long BusinessAddressID { get; set; }

        [Display(Name = "Allow shop address to display publically")]
        public bool IsBusinessAddressVisible { get; set; }

        [Display(Name = "Operating Language")]
        public long? OperatingLanguageID { get; set; }

        [Display(Name = "Operating Currency")]
        public long? OperatingCurrencyID { get; set; }

        [Display(Name ="Cash Payment")]
        public bool IsCOD { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "please enter processing fee")]
        [Display(Name = "Processing Fee")]
        public double ProcessingFee { get; set; } = 5;

        [Range(0, float.MaxValue, ErrorMessage = "Please enter gateway fee")]
        [Display(Name = "Payment Gateway Fee")]
        public double PaymentGatewayFee { get; set; } = 5;

        [Display(Name = "Is %age")]
        public bool IsProcessingFeePercentage { get; set; } = true;

        [Display(Name = "Is %age")]
        public bool IsPaymentGatewayFeePercentage { get; set; } = true;

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status")]
        public string StatusTitle { get; set; }

        [Display(Name = "Language")]
        public string LanguageTitle { get; set; }
        
        [Display(Name = "Currency")]
        public string CurrencyTitle { get; set; }

        public string WebLinksJSON { get; set; }
        public WebLinkJSON WebLinkJSONObject { get; set; }
        public string AnnouncementHTML { get; set; }
        public string PolicyHTML { get; set; }
        public string FAQHTML { get; set; }
        [Display(Name = "Category Requests")]
        [DataType(DataType.MultilineText)]
        public string CategoryRequests { get; set; }
        [Display(Name = "Attribute Requests")]
        [DataType(DataType.MultilineText)]
        public string AttributeRequests { get; set; }
        [Display(Name = "Shop Requested either Category, Attribute or both")]
        public bool IsRequestedCategoryOrAttribute { get; set; } = false;
    }

    public class SupplierSearchResultAdminModel : SearchResultModel
    {
        public List<SupplierModel> SupplierList { get; set; }
    }
}
