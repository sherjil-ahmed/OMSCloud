using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    //public class OrderPaymentModel : BaseModel
    //{

    //    [Display(Name = "Payment ID")]
    //    public long PaymentID { get; set; }


    //    [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
    //    [Required(ErrorMessage = "Can Not Be Empty!!")]
    //    [Display(Name = "Cart Order ID")]
    //    public long CartOrderID { get; set; }


    //    [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
    //    [Required(ErrorMessage = "Can Not Be Empty!!")]
    //    [Display(Name = "Pay Type ID")]
    //    public long PayTypeID { get; set; }


    //    [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
    //    [Required(ErrorMessage = "Can Not Be Empty!!")]
    //    [Display(Name = "Pay Mode ID")]
    //    public long PayModeID { get; set; }

    //    [Range(0, double.MaxValue, ErrorMessage = "Please enter valid doubleNumber")]
    //    [Required(ErrorMessage = "Can Not Be Empty!!")]
    //    [Display(Name = "Paid Amount")]
    //    public double PaidAmount { get; set; }

    //    [Display(Name = "Payment Gateway Transaction ID")]
    //    public string PaymentGatewayTransactionID { get; set; }

    //    [Display(Name = "Payment Token")]
    //    public string PaymentToken { get; set; }
    //}


    public partial class OrderPaymentModel : BaseModel
    {
        public long OrderPaymentID { get; set; }
        public long CartOrderID { get; set; }
        public long PaymentID { get; set; }
        public double Amount { get; set; }
        public long BillingAddressID { get; set; }
    }
}
