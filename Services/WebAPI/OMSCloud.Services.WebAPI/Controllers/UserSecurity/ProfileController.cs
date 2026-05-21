using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using static OMSCloud.Contracts.Common.CommonUtilities;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Threading.Tasks;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    [AllowAnonymous]
    public partial class ProfileController : ApiController, IProfileController
    {
        [HttpGet]
        [ReturnType(DataType = typeof(Int32))]
        public IHttpActionResult Subscribe(string email)
        {
            ProfileModel profile = null;
            int result = 0;
            ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = _userMgr.FindByEmail(email);
            if (user != null)
            {
                //User already exists, no need to call subscribe
                //simply try to get the existing profile
                profile = comp.GetProfileByUserId(user.Id);
                result = 1; // Registered User Already Exists
            }
            if(profile == null)
            {
                profile = comp.GetProfileByEmail(email);
                if (profile != null)
                {
                    result = 2; //Email Already Subscribed
                }
                else
                {
                    result = 3; // Email Successfully scribed
                    profile = comp.Subscribe(email);
                    var message = new IdentityMessage {
                        Subject = "Zvonr Subscription successful",
                        Destination = email,
                        Body = string.Format("Dear {0}, Thanks for the subscription request. Your have successfully subscribed to the Zvonr Marketplace." 
                        + Environment.NewLine +
                        "To unsubscribe, kindly send an email to support@zvonr.ca from your subscribed email account with subjectline \"Unsubscribe\". The Zvonr-Admin will remove your email subscription list at Zvonr Marketplace." , 
                        email) };
                    _userMgr.EmailService.Send(message);
                }
            }

            if (profile != null)
                return Ok<Int32>(result);
            return Conflict();
        }

        [HttpGet]
        [ReturnType(DataType = typeof(List<ProfileModel>))]
        public IHttpActionResult GetActiveProfileList()
        {
            return Ok<List<ProfileModel>>(comp.GetActiveProfileList());
        }

        // GET: api/Profile/GetProfileByUserId/5
        [HttpGet]
        [ReturnType(DataType = typeof(ProfileModel))]
        public IHttpActionResult GetProfileByUserId(long Id)
        {
            var profile = comp.GetProfileByUserId(Id);
            ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = _userMgr.FindById(profile.UserID);
            profile.UserName = user.UserName;
            if (profile != null)
                return Ok<ProfileModel>(profile);
            return Conflict();
        }

        [HttpGet]
        [ReturnType(DataType = typeof(ProfileModel))]
        public IHttpActionResult GetProfileByUserName(string userName)
        {
            ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = _userMgr.FindByName(userName);
            var profile = comp.GetProfileByUserId(user.Id);
            if (profile != null)
            {
                profile.UserName = userName;
                return Ok<ProfileModel>(profile);
            }
            return Conflict();
        }

        [HttpGet]
        [ReturnType(DataType = typeof(ProfileModel))]
        public IHttpActionResult GetProfileByEmail(string eMail)
        {
            ApplicationUserManager _userMgr = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = _userMgr.FindByEmail(eMail);
            var profile = comp.GetProfileByUserId(user.Id);
            if (profile != null)
            {
                profile.UserName = user.UserName;

                ChatMessageBusinessComponent cmbc = new ChatMessageBusinessComponent();                
                profile.UnreadMessageCount = cmbc.GetUnreadMessageCountByProfileId(profile.ProfileID);

                return Ok<ProfileModel>(profile);
            }
            return Conflict();
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult UpdateProfile_2FA(ProfileModel_2FA model)
        {
            if (comp.UpdateProfile_2FA(model))
                return Ok<bool>(true);
            return Conflict();
        }

        [AllowAnonymous]
        [HttpPost]
        [ReturnType(DataType = typeof(long?))]
        public async Task<IHttpActionResult> PutImageByProfileId(long Id)
        {
            try
            {
                if (Request.Content.IsMimeMultipartContent())
                {
                    var result = await Request.Content.ReadAsMultipartAsync();
                    if (result == null || result.Contents == null || result.Contents.Count <= 0)
                        return Ok("Request does not contain any image");

                    var root = HttpContext.Current.Server.MapPath("~/");
                    var dynamicContentLocation = Config.DynamicContent;
                    var filePath = GetFilePath(ImageRoute.Profile, Id);
                    var relativePath = Path.Combine(dynamicContentLocation, filePath);
                    relativePath = ConvertToWindowsFileSystemPath(relativePath);
                    var relativeWebPath = ConvertToWebPath(relativePath);
                    var fullPath = ConvertToWindowsFileSystemPath(Path.Combine(root + relativePath));

                    if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                    }
                    int count = 0;
                    foreach (var content in result.Contents)
                    {
                        var fileBytes = content.ReadAsByteArrayAsync().Result;
                        string fileName = (string.IsNullOrEmpty(content.Headers.ContentDisposition.Name.Replace("\"", ""))) ? "Test" + count : content.Headers.ContentDisposition.Name;
                        File.WriteAllBytes(Path.Combine(fullPath, (fileName.Replace("\"", ""))), fileBytes);
                        count++;
                    }
                    return Ok<int>(count);
                }
                return Ok("Request does not contain any image");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
