using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class CartModel : ConcurrencyBaseModel
    {
        public long CartID { get; set; }
        public long BuyerProfileID { get; set; }
        [Display(Name = "Cart Status")]
        public long CartStatusID { get; set; }
        [Display(Name = "Status")]
        public long StatusID { get; set; }
        [Display(Name = "Cart Total")]
        public double CartTotal { get; set; }
        [Display(Name = "Total Tax Amount")]
        public double TaxTotal { get; set; }
        [Display(Name = "Total Discount")]
        public double DiscountTotal { get; set; }
    }

    public class CartExtendedModel : CartModel
    {

        [Display(Name = "Buyer")]
        public string Buyer { get; set; }

        [Display(Name = "Cart Status")]
        public string CartStatus { get; set; }

        [Display(Name = "Status")]
        public string Status { get; set; }

        public long OrderCount { get; set; }

        //[Display(Name = "Sub Total (Excluding Tax)")]
        //public double? SubTotal_ExclTax { get; set; }

        //[Display(Name = "Grand Total (Including Tax)")]
        //public double? Total_InclTax { get; set; }

        //[Display(Name = "Is Paid")]
        //public bool IsPaid { get; set; }

        //[Display(Name = "Is Order")]
        //public bool IsOrder { get; set; }
    }
    public class CartDetailModel : CartExtendedModel
    {
        public List<CartItemWithAttributesModel> CartItemList { get; set; }
    }
}
