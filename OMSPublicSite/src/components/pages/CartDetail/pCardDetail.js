import React from 'react';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import { Helmet } from 'react-helmet';
import izitoast from 'izitoast';
import 'izitoast/dist/css/iziToast.css';
import { FetchData, baseUrlImage } from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  STATUS_CODE,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  GENERIC_ERR_MSG,
  PROFILE_ID,
  CART_DETAILS,
  TEMP_ORDER_LIST_TYPE,
  IS_USER_LOGGEDIN,
  SIZE
} from '../../../utils/constants';
import {
  getStorageItem,
  removeStorageItem,
  setStorageItem,
} from '../../../utils/storageHelper';
import { default_currency } from '../../../utils/globalConstants';
import { ImageEntityEnum } from '../../../utils/enums';

class CartDetail extends React.Component {
  constructor(props) {
    super(props);
    this.lstQtyRef = [];
    this.lstQtyRefMob = [];
    this.QtyRef = null;
    this.state = {
      cartDetailsObj: null,
    };
  }

  successGetCartDetails = (resp) => {
    window.exposeCardHeader(resp);
    if (resp != null && resp.CartItemList && resp.CartItemList.length > 0) {
      resp.CartItemList = resp.CartItemList.filter((a) => !(a.StatusID == 4));
      for (let item of resp.CartItemList) {
        item.QtyRef = React.createRef();
        item.QtyRefMob = React.createRef();
        item.CalculatedDiscountAmount = 0;

        let discountUnitVal = item.IsDiscountPercentage
          ? (item.DiscountValue / 100) * item.UnitPrice
          : item.DiscountValue;
        item.ItemTotalPriceWOTax =
          item.Quantity * item.UnitPrice - item.Quantity * discountUnitVal;
      }
    }
    this.setState(
      {
        cartDetailsObj: resp,
      },
      () => {
        if (
          this.state.cartDetailsObj != null &&
          this.state.cartDetailsObj.CartItemList &&
          this.state.cartDetailsObj.CartItemList.length > 0
        ) {
          //first time
          this.state.cartDetailsObj.DiscountTotal = this.ReCalcDiscount().toFixed(
            2,
          );
          this.setState({
            cartDetailsObj: this.state.cartDetailsObj,
          });

          for (let item of this.state.cartDetailsObj.CartItemList) {
            item.CalculatedDiscountAmount = item.IsDiscountPercentage
              ? (item.DiscountValue / 100) * item.UnitPrice
              : item.DiscountValue;
            window.createTouchspinElementVertical(item.QtyRef, (value) => {
              item.Quantity = value;
              this.state.cartDetailsObj.DiscountTotal = this.ReCalcDiscount(
                item,
              ).toFixed(2);
              window.DirtyFlag = true;
              this.setState(
                {
                  cartDetailsObj: this.state.cartDetailsObj,
                },
                () => { },
              );
            });
                        //ref for mobile
                        window.createTouchspinElementVertical(item.QtyRefMob, (value) => {
                          item.Quantity = value;
                          this.state.cartDetailsObj.DiscountTotal = this.ReCalcDiscount(
                            item,
                          );
                          window.DirtyFlag = true;
                          this.setState(
                            {
                              orderDetailObj: this.state.orderDetailObj,
                            },
                            () => { },
                          );
                        });
          }
        }
      },
    );
  };

  ReCalcDiscount = (refitem) => {
    let _orderTotal = 0;
    let _discount = 0;
    let _tax = 0;
    let _list = refitem
      ? this.state.cartDetailsObj.CartItemList.filter(
        (a) => !(a.CartItemID == refitem.CartItemID),
      )
      : this.state.cartDetailsObj.CartItemList;
    for (let item of _list) {
      let discountUnitVal = item.IsDiscountPercentage
        ? (item.DiscountValue / 100) * item.UnitPrice
        : item.DiscountValue;
      _discount += item.Quantity * discountUnitVal;
      _orderTotal += item.Quantity * item.UnitPrice;
      item.ItemTotalPriceWOTax =
        item.Quantity * item.UnitPrice - item.Quantity * discountUnitVal;
      item.TaxAmount = (item.ItemTotalPriceWOTax * item.TaxRateApplied) / 100;
      _tax += item.TaxAmount;
    }
    if (refitem) {
      let discountUnitVal = refitem.IsDiscountPercentage
        ? (refitem.DiscountValue / 100) * refitem.UnitPrice
        : refitem.DiscountValue;
      _discount += refitem.Quantity * discountUnitVal;
      _orderTotal += refitem.Quantity * refitem.UnitPrice;
      refitem.ItemTotalPriceWOTax =
        refitem.Quantity * refitem.UnitPrice -
        refitem.Quantity * discountUnitVal;
      refitem.TaxAmount =
        (refitem.ItemTotalPriceWOTax * refitem.TaxRateApplied) / 100;
      _tax += refitem.TaxAmount;
    }
    //set OrderTotal & PaymentTotal here as well
    this.state.cartDetailsObj.CartTotal = _orderTotal - _discount;
    this.state.cartDetailsObj.TaxTotal = _tax;

    return _discount;
  };

  successUpdateCartDetail = (res, params) => {
    window.exposeCardHeader(this.state.cartDetailsObj);
    window.DirtyFlag = false;
    if (!params.bRedirect) {
      let i = 0;
      for (let item of this.state.cartDetailsObj.CartItemList) {
        item.QtyRef = this.lstQtyRef[i];
        item.QtyRefMob = this.lstQtyRefMob[i];
        i++;
      }
      this.lstQtyRef = [];
      this.lstQtyRefMob = [];
    }

    if (res) {
      //window.exposeCardHeader({})
      if (params.bRedirect) {
        FetchData(
          REQUEST_TYPE.POST,
          SERVICE_ENDPOINTS.Order_ConvertCartToOrders,
          { existing_CartId: this.state.cartDetailsObj.CartID },
          this.successConvertCartToOrders,
        );
      } else {
              izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.SUCCESS,
          message: 'Cart Updated Successfully',
          target: '.testtarget',
          color: COLOR.GREEN,
          messageSize: SIZE.FONT_SIZE
        });
        window.location.href = '/cartdetail';
      }
    } else {
      if (!params.bRedirect) {
              izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.WARNING,
          message: 'Unable to update cart',
          target: '.testtarget',
          color: COLOR.RED,
          messageSize: SIZE.FONT_SIZE
        });
      }
    }
  };

  updateCartDetails = (bRedirect) => {
    if (
      this.state.cartDetailsObj &&
      this.state.cartDetailsObj.CartID &&
      this.state.cartDetailsObj.CartItemList &&
      this.state.cartDetailsObj.CartItemList.length > 0
    ) {
      for (let item of this.state.cartDetailsObj.CartItemList) {
        this.lstQtyRef.push(item.QtyRef);
        this.lstQtyRefMob.push(item.QtyRefMob);
        item.QtyRef = '';
        item.QtyRefMob = '';
      }
    }
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Cart_UpdateCartDetail,
      this.state.cartDetailsObj,
      this.successUpdateCartDetail,
      null,
      { bRedirect: bRedirect },
    );
  };
  componentDidMount() {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Cart_GetCartDetailsByProfileId +
      getStorageItem(PROFILE_ID),
      null,
      this.successGetCartDetails,
    );
  }

  successConvertCartToOrders = (resp) => {
    removeStorageItem(CART_DETAILS);
    setStorageItem(TEMP_ORDER_LIST_TYPE, 101);
    if (getStorageItem(IS_USER_LOGGEDIN)) {
      window.location.href = '/MyAccount';
    } else {
      window.location.href = '/OrderList';
    }
  };

  ConvertCartToOrder = (e, bRedirect) => {
    e.preventDefault();
    if (
      this.state.cartDetailsObj &&
      this.state.cartDetailsObj.CartItemList &&
      this.state.cartDetailsObj.CartItemList.length > 0
    ) {
      this.updateCartDetails(bRedirect);
    }
    else
    {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Your cart is empty therefore, it can\'t be converted to orders',
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };
  removeItem = (item, bRedirect) => {
    if (
      this.state.cartDetailsObj &&
      this.state.cartDetailsObj.CartID &&
      this.state.cartDetailsObj.CartItemList &&
      this.state.cartDetailsObj.CartItemList.length > 0
    ) {
      //this.state.cartDetailsObj.CartItemList.find(a=>a.CartItemID ==item.CartItemID)
      item.StatusID = 4;
      //this.state.cartDetailsObj.CartItemList = cartDetails
      this.setState(
        {
          cartDetailsObj: this.state.cartDetailsObj,
        },
        () => {
          if (
            this.state.cartDetailsObj &&
            this.state.cartDetailsObj.CartID &&
            this.state.cartDetailsObj.CartItemList &&
            this.state.cartDetailsObj.CartItemList.length > 0
          ) {
            for (let item of this.state.cartDetailsObj.CartItemList) {
              this.lstQtyRef.push(item.QtyRef);
              this.lstQtyRefMob.push(item.QtyRefMob);
              item.QtyRef = '';
              item.QtyRefMob = '';
            }
          }
          FetchData(
            REQUEST_TYPE.POST,
            SERVICE_ENDPOINTS.Cart_UpdateCartDetail,
            this.state.cartDetailsObj,
            this.successUpdateCartDetail,
            null,
            { bRedirect: bRedirect },
          );
        },
      );
    }
  };

  render() {
    return (
      <main className="main">
        {this.props.showCompOnly ? (
          <></>
        ) : (
          <>
            <Header />
            <nav aria-label="breadcrumb" className="breadcrumb-nav">
              <div className="container">
                <ol className="breadcrumb">
                  <li className="breadcrumb-item">
                    <a href="/">
                      <i className="icon-home" />
                    </a>
                  </li>
                  <li className="breadcrumb-item active" aria-current="page">
                    Cart
                  </li>
                </ol>
              </div>
              {/* End .container */}
            </nav>
          </>
        )}

        <div className="container cartorder_detail_min_height">
          <div className="row all-tac">
            <div className={this.props.showCompOnly ? 'col-lg-12' : 'col-lg-8'}>
              <div className="cart-table-container">
                <table className="table table-cart">
                  <thead>
                    <tr className="tr-head">
                      <th>Product Image</th>
                      <th className="product-col">Product</th>
                      <th className="price-col">Price</th>
                      <th className="qty-col">Qty</th>
                      <th>Subtotal</th>
                    </tr>
                  </thead>
                  
                  <tbody>
                    {this.state.cartDetailsObj != null &&
                      this.state.cartDetailsObj.CartItemList &&
                      this.state.cartDetailsObj.CartItemList.length > 0 ? (
                      this.state.cartDetailsObj.CartItemList.map((item, i) => (
                        <tr key={i} className="product-row cart-pro-row45">
                          <td>
                            {console.log(this.state.cartDetailsObj.cartDetailsObj)}
                            <a
                              href=""
                              onClick={(e) => {
                                e.preventDefault();
                                window.location.href =
                                  '/productdetail?ProductId=' + item.ProductID;
                              }}
                              className="product-image"
                            >
                              <img
                                src={
                                  baseUrlImage +
                                  ImageEntityEnum.PRODUCT +
                                  '/' +
                                  item.ProductID +
                                  '/' +
                                  item.ProductDefaultImage
                                }
                                alt="product"
                                onError={() => {
                                  this.src =
                                    'assets/images/logos/shop.png';
                                }}
                              />
                            </a>
                          </td>
                          <td className="product-col insdtd">
                            <h2 className="product-title">
                              <span className="product_name">
                                {' '}
                                <a
                                  href=""
                                  onClick={(e) => {
                                    e.preventDefault();
                                    window.location.href =
                                      '/productdetail?ProductId=' +
                                      item.ProductID;
                                  }}
                                >
                                  {item.ProductTitle}
                                </a>
                              </span>
                              <span className="shop_name">
                                {' '}
                                <a>{item.ShopName}</a>
                              </span>
                              {item.ExpectedDeliveryInfo ? (
                                <span
                                  className="mt-1"
                                  style={{ fontSize: '12px' }}
                                >
                                  {item.ExpectedDeliveryInfo}
                                </span>
                              ) : (
                                <></>
                              )}
                              {item.AttributeList.map((attr, j) => (
                                <span key={j} className="Product_attributes">
                                  {attr.AttributeID +
                                    ' : ' +
                                    attr.AttributeValue}
                                </span>
                              ))}
                              <span />
                            </h2>
                            <div className="edit_buttons">
                              <a
                                title="Remove product"
                                className="btn-remove"
                                onClick={(e) => {
                                  e.preventDefault();
                                  this.removeItem(item, false);
                                }}
                              >
                                <span className="sr-only">Remove</span>
                              </a>
                            </div>
                          </td>
                          <td>
                            {default_currency.symbol + item.UnitPrice}{' '}
                            <span className="discounted_price">
                              Discount ={' '}
                              {default_currency.symbol +
                                item.CalculatedDiscountAmount.toFixed(2)}
                            </span>
                          </td>
                          <td>
                            <input
                              ref={item.QtyRef}
                              value={item.Quantity}
                              className="vertical-quantity form-control"
                              type="text"
                              onChange={(e) => { }}
                            />
                          </td>
                          <td>
                            {default_currency.symbol +
                              item.ItemTotalPriceWOTax.toFixed(2)}
                          </td>
                        </tr>
                      ))
                    ) : (
                      <></>
                    )}
                   
                    {this.state.cartDetailsObj != null &&
                      this.state.cartDetailsObj.CartItemList &&
                      this.state.cartDetailsObj.CartItemList.length > 0 ? (
                        
                      this.state.cartDetailsObj.CartItemList.map((item, i) => (
                        
                        <tr key={i} className="jus-mob-view">
                           {
                           //console.log('hassanhere',this.state.cartDetailsObj.CartItemList) 
                           }
                          <td>
                            <div className="pro-img-con-main">
                              <div className="pro-ct-img">
                                <img src={
                                  baseUrlImage +
                                  ImageEntityEnum.PRODUCT +
                                  '/' +
                                  item.ProductID +
                                  '/' +
                                  item.ProductDefaultImage
                                }
                                  alt="product"
                                  onError={() => {
                                    this.src =
                                      'assets/images/logos/shop.png';
                                  }}></img>
                              </div>
                              <div className="pro-ct-cont">
                                <div className="crt-pro-tit">
                                  <h2> <a
                                    href=""
                                    onClick={(e) => {
                                      e.preventDefault();
                                      window.location.href =
                                        '/productdetail?ProductId=' +
                                        item.ProductID;
                                    }}
                                  >{item.ProductTitle} </a></h2>
                                  <div className="sp-n-pol">
                                    <p className="ssd"><a>{item.ShopName}</a></p>
                                    {item.ExpectedDeliveryInfo ? (
                                      <p>{item.ExpectedDeliveryInfo}</p>
                                    ) : (
                                      <></>
                                    )}

                                  </div>

                                  <a
                                    title="Remove product"
                                    onClick={(e) => {
                                      e.preventDefault();
                                      this.removeItem(item, false);
                                    }}
                                  >
                                    <span className="clx">X</span>
                                  </a>
                                </div>
                                <div className="crt-pro-pric">
                                  <h3>Price</h3>
                                  <p className="desc">Discount =  {default_currency.symbol +
                                    item.CalculatedDiscountAmount.toFixed(2)}</p>
                                  <span>{default_currency.symbol + item.UnitPrice}</span>
                                </div>
                                <div className="crt-pro-qtn">
                                  <h3>Qty</h3>
                                  <input
                                    ref={item.QtyRefMob}
                                    value={item.Quantity}
                                    type="text"
                                    onChange={(e) => { }}
                                  />
                                </div>
                                <div className="crt-pro-sub">
                                  <h3>Subtotal</h3>
                                  <span>{default_currency.symbol +
                                    item.ItemTotalPriceWOTax.toFixed(2)}</span>
                                </div>
                              </div>
                            </div>
                          </td>
                        </tr>
                      ))
                    ) : <> </>
                    }
                  </tbody>
                  <tfoot>
                    <tr>
                      <td colSpan={5} className="clearfix tab-fot-bot">
                        <div className="float-left">
                          <a href="/" className="btn btn-outline-secondary">
                            Continue Shopping
                          </a>
                        </div>
                        {/* End .float-left */}
                        {this.state.cartDetailsObj != null &&
                          this.state.cartDetailsObj.CartItemList &&
                          this.state.cartDetailsObj.CartItemList.length > 0 ? (
                          <div className="float-right">
                            {/* <a href="#" className="btn btn-outline-secondary btn-clear-cart">Clear Shopping Cart</a> */}
                            <a
                              href=""
                              onClick={(e) => {
                                e.preventDefault();
                                this.updateCartDetails(false);
                              }}
                              className="btn btn-outline-secondary btn-update-cart"
                            >
                              Update Shopping Cart
                            </a>
                          </div>
                        ) : (
                          <></>
                        )}
                      </td>
                    </tr>
                  </tfoot>
                </table>
              </div>
              {/* End .cart-table-container */}
              <div className="cart-discount">
                <h4>Apply Discount Code</h4>
                <form action="#">
                  <div className="input-group">
                    <input
                      type="text"
                      className="form-control form-control-sm"
                      placeholder="Enter discount code"
                      required
                    />
                    <div className="input-group-append">
                      <button className="btn btn-sm btn-primary" type="submit">
                        Apply Discount
                      </button>
                    </div>
                  </div>
                  {/* End .input-group */}
                </form>
              </div>
              {/* End .cart-discount */}
            </div>
            {/* End .col-lg-8 */}
            <div className={this.props.showCompOnly ? 'col-lg-12' : 'col-lg-4'}>
              <div className="cart-summary">
                <h3>Summary</h3>
                <table className="table table-totals">
                  <tfoot>
                    <tr>
                      <td>Discount Total</td>
                      <td>
                        {this.state.cartDetailsObj &&
                          this.state.cartDetailsObj.DiscountTotal
                          ? default_currency.symbol +
                          parseFloat(
                            this.state.cartDetailsObj.DiscountTotal,
                          ).toFixed(2)
                          : default_currency.symbol + '0'}
                      </td>
                    </tr>
                    <tr>
                      <td>Cart Total</td>
                      <td>
                        {this.state.cartDetailsObj &&
                          this.state.cartDetailsObj.CartTotal
                          ? default_currency.symbol +
                          parseFloat(
                            this.state.cartDetailsObj.CartTotal,
                          ).toFixed(2)
                          : default_currency.symbol + '0'}
                      </td>
                    </tr>
                    <tr>
                      <td>Tax</td>
                      <td>
                        {this.state.cartDetailsObj &&
                          this.state.cartDetailsObj.TaxTotal
                          ? default_currency.symbol +
                          parseFloat(
                            this.state.cartDetailsObj.TaxTotal,
                          ).toFixed(2)
                          : default_currency.symbol + '0'}
                      </td>
                    </tr>
                    <tr>
                      <td>Payment Total</td>
                      <td>
                        {this.state.cartDetailsObj
                          ? default_currency.symbol +
                          parseFloat(
                            this.state.cartDetailsObj.TaxTotal +
                            this.state.cartDetailsObj.CartTotal,
                          ).toFixed(2)
                          : default_currency.symbol + '0'}
                      </td>
                    </tr>
                  </tfoot>
                </table>
                <div className="checkout-methods">
                  <a
                    href=""
                    onClick={(e) => {
                      e.preventDefault();
                      this.ConvertCartToOrder(e, true);
                    }}
                    className="btn btn-block btn-outline-secondary"
                  >
                    Place Order <br />
                    (One order for each shop)
                  </a>
                </div>
              </div>
              {/* End .cart-summary */}
            </div>
            {/* End .col-lg-4 */}
          </div>
          {/* End .row */}
        </div>
        {/* End .container */}
        {this.props.showCompOnly ? <></> : <Footer />}
      </main>
    );
  }
}

export default CartDetail;
