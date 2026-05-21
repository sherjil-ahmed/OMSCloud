using System;
using System.Linq;
using System.Collections.Generic;

//using OMSCloud.Contracts.Common;
using OMSCloud.DataStore.EF.IRepositories;
using OMSCloud.DataStore.EF.Repositories;
using OMSCloud.DataStore.EF.OMSModel;

namespace OMSCloud.DataStore.EF.Repositories
{
    /*
    public partial class ContractRepository : OMSCloudRepositoryBase<Contract>, IContractRepository
    { 
        public bool IsAllowed(int userID, Guid authCode, DBOption option)
        {
            return (from user in base.SprinxleDBContext.User
                    join ro in base.SprinxleDBContext.RoleOptionPair
                          on user.RoleID equals ro.RoleID
                    where
                      user.UserID == userID
                      &&
                      user.AuthCode_WebDesktop == authCode
                      &&
                      ro.OptionID == (int)option
                    select ro.OptionID).Any();
        }

        public ActionSignature GetActionSignature(DBOption anOption)
        {
                    var list = (
                from option in base.SprinxleDBContext.Option
                join execAction in base.SprinxleDBContext.ExecAction
                on option.ExecActionID equals execAction.ExecActionID

                join component in base.SprinxleDBContext.DataType
                on execAction.DataTypeID equals component.DataTypeID

                join param in base.SprinxleDBContext.ActionParam
                on execAction.ExecActionID equals param.ExecActionID

                join paramType in base.SprinxleDBContext.DataType
                on param.DataTypeID equals paramType.DataTypeID

                where
                  option.OptionID == (int)anOption
                select new ActionSignature
                {
                    ComponentAssemblyName = component.AssemblyName,
                    ComponentNamespace = component.Namespace,
                    ComponentClassName = component.ClassName,
                    ActionName = execAction.ActionName,
                    ParamName = param.ParamName,
                    ParamTypeAssemblyName = paramType.AssemblyName,
                    ParamTypeNamespace = paramType.Namespace,
                    ParamTypeClassName = paramType.ClassName
                }).FirstOrDefault();
            return list;

        }

        public List<DBOption> GetAllowedOptionsByOptionType(int UserID, DBOptionType optionType)
        {
            return (from user in base.SprinxleDBContext.User
                    join ro in base.SprinxleDBContext.RoleOptionPair
                    on user.RoleID equals ro.RoleID
                    join o in base.SprinxleDBContext.Option
                    on ro.OptionID equals o.OptionID
                    where
                      o.StatusID == (int)DBStatus.Active
                      &&
                      (user.UserID == UserID
                      &&
                      ro.IsAssigned == true
                      &&
                      o.OptionTypeID == (int)optionType)
                      ||
                      o.AllowAnonymous == true
                    select (DBOption)ro.OptionID).ToList();
        }
    }
    */
}
