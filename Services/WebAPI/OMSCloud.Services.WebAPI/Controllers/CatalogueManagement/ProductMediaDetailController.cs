using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using static OMSCloud.Contracts.Common.CommonUtilities;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Common.DBEnums;
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
using System.Drawing;
using System.Drawing.Imaging;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class ProductMediaDetailController : ApiController, IProductMediaDetailController
    {
        [AllowAnonymous]
        [HttpPost]
        [ReturnType(DataType = typeof(long?))]
        public async Task<IHttpActionResult> PutImageByProductId(long Id, bool isDefault)
        {
            
            try
            {/*
                var httpRequest = HttpContext.Current.Request;

                foreach (string file in httpRequest.Files)
                {
                    HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created);

                    var postedFile = httpRequest.Files[file];
                    if (postedFile != null && postedFile.ContentLength > 0)
                    {

                        int MaxContentLength = 1024 * 1024 * 10; //Size = 1 MB  

                        IList<string> AllowedFileExtensions = new List<string> { ".jpg", ".gif", ".png" };
                        var ext = Path.GetExtension(file);
                        var extension = ext.ToLower();
                        if (!AllowedFileExtensions.Contains(extension))
                        {

                            var message = string.Format("Please Upload image of type .jpg,.gif,.png.");
                        }
                        else if (postedFile.ContentLength > MaxContentLength)
                        {
                            var message = string.Format("Please Upload a file upto 1 mb.");
                        }
                        else
                        {
                            var filePath = HttpContext.Current.Server.MapPath("~/" + file);
                            postedFile.SaveAs(filePath);
                        }
                    }

                    var message1 = string.Format("Image Updated Successfully.");
                    //return Ok();
                }*/



                if (Request.Content.IsMimeMultipartContent())
                {
                    var result = await Request.Content.ReadAsMultipartAsync();
                    if (result == null || result.Contents == null || result.Contents.Count <= 0)
                        return Ok("Request does not contain any image");

                    var root = HttpContext.Current.Server.MapPath("~/");
                    var dynamicContentLocation = Config.DynamicContent;
                    var filePath = GetFilePath(isDefault ? ImageRoute.Product : ImageRoute.ProductMediaDetail, Id);
                    var relativePath = Path.Combine(dynamicContentLocation, filePath);
                        relativePath = ConvertToWindowsFileSystemPath(relativePath);
                    var relativeWebPath = ConvertToWebPath(relativePath);
                    var fullPath = ConvertToWindowsFileSystemPath(Path.Combine(root + relativePath));
 
                    if (!Directory.Exists(Path.GetDirectoryName(fullPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
                    }
                    int count = 0;
                    string FullPathAndFileName = string.Empty;
                    string FullPathAndFileName_raw = string.Empty;
                    Image sourceImage = null;
                    foreach (var content in result.Contents)
                    {
                        var fileBytes = content.ReadAsByteArrayAsync().Result;
                        //byte[] newArray = new byte[(long)(fileBytes.Length / 10)];
                        //Array.Copy(fileBytes, newArray, (long)(fileBytes.Length / 10));
                        var ContentFileName = content.Headers.ContentDisposition.Name.Replace("\"", "");
                        var fileName = (string.IsNullOrEmpty(ContentFileName)) 
                            ? 
                            "Test_" + count + ".img"
                            :
                            ContentFileName;
                        var fileName_raw = Path.GetFileNameWithoutExtension(fileName) + "_raw" + Path.GetExtension(fileName);
                        FullPathAndFileName = Path.Combine(fullPath, (fileName));
                        //FullPathAndFileName_raw = Path.Combine(fullPath, (fileName_raw));
                        //File.WriteAllBytes(FullPathAndFileName_raw, fileBytes);
                        MemoryStream ms = new MemoryStream(fileBytes);
                        sourceImage = Image.FromStream(ms);
                        count++;
                    }
                    if(sourceImage != null)
                         ResizeImageOriginalRatio(FullPathAndFileName, sourceImage);
                    
                    return Ok<int>(count);
                }
                return Ok("Request does not contain any image");
            }
            catch (Exception ex)
            {
               NLogger.Log.Error(ex);
               //throw ex;
               return Ok(0);
            }
        }

        [HttpPut]
        [ReturnType(DataType = typeof(long?))]
        public IHttpActionResult PutImage(ProductImageModel image)
        {
            long? Id = null;
            if (image != null)
            {
                Id = comp.AddProductMediaDetail(
                    new ProductMediaDetailModel
                    {
                        ProductMediaTitle = "ImageFileName: " + image.ImageFileName,
                        ProductID = image.ProductId,
                        MediaFilePath = image.ImageFileName,
                        StatusID = (long)DBStatusEnum.Active,
                        Height = 20,
                        Width = 20,
                        MediaContentTypeID = (long)DBHTMLContentTypeEnum.PortableNetworkGraphics, //image/png	image/webp
                    TransparencyLevel = 1,
                        Description = image.IsDefault ? "default" : string.Empty,
                    });
            }
            if (Id.HasValue)
            {
                //ProductBusinessComponent pbc = new ProductBusinessComponent();
                //if (pbc.UpdateProductStatus(image.ProductId, DBStatusEnum.New))
                //{
                    return Ok<long?>(Id);
                //}
            }
            return Conflict();
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult SetImageAsDefault(long id)
        {
            var productImageModel = comp.GetProductMediaDetailById(id);
            productImageModel.Description = "default";
            if (comp.UpdateProductMediaDetail(productImageModel))
                return Ok(true);
            else
                return Ok(false);
        }
    }
}
