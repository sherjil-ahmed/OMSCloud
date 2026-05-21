using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class RoleOptionPairModel : ConcurrencyBaseModel
    {

        [Display(Name = "Role Option Pair ID")]
        public long RoleOptionPairID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Option ID")]
        public long OptionID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Role ID")]
        public long RoleID { get; set; }

       
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is Assigned")]
        public bool IsAssigned { get; set; }

       
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is System")]
        public bool IsSystem { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status ID")]
        public long StatusID { get; set; }

        public OptionModel Option { get; set; }
        public RoleModel Role { get; set; }
        public List<RoleOptionPairModel> Children { get; set; }
    }
}
