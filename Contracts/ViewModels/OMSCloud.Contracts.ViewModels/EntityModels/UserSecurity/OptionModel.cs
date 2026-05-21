using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class OptionModel : ConcurrencyBaseModel
    {

        [Display(Name = "Option ID")]
        public long OptionID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Option")]
        public string OptionTitle { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Menu")]
        public string MenuTitle { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Item")]
        public string ItemTitle { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Page Link")]
        public string PageURL { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Next Page Link")]
        public string NextPageURL { get; set; }


        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Module ID")]
        public int ModuleID { get; set; }


        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Option Type ID")]
        public int OptionTypeID { get; set; }


        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Parent Option ID")]
        public long ParentOptionID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "DisplayOrder")]
        public int DisplayOrder { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Execution Action ID")]
        public long ExecActionID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status ID")]
        public int StatusID { get; set; }
    }
}
