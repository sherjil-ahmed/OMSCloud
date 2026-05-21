using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.UnitofWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class UserTypeAdapter
    {
        #region select
        public List<UserTypeModel> GetUserTypeList()
        {
            var userTypeList = uow.UserTypeRepository.GetAll().Select(a => GetUserTypeModel(a)).ToList();
            return userTypeList;

        }

        public UserTypeModel GetUserTypeById(long Id)
        {
            var userType = uow.UserTypeRepository.GetById(Id);
            UserTypeModel UserTypeModel = GetUserTypeModel(userType);
            return UserTypeModel;
        }
        #endregion select

        #region update

        public bool UpdateUserType(UserTypeModel userTypeModel)
        {
            try
            {
                var userType = UpdateConcurrency(GetEntity(userTypeModel), userTypeModel);
                var recordsCount = uow.OMSContext.UserType_Update(userType);
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
        #endregion update

        #region Add
        public long? AddUserType(UserTypeModel userTypeModel)
        {
            try
            {
                var userType = UpdateConcurrency(GetEntity(userTypeModel), userTypeModel, false);
                var outParam = new ObjectParameter("UserTypeID", typeof(int));
                var recordsCount = uow.OMSContext.UserType_Insert(userType, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch
            {
                return null;
            }
            finally
            {

            }
        }
        #endregion Add

        #region Delete
        public bool DeleteUserType(UserTypeModel userTypeModel)
        {
            try
            {
                var userType = GetUserTypeEntity(userTypeModel);
                uow.UserTypeRepository.Add(userType);
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

        #region private

        public UserTypeModel GetUserTypeModel(UserType userType)
        {
            return new UserTypeModel()
            {
                UserTypeID = userType.UserTypeID,
                UserTypeTitle = userType.UserTypeTitle,
                Description = userType.Description

            };
        }
        public UserType GetUserTypeEntity(UserTypeModel userTypeModel)
        {
            return new UserType()
            {
                UserTypeID = userTypeModel.UserTypeID,
                UserTypeTitle = userTypeModel.UserTypeTitle,
                Description = userTypeModel.Description
            };
        }

        #endregion private

    }
}