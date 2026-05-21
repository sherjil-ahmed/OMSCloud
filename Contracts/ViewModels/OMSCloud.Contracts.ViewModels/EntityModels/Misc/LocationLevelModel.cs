using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class LocationLevelModel : BaseModel
    {
        [Display(Name = "Location Level ID")]
        public long LocationLevelID { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Location Level")]
        public string LocationLevelTitle { get; set; }


        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
