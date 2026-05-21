using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.UnitofWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Business.Adapters
{
    public partial class LocationLevelAdapter
    {


        #region Select
        public List<LocationLevelModel> GetLocationLevelList()
        {
            var locationLevelList = uow.LocationLevelRepository.GetAll().Select(a => GetLocationLevelModel(a)).ToList();
            return locationLevelList;
        }

        public LocationLevelModel GetLocationLevelById(long Id)
        {
            var locationLevel = uow.LocationLevelRepository.GetById(Id);
            LocationLevelModel locationLevelModel = GetLocationLevelModel(locationLevel);
            return locationLevelModel;
        }
        #endregion Select

        #region Update

        public bool UpdateLocationLevel(LocationLevelModel locationLevelModel)
        {
            try
            {
                var locationLevel = UpdateConcurrency(GetEntity(locationLevelModel), locationLevelModel);
                var recordsCount = uow.OMSContext.LocationLevel_Update(locationLevel);
                return recordsCount > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }

        #endregion Update

        #region Add

        public long? AddLocationLevel(LocationLevelModel locationLevelModel)
        {
            try
            {
                var outParam = new ObjectParameter("LocationLevelID", typeof(int));

                var locationLevel = UpdateConcurrency(GetEntity(locationLevelModel), locationLevelModel);
                var recordsCount = uow.OMSContext.LocationLevel_Insert(locationLevel, outParam);
                return recordsCount > 0 ? (long?)outParam.Value : null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }

        #endregion Add

        #region Delete
        public bool DeleteLocationLevel(LocationLevelModel locationLevelModel)
        {
            try
            {
                var locationLevel = GetLocationLevelEntity(locationLevelModel);
                uow.LocationLevelRepository.Delete(locationLevel);
                uow.Commit();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion Delete

        #region Private
        private LocationLevelModel GetLocationLevelModel(LocationLevel locationLevel)
        {
            return new LocationLevelModel
            {
                Description = locationLevel.Description,
                LocationLevelID = locationLevel.LocationLevelID,
                LocationLevelTitle = locationLevel.LocationLevelTitle
            };
        }
        private LocationLevel GetLocationLevelEntity(LocationLevelModel locationLevelModel)
        {
            return new LocationLevel()
            {
                Description = locationLevelModel.Description,
                LocationLevelID = locationLevelModel.LocationLevelID,
                LocationLevelTitle = locationLevelModel.LocationLevelTitle
            };
        }
        #endregion Private
    }
}
