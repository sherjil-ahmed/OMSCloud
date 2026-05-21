using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class CartOrderLookupModel : ConcurrencyBaseModel
    {
        [Display(Name = "Cart Order ID")]
        public long CartOrderID { get; set; }

        [Display(Name = "Order Number")]
        public string OrderNumber { get; set; }
    }

    public class OrderModel : ConcurrencyBaseModel //CartOrderLookupModel
    {
        [Display(Name = "Order ID")]
        public long OrderID { get; set; }
        public string OrderNumber { get; set; }

        [Display(Name = "Parent Cart ID")]
        public long? ParentCartID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please select valid User Profile")]
        [Required(ErrorMessage = "User Profile Can Not Be Empty!!")]
        [Display(Name = "Buyer Profile ID")]
        public long BuyerProfileID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Order Status")]
        [Required(ErrorMessage = "Order Status Can Not Be Empty!!")]
        [Display(Name = "Order Status")]
        public long OrderStatusId { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Status")]
        [Required(ErrorMessage = "Status Can Not Be Empty!!")]
        [Display(Name = "Status")]
        public long StatusId { get; set; }

        public long? DeliveryAddressID { get; set; }

        public string DeliveryAddress { get; set; }

        public long? ShopID { get; set; } //OrderSupplierID 

        public long DeliveryOptionID { get; set; }//SupplierDeliveryOptionPairID 

        //[Range(0, long.MaxValue, ErrorMessage = "Please enter valid PayOptionMatrix")]
        //[Required(ErrorMessage = "PayOptionMatrix Can Not Be Empty!!")]
        //[Display(Name = "Pay Option Matrix")]
        //public long PayOptionMatrixId { get; set; }

        public double OrderTotal { get; set; }

        public double TaxTotal { get; set; }

        public double DeliveryTotal { get; set; }

        public double DiscountTotal { get; set; }

        public double PaymentTotal { get; set; }

        public double CalculatedPayout { get; set; }

        public double ActualPayout { get; set; }

        public double CalculatedPayIn { get; set; }

        public double ActualPayIn { get; set; }
    }

    public class OrderExtendedModel : OrderModel
    {
        [Display(Name = "Buyer's Name")]
        public string BuyerName { get; set; }

        [Display(Name = "Shop Name")]
        public string ShopName { get; set; }//OrderSupplierName
        public long ShopProvinceId { get; set; }
        public long ShopCityId { get; set; }
        public bool ShopAllowCashPayment { get; set; }
        public string DeliveryProvinceName { get; set; }
        public string DeliveryCityName { get; set; }

        [Display(Name = "Order Status")]
        public string OrderStatusTitle { get; set; }

        [Display(Name = "Status")]
        public string StatusTitle { get; set; }

        [Display(Name = "Delivery Option")]
        public string DeliveryOptionTitle { get; set; }
        #region Commented
        //[Display(Name = "Sub Total (Excluding Tax)")]
        //public double? SubTotal_ExclTax { get; set; }

        //[Display(Name = "Grand Total (Including Tax)")]
        //public double? Total_InclTax { get; set; }

        //[Display(Name = "Is Paid")]
        //public bool IsPaid { get; set; }

        //[Display(Name = "Is Order")]
        //public bool IsOrder { get; set; }
        #endregion Commented
    }

    public class OrderDetailModel : OrderExtendedModel
    {
        public List<AddressModel> AddressList { get; set; }
        public List<CartItemWithAttributesModel> ItemList { get; set; }
        public List<PaymentModel> PaymentList { get; set; }
    }

    public class OrderAdminSearchModel : SearchModel
    {
        //public SortShopByEnum SortBy { get; set; }
        public long? BuyerProfileId { get; set; } = null;
        public long? ShopId { get; set; } = null;
        public long? OrderStatusId { get; set; } = null;
        public long? ParentCartId { get; set; } = null;
        //public string SortBy { get; set; }
    }
    public class OrderSearchResultAdminModel : SearchResultModel
    {
        public List<OrderDetailModel> OrderList { get; set; }
    }
    public class OrderAdminStatsModel : OrderAdminSearchModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
    public class ConvertCartToOrders_SpParams : BaseModel
    {
        public long existing_CartId { get; set; }
        public long new_DeliveryAddressID { get; set; }
        public List<AddressModel> AddressList { get; set; }
        //public long new_SupplierDeliveryOptionPairID { get; set; }
        //public long spProfileId { get; set; }
    }
    public class ConvertCartToOrders_ResultModel
    {
        public Nullable<long> OrderId { get; set; }
        public Nullable<long> ShopId { get; set; }
    }    
}
