using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Core
{
    public partial class CartBusinessComponent
    {
        public CartModel GetCurrentUserCart(long ProfileId)
        {
            return adapter.GetCurrentUserCart(ProfileId);
        }
        public CartDetailModel GetCartDetails(long ProfileId)
        {
            var cart = adapter.GetCartDetails(ProfileId);
            if(cart != null && cart.CartItemList != null && cart.CartItemList.Count > 0)
                UpdateExpectedDeliveryInfo(cart.CartItemList);
            return cart;
        }
        public List<CartExtendedModel> GetCartList()
        {
            return adapter.GetCartList();
        }
        public CartExtendedModel GetCartById(long Id)
        {
            return adapter.GetCartById(Id);
        }
        public bool UpdateCartDetail(CartDetailModel model)
        {
            var cart = model as CartModel;
            cart.DiscountTotal = 0.0;
            cart.TaxTotal = 0.0;
            cart.CartTotal = 0.0;
            cart.CartTotal = 0.0;

            CartItemBusinessComponent itemComp = new CartItemBusinessComponent();
            foreach (var item in model.CartItemList)
            {
                itemComp.UpdateCartItem(item);
                if (item.StatusID != (int)DBStatusEnum.Deleted)
                {
                    cart.DiscountTotal += item.DiscountAmount;
                    cart.TaxTotal += item.TaxAmount;
                    cart.CartTotal += item.ItemTotalPrice;
                }
            }
            
            return adapter.UpdateCart(cart);
        }

        /// <summary>
        /// The 'UpdateExpectedDeliveryInfo' method updates the expected delivery information for a given 'ProductDetailModel based on the shop's status and the specified response time unit.
        /// </summary>
        /// <param name="cartItemWithAttributesModels"></param>
        public static void UpdateExpectedDeliveryInfo(List<CartItemWithAttributesModel> cartItemWithAttributesModels)
        {
            if (cartItemWithAttributesModels == null || cartItemWithAttributesModels?.Count <= 0)
                return;
            foreach (var i in cartItemWithAttributesModels)
            {
                if (i.ShopStatusId == (int)DBStatusEnum.Active)
                {
                    var schedule = new ScheduleBusinessComponent();
                    var listOfSchedule = schedule.GetNextScheduleBySpecificDate(i.ShopId, DateTime.Now.ToString("dd/MM/yyyy"), 90);
                    double diffInDays = 0;
                    if (listOfSchedule.Count > 0)
                    {
                        DateTime nextAvailabledate;
                        if (DateTime.TryParseExact(listOfSchedule.First(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nextAvailabledate))
                        {
                            diffInDays = (nextAvailabledate.Date - DateTime.Now.Date).TotalDays;
                        }
                    }

                    double maxRange = i.ExpectedDeliveryTime;
                    var unit = (DBResponseTimeUnitEnum)Convert.ToInt32(i.ExpectedDeliveryUnit);
                    if (unit == DBResponseTimeUnitEnum.Day)
                    {
                        maxRange += diffInDays;
                        //var minRange = Math.Floor(maxRange - (maxRange * 0.2));
                        if (maxRange > 0)
                            i.ExpectedDeliveryInfo = "Expected Delivery/Ready within " + Math.Floor(maxRange) + (maxRange > 1 ? " days" : " day");
                        else
                            i.ExpectedDeliveryInfo = "Expected Delivery/Ready within today";
                    }
                    else if (unit == DBResponseTimeUnitEnum.Hour)
                    {
                        TimeSpan maxTimeSpan = ((DateTime.Now.Date.AddDays(diffInDays).AddHours(i.ExpectedDeliveryTime)) - DateTime.Now.Date);
                        //var minRange = Math.Floor(maxRange - (maxRange * 0.2));
                        //TimeSpan minTimeSpan = new TimeSpan(DateTime.Now.AddDays(diffInDays).AddHours(minRange).Ticks);
                        i.ExpectedDeliveryInfo = "Expected Delivery/Ready within ";
                        if (maxTimeSpan.Days > 0)
                            i.ExpectedDeliveryInfo += maxTimeSpan.Days + (maxTimeSpan.Days > 1 ? " days" : " day");
                        if (maxTimeSpan.Hours > 0)
                            i.ExpectedDeliveryInfo += maxTimeSpan.Hours + (maxTimeSpan.Hours > 1 ? " hours" : " hour");
                    }
                    else if (unit == DBResponseTimeUnitEnum.Minute)
                    {
                        TimeSpan maxTimeSpan = ((DateTime.Now.Date.AddDays(diffInDays).AddMinutes(i.ExpectedDeliveryTime)) - DateTime.Now.Date);
                        //var minRange = Math.Floor(maxRange - (maxRange * 0.2));
                        //TimeSpan minTimeSpan = new TimeSpan(DateTime.Now.AddDays(diffInDays).AddHours(minRange).Ticks);
                        i.ExpectedDeliveryInfo = "Expected Delivery/Ready within ";
                        if (maxTimeSpan.Days > 0)
                            i.ExpectedDeliveryInfo += maxTimeSpan.Days + (maxTimeSpan.Days > 1 ? " days" : " day");
                        if (maxTimeSpan.Hours > 0)
                            i.ExpectedDeliveryInfo += maxTimeSpan.Hours + (maxTimeSpan.Hours > 1 ? " hours" : " hour");
                        if (maxTimeSpan.Minutes > 0)
                            i.ExpectedDeliveryInfo += maxTimeSpan.Minutes + (maxTimeSpan.Minutes > 1 ? " mins" : " min");
                    }
                }
                else
                {
                    //either shop is NEW, InActive or deleted -- consider as unavailable
                    i.ExpectedDeliveryInfo = "Shop is unavailable";
                }
            }
        }

        /// <summary>
        /// The 'UpdateExpectedDeliveryInfo' method updates the expected delivery information for a given 'ProductDetailModel based on the shop's status and the specified response time unit.
        /// </summary>
        /// <param name="p: product"></param>
        public static void UpdateExpectedDeliveryInfo(ProductDetailModel p)
        {
            if (p.ShopStatusId == (int)DBStatusEnum.Active)
            {
                var schedule = new ScheduleBusinessComponent();
                var listOfSchedule = schedule.GetNextScheduleBySpecificDate(p.SupplierID, DateTime.Now.ToString("dd/MM/yyyy"), 90);
                double diffInDays = 0;
                if (listOfSchedule.Count > 0)
                {
                    DateTime nextAvailabledate;
                    if (DateTime.TryParseExact(listOfSchedule.First(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out nextAvailabledate))
                    {
                        diffInDays = (nextAvailabledate.Date - DateTime.Now.Date).TotalDays;
                    }
                }

                double maxRange = p.OrderResponseTime;
                var unit = (DBResponseTimeUnitEnum)Convert.ToInt32(p.OrderResponseTimeUnitID);
                if (unit == DBResponseTimeUnitEnum.Day)
                {
                    maxRange += diffInDays;
                    //var minRange = Math.Floor(maxRange - (maxRange * 0.2));
                    if (maxRange > 0)
                        p.ExpectedDeliveryInfo = "Expected Delivery/Ready within " + Math.Floor(maxRange) + (maxRange > 1 ? " days" : " day");
                    else
                        p.ExpectedDeliveryInfo = "Expected Delivery/Ready within today";
                }
                else if (unit == DBResponseTimeUnitEnum.Hour)
                {
                    TimeSpan maxTimeSpan = ((DateTime.Now.Date.AddDays(diffInDays).AddHours(p.OrderResponseTime)) - DateTime.Now.Date);
                    //var minRange = Math.Floor(maxRange - (maxRange * 0.2));
                    //TimeSpan minTimeSpan = new TimeSpan(DateTime.Now.AddDays(diffInDays).AddHours(minRange).Ticks);
                    p.ExpectedDeliveryInfo = "Expected Delivery/Ready within ";
                    if (maxTimeSpan.Days > 0)
                        p.ExpectedDeliveryInfo += maxTimeSpan.Days + (maxTimeSpan.Days > 1 ? " days" : " day");
                    if (maxTimeSpan.Hours > 0)
                        p.ExpectedDeliveryInfo += maxTimeSpan.Hours + (maxTimeSpan.Hours > 1 ? " hours" : " hour");                    
                }
                else if (unit == DBResponseTimeUnitEnum.Minute)
                {
                    TimeSpan maxTimeSpan = ((DateTime.Now.Date.AddDays(diffInDays).AddMinutes(p.OrderResponseTime)) - DateTime.Now.Date);
                    //var minRange = Math.Floor(maxRange - (maxRange * 0.2));
                    //TimeSpan minTimeSpan = new TimeSpan(DateTime.Now.AddDays(diffInDays).AddHours(minRange).Ticks);
                    p.ExpectedDeliveryInfo = "Expected Delivery/Ready within ";
                    if (maxTimeSpan.Days > 0)
                        p.ExpectedDeliveryInfo += maxTimeSpan.Days + (maxTimeSpan.Days > 1 ? " days" : " day");
                    if (maxTimeSpan.Hours > 0)
                        p.ExpectedDeliveryInfo += maxTimeSpan.Hours +  (maxTimeSpan.Hours > 1 ? " hours" : " hour");
                    if (maxTimeSpan.Minutes > 0)
                        p.ExpectedDeliveryInfo += maxTimeSpan.Minutes +  (maxTimeSpan.Minutes > 1 ? " mins" : " min");                    
                }
            }
            else
            {
                //either shop is NEW, InActive or deleted -- consider as unavailable
                p.ExpectedDeliveryInfo = "Shop is unavailable";
            }
        }
    }
}
