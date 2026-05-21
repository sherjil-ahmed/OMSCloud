using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class RoleModel : BaseModel
    {
        [Display(Name = "Role ID")]
        public long RoleID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Role")]
        public string RoleTitle { get; set; }


        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Icon Path")]
        public string IconPath { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status ID")]
        public long StatusID { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status")]
        public string StatusTitle { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is System")]
        public bool IsSystem { get; set; }

    }
}
