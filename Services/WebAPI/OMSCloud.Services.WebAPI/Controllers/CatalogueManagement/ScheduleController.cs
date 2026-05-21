using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    public partial class ScheduleController : ApiController, IScheduleController
    {
        [ReturnType(DataType = typeof(ScheduleDisplayModel))]
        public IHttpActionResult GetScheduleById(long Id)
        {
            var model = comp.GetScheduleById(Id);

            return Ok<ScheduleDisplayModel>(model);
        }

        [ReturnType(DataType = typeof(List<ScheduleDisplayModel>))]
        public List<ScheduleDisplayModel> GetScheduleList()
        {
            return comp.GetScheduleList();
        }

        [ReturnType(DataType = typeof(List<ScheduleDisplayModel>))]
        public List<ScheduleDisplayModel> GetScheduleListBySupplierId(long Id)
        {
            return comp.GetScheduleListBySupplierId(Id);
        }
        
        [ReturnType(DataType = typeof(Boolean))]
        [HttpGet]
        public IHttpActionResult IsShopDeliversAtDate(long SupplierId, string SpecificDate)
		{			
			Boolean isScheduled = false;
            isScheduled = comp.IsShopDeliversAtDate(SupplierId, SpecificDate);
            return Ok<Boolean>(isScheduled);            
		}
        
        [ReturnType(DataType = typeof(List<string>))]
        public IHttpActionResult GetScheduleByDates(long SupplierId, string FromDate, string ToDate)
        {            
            List<string> listOfDates = new List<string>();
            listOfDates = comp.GetScheduleByDates(SupplierId, FromDate, ToDate);
            return Ok<List<string>>(listOfDates);            
        }

        [ReturnType(DataType = typeof(List<string>))]
        public IHttpActionResult GetNextScheduleBySpecificDate(long SupplierId, string SpecificDate, int LimitInDays)
        {
            List<string> listOfDates = new List<string>();
            listOfDates = comp.GetNextScheduleBySpecificDate(SupplierId, SpecificDate, LimitInDays);
            return Ok<List<string>>(listOfDates);
        }

        
    }
}