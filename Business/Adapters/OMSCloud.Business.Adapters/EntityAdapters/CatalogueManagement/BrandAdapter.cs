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
    public partial class BrandAdapter
    {
        #region Select

        public List<BrandModel> GetListByPage(int PageNum, int PageSize_RowCount, string searchString)
        {
            string[] filters = searchString.Split(',');


            var total = uow.OMSContext.Brand.Select(p => p.BrandID).Count();
            var skip = PageSize_RowCount * (PageNum - 1);
            var cantPage = skip > total;

            if (cantPage) // do what you wish if you can page no further
                return new List<BrandModel>();
            var brandList = uow.OMSContext.Brand.Select(a => a)
                .OrderBy(a => a.BrandName)
                .Skip(skip)
                .Take(PageSize_RowCount)
                .ToList();

            var result = (from a in brandList select GetBrandModel(a)).ToList();

            return result;
        }

        public List<BrandModel> GetBrandList()
        {
            var brandList = uow.BrandRepository.GetAll().OrderBy(o => o.BrandName).Select(a => GetBrandModel(a)).ToList();
            return brandList;
        }
        public BrandModel GetBrandById(long Id)
        {
            var brand = uow.BrandRepository.GetById(Id);
            BrandModel brandModel = GetBrandModel(brand);
            return brandModel;
        }
        public List<BrandModel> GetBrandByStatus(DBStatusEnum status)
        {
            var result = from brand in uow.BrandRepository.OMSContext.Brand
                         where brand.StatusID == (int)status
                         orderby brand.BrandName
                         select GetBrandModel(brand);
            return result.ToList();
        }

        #endregion Select

        #region Update   
        public bool UpdateBrand(BrandModel brandModel)
        {
            try
            {
                var brand = UpdateConcurrency(GetEntity(brandModel), brandModel);

                var recordsCount = uow.OMSContext.Brand_Update(brand);

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
        public long? AddBrand(BrandModel brandModel)
        {
            try
            {
                var brand = UpdateConcurrency(GetEntity(brandModel), brandModel, false);
                var outParam = new ObjectParameter("BrandID", typeof(int));
                var recordsCount = uow.OMSContext.Brand_Insert(brand, outParam);

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
        public bool DeleteBrand(BrandModel brandModel)
        {
            try
            {
                var Brand = GetBrandEntity(brandModel);
                uow.BrandRepository.Delete(Brand);
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

        private BrandModel GetBrandModel(Brand brand)
        {
            return new BrandModel
            {
                BrandID = brand.BrandID,
                BrandName = brand.BrandName,
                //CreatedByUserID = brand.CreatedByUserID,
                //LastModifiedByUserID = brand.LastModifiedByUserID,
                //CreatedDateTime = brand.CreatedDateTime,
                //Description = brand.Description,
                //LastModifiedDateTime = brand.LastModifiedDateTime,
                ManufacturerName = brand.ManufacturerName,
                StatusID = brand.StatusID
            };
        }
        private Brand GetBrandEntity(BrandModel brandModel)
        {
            return new Brand
            {
                BrandID = brandModel.BrandID,
                BrandName = brandModel.BrandName,
                //CreatedByUserID = brandModel.CreatedByUserID,
                //LastModifiedByUserID = brandModel.LastModifiedByUserID,
                //CreatedDateTime = brandModel.CreatedDateTime,
                Description = brandModel.Description,
                //LastModifiedDateTime = brandModel.LastModifiedDateTime,
                ManufacturerName = brandModel.ManufacturerName,
                StatusID = brandModel.StatusID
            };
        }

        #endregion Private

    }
}
