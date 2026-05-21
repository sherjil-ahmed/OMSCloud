using OMSCloud.Contracts.Common.DBEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class UserModel : ConcurrencyBaseModel
    {
        [Display(Name = "User ID")]
        public long UserID { get; set; }


        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a - z])(?=.*[A - Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "User Password")]
        public string UserPassword { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid Email address")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "User email")]
        public string Useremail { get; set; }

        [Display(Name = "Password Reset Code")]
        public string PasswordResetCode { get; set; }

        [Display(Name = "Acvtivation GUID")]
        public string AcvtivationGUID { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status ID")]
        public long StatusID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Status")]
        public string StatusTitle { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is Logged In")]
        public bool IsLoggedIn { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Is System")]
        public bool IsSystem { get; set; }

        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid Number")]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Group ID")]
        public long GroupID { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "Group")]
        public String GroupTitle { get; set; }

        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "User Type")]
        public DBUserTypeEnum UserType { get; set; }

        [Display(Name = "Approved By")]
        public long? ApprovedByUserID { get; set; }

        [Display(Name = "Approved On")]
        public DateTime? ApprovedDateTime { get; set; }
    }
}
