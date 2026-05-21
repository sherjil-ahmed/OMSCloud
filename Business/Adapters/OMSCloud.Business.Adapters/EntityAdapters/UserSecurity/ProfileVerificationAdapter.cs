using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class ProfileVerificationAdapter
    {
        #region GET
        public List<ProfileVerificationModelForAdmin> GetListForAdmin()
        {
            var result = (from pv in uow.OMSContext.ProfileVerification
                          select new ProfileVerificationModelForAdmin
                          {
                              VerificationID = pv.VerificationID,
                              Comments = pv.Comments,
                              DocumentNumberByVerifier = pv.DocumentNumberByVerifier,
                              DocumentImagePath = pv.DocumentImagePath,
                              DocumentTypeID = pv.DocumentTypeID,
                              DocumentTypeTitle = pv.DocumentType.DocumentTypeTitle,
                              VerificationStatusTitle = pv.VerificationStatus.VerificationStatusTitle,
                              FullName = pv.Profile.FirstName + " " + pv.Profile.MiddleName + " " + pv.Profile.LastName,
                              VerificationStatus = (pv.VerificationStatusID.HasValue ? (DBVerificationStatusEnum)pv.VerificationStatusID.Value  : DBVerificationStatusEnum.Unverified),
                              Verified = pv.VerificationStatusID == (int)DBVerificationStatusEnum.Verified,
                          }).ToList();
            return result;
        }

        public List<ProfileVerificationModelForAdmin> GetListForAdminByProfileId(long profileId)
        {
            var result = (from pv in uow.OMSContext.ProfileVerification
                          where pv.ProfileID == profileId
                          select new ProfileVerificationModelForAdmin
                          {
                              VerificationID = pv.VerificationID,
                              Comments = pv.Comments,
                              DocumentNumberByVerifier = pv.DocumentNumberByVerifier,
                              DocumentImagePath = pv.DocumentImagePath,
                          }).ToList();
            return result;
        }

        public List<ProfileVerificationModelForUser> GetListForPublicByProfileId(long profileId)
        {
            var result = (from pv in uow.OMSContext.ProfileVerification
                          where pv.ProfileID == profileId
                          select new ProfileVerificationModelForUser
                          {
                              VerificationID = pv.VerificationID,
                              ProfileID = pv.ProfileID,
                              DocumentTypeTitle = pv.DocumentType.DocumentTypeTitle,
                              VerificationStatusTitle = pv.VerificationStatus.VerificationStatusTitle,
                              FullName = pv.Profile.FirstName + " " + pv.Profile.MiddleName + " " + pv.Profile.LastName,
                              DocumentNumberByUser = pv.DocumentNumberByUser,
                              DocumentImagePath = pv.DocumentImagePath,
                              DocumentTypeID = pv.DocumentTypeID,
                          }).ToList();
            return result;
        }

        public ProfileVerificationModelForAdmin GetByIdForAdmin(long Id)
        {
            var result = (from pv in uow.OMSContext.ProfileVerification
                          where pv.VerificationID == Id
                          select new ProfileVerificationModelForAdmin
                          {
                              VerificationID = pv.VerificationID,
                              Comments = pv.Comments,
                              DocumentNumberByVerifier = pv.DocumentNumberByVerifier,
                              
                              DocumentImagePath = pv.DocumentImagePath,
                              DocumentTypeTitle = pv.DocumentType.DocumentTypeTitle,
                              DocumentTypeID = pv.DocumentTypeID,
                              VerificationStatusTitle = pv.VerificationStatus.VerificationStatusTitle,
                              VerificationStatus = (pv.VerificationStatusID.HasValue ? (DBVerificationStatusEnum)pv.VerificationStatusID.Value : DBVerificationStatusEnum.Unverified),
                              FullName = pv.Profile.FirstName + " " + pv.Profile.MiddleName + " " + pv.Profile.LastName,
                              RequestedByProfileId = pv.ProfileID,
                          }).FirstOrDefault();
            return result;
        }
        #endregion GET

        #region update-add
        public long? AddProfileVerification(ProfileVerificationModel profileVerificationModel)
        {
            try
            {
                var profileVerification = UpdateConcurrency(GetEntity(profileVerificationModel), profileVerificationModel, false);
                var outParam = new ObjectParameter("VerificationID", typeof(int));
                var recordsCount = uow.OMSContext.ProfileVerification_Insert(profileVerification, outParam);
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

        public bool UpdateProfileVerification(ProfileVerificationModel profileVerificationModel)
        {
            try
            {
                var profile = UpdateConcurrency(GetEntity(profileVerificationModel), profileVerificationModel);
                var recordsCount = uow.OMSContext.ProfileVerification_Update(profile);
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
        
        public bool ChangeVerificationStatus(ProfileVerificationModel profileVerificationModel)
        {
            try
            {
                var profile = UpdateConcurrency(GetEntity(profileVerificationModel), profileVerificationModel);
                var recordsCount = uow.OMSContext.ProfileVerification_ChangeVerificationStatus(profile);
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

        public bool UpdateProfileVerificationByUser(ProfileVerificationModel profileVerificationModel)
        {
            try
            {
                var profile = UpdateConcurrency(GetEntity(profileVerificationModel), profileVerificationModel);
                var recordsCount = uow.OMSContext.ProfileVerification_UpdateByUser(profile);
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
        #endregion update-add

        #region Private
        protected ProfileVerificationModelForAdmin GetModelForAdmin(ProfileVerification entity)
        {
            return new ProfileVerificationModelForAdmin
            {
                VerificationID = entity.VerificationID,
                Comments = entity.Comments,
                DocumentNumberByVerifier = entity.DocumentNumberByVerifier,
                DocumentImagePath = entity.DocumentImagePath,
            };
        }
        protected ProfileVerificationModelForUser GetModelForUser(ProfileVerification entity)
        {
            return new ProfileVerificationModelForUser
            {
                VerificationID = entity.VerificationID,
                ProfileID = entity.ProfileID,
                DocumentNumberByUser = entity.DocumentNumberByUser,
                DocumentImagePath = entity.DocumentImagePath,
            };
        }
        #endregion Private
    }
}
