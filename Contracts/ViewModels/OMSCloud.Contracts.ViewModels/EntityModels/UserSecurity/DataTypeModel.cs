using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{

    public class DataTypeModel : BaseModel
    {
        [Display(Name = "Data Type ID")]
        public long DataTypeID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Assembly Name")]
        public string AssemblyName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Name space")]
        public string Namespace { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Class Name")]
        public string ClassName { get; set; }

        [Display(Name = "Friendly Name")]
        public string FriendlyName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is System")]
        public bool IsSystem { get; set; }
        public string SuggestedUIControl { get; set; }
    }

}
