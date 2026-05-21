using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ExecActionParamModel : BaseModel
    {
        [Display(Name = "Execute Action Param ID")]
        public long ExecActionParamID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Execute Action ID")]
        public long ExecActionID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Parameter Name")]
        public string ParamName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Data Type ID")]
        public long DataTypeID { get; set; }

    }
}
