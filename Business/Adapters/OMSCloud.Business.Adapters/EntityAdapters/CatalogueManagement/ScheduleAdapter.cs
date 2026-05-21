using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Business.Adapters
{
    public partial class ScheduleAdapter
    {
        private IEnumerable<ScheduleDisplayModel> GetScheduleEnumeration(bool includeNew = true)
        {
            var result = (from s in uow.OMSContext.Schedule
                          join st in uow.OMSContext.Status on s.StatusID equals st.StatusID
                          //where s.StatusID <= (int)DBStatusEnum.Active
                          select new ScheduleDisplayModel
                          {
                              ScheduleID = s.ScheduleID,
                              ShopID = s.SupplierID,
                              ScheduleTypeID = s.ScheduleTypeID.Value,
                              IsException = s.IsException,
                              WeekDays = s.WeekDays,
                              FromDay = s.FromDay,
                              ToDay = s.ToDay,
                              Month = s.Month,
                              MonthDay = s.MonthDay,
                              StatusID = s.StatusID,
                              Notes = s.Notes,
                              StatusTitle = st.StatusName,
                              ShopName = s.Supplier.SupplierName,
                              ScheduleTypeTitle = s.ScheduleType.ScheduleTypeTitle,
                              Monday = s.WeekDays.Contains("Mon"),
                              Tuesday = s.WeekDays.Contains("Tue"),
                              Wednesday = s.WeekDays.Contains("Wed"),
                              Thursday = s.WeekDays.Contains("Thu"),
                              Friday = s.WeekDays.Contains("Fri"),
                              Saturday = s.WeekDays.Contains("Sat"),
                              Sunday = s.WeekDays.Contains("Sun"),
                              CreatedBy = s.CreatedByUserID,
                              CreatedOn = s.CreatedDateTime,
                              ModifiedBy = s.LastModifiedByUserID,
                              ModifiedOn = s.LastModifiedDateTime,
                          });
            if(includeNew)
                return result = result.Where(s => s.StatusID <= (int)DBStatusEnum.Active);
            else
                return result = result.Where(s => s.StatusID == (int)DBStatusEnum.Active);
        }
        public List<ScheduleDisplayModel> GetScheduleList()
        {
            var result = GetScheduleEnumeration();
            return result.ToList();
        }
        public ScheduleDisplayModel GetScheduleById(long Id)
        {
            var result = GetScheduleEnumeration().Where(s => s.ScheduleID == Id);
                
            return result.FirstOrDefault();
        }

        public List<ScheduleDisplayModel> GetScheduleListBySupplierId(long SupplierId)
        {
            return GetScheduleEnumeration().Where(s => s.ShopID == SupplierId).ToList();
        }
    }
}
