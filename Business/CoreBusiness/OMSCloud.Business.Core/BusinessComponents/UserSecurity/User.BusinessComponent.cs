using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Business.Adapters;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Business.Core
{
    public partial class UserBusinessComponent
    {
        public UserModel LoginUser(LoginModel model)
        {
            return adapter.LoginUser(model);
        }
        public bool ChangePassword(ChangePasswordModel model)
        {
            //Make Encryption Here
            model.CurrentPassword = model.CurrentPassword;
            model.NewPassword = model.NewPassword;
            //model.RequestedByUserId 

            return adapter.ChangePassword(model);
        }
        public List<UserModel> GetUserList()
        {
            return adapter.GetUserList();
        }
        public UserModel GetUserById(long Id)
        {
            return adapter.GetUserById(Id);
        }
        public long? AddUser(UserModel User)
        {
            if (string.IsNullOrEmpty(User.AcvtivationGUID))
                User.AcvtivationGUID = (User.IsSystem || User.StatusID <= (int)DBStatusEnum.Active) ? Guid.NewGuid().ToString() : string.Empty;
            return adapter.AddUser(User);
        }
        public bool UpdateUser(UserModel User)
        {
            return adapter.UpdateUser(User);
        }
        public bool DeleteUser(UserModel User)
        {
            return adapter.DeleteUser(User);
        }
    }
}
