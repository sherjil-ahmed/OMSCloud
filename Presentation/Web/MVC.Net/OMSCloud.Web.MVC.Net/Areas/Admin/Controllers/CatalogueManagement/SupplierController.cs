using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OMSCloud.Contracts.Common.ConfigMgmt;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.Proxy.WebAPI;
using OMSCloud.Contracts.ViewModels;

namespace OMSCloud.Web.MVC.Net.Areas.Admin.Controllers
{

    public class SupplierController : BaseMvcController
    {
        #region Proxies
        private SupplierControllerProxy proxy = new SupplierControllerProxy();
        private StatusControllerProxy statusProxy = new StatusControllerProxy();
        private LanguageControllerProxy languageProxy = new LanguageControllerProxy();
        private CurrencyControllerProxy currencyProxy = new CurrencyControllerProxy();
        private LocationTreeControllerProxy locationProxy = new LocationTreeControllerProxy();
        private LocationLevelControllerProxy locationLevelProxy = new LocationLevelControllerProxy();
        private ProfileControllerProxy profileProxy = new ProfileControllerProxy();
        private AddressTypeControllerProxy addressTypeProxy = new AddressTypeControllerProxy();
        private LocationTreeControllerProxy locationTreeProxy = new LocationTreeControllerProxy();
        private AddressControllerProxy addressProxy = new AddressControllerProxy();
        private SupplierDeliveryOptionPairControllerProxy deliveryProxy = new SupplierDeliveryOptionPairControllerProxy();
        private DeliveryOptionControllerProxy deliveryOptionProxy = new DeliveryOptionControllerProxy();
        
        #endregion Proxies

        // GET: Admin/Supplier
        public ActionResult Index(int PageNum = 1, int PageSize_RowCount = 10, string searchString = "", string sortOrder = "")
         {
            ViewBag.ShopNameSortParm = sortOrder == "ShopName" ? "ShopName_desc" : "ShopName";
            ViewBag.DescriptionSortParm = sortOrder == "Description" ? "Description_desc" : "Description";
            ViewBag.IsRequestedCategoryOrAttributeSortParm = sortOrder == "IsRequestedCategoryOrAttribute" ? "IsRequestedCategoryOrAttribute_desc" : "IsRequestedCategoryOrAttribute";
            ViewBag.StatusSortParm = sortOrder == "Status" ? "Status_desc" : "Status";

            var searchResult = proxy.GetListByPage(new SearchModel {
                PageNum = PageNum,
                PageSize_RowCount = PageSize_RowCount,
                SearchString = searchString,
                SortBy = sortOrder,
                CountryId = 0,
                ProvinceId = ApplicationSession.ProvinceId < 0 ?  (long?)null : ApplicationSession.ProvinceId,
                CityId = ApplicationSession.CityId < 0 ? (long?)null : ApplicationSession.CityId,
            });
            var statusList = statusProxy.GetList();
            ViewBag.PageCount = searchResult.NumberOfPages; 
            ViewBag.CurrentPageIndex = PageNum;
            ViewBag.SearchString = searchString;
            ViewBag.SortOrder = sortOrder;
            IEnumerable<SupplierViewModel> result = null;
            if(searchResult.SupplierList != null)
            {
                result = from s in searchResult.SupplierList
                             join st in statusList on s.StatusID equals st.StatusID
                             where s.StatusID != (int)DBStatusEnum.Deleted
                             select new SupplierViewModel
                             {
                                 SupplierID = s.SupplierID,
                                 SupplierName = s.SupplierName,
                                 StatusID = s.StatusID,
                                 StatusTitle = st.StatusName,
                                 Description = s.Description,
                                 IsRequestedCategoryOrAttribute = s.IsRequestedCategoryOrAttribute
                             };
                return View(result);
            }
            return View();
        }

        // GET: Admin/Supplier/Create
        public ActionResult Create()
        {
            PrepareViewBag();
            return View(new SupplierViewModel() {
                AddressTypeID = (int)DBAddressTypeEnum.BusinessAddress,
                StatusID = (int)DBStatusEnum.Active,
                PaymentGatewayFee = AppSession.PaymentGatewayFee,
                IsPaymentGatewayFeePercentage = AppSession.IsPaymentGatewayFeePercentage,
                ProcessingFee = AppSession.ZvonrProcessingFee,
                IsProcessingFeePercentage = AppSession.IsProcessingFeePercentage,
                OperatingCountryID = AppSession.CountryID,
                OperatingCountryTitle = AppSession.CountryName,
                CurrencyTitle = AppSession.CurrencyName,
                //OperatingCurrencyID = AppSession.CurrencyCode,
                LanguageTitle = AppSession.LanguageName,
                //OperatingLanguageID = AppSession.LanguageCode,
            });
        }

        // POST: Admin/Supplier/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, SupplierViewModel model, FormCollection collection)
        {
            try
            {
                if (file != null)
                {
                    model.Logo = file.FileName;
                }
                long outVal;
                //long.TryParse(collection["OperatingCountryID"], out outVal);
                model.OperatingCountryID = AppSession.CountryID;// outVal;
                long.TryParse(collection["OperatingProvinceID"], out outVal);
                model.OperatingProvinceID = outVal;
                long.TryParse(collection["OperatingCityID"], out outVal);
                model.OperatingCityID = outVal;
                //long.TryParse(collection["OperatingAreaID"], out outVal);
                //model.OperatingAreaID = outVal;

                var addressModel = new AddressModel()
                {
                    ProfileID = model.ProfileID,
                    AddressTypeID = model.AddressTypeID,
                    PlotNumber = model.PlotNumber,
                    StreetNumber = model.StreetNumber,
                    CountryID = model.OperatingCountryID,
                    ProvinceID = model.OperatingProvinceID,
                    CityID = model.OperatingCityID,
                    LocationID = model.OperatingCityID,
                    NearestLandmark = model.NearestLandmark,
                    PostalCode = model.PostalCode,
                    MapLink = model.MapLink,
                };
                var AddressID = addressProxy.Put(addressModel);
                
                var supplierModel = new SupplierModel()
                {
                    SupplierName = model.SupplierName,
                    Logo = model.Logo,
                    Description = model.Description,
                    StatusID = model.StatusID,
                    StatusNotes = model.StatusNotes,
                    BusinessAddressID = (long)AddressID,
                    IsBusinessAddressVisible = model.IsBusinessAddressVisible,
                    OperatingLanguageID = model.OperatingLanguageID,
                    OperatingCurrencyID = model.OperatingCurrencyID,
                    CountryID = model.OperatingCountryID,
                    ProvinceID = model.OperatingProvinceID,
                    CityID = model.OperatingCityID,
                    IsCOD = model.IsCOD,
                    ProfileID = model.ProfileID,
                    ProcessingFee = model.ProcessingFee,
                    PaymentGatewayFee = model.PaymentGatewayFee,
                    IsProcessingFeePercentage = model.IsProcessingFeePercentage,
                    IsPaymentGatewayFeePercentage = model.IsPaymentGatewayFeePercentage,
                    ModifiedOn = model.ModifiedOn
                };
                var Id = proxy.Put(supplierModel);
                if (Id.HasValue)
                {
                    if (file != null)
                    {
                        proxy.PutImageByShopId(Id.Value, file);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.Message = "Unable to save supplier and/or its image";
                PrepareViewBag();
                return View(model);
            }
            catch(Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message;
                PrepareViewBag();
                return View(model);
            }
        }

        // GET: Admin/Supplier/Edit/5
        public ActionResult Edit(long Id)
        {
            var supplierModel = proxy.GetSupplierById(Id);
            if (supplierModel != null)
            {
                PrepareViewBag();
                supplierModel.AnnouncementHTML = HttpUtility.HtmlEncode(supplierModel.AnnouncementHTML);
                supplierModel.PolicyHTML = HttpUtility.HtmlEncode(supplierModel.PolicyHTML);
                supplierModel.FAQHTML = HttpUtility.HtmlEncode(supplierModel.FAQHTML);
                supplierModel.WebLinkJSONObject = new WebLinkJSON();
                try{
                    var WebLinkObject = Newtonsoft.Json.JsonConvert.DeserializeObject<WebLinkJSON>(supplierModel.WebLinksJSON);
                    supplierModel.WebLinkJSONObject = WebLinkObject;
                }catch (Exception ex){}
                var deliveryOptions = deliveryProxy.GetList().Where(a => a.SupplierID == Id);

                supplierModel.LanguageTitle = AppSession.LanguageName;
                supplierModel.CurrencyTitle = AppSession.CurrencyName;
                supplierModel.AddressTypeID = (int)DBAddressTypeEnum.BusinessAddress;

                return View(supplierModel);
            }
            return RedirectToAction("Index");
        }

        // POST: Admin/Supplier/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        public ActionResult Edit(HttpPostedFileBase file, SupplierViewModel model, FormCollection collection)
        {    
            try
            {
                if (file != null)
                {
                    model.Logo = file.FileName;
                }
                // TODO: Add update logic here
                long outVal;
                //long.TryParse(collection["OperatingCountryID"], out outVal);
                model.OperatingCountryID = AppSession.CountryID;// outVal;
                long.TryParse(collection["OperatingProvinceID"], out outVal);
                model.OperatingProvinceID = outVal;
                long.TryParse(collection["OperatingCityID"], out outVal);
                model.OperatingCityID = outVal;
                //long.TryParse(collection["OperatingAreaID"], out outVal);
                //model.OperatingAreaID = outVal;
                model.ModifiedOn = new DateTime(Convert.ToInt64(collection["ModifiedOn.Ticks"]));
                model.AddressModifiedOn = new DateTime(Convert.ToInt64(collection["AddressModifiedOn.Ticks"]));

                //var dbAddress = addressProxy.GetById(model.AddressID);
                var address = new AddressModel()
                {
                    //AddressID = model.AddressID,
                    ProfileID = model.ProfileID,
                    AddressTypeID = model.AddressTypeID,
                    PlotNumber = model.PlotNumber,
                    StreetNumber = model.StreetNumber,
                    CountryID = model.OperatingCountryID,
                    ProvinceID = model.OperatingProvinceID,
                    CityID = model.OperatingCityID,
                    LocationID = model.OperatingCityID,
                    NearestLandmark = model.NearestLandmark,
                    PostalCode = model.PostalCode,
                    MapLink = model.MapLink,
                    ModifiedOn = model.AddressModifiedOn,
                    ShopID = model.SupplierID,
                    //StatusID = 2,
                    IsBusinessAddressVisible = model.IsBusinessAddressVisible,
                };
                if (model.AddressID <= 0)
                {
                    var id = addressProxy.Put(address);
                    if (id.HasValue)
                    {
                        model.AddressID = id.Value;
                        model.BusinessAddressID = id.Value;
                    }
                }
                else
                {
                    address.AddressID = model.AddressID;
                    addressProxy.Post(address);
                }
                var supplierModel = new SupplierModel()
                {
                    SupplierID = model.SupplierID,
                    SupplierName = model.SupplierName,
                    Logo = model.Logo,
                    Description = model.Description,
                    StatusID = model.StatusID,
                    StatusNotes = model.StatusNotes,
                    BusinessAddressID = model.BusinessAddressID,
                    IsBusinessAddressVisible = model.IsBusinessAddressVisible,
                    OperatingLanguageID = /*AppSession.LanguageCode */model.OperatingLanguageID,
                    OperatingCurrencyID = /*AppSession.CurrencyCode*/ model.OperatingCurrencyID,
                    CountryID = model.OperatingCountryID,
                    ProvinceID = model.OperatingProvinceID,
                    CityID = model.OperatingCityID,
                    IsCOD = model.IsCOD,
                    ProfileID = model.ProfileID,
                    ProcessingFee = model.ProcessingFee,
                    PaymentGatewayFee = model.PaymentGatewayFee,
                    IsProcessingFeePercentage = model.IsProcessingFeePercentage,
                    IsPaymentGatewayFeePercentage = model.IsPaymentGatewayFeePercentage,
                    ModifiedOn = model.ModifiedOn,
                    AnnouncementHTML = HttpUtility.HtmlDecode(model.AnnouncementHTML),
                    PolicyHTML = HttpUtility.HtmlDecode(model.PolicyHTML),
                    FAQHTML = HttpUtility.HtmlDecode(model.FAQHTML),
                    AttributeRequests = model.AttributeRequests,
                    CategoryRequests = model.CategoryRequests,
                    WebLinksJSON = model.WebLinksJSON,
                };
                
                if (proxy.Post(supplierModel))
                {
                    if (file != null)
                    {
                        proxy.PutImageByShopId(model.SupplierID, file);
                        ViewBag.Message = "File uploaded successfully";
                    }
                    return RedirectToAction("Index");
                }
                ViewBag.Message = "Unable to save supplier and/or its image";
                PrepareViewBag();
                return View(model);
            }
            catch(Exception ex)
            {
                ViewBag.Message = "ERROR:" + ex.Message;
                PrepareViewBag();
                return View(model);
            }
        }

        private void PrepareViewBag()
        {
            var surroundingCitiesList = new List<LocationLookup>();
            ViewBag.SurroundingCities = new SelectList(surroundingCitiesList, "LocationID", "LocationName");

            var deliveryOptionList = deliveryOptionProxy.GetList();
            ViewBag.DeliveryOption = new SelectList(deliveryOptionList, "DeliveryOptionID", "DeliveryOptionTitle");

            var supplierList = proxy.GetList();
            ViewBag.Supplier = new SelectList(supplierList, "SupplierID", "SupplierName");

            var statusList = statusProxy.GetList();
            ViewBag.status = new SelectList(statusList, "StatusID", "StatusName");
            
            //var languageList = languageProxy.GetList();
            //ViewBag.language = new SelectList(languageList, "Id", "Name");
            
            //var currencyList = currencyProxy.GetList();
            //ViewBag.currency = new SelectList(currencyList,"CurrencyId","Name");

            var locationList = locationProxy.GetList();
            ViewBag.location = locationList;

            var locationLevelList = locationLevelProxy.GetList();
            ViewBag.locationLevel = new SelectList(locationLevelList, "LocationLevelID", "LocationLevelTitle");

            var profileList = profileProxy.GetList().Where(a=>a.UserTypeID >= (int)DBUserTypeEnum.Seller);
            var list = profileList.Select(x => new { ProfileID = x.ProfileID, FullName = x.FirstName + " " + x.LastName } ).ToList();
            ViewBag.profileList = new SelectList(list, "ProfileID", "FullName");

            ViewBag.AddressType = new SelectList(addressTypeProxy.GetList(), "AddressTypeID", "AddressTypeTitle");

            ViewBag.Location = new SelectList(locationTreeProxy.GetList(), "LocationID", "LocationTitle");


        }

        public ActionResult Details(long Id)
        {

            var supplier = proxy.GetSupplierById(Id);

            return View(supplier);
        }

        // GET: Admin/Supplier/Delete/5
        public ActionResult Delete(long Id)
        {

            var supplier = proxy.GetSupplierById(Id);
            
            return View(supplier);
        }

        // POST: Admin/Supplier/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(long Id, FormCollection collection)
        {
            try
            {
                //proxy.Delete(Id);
                SupplierModel model = proxy.GetById(Id);
                model.StatusID = (int)DBStatusEnum.Deleted;
                proxy.Post(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult GetBankingInfo(long Id)
        {
            ViewData["SupplierID"] = Id;
            BankAccountControllerProxy baProxy = new BankAccountControllerProxy();
            var model = baProxy.GetBankAccountByShopId(Id);
            if (model != null)
            {
                if (model.AccountTypeId == 0)
                    model.AccountType = BankAccountTypeEnum.BusinessChequing.ToString();
                else if (model.AccountTypeId == 1)
                    model.AccountType = BankAccountTypeEnum.BusinessSaving.ToString();
                else if (model.AccountTypeId == 2)
                    model.AccountType = BankAccountTypeEnum.PersonalChequing.ToString();
                else if (model.AccountTypeId == 3)
                    model.AccountType = BankAccountTypeEnum.PersonalSaving.ToString();
                else if (model.AccountTypeId == -1)
                    model.AccountType = BankAccountTypeEnum.None.ToString();
            }
            //ViewBag.BankAccountTypeList = Enum.GetValues(typeof(BankAccountType)).Cast<BankAccountType>().
            //    Select(v => new SelectListItem
            //    {
            //        Text = v.ToString(),
            //        Value = ((int)v).ToString()
            //    }
            //).ToList();

            return PartialView("partial/_BankingInfo", model);
        }

        public ActionResult GetBankList()
        {
            BankAccountControllerProxy baProxy = new BankAccountControllerProxy();
            var model = baProxy.GetBankAccountList();
            //ViewBag.BankAccountTypeList = Enum.GetValues(typeof(BankAccountType)).Cast<BankAccountType>().
            //        Select(v => new SelectListItem
            //        {
            //            Text = v.ToString(),
            //            Value = ((int)v).ToString()
            //        }
            //    ).ToList();
            return View(model);
        }

        public ActionResult GetShopReviews(long Id)
        {
            ViewData["SupplierID"] = Id;
            CustomerReviewControllerProxy reviewProxy = new CustomerReviewControllerProxy();
            var model = reviewProxy.GetCustomerReviewList(null, CustomerReviewSubjectEnum.Shop, Id, null);
            return PartialView("partial/_ShopReview", model);
        }

        public ActionResult GetShopTaxInfo(long Id)
        {
            ViewData["SupplierID"] = Id;
            
            var model = proxy.GetShopTaxInfo(Id);
            return PartialView("partial/_ShopTaxInfo", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult ApproveSupplierList(string SupplierCSV)
        {
            if(string.IsNullOrEmpty(SupplierCSV))
                return new JsonResult() { Data = "" };
            var result = proxy.ApproveSupplierList(SupplierCSV);
            return new JsonResult() { Data = result };
        }
    }
}
