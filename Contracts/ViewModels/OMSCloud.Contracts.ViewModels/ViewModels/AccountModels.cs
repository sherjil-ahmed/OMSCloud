using OMSCloud.Contracts.Common.DBEnums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class LoginModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Can Not Be Empty!!")]
        [Display(Name = "User Password")]
        public string Password { get; set; }

        public string recaptcha { get; set; }

        //public DBUserTypeEnum UserType { get; set; }

        public AppCodeEnum AppCode { get; set; }
    }
    public class ChangePasswordModel : BaseModel
    {
        public string UserName { get; set; }
        public string email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmNewPassword { get; set; }
        public string PasswordResetCode { get; set; }
    }

    public class RequestResetPassword : BaseModel
    {
        public string email { get; set; }

    }

    public class EmailModel
    {
        public string From_FullName { get; set; }
        public string From_Email { get; set; }
        public string Subject { get; set; }
        public string PhoneNumber { get; set; }
        public string Body { get; set; }

    }
}
