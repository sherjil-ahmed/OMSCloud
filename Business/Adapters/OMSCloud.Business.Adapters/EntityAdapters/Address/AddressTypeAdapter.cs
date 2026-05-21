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
    public partial class AddressTypeAdapter
    {
        #region Select

        public List<AddressTypeModel> GetAddressTypeList()
        {
            var addressTypeList = uow.AddressTypeRepository.GetAll().Select(a => GetAddressTypeModel(a)).ToList();
            return addressTypeList;
        }
        public AddressTypeModel GetAddressTypeById(long Id)
        {
            var addressType = uow.AddressTypeRepository.GetById(Id);
            AddressTypeModel addressTypeModel = GetAddressTypeModel(addressType);
            return addressTypeModel;
        }
        #endregion Select

        #region update
        public bool UpdateAddressType(AddressTypeModel addressTypeModel)
        {
            try
            {
                var addressType = UpdateConcurrency(GetEntity(addressTypeModel), addressTypeModel);
                var recordsCount = uow.OMSContext.AddressType_Update(addressType);

                return recordsCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion update

        #region Add

        public long? AddAddressType(AddressTypeModel addressTypeModel)
        {
            try
            {
                var addressType = UpdateConcurrency(GetEntity(addressTypeModel), addressTypeModel, false);
                var outParam = new ObjectParameter("AddressTypeID", typeof(int));
                var recordsCount = uow.OMSContext.AddressType_Insert(addressType, outParam);
                var t = outParam.Value.GetType();
                var result = recordsCount > 0 ? (int?)outParam.Value : null;
                if (result.HasValue)
                    return Convert.ToInt64(result.Value);
                else
                    return null;
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

        public bool DeleteAddressType(AddressTypeModel addressTypeModel)
        {
            try
            {
                var addresstype = GetAddressTypesEntity(addressTypeModel);
                uow.AddressTypeRepository.Delete(addresstype);
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

        private AddressTypeModel GetAddressTypeModel(AddressType addressType)
        {
            return new AddressTypeModel
            {
                AddressTypeID = addressType.AddressTypeID,
                AddressTypeTitle = addressType.AddressTypeTitle,
                Description = addressType.Description
            };
        }
        private AddressType GetAddressTypesEntity(AddressTypeModel addressTypeModel)
        {
            return new AddressType
            {
                AddressTypeID = addressTypeModel.AddressTypeID,
                AddressTypeTitle = addressTypeModel.AddressTypeTitle,
                Description = addressTypeModel.Description
            };
        }
        #endregion Private
    }
}
