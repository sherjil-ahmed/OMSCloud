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
    public partial class RoleBusinessComponent
    {
        public List<RoleModel> GetRoleList()
        {
            return adapter.GetRoleList();
        }
        public RoleModel GetRoleById(long Id)
        {
            return adapter.GetRoleById(Id);
        }
        public long? AddRole(RoleModel Role)
        {
            return adapter.AddRole(Role);
        }
        public bool UpdateRole(RoleModel Role)
        {
            return adapter.UpdateRole(Role);
        }
        public bool DeleteRole(RoleModel Role)
        {
            return adapter.DeleteRole(Role);
        }
    }
}
