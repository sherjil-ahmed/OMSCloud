using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ApiExplorerEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{

    public class ApiDescriptorModel : BaseModel
    {
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Declared Response Type")]
        public string DeclaredResponseType { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Actual Response Type")]
        public string ActualResponseType { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Action Name")]
        public string ActionName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Method Name")]
        public string MethodName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Method Signature")]
        public string MethodSignature { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Controller Name")]
        public string ControllerName { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Relative Path")]
        public string RelativePath { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Route Template")]
        public string RouteTemplate { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Http Verb")]
        public WebAPIVerbEnum HttpVerb { get; set; }

        
        [Display(Name = "Description")]
        public List<ParamDescription> Params { get; set; }
    }
    public class ParamDescription : BaseModel
    {
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Source")]
        public string Source { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Data Type")]
        public string DataType { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is Optional")]
        public bool IsOptional { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Prefix")]
        public string Prefix { get; set; }
    }
}
