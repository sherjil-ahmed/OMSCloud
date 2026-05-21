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
    public partial class UserTypeBusinessComponent
    {
        public List<UserTypeModel> GetUserTypeList()
        {
            return adapter.GetUserTypeList();
        }
        public UserTypeModel GetUserTypeById(long Id)
        {
            return adapter.GetUserTypeById(Id);
        }
        public long? AddUserType(UserTypeModel UserType)
        {
            return adapter.AddUserType(UserType);
        }
        public bool UpdateUserType(UserTypeModel UserType)
        {
            return adapter.UpdateUserType(UserType);
        }
        public bool DeleteUserType(UserTypeModel UserType)
        {
            return adapter.DeleteUserType(UserType);
        }
    }
}
