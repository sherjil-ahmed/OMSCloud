using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Common.DBEnums
{
    public enum BankAccountTypeEnum
    {
        [Description("None - N/A")]
        None = -1,
        [Description("BusinessChequing")]
        BusinessChequing = 0,
        [Description("Business Saving")]
        BusinessSaving = 1,
        [Description("Personal Chequing")]
        PersonalChequing = 2,
        [Description("Personal Saving")]
        PersonalSaving = 3,
    }

    public enum SortByEnum
    {
        [Description("None")]
        None = -1,
        [Description("Min Price")]
        MinPrice = 1,
        [Description("Product Name")]
        ProductTitle = 2,
        [Description("Max Price")]
        MaxPrice = 3,
        [Description("Shop")]
        Shop = 4,
        //[Description("Brands")]
        //Brands = 5,
        [Description("User Rating")]
        UserRating = 6,
        //[Description("Capacity")]
        //Capacity = 7,
        //[Description("Cateogry")]
        //MainCategory = 8,
        //[Description("Area/Location")]
        //AreaCategory = 9,

    }
    public enum SortShopByEnum
    {
        [Description("None")]
        None = 0,
        [Description("Shop Name")]
        ShopName = 1,
        [Description("User Rating")]
        UserRating = 2,
    }

    public enum CustomerReviewSubjectEnum
    {
        [Description("Unknown")]
        Unknown = 0,
        [Description("Product")]
        Product = 1,
        [Description("Shop")]
        Shop = 2,
        [Description("Order")]
        Order = 3,
    }
    public enum AppCodeEnum
    {
        [Description("WebFrontEnd")]
        WebFrontEnd = 1,
        [Description("WebBackEnd")]
        WebBackEnd = 2,
        [Description("AndroidFrontEnd")]
        AndroidFrontEnd = 3,
        [Description("AndroidBackEnd")]
        AndroidBackEnd = 4,
        [Description("iOSFrontEnd")]
        iOSFrontEnd = 5,
        [Description("iOSBackEnd")]
        iOSBackEnd = 6
    }
    public enum DBAddressTypeEnum
    {
        [Description("Shop Address")]
        BusinessAddress = 1,
        [Description("Delivery/Shipping Address")]
        PersonalAddress = 2,
    }

    public enum DBScheduleTypeEnum
    {
        Weekly = 1,
        Monthly = 2,
        Yearly = 3
    }

    //public enum DBLocationLevelEnum
    //{
    //    Country = 1,
    //    Province = 2,
    //    State = 3,
    //    City = 4,
    //}
    public enum DBStatusEnum
    {
        [Description("New")]
        New = 1,
        [Description("Active")]
        Active = 2,
        [Description("InActive")]
        InActive = 3,
        [Description("Deleted")]
        Deleted = 4,
    }
    public enum DBMonthsEnum {
        [Description("JAN")]
        January = 1,
        [Description("FEB")]
        Feburary = 2,
        [Description("MAR")]
        March = 3,
        [Description("APR")]
        April = 4,
        [Description("MAY")]
        May = 5,
        [Description("JUN")]
        Jun = 6,
        [Description("JUL")]
        July = 7,
        [Description("AUG")]
        Aug = 8,
        [Description("SEP")]
        September = 9,
        [Description("OCT")]
        October = 10,
        [Description("NOV")]
        November= 11,
        [Description("DEC")]
        December = 12,

    }
    public enum DBCountryEnum
    {
        [Description("CA")]
        Canada = 1,
        [Description("US")]
        USA = 2,
        [Description("UK")]
        UK = 3,
        [Description("AU")]
        Australia = 4
    }
    public enum DBAttributeTypeEnum
    {
        [Description("Customization Attribute")]
        Customization = 1,
        [Description("Specification Attribute")]
        Specification = 2,
    }

    public enum DBUserTypeEnum
    {
        [Description("Anonymous User")]
        Anonymous = 0,
        [Description("Buyer")]
        Buyer = 1,
        [Description("Seller")]
        Seller = 2,
        [Description("BackEnd")]
        Admin = 3,
    }

    public enum DBUserTypePublicEnum //Limited Enum for Public User Registration Form
    {
        [Description("Anonymous")]
        Anonymous = 0,
        [Description("I want to Buy.")]
        Buyer = 1, //mapped to Full User
        [Description("I want to sell.")]
        Seller = 2, // Map to Front/Back End Business User (Supplier/Manufaturer/Vendour/Provider)
        [Description("System Administrator")]
        Admin = 3, // Map to Front/Back End Business User (Supplier/Manufaturer/Vendour/Provider)
        //[DefaultValue("13,16,17,18,19")]
    }

    public enum DBVerificationStatusEnum
    {
        [Description("Unverified")]
        Unverified = 1,
        [Description("Verified")]
        Verified = 2,
        [Description("Rejected")]
        Rejected = 3,
        [Description("BlackListed")]
        BlackListed = 4,
        //[Description("Deffered")]
        //Deffered = 5,
        //[Description("OnHold")]
        //OnHold = 6,
    }

    public enum DBDocumentTypeEnum
    {
        [Description("NationalSecurityNumber")]
        NationalSecurityNumber = 1,
        [Description("PassportNumber")]
        PassportNumber = 2,
        [Description("DrivingLicenseNumber")]
        DrivingLicenseNumber = 3,
        [Description("UtilityBillNumber")]
        UtilityBillNumber = 4,
        [Description("Other")]
        Other = 5
    }

    public enum DBSystemGroupEnum
    {
        DBAdmin = 0,
        Admin = 1,
        System = 2,
        Power = 3,
        AnonymousUser = 4,
        Customer = 5,
        Supplier = 6
    }
    public enum DBResponseTimeUnitEnum
    { 
        //[Description("Months")]
        //Month = 1,
        //[Description("Weeks")]
        //Week = 2,
        [Description("Days")]
        Day = 3,
        [Description("Hours")]
        Hour = 4,
        [Description("Minutes")]
        Minute = 5
    }
    public enum DBLocationLevelEnum
    { 
        Country = 1,
        Province = 2,
        City = 3,
        Area = 4
    }

    public enum DBSystemRoleEnum
    {
        [Description("Anonymous")]
        Anonymous = 1,
        [Description("Buyer")]
        Buyer = 2,
        [Description("Shop")]
        Shop = 3,
        [Description("Admin Portal")]
        AdminPortal = 4,
        [Description("Security Admin")]
        SecurityAdmin = 5,
        [Description("Super Admin")]
        SuperAdmin = 6,
        [Description("Admin Portal Api")]
        AdminPortalApi = 7,
        [Description("Public Anonymous access")]
        PublicAnonymousaccess = 8,
        [Description("MarketPlace")]
        MarketPlace = 9,
        [Description("Backgorund Services")]
        BackgorundServices = 10,
    }
    public enum DBCartStatusEnum
    {
        [Description("NewCart")]
        NewCart = 1,
        [Description("CartConvertedToOrders")]
        CartConvertedToOrders = 2,
    }
    public enum DBOrderStatusEnum
    {
        [Description("New Order")]
        NewOrder = 3,
        [Description("Order Placed")]
        OrderPlaced = 4,
        [Description("In Process")]
        OrderInProcess = 5,
        [Description("Dispatched / ReadyforPickup")]
        OrderDispatched_ReadyforPickup = 6,
        [Description("Delivered / Pickedup")]
        Order_Delivered_Pickedup = 8,
        [Description("Issue Raised By Buyer")]
        OrderIssueRaisedByBuyer = 9,
        [Description("Order Successfully Completed")]
        OrderCompleted = 10
    }
    public enum DBOrderStatusAdminEnum
    {
        [Description("Order_Delivery_Pickup_Failed")]
        Order_Delivery_Pickup_Failed = 11,
        [Description("OrderIssues")]
        OrderIssues = 12,
        [Description("OrderFailed")]
        OrderFailed = 13
    }

    public enum OrderPublicStatusEnum
    {
        New = 101,
        Inprocess = 102,
        Completed = 103,
        Failed = 104,
    }
    public enum DBDeliveryOptionEnum
    { 
        [Description("Self Pickup")]
        SelfPickUp = 1,
        [Description("Shop Delivery Service")]
        ShopDelivery = 2,
        [Description("Deliver Surrounding Cities")]
        DeliverSurroundingCities = 3,
        [Description("DeliverAcrossCountry(Mail)")]
        DeliveryAcrossCountry = 4
    }
    public enum DBPaymentMethodEnum
    {
        [Description("Cash")]
        Cash = 1,
        [Description("Stripe")]
        Stripe = 2,
        [Description("PayPal")]
        PayPal = 3        
    }

    public enum DBAppConfigEnum
    {
        [Description("SMTP Server")]
        SMTPServer = 1,
        [Description("CountryID")]
        CountryID = 2,
        [Description("Country Name")]
        CountryName = 3,
        //[Description("Shop Preference")]
        //ShopPreference = 4,
        [Description("Currency Name")]
        CurrencyName = 5,
        [Description("Currency Code")]
        CurrencyCode = 6,
        [Description("Currency Symbol")]
        CurrencySymbol = 7,
        [Description("Language Name")]
        LanguageName = 8,
        [Description("Language Code")]
        LanguageCode = 9,
        [Description("ProcessingFee")]
        ProcessingFee = 10,
        [Description("Is Processing Fee Percentage")]
        IsProcessingFeePercentage = 11,
        [Description("Payment Gateway Fee")]
        PaymentGatewayFee = 12,
        [Description("Is Payment Gateway Fee Percentage")]
        IsPaymentGatewayFeePercentage = 13,
        [Description("CurrencyID")]
        CurrencyID = 14,
        [Description("LanguageID")]
        LanguageID = 14,

    }
    public enum DBHTMLContentTypeEnum
    {
        [Description("image/webp")]
        PrograsiveWebImages = 1,
        [Description("image/png")]
        PortableNetworkGraphics = 2,
        [Description("image/jpeg")]
        JPEGImage = 3,
        [Description("image/gif")]
        GIFImage = 4,
        [Description("image/x-icon")]
        IconImage = 5,
        [Description("image/bmp")]
        BMPBitmapImage = 6,
        [Description("image/svg+xml")]
        ScalableVectorGraphics = 8,

    }
}
