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
    public partial class UserAdapter
    {
        #region select
        public List<UserModel> GetUserList()
        {
            var userList = uow.UserRepository.GetAll().Select(a => GetUserModel(a)).ToList();
            return userList;
        }

        public UserModel GetUserById(long Id)
        {

            var user = uow.UserRepository.GetById(Id);
            UserModel UserModel = GetUserModel(user);
            return UserModel;



        }

        public List<UserModel> GetUserByStatus(DBStatusEnum status)
        {
            var result = from user in uow.UserRepository.OMSContext.User
                         where user.StatusID == (int)status
                         select GetUserModel(user);
            return result.ToList();
        }
        #endregion select

        #region Security
        public UserModel LoginUser(LoginModel model)
        {
            try
            {
                var userQuery = (from u in uow.OMSContext.User
                                 where
                                   u.UserName.ToLower() == model.UserName.ToLower() &&
                                   u.UserPassword == model.Password &&
                                   u.StatusID <= (int)DBStatusEnum.Active &&
                                   u.IsLoggedIn == false &&
                                   u.ApprovedByUserID != null &&
                                   u.AcvtivationGUID != null
                                 select new UserModel
                                 {
                                     UserID = u.UserID,
                                     UserName = u.UserName,
                                     UserPassword = u.UserPassword,
                                     Useremail = u.Useremail,
                                     PasswordResetCode = u.PasswordResetCode,
                                     AcvtivationGUID = u.AcvtivationGUID,
                                     StatusID = u.StatusID,
                                     IsLoggedIn = u.IsLoggedIn,
                                     IsSystem = u.IsSystem,
                                     GroupID = u.GroupID,
                                     ApprovedByUserID = u.ApprovedByUserID,
                                     ApprovedDateTime = u.ApprovedDateTime
                                 });
                if (model.AppCode == AppCodeEnum.WebFrontEnd || model.AppCode == AppCodeEnum.iOSFrontEnd || model.AppCode == AppCodeEnum.AndroidFrontEnd)
                    userQuery.Where(
                        u =>
                        u.UserType == DBUserTypeEnum.Anonymous ||
                        u.UserType == DBUserTypeEnum.Buyer ||
                        u.UserType == DBUserTypeEnum.Seller ||
                        u.UserType == DBUserTypeEnum.Admin
                    );
                else if (model.AppCode == AppCodeEnum.WebBackEnd || model.AppCode == AppCodeEnum.iOSBackEnd || model.AppCode == AppCodeEnum.AndroidBackEnd)
                    userQuery.Where(
                        u =>
                        u.UserType == DBUserTypeEnum.Admin //||
                        //u.UserType == DBUserTypeEnum.BackEndBusinessUser ||
                        //u.UserType == DBUserTypeEnum.BackEndAdminUser
                    );
                var result = userQuery.ToList();
                if (result.Count() > 0)
                {
                    var user = result.First();
                    user.UserPassword = string.Empty;
                    return user;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }

        public bool ChangePassword(ChangePasswordModel model)
        {
            var outParam = new ObjectParameter("IsChanged", typeof(bool));
            var recordsCount = 0;// uow.OMSContext.User_UpdatePassword(model, outParam);
            if (recordsCount < 1 || (bool)outParam.Value == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion Security

        #region Update
        public bool UpdateUser(UserModel userModel)
        {
            try
            {
                var user = UpdateConcurrency(GetEntity(userModel), userModel);
                var recordsCount = uow.OMSContext.User_Update(user);
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
        public long? AddUser(UserModel userModel)
        {
            try
            {
                var user = UpdateConcurrency(GetEntity(userModel), userModel, false);
                var outParam = new ObjectParameter("UserID", typeof(int));
                var recordsCount = uow.OMSContext.User_Insert(user, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {

            }
        }
        #endregion Add

        #region Delete
        public bool DeleteUser(UserModel userModel)
        {
            try
            {
                var user = GetUserEntity(userModel);
                uow.UserRepository.Delete(user);
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

        public UserModel GetUserModel(User user)
        {
            return new UserModel()
            {
                UserID = user.UserID,
                UserName = user.UserName,
                UserPassword = user.UserPassword,
                Useremail = user.Useremail,
                PasswordResetCode = user.PasswordResetCode,
                AcvtivationGUID = user.AcvtivationGUID,
                StatusID = user.StatusID,
                IsLoggedIn = user.IsLoggedIn,
                IsSystem = user.IsSystem,
                GroupID = user.GroupID,
                CreatedBy = user.CreatedByUserID,
                ModifiedBy = user.LastModifiedByUserID,
                CreatedOn = user.CreatedDateTime,
                ModifiedOn = user.LastModifiedDateTime,
                ApprovedByUserID = user.ApprovedByUserID,
                ApprovedDateTime = user.ApprovedDateTime

            };
        }

        public User GetUserEntity(UserModel userModel)
        {
            return new User()
            {
                UserID = userModel.UserID,
                UserName = userModel.UserName,
                UserPassword = userModel.UserPassword,
                Useremail = userModel.Useremail,
                PasswordResetCode = userModel.PasswordResetCode,
                AcvtivationGUID = userModel.AcvtivationGUID,
                StatusID = userModel.StatusID,
                IsLoggedIn = userModel.IsLoggedIn,
                IsSystem = userModel.IsSystem,
                GroupID = userModel.GroupID,
                //CreatedByUserID = userModel.CreatedByUserID,
                //LastModifiedByUserID = userModel.LastModifiedByUserID,
                //CreatedDateTime = userModel.CreatedDateTime,
                //LastModifiedDateTime = userModel.LastModifiedDateTime,
                ApprovedByUserID = userModel.ApprovedByUserID,
                ApprovedDateTime = userModel.ApprovedDateTime

            };

        }
        #endregion private


    }
}