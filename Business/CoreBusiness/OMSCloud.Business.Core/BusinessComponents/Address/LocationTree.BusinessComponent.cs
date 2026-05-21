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
    public partial class LocationTreeBusinessComponent
    {
        public List<LocationTreeModel> GetLocationTreeList()
        {
            return adapter.GetLocationTreeList();
        }
        public LocationModel GetLocationTreeByLocationId(long Id) 
        {
            return adapter.GetLocationTreeByLocationId(Id);
        }
        public List<LocationLookup> GetCountries()
        {
            return adapter.GetCountries();
        }
        public List<LocationLookup> GetProvincesByCountryID(long CountryId)
        {
            return adapter.GetProvincesByCountryID(CountryId);
        }
        public List<LocationLookup> GetCitiesByProvinceID(long ProvinceId)
        {
            return adapter.GetCitiesByProvinceID(ProvinceId);
        }

        public List<LocationLookup> GetLocationList(DBLocationLevelEnum LocationLevel, long ParentLocationId = 0)
        {
            return adapter.GetLocationList(LocationLevel, ParentLocationId);
        }
        public List<LocationLookup> GetLocationListByParentName(DBLocationLevelEnum LocationLevel, string ParentName)
        {
            return adapter.GetLocationListByParentName(LocationLevel, ParentName);
        }

        public LocationTreeModel GetLocationTreeById(long Id)
        {
            return adapter.GetLocationTreeById(Id);
        }
        public long? AddLocationTree(LocationTreeModel LocationTree)
        {
            return adapter.AddLocationTree(LocationTree);
        }
        public bool UpdateLocationTree(LocationTreeModel LocationTree)
        {
            return adapter.UpdateLocationTree(LocationTree);
        }
        public bool DeleteLocationTree(LocationTreeModel LocationTree)
        {
            return adapter.DeleteLocationTree(LocationTree);
        }
    }
}
