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
    public partial class GroupRolePairBusinessComponent
    {
        public List<GroupRolePairModel> GetGroupRolePairList()
        {
            return adapter.GetGroupRolePairList();
        }
        public GroupRolePairModel GetGroupRolePairById(long Id)
        {
            return adapter.GetGroupRolePairById(Id);
        }
        public long? AddGroupRolePair(GroupRolePairModel GroupRolePair)
        {
            return adapter.AddGroupRolePair(GroupRolePair);
        }
        public bool UpdateGroupRolePair(GroupRolePairModel GroupRolePair)
        {
            return adapter.UpdateGroupRolePair(GroupRolePair);
        }
        public bool DeleteGroupRolePair(GroupRolePairModel GroupRolePair)
        {
            return adapter.DeleteGroupRolePair(GroupRolePair);
        }
    }
}
