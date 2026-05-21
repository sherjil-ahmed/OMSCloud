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
    public partial class PackagedProductAdapter
    {
        #region Select
        public List<PackagedProductModel> GetListByPage(int PageNum, int PageSize_RowCount, string searchString)
        {
            string[] filters = searchString.Split(',');


            var total = uow.OMSContext.PackagedProduct.Select(p => p.PackageID).Count();
            var skip = PageSize_RowCount * (PageNum - 1);
            var cantPage = skip > total;

            if (cantPage) // do what you wish if you can page no further
                return new List<PackagedProductModel>();
            var packageProductList = uow.OMSContext.PackagedProduct.Select(a => a)
                .OrderBy(a => a.PackageID)
                .Skip(skip)
                .Take(PageSize_RowCount)
                .ToList();

            var result = (from a in packageProductList select GetPackagedProductModel(a)).ToList();

            return result;
        }

        public List<PackagedProductModel> GetPackagedProductList()
        {
            var packagedProductList = uow.PackagedProductRepository.GetAll().Select(a => GetPackagedProductModel(a)).ToList();
            return packagedProductList;
        }
        public List<PackagedProductModel> GetListByProductId(long Id)
        {
            try
            {
                var result = (from pp in uow.OMSContext.PackagedProduct
                              where pp.ProductID == Id
                              select this.GetModel(pp)).ToList();
                return result;
            }
            catch (Exception ex)
            {
                var result = (from pp in uow.OMSContext.PackagedProduct
                              where pp.ProductID == Id
                              select new PackagedProductModel
                              {
                                  ProductID = pp.ProductID,
                                  PackageID = pp.PackageID,
                                  ChildProductID = pp.ChildProductID,
                                  ChildProductTitle = pp.Product1.ProductTitle,
                                  ProductTitle = pp.Product.ProductTitle,
                                  IncludedByDefault = pp.IncludedByDefault,
                                  OtherDetails = pp.OtherDetails,
                                  PercentagePrice = pp.PercentagePrice,
                                  Quantity = pp.Quantity
                              }).ToList();
                return result;
            }
        }
        public PackagedProductModel GetPackagedProductById(long Id)
        {
            var packagedProduct = uow.PackagedProductRepository.GetById(Id);
            PackagedProductModel packagedProductModel = GetPackagedProductModel(packagedProduct);
            return packagedProductModel;
        }

        #endregion Select

        #region Update

        public bool UpdatePackagedProduct(PackagedProductModel packagedProductModel)
        {
            try
            {
                var packededProduct = UpdateConcurrency(GetEntity(packagedProductModel), packagedProductModel);
                var recordsCount = uow.OMSContext.PackagedProduct_Update(packededProduct);
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

        public long? AddPackagedProduct(PackagedProductModel packagedProductModel)
        {
            try
            {
                var packededProduct = UpdateConcurrency(GetEntity(packagedProductModel), packagedProductModel, false);
                var outParam = new ObjectParameter("PackageID", typeof(int));
                var recordsCount = uow.OMSContext.PackagedProduct_Insert(packededProduct, outParam);
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
        public bool DeletePackagedProduct(PackagedProductModel packagedProductModel)
        {
            try
            {
                var packagedProduct = GetPackagedProductEntity(packagedProductModel);
                uow.PackagedProductRepository.Delete(packagedProduct);
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
        private PackagedProductModel GetPackagedProductModel(PackagedProduct packagedProduct)
        {
            return new PackagedProductModel()
            {
                ProductID = packagedProduct.ProductID,
                PackageID = packagedProduct.PackageID,
                ChildProductID = packagedProduct.ChildProductID,
                IncludedByDefault = packagedProduct.IncludedByDefault,
                OtherDetails = packagedProduct.OtherDetails,
                PercentagePrice = packagedProduct.PercentagePrice,
                Quantity = packagedProduct.Quantity
            };
        }
        private PackagedProduct GetPackagedProductEntity(PackagedProductModel packagedProductModel)
        {
            return new PackagedProduct()
            {
                ProductID = packagedProductModel.ProductID,
                PackageID = packagedProductModel.PackageID,
                ChildProductID = packagedProductModel.ChildProductID,
                IncludedByDefault = packagedProductModel.IncludedByDefault,
                OtherDetails = packagedProductModel.OtherDetails,
                PercentagePrice = packagedProductModel.PercentagePrice,
                Quantity = packagedProductModel.Quantity
            };
        }
        #endregion Private
    }
}
