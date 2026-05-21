using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ExecActionModel : BaseModel
    {
        
        [Display(Name = "Execute Action ID")]
        public long ExecActionID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Data Type ID")]
        public long DataTypeID { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Method")]
        public string Method { get; set; }
    }
}
