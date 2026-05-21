using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using static OMSCloud.Contracts.Common.NLogger;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System.Web;
using OMSCloud.Contracts.Common.ConfigMgmt;
using System.IO;
using System.Threading.Tasks;
using static OMSCloud.Contracts.Common.CommonUtilities;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class CategoryController : ApiController, ICategoryController
    {
        [ReturnType(DataType = typeof(List<CategoryModel>))]
        public IHttpActionResult GetCategoryList()
        {
            return Ok<List<CategoryModel>>(comp.GetCategoryList());
        }

        [ReturnType(DataType = typeof(List<CategoryLookupModel>))]
        public IHttpActionResult GetCategoryListLookup()
        {
            return Ok<List<CategoryLookupModel>>(comp.GetCategoryListLookup());
        }

        [ReturnType(DataType = typeof(List<CategoryLookupModel>))]
        public IHttpActionResult GetCategoryListNotAssociatedWithProductId(long Id)
        {
            return Ok<List<CategoryLookupModel>>(comp.GetCategoryListNotAssociatedWithProductId(Id));
        }

        [ReturnType(DataType = typeof(CategorySearchResultAdminModel))]
        public IHttpActionResult GetListByPage(int PageNum, int PageSize_RowCount, string searchString,string sortOrder)
        {
            return Ok<CategorySearchResultAdminModel>(comp.GetListByPage(PageNum, PageSize_RowCount, searchString, sortOrder));
        }

        [AllowAnonymous]
        [HttpPost]
        [ReturnType(DataType = typeof(long?))]
        public async Task<IHttpActionResult> PutImageByCategoryId(long Id)
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
                    var filePath = GetFilePath(ImageRoute.Category, Id);
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
