using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class GroupRolePairModel : BaseModel
    {
        [Display(Name = "Group Role Pair ID")]
        public long GroupRolePairID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Group ID")]
        public long GroupID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Role ID")]
        public long RoleID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is System")]
        public bool IsSystem { get; set; }
    }
}
