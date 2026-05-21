using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class OrderStatusModel : BaseModel
    {
        [Display(Name = "Order Status ID")]
        public long OrderStatusID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Order Status")]
        public string OrderStatusTitle { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is System")]
        public bool IsSystem { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is Order")]
        public bool IsOrder { get; set; }
    }

    public class ChangeOrderStatusModel : BaseModel
    {
        public long OrderStatusID { get; set; }
        public string OrderStatusTitle { get; set; }
        public bool IsDefault { get; set; }
        public bool IsCurrent { get; set; }
    }
}
