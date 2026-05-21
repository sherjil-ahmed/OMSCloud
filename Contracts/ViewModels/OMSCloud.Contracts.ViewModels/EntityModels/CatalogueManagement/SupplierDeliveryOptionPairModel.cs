using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class SupplierDeliveryOptionPairModel : ConcurrencyBaseModel
    {
        public long  SupplierDeliveryOptionPairID { get; set; }
        public long SupplierID { get; set; }
        [Display(Name = "Shop")]
        public string SupplierName { get; set; }
        public long DeliveryOptionID { get; set; }
        [Display(Name = "Delivery Option")]
        public string DeliveryOptionTitle { get; set; }
        [Display(Name = "Delivery Charges")]
        public double DeliveryCharges { get; set; }
        [Display(Name = "Minimum Order Limit (Amount)")]
        public double MinOrderLimit { get; set; }
        [Display(Name = "Surrounding Cities")]
        public string SurroundingCities { get; set; }
        public string SurroundingCitiesIDs { get; set; }
        public long StatusID { get; set; }
    }
}

