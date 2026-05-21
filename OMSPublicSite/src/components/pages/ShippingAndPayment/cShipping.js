import React from 'react';
import { FetchData } from '../../../utils/serviceHelper';
import {
  INPROC_SHIPPING_ORDER,
  IS_USER_LOGGEDIN,
  PROFILE_ID,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SIZE
} from '../../../utils/constants';
import { DeliveryOptionEnum, LocationLevelEnum } from '../../../utils/enums';
import AddressManagement from '../AccountProfile/cAddressManagement';
import { getStorageItem } from '../../../utils/storageHelper';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR } from '../../../utils/constants';

class Shipping extends React.Component {
  constructor(props) {
    super(props);
    this.child = React.createRef();
    this.state = {
      shippingDetailObj: getStorageItem(INPROC_SHIPPING_ORDER),
      proceedToPayment: false,
      useAddress: 'existing',
    };
  }

  componentDidMount() {}

  componentDidUpdate() {}

  handleAddressSelection = (item) => {
    if (
      this.state.shippingDetailObj.selectedCity == item.CityID &&
      this.state.shippingDetailObj.selectedProvince == item.ProvinceID
    ) {
      this.props.setValues('shippingAddressId', item.AddressID);
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message:
          "This shipment address doesn’t match with the shipment province/city selected earlier on the “order detail” page.",
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
      this.props.setValues('shippingAddressId', null);
    }
  };
  render() {
    return (
      <div className="body">
        <ul className="checkout-steps">
          <li>
            {getStorageItem(IS_USER_LOGGEDIN) ? (
              <></>
            ) : (
              <form action="#">
              <label style={{color:'GREY'}}> Either <a href="/LoginSignup" style={{color:'Blue', textDecoration: 'underline'}}>Create account</a> or <a href="/LoginSignup" style={{color:'Blue', textDecoration: 'underline'}}>Login with your registered email</a> Alternativly,</label>
              <div className="form-group">
              
              </div>
              <div className="form-group required-field">
                  <ul className="ks-cboxtags fw">
                     <li></li>
                    <li>
                      <input
                        type="checkbox"
                        id="checkboxOne2"
                        checked={
                          this.props.parentState.AccSelection == 'Anon'
                            ? true
                            : false
                        }
                        onClick={(e) => {
                          this.props.setValuesMany({ AccSelection: 'Anon' });
                        }}
                      />
                      <label htmlFor="checkboxOne2" className="npad" />
                      <span className="label span">Continue as guest buyer</span>
                    </li>
                  </ul>
                </div>
                <div className="form-group required-field">
                  <label>Email address is required to continue as guest buyer</label>
                  <div className="form-control-tooltip">
                    <input
                      type="email"
                      maxLength="100"
                      className="form-control required-field"
                      required
                      placeholder='email address'
                      onChange={(e) => {
                        this.props.setValuesMany({ Email: e.target.value });
                      }}
                      value={this.props.parentState.Email}
                    />
                    <span
                      className="input-tooltip"
                      data-toggle="tooltip"
                      title
                      data-placement="right"
                      data-original-title="We'll send your order confirmation here."
                    >
                      <i className="icon-question-circle" />
                    </span>
                  </div>
                  <p>you will receive order confirmation email and order status notification at your email.</p>  

                  {/* End .form-control-tooltip */}
                </div>
                {/* End .form-group */}
                <label class="sak_collapse" style={{ cursor: 'pointer' , display:'block'}}for="_1">more info...</label>
                <input id="_1" style={{display: 'none'}}type="checkbox" /> 
                <div>
                <p>Once you close this browser tab, we do not remember your identity for your security. 
You will be registered as guest buyer and can keep track of your orders with your email. 
Without verifying your email, you will not be able to track your orders later on.</p>
                  <p>To keep track all of your orders (No need to signup), just sign-in with the same email.</p>
                  </div>
                {/* End .form-group */}
                {this.props.parentState.AccSelection == 'Account' ? (
                  <>
                    <div className="form-group required-field">
                      <label>First Name </label>
                      <input
                        type="text"
                        maxLength="200"
                        className="form-control"
                        required
                        onChange={(e) => {
                          this.props.setValuesMany({
                            FirstName: e.target.value,
                          });
                        }}
                        value={this.props.parentState.FirstName}
                      />
                    </div>
                    {/* End .form-group */}
                    <div className="form-group required-field">
                      <label>Last Name </label>
                      <input
                        type="text"
                        maxLength="200"
                        className="form-control"
                        required
                        onChange={(e) => {
                          this.props.setValuesMany({
                            LastName: e.target.value,
                          });
                        }}
                        value={this.props.parentState.LastName}
                      />
                    </div>
                    {/* End .form-group */}
                    <div className="form-group required-field">
                      <label>Password </label>
                      <input
                        type="password"
                        maxLength="25"
                        className="form-control"
                        required
                        onChange={(e) => {
                          this.props.setValuesMany({
                            Password: e.target.value,
                          });
                        }}
                        value={this.props.parentState.Password}
                      />
                    </div>

                    <div className="form-group required-field">
                      <label>Confirm Password </label>
                      <input
                        type="password"
                        maxLength="25"
                        className="form-control"
                        required
                        onChange={(e) => {
                          this.props.setValuesMany({
                            ConfirmPassword: e.target.value,
                          });
                        }}
                        value={this.props.parentState.ConfirmPassword}
                      />
                    </div>
                    {/* End .form-group */}
                  </>
                ) : (
                  <></>
                )}
              </form>
            )}
            {this.state.shippingDetailObj.applyAmounts.DeliveryOptionID ==
            DeliveryOptionEnum.SelfPickUp ? (
              <></>
            ) : (
              <>
                <div className="form-group required-field">
                  <h2>Choose a delivery address</h2>
                  <ul className="ks-cboxtags fw">
                    <li>
                      <input
                        onClick={() => {
                          this.child.current.initComponent();
                          this.setState({ useAddress: 'existing' });
                        }}
                        type="checkbox"
                        id="existing"
                        checked={
                          this.state.useAddress == 'existing' ? true : false
                        }
                      />
                      <label htmlFor="existing" className="npad" />
                      <span className="label span">
                        Continue with existing address
                      </span>
                    </li>
                    </ul>
                    <ul className="ks-cboxtags fw">
                    <li>
                      <input
                        onClick={() => {
                          this.setState({ useAddress: 'new' });
                        }}
                        type="checkbox"
                        id="new"
                        checked={this.state.useAddress == 'new' ? true : false}
                      />
                      <label htmlFor="new" className="npad" />
                      <span className="label span">Add new address</span>
                    </li>
                  </ul>
                </div>
                <AddressManagement
                  AddressID={this.props.parentState.shippingAddressId}
                  handleAddressSelection={this.handleAddressSelection}
                  ShowAddressHeader={false}
                  ShowSelection={true}
                  ShowExisting={
                    this.state.useAddress == 'existing' ? true : false
                  }
                  ShowNew={this.state.useAddress == 'new' ? true : false}
                  setShowNew={(val) => {
                    if (val) {
                      this.setState({
                        useAddress: 'new',
                      });
                    } else {
                      this.setState({
                        useAddress: 'existing',
                      });
                    }
                  }}
                  ref={this.child}

                />
              </>
            )}
          </li>
        </ul>
      </div>
    );
  }
}

export default Shipping;
