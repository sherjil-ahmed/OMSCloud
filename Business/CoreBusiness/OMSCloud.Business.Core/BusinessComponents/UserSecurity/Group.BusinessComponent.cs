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
    public partial class GroupBusinessComponent
    {
        public List<GroupModel> GetGroupList()
        {
            return adapter.GetGroupList();
        }
        public GroupModel GetGroupById(long Id)
        {
            return adapter.GetGroupById(Id);
        }
        public long? AddGroup(GroupModel Group)
        {
            return adapter.AddGroup(Group);
        }
        public bool UpdateGroup(GroupModel Group)
        {
            return adapter.UpdateGroup(Group);
        }
        public bool DeleteGroup(GroupModel Group)
        {
            return adapter.DeleteGroup(Group);
        }
    }
}
