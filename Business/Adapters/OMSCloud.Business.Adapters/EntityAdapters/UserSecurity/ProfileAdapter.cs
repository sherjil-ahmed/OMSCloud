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
    public partial class ProfileAdapter
    {
        #region Select
        public List<ProfileModel> GetListByPage(int PageNum, int PageSize_RowCount, string searchString)
        {
            string[] filters = searchString.Split(',');


            var total = uow.OMSContext.Profile.Select(p => p.ProfileID).Count();
            var skip = PageSize_RowCount * (PageNum - 1);
            var cantPage = skip > total;

            if (cantPage) // do what you wish if you can page no further
                return new List<ProfileModel>();
            var profileList = uow.OMSContext.Profile.Select(a => a).Where(a=>a.Nationality != "2")
                .OrderBy(a => a.ProfileID)
                .Skip(skip)
                .Take(PageSize_RowCount)
                .ToList();

            var result = (from a in profileList select GetProfileModel(a)).ToList();

            return result;
        }

        public List<ProfileModel> GetProfileList()
        {
            var profileList = uow.ProfileRepository
                .GetAll()
                .Select(a => GetProfileModel(a))
                .Where(a => a.Nationality != "2")
                .ToList();
            return profileList;
        }

        public List<ProfileModel> GetActiveProfileList()
        {
            var profileList = (from p in uow.OMSContext.Profile
                               where p.Nationality != "2"
                               select new ProfileModel
                               {
                                   ProfileID = p.ProfileID,
                                   UserID = p.UserID,
                                   UserName = "",
                                   UserTypeID = p.UserTypeID ?? (int)DBUserTypeEnum.Buyer,
                                   FirstName = p.FirstName,
                                   MiddleName = p.MiddleName,
                                   LastName = p.LastName,
                                   Nationality = p.Nationality,
                                   FatherName = p.FatherName,
                                   ImagePath = p.ImagePath,
                                   EMail_2FA = p.EMail_2FA,
                                   SMS_2FA = p.SMS_2FA,
                                   CreatedOn = p.CreatedOn,
                                   IsVerified = p.IsVerified.HasValue ? p.IsVerified.Value : false,
                                   ShopId = p.Supplier.Where(s => s.ProfileID == p.ProfileID).Select(s => s.SupplierID).FirstOrDefault(),
                               }).ToList();
            return profileList;
        }

        public ProfileModel GetProfileByProfileId(long Id)
        {
            var profile = GetProfile(Id);// uow.ProfileRepository.GetById(Id);
            //if (profile == null)
                //return null;
            //ProfileModel profileModel = GetProfileModel(profile);
            return profile;
        }

        public ProfileModel GetProfileByEmail(string email, string ProfileState = "2")
        {
            var profileModel = (from p in uow.OMSContext.Profile
                                where 
                                    p.FirstName == email // Anonymous user has email writen in First Name
                                    && 
                                    p.Nationality == ProfileState
                                //1 - indicate user is anonymous
                                //2 - indicate user is subscribed
                                select new ProfileModel
                                {
                                    ProfileID = p.ProfileID,
                                    UserID = p.UserID,
                                    UserName = "",
                                    UserTypeID = p.UserTypeID ?? (int)DBUserTypeEnum.Buyer,
                                    FirstName = p.FirstName,
                                    MiddleName = p.MiddleName,
                                    LastName = p.LastName,
                                    Nationality = p.Nationality,
                                    FatherName = p.FatherName,
                                    ImagePath = p.ImagePath,
                                    EMail_2FA = p.EMail_2FA,
                                    SMS_2FA = p.SMS_2FA,
                                    CreatedOn = p.CreatedOn,
                                    IsVerified = p.IsVerified.HasValue ? p.IsVerified.Value : false,
                                    ShopId = p.Supplier.Where(s => s.ProfileID == p.ProfileID).Select(s => s.SupplierID).FirstOrDefault(),
                                }).FirstOrDefault();
            return profileModel;
        }
        public ProfileModel GetProfile(long? profileId = null, long? UserId = null)
        {
            var profileModel = (from p in uow.OMSContext.Profile
                                where p.Nationality != "2" //exclude subscribed emails they are not valid users
                                select new ProfileModel//GetProfileModel(p)).FirstOrDefault();
                                {
                                    ProfileID = p.ProfileID,
                                    UserID = p.UserID,
                                    UserName = (string.IsNullOrEmpty(p.LastName) ? "" : p.LastName) + "," + (string.IsNullOrEmpty(p.FirstName) ? "" : p.FirstName),
                                    UserTypeID = p.UserTypeID ?? (int)DBUserTypeEnum.Buyer,
                                    FirstName = p.FirstName,
                                    MiddleName = p.MiddleName,
                                    LastName = p.LastName,
                                    FatherName = p.FatherName,
                                    ImagePath = p.ImagePath,
                                    EMail_2FA = p.EMail_2FA,
                                    SMS_2FA = p.SMS_2FA,
                                    CreatedOn = p.CreatedOn,
                                    IsVerified = p.IsVerified.HasValue ? p.IsVerified.Value : false,
                                    ShopId = p.Supplier.Where(s => s.ProfileID == p.ProfileID).Select(s => s.SupplierID).FirstOrDefault(),
                                });
            if (profileId.HasValue)
            {
                profileModel = profileModel.Where(x => x.ProfileID == profileId.Value);
            }
            else if(UserId.HasValue)
            {
                profileModel = profileModel.Where(x => x.UserID == UserId.Value);
            }
            
            return profileModel.FirstOrDefault();
        }

        #endregion Select

        #region Update

        public bool UpdateProfile(ProfileModel profileModel)
        {
            try
            {
                var profile = UpdateConcurrency(GetEntity(profileModel), profileModel);
                var recordsCount = uow.OMSContext.Profile_Update(profile);
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }
        public bool UpdateProfile_2FA(ProfileModel_2FA profileModel)
        {
            try
            {
                var profile = UpdateConcurrency(GetEntity(profileModel), profileModel);
                var recordsCount = uow.OMSContext.Profile_Update_2FA(profile);
                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {

            }
        }

        #endregion Update

        #region Add

        public long? AddProfile(ProfileModel profileModel)
        {
            try
            {
                var profile = UpdateConcurrency(GetEntity(profileModel), profileModel, false);
                var outParam = new ObjectParameter("ProfileID", typeof(int));
                var recordsCount = uow.OMSContext.Profile_Insert(profile, outParam);
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
        public ProfileModel Subscribe(string email)
        {
            var profile = new ProfileModel()
            {
                UserID = DateTime.Now.Ticks,
                UserName = email,// Subscribed user has email writen in UserName 
                EMail_2FA = false,
                SMS_2FA = false,
                FirstName = email,// Subscribed user has email writen in First Name
                LastName = email,// Subscribed user has email writen in Last Name
                Nationality = "2",//2 - indicate user is Subscribed
                PublicUserType = DBUserTypePublicEnum.Buyer,
                UserTypeID = (long)DBUserTypeEnum.Buyer,
                IsVerified = false
            };

            long? vProfileId = this.AddProfile(profile);
            if (vProfileId.HasValue)
                return profile;
            else
                return null;
        }
    
        #endregion Add

        #region Delete
        public bool DeleteProfile(ProfileModel profileModel)
        {
            try
            {
                var profile = GetProfileEntity(profileModel);
                uow.ProfileRepository.Delete(profile);
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
        private ProfileModel GetProfileModel(Profile profile)
        {
            return new ProfileModel()
            {
                ProfileID = profile.ProfileID,
                UserID = profile.UserID,
                FirstName = profile.FirstName,
                MiddleName = profile.MiddleName,
                LastName = profile.LastName,
                FatherName = profile.FatherName,
                Nationality = profile.Nationality,
                Occupation = profile.Occupation,
                Education = profile.Education,
                ImagePath = profile.ImagePath,
                IsVerified = profile.IsVerified.HasValue ? profile.IsVerified.Value : false,
                UserTypeID = (profile.UserTypeID.HasValue ? (int)profile.UserTypeID.Value : (int)DBUserTypePublicEnum.Anonymous),
                SMS_2FA = profile.SMS_2FA,
                EMail_2FA = profile.EMail_2FA,
                CreatedOn = profile.CreatedOn, 
                //AdminUserTypeID = (profile.UserTypeID.HasValue ? (int)profile.UserTypeID.Value : (int)DBUserTypePublicEnum.None),
                //PublicUserType = (profile.UserTypeID.HasValue ? (int)profile.UserTypeID.Value : (int)DBUserTypePublicEnum.None),
            };
        }
        private Profile GetProfileEntity(ProfileModel profileModel)
        {
            return new Profile()
            {
                ProfileID = profileModel.ProfileID,
                UserID = profileModel.UserID,
                FirstName = profileModel.FirstName,
                MiddleName = profileModel.MiddleName,
                LastName = profileModel.LastName,
                FatherName = profileModel.FatherName,
                Nationality = profileModel.Nationality,
                Occupation = profileModel.Occupation,
                Education = profileModel.Education,
                ImagePath = profileModel.ImagePath,
                IsVerified = profileModel.IsVerified,
                UserTypeID = profileModel.UserTypeID,
                SMS_2FA = profileModel.SMS_2FA,
                EMail_2FA = profileModel.EMail_2FA
            };
        }
        #endregion Private
    }
}