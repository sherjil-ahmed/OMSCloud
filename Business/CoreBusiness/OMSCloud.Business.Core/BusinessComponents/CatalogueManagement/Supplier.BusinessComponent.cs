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
    public partial class SupplierBusinessComponent
    {
        public long GetCountByFilter(ShopStatsModel statsRequestModel)
        {
            return adapter.GetCountByFilter(statsRequestModel);
        }
        public SupplierSearchResultAdminModel GetListByPage(SearchModel model)
        {
            return adapter.GetListByPage(model);
        }
        public SupplierSearchResultAdminModel GetListByPage(int PageNum, int PageSize_RowCount, string searchString, string sortOrder)
        {
            return adapter.GetListByPage(
            new SearchModel
            {
                PageNum = PageNum,
                PageSize_RowCount = PageSize_RowCount,
                SearchString = searchString,
                SortBy = sortOrder
            });
        }
        public List<ShopUserModel> GetSupplierUserIds()
        {
            return adapter.GetSupplierUserIds();
        }
        public List<SupplierModel> GetSupplierList()
        {
            return adapter.GetSupplierList();
        }
        public SupplierViewModel GetSupplierById(long Id)
        {
            return adapter.GetSupplierById(Id);
        }
        public SupplierViewModel GetSupplierByProfileId(long Id)
        {
            return adapter.GetSupplierByProfileId(Id);
        }
        public ShopSearchResultModel GetShopPublicList(ShopSearchModel shopSearchModal)
        {
            return adapter.GetShopPublicList(shopSearchModal);
        }
        public ShopPublicProfileModel GetShopPublicProfile(long supplierId, long profileId = -1)
        {
            return adapter.GetShopPublicProfile(supplierId, profileId);
        }
        public bool GetSupplierByName(string supplierName)
        {
            return adapter.GetSupplierByName(supplierName);
        }
        public CategoryAttributeRequestModel GetCategoryAttributeRequestBySupplierId(long Id)
        {
            return adapter.GetCategoryAttributeRequestBySupplierId(Id);
        }
        public ShopTaxInfoModel GetShopTaxInfo(long Id)
        {
            return adapter.GetShopTaxInfo(Id);
        }
    }
}
