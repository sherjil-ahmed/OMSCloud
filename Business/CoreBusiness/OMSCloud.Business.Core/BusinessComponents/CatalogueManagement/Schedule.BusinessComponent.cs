using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Business.Adapters;
using OMSCloud.Contracts.Common.DBEnums;
using System.Globalization;

namespace OMSCloud.Business.Core
{
    public partial class ScheduleBusinessComponent
    {
        public List<ScheduleDisplayModel> GetScheduleList()
        {
            return adapter.GetScheduleList();
        }
        public ScheduleDisplayModel GetScheduleById(long Id)
        {
            return adapter.GetScheduleById(Id);
        }

        public List<ScheduleDisplayModel> GetScheduleListBySupplierId(long SupplierId)
        {

            return adapter.GetScheduleListBySupplierId(SupplierId);
        }

        public bool IsShopDeliversAtDate(long SupplierId, string SpecificDate)
        {
            var model = adapter.GetScheduleListBySupplierId(SupplierId);
            DateTime sdate;
            Boolean isScheduled = false;
            if (DateTime.TryParseExact(SpecificDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out sdate))
            {
                if (model == null || model.Count == 0)
                {
                    isScheduled = true;
                }
                else
                {
                    foreach (ScheduleDisplayModel sdm in model.Where(x => x.IsException == false))
                    {
                        #region Weekly
                        if (sdm.ScheduleTypeID == 1) //Weekly
                        {
                            if (sdate.DayOfWeek == DayOfWeek.Monday && sdm.Monday)
                            {
                                isScheduled = true;
                                break;
                            }
                            if (sdate.DayOfWeek == DayOfWeek.Tuesday && sdm.Tuesday)
                            {
                                isScheduled = true;
                                break;
                            }
                            if (sdate.DayOfWeek == DayOfWeek.Wednesday && sdm.Wednesday)
                            {
                                isScheduled = true;
                                break;
                            }
                            if (sdate.DayOfWeek == DayOfWeek.Thursday && sdm.Thursday)
                            {
                                isScheduled = true;
                                break;
                            }
                            if (sdate.DayOfWeek == DayOfWeek.Friday && sdm.Friday)
                            {
                                isScheduled = true;
                                break;
                            }
                            if (sdate.DayOfWeek == DayOfWeek.Saturday && sdm.Saturday)
                            {
                                isScheduled = true;
                                break;
                            }
                            if (sdate.DayOfWeek == DayOfWeek.Sunday && sdm.Sunday)
                            {
                                isScheduled = true;
                                break;
                            }
                        }
                        #endregion
                        #region Monthly
                        else if (sdm.ScheduleTypeID == 2 &&
                            sdm.FromDay.HasValue &&
                            sdm.ToDay.HasValue &&
                            sdm.FromDay.Value > 0 &&
                            sdm.FromDay.Value <= 31 &&
                            sdm.ToDay.Value > 0 &&
                            sdm.ToDay.Value <= 31 &&
                            (sdm.FromDay.Value <= sdm.ToDay.Value))
                        {
                            for (int day = sdm.FromDay.Value; day <= sdm.ToDay.Value; day++)
                            {
                                if (day == sdate.Day)
                                {
                                    isScheduled = true;
                                    break;
                                }
                            }
                        }
                        #endregion
                        #region Yearly
                        else if (sdm.ScheduleTypeID == 3 &&
                            sdm.Month.HasValue &&
                            sdm.Month.Value > 0 &&
                            sdm.Month.Value <= 12 &&
                            sdm.MonthDay.HasValue &&
                            sdm.MonthDay.Value > 0 &&
                            sdm.MonthDay.Value <= 31)
                        {
                            if (sdm.Month.Value == sdate.Date.Month && sdm.MonthDay.Value == sdate.Date.Day)
                            {
                                isScheduled = true;
                                break;
                            }
                        }
                        #endregion

                    }

                    if (isScheduled == true)
                    {
                        foreach (ScheduleDisplayModel sdmException in model.Where(x => x.IsException == true))
                        {
                            #region Weekly
                            if (sdmException.ScheduleTypeID == 1) //Weekly
                            {
                                if (sdate.DayOfWeek == DayOfWeek.Monday && sdmException.Monday)
                                {
                                    isScheduled = false;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Tuesday && sdmException.Tuesday)
                                {
                                    isScheduled = false;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Wednesday && sdmException.Wednesday)
                                {
                                    isScheduled = false;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Thursday && sdmException.Thursday)
                                {
                                    isScheduled = false;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Friday && sdmException.Friday)
                                {
                                    isScheduled = false;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Saturday && sdmException.Saturday)
                                {
                                    isScheduled = false;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Sunday && sdmException.Sunday)
                                {
                                    isScheduled = false;
                                    break;
                                }
                            }
                            #endregion
                            #region Monthly
                            else if (sdmException.ScheduleTypeID == 2 &&
                                sdmException.FromDay.HasValue &&
                                sdmException.ToDay.HasValue &&
                                sdmException.FromDay.Value > 0 &&
                                sdmException.FromDay.Value <= 31 &&
                                sdmException.ToDay.Value > 0 &&
                                sdmException.ToDay.Value <= 31 &&
                                (sdmException.FromDay.Value <= sdmException.ToDay.Value))
                            {
                                for (int day = sdmException.FromDay.Value; day <= sdmException.ToDay.Value; day++)
                                {
                                    if (day == sdate.Day)
                                    {
                                        isScheduled = false;
                                        break;
                                    }
                                }
                            }
                            #endregion
                            #region Yearly
                            else if (sdmException.ScheduleTypeID == 3 &&
                            sdmException.Month.HasValue &&
                            sdmException.Month.Value > 0 &&
                            sdmException.Month.Value <= 12 &&
                            sdmException.MonthDay.HasValue &&
                            sdmException.MonthDay.Value > 0 &&
                            sdmException.MonthDay.Value <= 31)
                            {
                                if (sdmException.Month.Value == sdate.Date.Month && sdmException.MonthDay.Value == sdate.Date.Day)
                                {
                                    isScheduled = false;
                                    break;
                                }
                            }
                            #endregion
                        }
                    }
                }

                return isScheduled;
            }
            else
            {
                return isScheduled;
            }
        }

        public List<string> GetScheduleByDates(long SupplierId, string FromDate, string ToDate)
        {
            var model = adapter.GetScheduleListBySupplierId(SupplierId);
            DateTime fDate;
            DateTime tDate;
            List<string> listOfDates = new List<string>();
            if (DateTime.TryParseExact(FromDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fDate) && DateTime.TryParseExact(ToDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out tDate))
            {
                if (model == null || model.Count == 0)
                {
                    foreach (DateTime day in EachDay(fDate.Date, tDate.Date))
                    {
                        string dayString = day.ToString("dd/MM/yyyy");
                        if (!listOfDates.Contains(dayString))
                            listOfDates.Add(dayString);
                    }
                }
                else
                {
                    foreach (ScheduleDisplayModel sdm in model.Where(x => x.IsException == false))
                    {
                        foreach (DateTime day in EachDay(fDate.Date, tDate.Date))
                        {
                            string dayString = day.ToString("dd/MM/yyyy");

                            #region Weekly
                            if (sdm.ScheduleTypeID == 1) //Weekly
                            {
                                if (day.DayOfWeek == DayOfWeek.Monday && sdm.Monday)
                                {
                                    if (!listOfDates.Contains(dayString))
                                        listOfDates.Add(dayString);
                                }
                                if (day.DayOfWeek == DayOfWeek.Tuesday && sdm.Tuesday)
                                {
                                    if (!listOfDates.Contains(dayString))
                                        listOfDates.Add(dayString);
                                }
                                if (day.DayOfWeek == DayOfWeek.Wednesday && sdm.Wednesday)
                                {
                                    if (!listOfDates.Contains(dayString))
                                        listOfDates.Add(dayString);
                                }
                                if (day.DayOfWeek == DayOfWeek.Thursday && sdm.Thursday)
                                {
                                    if (!listOfDates.Contains(dayString))
                                        listOfDates.Add(dayString);
                                }
                                if (day.DayOfWeek == DayOfWeek.Friday && sdm.Friday)
                                {
                                    if (!listOfDates.Contains(dayString))
                                        listOfDates.Add(dayString);
                                }
                                if (day.DayOfWeek == DayOfWeek.Saturday && sdm.Saturday)
                                {
                                    if (!listOfDates.Contains(dayString))
                                        listOfDates.Add(dayString);
                                }
                                if (day.DayOfWeek == DayOfWeek.Sunday && sdm.Sunday)
                                {
                                    if (!listOfDates.Contains(dayString))
                                        listOfDates.Add(dayString);
                                }
                            }
                            #endregion
                            #region Monthly
                            else if (sdm.ScheduleTypeID == 2 &&
                                sdm.FromDay.HasValue &&
                                sdm.ToDay.HasValue &&
                                sdm.FromDay.Value > 0 &&
                                sdm.FromDay.Value <= 31 &&
                                sdm.ToDay.Value > 0 &&
                                sdm.ToDay.Value <= 31 &&
                                (sdm.FromDay.Value <= sdm.ToDay.Value))
                            {
                                for (int sdmday = sdm.FromDay.Value; sdmday <= sdm.ToDay.Value; sdmday++)
                                {
                                    if (sdmday == day.Day)
                                    {
                                        if (!listOfDates.Contains(dayString))
                                            listOfDates.Add(dayString);
                                    }
                                }
                            }
                            #endregion
                            #region Yearly
                            else if (sdm.ScheduleTypeID == 3 &&
                                sdm.Month.HasValue &&
                                sdm.Month.Value > 0 &&
                                sdm.Month.Value <= 12 &&
                                sdm.MonthDay.HasValue &&
                                sdm.MonthDay.Value > 0 &&
                                sdm.MonthDay.Value <= 31)
                            {
                                if (sdm.Month.Value == day.Date.Month && sdm.MonthDay.Value == day.Date.Day)
                                {
                                    if (!listOfDates.Contains(dayString))
                                        listOfDates.Add(dayString);
                                }
                            }
                            #endregion
                        }

                    }

                    if (listOfDates.Count > 0)
                    {
                        foreach (ScheduleDisplayModel sdmException in model.Where(x => x.IsException == true))
                        {
                            foreach (DateTime day in EachDay(fDate.Date, tDate.Date))
                            {
                                string dayString = day.ToString("dd/MM/yyyy");

                                #region Weekly
                                if (sdmException.ScheduleTypeID == 1) //Weekly
                                {
                                    if (day.DayOfWeek == DayOfWeek.Monday && sdmException.Monday)
                                    {
                                        if (listOfDates.Contains(dayString))
                                            listOfDates.Remove(dayString);
                                    }
                                    if (day.DayOfWeek == DayOfWeek.Tuesday && sdmException.Tuesday)
                                    {
                                        if (listOfDates.Contains(dayString))
                                            listOfDates.Remove(dayString);
                                    }
                                    if (day.DayOfWeek == DayOfWeek.Wednesday && sdmException.Wednesday)
                                    {
                                        if (listOfDates.Contains(dayString))
                                            listOfDates.Remove(dayString);
                                    }
                                    if (day.DayOfWeek == DayOfWeek.Thursday && sdmException.Thursday)
                                    {
                                        if (listOfDates.Contains(dayString))
                                            listOfDates.Remove(dayString);
                                    }
                                    if (day.DayOfWeek == DayOfWeek.Friday && sdmException.Friday)
                                    {
                                        if (listOfDates.Contains(dayString))
                                            listOfDates.Remove(dayString);
                                    }
                                    if (day.DayOfWeek == DayOfWeek.Saturday && sdmException.Saturday)
                                    {
                                        if (listOfDates.Contains(dayString))
                                            listOfDates.Remove(dayString);
                                    }
                                    if (day.DayOfWeek == DayOfWeek.Sunday && sdmException.Sunday)
                                    {
                                        if (listOfDates.Contains(dayString))
                                            listOfDates.Remove(dayString);
                                    }
                                }
                                #endregion
                                #region Monthly
                                else if (sdmException.ScheduleTypeID == 2 &&
                                    sdmException.FromDay.HasValue &&
                                    sdmException.ToDay.HasValue &&
                                    sdmException.FromDay.Value > 0 &&
                                    sdmException.FromDay.Value <= 31 &&
                                    sdmException.ToDay.Value > 0 &&
                                    sdmException.ToDay.Value <= 31 &&
                                    (sdmException.FromDay.Value <= sdmException.ToDay.Value))
                                {
                                    for (int sdmday = sdmException.FromDay.Value; sdmday <= sdmException.ToDay.Value; sdmday++)
                                    {
                                        if (sdmday == day.Day)
                                        {
                                            if (listOfDates.Contains(dayString))
                                                listOfDates.Remove(dayString);
                                        }
                                    }
                                }
                                #endregion
                                #region Yearly
                                else if (sdmException.ScheduleTypeID == 3 &&
                                    sdmException.Month.HasValue &&
                                    sdmException.Month.Value > 0 &&
                                    sdmException.Month.Value <= 12 &&
                                    sdmException.MonthDay.HasValue &&
                                    sdmException.MonthDay.Value > 0 &&
                                    sdmException.MonthDay.Value <= 31)
                                {
                                    if (sdmException.Month.Value == day.Date.Month && sdmException.MonthDay.Value == day.Date.Day)
                                    {
                                        if (listOfDates.Contains(dayString))
                                            listOfDates.Remove(dayString);
                                    }
                                }
                                #endregion
                            }
                        }
                    }
                }

                return listOfDates.OrderBy(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)).ToList();
            }
            else
            {
                return listOfDates.OrderBy(x => DateTime.ParseExact(x, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None)).ToList();
            }
        }

        public List<string> GetNextScheduleBySpecificDate(long SupplierId, string SpecificDate, int LimitInDays)
        {
            var model = adapter.GetScheduleListBySupplierId(SupplierId);
            DateTime sdate;
            bool isScheduled = false;
            List<DateTime> listOfDates = new List<DateTime>();
            if (DateTime.TryParseExact(SpecificDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out sdate))
            {
                int counter = 1;

                while (counter <= LimitInDays)
                {
                    if (model == null || model.Count == 0)
                    {
                        isScheduled = true;
                    }
                    else
                    {
                        isScheduled = false;
                        foreach (ScheduleDisplayModel sdm in model.Where(x => x.IsException == false))
                        {
                            #region Weekly
                            if (sdm.ScheduleTypeID == 1) //Weekly
                            {
                                if (sdate.DayOfWeek == DayOfWeek.Monday && sdm.Monday)
                                {
                                    isScheduled = true;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Tuesday && sdm.Tuesday)
                                {
                                    isScheduled = true;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Wednesday && sdm.Wednesday)
                                {
                                    isScheduled = true;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Thursday && sdm.Thursday)
                                {
                                    isScheduled = true;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Friday && sdm.Friday)
                                {
                                    isScheduled = true;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Saturday && sdm.Saturday)
                                {
                                    isScheduled = true;
                                    break;
                                }
                                if (sdate.DayOfWeek == DayOfWeek.Sunday && sdm.Sunday)
                                {
                                    isScheduled = true;
                                    break;
                                }
                            }
                            #endregion
                            #region Monthly
                            else if (sdm.ScheduleTypeID == 2 &&
                            sdm.FromDay.HasValue &&
                            sdm.ToDay.HasValue &&
                            sdm.FromDay.Value > 0 &&
                            sdm.FromDay.Value <= 31 &&
                            sdm.ToDay.Value > 0 &&
                            sdm.ToDay.Value <= 31 &&
                            (sdm.FromDay.Value <= sdm.ToDay.Value))
                            {
                                for (int day = sdm.FromDay.Value; day <= sdm.ToDay.Value; day++)
                                {
                                    if (day == sdate.Day)
                                    {
                                        isScheduled = true;
                                        break;
                                    }
                                }
                            }
                            #endregion
                            #region Yearly
                            else if (sdm.ScheduleTypeID == 3 &&
                            sdm.Month.HasValue &&
                            sdm.Month.Value > 0 &&
                            sdm.Month.Value <= 12 &&
                            sdm.MonthDay.HasValue &&
                            sdm.MonthDay.Value > 0 &&
                            sdm.MonthDay.Value <= 31)
                            {
                                if (sdm.Month.Value == sdate.Date.Month && sdm.MonthDay.Value == sdate.Date.Day)
                                {
                                    isScheduled = true;
                                    break;
                                }
                            }
                            #endregion

                        }

                        if (isScheduled == true)
                        {
                            foreach (ScheduleDisplayModel sdmException in model.Where(x => x.IsException == true))
                            {
                                #region Weekly
                                if (sdmException.ScheduleTypeID == 1) //Weekly
                                {
                                    if (sdate.DayOfWeek == DayOfWeek.Monday && sdmException.Monday)
                                    {
                                        isScheduled = false;
                                        break;
                                    }
                                    if (sdate.DayOfWeek == DayOfWeek.Tuesday && sdmException.Tuesday)
                                    {
                                        isScheduled = false;
                                        break;
                                    }
                                    if (sdate.DayOfWeek == DayOfWeek.Wednesday && sdmException.Wednesday)
                                    {
                                        isScheduled = false;
                                        break;
                                    }
                                    if (sdate.DayOfWeek == DayOfWeek.Thursday && sdmException.Thursday)
                                    {
                                        isScheduled = false;
                                        break;
                                    }
                                    if (sdate.DayOfWeek == DayOfWeek.Friday && sdmException.Friday)
                                    {
                                        isScheduled = false;
                                        break;
                                    }
                                    if (sdate.DayOfWeek == DayOfWeek.Saturday && sdmException.Saturday)
                                    {
                                        isScheduled = false;
                                        break;
                                    }
                                    if (sdate.DayOfWeek == DayOfWeek.Sunday && sdmException.Sunday)
                                    {
                                        isScheduled = false;
                                        break;
                                    }
                                }
                                #endregion
                                #region Monthly
                                else if (sdmException.ScheduleTypeID == 2 &&
                                sdmException.FromDay.HasValue &&
                                sdmException.ToDay.HasValue &&
                                sdmException.FromDay.Value > 0 &&
                                sdmException.FromDay.Value <= 31 &&
                                sdmException.ToDay.Value > 0 &&
                                sdmException.ToDay.Value <= 31 &&
                                (sdmException.FromDay.Value <= sdmException.ToDay.Value))
                                {
                                    for (int day = sdmException.FromDay.Value; day <= sdmException.ToDay.Value; day++)
                                    {
                                        if (day == sdate.Day)
                                        {
                                            isScheduled = false;
                                            break;
                                        }
                                    }
                                }
                                #endregion
                                #region Yearly
                                else if (sdmException.ScheduleTypeID == 3 &&
                                    sdmException.Month.HasValue &&
                                    sdmException.Month.Value > 0 &&
                                    sdmException.Month.Value <= 12 &&
                                    sdmException.MonthDay.HasValue &&
                                    sdmException.MonthDay.Value > 0 &&
                                    sdmException.MonthDay.Value <= 31)
                                {
                                    if (sdmException.Month.Value == sdate.Date.Month && sdmException.MonthDay.Value == sdate.Date.Day)
                                    {
                                        isScheduled = false;
                                        break;
                                    }
                                }
                                #endregion

                            }
                        }                        
                    }
                    if (isScheduled)
                    {
                        DateTime? lastAvailableDate = listOfDates.LastOrDefault();
                        if (lastAvailableDate.HasValue && (lastAvailableDate.Value == new DateTime(1, 1, 1) || lastAvailableDate.Value.AddDays(1) == sdate))
                            listOfDates.Add(sdate);
                        else
                            counter = LimitInDays;
                    }
                    sdate = sdate.AddDays(1);
                    counter++;
                }

                List<string> stringList = listOfDates.Select(x => x.ToString("dd/MM/yyyy")).ToList();

                return stringList;
            }
            else
            {
                return new List<string>();
            }
        }

        private IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}
