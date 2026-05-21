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
    public partial class CartItemAdapter
    {
        #region Select

        public List<CartItemModel> GetListByPage(int PageNum, int PageSize_RowCount, string searchString)
        {
            string[] filters = searchString.Split(',');


            var total = uow.OMSContext.CartItem.Select(p => p.CartItemID).Count();
            var skip = PageSize_RowCount * (PageNum - 1);
            var cantPage = skip > total;

            if (cantPage) // do what you wish if you can page no further
                return new List<CartItemModel>();
            var cartItemList = uow.OMSContext.CartItem.Select(a => a)
                .OrderBy(a => a.CartItemID)
                .Skip(skip)
                .Take(PageSize_RowCount)
                .ToList();

            var result = (from a in cartItemList select GetCartItemModel(a)).ToList();

            return result;
        }

        public List<CartItemModel> GetCartItemList()
        {
            var cartItemList = uow.CartItemRepository.GetAll().Select(a => GetCartItemModel(a)).ToList();
            return cartItemList;
        }

        public List<CartItemWithAttributesModel> GetCartItemListByCartOrderId(long CartOrderId)
        {
            var cartItemList = from i in uow.OMSContext.CartItem
                                   //join p in uow.OMSContext.Product on i.ProductID equals p.ProductID
                               join s in uow.OMSContext.Status on i.StatusID equals s.StatusID
                               where i.CartOrderID == CartOrderId
                               select new CartItemWithAttributesModel
                               {
                                   CartItemID = i.CartItemID,
                                   CartOrderID = i.CartOrderID,
                                   ProductID = i.ProductID,
                                   ProductTitle = i.Product.ProductTitle,
                                   ShopName = i.Product.Supplier.SupplierName,
                                   ProductTypeId = i.Product.ProductTypeID,
                                   ProductTypeTitle = i.Product.ProductType.ProductTypeTitle,
                                   UnitPrice = i.UnitPrice,
                                   Quantity = i.Quantity,
                                   TaxAmount = i.TaxAmount,
                                   TaxRateApplied = i.TaxRateApplied,
                                   DiscountAmount = i.DiscountAmount,
                                   ItemTotalPrice = i.ItemTotalPrice,
                                   DiscountValue = i.Product.DiscountValue ?? 0,
                                   IsDiscountPercentage = i.Product.IsDiscountPercentage ?? true,
                                   StatusID = i.StatusID,
                                   StatusTitle = s.StatusName,
                                   AttributeList = i.CartItemAttributePair.Select(a => new CartItemAttributePairModel {
                                       AttributeID = a.AttributeID,
                                       AttributeValue = a.AttributeValue,
                                       VariationInPrice = a.VariationInPrice.HasValue ? a.VariationInPrice.Value : 0,
                                       CartItemAttributeID = a.CartItemAttributeId,
                                       CartItemID = a.CartItemID,
                                       AttributeName = a.Attribute.AttributeTitle,
                                       AttributeTypeName = a.Attribute.AttributeType.AttributeTypeTitle,
                                       AttributeTypeId = a.Attribute.AttributeTypeID,
                                   }).ToList(),
                               };
            return cartItemList.ToList();
        }

        public CartItemModel GetCartItemById(long Id)
        {
            var model = (from i in uow.OMSContext.CartItem
                         where i.CartItemID == Id
                         select new CartItemModel {
                             CartItemID = i.CartItemID,
                             CartOrderID = i.CartOrderID,
                             ProductID = i.ProductID,
                             UnitPrice = i.UnitPrice,
                             Quantity = i.Quantity,
                             ItemTotalPrice = i.ItemTotalPrice,
                             DiscountAmount = i.DiscountAmount,
                             TaxAmount = i.TaxAmount,
                             TaxRateApplied = i.TaxRateApplied,
                             StatusID = i.StatusID,
                             ModifiedOn = i.LastModifiedDateTime,
                             DiscountValue = i.Product.DiscountValue ?? 0,
                             IsDiscountPercentage = i.Product.IsDiscountPercentage ?? true,
                             ProductTypeId = i.Product.ProductTypeID,
                             ProductTitle = i.Product.ProductTitle,
                             ProductTypeTitle = i.Product.ProductType.ProductTypeTitle,
                             ShopName = i.Product.Supplier.SupplierName,
                         }).FirstOrDefault();
            return model;
        }
        #endregion Select

        #region Update

        public bool UpdateCartItem(CartItemModel cartItemModel)
        {
            try
            {
                var cartItem = UpdateConcurrency(GetEntity(cartItemModel), cartItemModel);
                var recordsCount = uow.OMSContext.CartItem_Update(cartItem);

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
        public long? AddCartItem(CartItemModel cartItemModel)
        {
            try
            {
                var CartItem = UpdateConcurrency(GetEntity(cartItemModel), cartItemModel, false);
                var outParam = new ObjectParameter("CartItemID", typeof(int));
                var recordsCount = uow.OMSContext.CartItem_Insert(CartItem, outParam);

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
        public bool DeleteCartItem(CartItemModel cartItemModel)
        {
            try
            {
                var CartItem = GetCartItemEntity(cartItemModel);
                uow.CartItemRepository.Delete(CartItem);
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
        private CartItemModel GetCartItemModel(CartItem cartItem)
        {
            return new CartItemModel
            {
                CartItemID = cartItem.CartItemID,
                CartOrderID = cartItem.CartOrderID,
                StatusID = cartItem.StatusID,
                ProductID = cartItem.ProductID,
                Quantity = cartItem.Quantity,
                ItemTotalPrice = cartItem.ItemTotalPrice,
                DiscountAmount = cartItem.DiscountAmount,
                TaxAmount = cartItem.TaxAmount,
                TaxRateApplied = cartItem.TaxRateApplied,
                ModifiedOn = cartItem.LastModifiedDateTime,
            };
        }
        private CartItem GetCartItemEntity(CartItemModel cartItemModel)
        {
            return new CartItem
            {
                CartItemID = cartItemModel.CartItemID,
                CartOrderID = cartItemModel.CartOrderID,
                StatusID = cartItemModel.StatusID,
                ProductID = cartItemModel.ProductID,
                Quantity = cartItemModel.Quantity,
                ItemTotalPrice = cartItemModel.ItemTotalPrice
            };
        }
        #endregion Private
    }
    public partial class CartItemAttributePairAdapter : BaseAdapter<CartItemAttributePair, CartItemAttributePairModel>
    {
        public List<CartItemAttributePairModel> GetCartItemAttributePairList(long Id)
        {
            var result = (from a in uow.OMSContext.CartItemAttributePair
                          where a.CartItemID == Id
                          select new CartItemAttributePairModel { 
                                CartItemAttributeID = a.CartItemAttributeId,
                                CartItemID = a.CartItemID,
                                AttributeID = a.AttributeID,
                                AttributeValue = a.AttributeValue,
                                AttributeName = a.Attribute.AttributeTitle,
                                AttributeTypeId = a.Attribute.AttributeTypeID,
                                AttributeTypeName = a.Attribute.AttributeType.AttributeTypeTitle,
                                VariationInPrice = a.VariationInPrice.HasValue ? a.VariationInPrice.Value : 0.0d,
                          });
            return result.ToList();
        }
    }
}
