using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.ViewModels;
using OMSCloud.Business.Adapters;
using OMSCloud.Contracts.Common.DBEnums;
using OMSCloud.DataStore.EF.OMSModel;

namespace OMSCloud.Business.Core
{
    public partial class CartItemBusinessComponent
    {
        public List<CartItemModel> GetCartItemList()
        {
            return adapter.GetCartItemList();
        }

        public List<CartItemWithAttributesModel> GetCartItemListByCartOrderId(long CartOrderId)
        {
            return adapter.GetCartItemListByCartOrderId(CartOrderId);
        }

        public CartItemModel GetCartItemById(long Id)
        {
            return adapter.GetCartItemById(Id);
        }
        public long? AddCartItem(CartItemModel cartItem)
        {
            //cartItem.TaxAmount = (cartItem.UnitPrice * cartItem.Quantity) * (cartItem.TaxRateApplied / 100);
            //cartItem.ItemTotalPrice = (cartItem.UnitPrice * cartItem.Quantity) + cartItem.TaxAmount - cartItem.DiscountAmount;
            return MakeCalc(cartItem) ? adapter.AddCartItem(cartItem) : 0;
        }
        public long? AddToCartByProductId(CartItemModel cartItem)
        {
            if (cartItem == null) return null;

            var pa = new ProductAdapter();
            if (!pa.IsShopAvailable(cartItem.ProductID))
            {
                return -1;
            }
            var profileId = cartItem.RequestedByProfileId;
            var cartAdapter = new CartAdapter();
            var cart = cartAdapter.GetCurrentUserCart(profileId);

            if (cart == null) return null;

            profileId = cart.BuyerProfileID;
            cartItem.CartOrderID = cart.CartID;

            cartItem.StatusID = (int)DBStatusEnum.Active;
            //var p = new ProductAdapter();
            //var product = p.GetById(cartItem.ProductID);

            //if (product != null) return null;

            //if (product.IsDiscountPercentage)
            //    cartItem.DiscountAmount = product.SellingPrice * (product.DiscountValue ?? 0) / 100;
            //else
            //    cartItem.DiscountAmount = (product.DiscountValue ?? 0) * cartItem.Quantity;
            //cartItem.UnitPrice = product.SellingPrice;
            //cartItem.TaxRateApplied = 0;
            //cartItem.TaxAmount = 0;
            //cartItem.TaxAmount = (cartItem.UnitPrice * cartItem.Quantity) * (cartItem.TaxRateApplied / 100);
            //cartItem.ItemTotalPrice = (cartItem.UnitPrice * cartItem.Quantity) + cartItem.TaxAmount - cartItem.DiscountAmount;
            var newCartItemId = MakeCalc(cartItem) ? adapter.AddCartItem(cartItem) : 0;

            cart.CartTotal += cartItem.UnitPrice * cartItem.Quantity;
            cart.DiscountTotal += cartItem.DiscountAmount;
            cart.TaxTotal += cartItem.TaxAmount;
            cartAdapter.UpdateCart(cart);

            return profileId;
        }

        public long? AddToCartWithAttributesByProductId(CartItemWithAttributesModel cartItem)
        {
            if (cartItem == null) return null;
            var pa = new ProductAdapter();
            if (!pa.IsShopAvailable(cartItem.ProductID))
            {
                return -1;
            }
            var profileId = cartItem.RequestedByProfileId;
            var cartAdapter = new CartAdapter();
            var cart = cartAdapter.GetCurrentUserCart(profileId);
            profileId = cart.BuyerProfileID;
            if (cart == null) return null;
            cartItem.CartOrderID = cart.CartID;
            //cartItem.Quantity = 1;
            cartItem.StatusID = (int)DBStatusEnum.Active;
            var product = pa.GetCartItemProduct(cartItem.ProductID);
            if (product == null) return null;
            var TotalVariationInPrice = 0.0d;
            //TotalVariationInPrice = (from a in cartItem.AttributeList select a.VariationInPrice).Sum();
            foreach (var a in cartItem.AttributeList)
            {
                //a.AttributeID
                //a.AttributeValue
                TotalVariationInPrice += a.VariationInPrice;
            }
            cartItem.UnitPrice = product.UnitPrice + TotalVariationInPrice;
            var Price_x_Quantity = (cartItem.UnitPrice * cartItem.Quantity);
            if (product.IsDiscountPercentage)
                cartItem.DiscountAmount = Price_x_Quantity * (product.DiscountValue ) / 100;
            else
                cartItem.DiscountAmount = (product.DiscountValue) * cartItem.Quantity;

            cartItem.TaxAmount = (Price_x_Quantity - cartItem.DiscountAmount) * (product.TaxRateApplied / 100);
            cartItem.ItemTotalPrice = (cartItem.UnitPrice * cartItem.Quantity) + cartItem.TaxAmount - cartItem.DiscountAmount;
            var cartItemId = adapter.AddCartItem(cartItem);


            cart.CartTotal += Price_x_Quantity;
            cart.DiscountTotal += cartItem.DiscountAmount;
            cart.TaxTotal += cartItem.TaxAmount;
            cartAdapter.UpdateCart(cart);

            if (!cartItemId.HasValue) return null;

            var cia = new CartItemAttributePairAdapter();
            foreach (var a in cartItem.AttributeList)
            {
                a.CartItemID = cartItemId.Value;
                cia.Add(a);
                //a.AttributeID
                //a.AttributeValue
                //a.VariationInPrice;
            }
            return profileId; // return Profile ID becuase of Anonymous user does not have profile id at the time of first add to cart
            //return cartItemId.Value;
        }
        public bool UpdateCartItem(CartItemModel cartItem)
        {
            //var p = new ProductAdapter();
            //var product = p.GetById(cartItem.ProductID);
            //if (product == null) return false;
            //var Price_x_Quantity = (cartItem.UnitPrice * cartItem.Quantity);
            //var DiscountValue = product.DiscountValue ?? 0;
            //if (product.IsDiscountPercentage)
            //    cartItem.DiscountAmount = Price_x_Quantity * DiscountValue / 100;
            //else
            //    cartItem.DiscountAmount = DiscountValue * cartItem.Quantity;

            //cartItem.TaxAmount = Price_x_Quantity * (cartItem.TaxRateApplied/100);
            //cartItem.ItemTotalPrice = Price_x_Quantity + cartItem.TaxAmount - cartItem.DiscountAmount;
            return MakeCalc(cartItem) ? adapter.UpdateCartItem(cartItem) : false;
         
        }
        private bool MakeCalc(CartItemModel cartItem)
        {
            //make calculation with varition in price by CartItemAttribute -- get it from DB if not in Model
            if (cartItem == null) return false;
            var p = new ProductAdapter();
            var product = p.GetCartItemProduct(cartItem.ProductID);
            if (product == null) return false;

            var TotalVariationInPrice = 0.0d;
            var ciapa = new CartItemAttributePairAdapter();
            var AttributeList = ciapa.GetCartItemAttributePairList(cartItem.CartItemID);
            //TotalVariationInPrice = (from a in cartItem.AttributeList select a.VariationInPrice).Sum();
            foreach (var a in AttributeList)
            {
                //a.AttributeID
                //a.AttributeValue
                TotalVariationInPrice += a.VariationInPrice;
            }

            cartItem.UnitPrice = product.UnitPrice + TotalVariationInPrice;
            var Price_x_Quantity = (cartItem.UnitPrice * cartItem.Quantity);
            var DiscountValue = product.DiscountValue ;
            if (product.IsDiscountPercentage)
                cartItem.DiscountAmount = Price_x_Quantity * DiscountValue / 100;
            else
                cartItem.DiscountAmount = DiscountValue * cartItem.Quantity;

            cartItem.TaxAmount = (Price_x_Quantity - cartItem.DiscountAmount) * (cartItem.TaxRateApplied / 100);
            cartItem.ItemTotalPrice = Price_x_Quantity + cartItem.TaxAmount - cartItem.DiscountAmount;
            return true;
        }
        public bool DeleteCartItem(CartItemModel cartItem)
        {
            return adapter.DeleteCartItem(cartItem);
        }
    }
}
