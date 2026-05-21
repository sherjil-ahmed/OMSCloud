import React from 'react';
import { FetchData } from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
 SIZE
} from '../../../utils/constants';
import { DBResponseTimeUnitEnum } from '../../../utils/enums';
import { default_currency } from '../../../utils/globalConstants';
import izitoast from 'izitoast';
import 'izitoast/dist/css/iziToast.css';

const enPARENT = {
  ProductPricing: 'ProductPricing',
  TaxTypeID: 'TaxTypeID',
  BasePrice: 'BasePrice',
  SellingPrice: 'SellingPrice',
};

class ProductPricing extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      listTaxType: [],
    };
  }
  componentDidMount() {
    let _state = this.props.parentState;
    window.scrollTo(0, 0);
    if (!(this.state.listTaxType && this.state.listTaxType.length > 0)) {
      this.fetchTaxTypeList();
    }
  }

  successGetTaxTypeList = (res) => {
    if (res) {
      this.setState({
        listTaxType: res,
      });
    }
  };

  fetchTaxTypeList = () => {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.TaxType_GetList,
      null,
      this.successGetTaxTypeList,
    );
  };

  formatInput = (e) => {
    let checkIfNum;
    if (e.key !== undefined) {
      checkIfNum = e.key === "e" || e.key === "." || e.key === "+" || e.key === "-";
      console.log('checkifNum if', checkIfNum)
    }
    else if (e.keyCode !== undefined) {
      checkIfNum = e.keyCode === 69 || e.keyCode === 190 || e.keyCode === 187 || e.keyCode === 189;
      console.log('checkifNum if', checkIfNum)
    }
    return checkIfNum && e.preventDefault();
  }

  handleChange = (e) => {
    let _state = this.props.parentState;
     if (parseInt(e.target.value) > 100000 && e.target.name === 'SellingPrice') {
      e.target.value = 0;
      izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.DANGER,
        message: 'selling price value cannot be greater than 100,000',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED
      });
    }
    else if (e.target.name === 'OrderResponseTime') {
      if (e.target.value > 200) {
        e.target.value = 0;
        izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.DANGER,
          message: 'Delivery duration must be in range of 0-200',
          //position : APP_TOAST_POSITION.BOTTOM_CENTER,
          target: '.testtarget',
          color: COLOR.RED
        });
      }
    }
    if (e.target.name == 'SellingPrice' || e.target.name == 'DiscountValue') {
      console.log('im here tooo')
      if (!_state.ProductPricing.IsDiscountPercentage) {
        //discount amount
        if (e.target.name == 'SellingPrice') {
          if (
            parseInt(e.target.value) < 0
          ) {
            e.target.value = 0;
            izitoast.destroy();
      izitoast.show({

                title: '',
                icon : APP_ICONS.DANGER,
                message: 'selling price value cannot be less than zero',
                //position : APP_TOAST_POSITION.BOTTOM_CENTER,
                target : '.testtarget',
                color : COLOR.RED,
                messageSize: SIZE.FONT_SIZE
            });
          }
          
          else if (
            parseInt(_state.ProductPricing.DiscountValue) >
            parseInt(e.target.value)
          ) {
            _state.ProductPricing.DiscountValue = 0;
            izitoast.destroy();
      izitoast.show({

              title: '',
              icon: APP_ICONS.DANGER,
              message: 'Discount value cannot be more than the actual price',
              //position : APP_TOAST_POSITION.BOTTOM_CENTER,
              target: '.testtarget',
              color: COLOR.RED,
              messageSize: SIZE.FONT_SIZE
            });
          }
        } else {
          if (
            parseInt(e.target.value) >
            parseInt(_state.ProductPricing.SellingPrice)
          ) {
            e.target.value = 0;
            izitoast.destroy();
      izitoast.show({

              title: '',
              icon: APP_ICONS.DANGER,
              message: 'Discount value cannot be more than the actual price',
              //position : APP_TOAST_POSITION.BOTTOM_CENTER,
              target: '.testtarget',
              color: COLOR.RED,
              messageSize: SIZE.FONT_SIZE
            });
          } else if (parseInt(e.target.value) < 0) {
            e.target.value = 0;
            izitoast.destroy();
      izitoast.show({

              title: '',
              icon: APP_ICONS.DANGER,
              message: 'Discount value cannot be less than zero',
              //position : APP_TOAST_POSITION.BOTTOM_CENTER,
              target: '.testtarget',
              color: COLOR.RED,
              messageSize: SIZE.FONT_SIZE
            });
          }
        }
      } else {
        // discount percentage
        if (e.target.name == 'SellingPrice') {
          if (
            parseInt(_state.ProductPricing.DiscountValue) > 100 ||
            parseInt(e.target.value) < 0
          ) {
            _state.ProductPricing.DiscountValue = 0;
            izitoast.destroy();
      izitoast.show({

              title: '',
              icon: APP_ICONS.DANGER,
              message: 'Discount value should be in between 0 to 100%',
              //position : APP_TOAST_POSITION.BOTTOM_CENTER,
              target: '.testtarget',
              color: COLOR.RED,
              messageSize: SIZE.FONT_SIZE
            });
          }
        } else {
          if (parseInt(e.target.value) > 100 || parseInt(e.target.value) < 0) {
            e.target.value = 0;
            izitoast.destroy();
      izitoast.show({

              title: '',
              icon: APP_ICONS.DANGER,
              message: 'Discount value should be in between 0 to 100%',
              //position : APP_TOAST_POSITION.BOTTOM_CENTER,
              target: '.testtarget',
              color: COLOR.RED,
              messageSize: SIZE.FONT_SIZE
            });
          }
        }
      }
    }
    _state.ProductPricing[e.target.name] = e.target.value;
    this.props.setValues(enPARENT.ProductPricing, _state.ProductPricing, () => {
      if (
        _state.ProductPricing[enPARENT.TaxTypeID] &&
        _state.ProductPricing[enPARENT.TaxTypeID] !== '' &&
        _state.ProductPricing[enPARENT.SellingPrice] &&
        _state.ProductPricing[enPARENT.SellingPrice] !== ''
      ) {
        _state.ProductPricing[enPARENT.BasePrice] =
          parseFloat(_state.ProductPricing[enPARENT.SellingPrice]) -
          parseFloat(_state.ProductPricing['SellingPrice'] * (10 / 100));
        this.props.setValues(enPARENT.ProductPricing, _state.ProductPricing);
      }
    });
  };

  handleChangeRadio = (e) => {
    let _state = this.props.parentState;
    if (e.target.value == '1') {
      //discount amount
      if (
        parseInt(_state.ProductPricing.DiscountValue) >
        parseInt(_state.ProductPricing.SellingPrice)
      ) {
        _state.ProductPricing.DiscountValue = 0;
        izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.DANGER,
          message: 'Discount value cannot be more than the actual price',
          //position : APP_TOAST_POSITION.BOTTOM_CENTER,
          target: '.testtarget',
          color: COLOR.RED,
          messageSize: SIZE.FONT_SIZE
        });
      }
    } else {
      // discount percentage
      if (parseInt(_state.ProductPricing.DiscountValue) > 100) {
        _state.ProductPricing.DiscountValue = 0;
        izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.DANGER,
          message: 'Discount value cannot be more than 100%',
          //position : APP_TOAST_POSITION.BOTTOM_CENTER,
          target: '.testtarget',
          color: COLOR.RED,
          messageSize: SIZE.FONT_SIZE
        });
      }
    }
    _state.ProductPricing[e.target.name] = e.target.value == '1' ? false : true;
    this.props.setValues(
      enPARENT.ProductPricing,
      _state.ProductPricing,
      () => {},
    );
  };

  render() {
    let _state = this.props.parentState;

    if (this.state.listTaxType.length > 0) {
      if (_state.ProductPricing.TaxTypeID === "") {
        _state.ProductPricing.TaxTypeID = this.state.listTaxType[0].TaxTypeID
      }
    }
    return (
      <>

        <div className="body">
          <div className="row fm-tp">
            <div className="col-sm-4 ls-inp">
              <label>Price (original) {default_currency.symbol}</label>
              <input
                name="SellingPrice"
                type="number"
                className="form-control"
                placeholder="Price (original)"
                onChange={this.handleChange}
                value={_state.ProductPricing.SellingPrice}
                onKeyDown={this.formatInput}
              />
            </div>
            <div className="col-sm-4 pro-pric-lab">
              <input
                checked={
                  _state.ProductPricing.IsDiscountPercentage ? false : true
                }
                onChange={this.handleChangeRadio}
                value="1"
                name="IsDiscountPercentage"
                type="radio"
              />
              <label style={{ fontSize: '16px' }}>
                {' '}
                &nbsp;&nbsp; Discount Amount ({default_currency.symbol}
                )
              </label>
              <label style={{ fontSize: '16px', color: 'RED' }}>
                {' '}
                &nbsp;&nbsp; OR
              </label>&nbsp;&nbsp;
              <input
                checked={
                  _state.ProductPricing.IsDiscountPercentage ? true : false
                }
                onChange={this.handleChangeRadio}
                value="2"
                name="IsDiscountPercentage"
                type="radio"
              />
              <label style={{ fontSize: '16px' }}>&nbsp;&nbsp;Percentage (%)&nbsp;&nbsp;</label>

              <input
                type="number"
                name="DiscountValue"
                className="form-control"
                placeholder="Discount Amount or %"
                required
                onChange={this.handleChange}
                onKeyDown={this.formatInput}
                value={_state.ProductPricing.DiscountValue}
              />
            </div>
            <div className="col-sm-4 rs-inp">
              <label>Tax Type</label>
              <select
                value={_state.ProductPricing.TaxTypeID}
                className="form-control cursorpointer"
                name="TaxTypeID"
                required
                onChange={this.handleChange}
              >


                {this.state.listTaxType.map((opt, i) => (
                  <option key={i} value={opt.TaxTypeID}>
                    {opt.Description}
                  </option>
                ))}
              </select>
            </div>
          </div>
        </div>
        <div className="row">
          <div className="col-sm-6 ">
            <label>Expected Delivery Duration</label>
            <input
              value={_state.ProductPricing.OrderResponseTime}
              type="number"
              name="OrderResponseTime"
              className="form-control"
              placeholder="Max Response Duration"
              required
              onChange={this.handleChange}
              onKeyDown={this.formatInput}
            />
          </div>
          <div className="col-sm-6 ">
            <label>Expected Delivery Duration Unit</label>
            <select
              value={_state.ProductPricing.OrderResponseTimeUnitID}
              className="form-control cursorpointer"
              name="OrderResponseTimeUnitID"
              onChange={this.handleChange}
            >
              <option value="">-- Select Hours or Days --</option>
              {Object.keys(DBResponseTimeUnitEnum).map((_enum, i) => (
                <option key={i} value={DBResponseTimeUnitEnum[_enum].Value}>
                  {DBResponseTimeUnitEnum[_enum].Description}
                </option>
              ))}
            </select>
          </div>
        </div>
      </>

      // <div className="container bg-light mb-3">
      //     <h2 className="text-center mb-4 pt-5">Product Pricing</h2>
      //     <div className="row">
      //         <div className="col col-sm-8 col-md-12 mx-auto">

      //             <div className="container">
      //             <div className="row justify-content-center">
      //                 <div className="col-md-4">
      //                 <div className="form-group">
      //                     <label><strong>Price (for Buyer)</strong></label>
      //                     <div>
      //                     <input name="BasePrice" type="number" className="form-control" placeholder="Price (for Buyer)"  onChange={this.handleChange} value={_state.ProductPricing.BasePrice} />
      //                     </div>{/* End .select-custom */}
      //                 </div>
      //                 </div>{/*End Form Col-1*/}
      //                 <div className="col-md-4">
      //                 <div className="form-group">
      //                     <label><strong>Discount Amount Percentage</strong></label>
      //                     <div>
      //                     <input type="number" name="DiscountValue" className="form-control" placeholder="Discount Amount or %" required onChange={this.handleChange} value={_state.ProductPricing.DiscountValue} />
      //                     </div>{/* End .select-custom */}
      //                 </div>
      //                 </div>{/*End Form Col-2*/}
      //                 <div className="col-md-4">
      //                 <div className="form-group">
      //                     <label><strong>Tax Type</strong></label>
      //                     <div className="select-custom">
      //                     <select value={_state.ProductPricing.TaxTypeID} defaultValue="" className="form-control" name="TaxTypeID" required onChange={this.handleChange}>
      //                         <option value="">Tax Type</option>
      //                         {
      //                             this.state.listTaxType.map((opt,i)=>
      //                                 <option key={i} value={opt.TaxTypeID}>{opt.Description}</option>
      //                             )
      //                         }
      //                     </select>
      //                     </div>{/* End .select-custom */}
      //                 </div>
      //                 </div>{/*End Form Col-2*/}
      //                 <div className="col-md-8">
      //                 <div className="form-group">
      //                     <label><strong>Price (Recieved by Shop)</strong></label>
      //                     <div>
      //                     <input disabled value={_state.ProductPricing.SellingPrice} type="number" name="SellingPrice" className="form-control" placeholder="Price as recieved by shop" required onChange={this.handleChange} />
      //                     </div>{/* End .select-custom */}
      //                 </div>
      //                 </div>{/*End Form Col-2*/}
      //             </div>{/*End Form Row-1*/}
      //             <hr style={{paddingBottom : '20px'}}/>
      //             </div>{/*End Form Container*/}
      //         </div>{/*End Col*/}
      //     </div>{/*End Row-1*/}
      //     <div className="row">
      //         <div className="col col-sm-8 col-md-12 mx-auto">
      //         <form>
      //             <div className="container">
      //             <div className="row justify-content-center">
      //                 <div className="col-md-4">
      //                 <div className="form-group">
      //                     <label><strong>Order Response Duration</strong></label>
      //                     <div>
      //                     <input value={_state.ProductPricing.OrderResponseTime} type="number" name="OrderResponseTime" className="form-control" placeholder="Max Response Duration" required onChange={this.handleChange} />
      //                     </div>{/* End .select-custom */}
      //                 </div>
      //                 </div>{/*End Form Col-1*/}
      //                 <div className="col-md-4">
      //                 <div className="form-group">
      //                     <label><strong>Duration Unit</strong></label>
      //                     <div className="select-custom">
      //                     <select value={_state.ProductPricing.OrderResponseTimeUnitID} className="form-control" name="OrderResponseTimeUnitID" onChange={this.handleChange}>
      //                         <option value="" selected disabled>Hours, Days, Weeks, Months</option>
      //                         {
      //                             Object.keys(DBResponseTimeUnitEnum).map((_enum,i)=>
      //                                 <option key={i} value={DBResponseTimeUnitEnum[_enum].Value}>{DBResponseTimeUnitEnum[_enum].Description}</option>
      //                             )
      //                         }
      //                     </select>
      //                     </div>{/* End .select-custom */}
      //                 </div>
      //                 </div>{/*End Form Col-2*/}
      //             </div>{/*End Form Row-1*/}
      //             </div>{/*End Form Container*/}
      //         </form>{/*End Form */}
      //         </div>{/*End Col*/}
      //     </div>{/*End Row-2*/}
      // </div>
    );
  }
}

export default ProductPricing;
