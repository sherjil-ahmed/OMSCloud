import React from 'react';
import { compose, withProps } from 'recompose';
import {
  withScriptjs,
  withGoogleMap,
  GoogleMap,
  Marker,
} from 'react-google-maps';
import { FetchData } from '../../../utils/serviceHelper';
import { REQUEST_TYPE, SERVICE_ENDPOINTS } from '../../../utils/constants';
import { LocationLevelEnum } from '../../../utils/enums';
import { default_strings } from '../../../utils/globalConstants';

const enPARENT = {
  LIST_CITIES: 'listCities',
  LIST_PROVINCES: 'listProvinces',
  ADDRESS: 'Address',
};

class ShopAddress extends React.Component {
  constructor(props) {
    super(props);
    this.ProvinceID = '';
    this.state = {};
  }

  successGetCityList_parent = (res) => {
    this.props.setValues(enPARENT.LIST_CITIES, res);
  };

  componentDidMount() {
    window.scrollTo(0, 0);
    let _state = this.props.parentState.Address;
    console.log("_state new ",_state)
    if (
      !(
        this.props.parentState.listProvinces &&
        this.props.parentState.listProvinces.length > 0
      )
    ) {
      //fetch provinces
      this.fetchProvinces();
    }

    if (
      this.props.parentState.Address.ProvinceID &&
      this.props.parentState.Address.ProvinceID != ''
    ) {
      this.fetchCities(
        this.props.parentState.Address.ProvinceID,
        this.successGetCityList_parent,
      );
    }
  }

  componentDidUpdate() {
    if (
      this.props.parentState.Address.ProvinceID &&
      this.props.parentState.Address.ProvinceID != ''
    ) {
      if (
        !(
          this.props.parentState.listCities &&
          this.props.parentState.listCities.length >= 0
        )
      ) {
        this.fetchCities(
          this.props.parentState.Address.ProvinceID,
          this.successGetCityList_parent,
        );
      }
    }
  }

  successGetProvinceList = (res) => {
    this.props.setValues(enPARENT.LIST_PROVINCES, res);
  };

  fetchProvinces = () => {
    let idParent = LocationLevelEnum.Province;
    let idChild = this.props.parentState.Supplier.CountryID;

    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.LocationTree_GetLocationList + idParent + '/' + idChild,
      null,
      this.successGetProvinceList,
    );
  };

  fetchCities = (ProvinceID) => {
    this.ProvinceID = ProvinceID;
    let idParent = LocationLevelEnum.City;
    let idChild = ProvinceID;

    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.LocationTree_GetLocationList + idParent + '/' + idChild,
      null,
      this.successGetCityList,
    );
  };

  successGetCityList = (res) => {
    let _state = this.props.parentState.Address;
    _state.ProvinceID = this.ProvinceID;
    //_state.CityID =  "";

    this.props.setValuesMany({
      Address: _state,
      listCities: res,
    });
  };

  handleProvinceChange = (e) => {
    let _ProvinceID = e.target.value;
    this.fetchCities(_ProvinceID);
  };

  handleChange = (e) => {
    let _state = this.props.parentState.Address;
    _state[e.target.name] = e.target.value;
    this.props.setValues(enPARENT.ADDRESS, _state);
  };
  handleChangeCheckbox = (e) => {
    let _state = this.props.parentState.Address;
    if(_state[e.target.name] ===true){
      _state[e.target.name] = false
    }
    else{
      _state[e.target.name] = true
    }
    this.props.setValues(enPARENT.ADDRESS, _state);
       };

  render() {
    let _state = this.props.parentState.Address;
    console.log("_state",_state)
    return (
      <div className="body">
        <div className="row">
          <div className="col-md-6 col-sm-12">
            <ul className="ks-cboxtags fw">
              <li>
              <input
                          checked={_state.IsBusinessAddressVisible}
                          onChange={this.handleChangeCheckbox}
                          name="IsBusinessAddressVisible"
                          id="IsBusinessAddressVisible"
                          type="checkbox"
                          className="custom-control-input"
                          value={_state.IsBusinessAddressVisible}
                        />
                {/* <input
                  type="checkbox"
                  id="checkboxOne1"
                  onChange={this.handleVisibiltyChange}
                  value={_state.IsBusinessAddressVisible}
                /> */}
                <label htmlFor="IsBusinessAddressVisible" className="npad" />
                <span className="label span">
                  Address publicly visible
                  <br></br>
                  <text style={{ fontSize: '12px' }}>
                  Complete Address visible on public profile
                  </text>
                  <br></br>
                  <text style={{ fontSize: '12px' }}>
(If this option is not selected, the state/province, city & postal code/zip code will be visible on public profile, anyways)
 
                  </text>
                </span>
              </li>
            </ul>
            </div>
            </div>
            <div className="row">
                <div className="col-md-6 col-sm-12">
                        <label>Street Number *</label>
                        <input
                          value={_state.StreetNumber}
                          onChange={this.handleChange}
                          name="StreetNumber"
                          type="text"
                          maxLength = "200"
                          className="form-control"
                          placeholder="Street Number"
                        />
                        <label className="">Apartment / Suite / Unit (optional)</label>
                        <input
                          value={_state.NearestLandmark}
                          onChange={this.handleChange}
                          name="NearestLandmark"
                          type="text"
                          maxLength = "200"
                          className="form-control "
                          placeholder="Apartment / Suite / Unit"
                        />
                        <label>City *</label>
                        <select
                          value={_state.CityID}
                          onChange={this.handleChange}
                          name="CityID"
                          className="form-control"
                          placeholder="City"
                          defaultValue=""
                        >
                          <option value={''}>--Select City--</option>
                          {this.props.parentState.listCities.map((item, i) => (
                            <option key={i} value={item.LocationID}>
                              {item.LocationName}
                            </option>
                          ))}
                        </select>

                </div>
              <div className="col-md-6 col-sm-12">
                        <label>Street Name *</label>
                        <input
                          value={_state.PlotNumber}
                          onChange={this.handleChange}
                          name="PlotNumber"
                          type="text"
                          maxLength = "200"
                          className="form-control"
                          placeholder="Street Name"
                        />
                        <label>{default_strings.PROVINCE} *</label>
                        <select
                          value={_state.ProvinceID}
                          onChange={this.handleProvinceChange}
                          name="ProvinceID"
                          className="form-control"
                          placeholder="Province"
                          defaultValue=""
                        >
                          <option value={''}>--Select Province--</option>
                          {this.props.parentState.listProvinces.map((item, i) => (
                            <option key={i} value={item.LocationID}>
                              {item.LocationName}
                            </option>
                          ))}
                        </select>
                        
                        <label>{default_strings.POSTAL} *</label>
                        <input
                          value={_state.PostalCode}
                          onChange={this.handleChange}
                          name="PostalCode"
                          type="text"
                          maxLength = "10"
                          className="form-control"
                          placeholder="Postal Code"
                        />
                  
                        <label style={{ fontSize: 12, marginBottom: 15, color: 'RED' }}>
                          {this.props.parentState.postalCodeerror}
                        </label>

              </div>

        </div>
      </div>
    );
  }
}

export default ShopAddress;
