using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class MediaContentTypeModel : BaseModel
    {
        [Display(Name = "Media Content Type ID")]
        public long MediaContentTypeID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Display Text")]
        public string DisplayText { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "HTML Content Type Text")]
        public string HTMLContentTypeText { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Icon Path")]
        public string IconPath { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is System")]
        public bool IsSystem { get; set; }

    }
}
