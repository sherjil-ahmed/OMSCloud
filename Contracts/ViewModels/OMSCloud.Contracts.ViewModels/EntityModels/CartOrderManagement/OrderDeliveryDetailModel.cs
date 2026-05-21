using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class OrderDeliveryDetailModel : BaseModel
    {
        public long OrderDeliveryDetailID { get; set; }

        public long CartOrderID { get; set;}

        [Display(Name = "Cart/Order Name")]
        public string CartOrderName { get; set; }

        [Display(Name = "Delivery Product")]
        [Required(ErrorMessage = "Deleivery Product must be provided")]
        public long DeliveryProductID { get; set; }
        public string DeliveryProductTitle { get; set; }

        [Display(Name = "Delivery Address")]
        [Required(ErrorMessage = "Deleivery Address must be provided")]
        public long DeliveryAddressID { get; set; }

        public string DeliveryAddress { get; set; }
    }
}
