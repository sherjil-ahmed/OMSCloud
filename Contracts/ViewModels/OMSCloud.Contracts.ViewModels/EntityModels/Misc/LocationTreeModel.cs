using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class LocationTreeModel : BaseModel
    {

        [Display(Name = "Location ID")]
        public long LocationID { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Location")]
        public string LocationTitle { get; set; }


        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Display(Name = "Parent Location ID")]
        public long? ParentLocationID { get; set; }

        //[Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Display(Name = "Parent Location Title")]
        public string ParentLocationTitle { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Location Level ID")]
        public long LocationLevelID { get; set; }

        //[Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Location Level Title")]
        public string LocationLevelTitle { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
