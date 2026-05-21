using System;
using System.Collections.Generic;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
namespace OMSCloud.Contracts.Proxy.WebAPI
{
    public partial class ScheduleControllerProxy : BaseControllerProxy//, IScheduleController
    {
        public List<ScheduleModel> GetList()
        {
            string uri = "api/Schedule/GetList";

            var result = WebApiClient.Get<List<ScheduleModel>>(uri);
            return result;
        }

        public List<ScheduleDisplayModel> GetScheduleList()
        {
            string uri = "api/Schedule/GetScheduleList/";

            var result = WebApiClient.Get<List<ScheduleDisplayModel>>(uri);
            return result;
        }
        public ScheduleModel GetById(Int64 Id)
        {
            string uri = "api/Schedule/GetById/" + Id.ToString() + "";

            var result = WebApiClient.Get<ScheduleModel>(uri);
            return result;
        }

        public ScheduleDisplayModel GetScheduleById(long Id)
        {
            string uri = "api/Schedule/GetScheduleById/" + Id.ToString() + "";

            var result = WebApiClient.Get<ScheduleDisplayModel>(uri);
            return result;
        }


        public List<ScheduleDisplayModel> GetScheduleListBySupplierId(long SupplierId)
        {
            string uri = "api/Schedule/GetScheduleListBySupplierId/" + SupplierId.ToString() + "";

            var result = WebApiClient.Get<List<ScheduleDisplayModel>>(uri);
            return result;
        }
        
        public Nullable<Int64> Put(ScheduleModel model)
        {
            string uri = "api/Schedule/Put";

            var result = WebApiClient.Put<Nullable<Int64>>(uri, model);
            return result;

        }
        public Boolean Post(ScheduleModel model)
        {
            string uri = "api/Schedule/Post";

            var result = WebApiClient.Post<Boolean>(uri, model);
            return result;

        }
        public Boolean Delete(ScheduleModel model)
        {
            string uri = "api/Schedule/Delete";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public Boolean Delete(Int64 Id)
        {
            string uri = "api/Schedule/Delete/" + Id.ToString() + "";

            var result = WebApiClient.Delete<Boolean>(uri);
            return result;

        }
        public bool IsShopDeliversAtDate(long ShopId, string SpecificDate)
        {
            string uri = "api/Schedule/IsShopDeliversAtDate?ShopId=" + ShopId+"&SpecificDate="+SpecificDate;            

            var result = WebApiClient.GetForValueType<Boolean>(uri);
            return result;
        }
        public List<DateTime> GetScheduleByDates(long ShopId, string FromDate, string ToDate)
        {
            string uri = "api/Schedule/GetScheduleByDates?ShopId=" + ShopId + "&FromDate=" + FromDate + "&ToDate=" + ToDate;

            var result = WebApiClient.Get<List<DateTime>>(uri);
            return result;
        }
        public List<DateTime> GetNextScheduleBySpecificDate(long ShopId, string SpecificDate, int LimitInDays)
        {
            string uri = "api/Schedule/GetNextScheduleBySpecificDate?ShopId=" + ShopId + "&SpecificDate=" + SpecificDate + "&LimitInDays=" + LimitInDays;

            var result = WebApiClient.Get<List<DateTime>>(uri);
            return result;
        }
    }
}
