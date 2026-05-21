import React from 'react';
import {
  IS_USER_LOGGEDIN,
  INPROC_ORDERID,
  INPROC_SHIPPING_ORDER,
  PROFILE_ID,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  TEMP_ORDER_LIST_TYPE,
  STATUS_CODE,
  SIZE
} from '../../../utils/constants';
import { default_currency } from '../../../utils/globalConstants';
import { FetchData } from '../../../utils/serviceHelper';
import { getStorageItem, setStorageItem } from '../../../utils/storageHelper';
import {
  DeliveryOptionEnum,
  ImageEntityEnum,
  PaymentMethod,
  AddressTypeID,
} from '../../../utils/enums';
import { loadStripe } from '@stripe/stripe-js';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR } from '../../../utils/constants';

class Payment extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      shippingDetailObj: getStorageItem(INPROC_SHIPPING_ORDER),
      selectedPaymentMethod: '',
      supplierDetails: {},
      AddressDetails: {}
    };
  }

  successGetPayOrder = (data, params) => {
    if (data.StatusCode == 0) {
      if (params.PaymentMethod == PaymentMethod.STRIPE) {
        const stripePromise = loadStripe(data.APIKey);
        stripePromise.then((stripeResponse) => {
          stripeResponse.redirectToCheckout({ sessionId: data.SessionID });
        });
      } else if (params.PaymentMethod == PaymentMethod.PAYPAL) {
        window.location.href = data.SessionID;
      } else if (params.PaymentMethod == PaymentMethod.CASH) {
        setStorageItem(TEMP_ORDER_LIST_TYPE, 102)
        setTimeout(() => {
          window.location.href = '/PaidOrderDetail?source=Account';
        }, 2000);
      }
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: data.StatusMessage,
        //position: APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };

  ProceedToPayment = () => {
    new Promise((resolve, reject) => {
      if (getStorageItem(IS_USER_LOGGEDIN)) {
        resolve();
      } else {
        this.RegisterGuestUser(resolve, reject);
      }
    })
      .then(() => {
        let reqData = {
          OrderID: this.state.shippingDetailObj.orderDetailObj.OrderID,
          ShopID: this.state.shippingDetailObj.orderDetailObj.ShopID,
          PaymentMethod: this.state.selectedPaymentMethod,
          DeliveryOption: this.state.shippingDetailObj.applyAmounts
            .DeliveryOptionID,
          DeliveryCharges: this.state.shippingDetailObj.applyAmounts
            .DeliveryCharges,
          PaymentAmount: this.state.shippingDetailObj.calculatedPaymentTotal,
          MinOrderLimit: this.state.shippingDetailObj.applyAmounts
            .MinOrderLimit,
          DeliveryAddressID: this.props.parentState.shippingAddressId,
          SelectedProvinceID: this.state.shippingDetailObj.selectedProvince,
          SelectedCityID: this.state.shippingDetailObj.selectedCity,
          RequestedByProfileId: getStorageItem(PROFILE_ID),
        };

        setStorageItem(INPROC_ORDERID, reqData.OrderID);

        FetchData(
          REQUEST_TYPE.POST,
          SERVICE_ENDPOINTS.PaymentGateway_PayOrder,
          reqData,
          this.successGetPayOrder,
          null,
          { PaymentMethod: reqData.PaymentMethod },
        );
      })
      .catch(() => { });
  };

  successAccountRegister = (res, params) => {
    if (
      res.StatusCode == STATUS_CODE.ZERO ||
      res.StatusCode == STATUS_CODE.FIVE ||
      res.StatusCode == STATUS_CODE.SIX
    ) {
      //setStorageItem(PROFILE_ID, res.ValidProfileId);
      
      params.resolve();
    } else {
      this.props.setValues('GUESTUSERERRORMSG', res.StatusMessage);
      izitoast.destroy();
      izitoast.show({
        title: '',
        icon: APP_ICONS.WARNING,
        message: res.StatusMessage,
        //position: APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
      params.reject();
    }
  };

  RegisterGuestUser = (resolve, reject) => {
    let reqData = {
      UserName: this.props.parentState.Email,
      Email: this.props.parentState.Email,
      RequestedByProfileId: getStorageItem(PROFILE_ID),
    };

    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Account_RegisterGuest,
      reqData,
      this.successAccountRegister,
      null,
      { resolve: resolve, reject: reject },
    );
  };

  componentDidMount() {
    this.props.setValues('GUESTUSERERRORMSG', '');
    window.scrollTo(0, 0);
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Supplier_GetSupplierPublic +
      this.props.parentState.shippingDetailObj.applyAmounts.SupplierID + '/' + getStorageItem(PROFILE_ID),
      null,
      this.gotSupplierDetails,
    );
  }

  gotUserData = (res) => {
    this.setState({
      supplierDetails: res,
    });
  };
  gotSupplierDetails = (res) => {
    console.log("Suplier Detail", res);
    this.setState({
      AddressDetails: res,
    });
    if (res != null) {
      console.log(res)
      if (res.IsBusinessAddressVisible) {
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Address_GetAddressListByProfileid +
          '?Id=' +
          res.ShopOwnerProfileId +
          '&AddressTypeID=' +
          AddressTypeID.ShopAddressType,
          null,
          this.gotUserData,
        );
      }
    };
  }

  render() {
    return (
      <div className="body">
        <ul className="checkout-steps">
          <li>
            {this.state.supplierDetails.length > 0 && this.props.parentState.shippingDetailObj.deliveryType === 'SelfPickup' ? <div> <h4>Shop Address for Self Pickup: {this.state.supplierDetails[0].PlotNumber + ", " + this.state.supplierDetails[0].StreetNumber + " " + this.state.supplierDetails[0].PostalCode + " " + this.state.AddressDetails.City + ", " + this.state.AddressDetails.Province} </h4>
              <p style={{ color: 'red' }}>Please note this address for self pickup or find shop address under shop detail page </p> </div> : null}
            <div className="form-group required-field">
              <h2>Choose Payment Method</h2>
              <ul className="ks-cboxtags fw payment_methods_list">
                {this.state.shippingDetailObj.orderDetailObj.ShopAllowCashPayment ?
                  <li>
                    <input
                      type="checkbox"
                      id="checkboxOne8"
                      checked={
                        this.state.selectedPaymentMethod == PaymentMethod.CASH
                          ? true
                          : false
                      }
                      onClick={() => {
                        this.setState({
                          selectedPaymentMethod: PaymentMethod.CASH,
                        });
                      }}
                    />
                    <label htmlFor="checkboxOne8" className="npad" />
                    <span className="label span">Cash Payment</span>
                  </li>
                  : <li></li>}

                <li>
                  <input
                    type="checkbox"
                    id="checkboxOne9"
                    checked={
                      this.state.selectedPaymentMethod == PaymentMethod.STRIPE
                        ? true
                        : false
                    }
                    onClick={() => {
                      this.setState({
                        selectedPaymentMethod: PaymentMethod.STRIPE,
                      });
                    }}
                  />
                  <label htmlFor="checkboxOne9" className="npad" />
                  <span className="label span">
                    Credit Card (Master, Visa, Visa Debit)
                  </span>
                </li>
                <li>
                  <input
                    type="checkbox"
                    id="checkboxOne10"
                    checked={
                      this.state.selectedPaymentMethod == PaymentMethod.PAYPAL
                        ? true
                        : false
                    }
                    onClick={() => {
                      this.setState({
                        selectedPaymentMethod: PaymentMethod.PAYPAL,
                      });
                    }}
                  />
                  <label htmlFor="checkboxOne10" className="npad" />
                  <span className="label span">Paypal</span>
                </li>
              </ul>
              <p className="conclude_price">
                OrderAmount{' '}
                <span className="order_amount">
                  {default_currency.symbol +
                    this.state.shippingDetailObj.orderDetailObj.OrderTotal.toFixed(
                      2,
                    )}
                </span>
                &nbsp;&nbsp;+ Delivery/Shipping Charges{' '}
                <span className="delivery_amount">
                  {default_currency.symbol +
                    this.state.shippingDetailObj.applyAmounts.DeliveryCharges.toFixed(
                      2,
                    )}
                </span>
                {/* &nbsp;&nbsp;- Discount{' '}
                <span className="delivery_amount">
                  {default_currency.symbol +
                    this.state.shippingDetailObj.orderDetailObj.DiscountTotal.toFixed(
                      2,
                    )}
                </span> */}
                &nbsp;&nbsp; (Payment Total{' '}
                <span className="delivery_amount">
                  {default_currency.symbol +
                    this.state.shippingDetailObj.calculatedPaymentTotal.toFixed(
                      2,
                    )}
                </span>
                )
              </p>
              <p style={{color:'Red'}} className='md-col-4'>
              
              {this.props.parentState.GUESTUSERERRORMSG}
              </p>
              <a
                href=""
                onClick={(e) => {
                  e.preventDefault();
                  this.ProceedToPayment();
                }}
                className="btn btn-block btn-outline-secondary"
              >
                Place Order
              </a>
              
              <button
              type="button"
              className="btn btn-block btn-outline-secondary"
              onClick={(e) => {
                e.preventDefault();
                window.location.href = '/OrderDetail';
              }}
            >
              Go back to Order Details
            </button>

              
            </div>
          </li>
          <li></li>
        </ul>
      </div>
    );
  }
}

export default Payment;
