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
    public partial class SupplierAdapter
    {
        #region Select
        public long GetCountByFilter(ShopStatsModel statsRequestModel)
        {
            var supplier = GetSupplierEnumeration(statsRequestModel);
            //1'new opened shops'
            //2'total opened shops'
            //3'inactive shops'
            //4'active shops'

            if (statsRequestModel.SortBy == "1")
            {
                supplier = supplier.Where(s => s.StatusID == (long)DBStatusEnum.New);
            }
            else if (statsRequestModel.SortBy == "2")
            {
                supplier = supplier.Where(s => s.StatusID == (long)DBStatusEnum.New && s.StatusID == (long)DBStatusEnum.Active);
            }
            else if (statsRequestModel.SortBy == "3")
            {
                supplier = supplier.Where(s => s.StatusID == (long)DBStatusEnum.InActive);
            }
            else if (statsRequestModel.SortBy == "4")
            {
                supplier = supplier.Where(s => s.StatusID == (long)DBStatusEnum.Active);
            }
            if(statsRequestModel.From != null)
                supplier = supplier.Where(x => x.CreatedOn >= statsRequestModel.From.Date);
            if (statsRequestModel.To != null)
                supplier = supplier.Where(x => x.CreatedOn <= statsRequestModel.To.Date);

            return supplier.Count();
        }

        public SupplierSearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder)
        {
            return GetListByPage(new SearchModel
            {
                PageNum = PageNum,
                PageSize_RowCount = PageSize_RowCount,
                SearchString = searchString,
                SortBy = sortOrder
            });
        }
        public SupplierSearchResultAdminModel GetListByPage(SearchModel model)
        {
            var result = new SupplierSearchResultAdminModel();
            var supplier = GetSupplierEnumeration(model);

            #region Sorting Products
            supplier = SortSupplier(model.SortBy, supplier);
            #endregion
            
            #region NewCodePaging
            var total = supplier.Count();
            if (total > 0)
            {
                var pages = (int)Math.Ceiling((double)total / model.PageSize_RowCount);
                pages = pages == 0 ? 1 : pages;
                var skip = model.PageSize_RowCount * (model.PageNum - 1);
                if (skip > total)
                    skip = total;
                var supplierList = supplier.Skip(skip).Take(model.PageSize_RowCount).ToList();
                
                var MaxPrice = 0.0d;
                var MinPrice = 0.0d;
                result = new SupplierSearchResultAdminModel
                {
                    NumberOfPages = pages,
                    GrandRecordsCount = total,
                    CurrentPageMinIndex = skip + 1,
                    CurrentPageMaxIndex = supplierList.Count + skip,
                    MaxPrice = MaxPrice,
                    MinPrice = MinPrice,
                    SupplierList = supplierList,
                };
            }
            return result;
            #endregion
        }

        private IEnumerable<SupplierModel> SortSupplier(string sortOrder, IEnumerable<SupplierModel> shopList)
        {
            switch (sortOrder)
            {
                case "ShopName":
                    shopList = shopList.OrderBy(s => s.SupplierName);
                    break;
                case "ShopName_desc":
                    shopList = shopList.OrderByDescending(s => s.SupplierName);
                    break;
                case "Description":
                    shopList = shopList.OrderBy(x => x.Description);
                    break;
                case "Description_desc":
                    shopList = shopList.OrderByDescending(x => x.Description);
                    break;
                case "IsRequestedCategoryOrAttribute":
                    shopList = shopList.OrderBy(s => s.IsRequestedCategoryOrAttribute);
                    break;
                case "IsRequestedCategoryOrAttribute_desc":
                    shopList = shopList.OrderByDescending(s => s.IsRequestedCategoryOrAttribute);
                    break;
                case "Status":
                    shopList = shopList.OrderBy(s => s.StatusID);
                    break;
                case "Status_desc":
                    shopList = shopList.OrderByDescending(s => s.StatusID);
                    break;
                default:
                    shopList = shopList.OrderBy(s => s.SupplierName);
                    break;
            }
            return shopList;
        }

        public List<SupplierModel> GetSupplierList()
        {
            var supplierList = uow.SupplierRepository.GetAll().Select(a => GetSupplierModel(a)).OrderBy(o => o.SupplierName).ToList();
            return supplierList;
        }
        public List<ShopUserModel> GetSupplierUserIds()
        {
            var supplierList = (from s in uow.OMSContext.Supplier
                                select new ShopUserModel {
                                    UserId = s.Profile.UserID,
                                    ProfileId = s.ProfileID,
                                    Firstname = s.Profile.FirstName,
                                    Lastname = s.Profile.LastName,
                                    ShopId = s.SupplierID,
                                    ShopName = s.SupplierName,
                                    UserCreatedOn = s.Profile.CreatedOn,
                                    //Inactive = false,
                                    //LastModified = DateTime.MinValue,
                                }).ToList();
            return supplierList;
        }

        public SupplierViewModel GetSupplierById(long Id)
        {
            var Supplier = (from supplier in uow.OMSContext.Supplier
                            join status in uow.OMSContext.Status on supplier.StatusID equals status.StatusID
                            join address in uow.OMSContext.Address on supplier.BusinessAddressID equals address.AddressID into leftoutter
                            from subAddress in leftoutter.DefaultIfEmpty()

                            where supplier.SupplierID == Id
                            select new SupplierViewModel
                            {
                                SupplierID = supplier.SupplierID,
                                SupplierName = supplier.SupplierName,
                                Logo = supplier.Logo,
                                Description = supplier.Description,
                                StatusID = supplier.StatusID,
                                StatusNotes = supplier.StatusNotes,
                                BusinessAddressID = supplier.BusinessAddressID,
                                IsBusinessAddressVisible = supplier.IsBusinessAddressVisible,
                                OperatingLanguageID = supplier.LanguageID,
                                OperatingCurrencyID = supplier.CurrencyID,
                                IsCOD = supplier.IsCOD,
                                ProfileID = supplier.ProfileID,
                                ProcessingFee = supplier.ProcessingFee,
                                PaymentGatewayFee = supplier.PaymentGatewayFee,
                                IsProcessingFeePercentage = supplier.IsProcessingFeePercentage,
                                IsPaymentGatewayFeePercentage = supplier.IsPaymentGatewayFeePercentage,
                                StatusTitle = status.StatusName,
                                AddressID = supplier.BusinessAddressID,
                                OperatingCountryID = supplier.CountryID.HasValue ? supplier.CountryID.Value : -1,
                                OperatingProvinceID = supplier.ProvinceID.HasValue ? supplier.ProvinceID.Value : -1,
                                OperatingCityID = supplier.CityID.HasValue ? supplier.CityID.Value : -1,
                                LocationID = subAddress == null ? -1 : subAddress.LocationID,
                                AddressTypeName = subAddress == null ? "" : subAddress.AddressType.AddressTypeTitle,//  addressType.AddressTypeTitle,
                                AddressTypeID = subAddress == null ? -1 : subAddress.AddressTypeID,
                                PlotNumber = subAddress == null ? "" : subAddress.PlotNumber,
                                StreetNumber = subAddress == null ? "" : subAddress.StreetNumber,
                                NearestLandmark = subAddress == null ? "" : subAddress.NearestLandmark,
                                PostalCode = subAddress == null ? "" : subAddress.PostalCode,
                                MapLink = subAddress.MapLink,
                                ModifiedOn = supplier.LastModifiedDateTime,
                                AnnouncementHTML = supplier.AnnouncementHTML,
                                PolicyHTML = supplier.PolicyHTML,
                                FAQHTML = supplier.FAQHTML,
                                WebLinksJSON = supplier.WebLinksJSON,
                                AttributeRequests = supplier.AttributeRequests,
                                CategoryRequests = supplier.CategoryRequests,
                                AddressModifiedOn = subAddress == null ? DateTime.Now : subAddress.LastModifiedDateTime
                            }).ToList();
            if (Supplier != null && Supplier.Count > 0)
                return Supplier.First();
            else
                return null;
        }
        public SupplierViewModel GetSupplierByProfileId(long Id)
        {
            var Supplier = (from supplier in uow.OMSContext.Supplier
                            join status in uow.OMSContext.Status on supplier.StatusID equals status.StatusID
                            //join address in uow.OMSContext.Address on supplier.BusinessAddressID equals address.AddressID

                            where supplier.ProfileID == Id
                            select new SupplierViewModel
                            {
                                SupplierID = supplier.SupplierID,
                                SupplierName = supplier.SupplierName,
                                Logo = supplier.Logo,
                                Description = supplier.Description,
                                StatusID = supplier.StatusID,
                                StatusNotes = supplier.StatusNotes,
                                BusinessAddressID = supplier.BusinessAddressID,
                                IsBusinessAddressVisible = supplier.IsBusinessAddressVisible,
                                OperatingLanguageID = supplier.LanguageID,
                                OperatingCurrencyID = supplier.CurrencyID,
                                IsCOD = supplier.IsCOD,
                                ProfileID = supplier.ProfileID,
                                ProcessingFee = supplier.ProcessingFee,
                                PaymentGatewayFee = supplier.PaymentGatewayFee,
                                IsProcessingFeePercentage = supplier.IsProcessingFeePercentage,
                                IsPaymentGatewayFeePercentage = supplier.IsPaymentGatewayFeePercentage,
                                StatusTitle = status.StatusName,
                                AddressID = supplier.BusinessAddressID,
                                OperatingCountryID = supplier.CountryID.HasValue ? supplier.CountryID.Value : -1,
                                OperatingProvinceID = supplier.ProvinceID.HasValue ? supplier.ProvinceID.Value : -1,
                                OperatingCityID = supplier.CityID.HasValue ? supplier.CityID.Value : -1,
                                //LocationID = address.LocationID,
                                //AddressTypeName = addressType.AddressTypeTitle,
                                //AddressTypeID = address.AddressTypeID,
                                //PlotNumber = address.PlotNumber,
                                //StreetNumber = address.StreetNumber,
                                //NearestLandmark = address.NearestLandmark,
                                //PostalCode = address.PostalCode,
                                //MapLink = address.MapLink,
                                ModifiedOn = supplier.LastModifiedDateTime,
                                //AddressModifiedOn = address.LastModifiedDateTime
                                WebLinksJSON = supplier.WebLinksJSON,
                                AnnouncementHTML = supplier.AnnouncementHTML,
                                PolicyHTML = supplier.PolicyHTML,
                                FAQHTML = supplier.FAQHTML,
                                CategoryRequests = supplier.CategoryRequests,
                                AttributeRequests = supplier.AttributeRequests,
                            }).ToList();
                                
            if (Supplier != null && Supplier.Count > 0)
                return Supplier.First();
            else
                return null;
        }
        //ShopPublicProfileSummaryModel
        public ShopSearchResultModel GetShopPublicList(ShopSearchModel model)
        {
            var filter = (from s in uow.OMSContext.Supplier
                          where (s.StatusID == (int)DBStatusEnum.Active || s.StatusID == (int)DBStatusEnum.InActive)
                          select new {  Supplier = s });
            if (model.CountryId > -1)
            {
                //No need to apply filter on Country as each deployment will have product to its own country only. 
                //filter = filter.Where(f => f.Product.Supplier.CountryID == model.CountryId.Value);
            }
            if (model.ProvinceId.HasValue)
            {
                filter = filter.Where(f => f.Supplier.ProvinceID == model.ProvinceId.Value);
            }
            if (model.CityId.HasValue)
            {
                filter = filter.Where(f => f.Supplier.CityID == model.CityId.Value);
            }
            if (!string.IsNullOrEmpty(model.SearchString))
            {
                filter = filter.Where(s => s.Supplier.SupplierName.Contains(model.SearchString));
            }
            var SupplierList = (from s in filter.Select(x => x.Supplier)//.Supplier
                            join status in uow.OMSContext.Status on s.StatusID equals status.StatusID
                            join city in uow.OMSContext.LocationTree on s.CityID equals city.LocationID into clos
                            from clo in clos.DefaultIfEmpty()
                            join province in uow.OMSContext.LocationTree on s.ProvinceID equals province.LocationID into plos
                            from plo in plos.DefaultIfEmpty()
                            //where s.StatusID == (long)DBStatusEnum.Active
                            orderby s.SupplierName
                            select new ShopPublicProfileSummaryModel
                            {
                                ShopID = s.SupplierID,
                                ShopName = s.SupplierName,
                                ShopOwnerName = s.Profile.FirstName + " " + s.Profile.LastName,
                                ShopOwnerImage = s.Profile.ImagePath,
                                City = clo.LocationTitle,
                                Province = plo.LocationTitle,
                                Logo = s.Logo,
                                WebLinksJSON = s.WebLinksJSON,
                                ShopOwnerProfileId = s.ProfileID,
                                IsBusinessAddressVisible = s.IsBusinessAddressVisible,
                            });
            var total = SupplierList.Count();
            var result = new ShopSearchResultModel
            {
                NumberOfPages = 0,
                GrandRecordsCount = 0,
                CurrentPageMaxIndex = 0,
                CurrentPageMinIndex = 0,
                MaxPrice = 0,
                MinPrice = 0,
            };
            if (total <= 0) return result;
            var pages = (int)Math.Ceiling((double)total / model.PageSize_RowCount);
            pages = pages == 0 ? 1 : pages;
            var skip = model.PageSize_RowCount * (model.PageNum - 1);
            if (skip > total)
                skip = total;
            var supplierList = SupplierList
                .OrderBy(a => a.ShopName)
                .Skip(skip)
                .Take(model.PageSize_RowCount)
                .ToList();
            result = new ShopSearchResultModel {
                NumberOfPages = pages,
                GrandRecordsCount = total,
                CurrentPageMinIndex = skip + 1,
                CurrentPageMaxIndex = supplierList.Count + skip,
                ShopList = supplierList,
            };
            return result;
        }

        public ShopPublicProfileModel GetShopPublicProfile(long supplierId, long profileId = -1)
        {
            var IsReviewInputAllowed = false;
            if (profileId > -1)
            {
                IsReviewInputAllowed = (from o in uow.OMSContext.CartOrder 
                                        where o.BuyerProfileID == profileId
                                        &&
                                        o.OrderStatusID >= (long)DBOrderStatusEnum.OrderPlaced
                                        &&
                                        o.OrderSupplierId == supplierId
                                        select o.CartOrderID).Any();
            }
            var avgRating = (from r in uow.OMSContext.CustomerReview
                             where r.SubjectID == (long)CustomerReviewSubjectEnum.Shop
                             &&
                             r.SubjectRowID == supplierId
                             select (double)r.Rating);//.Average();

            var Supplier = (from supplier in uow.OMSContext.Supplier
                            join status in uow.OMSContext.Status on supplier.StatusID equals status.StatusID
                            join city in uow.OMSContext.LocationTree on supplier.CityID equals city.LocationID into clos
                            from clo in clos.DefaultIfEmpty()
                            join province in uow.OMSContext.LocationTree on supplier.ProvinceID equals province.LocationID into plos
                            from plo in plos.DefaultIfEmpty()

                            where supplier.SupplierID == supplierId
                            && (supplier.StatusID == (int)DBStatusEnum.New || supplier.StatusID == (int)DBStatusEnum.Active || supplier.StatusID == (int)DBStatusEnum.InActive)
                            select new ShopPublicProfileModel
                            {
                                ShopID = supplier.SupplierID,
                                ShopName = supplier.SupplierName,
                                ShopOwnerProfileId = supplier.ProfileID,
                                ShopOwnerName = supplier.Profile.FirstName + " " + supplier.Profile.LastName,
                                ShopOwnerImage = supplier.Profile.ImagePath,
                                City = clo.LocationTitle,
                                Province = plo.LocationTitle,
                                Logo = supplier.Logo,
                                WebLinksJSON = supplier.WebLinksJSON,
                                AnnouncementHTML = supplier.AnnouncementHTML,
                                PolicyHTML = supplier.PolicyHTML,
                                FAQHTML = supplier.FAQHTML,
                                StatusID = supplier.StatusID,
                                ModifiedOn = supplier.LastModifiedDateTime,
                                IsBusinessAddressVisible = supplier.IsBusinessAddressVisible,
                                Description = supplier.Description,
                            }).ToList();

            if (Supplier != null && Supplier.Count > 0)
            {
                var s = Supplier.First();
                s.IsReviewInputAllowed = IsReviewInputAllowed;
                var reviewCount = avgRating.Count();
                if (reviewCount > 0)
                {
                    s.ShopRating = avgRating.Average();
                }
                return s;
            }
            else
            {
                return null;
            }
        }

        public bool GetSupplierByName(string supplierName)
        {
            //var supplier = uow.SupplierRepository.GetById(Id);
            var Supplier = (from s in uow.OMSContext.Supplier
                            where s.SupplierName.ToLower() == supplierName.ToLower()
                            select s).Any();
            return Supplier;
        }

        public List<SupplierModel> GetSupplierByStatus(DBStatusEnum status)
        {
            var result = from supplier in uow.SupplierRepository.OMSContext.Supplier
                         where supplier.StatusID == (int)status
                         select GetSupplierModel(supplier);
            return result.ToList();
        }
        public CategoryAttributeRequestModel GetCategoryAttributeRequestBySupplierId(long Id)
        {
            var result = (from s in uow.OMSContext.Supplier
                          where s.SupplierID == Id
                          select new CategoryAttributeRequestModel {
                              SupplierID = s.SupplierID,
                              AttributeRequests = s.AttributeRequests,
                              CategoryRequests = s.CategoryRequests,
                              ModifiedBy = s.LastModifiedByUserID,
                              ModifiedOn = s.LastModifiedDateTime,
                              CreatedBy = s.CreatedByUserID,
                              CreatedOn = s.CreatedDateTime,
                          });
            return result.FirstOrDefault();
        }

        public ShopTaxInfoModel GetShopTaxInfo(long Id)
        {
            var result = (from s in uow.OMSContext.Supplier
                          where s.SupplierID == Id
                          select new ShopTaxInfoModel {
                              SupplierID = s.SupplierID,
                              TaxConsent = s.TaxConcent,
                              TaxRegistration = s.TaxRegistration,
                              ModifiedOn = s.LastModifiedDateTime,
                              ModifiedBy = s.LastModifiedByUserID,
                              CreatedBy = s.CreatedByUserID,
                              CreatedOn = s.CreatedDateTime,
                          });
            return result.FirstOrDefault();
        }

        private IEnumerable<SupplierModel> GetSupplierEnumeration(SearchModel model)
        {
            var result = (from s in uow.OMSContext.Supplier
                    select new SupplierModel()
                    {
                        SupplierID = s.SupplierID,
                        SupplierName = s.SupplierName,
                        Logo = s.Logo,
                        Description = s.Description,
                        StatusID = s.StatusID,
                        StatusNotes = s.StatusNotes,
                        BusinessAddressID = s.BusinessAddressID,
                        IsBusinessAddressVisible = s.IsBusinessAddressVisible,
                        OperatingLanguageID = s.LanguageID,
                        OperatingCurrencyID = s.CurrencyID,
                        CountryID = s.CountryID.HasValue ? s.CountryID.Value : -1,
                        ProvinceID = s.ProvinceID.HasValue ? s.ProvinceID.Value : -1,
                        CityID = s.CityID.HasValue ? s.CityID.Value : -1,

                        IsCOD = s.IsCOD,
                        IsPaymentGatewayFeePercentage = s.IsPaymentGatewayFeePercentage,
                        IsProcessingFeePercentage = s.IsProcessingFeePercentage,
                        PaymentGatewayFee = s.PaymentGatewayFee,
                        ProcessingFee = s.ProcessingFee,
                        ProfileID = s.ProfileID,

                        AnnouncementHTML = s.AnnouncementHTML,
                        PolicyHTML = s.PolicyHTML,
                        FAQHTML = s.FAQHTML,
                        WebLinksJSON = s.WebLinksJSON,
                        AttributeRequests = s.AttributeRequests,
                        CategoryRequests = s.CategoryRequests,
                        IsRequestedCategoryOrAttribute = !(string.IsNullOrEmpty(s.AttributeRequests.Trim()) && string.IsNullOrEmpty(s.CategoryRequests.Trim()))
                    });
            if (!string.IsNullOrEmpty(model.SearchString))
                result = result.Where(x => x.SupplierName.Contains(model.SearchString));
            if (model.ProvinceId.HasValue && model.ProvinceId.Value > 0)
            {
                result = result.Where(s => s.ProvinceID == model.ProvinceId.Value);
            }
            if (model.CityId.HasValue && model.CityId.Value > 0)
            {
                result = result.Where(s => s.CityID == model.CityId.Value);
            }
            return result;
        }
        #endregion Select

        #region Delete
        public bool DeleteSupplier(SupplierModel supplierModel)
        {
            try
            {
                var supplier = GetSupplierEntity(supplierModel);
                uow.SupplierRepository.Delete(supplier);
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
        private SupplierModel GetSupplierModel(Supplier supplier)
        {
            return new SupplierModel()
            {
                SupplierID = supplier.SupplierID,
                SupplierName = supplier.SupplierName,
                Logo = supplier.Logo,
                Description = supplier.Description,
                StatusID = supplier.StatusID,
                StatusNotes = supplier.StatusNotes,
                BusinessAddressID = supplier.BusinessAddressID,
                IsBusinessAddressVisible = supplier.IsBusinessAddressVisible,
                OperatingLanguageID = supplier.LanguageID,
                OperatingCurrencyID = supplier.CurrencyID,
                CountryID = supplier.CountryID.HasValue ? supplier.CountryID.Value : -1,
                ProvinceID = supplier.ProvinceID.HasValue ? supplier.ProvinceID.Value : -1,
                CityID = supplier.CityID.HasValue ? supplier.CityID.Value : -1,

                IsCOD = supplier.IsCOD,
                IsPaymentGatewayFeePercentage = supplier.IsPaymentGatewayFeePercentage,
                IsProcessingFeePercentage = supplier.IsProcessingFeePercentage,
                PaymentGatewayFee = supplier.PaymentGatewayFee,
                ProcessingFee = supplier.ProcessingFee,
                ProfileID = supplier.ProfileID,

                AnnouncementHTML = supplier.AnnouncementHTML,
                PolicyHTML = supplier.PolicyHTML,
                FAQHTML = supplier.FAQHTML,
                WebLinksJSON = supplier.WebLinksJSON,
                AttributeRequests = supplier.AttributeRequests,
                CategoryRequests = supplier.CategoryRequests,

            };
        }
        private Supplier GetSupplierEntity(SupplierModel supplierModel)
        {
            return new Supplier()
            {
                SupplierID = supplierModel.SupplierID,
                SupplierName = supplierModel.SupplierName,
                Logo = supplierModel.Logo,
                Description = supplierModel.Description,
                StatusID = supplierModel.StatusID,
                StatusNotes = supplierModel.StatusNotes,
                BusinessAddressID = supplierModel.BusinessAddressID,
                IsBusinessAddressVisible = supplierModel.IsBusinessAddressVisible,
                LanguageID = supplierModel.OperatingLanguageID,
                CurrencyID = supplierModel.OperatingCurrencyID,
                CountryID = supplierModel.CountryID,
                ProvinceID = supplierModel.ProvinceID,
                CityID = supplierModel.CityID,
                IsCOD = supplierModel.IsCOD,
                IsPaymentGatewayFeePercentage= supplierModel.IsPaymentGatewayFeePercentage,
                IsProcessingFeePercentage = supplierModel.IsProcessingFeePercentage,
                PaymentGatewayFee = supplierModel.PaymentGatewayFee,
                ProcessingFee = supplierModel.ProcessingFee,
                ProfileID = supplierModel.ProfileID,
                AnnouncementHTML = supplierModel.AnnouncementHTML,
                PolicyHTML = supplierModel.PolicyHTML,
                FAQHTML = supplierModel.FAQHTML,
                WebLinksJSON = supplierModel.WebLinksJSON,
                AttributeRequests = supplierModel.AttributeRequests,
                CategoryRequests = supplierModel.CategoryRequests,

            };
        }
        #endregion Private
    }
}