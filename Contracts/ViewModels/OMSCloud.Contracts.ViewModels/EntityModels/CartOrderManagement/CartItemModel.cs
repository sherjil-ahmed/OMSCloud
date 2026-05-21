using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class CartItemModel : ConcurrencyBaseModel
    {
        public long CartItemID { get; set; }
        public long CartOrderID { get; set; }
        public long ProductID { get; set; }

        [Display(Name = "Product")]
        public string ProductTitle { get; set; }
        public string ProductDefaultImage { get; set; }
        [Display(Name = "Shop Name")]
        public string ShopName { get; set; }
        public long ShopCountryId { get; set; }
        public long ShopProvinceId { get; set; }
        public long ShopCityId { get; set; }
        public long ShopId { get; set; }
        public long ShopStatusId { get; set; }
        public long Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double ItemTotalPrice { get; set; }
        public long StatusID { get; set; }
        public string StatusTitle { get; set; }
        public long ProductTypeId { get; set; }
        public string ProductTypeTitle { get; set; }
        public long TaxTypeID { get; set; }
        public double TaxRateApplied { get; set; }
        public double TaxAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double DiscountValue { get; set; }
        public bool IsDiscountPercentage { get; set; }
        public string ExpectedDeliveryInfo { get; set; }
        public long ExpectedDeliveryTime { get; set; }
        public string ExpectedDeliveryUnit { get; set; }
    }

    public class CartItemWithAttributesModel : CartItemModel
    {
        public List<CartItemAttributePairModel> AttributeList { get; set; }
    }

    public class CartItemUpdateModel : ConcurrencyBaseModel
    {
        public long CartItemID { get; set; }
        public long CartOrderID { get; set; }
        public long ProductID { get; set; }
        public long Quantity { get; set; }
    }
}
