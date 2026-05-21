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
    public partial class ProfileBusinessComponent
    {
        public List<ProfileModel> GetProfileList()
        {
            return adapter.GetProfileList();
        }
        
        public List<ProfileModel> GetActiveProfileList()
        {
            return adapter.GetActiveProfileList();
        }
        public ProfileModel GetProfileByProfileId(long Id)
        {
            return adapter.GetProfileByProfileId(Id);
        }
        public ProfileModel GetProfileByEmail(string email)
        {
            return adapter.GetProfileByEmail(email);
        }
        public ProfileModel GetProfileByUserId(long Id)
        {
            return adapter.GetProfile(null, Id);
        }
        public ProfileModel Subscribe(string email)
        {
            return adapter.Subscribe(email);
        }

        public long? AddProfile(ProfileModel Profile)
        {
            return adapter.AddProfile(Profile);
        }
        public bool UpdateProfile(ProfileModel Profile)
        {
            return adapter.UpdateProfile(Profile);
        }
        public bool UpdateProfile_2FA(ProfileModel_2FA Profile)
        {
            return adapter.UpdateProfile_2FA(Profile);
        }
        public bool DeleteProfile(ProfileModel Profile)
        {
            return adapter.DeleteProfile(Profile);
        }
        public string GetDisplayDescription(ProfileModel profile)
        {
            try
            {
                if (profile != null)
                    return (string.IsNullOrEmpty(profile.FirstName) ? "" : profile.FirstName) + (string.IsNullOrEmpty(profile.LastName) ? "" : ", " + profile.LastName);
                else
                    return "";
            }
            catch(Exception ex)
            {
                return "";
            }
        }
    }
}
