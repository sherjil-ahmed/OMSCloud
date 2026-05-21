using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Core
{
    public partial class ProfileVerificationBusinessComponent
    {
        public List<ProfileVerificationModelForAdmin> GetListForAdmin()
        {
            return adapter.GetListForAdmin();
        }

        public List<ProfileVerificationModelForAdmin> GetListForAdminByProfileId(long profileId)
        {
            return adapter.GetListForAdminByProfileId(profileId);
        }

        public List<ProfileVerificationModelForUser> GetListForPublicByProfileId(long profileId)
        {
            return adapter.GetListForPublicByProfileId(profileId);
        }
        public ProfileVerificationModelForAdmin GetByIdForAdmin(long Id)
        {
            return adapter.GetByIdForAdmin(Id);
        }

        public long? AddProfileVerification(ProfileVerificationModel Profile)
        {
            return adapter.AddProfileVerification(Profile);
        }

        public long? AddProfileVerification(ProfileVerificationModelForUser Profile)
        {
            var model = new ProfileVerificationModel
            {
                VerificationID = Profile.VerificationID,
                DocumentTypeID = Profile.DocumentTypeID,
                VerifiedBy = null,
                VerifiedOn = null,
                Comments = null,
                VerificationStatusID = (int)(DBVerificationStatusEnum.Unverified),
                ProfileID = Profile.ProfileID,
                DocumentNumberByUser = Profile.DocumentNumberByUser,
                DocumentNumberByVerifier = null,
                DocumentImagePath = Profile.DocumentImagePath
            };
            return adapter.AddProfileVerification(model);
        }

        public bool UpdateProfileVerification(ProfileVerificationModel model)
        {
            return adapter.UpdateProfileVerification(model);
        }

        public bool UpdateProfileVerification(ProfileVerificationModelForAdmin modelAdmin)
        {
            var model = new ProfileVerificationModel
            {
                VerificationID = modelAdmin.VerificationID,
                VerifiedBy = modelAdmin.RequestedByProfileId,
                //VerifiedOn = DateTime.Now, -- SP will handle
                Comments = modelAdmin.Comments,
                VerificationStatusID = (int)(modelAdmin.VerificationStatus),
                DocumentNumberByVerifier = modelAdmin.DocumentNumberByVerifier,
            };
            return adapter.ChangeVerificationStatus(model);
        }

        public bool UpdateProfileVerification(ProfileVerificationModelForUser Profile)
        {
            var model = new ProfileVerificationModel
            {
                VerificationID = Profile.VerificationID,
                DocumentTypeID = Profile.DocumentTypeID,
                DocumentNumberByUser = Profile.DocumentNumberByUser,
                DocumentImagePath = Profile.DocumentImagePath
            };
            return adapter.UpdateProfileVerificationByUser(model);
        }
    }
}
