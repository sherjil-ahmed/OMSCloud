using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class TaxModel : ConcurrencyBaseModel
    {
        public long TaxID { get; set; }
        public double TaxValue { get; set; }
        public long TaxTypeID { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public long StatusID { get; set; }
        public bool IsPercentage { get; set; }
        public long LocationLevelId { get; set; }
        public long LocationId { get; set; }
        public System.DateTime EffectiveDate { get; set; }
    }
    public class TaxViewModel : ConcurrencyBaseModel//LocationModel
    {
        [Display(Name = "Tax ID")]
        public long TaxID { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Tax Value")]
        public double TaxValue { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Tax Type ID")]
        public long TaxTypeID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Location Id")]
        public long LocationID { get; set; }

        [Display(Name = "Location Name")]
        public string LocationName{ get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Tax Territory Level ID")]
        public long LocationLevelId/*TaxTerritoryLevelId */{ get; set; }

        [Display(Name = "Tax Territory Leve")]
        public string TaxTerritoryLevel { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Tax Type")]
        public string TaxTypeTitle { get; set; }


        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status ID")]
        public long StatusID { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status")]
        public string StatusTitle { get; set; }

        [Required(ErrorMessage = "Must be either True or False")]
        [Display(Name = "Is Tax Value is in %age")]
        public bool IsPercentage { get; set; }

        //[Required(ErrorMessage = "Must select a valid Location")]
        //[Display(Name = "Location Id")]
        //public long LocationId { get; set; }

        [Required(ErrorMessage = "Must provide a valid Date.")]
        [Display(Name = "EffectiveDate ")]
        public System.DateTime EffectiveDate { get; set; }
    }
}
