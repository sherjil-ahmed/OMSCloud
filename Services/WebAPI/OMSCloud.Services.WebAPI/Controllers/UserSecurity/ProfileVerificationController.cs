using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using static OMSCloud.Contracts.Common.CommonUtilities;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class ProfileVerificationController : ApiController, IProfileVerificationController
    {
        [ReturnType(DataType = typeof(List<ProfileVerificationModelForAdmin>))]
        public IHttpActionResult GetListForAdmin()
        {
            return Ok<List<ProfileVerificationModelForAdmin>>(comp.GetListForAdmin());
        }

        [ReturnType(DataType = typeof(List<ProfileVerificationModelForAdmin>))]
        public IHttpActionResult GetListForAdminByProfileId(long Id)
        {
            return Ok<List<ProfileVerificationModelForAdmin>>(comp.GetListForAdminByProfileId(Id));
        }

        [ReturnType(DataType = typeof(List<ProfileVerificationModelForUser>))]
        public IHttpActionResult GetListForPublic(long Id)
        {
            return Ok<List<ProfileVerificationModelForUser>>(comp.GetListForPublicByProfileId(Id));
        }
        [HttpGet]
        [ReturnType(DataType = typeof(ProfileVerificationModelForAdmin))]
        public IHttpActionResult GetByIdForAdmin(long Id)
        {
            return Ok<ProfileVerificationModelForAdmin>(comp.GetByIdForAdmin(Id));
        }
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult PostForAdmin([FromBody]ProfileVerificationModelForAdmin model)
        {
            if (comp.UpdateProfileVerification(model))
                return Ok<bool>(true);
            return Conflict();
        }

        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult PostForUser([FromBody]ProfileVerificationModelForUser model)
        {
            if (comp.UpdateProfileVerification(model))
                return Ok<bool>(true);
            return Conflict();
        }
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult PutForUser(ProfileVerificationModelForUser model)
        {
            var result = comp.AddProfileVerification(model);
            if (result.HasValue)
                return Ok<long?>(result);
            return Conflict();
        }

        [AllowAnonymous]
        [HttpPost]
        [ReturnType(DataType = typeof(long?))]
        public async Task<IHttpActionResult> PutVerificationDocument(long Id)
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
                    var filePath = GetFilePath(ImageRoute.ProfileVerification, Id);
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
