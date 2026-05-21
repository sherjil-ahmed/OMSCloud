using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.DataStore.EF.OMSModel;
using oms = OMSCloud.DataStore.EF.OMSModel;
using OMSCloud.DataStore.EF.UnitofWork;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OMSCloud.Business.Adapters
{

    public partial class AddressAdapter
    {

        #region Select
        public List<AddressViewModel> GetAddressList()
        {
            var editableAddressList = GetNonEditableAddressEnumeration();
            var result = (from a in uow.OMSContext.Address
                          join at in uow.OMSContext.AddressType on a.AddressTypeID equals at.AddressTypeID
                          join p in uow.OMSContext.Profile on a.ProfileID equals p.ProfileID
                          join c in uow.OMSContext.LocationTree on a.CityID equals c.LocationID
                          join pr in uow.OMSContext.LocationTree on a.ProvinceID equals pr.LocationID
                          join l in uow.OMSContext.LocationTree on a.CountryID equals l.LocationID
                          select new AddressViewModel
                          {
                              AddressID = a.AddressID,
                              OperatingCountryID = a.CountryID.HasValue ? a.CountryID.Value : -1,
                              OperatingProvinceID = a.ProvinceID.HasValue ? a.ProvinceID.Value : -1,
                              OperatingCityID = a.CityID.HasValue ? a.CityID.Value : -1,
                              LocationID = a.LocationID,
                              LocationName = l.LocationTitle,
                              AddressTypeID = a.AddressTypeID,
                              AddressTypeName = at.AddressTypeTitle,
                              ProfileID = a.ProfileID,
                              ProfileName = p.FirstName + " " + p.LastName,
                              NearestLandmark = a.NearestLandmark,
                              PlotNumber = a.PlotNumber,
                              PostalCode = a.PostalCode,
                              StreetNumber = a.StreetNumber,
                              OperatingCityTitle = c.LocationTitle,
                              OperatingProvinceTitle = pr.LocationTitle,
                              IsEditable = editableAddressList.Any(item => item.AddressID == a.AddressID)
                          }).ToList();

            return result;
        }
        public AddressViewModel GetAddressByAddressID(long AddressID)
        {
            var result = (from a in uow.OMSContext.Address
                          join c in uow.OMSContext.LocationTree on a.CityID equals c.LocationID
                          join pr in uow.OMSContext.LocationTree on a.ProvinceID equals pr.LocationID
                          where a.AddressID == AddressID
                          select new AddressViewModel
                          {
                              AddressID = a.AddressID,
                              OperatingCountryID = a.CountryID.HasValue ? a.CountryID.Value : -1,
                              OperatingProvinceID = a.ProvinceID.HasValue ? a.ProvinceID.Value : -1,
                              OperatingCityID = a.CityID.HasValue ? a.CityID.Value : -1,
                              AddressTypeID = a.AddressTypeID,
                              ProfileID = a.ProfileID,
                              NearestLandmark = a.NearestLandmark,
                              PlotNumber = a.PlotNumber,
                              PostalCode = a.PostalCode,
                              StreetNumber = a.StreetNumber,
                              OperatingCityTitle = c.LocationTitle,
                              OperatingProvinceTitle = pr.LocationTitle,
                              MapLink = a.MapLink,
                          }).ToList();

            return result.FirstOrDefault();
        }
        public AddressModel GetAddressById(long AddressId)
        {
            var address = (from a in uow.OMSContext.Address
                           join s in uow.OMSContext.Supplier on a.AddressID equals s.BusinessAddressID
                           where a.AddressID == AddressId
                           select new AddressModel
                           {
                               AddressID = a.AddressID,
                               AddressTypeID = a.AddressTypeID,
                               CountryID = a.CountryID.HasValue ? a.CountryID.Value : -1,
                               ProvinceID = a.ProvinceID.HasValue ? a.ProvinceID.Value : -1,
                               CityID = a.CityID.HasValue ? a.CityID.Value : -1,
                               LocationID = a.LocationID,
                               NearestLandmark = a.NearestLandmark,
                               PlotNumber = a.PlotNumber,
                               PostalCode = a.PostalCode,
                               ProfileID = a.ProfileID,
                               StreetNumber = a.StreetNumber,
                               ModifiedOn = a.LastModifiedDateTime,
                               IsBusinessAddressVisible = s.IsBusinessAddressVisible,
                               ShopID = s.SupplierID,
                           }).FirstOrDefault();
            return address;
        }

        public List<AddressModel> GetAddressListByProfileId(long Id, long? AddressTypeID = null) 
        {
            var result = (from a in uow.OMSContext.Address
                          //join c in uow.OMSContext.CartOrder on a.ProfileID equals c.BuyerProfileID
                          where a.ProfileID == Id
                          select new AddressModel
                          {
                              AddressID = a.AddressID,
                              AddressTypeID = a.AddressTypeID,
                              CountryID = a.CountryID.HasValue ? a.CountryID.Value : -1,
                              ProvinceID = a.ProvinceID.HasValue ? a.ProvinceID.Value : -1,
                              CityID = a.CityID.HasValue ? a.CityID.Value : -1,
                              LocationID = a.LocationID,
                              NearestLandmark = a.NearestLandmark,
                              PlotNumber = a.PlotNumber,
                              PostalCode = a.PostalCode,
                              ProfileID = a.ProfileID,
                              StreetNumber = a.StreetNumber,
                              ModifiedOn = a.LastModifiedDateTime,
                          });
            if (AddressTypeID != null)
                result = result.Where(a => a.AddressTypeID == AddressTypeID.Value);
            return result.ToList();
        }

        public List<AddressModel> GetDeliveryAddressByCartId(long Id) //CartOrder 
        {
            var result = (from a in uow.OMSContext.Address
                          join c in uow.OMSContext.CartOrder on a.ProfileID equals c.BuyerProfileID
                          where c.CartOrderID == Id
                          select new AddressModel
                          {
                              AddressID = a.AddressID,
                              AddressTypeID = a.AddressTypeID,
                              CountryID = a.CountryID.HasValue ? a.CountryID.Value : -1,
                              ProvinceID = a.ProvinceID.HasValue ? a.ProvinceID.Value : -1,
                              CityID = a.CityID.HasValue ? a.CityID.Value : -1,
                              LocationID = a.LocationID,
                              NearestLandmark = a.NearestLandmark,
                              PlotNumber = a.PlotNumber,
                              PostalCode = a.PostalCode,
                              ProfileID = a.ProfileID,
                              StreetNumber = a.StreetNumber,
                          }
                          );
            return result.ToList();
        }

        private IEnumerable<UsedAddress> GetNonEditableAddressEnumeration()
        {
            return (from a in uow.OMSContext.Address
                    join s in uow.OMSContext.Supplier on a.AddressID equals s.BusinessAddressID
                    select new UsedAddress
                    {
                        AddressID = a.AddressID
                    }).Union(
                 from a in uow.OMSContext.Address
                 join co in uow.OMSContext.CartOrder on a.AddressID equals co.DeliveryAddressID
                 select new UsedAddress
                 {
                     AddressID = a.AddressID
                 });
            //.Union(
            //      from a in uow.OMSContext.Address
            //      //need to fix the logic here
            //      //join ci in uow.OMSContext.CartItem on a.AddressID equals ci.DeliveryAdddressID
            //      select new UsedAddress
            //      {
            //          AddressID = a.AddressID
            //      });
        }
        public List<UsedAddress> GetNonEditableAddressList() 
        {
            var result = GetNonEditableAddressEnumeration();
            return result.ToList();
        }

        #endregion Select

        #region Update

        public bool UpdateAddress(AddressModel addressModel)
        {
            try
            {
                var address = UpdateConcurrency(GetEntity(addressModel), addressModel);
                var recordsCount = uow.OMSContext.Address_Update(address);

                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

        #endregion Update

        #region Add

        public long? AddAddress(AddressModel addressModel)
        {
            try
            {
                var address = UpdateConcurrency(GetEntity(addressModel), addressModel, false);
                var outParam = new ObjectParameter("AddressID", typeof(int));
                var recordsCount = uow.OMSContext.Address_Insert(address, outParam, addressModel.ShopID);

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
        public bool DeleteAddress(AddressModel addressModel)
        {
            try
            {
                var address = GetAddressEntity(addressModel);
                uow.AddressRepository.Delete(address);
                uow.Commit();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }
        }
        #endregion Delete

        #region Private
        private AddressModel GetAddressModel(Address address)
        {
            return new AddressModel
            {
                AddressID = address.AddressID,
                AddressTypeID = address.AddressTypeID,
                CountryID = address.CountryID.HasValue ? address.CountryID.Value : -1,
                ProvinceID = address.ProvinceID.HasValue ? address.ProvinceID.Value : -1,
                CityID = address.CityID.HasValue ? address.CityID.Value : -1,
                LocationID = address.LocationID,
                NearestLandmark = address.NearestLandmark,
                PlotNumber = address.PlotNumber,
                PostalCode = address.PostalCode,
                ProfileID = address.ProfileID,
                StreetNumber = address.StreetNumber,
            };
        }
        private Address GetAddressEntity(AddressModel address)
        {
            return new Address()
            {
                AddressID = address.AddressID,
                AddressTypeID = address.AddressTypeID,
                CountryID = address.CountryID,
                ProvinceID = address.ProvinceID,
                CityID = address.CityID,
                LocationID = address.LocationID,
                NearestLandmark = address.NearestLandmark,
                PlotNumber = address.PlotNumber,
                PostalCode = address.PostalCode,
                ProfileID = address.ProfileID,
                StreetNumber = address.StreetNumber
            };
        }
        #endregion Private
    }
}

