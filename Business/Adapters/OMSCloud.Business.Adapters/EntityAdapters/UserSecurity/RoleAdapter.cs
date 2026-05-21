using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.UnitofWork;
using OMSCloud.DataStore.EF.OMSModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.Common.DBEnums;
using System.Data.Entity.Core.Objects;

namespace OMSCloud.Business.Adapters
{
    public partial class RoleAdapter
    {
        #region Select
        public List<RoleModel> GetRoleList()
        {
            var roleList = uow.RoleRepository.GetAll().Select(a => GetRoleModel(a)).ToList();
            return roleList;
        }

        public RoleModel GetRoleById(long Id)
        {
            var role = uow.RoleRepository.GetById(Id);
            RoleModel roleModel = GetRoleModel(role);
            return roleModel;
        }

        public List<RoleModel> GetRoleByStatus(DBStatusEnum status)
        {
            var result = from role in uow.RoleRepository.OMSContext.Role
                         where role.StatusID == (int)status
                         select GetRoleModel(role);
            return result.ToList();
        }
        #endregion Select

        #region Update

        public bool UpdateRole(RoleModel roleModel)
        {
            try
            {
                var role = UpdateConcurrency(GetEntity(roleModel), roleModel);
                var recordsCount = uow.OMSContext.Role_Update(role);
                return recordsCount > 0;
            }
            catch
            {
                return false;
            }
            finally
            {

            }
        }

        #endregion Update

        #region Add

        public long? AddRole(RoleModel roleModel)
        {
            try
            {
                var role = UpdateConcurrency(GetEntity(roleModel), roleModel, false);
                var outParam = new ObjectParameter("RoleID", typeof(int));
                var recordsCount = uow.OMSContext.Role_Insert(role, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                return null;
            }
            finally
            {

            }
        }

        #endregion Add

        #region Delete
        public bool DeleteRole(RoleModel roleModel)
        {
            try
            {
                var role = GetRoleEntity(roleModel);
                uow.RoleRepository.Delete(role);
                uow.Commit();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion Delete

        #region Private
        private RoleModel GetRoleModel(Role role)
        {
            return new RoleModel()
            {
                RoleID = role.RoleID,
                RoleTitle = role.RoleTitle,
                Description = role.Description,
                IconPath = role.IconPath,
                StatusID = role.StatusID,
                IsSystem = role.IsSystem
            };
        }
        private Role GetRoleEntity(RoleModel roleModel)
        {
            return new Role()
            {
                RoleID = roleModel.RoleID,
                RoleTitle = roleModel.RoleTitle,
                Description = roleModel.Description,
                IconPath = roleModel.IconPath,
                StatusID = roleModel.StatusID,
                IsSystem = roleModel.IsSystem
            };
        }
        #endregion Private

    }
}