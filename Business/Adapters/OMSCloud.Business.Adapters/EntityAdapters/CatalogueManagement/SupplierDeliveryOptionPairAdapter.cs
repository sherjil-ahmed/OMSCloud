using OMSCloud.Contracts.ViewModels;

using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.Common.DBEnums;

namespace OMSCloud.Business.Adapters
{
    public partial class SupplierDeliveryOptionPairAdapter
    {
        public List<LocationLookup> GetSurroundingCities(long Id)
        {
            //select* from LocationTree as lt
            //where lt.ParentLocationID =
            //(select locationCity.ParentLocationID from Supplier as supplier
            //join Address as address on supplier.BusinessAddressID = address.AddressID
            //join LocationTree as locationArea on address.LocationID = locationArea.LocationID
            //join LocationTree as locationCity on locationArea.ParentLocationID = locationCity.LocationID
            //where supplier.SupplierID = 26);

            var locationList = (from supplier in uow.OMSContext.Supplier
                                join address in uow.OMSContext.Address on supplier.BusinessAddressID equals address.AddressID
                                join locationCity in uow.OMSContext.LocationTree on address.ProvinceID equals locationCity.ParentLocationID
                                //join locationCity in uow.OMSContext.LocationTree on locationArea.ParentLocationID equals locationCity.LocationID
                                where supplier.SupplierID == Id
                                select new LocationLookup {
                                    LocationID = locationCity.LocationID,
                                    LocationName = locationCity.LocationTitle
                                }).ToList();
            return locationList;
            //var x = locationList.FirstOrDefault();
            //var surroundingCities = (from locationTree in uow.OMSContext.LocationTree
            //                         where locationTree.ParentLocationID == x
            //                        select new LocationLookup { 
            //                           LocationID = locationTree.LocationID,
            //                           LocationName = locationTree.LocationTitle
            //                        }).ToList();

            //return surroundingCities;
        }
        private IQueryable<SupplierDeliveryOptionPairModel> SupplierDeliveryOption(bool filterOnStatus = true)
        {
            var result = from sdo in uow.OMSContext.SupplierDeliveryOptionPair
                         join dO in uow.OMSContext.DeliveryOption on sdo.DeliveryOptionID equals dO.DeliveryOptionID
                         join s in uow.OMSContext.Supplier on sdo.SupplierID equals s.SupplierID
                         select new SupplierDeliveryOptionPairModel()
                         {
                             SupplierDeliveryOptionPairID = sdo.SupplierDeliveryOptionPairID,
                             DeliveryOptionID = sdo.DeliveryOptionID,
                             DeliveryOptionTitle = dO.DeliveryOptionTitle,
                             SupplierID = sdo.SupplierID,
                             SupplierName = s.SupplierName,
                             DeliveryCharges = sdo.DeliveryCharges,
                             MinOrderLimit = sdo.MinOrderLimit,
                             SurroundingCitiesIDs = sdo.SurroundingCitiesIDs,
                             SurroundingCities = "",//To DO: Get Names of Surrounding Cities
                             StatusID = sdo.StatusID,
                             CreatedBy = sdo.CreatedByUserID,
                             CreatedOn = sdo.CreatedDateTime,
                             ModifiedBy = sdo.LastModifiedByUserID,
                             ModifiedOn = sdo.LastModifiedDateTime,
                         };
            if (filterOnStatus)
                result = result.Where(x => x.StatusID <= (long)DBStatusEnum.Active);
            return result;
        }
        public List<SupplierDeliveryOptionPairModel> GetSupplierDeliveryOptionList()
        {
            return SupplierDeliveryOption().ToList();
        }

        public SupplierDeliveryOptionPairModel GetSupplierDeliveryOptionById(long Id)
        {
            var result = SupplierDeliveryOption().Where(d => d.SupplierDeliveryOptionPairID == Id);
            if (result != null && result.Count() > 0)
            {
                var supplier = result.First();
                //if (supplier != null && !string.IsNullOrEmpty(supplier.SurroundingCitiesIDs))
                //{
                //    var cityList = GetSurroundingCities(supplier.SupplierID).Where(a => supplier.SurroundingCitiesIDs.Contains(a.LocationID.ToString()));
                //    var cities = string.Join(",", cityList.Select(c => c.LocationName));
                //    supplier.SurroundingCities = cities;
                //}
                return supplier;
            }
            else
            {
                return null;
            }
        }
        public List<SupplierDeliveryOptionPairModel> GetSupplierDeliveryOptionBySupplierId(long Id, bool filterOnStatus = true)
        {
            var result = SupplierDeliveryOption(filterOnStatus).Where(d => d.SupplierID == Id);
            return result.ToList();
        }

    }
}
