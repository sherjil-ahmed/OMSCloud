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
  INPROC_ORDERID,
  LIST_CITIES,
  LIST_PROVINCES,
  INPROC_SHIPPING_ORDER,
  TEMP_ORDER_LIST_TYPE,
  IS_USER_LOGGEDIN,
  SIZE
} from '../../../utils/constants';
import { getStorageItem, setStorageItem } from '../../../utils/storageHelper';
import { default_currency } from '../../../utils/globalConstants';
import {
  LocationLevelEnum,
  DeliveryOptionEnum,
  ImageEntityEnum,
} from '../../../utils/enums';

class OrderDetail extends React.Component {
  constructor(props) {
    super(props);
    this.lstQtyRef = [];
    this.lstQtyRefMob = [];
    this.state = {
      orderDetailObj: null,
      listCities: [],
      selectedProvince: '',
      selectedCity: '',
      SupplierDeliveryOptionPair: [],
      deliveryType: '',
      showSelfPickup: false,
      showShipping: false,
      calculatedPaymentTotal: 0,
    };
  }

  successGetCityList = (resp) => {
    this.setState({
      listCities: resp,
    });
  };

  successGetSupplierDeliveryOptionPair = (resp) => {
    let showSelfPickup = resp
      ? resp.find((a) => a.DeliveryOptionID == DeliveryOptionEnum.SelfPickUp)
        ? true
        : false
      : false;
    let showShipping = resp
      ? resp.find(
        (a) =>
          a.DeliveryOptionID == DeliveryOptionEnum.DeliverSurroundingCities ||
          a.DeliveryOptionID == DeliveryOptionEnum.ShopDelivery ||
          a.DeliveryOptionID == DeliveryOptionEnum.DeliveryAcrossCountry,
      )
        ? true
        : false
      : false;

    this.setState(
      {
        SupplierDeliveryOptionPair: resp ? resp : [],
        showShipping: showShipping,
        showSelfPickup: showSelfPickup,
        deliveryType: showShipping ? 'Shippment' : '',
      },
      () => {
        let applyAmounts = this.getApplyAmounts();
        let shippingCharge =
          this.state.deliveryType == 'SelfPickup'
            ? 0
            : applyAmounts &&
              applyAmounts.DeliveryCharges &&
              applyAmounts.DeliveryCharges > 0
              ? applyAmounts.DeliveryCharges
              : 0;
        let calculatedPaymentTotal =
          this.state.orderDetailObj.OrderTotal + shippingCharge;
        this.setState({
          calculatedPaymentTotal: calculatedPaymentTotal,
        });
      },
    );
  };

  FetchCityList = () => {
    if (this.state.selectedProvince) {
      let idParent = LocationLevelEnum.City;
      let idChild = this.state.selectedProvince;
      FetchData(
        REQUEST_TYPE.GET,
        SERVICE_ENDPOINTS.LocationTree_GetLocationList +
        idParent +
        '/' +
        idChild,
        null,
        this.successGetCityList,
      );
    } else {
      this.setState({
        listCities: [],
      });
    }
  };

  successGetOrderDetail = (resp) => {
    if (resp != null && resp.ItemList && resp.ItemList.length > 0) {
      resp.ItemList = resp.ItemList.filter((a) => !(a.StatusID == 4));
      for (let item of resp.ItemList) {
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
        orderDetailObj: resp,
        selectedCity: resp.ShopCityId,
        selectedProvince: resp.ShopProvinceId,
        calculatedPaymentTotal: resp.OrderTotal - resp.DiscountTotal,
      },
      () => {
        if (
          this.state.orderDetailObj != null &&
          this.state.orderDetailObj.ItemList &&
          this.state.orderDetailObj.ItemList.length > 0
        ) {
          for (let item of this.state.orderDetailObj.ItemList) {
            //item.UnitDiscountAmount = item.DiscountAmount / item.Quantity;
            item.CalculatedDiscountAmount = item.IsDiscountPercentage
              ? (item.DiscountValue / 100) * item.UnitPrice
              : item.DiscountValue;
            window.createTouchspinElementVertical(item.QtyRef, (value) => {
              item.Quantity = value;
              this.state.orderDetailObj.DiscountTotal = this.ReCalcDiscount(
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

            //ref for mobile
            window.createTouchspinElementVertical(item.QtyRefMob, (value) => {
              item.Quantity = value;
              this.state.orderDetailObj.DiscountTotal = this.ReCalcDiscount(
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

        this.FetchCityList();
        //fetch supplierdeliveryoption
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.SupplierDelivery_GetSupplierDeliveryOptionBySupplierId +
          this.state.orderDetailObj.ShopID,
          null,
          this.successGetSupplierDeliveryOptionPair,
        );
        //
      },
    );
  };

  ReCalcDiscount = (refitem) => {
    let _orderTotal = 0;
    let _discount = 0;
    let _tax = 0;
    let _list = this.state.orderDetailObj.ItemList.filter(
      (a) => !(a.CartItemID == refitem.CartItemID),
    );
    for (let item of _list) {
      let discountUnitVal = item.IsDiscountPercentage
        ? (item.DiscountValue / 100) * item.UnitPrice
        : item.DiscountValue;
      _discount += item.Quantity * discountUnitVal;
      _orderTotal += item.Quantity * item.UnitPrice;
      //item.ItemTotalPrice = (item.Quantity * item.UnitPrice) - (item.Quantity * discountUnitVal)
      item.ItemTotalPriceWOTax =
        item.Quantity * item.UnitPrice - item.Quantity * discountUnitVal;
      item.TaxAmount = (item.ItemTotalPriceWOTax * item.TaxRateApplied) / 100;
      _tax += item.TaxAmount;
    }
    let discountUnitVal = refitem.IsDiscountPercentage
      ? (refitem.DiscountValue / 100) * refitem.UnitPrice
      : refitem.DiscountValue;
    _discount += refitem.Quantity * discountUnitVal;
    _orderTotal += refitem.Quantity * refitem.UnitPrice;
    //refitem.ItemTotalPrice = (refitem.Quantity * refitem.UnitPrice) - (refitem.Quantity * discountUnitVal)
    refitem.ItemTotalPriceWOTax =
      refitem.Quantity * refitem.UnitPrice - refitem.Quantity * discountUnitVal;
    refitem.TaxAmount =
      (refitem.ItemTotalPriceWOTax * refitem.TaxRateApplied) / 100;
    _tax += refitem.TaxAmount;
    //set OrderTotal & PaymentTotal here as well
    this.state.orderDetailObj.OrderTotal = _orderTotal - _discount + _tax;
    this.state.orderDetailObj.TaxTotal = _tax;

    let applyAmounts = this.getApplyAmounts();
    let shippingCharge =
      this.state.deliveryType == 'SelfPickup'
        ? 0
        : applyAmounts &&
          applyAmounts.DeliveryCharges &&
          applyAmounts.DeliveryCharges > 0
          ? applyAmounts.DeliveryCharges
          : 0;
    this.state.calculatedPaymentTotal =
      this.state.orderDetailObj.OrderTotal + shippingCharge;

    return _discount;
  };

  successUpdateOrderDetail = (res, params) => {
    window.DirtyFlag = false;
    if (!(res && params.bRedirect)) {
      let i = 0;
      for (let item of this.state.orderDetailObj.ItemList) {
        item.QtyRef = this.lstQtyRef[i];
          item.QtyRefMob = this.lstQtyRefMob[i];
        i++;
      }
      this.lstQtyRef = [];
      this.lstQtyRefMob = [];
    }
    if (res) {
      if (params.bRedirect) {
        setStorageItem(INPROC_SHIPPING_ORDER, params.shippingOrder);
        setTimeout(() => {
          window.location.href = '/Checkout';
        }, 500);
      } else {
              izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.SUCCESS,
          message: 'Order Updated Successfully',
          target: '.testtarget',
          color: COLOR.GREEN,
          messageSize: SIZE.FONT_SIZE
        });
        window.location.href = '/OrderDetail';
      }
    } else {
      if (!params.bRedirect) {
              izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.WARNING,
          message: 'Unable to update order',
          target: '.testtarget',
          color: COLOR.RED,
          messageSize: SIZE.FONT_SIZE
        });
      }
    }
  };

  updateOrderDetails = (shippingOrder, bRedirect) => {
    if (
      this.state.orderDetailObj != null &&
      this.state.orderDetailObj.ItemList &&
      this.state.orderDetailObj.ItemList.length > 0
    ) {
      for (let item of this.state.orderDetailObj.ItemList) {
          this.lstQtyRef.push(item.QtyRef);
          this.lstQtyRefMob.push(item.QtyRefMob);
          item.QtyRef = '';
          item.QtyRefMob = '';
      }
    }

    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Order_UpdateOrderDetail,
      this.state.orderDetailObj,
      this.successUpdateOrderDetail,
      null,
      { shippingOrder: shippingOrder, bRedirect: bRedirect },
    );
  };

  redirectToShipping = () => {
    //e.preventDefault()
    let shippingOrder = {
      orderDetailObj: this.state.orderDetailObj,
      applyAmounts: this.getApplyAmounts(),
      selectedProvince: this.state.selectedProvince,
      selectedCity: this.state.selectedCity,
      deliveryType: this.state.deliveryType,
      calculatedPaymentTotal: this.state.calculatedPaymentTotal,
    };
    if (this.state.orderDetailObj.ItemList[0].ShopStatusId == 2) {
      this.updateOrderDetails(shippingOrder, true);
    }
  };

  componentDidMount() {
    //setStorageItem(INPROC_ORDERID,"3")

    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Order_GetOrderDetailByOrderId +
      getStorageItem(INPROC_ORDERID),
      null,
      this.successGetOrderDetail,
    );
  }

  getApplyAmounts = () => {
    let supplierDeliveryId = -1;
    let applyAmounts = null;
    if (this.state.selectedProvince) {
      if (this.state.orderDetailObj.ShopProvinceId == this.state.selectedProvince) {
        //console.log('ShopProvinceId == selectedProvince');
        if (this.state.orderDetailObj.ShopCityId == this.state.selectedCity) {
          //console.log('ShopCityId == selectedCity');
          supplierDeliveryId = DeliveryOptionEnum.ShopDelivery;
        } else {
          //console.log('ShopCityId != selectedCity. May be DeliverSurroundingCities');
          supplierDeliveryId = DeliveryOptionEnum.DeliverSurroundingCities;
        }

        applyAmounts = this.state.SupplierDeliveryOptionPair.find( (a) => a.DeliveryOptionID == supplierDeliveryId );
        if (supplierDeliveryId == DeliveryOptionEnum.ShopDelivery) {
          if (  applyAmounts ) {
               //console.log('local delivery confirmed');
            //Do nothing
            // and keep the value of applyAmounts set above
          } else {
            //console.log('not local delivery, check country wide ');
            supplierDeliveryId = DeliveryOptionEnum.DeliveryAcrossCountry;
            applyAmounts = this.state.SupplierDeliveryOptionPair.find(
              (a) => a.DeliveryOptionID == supplierDeliveryId,
            );
            if(applyAmounts){
              //console.log('Country-wide shipping confirmed -0 ');
            }
    
            //applyAmounts = null;
          }
        }

        else if (supplierDeliveryId == DeliveryOptionEnum.DeliverSurroundingCities) {
          if (  applyAmounts 
                &&
                applyAmounts.SurroundingCitiesIDs.split(',').includes(this.state.selectedCity)
             ) {
               //console.log('found selected city within surrounding cities');
            //Do nothing
            // and keep the value of applyAmounts set above
          } else {
            //console.log('selected city NOT found within surrounding cities');
            supplierDeliveryId = DeliveryOptionEnum.DeliveryAcrossCountry;
            applyAmounts = this.state.SupplierDeliveryOptionPair.find(
              (a) => a.DeliveryOptionID == supplierDeliveryId,
            );
            if(applyAmounts){
              //console.log('Country-wide shipping confirmed -1 ');
            }
            else{
              applyAmounts = null;
            }
          }
        }
      } else {
        //console.log('ShopProvinceId != selectedProvince, may be Country-wide shipping');
        supplierDeliveryId = DeliveryOptionEnum.DeliveryAcrossCountry;
        applyAmounts = this.state.SupplierDeliveryOptionPair.find(
          (a) => a.DeliveryOptionID == supplierDeliveryId,
        );
        if(applyAmounts){
          //console.log('Country-wide shipping confirmed-2');
        }
      }
    } else {
        //console.log('province not matched, may be self pickup');

      supplierDeliveryId = DeliveryOptionEnum.SelfPickUp;
      applyAmounts = this.state.SupplierDeliveryOptionPair.find(
        (a) => a.DeliveryOptionID == supplierDeliveryId,
      );
      if(applyAmounts){
        //console.log('self pickup confirmed');
      }

    }

    return applyAmounts;
  };
  removeItem = (item) => {
    item.StatusID = 4;
    this.setState(
      {
        orderDetailObj: this.state.orderDetailObj,
      },
      () => {
        if (this.state.orderDetailObj && this.state.orderDetailObj.ItemList) {
          for (let item of this.state.orderDetailObj.ItemList) {
            this.lstQtyRef.push(item.QtyRef);
            this.lstQtyRefMob.push(item.QtyRefMob);
            item.QtyRef = '';
            item.QtyRefMob = '';
          }
        }
        FetchData(
          REQUEST_TYPE.POST,
          SERVICE_ENDPOINTS.Order_UpdateOrderDetail,
          this.state.orderDetailObj,
          this.successUpdateOrderDetail,
          null,
          { shippingOrder: {}, bRedirect: false },
        );
      },
    );
  };

  render() {
    let listProvinces = getStorageItem(LIST_PROVINCES);
    return (
      <main className="main">
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
                Order Detail
              </li>
            </ol>
          </div>
          {/* End .container */}
        </nav>
        {this.state.orderDetailObj != null ? (
          <div className="container cartorder_detail_min_height">
            <div className="row">
              <div className="col-lg-8">
                <div className="cart-table-container">
                  <table className="table table-cart">
                    <thead>
                      <tr className="non-for-mob-tab">
                        <th className="product-col">
                          <a
                            href={
                              '/search?ShopId=' +
                              this.state.orderDetailObj.ShopID
                            }
                          >
                            {this.state.orderDetailObj.ShopName}
                          </a>
                        </th>
                        <th className="price-col">Price</th>
                        <th className="qty-col">Qty</th>
                        <th>Subtotal</th>
                      </tr>
                    </thead>
                    <tbody>
                      {this.state.orderDetailObj.ItemList &&
                        this.state.orderDetailObj.ItemList.length > 0 ? (
                        this.state.orderDetailObj.ItemList.map((item, i) => (
                          <>
                            <tr key={i} className="product-row">
                              <td className="product-col">
                                <figure className="product-image-container">
                                  <a
                                    href=""
                                    onClick={(e) => {
                                      e.preventDefault();
                                      window.location.href =
                                        '/productdetail?ProductId=' +
                                        item.ProductID;
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
                                    />
                                  </a>
                                </figure>
                                <h2 className="product-title">
                                  <span className="product_name">
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
                                  {item.AttributeList.map((attr, j) => (
                                    <span
                                      key={j}
                                      className="Product_attributes"
                                    >
                                      {attr.AttributeID +
                                        ' : ' +
                                        attr.AttributeValue}
                                    </span>
                                  ))}
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
                          </>
                        ))
                      ) : (
                        <></>
                      )}
                      {this.state.orderDetailObj.ItemList &&
                        this.state.orderDetailObj.ItemList.length > 0 ? (
                        this.state.orderDetailObj.ItemList.map((item, i) => (
                          <>
                            <tr key={i} className="jus-mob-view">
                              <td>
                                <div className="pro-img-con-main">
                                  <div className="pro-ct-img">
                                    <a
                                      href=""
                                      onClick={(e) => {
                                        e.preventDefault();
                                        window.location.href =
                                          '/productdetail?ProductId=' +
                                          item.ProductID;
                                      }}>
                                      <img src={
                                        baseUrlImage +
                                        ImageEntityEnum.PRODUCT +
                                        '/' +
                                        item.ProductID +
                                        '/' +
                                        item.ProductDefaultImage
                                      }
                                        alt="product"></img>
                                    </a>

                                  </div>
                                  <div className="pro-ct-cont">
                                    <div className="crt-pro-tit">
                                      <a
                                        href=""
                                        onClick={(e) => {
                                          e.preventDefault();
                                          window.location.href =
                                            '/productdetail?ProductId=' +
                                            item.ProductID;
                                        }}
                                      >
                                        <h2>{item.ProductTitle}</h2>
                                      </a>
                                      <div className="sp-n-pol">
                                        {item.ExpectedDeliveryInfo ? (
                                          <span

                                            style={{ fontSize: '12px' }}
                                          >
                                            <p>{item.ExpectedDeliveryInfo}</p>
                                          </span>
                                        ) : (
                                          <></>
                                        )}
                                      </div>

                                      <a
                                        title="Remove product"

                                      >
                                        <span className="clx">X</span>
                                      </a>
                                    </div>
                                    <div className="crt-pro-pric">
                                      <h3>Price</h3>
                                      <p className="desc">Discount =
                                        {default_currency.symbol +
                                          item.CalculatedDiscountAmount.toFixed(2)}
                                      </p>
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
                                      <span> {default_currency.symbol +
                                      item.ItemTotalPriceWOTax.toFixed(2)}</span>
                                    </div>
                                  </div>
                                </div>
                              </td>
                            </tr>
                          </>
                        ))
                      ) : (
                        <></>
                      )}
                    </tbody>
                    <tfoot>
                      <tr>
                        <td colSpan={5} className="clearfix mob-fot-cart-pg">
                          <div className="float-left">
                            <a
                              href=""
                              onClick={(e) => {
                                e.preventDefault();
                                //setStorageItem(TEMP_ORDER_LIST_TYPE,101)
                                if (getStorageItem(IS_USER_LOGGEDIN)) {
                                  setTimeout(() => {
                                    window.location.href = '/MyAccount';
                                  }, 500);
                                } else {
                                  setTimeout(() => {
                                    window.location.href = '/OrderList';
                                  }, 500);
                                }
                              }}
                              className="btn btn-outline-secondary"
                            >
                              Go back to Orders
                            </a>
                          </div>
                          {/* End .float-left */}
                          <div className="float-left">
                            <a
                              href=""
                              onClick={(e) => {
                                e.preventDefault();
                                window.location.href = '/';
                              }}
                              className="btn btn-outline-secondary"
                            >
                              Continue Shopping
                            </a>
                          </div>
                          {/* End .float-left */}
                          <div className="float-right">
                            {/* <a href="#" className="btn btn-outline-secondary btn-clear-cart">Clear Shopping Cart</a> */}
                            <a
                              href=""
                              onClick={(e) => {
                                e.preventDefault();
                                this.updateOrderDetails({}, false);
                              }}
                              className="btn btn-outline-secondary btn-update-cart"
                            >
                              Update Order
                            </a>
                          </div>
                          {/* End .float-right */}
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
                        <button
                          className="btn btn-sm btn-primary"
                          type="submit"
                        >
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
              <div className="col-lg-4">
                <div className="cart-summary">
                  <h3>
                    Summary
                    {(() => {
                      switch (getStorageItem(TEMP_ORDER_LIST_TYPE)) {
                        case 101:
                          return (
                            <span
                              className="badge badge-warning"
                              style={{ float: 'right' }}
                            >
                              New (Unpaid)
                            </span>
                          );
                        case 102:
                          return (
                            <span
                              className="badge badge-info"
                              style={{ float: 'right' }}
                            >
                              In Process
                            </span>
                          );
                        case 103:
                          return (
                            <span
                              className="badge badge-success"
                              style={{ float: 'right' }}
                            >
                              Completed
                            </span>
                          );
                        case 104:
                          return (
                            <span
                              className="badge badge-danger"
                              style={{ float: 'right' }}
                            >
                              Disputed
                            </span>
                          );
                        default:
                          <></>;
                      }
                    })()}
                  </h3>
                  <h5>Order Number: {this.state.orderDetailObj.OrderNumber}</h5>
                  <h4>
                    <div
                      data-toggle="collapse"
                      href="#total-estimate-section1"
                      className="collapsed"
                      role="button"
                      aria-expanded="false"
                      aria-controls="total-estimate-section"
                      style={{paddingBottom:'20px', paddingTop:'20px'}}
                    >
                      Estimate Shipping and Tax
                    </div>
                  </h4>
                  <ul className="ks-cboxtags fw">
                    {this.state.showSelfPickup ? (
                      <li>
                        <input
                          type="checkbox"
                          id="checkboxOne1"
                          checked={
                            this.state.deliveryType == 'SelfPickup'
                              ? true
                              : false
                          }
                          onChange={(e) => {
                            this.setState(
                              {
                                selectedProvince: '',
                                selectedCity: '',
                                deliveryType: 'SelfPickup',
                                calculatedPaymentTotal: this.state
                                  .orderDetailObj.OrderTotal, //- this.state.orderDetailObj.DiscountTotal
                              },
                              () => { },
                            );
                          }}
                        />
                        <label htmlFor="checkboxOne1" className="npad" />
                        <span className="label span">Self Pickup</span>
                      </li>
                    ) : (
                      <></>
                    )}
                    {this.state.showShipping ? (
                      <li>
                        <input
                          type="checkbox"
                          id="checkboxOne2"
                          checked={
                            this.state.deliveryType == 'Shippment'
                              ? true
                              : false
                          }
                          onChange={(e) => {
                            this.state.deliveryType = 'Shippment';
                            this.state.selectedProvince = this.state.orderDetailObj.ShopProvinceId;
                            this.state.selectedCity = this.state.orderDetailObj.ShopCityId;
                            let applyAmounts = this.getApplyAmounts();
                            let shippingCharge =
                              this.state.deliveryType == 'SelfPickup'
                                ? 0
                                : applyAmounts &&
                                  applyAmounts.DeliveryCharges &&
                                  applyAmounts.DeliveryCharges > 0
                                  ? applyAmounts.DeliveryCharges
                                  : 0;
                            let calculatedPaymentTotal =
                              this.state.orderDetailObj.OrderTotal +
                              shippingCharge; //- this.state.orderDetailObj.DiscountTotal

                            this.setState(
                              {
                                deliveryType: this.state.deliveryType,
                                selectedProvince: this.state.selectedProvince,
                                selectedCity: this.state.selectedCity,
                                calculatedPaymentTotal: calculatedPaymentTotal,
                              },
                              () => { },
                            );
                          }}
                        />
                        <label htmlFor="checkboxOne2" className="npad" />
                        <span className="label span">Shipment</span>
                      </li>
                    ) : (
                      <></>
                    )}
                  </ul>
                  {this.state.deliveryType == 'Shippment' ? (
                    <div
                      className="collapse"
                      id="total-estimate-section"
                      style={{}}
                    >
                      Select Shipment Location
                      <form action="#">
                        <div className="form-group form-group-sm">
                          <label>Shipment Province</label>
                          <div className="select-custom">
                            <select
                              value={this.state.selectedProvince}
                              className="form-control form-control-sm"
                              onChange={(e) => {
                                this.setState(
                                  {
                                    selectedProvince: e.target.value,
                                    selectedCity: '',
                                  },
                                  () => {
                                    let applyAmounts = this.getApplyAmounts();
                                    let shippingCharge =
                                      this.state.deliveryType == 'SelfPickup'
                                        ? 0
                                        : applyAmounts &&
                                          applyAmounts.DeliveryCharges &&
                                          applyAmounts.DeliveryCharges > 0
                                          ? applyAmounts.DeliveryCharges
                                          : 0;
                                    let calculatedPaymentTotal =
                                      this.state.orderDetailObj.OrderTotal +
                                      shippingCharge; //- this.state.orderDetailObj.DiscountTotal
                                    this.setState(
                                      {
                                        calculatedPaymentTotal: calculatedPaymentTotal,
                                      },
                                      () => {
                                        this.FetchCityList();
                                      },
                                    );
                                  },
                                );
                              }}
                            >
                              <option value="">
                                -Please Select a Province-
                              </option>
                              {listProvinces.map((prov, i) => (
                                <option value={prov.LocationID} key={i}>
                                  {prov.LocationName}
                                </option>
                              ))}
                            </select>
                          </div>
                          {/* End .select-custom */}
                        </div>
                        {/* End .form-group */}
                        <div className="form-group form-group-sm">
                          <label>Shipment City</label>
                          <div className="select-custom">
                            <select
                              value={this.state.selectedCity}
                              className="form-control form-control-sm"
                              onChange={(e) => {
                                this.setState(
                                  { selectedCity: e.target.value },
                                  () => {
                                    let applyAmounts = this.getApplyAmounts();
                                    let shippingCharge =
                                      this.state.deliveryType == 'SelfPickup'
                                        ? 0
                                        : applyAmounts &&
                                          applyAmounts.DeliveryCharges &&
                                          applyAmounts.DeliveryCharges > 0
                                          ? applyAmounts.DeliveryCharges
                                          : 0;
                                    let calculatedPaymentTotal =
                                      this.state.orderDetailObj.OrderTotal +
                                      shippingCharge; //- this.state.orderDetailObj.DiscountTotal
                                    this.setState({
                                      calculatedPaymentTotal: calculatedPaymentTotal,
                                    });
                                  },
                                );
                              }}
                            >
                              <option value="">-Please Select a City-</option>
                              {this.state.listCities.map((city, i) => (
                                <option value={city.LocationID} key={i}>
                                  {city.LocationName}
                                </option>
                              ))}
                            </select>
                          </div>
                          {/* End .select-custom */}
                        </div>
                        {/* End .form-group */}
                      </form>
                    </div>
                  ) : (
                    <></>
                  )}
                  <table className="table table-totals">
                    {(() => {
                      let applyAmounts = this.getApplyAmounts();

                      if (applyAmounts) {
                        //let sumItemQty = this.state.orderDetailObj.ItemList.map(a=> a.Quantity).reduce((prev ,next)=> prev + next);
                        return (
                          <tbody>
                            <tr>
                              <td>Shipping Charges</td>
                              <td>
                                {this.state.deliveryType == 'SelfPickup'
                                  ? 'Shipping charges are not applicable'
                                  : applyAmounts.DeliveryCharges > 0
                                    ? default_currency.symbol +
                                    applyAmounts.DeliveryCharges.toFixed(2)
                                    : 'Free'}
                              </td>
                            </tr>
                            <tr>
                              <td>Order Amount</td>
                              <td>
                                {default_currency.symbol +
                                  this.state.orderDetailObj.OrderTotal.toFixed(
                                    2,
                                  )}
                                <span className="cart_notification">
                                  {' '}
                                  (Inclusive Tax)
                                </span>
                              </td>
                            </tr>
                            {this.state.orderDetailObj.OrderTotal >=
                              applyAmounts.MinOrderLimit ? (
                              <tr>
                                <td>Min Order Limit</td>
                                <td>
                                  {default_currency.symbol +
                                    applyAmounts.MinOrderLimit}
                                </td>
                              </tr>
                            ) : (
                              <tr>
                                <td>
                                  <span className="cart_notification">
                                    {' '}
                                    Note : This order doesn’t meet the minimum order limit i.e {' : '}
                                    
                                  </span>
                                </td>
                                <td>
                                    {default_currency.symbol + applyAmounts.MinOrderLimit}
                                </td>
                              </tr>
                            )}
                          </tbody>
                        );
                      } else {
                        return (this.state.deliveryType == 'Shippment' ? (                  
                          <tbody>
                            <tr>
                              <td style={{color:'red'}}>
                                The shop doesn't deliver in your selected city
                              </td>
                              <td></td>
                            </tr>
                          </tbody>
                        ) : (
                          <></>
                        ));
                      }
                    })()}
                    <tfoot>
                      <tr>
                        <td>Discount amount</td>
                        <td>
                          {default_currency.symbol +
                            this.state.orderDetailObj.DiscountTotal.toFixed(2)}
                        </td>
                      </tr>
                      <tr>
                        <td>Tax amount</td>
                        <td>
                          {default_currency.symbol +
                            this.state.orderDetailObj.TaxTotal.toFixed(2)}
                        </td>
                      </tr>
                      <tr>
                        <td>Payment Total</td>
                        <td>
                          {default_currency.symbol +
                            this.state.calculatedPaymentTotal.toFixed(2)}
                        </td>
                      </tr>
                    </tfoot>
                  </table>
                  {this.state.orderDetailObj.ItemList &&
                    this.state.orderDetailObj.ItemList.length > 0 ? (
                    <div
                      className={
                        this.state.orderDetailObj.ItemList
                          ? this.state.orderDetailObj.ItemList[0]
                            .ShopStatusId != 2
                            ? 'disabled checkout-methods'
                            : 'checkout-methods'
                          : 'checkout-methods'
                      }
                      disabled={
                        this.state.orderDetailObj.ItemList
                          ? this.state.orderDetailObj.ItemList[0]
                            .ShopStatusId != 2
                            ? 'disabled'
                            : ''
                          : ''
                      }
                    >
                      <a
                        href=""
                        onClick={(e) => {
                          e.preventDefault();
                          let applyAmounts = this.getApplyAmounts();
                          if (applyAmounts) {
                            if (
                              this.state.orderDetailObj.OrderTotal >=
                              applyAmounts.MinOrderLimit
                            ) {
                              this.redirectToShipping(e);
                            }
                          }
                        }}
                        className="btn btn-block btn-outline-secondary"
                      >
                        Go to Checkout
                      </a>
                    </div>
                  ) : (
                    <></>
                  )}
                </div>
                {/* End .cart-summary */}
              </div>
              {/* End .col-lg-4 */}
            </div>
            {/* End .row */}
          </div>
        ) : (
          <></>
        )}
        <Footer />
      </main>
    );
  }
}

export default OrderDetail;
