using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class SearchModel : BaseModel
    {
        public long CountryId { get; set; } = 0;
        public long? ProvinceId { get; set; } //= null;
        public long? CityId { get; set; } //= null;
        public string SearchString { get; set; }
        public int PageNum { get; set; }
        public int PageSize_RowCount { get; set; }
        public string SortBy { get; set; }
        public bool SortOrder { get; set; }//True=Desc, False = Asc
    }

    public class SearchResultModel : BaseModel
    {
        public int NumberOfPages { get; set; }
        public int GrandRecordsCount { get; set; }
        public int CurrentPageMinIndex { get; set; }
        public int CurrentPageMaxIndex { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }

    public class StatsModel
    {
        #region Shop
        [Display(Name = "New Opened Shops")]
        public long NewOpenedShops { get; set; }
        [Display(Name = "Total Opened Shops ")]
        public long TotalOpenedShops { get; set; }
        [Display(Name = "Inactive Shops ")]
        public long InactiveShops { get; set; }
        [Display(Name = "Active Shops")]
        public long ActiveShops { get; set; }
        #endregion
        #region Users
        [Display(Name = "New Users ")]
        public long NewUsers { get; set; }
        [Display(Name = "Total Users ")]
        public long TotalUsers { get; set; }
        [Display(Name = "Inactive Users ")]
        public long InactiveUsers { get; set; }
        #endregion
        #region Orders
        [Display(Name = "InProcess Orders")]
        public long InProcessOrders { get; set; }
        [Display(Name = "Delivered Orders")]
        public long DeliveredOrders { get; set; }
        [Display(Name = "Completed Orders")]
        public long CompletedOrders { get; set; }
        #endregion
        #region Payment
        [Display(Name = "New Payment Sum")]
        public double NewPaymentSum { get; set; }
        [Display(Name = "All Payment Sum ")]
        public double AllPaymentSum { get; set; }
        #endregion
    }
}
