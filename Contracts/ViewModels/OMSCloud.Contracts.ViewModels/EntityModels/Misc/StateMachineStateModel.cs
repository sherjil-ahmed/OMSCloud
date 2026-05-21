using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class StateMachineStateModel : BaseModel
    {
        [Display(Name = "State Machine State ID")]
        public long StateMachineStateID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "State ID")]
        public long StateID { get; set; }

        [Display(Name = "Next State ID")]
        public long? NextStateID { get; set; }

        [Display(Name = "Next Input String")]
        public string NextInputString { get; set; }
    }
}
