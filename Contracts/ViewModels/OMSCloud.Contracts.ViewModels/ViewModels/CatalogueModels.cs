using OMSCloud.Contracts.Common.DBEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ShopSearchModel : SearchModel
    {
        //public SortShopByEnum SortBy { get; set; }
    }
    public class ProductSearchModel : SearchModel
    {
        public long? CategoryId { get; set; }
        public long? ShopId { get; set; }
        public new SortByEnum SortBy { get; set; }
        public long? ProductTypeId { get; set; }
        public long? MinPrice { get; set; }
        public long? MaxPrice { get; set; }
        public Dictionary<long, List<string>> AttributeList { get; set; }
    }

    public class ShopSearchResultModel : SearchResultModel
    {
        public List<ShopPublicProfileSummaryModel> ShopList { get; set; }
    }

    public class ProductSearchResultModel : SearchResultModel
    {
        public List<AllInheritedAttributesByCategoryModel> AttributeList { get; set; }
        public List<AllParentsByChildCategoryModel> ParentCategoryList { get; set; }
        public List<ProductBoxModel> ProductList { get; set; }
    }
    public class ShopStatsModel : SearchModel {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
    public class ProductBoxModel : BaseModel
    {
        public long ProductID { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public double BasePrice { get; set; }
        public double SellingPrice { get; set; }
        public double DiscountAmount { get; set; }
        public double Discount { get; set; }
        public bool IsDiscountPercentage { get; set; }
        public long Rating { get; set; }
        public string ShopName { get; set; }
        public long ShopId { get; set; }
        public string BriefDescription { get; set; }
        public CategoryLookupModel Category { get; set; }
    }

    public class ProductAdminModel : ProductBoxModel
    {
        public int? AnalysisRank { get; set; } = 0;
        public long ProductTypeID { get; set; }
        public string ProductTypeName { get; set; }
        public long StatusID { get; set; }
        public string StatusName { get; set; }
    }

    public class ProductSearchResultAdminModel : SearchResultModel
    {
        public List<ProductAdminModel> ProductList { get; set; }
    }
}
