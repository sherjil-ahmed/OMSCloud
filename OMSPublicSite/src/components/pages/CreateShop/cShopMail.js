import React from 'react';
import { DeliveryOptionEnum } from '../../../utils/enums';

const enPARENT = {
  DELIVERY: 'Delivery',
};

class ShopMail extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      DeliveryAcrossCountry: false,
      deliverychargesAC: 0,
      minorderAC: 0,
    };
  }
  componentDidMount() {
    window.scrollTo(0, 0);
    this.initValues();
  }

  initValues = () => {
    let _state = this.props.parentState;
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
    this.setState(newState);
  };

  handleChangeCheckbox = (e) => {
    let temp = this.state[e.target.name];
    this.setState(
      {
        [e.target.name]: !temp,
      },
      () => {
        this.AddtoDeliveryOptionList(e.target.name);
      },
    );
  };

  handleChangeTextbox = (e) => {
    this.setState(
      {
        [e.target.name]: e.target.value,
      },
      () => {
        let _keyList = '';
        let _keyObj = '';
        switch (e.target.name) {
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
      },
    );
  };

  AddtoDeliveryOptionList = (key) => {
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

  render() {
    return (
      <div>
        <div className="heading">
          <h2 className="title">Mail Delivery Setup</h2>
        </div>
        <div>
          <div className="form-group-custom-control">
            <div
              className="custom-control custom-checkbox"
              style={{ textAlign: 'initial' }}
            >
              <input
                checked={this.state.DeliveryAcrossCountry}
                id="DeliveryAcrossCountry"
                onChange={this.handleChangeCheckbox}
                name="DeliveryAcrossCountry"
                type="checkbox"
                className="custom-control-input"
                value={this.state.DeliveryAcrossCountry}
              />
              <label
                htmlFor="DeliveryAcrossCountry"
                className="custom-control-label"
              >
                {' '}
                Anywhere else in country
              </label>
            </div>
            <div className="row">
              <div className="col-md-6">
                <label>
                  <strong>Delivery charges</strong>
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
              <div className="col-md-6">
                <label>
                  <strong>Minimum Order Limit (Amount)</strong>
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
    );
  }
}

export default ShopMail;
