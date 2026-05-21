import React from 'react';
import SearchSelect from '../../customControls/SearchSelect/SearchSelect';
import { FetchData } from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  SIZE
} from '../../../utils/constants';
import { DeliveryOptionEnum } from '../../../utils/enums';
import { default_currency } from '../../../utils/globalConstants';
import izitoast from 'izitoast';
import 'izitoast/dist/css/iziToast.css';

const enPARENT = {
  DELIVERY: 'Delivery',
};

class ShopDelivery extends React.Component {
  constructor(props) {
    super(props);
    this.resolve = null;
    this.state = {
      SelfPickUp: false,
      ShopDelivery: false,
      DeliverSurroundingCities: false,
      DeliveryAcrossCountry: false,
      surroundingCities: [],
      selectedSurroundingCities: [],

      deliverychargesSD: 0,
      minorderSD: 0,
      deliverychargesSC: 0,
      minorderSC: 0,
      deliverychargesAC: 0,
      minorderAC: 0,
      currencySymbol: default_currency.symbol,
    };
  }

  successGetSurroundingCities = (res) => {
    this.setState(
      {
        surroundingCities: res,
      },
      () => {
        this.resolve();
      },
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

  componentDidMount() {
    window.scrollTo(0, 0);
    let _promise = new Promise((resolve, reject) => {
      this.resolve = resolve;
      if (!(this.state.surroundingCities.length > 0)) {
        let supplierId = this.props.parentState.Supplier.SupplierID;
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.SupplierDelivery_GetSurroundingCities + supplierId,
          null,
          this.successGetSurroundingCities,
        );
      } else {
        resolve();
      }
    });

    _promise.then(() => {
      this.initValues();
    });

    let _state = this.props.parentState;
    console.log("_state.Delivery", _state.Delivery)
  }

  initValues = () => {
    let _state = this.props.parentState;
    //console.log("_state.Delivery",_state.Delivery)
    let SelfPickUp = _state.Delivery.find(
      (a) => a.DeliveryOptionID == DeliveryOptionEnum.SelfPickUp,
    );
    let ShopDelivery = _state.Delivery.find(
      (a) => a.DeliveryOptionID == DeliveryOptionEnum.ShopDelivery,
    );
    let DeliverSurroundingCities = _state.Delivery.find(
      (a) => a.DeliveryOptionID == DeliveryOptionEnum.DeliverSurroundingCities,
    );
    let DeliveryAcrossCountry = _state.Delivery.find(
      (a) => a.DeliveryOptionID == DeliveryOptionEnum.DeliveryAcrossCountry,
    );

    let newState = this.state;

    if (DeliveryAcrossCountry) {
      newState.DeliveryAcrossCountry = true;
      newState.deliverychargesAC = parseInt(
        DeliveryAcrossCountry.DeliveryCharges,
      );
      newState.minorderAC = parseInt(DeliveryAcrossCountry.MinOrderLimit);
    }

    if (SelfPickUp) {
      newState.SelfPickUp = true;
    }

    if (ShopDelivery) {
      newState.ShopDelivery = true;
      newState.deliverychargesSD = parseInt(ShopDelivery.DeliveryCharges);
      newState.minorderSD = parseInt(ShopDelivery.MinOrderLimit);
    }

    if (DeliverSurroundingCities) {
      newState.DeliverSurroundingCities = true;
      newState.deliverychargesSC = parseInt(
        DeliverSurroundingCities.DeliveryCharges,
      );
      newState.minorderSC = parseInt(DeliverSurroundingCities.MinOrderLimit);
      if (
        DeliverSurroundingCities.SurroundingCitiesIDs &&
        DeliverSurroundingCities.SurroundingCitiesIDs != ''
      ) {
        let _arrSCIds = DeliverSurroundingCities.SurroundingCitiesIDs.split(
          ',',
        );
        let _arrSCNames = [];

        if (
          !(
            DeliverSurroundingCities.SurroundingCities &&
            DeliverSurroundingCities.SurroundingCities != ''
          )
        ) {
          if (this.state.surroundingCities) {
            let tempArrCities = [];
            for (let item of _arrSCIds) {
              let temp = this.state.surroundingCities.find(
                (a) => a.LocationID == item,
              );
              if (temp) {
                tempArrCities.push(temp.LocationName);
              }
            }
            DeliverSurroundingCities.SurroundingCities = tempArrCities.toString();
          }
        } else {
        }
        _arrSCNames = DeliverSurroundingCities.SurroundingCities.split(',');

        for (let i = 0; i < _arrSCIds.length; i++) {
          let tmpModel = {
            LocationID: _arrSCIds[i],
            LocationName: _arrSCNames[i],
          };

          newState.selectedSurroundingCities.push(tmpModel);
        }
      }
    }

    this.setState(newState);
  };

  // componentDidMount() {
  //   console.log('in comppnent did mount')
  //   if (this.state.SelfPickUp === false && this.state.ShopDelivery === false && this.state.DeliveryAcrossCountry === false) {
  //     this.AddtoDeliveryOptionList('SelfPickUp')
  //   }
  // }
  componentDidUpdate() { }

  handleChangeCheckbox = (e) => {
    console.log("targetname", e.target.name)
    let temp = this.state[e.target.name];
    console.log("temp", temp)
    let setStateObj = {};
    if (e.target.name == 'ShopDelivery' && this.state[e.target.name] == true) {
      setStateObj = {
        ShopDelivery: !temp,
        DeliverSurroundingCities: !temp,
      };
    } else {
      setStateObj = {
        [e.target.name]: !temp,
      };
      console.log("setStateObj", setStateObj)
    }
    console.log(this.state.SelfPickUp)
    this.setState(setStateObj, () => {
      if (
        e.target.name == 'ShopDelivery' &&
        this.state[e.target.name] == false
      ) {
        this.AddtoDeliveryOptionList(e.target.name);
        this.AddtoDeliveryOptionList('DeliverSurroundingCities');
      } else {

        console.log('in second else')
        this.AddtoDeliveryOptionList(e.target.name);
      }
    });
  };

  minimumOrderCheck= (fieldName,value) => {
    if(fieldName === 'minorderSD' || fieldName ==='minorderSC')
    {
        if(parseInt(value) < 1)
        {
          return true;
        }
        else if (parseInt(value) > 999)
        {
          return true;
        }
        return false;
    }
    return false
  }

  handleChangeTextbox = (e) => {
    //console.log('in handletextbox', e.target.value)
    if (parseInt(e.target.value) < 0) {
      e.target.value = 0
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.DANGER,
        message: ' value cannot be less than zero',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
    else if (parseInt(e.target.value) > 10000) {
      e.target.value = 0
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.DANGER,
        message: ' value must be in range of 0-10000',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED
      });
    }
    else if (this.minimumOrderCheck(e.target.name, e.target.value)) {
      e.target.value = 0
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.DANGER,
        message: ' value must be in range of 1-999',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED
      });
    }
    else {
      this.setState(
        {
          [e.target.name]: e.target.value,
        },
        () => {
          let _keyList = '';
          let _keyObj = '';

          switch (e.target.name) {
            case 'deliverychargesSD':
              _keyList = 'ShopDelivery';
              _keyObj = 'DeliveryCharges';
              break;
            case 'minorderSD':
              _keyList = 'ShopDelivery';
              _keyObj = 'MinOrderLimit';
              break;
            case 'deliverychargesSC':
              _keyList = 'DeliverSurroundingCities';
              _keyObj = 'DeliveryCharges';
              break;
            case 'minorderSC':
              _keyList = 'DeliverSurroundingCities';
              _keyObj = 'MinOrderLimit';
              break;
            case 'deliverychargesAC':
              _keyList = 'DeliveryAcrossCountry';
              _keyObj = 'DeliveryCharges';
              break;
            case 'minorderAC':
              _keyList = 'DeliveryAcrossCountry';
              _keyObj = 'MinOrderLimit';
              break;
          }

          this.AppendDetailsToDeliveryOption(_keyList, _keyObj, e.target.value);
        }
      );
    }
  };

  AddtoDeliveryOptionList = (key) => {
    console.log('deliveryoption', key);
    let _state = this.props.parentState;
    let _remove = false;
    let _model = {
      SupplierDeliveryOptionPairID: '',
      SupplierID: _state.Supplier.SupplierID,
      SupplierName: _state.Supplier.SupplierName,
      DeliveryOptionID: '',
      DeliveryOptionTitle: '',
      DeliveryCharges: '',
      MinOrderLimit: '',
      SurroundingCities: '',
      SurroundingCitiesIDs: '',
      RequestedByProfileId: _state.Supplier.RequestedByProfileId,
    };

    if (this.state[key]) {
      _model.DeliveryOptionID = DeliveryOptionEnum[key];
      _model.DeliveryOptionTitle = key;
      //exception ~ DeliverSurroundingCities
    } else {
      _remove = true;
    }

    if (_remove) {
      //in case of false i.e. uncheck
      _state.Delivery = _state.Delivery.filter(
        (a) => !(a.DeliveryOptionID == DeliveryOptionEnum[key]),
      );
      this.props.setValues(enPARENT.DELIVERY, _state.Delivery);
    } else {
      _state.Delivery.push(_model);
      this.props.setValues(enPARENT.DELIVERY, _state.Delivery);
    }
  };

  AppendDetailsToDeliveryOption = (keyList, keyObj, value) => {
    let _state = this.props.parentState;
    let item = _state.Delivery.find(
      (a) => a.DeliveryOptionID == DeliveryOptionEnum[keyList],
    );
    if (item) {
      item[keyObj] = value;
      this.props.setValues(enPARENT.DELIVERY, _state.Delivery);
    }
  };

  renderItemSearch = (obj, i, _selectedItem) => {
    return (
      <div
        onClick={() => {
          _selectedItem(obj);
        }}
      >
        <span className="text-bold info-custom-inner">{obj.LocationName}</span>
        <br />
      </div>
    );
  };

  selectedItemSearch = (obj) => {
    if (
      !this.state.selectedSurroundingCities.find(
        (a) => a.LocationName == obj.LocationName,
      )
    ) {
      this.state.selectedSurroundingCities.push(obj);
      this.setState(
        {
          selectedSurroundingCities: this.state.selectedSurroundingCities,
        },
        () => {
          let _state = this.props.parentState;
          let item = _state.Delivery.find(
            (a) =>
              a.DeliveryOptionID == DeliveryOptionEnum.DeliverSurroundingCities,
          );
          if (item) {
            item.SurroundingCitiesIDs = this.state.selectedSurroundingCities
              .map((_obj, _i) => _obj.LocationID)
              .toString();
            item.SurroundingCities = this.state.selectedSurroundingCities
              .map((_obj, _i) => _obj.LocationName)
              .toString();
            this.props.setValues(enPARENT.DELIVERY, _state.Delivery);
          }
        },
      );
    }
  };
  removeSelectedSurroundingCity = (obj) => {
    let _selectedSurroundingCities = this.state.selectedSurroundingCities.filter(
      (a) => !(a.LocationName == obj.LocationName),
    );
    this.setState(
      {
        selectedSurroundingCities: _selectedSurroundingCities,
      },
      () => {
        let _state = this.props.parentState;
        let item = _state.Delivery.find(
          (a) =>
            a.DeliveryOptionID == DeliveryOptionEnum.DeliverSurroundingCities,
        );
        if (item) {
          item.SurroundingCitiesIDs = this.state.selectedSurroundingCities
            .map((_obj, _i) => _obj.LocationID)
            .toString();
          item.SurroundingCities = this.state.selectedSurroundingCities
            .map((_obj, _i) => _obj.LocationName)
            .toString();
          this.props.setValues(enPARENT.DELIVERY, _state.Delivery);
        }
      },
    );
  };
  hookSearchTyping = () => { };

  render() {
    return (
      <div className="body">
        <div className="row">
          <div
            style={{
              fontWeight: '500',
              marginBottom: '5px',
              textAlign: 'left',
              fontSize: '24px',
            }}
            className="container"
          >
            Please select one or MORE delivery methods you offer to your customers
          </div>{/*}
          <div
            style={{
              fontWeight: '500',
              marginBottom: '5px',
              textAlign: 'left',
              fontSize: '24px',
            }}
            className="container"
          >
            For All Services Sellers please leave all options unchecked and tap "Save and Continue"
          </div>*/}
          <div className="col-sm-12">
            <div className="row inrw">
              <div className="col-sm-4 npad">
                <div className="inputGroup">
                  <input
                    checked={this.state.SelfPickUp}
                    id="SelfPickUp"
                    onChange={this.handleChangeCheckbox}
                    name="SelfPickUp"
                    type="checkbox"
                    className="custom-control-input"
                    value={this.state.SelfPickUp}
                    style={{ position: 'absolute' }}
                  />
                  <label htmlFor="SelfPickUp" className="bigger">Self Pickup / My Services</label>
                </div>
              </div>
              <div className="col-sm-8 npad hb op1">
                <p
                  style={{
                    fontWeight: '500',
                    marginBottom: '5px',
                    textAlign: 'left',
                    fontSize: '24px',
                  }}
                >No delivery fee or minimum order are required to configure in pick-up</p>
                {this.state.SelfPickUp ? (
                  <span>
                    Complete address will be available to your customer on
                    check-out
                  </span>
                ) : (
                  <></>
                )}
              </div>
            </div>
            <div className="row inrw">
              <div className="col-sm-4 npad">
                <div className="inputGroup">
                  <input
                    checked={this.state.ShopDelivery}
                    id="ShopDelivery"
                    onChange={this.handleChangeCheckbox}
                    name="ShopDelivery"
                    type="checkbox"
                    className="custom-control-input"
                    value={this.state.ShopDelivery}
                    style={{ position: 'absolute' }}
                  />
                  <label htmlFor="ShopDelivery">Local Delivery / Remote Services</label>
                </div>
                <span
                  style={{
                    fontWeight: '500',
                    marginBottom: '5px',
                    textAlign: 'left',
                    fontSize: '20px',
                  }}

                  htmlFor="ShopDelivery" className="tpsd"
                >
                  Your LOCAL CITY is based on your Shop Address Entry
                </span>
              </div>
              <div className="col-sm-8 npad hb op2">
                <div className="row">
                  <div className="col-sm-6">
                    <label>
                      Delivery fee <span>{this.state.currencySymbol} (in your local city)</span>
                    </label>
                    <input
                      disabled={!this.state.ShopDelivery}
                      onChange={this.handleChangeTextbox}
                      name="deliverychargesSD"
                      type="number"
                      className="form-control"
                      placeholder="Delivery Charges"
                      onKeyDown={this.formatInput}
                      value={this.state.deliverychargesSD}
                    />
                  </div>
                  <div className="col-sm-6">
                    <label>
                      Minimum Order {this.state.currencySymbol}
                    </label>
                    <input
                      disabled={!this.state.ShopDelivery}
                      onChange={this.handleChangeTextbox}
                      name="minorderSD"
                      type="number"
                      className="form-control"
                      placeholder="Minimum Order (Amount)"
                      value={this.state.minorderSD}
                      onKeyDown={this.formatInput}
                    />
                  </div>
                </div>
                <div className="row">
                  <div className="col-sm-12">
                    <br />
                    <ul className="ks-cboxtags">
                      <li>
                        <input
                          checked={this.state.DeliverSurroundingCities}
                          id="DeliverSurroundingCities"
                          onChange={this.handleChangeCheckbox}
                          name="DeliverSurroundingCities"
                          type="checkbox"
                          className="custom-control-input"
                          value={this.state.DeliverSurroundingCities}
                        />
                        <label
                          style={
                            this.state.ShopDelivery
                              ? { pointerEvents: 'all' }
                              : { pointerEvents: 'none' }
                          }
                          htmlFor="DeliverSurroundingCities"
                          className="npad"
                        />
                        <span className="label span">
                          Delivery/Services within surrounding city
                        </span>
                      </li>
                    </ul>
                  </div>
                </div>
                <div className="row">
                  <div className="col-sm-6">
                    <label>
                      Delivery Fee <span>{this.state.currencySymbol} (for surrounding cities)</span>
                    </label>
                    <input
                      disabled={!this.state.DeliverSurroundingCities}
                      onChange={this.handleChangeTextbox}
                      name="deliverychargesSC"
                      type="number"
                      className="form-control"
                      placeholder="Delivery Charges"
                      value={this.state.deliverychargesSC}
                      onKeyDown={this.formatInput}
                    />
                  </div>
                  <div className="col-sm-6">
                    <label>
                      Minimum Order {this.state.currencySymbol}
                    </label>
                    <input
                      disabled={!this.state.DeliverSurroundingCities}
                      onChange={this.handleChangeTextbox}
                      name="minorderSC"
                      type="number"
                      className="form-control"
                      placeholder="Minimum Order (Amount)"
                      value={this.state.minorderSC}
                      onKeyDown={this.formatInput}
                    />
                  </div>
                </div>
                <div className="row">
                  <div className="col-sm-12">
                    <label>Surrounding Cities</label>
                    <SearchSelect
                      list={this.state.surroundingCities}
                      placeholder={'Type to search and add MORE surrounding cities you would serve.'}
                      disabled={!this.state.DeliverSurroundingCities}
                      filter="ALL"
                      sKey="ShopDelivery"
                      CharacterCount={0 /*min character to start search*/}
                      displayHook={this.renderItemSearch /*Can be customized*/}
                      selectHook={this.selectedItemSearch}
                      hookInputTyping={this.hookSearchTyping}
                    />
                    <div className="cityblockwrapper">
                      {
                        /* custom render hook for selected items*/
                        this.state.selectedSurroundingCities.map((item, i) => (
                          <div key={i} className="cityblock">
                            {item.LocationName}
                            <i
                              className="icon-retweet"
                              onClick={() => {
                                this.removeSelectedSurroundingCity(item);
                              }}
                            ></i>
                          </div>
                        ))
                      }
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div className="row inrw">
              <div className="col-sm-4 npad">
                <div className="inputGroup">
                  <input
                    checked={this.state.DeliveryAcrossCountry}
                    id="DeliveryAcrossCountry"
                    onChange={this.handleChangeCheckbox}
                    name="DeliveryAcrossCountry"
                    type="checkbox"
                    className="custom-control-input"
                    value={this.state.DeliveryAcrossCountry}
                    style={{ position: 'absolute' }}
                  />
                  <label htmlFor="DeliveryAcrossCountry">
                    Country-Wide Shipping
                  </label>
                </div>
              </div>
              <div className="col-sm-8 npad hb op3">
                <div className="row">
                  <div className="col-sm-6">
                    <label>
                      Shipping Fee <span>{this.state.currencySymbol}</span>
                    </label>
                    <input
                      disabled={!this.state.DeliveryAcrossCountry}
                      onChange={this.handleChangeTextbox}
                      name="deliverychargesAC"
                      type="number"
                      className="form-control"
                      placeholder="Delivery Charges"
                      value={this.state.deliverychargesAC}
                    />
                  </div>
                  <div className="col-sm-6">
                    <label>
                      Minimum Order {this.state.currencySymbol}
                    </label>
                    <input
                      disabled={!this.state.DeliveryAcrossCountry}
                      onChange={this.handleChangeTextbox}
                      name="minorderAC"
                      type="number"
                      className="form-control"
                      placeholder="Minimum Order (Amount)"
                      value={this.state.minorderAC}
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default ShopDelivery;
