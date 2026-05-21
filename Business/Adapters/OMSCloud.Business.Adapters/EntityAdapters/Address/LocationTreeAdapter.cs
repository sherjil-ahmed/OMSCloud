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
    public partial class LocationTreeAdapter
    {
        #region Select
        public List<LocationTreeModel> GetLocationTreeList()
        {
            var locationTreeList = (from lt in uow.OMSContext.LocationTree
                                    join ltp in uow.OMSContext.LocationTree on lt.ParentLocationID equals ltp.LocationID
                                    select new LocationTreeModel
                                    {
                                        LocationID = lt.LocationID,
                                        LocationLevelID = lt.LocationLevelID,
                                        ParentLocationID = lt.ParentLocationID,
                                        LocationTitle = lt.LocationTitle,
                                        LocationLevelTitle = lt.LocationLevel.LocationLevelTitle,
                                        ParentLocationTitle = ltp.LocationTitle,
                                        Description = lt.Description,
                                    }).OrderBy(x => x.ParentLocationID).ToList();
                //uow.LocationTreeRepository.GetAll().Select(a => GetLocationTreeModel(a)).ToList();
            return locationTreeList;
        }

        public LocationTreeModel GetLocationTreeById(long Id)
        {
            var locationTree = uow.LocationTreeRepository.GetById(Id);
            LocationTreeModel locationTreeModel = GetLocationTreeModel(locationTree);
            return locationTreeModel;
        }
        public List<LocationLookup> GetCountries() 
        {
            return GetLocationList(DBLocationLevelEnum.Country, 0);
        }
        public List<LocationLookup> GetProvincesByCountryID(long CountryId) 
        {
            return GetLocationList(DBLocationLevelEnum.Province, CountryId);
        }
        public List<LocationLookup> GetCitiesByProvinceID(long ProvinceId)
        {
            return GetLocationList(DBLocationLevelEnum.City, ProvinceId);
        }
        
        public List<LocationLookup> GetLocationList(DBLocationLevelEnum LocationLevel, long ParentLocationId = 0)
        {
            return (from c in uow.OMSContext.LocationTree
                    where c.LocationLevelID == (long)LocationLevel && c.ParentLocationID == ParentLocationId
                    orderby c.LocationTitle
                    select new LocationLookup
                    {
                        LocationName = c.LocationTitle,
                        LocationID = c.LocationID
                    }).ToList();
        }
        public List<LocationLookup> GetLocationListByParentName(DBLocationLevelEnum LocationLevel, string ParentName)
        {
            return (from lt in uow.OMSContext.LocationTree
                    join lt2 in uow.OMSContext.LocationTree on lt.ParentLocationID equals lt2.LocationID
                    where lt.LocationLevelID == (long)LocationLevel && lt2.LocationTitle.Trim() == ParentName.Trim()
                    select new LocationLookup
                    {
                        LocationName = lt.LocationTitle,
                        LocationID = lt.LocationID
                    }).ToList();
        }

        public LocationModel GetLocationTreeByLocationId(long Id) //OperatingCityID
        {
            try
            {
                var OperatingProvinceID = new ObjectParameter("operatingProvinceID", typeof(long));
                var OperatingCountryID = new ObjectParameter("operatingCountryID", typeof(long));
                var OperatingCityTitle = new ObjectParameter("operatingCityTitle", typeof(string));
                var OperatingProvinceTitle = new ObjectParameter("operatingProvinceTitle", typeof(string));
                var OperatingCountryTitle = new ObjectParameter("operatingCountryTitle", typeof(string));
                var result = uow.OMSContext.sp_LocationTree_GetByID(Id,
                                                                    OperatingProvinceID,
                                                                    OperatingCountryID,
                                                                    OperatingCityTitle,
                                                                    OperatingProvinceTitle,
                                                                    OperatingCountryTitle);
                LocationModel locationModel = new LocationModel()
                {
                    OperatingCityID = Id,
                    OperatingCityTitle = OperatingCityTitle.Value.ToString(),
                    OperatingProvinceID = (long)OperatingProvinceID.Value,
                    OperatingProvinceTitle = OperatingProvinceTitle.Value.ToString(),
                    OperatingCountryID = (long)OperatingCountryID.Value,
                    OperatingCountryTitle = OperatingCountryTitle.Value.ToString()
                };
                return locationModel;
            }
            catch (Exception ex) 
            {
                return new LocationModel();
            }


        }

        #endregion Select

        #region Update

        public bool UpdateLocationTree(LocationTreeModel locationTreeModel)
        {
            try
            {
                var locationTree = UpdateConcurrency(GetEntity(locationTreeModel), locationTreeModel);
                var recordsCount = uow.OMSContext.LocationTree_Update(locationTree);
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

        public long? AddLocationTree(LocationTreeModel locationTreeModel)
        {
            try
            {
                var outParam = new ObjectParameter("LocationID", typeof(int));

                var locationTree = UpdateConcurrency(GetEntity(locationTreeModel), locationTreeModel);
                var recordsCount = uow.OMSContext.LocationTree_Insert(locationTree, outParam);
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
        public bool DeleteLocationTree(LocationTreeModel locationTreeModel)
        {
            try
            {
                var locationTree = GetLocationTreeEntity(locationTreeModel);
                uow.LocationTreeRepository.Delete(locationTree);
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
        private LocationTreeModel GetLocationTreeModel(LocationTree locationTree)
        {
            return new LocationTreeModel()
            {
                LocationID = locationTree.LocationID,
                LocationLevelID = locationTree.LocationLevelID,
                LocationTitle = locationTree.LocationTitle,
                ParentLocationID = locationTree.ParentLocationID,
                Description = locationTree.Description
            };
        }
        private LocationTree GetLocationTreeEntity(LocationTreeModel locationTreeModel)
        {
            return new LocationTree
            {
                LocationID = locationTreeModel.LocationID,
                LocationLevelID = locationTreeModel.LocationLevelID,
                LocationTitle = locationTreeModel.LocationTitle,
                ParentLocationID = locationTreeModel.ParentLocationID,
                Description = locationTreeModel.Description
            };
        }
        #endregion Private
    }
}
