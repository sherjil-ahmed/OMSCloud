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
    public partial class RoleOptionPairBusinessComponent
    {
        public List<RoleOptionPairModel> GetRoleOptionPairList()
        {
            return adapter.GetRoleOptionPairList();
        }
        public RoleOptionPairModel GetRoleOptionPairById(long Id)
        {
            return adapter.GetRoleOptionPairById(Id);
        }
        public long? AddRoleOptionPair(RoleOptionPairModel RoleOptionPair)
        {
            return adapter.AddRoleOptionPair(RoleOptionPair);
        }
        public bool UpdateRoleOptionPair(RoleOptionPairModel RoleOptionPair)
        {
            return adapter.UpdateRoleOptionPair(RoleOptionPair);
        }
        public bool DeleteRoleOptionPair(RoleOptionPairModel RoleOptionPair)
        {
            return adapter.DeleteRoleOptionPair(RoleOptionPair);
        }
        public List<RoleOptionPairModel> GetRoleOptionPairByRoleId(long RoleId)
        {
            RoleAdapter roleAdapter = new RoleAdapter();
            OptionAdapter optionAdapter = new OptionAdapter();

            List<RoleOptionPairModel> roleOptionPairModelList = adapter.GetRoleOptionPairByRoleId(RoleId);
            foreach(RoleOptionPairModel model in roleOptionPairModelList)
            {
                //model.Role = roleAdapter.GetRoleById(model.RoleID);
                model.Option = optionAdapter.GetOptionById(model.OptionID);
            }

            List<RoleOptionPairModel> hierarchy = new List<RoleOptionPairModel>();
            hierarchy = roleOptionPairModelList
                            .Where(c => c.Option.ParentOptionID == 0)
                            .Select(c => new RoleOptionPairModel()
                            {
                                CreatedBy = c.CreatedBy,
                                IsAssigned = c.IsAssigned,
                                CreatedOn = c.CreatedOn,
                                IsSystem = c.IsSystem,
                                ModifiedBy = c.ModifiedBy,
                                ModifiedOn = c.ModifiedOn,
                                Option = c.Option,
                                OptionID = c.OptionID,
                                RequestedByProfileId = c.RequestedByProfileId,
                                //Role = c.Role,
                                RoleID = c.RoleID,
                                RoleOptionPairID = c.RoleOptionPairID,
                                StatusID = c.StatusID,
                                Children = GetChildren(roleOptionPairModelList, c.Option.OptionID)
                            })
                            .ToList();

            return hierarchy;
        }
        public List<RoleOptionPairModel> GetRoleOptionPairByRoleId(List<long> RoleIds)
        {
            RoleAdapter roleAdapter = new RoleAdapter();
            OptionAdapter optionAdapter = new OptionAdapter();

            List<RoleOptionPairModel> roleOptionPairModelList = adapter.GetRoleOptionPairByRoleId(RoleIds);
            foreach (RoleOptionPairModel model in roleOptionPairModelList)
            {
                //model.Role = roleAdapter.GetRoleById(model.RoleID);
                model.Option = optionAdapter.GetOptionById(model.OptionID);
            }

            List<RoleOptionPairModel> hierarchy = new List<RoleOptionPairModel>();
            hierarchy = roleOptionPairModelList
                            .Where(c => c.Option.ParentOptionID == 0)
                            .Select(c => new RoleOptionPairModel()
                            {
                                CreatedBy = c.CreatedBy,
                                IsAssigned = c.IsAssigned,
                                CreatedOn = c.CreatedOn,
                                IsSystem = c.IsSystem,
                                ModifiedBy = c.ModifiedBy,
                                ModifiedOn = c.ModifiedOn,
                                Option = c.Option,
                                OptionID = c.OptionID,
                                RequestedByProfileId = c.RequestedByProfileId,
                                //Role = c.Role,
                                RoleID = c.RoleID,
                                RoleOptionPairID = c.RoleOptionPairID,
                                StatusID = c.StatusID,
                                Children = GetChildren(roleOptionPairModelList, c.Option.OptionID)
                            })
                            .ToList();

            return hierarchy;
        }
        private List<RoleOptionPairModel> GetChildren(List<RoleOptionPairModel> roleOptionPairs, long parentId)
        {
            return roleOptionPairs
                    .Where(c => c.Option.ParentOptionID == parentId)
                    .Select(c => new RoleOptionPairModel
                    {
                        CreatedBy = c.CreatedBy,
                        IsAssigned = c.IsAssigned,
                        CreatedOn = c.CreatedOn,
                        IsSystem = c.IsSystem,
                        ModifiedBy = c.ModifiedBy,
                        ModifiedOn = c.ModifiedOn,
                        Option = c.Option,
                        OptionID = c.OptionID,
                        RequestedByProfileId = c.RequestedByProfileId,
                        //Role = c.Role,
                        RoleID = c.RoleID,
                        RoleOptionPairID = c.RoleOptionPairID,
                        StatusID = c.StatusID,
                        Children = GetChildren(roleOptionPairs, c.Option.OptionID)
                    })
                    .ToList();
        }
    }
}
