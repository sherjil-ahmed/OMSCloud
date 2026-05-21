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
    public partial class LocationLevelBusinessComponent
    {
        public List<LocationLevelModel> GetLocationLevelList()
        {
            return adapter.GetLocationLevelList();
        }
        public LocationLevelModel GetLocationLevelById(long Id)
        {
            return adapter.GetLocationLevelById(Id);
        }
        public long? AddLocationLevel(LocationLevelModel LocationLevel)
        {
            return adapter.AddLocationLevel(LocationLevel);
        }
        public bool UpdateLocationLevel(LocationLevelModel LocationLevel)
        {
            return adapter.UpdateLocationLevel(LocationLevel);
        }
        public bool DeleteLocationLevel(LocationLevelModel LocationLevel)
        {
            return adapter.DeleteLocationLevel(LocationLevel);
        }
    }
}
