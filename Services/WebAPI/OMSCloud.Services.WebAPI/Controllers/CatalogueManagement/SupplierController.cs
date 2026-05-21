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
using OMSCloud.Services.WebAPIs.Hubs;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class SupplierController : ApiController, ISupplierController
    {
        [ReturnType(DataType = typeof(SupplierSearchResultAdminModel))]
        public IHttpActionResult GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder)
        {
            var model = comp.GetListByPage(PageNum, PageSize_RowCount, searchString, sortOrder);

            return Ok<SupplierSearchResultAdminModel>(model);
        }
        
        [HttpPost]
        [ReturnType(DataType = typeof(long))]
        public IHttpActionResult GetCountByFilter(ShopStatsModel statsRequestModel)
        {
            var model = comp.GetCountByFilter(statsRequestModel);

            return Ok<long>(model);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(SupplierSearchResultAdminModel))]
        public IHttpActionResult GetListByPage(SearchModel searchModel)
        {
            var model = comp.GetListByPage(searchModel);

            return Ok<SupplierSearchResultAdminModel>(model);
        }

        [ReturnType(DataType = typeof(SupplierViewModel))]
        public IHttpActionResult GetSupplierById(long Id)
        {
            var model = comp.GetSupplierById(Id);
            
            return Ok<SupplierViewModel>(model);
        }

        [ReturnType(DataType = typeof(SupplierViewModel))]
        public IHttpActionResult GetSupplierByProfileId(long Id)
        {
            var model = comp.GetSupplierByProfileId(Id);

            return Ok<SupplierViewModel>(model);
        }

        [ReturnType(DataType = typeof(ShopPublicProfileModel))]
        public IHttpActionResult GetShopPublicProfile(long Id, long Id1 = -1)
        {
            var model = comp.GetShopPublicProfile(Id, Id1);

            return Ok<ShopPublicProfileModel>(model);
        }

        [HttpPost]
        [ReturnType(DataType = typeof(ShopSearchResultModel))]
        public IHttpActionResult GetShopPublicList(ShopSearchModel shopSearchModal)
        {
            var model = comp.GetShopPublicList(shopSearchModal);

            return Ok<ShopSearchResultModel>(model);
        }

        [ReturnType(DataType = typeof(Boolean))]
        public IHttpActionResult GetSupplierByName(string supplierName)
        {
            return Ok<Boolean>(comp.GetSupplierByName(supplierName));
        }

        [ReturnType(DataType = typeof(CategoryAttributeRequestModel))]
        public IHttpActionResult GetCategoryAttributeRequestBySupplierId(long Id)
        {
            return Ok<CategoryAttributeRequestModel>(comp.GetCategoryAttributeRequestBySupplierId(Id));
        }

        [HttpGet]
        [ReturnType(DataType = typeof(ShopTaxInfoModel))]
        public IHttpActionResult GetShopTaxInfo(long Id)
        {
            return Ok<ShopTaxInfoModel>(comp.GetShopTaxInfo(Id));
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult PostSupplierDetails(ShopPublicProfileModel model)
        {

            if (model != null)
             {
                model.StatusID = (int)DBStatusEnum.New;
                if (comp.UpdateSupplierDetails(model))
                {
                    SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Shop, model.ShopID);
                    return Ok<bool>(true);
                }
            }
            return Conflict();
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult ApproveSupplierList(string SupplierCSV)
        {
            if (string.IsNullOrEmpty(SupplierCSV))
                return BadRequest("Empty list of Shop Ids. Nothing to process.");
            var ListString = SupplierCSV.Split(',');
            List<long> SupplierListLong = new List<long>();
            foreach (var id in ListString)
            {
                long x = 0;
                Int64.TryParse(id, out x);
                SupplierListLong.Add(x);
            }
            if (comp.ApproveSupplierList(SupplierListLong))
            {
                foreach (var id in SupplierListLong)
                {
                    SendNotificationQueue.Instance.SendNotification(NotificationTypeEnum.Shop, id);
                }
                return Ok<bool>(true);
            }
            return Conflict();
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult UpdateSupplierCategoryRequests(CategoryRequestModel model)
        {
            if (comp.UpdateSupplierCategoryRequests(model))
            {
                //NotificationHub.SendNotification(NotificationTypeEnum.Shop, model.SupplierID);
                return Ok<bool>(true);
            }
            return Conflict();
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult UpdateShopTaxInfo(ShopTaxInfoModel model)
        {
            if (comp.UpdateShopTaxInfo(model))
            {
                //NotificationHub.SendNotification(NotificationTypeEnum.Shop, model.SupplierID);
                return Ok<bool>(true);
            }
            return Conflict();
        }

        [HttpPost]
        [ReturnType(DataType = typeof(bool))]
        public IHttpActionResult UpdateSupplierAttributeRequests(AttributeRequestModel model)
        {
            if (comp.UpdateSupplierAttributeRequests(model))
            {
                //NotificationHub.SendNotification(NotificationTypeEnum.Shop, model.SupplierID);
                return Ok<bool>(true);
            }
            return Conflict();
        }

        [AllowAnonymous]
        [HttpPost]
        [ReturnType(DataType = typeof(long?))]
        public async Task<IHttpActionResult> PutImageByShopId(long Id)
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
                    var filePath = GetFilePath(ImageRoute.Supplier, Id);
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
