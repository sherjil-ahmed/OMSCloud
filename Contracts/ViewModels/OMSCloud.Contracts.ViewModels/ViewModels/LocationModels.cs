using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OMSCloud.Contracts.ViewModels
{
    public class LocationModel : ConcurrencyBaseModel
    {
        #region IDs
        public long LocationID { get; set; } = -1;
        public long OperatingCountryID { get; set; } = -1;
        public long OperatingProvinceID { get; set; }
        public long OperatingCityID { get; set; }
        //public long OperatingAreaID { get; set; }
        #endregion IDs

        #region Titles
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Location")]
        public string LocationName { get; set; }

        [Display(Name = "Country")]
        public string OperatingCountryTitle { get; set; }

        [Display(Name = "Province")]
        public string OperatingProvinceTitle { get; set; }

        [Display(Name = "City")]
        public string OperatingCityTitle { get; set; }

        //[Display(Name = " Area")]
        //public string OperatingAreaTitle { get; set; }
        #endregion Titles
    }

    public class LocationLookup : BaseModel
    {
        public long LocationID { get; set; }
        public string LocationName { get; set; }
    }

    public class CountrySelectionConfigModel : BaseModel
    {
        public long CountryId { get; set; }
        public string CountryName { get; set; }
        public string ApiUri { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string LanguageName { get; set; } = "English";
        public string IBAN { get; set; } = "Transit / Routing Number";
        public string Banking { get; set; } = "banking";
        public string Province { get; set; } = "Province";
        public string PostalCode { get; set; } = "Postal Code";
        public string PhoneCountryCode { get; set; } = "+1";
        public string ZvonrAddress { get; set; } = "";

    }

    public class LocationPreference : BaseModel
    {
        public long CountryID { get; set; } = -1;
        public long CurrencyID { get; set; } = -1;
        public long LanguageID { get; set; } = -1;
        public string CountryName { get; set; }
        public string CurrencyName { get; set; }
        public string LanguageName { get; set; }
        public string CurrencyCode { get; set; } // PKR, CAD, USD
        public string CurrencySymbol { get; set; } // $, RS, 
        public string LanguageShortForm { get; set; } // en-us, en-ca, 

    }
}
