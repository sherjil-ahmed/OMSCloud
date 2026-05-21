using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class UsedAddress
    {
        public long AddressID { get; set; }
    }
    public class AddressModel : ConcurrencyBaseModel
    {
        public long AddressID { get; set; }
        public long ProfileID { get; set; }
        public int AddressTypeID { get; set; }
        public string PlotNumber { get; set; }
        public string StreetNumber { get; set; }
        public long CountryID { get; set; }
        public long ProvinceID { get; set; }
        public long CityID { get; set; }
        public long LocationID { get; set; }
        public string NearestLandmark { get; set; }
        public string PostalCode { get; set; }
        public string MapLink { get; set; }
        public long StatusID { get; set; }
        public long? ShopID { get; set; }
        public bool IsBusinessAddressVisible { get; set; } //This is for update purpose, no need in GET calls.
    }
    public class AddressViewModel : LocationModel //ConcurrencyBaseModel indirectly inherited from base
    {
        [Display(Name = "Address ID")]
        public long AddressID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Profile ID")]
        public long ProfileID { get; set; }

        [Display(Name = "User's Profile")]
        public string ProfileName { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Address Type ID")]
        public int AddressTypeID { get; set; }

        [Display(Name = "Address Type")]
        public string AddressTypeName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Street Name")]
        public string PlotNumber { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Street Number")]
        public string StreetNumber { get; set; }

        //[Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Apartment/Suit/Unit")]
        public string NearestLandmark { get; set; }

        //[RegularExpression(@"^(?!0+$)[0-9]{5,5}$", ErrorMessage = "Please Enter Valid Value")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Display(Name = "Map Link")]
        public string MapLink { get; set; }
        public DateTime AddressModifiedOn { get; set; }
        [Display(Name ="Address Status")]
        public long AddressStatusID { get; set; }
        public bool IsEditable { get; set; }

    }
}
