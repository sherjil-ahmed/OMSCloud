import React from 'react';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import Shipping from './cShipping';
import Payment from './cPayment';
import Wizard from '../../customControls/Wizard/Wizard';
import { Helmet } from 'react-helmet';
import { FetchData } from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SUPPLIER_ID,
  PRODUCT_ID,
  PROFILE_ID,
  DIRECT_PRODUCTS,
  IS_USER_LOGGEDIN,
  INPROC_SHIPPING_ORDER,
  SIZE
} from '../../../utils/constants';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import { DeliveryOptionEnum } from '../../../utils/enums';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR } from '../../../utils/constants';

const enWIZARD_KEYS = {
  Shipping: 'Checkout',
  Payment: 'Payment',
};

class ShippingAndPayment extends React.Component {
  constructor(props) {
    super(props);
    this.steps = null;
    this.lastMaxStep = enWIZARD_KEYS.Shipping;
    this.state = {
      shippingDetailObj: getStorageItem(INPROC_SHIPPING_ORDER),
      activeStep: '',
      completedsteps: [],

      //adding to parent state for validation
      // FirstName : "",
      // LastName : "",
      // Password : "",
      // Email : "",
      // AccSelection : ""
    };
  }

  setValues = (key, value) => {
    this.setState({
      [key]: value,
    });
  };

  setValuesMany = (obj, callbackFunc) => {
    this.setState(obj, () => {
      if (callbackFunc) {
        callbackFunc();
      }
    });
  };

  setActiveStep = (_activeStep) => {
    this.setMaxStep(_activeStep);
    this.setState({
      activeStep: _activeStep,
    });
  };

  setMaxStep = (_activeStep) => {
    //check if active step's rank is greater than lastMaxStep
    let _rank = this.steps.find((a) => a.name == _activeStep).rank;
    let _lastMaxStepRank = this.steps.find((a) => a.name == this.lastMaxStep)
      .rank;
    if (_rank > _lastMaxStepRank) {
      this.lastMaxStep = _activeStep;
    }
  };

  setActiveStepWizard = (_activeStep) => {
    let _completedsteps = this.state.completedsteps.find(
      (a) => a == _activeStep,
    );

    if (_completedsteps || this.lastMaxStep == _activeStep) {
      this.setState({
        activeStep: _activeStep,
      });
    }
  };

  /////////////////////VALIDATE BEGIN//////////////////////////////

  ValidateShipping = () => {
    let validEmailRegex = RegExp(
      /^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i,
    );

    if (!getStorageItem(IS_USER_LOGGEDIN)) {
      //console.log('I am here 1')
      if (!validEmailRegex.test(this.state.Email) == false) {
        if (this.state.AccSelection) {
          //console.log('I am here 2')
          if (this.state.AccSelection == 'Anon') {
            //console.log('I am here 3')
            //console.log('shipping id', this.state.shippingAddressId)
            if (!this.state.shippingAddressId) {
                    izitoast.destroy();
      izitoast.show({

                title: '',
                icon: APP_ICONS.WARNING,
                  message: 'Please select either existing address or add a new address.',
                //position: APP_TOAST_POSITION.BOTTOM_CENTER,
                target: '.testtarget',
                color: COLOR.RED,
                messageSize: SIZE.FONT_SIZE
              });
            }
            return this.state.shippingAddressId && true;
          } else {
            //console.log('I am here 4')
            if (
              this.state.FirstName &&
              this.state.LastName &&
              this.state.Password &&
              this.state.ConfirmPassword
            ) {
              //console.log('I am here 5')
              if (this.state.Password === this.state.ConfirmPassword) {
                if (!this.state.shippingAddressId) {
                        izitoast.destroy();
      izitoast.show({

                    title: '',
                    icon: APP_ICONS.WARNING,
                    message: 'Please select either existing address or add a new address.',
                    //position: APP_TOAST_POSITION.BOTTOM_CENTER,
                    target: '.testtarget',
                    color: COLOR.RED,
                    messageSize: SIZE.FONT_SIZE
                  });
                }
                return this.state.shippingAddressId && true;
              }

              else {
                //console.log('I am here 7')
                      izitoast.destroy();
      izitoast.show({

                  title: '',
                  icon: APP_ICONS.WARNING,
                  message: 'Password doesnot match',
                  //position: APP_TOAST_POSITION.BOTTOM_CENTER,
                  target: '.testtarget',
                  color: COLOR.RED,
                  messageSize: SIZE.FONT_SIZE
                });
                return false;
              }

            } else {
              //console.log('I am here 8')
                    izitoast.destroy();
      izitoast.show({

                title: '',
                icon: APP_ICONS.WARNING,
                message: 'All input fields are required for new account creation.',
                //position: APP_TOAST_POSITION.BOTTOM_CENTER,
                target: '.testtarget',
                color: COLOR.RED,
                messageSize: SIZE.FONT_SIZE
              });
              return false;
            }
          }
        } else {
          //console.log('I am here 9')
                izitoast.destroy();
      izitoast.show({

            title: '',
            icon: APP_ICONS.WARNING,
            message: 'Please select either ‘Creat Account’ or ‘Continue as guest buyer’.',
            //position: APP_TOAST_POSITION.BOTTOM_CENTER,
            target: '.testtarget',
            color: COLOR.RED,
            messageSize: SIZE.FONT_SIZE
          });
          return false;
        }
      } else {
        //console.log('I am here 10')
              izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.WARNING,
          message: 'Valid email address is required',
          //position: APP_TOAST_POSITION.BOTTOM_CENTER,
          target: '.testtarget',
          color: COLOR.RED,
          messageSize: SIZE.FONT_SIZE
        });
        return false;
      }
    } else {
      //console.log('I am here 11')
      return this.state.shippingAddressId;
    }
  };

  ValidatePayment = () => {
    return true;
  };

  ///////////////////////VALIDATE END///////////////////////////////
  /////////////////////PREV BEGIN//////////////////////////////////

  PaymentPrev = () => {
    this.setActiveStep(enWIZARD_KEYS.Shipping);
  };
  //////////////////////PREV END/////////////////////////////////
  /////////////////////NEXT BEGIN////////////////////////////////

  ShippingNext = () => {
    if (this.ValidateShipping()) {
      //console.log('in shipping next')
      this.setActiveStep(enWIZARD_KEYS.Payment);
      let _completedsteps = this.state.completedsteps.filter(
        (a) => !(a == enWIZARD_KEYS.Shipping),
      );
      _completedsteps.push(enWIZARD_KEYS.Shipping);
      this.setState({
        completedsteps: _completedsteps,
      });
    }
  };

  PaymentNext = () => {
    if (this.ValidatePayment()) {
      if (
        !(
          this.state.Supplier.SupplierID && this.state.Supplier.SupplierID != ''
        )
      ) {
        FetchData(
          REQUEST_TYPE.PUT,
          SERVICE_ENDPOINTS.Supplier_Put,
          this.state.Supplier,
          this.successSupplierInsert,
        );
      } else {
        //concurrency
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Supplier_GetById + this.state.Supplier.SupplierID,
          null,
          this.successGetSupplier,
        );
      }
    } else {
    }
  };

  renderWizardPrevNext = (activeStep) => {
    switch (activeStep) {
      case enWIZARD_KEYS.Shipping:
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.ShippingNext}
            >
              Save & Continue
            </button>

            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={(e) => {
                e.preventDefault();
                window.location.href = '/OrderDetail';
              }}
            >
              Go back to Order Details
            </button>
          </div>
        );
      case enWIZARD_KEYS.Payment:
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-outline-dark custom-btn prebtn"
              onClick={this.PaymentPrev}
            >
              Previous
            </button>
            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.PaymentNext}
            >
              Save & Continue
            </button>
          </div>
        );
      default:
        return <div></div>;
    }
  };

  componentDidMount() {
    let _activeStep = '';
    let shippingAddressId = '';
    if (
      getStorageItem(IS_USER_LOGGEDIN) &&
      this.state.shippingDetailObj.applyAmounts.DeliveryOptionID ==
      DeliveryOptionEnum.SelfPickUp
    ) {
      _activeStep = enWIZARD_KEYS.Payment;
    } else {
      if (
        this.state.shippingDetailObj.applyAmounts.DeliveryOptionID ==
        DeliveryOptionEnum.SelfPickUp
      ) {
        shippingAddressId = true;
      }
      _activeStep = enWIZARD_KEYS.Shipping;
    }
    this.setState(
      {
        activeStep: _activeStep,
        shippingAddressId: shippingAddressId,
      },
      () => {
        this.setMaxStep(_activeStep);
      },
    );
  }

  render() {
    this.steps = [
      {
        title: 'Checkout Details',
        rank: 1,
        name: enWIZARD_KEYS.Shipping,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <Shipping
            parentState={this.state}
            setValues={this.setValues}
            setValuesMany={this.setValuesMany}
          />
        ),
      },
      {
        title: 'Payment',
        rank: 2,
        name: enWIZARD_KEYS.Payment,
        NextPrev: () => {
          return <></>;
        },
        component: (
          <Payment
            parentState={this.state}
            setValues={this.setValues}
            setValuesMany={this.setValuesMany}
          />
        ),
      },
    ];

    if (
      getStorageItem(IS_USER_LOGGEDIN) &&
      this.state.shippingDetailObj.applyAmounts.DeliveryOptionID ==
      DeliveryOptionEnum.SelfPickUp
    ) {
      this.lastMaxStep = enWIZARD_KEYS.Payment;
      this.steps = [
        {
          title: 'Payment',
          rank: 1,
          name: enWIZARD_KEYS.Payment,
          NextPrev: () => {
            return <></>;
          },
          component: (
            <Payment
              parentState={this.state}
              setValues={this.setValues}
              setValuesMany={this.setValuesMany}
            />
          ),
        },
      ];
    }

    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Shipping & Payments</title>
        </Helmet>
        <Header />
        <main className="main" style={{ padding: '25px' }}>
          <div className="container">
            {/* <Multistep showNavigation={true} steps={steps}/> */}
            <Wizard
              steps={this.steps}
              setActiveStep={this.setActiveStepWizard}
              activeStep={this.state.activeStep}
              completedsteps={this.state.completedsteps}
            />
            {/* <div className="row mt-8">
                        {this.renderWizardFooter()}
                    </div>   */}
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}

export default ShippingAndPayment;
