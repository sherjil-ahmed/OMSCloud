import React from 'react';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  USER_PROFILE,
  LIST_PROVINCES,
  LIST_CITIES,
  PROFILE_ID,
  SIZE
} from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import { countries, default_strings } from '../../../utils/globalConstants';
import { LocationLevelEnum } from '../../../utils/enums';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR } from '../../../utils/constants';
import Modal from 'react-modal';
import  { AddressTypeID} from '../../../utils/enums';
class AddressManagement extends React.Component {
  constructor(props) {
    super(props);
    this.NewAddressForm = React.createRef();
    this.NewAddressSubmit = React.createRef();
    this.state = {
      userProfile: getStorageItem(USER_PROFILE),
      addressDetail: [],
      listProvinces: getStorageItem(LIST_PROVINCES)
        ? getStorageItem(LIST_PROVINCES)
        : [],
      openModal: false,
      newPlotNumber: '',
      newStreetNumber: '',
      newNearestLandmark: '',
      newPostalCode: '',
      newSelectedCity: '',
      newSelectedProvince: '',
      newAddressCitiesList: [],
      //
      selectedAddressID: '',
      postalCodeerror: ''
    };
  }
  componentDidMount() {
    this.initComponent();
  }

  componentDidUpdate(prevProps, prevState) {
    if (this.props.ShowNew != undefined && prevProps != this.props) {
      this.setState({
        openModal: this.props.ShowNew,
        selectedAddressID: this.props.AddressID,
      });
    }
  }

  initComponent = () => {
    console.log('init component called')
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Address_GetAddressListByProfileid +
      '?Id=' +
      getStorageItem(PROFILE_ID) +
      '&AddressTypeID=' +
      AddressTypeID.DeliveryAddressType,

        
      null,
      this.gotUserData,
    );
  };

  gotUserData = (res) => {
    for (let address of res) {
      address.ShowHideDiv = false;
      address.FormRef = React.createRef();
      if (address.ProvinceID != null && address.ProvinceID) {
        this.getAddressCity(address.ProvinceID, address);
      }
    }
    this.setState({
      addressDetail: res,
    });
  };
  getAddressCity(Province, item) {
    let idParent = LocationLevelEnum.City;
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.LocationTree_GetLocationList +
        idParent +
        '/' +
        Province,
      null,
      this.successGetCitiesList,
      null,
      { selectedItem: item },
    );
  }
  successGetCitiesList = (res, params) => {
    params.selectedItem.listCities = res;
    this.setState({
      addressDetail: this.state.addressDetail,
    });
  };
  deleteAddress(addressID) {
    FetchData(
      REQUEST_TYPE.DELETE,
      SERVICE_ENDPOINTS.Address_Delete + addressID,
      null,
      this.responseOnDelete,
      null,
      { addressID: addressID },
    );
  }
  responseOnDelete = (res, params) => {
    if (res == true) {
      let newAddressDetails = this.state.addressDetail.filter(
        (a) => !(a.AddressID == params.addressID),
      );
      this.setState(
        {
          addressDetail: newAddressDetails,
        },
        () => {
                izitoast.destroy();
      izitoast.show({

            title: '',
            icon: APP_ICONS.SUCCESS,
            message: 'Address Deleted Successfully',
            ////position: APP_TOAST_POSITION.BOTTOM_CENTER,
            target: '.testtarget',
            target: '.testtarget',
            color: COLOR.GREEN,
            messageSize: SIZE.FONT_SIZE
          });
        },
      );
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Error',
        //position: APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };
  handleProvinceDropdownChange = (e, item) => {
    item.ProvinceID = e.target.value;
    this.getAddressCity(item.ProvinceID, item);
    this.setState({
      addressDetail: this.state.addressDetail,
    });
  };
  handleNewProvinceDropdownChange = (e) => {
    let provinceVal = e.target.value;
    this.getNewAddressCity(provinceVal);
    this.setState({
      newSelectedProvince: provinceVal,
    });
  };
  handleNewCityDropdownChange = (e) => {
    this.setState({
      newSelectedCity: e.target.value,
    });
  };
  getNewAddressCity(Province) {
    let idParent = LocationLevelEnum.City;
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.LocationTree_GetLocationList +
        idParent +
        '/' +
        Province,
      null,
      this.successGetNewCitiesList,
    );
  }
  successGetNewCitiesList = (res) => {
    this.setState({
      newAddressCitiesList: res,
    });
  };
  handleCityDropdownChange = (e, item) => {
    item.CityID = e.target.value;
    this.setState({
      addressDetail: this.state.addressDetail,
    });
  };
  handleTextChange = (e, item, name) => {
    if (name === 'PlotNumber') {
      item.PlotNumber = e.target.value;
    } else if (name === 'StreetNumber') {
      item.StreetNumber = e.target.value;
    } else if (name === 'NearestLandmark') {
      item.NearestLandmark = e.target.value;
    } else if (name === 'PostalCode') {
      item.PostalCode = e.target.value;
    }
    this.setState({
      addressDetail: this.state.addressDetail,
    });
  };
  updateAddressItem = (e, item) => {

      
      window.ValidateForm(null, item.FormRef, () => {
        item.AddressTypeID = 2;
        item.StatusID = 1;
        item.FormRef = null;
        e.preventDefault();
        FetchData(
          REQUEST_TYPE.POST,
          SERVICE_ENDPOINTS.Address_Post,
          item,
          this.successSavedAddressItem,
        );
      });
      this.setState({
        postalCodeerror : ''
      })
     
  };
  successSavedAddressItem = (res) => {
    if (res != null) {
      this.initComponent();
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.SUCCESS,
        message: 'Address Saved Successfully',
        target: '.testtarget',
        color: COLOR.GREEN,
        messageSize: SIZE.FONT_SIZE
      });
      this.setState(
        {
          openModal: false,
          newPlotNumber: '',
          newStreetNumber: '',
          newNearestLandmark: '',
          newPostalCode: '',
          newSelectedCity: '',
          newSelectedProvince: '',
          newAddressCitiesList: [],
        },
        () => {
          if (this.props && this.props.setShowNew) this.props.setShowNew(false);
        },
      );
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Error',
        //position: APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };
  newAddressHanleChange = (e) => {
    this.setState({
      [e.target.name]: e.target.value,
    });
  };
  saveNewAddress() {
        window.ValidateForm(this.NewAddressSubmit, this.NewAddressForm, () => {
          
          this.setState({
            openModal: false,
          })  
          let reqObj = {
            AddressTypeID: 2,
            CityID: this.state.newSelectedCity,
            CountryID: countries[0].countryId,
            NearestLandmark: this.state.newNearestLandmark,
            PlotNumber: this.state.newPlotNumber,
            PostalCode: this.state.newPostalCode,
            ProfileID: getStorageItem(PROFILE_ID), //this.state.userProfile.ProfileID,
            ProvinceID: this.state.newSelectedProvince,
            ShopID: null,
            StatusID: 1,
            StreetNumber: this.state.newStreetNumber,
          };
          FetchData(
            REQUEST_TYPE.PUT,
            SERVICE_ENDPOINTS.Address_Put,
            reqObj,
            this.successSavedAddressItem,
          );
        });
        this.setState({
          postalCodeerror : ''
        })      
      }

  handleCheck = (item) => {
    this.setState(
      {
        selectedAddressID: item.AddressID,
      },
      () => {},
    );
  };

  render() {
    let optionsProvince = [];
    let j = 1;
    if (this.state.listProvinces && this.state.listProvinces.length > 0) {
      for (let Pitem of this.state.listProvinces) {
        optionsProvince.push(
          <option value={Pitem.LocationID} key={j}>
            {Pitem.LocationName}
          </option>,
        );
        j++;
      }
    }
    let optionsNewAddressCities = [];
    let k = 1;
    if (
      this.state.newAddressCitiesList &&
      this.state.newAddressCitiesList.length > 0
    ) {
      for (let Citem of this.state.newAddressCitiesList) {
        optionsNewAddressCities.push(
          <option key={k} value={Citem.LocationID}>
            {Citem.LocationName}
          </option>,
        );
        k++;
      }
    }

    let propShowAddressHeader =
      this.props.ShowAddressHeader == undefined
        ? true
        : this.props.ShowAddressHeader;
    let propShowExisting =
      this.props.ShowExisting == undefined ? true : this.props.ShowExisting;
    let propShowNew =
      this.props.ShowNew && this.props.ShowNew == true ? true : false;
    let propShowSelection =
      this.props.ShowSelection && this.props.ShowSelection == true
        ? true
        : false;

    return (
      <div className="col-lg-9 order-lg-last dashboard-content">
        <Modal
          isOpen={this.state.openModal}
          onRequestClose={() => {
            return this.state.openModal;
          }}
          className="modal-content"
        >
          <div className="modal-header">
            <h4 class="modal-title">Add New Address</h4>
            <label
              className="close"
              data-dismiss="modal"
              onClick={(e) => {
                this.setState(
                  {
                    openModal: false,
                  },
                  () => {},
                );
                this.props.setShowNew();
              }}
            >
              <i class="fa fa-times" aria-hidden="true"></i>
            </label>
          </div>
          <div className="modal-body">
            <div className="row address_managmentrow">
              <form action="#" className="col-lg-12" ref={this.NewAddressForm}>

                <div className="form-group required-field">
                  <label>Street Number </label>
                  <input
                    type="text"
                    maxLength = "200"
                    className="form-control"
                    required
                    name="newStreetNumber"
                    value={this.state.newStreetNumber}
                    onChange={(e) => {
                      this.newAddressHanleChange(e);
                    }}
                  />
                </div>
                {/* End .form-group */}
                <div className="form-group required-field">
                  <label>Street Name </label>
                  <input
                    type="text"
                    maxLength = "200"
                    name="newPlotNumber"
                    value={this.state.newPlotNumber}
                    className="form-control"
                    required
                    onChange={(e) => {
                      this.newAddressHanleChange(e);
                    }}
                  />
                </div>
                {/* End .form-group */}
                <div className="form-group">
                  <label>Apartment / Suite / Unit (optional) </label>
                  <input
                    type="text"
                    maxLength = "200"
                    className="form-control"
                    name="newNearestLandmark"
                    value={this.state.newNearestLandmark}
                    onChange={(e) => {
                      this.newAddressHanleChange(e);
                    }}
                  />
                </div>
                {/* End .form-group */}
                <div className="form-group required-field">
                  <label>{default_strings.PROVINCE}</label>
                  <div className="select-custom">
                    <select
                      className="form-control"
                      required
                      value={this.state.newSelectedProvince}
                      onChange={(e) => this.handleNewProvinceDropdownChange(e)}
                    >
                      {optionsProvince}
                    </select>
                  </div>
                </div>
                <div className="form-group required-field">
                  <label>City</label>
                  <div className="select-custom">
                    <select
                      className="form-control"
                      required
                      value={this.state.newSelectedCity}
                      onChange={(e) => this.handleNewCityDropdownChange(e)}
                    >
                      <option value=""></option>
                      {optionsNewAddressCities}
                    </select>
                  </div>
                </div>
                <div className="form-group required-field">
                  <label>{default_strings.POSTAL} </label>
                  <input
                    type="text"
                    maxLength = "10"
                    value={this.state.newPostalCode}
                    required
                    name="newPostalCode"
                    className="form-control"
                    onChange={(e) => {
                      this.newAddressHanleChange(e);
                    }}
                  />
                </div>
                {/* End .form-group */}
                <div className="checkout-steps-action">
                  <a
                    href="#"
                    className="btn btn-block btn-outline-secondary"
                    onClick={(e) => {
                      this.saveNewAddress();
                    }}
                  >
                    Save
                  </a>
                </div>
                {/* End .checkout-steps-action */}
                <input type="submit" ref={this.NewAddressSubmit} hidden />
              </form>
            </div>
          </div>
        </Modal>
        {/* <h2>Account Information</h2> */}
        <div className="mb-4" />
        {/* margin */}
        <div className="card">
          {propShowAddressHeader ? (
            <div className="card-header address_managment_header">
              Address Management
              <a
                href="#"
                className="card-edit"
                onClick={(e) => {
                  this.setState({
                    openModal: true,
                  });
                }}
              >
                Add New Address
              </a>
            </div>
          ) : (
            <></>
          )}
          {propShowExisting ? (
            <div className="card-body address_managment_body">
              {(() => {
                let addressItem = [];
                if (this.state.addressDetail.length == 0) {
                  <p>
                    <div className="row">
                      <span>
                        <p>No Record Found</p>
                      </span>
                    </div>
                  </p>;
                } else {
                  let itr = 0;
                  for (let item of this.state.addressDetail) {
                    itr++;
                    let optionsCities = [];
                    let k = 1;
                    if (item.listCities && item.listCities.length > 0) {
                      for (let Citem of item.listCities) {
                        optionsCities.push(
                          <option key={k} value={Citem.LocationID}>
                            {Citem.LocationName}
                          </option>,
                        );
                        k++;
                      }
                    }
                    let addressCity = item.listCities
                      ? item.listCities.find((a) => a.LocationID == item.CityID)
                      : '';
                    let addressProvince = this.state.listProvinces.find(
                      (a) => a.LocationID == item.ProvinceID,
                    );
                    let computedStyle =
                      itr == this.state.addressDetail.length
                        ? { marginBottom: '0px' }
                        : {};
                    addressItem.push(
                      <div
                        key={itr}
                        className="default_address_section address_section_margin"
                        style={computedStyle}
                      >
                        <div className="row">
                          <div className="col-sm-9 address_section">
                            <p>
                              {item.PlotNumber}, {item.StreetNumber}, {item.NearestLandmark}{' '}
                            </p>
                            <p>
                              {item.PostalCode},{' '}
                              {addressCity ? addressCity.LocationName : ''},{' '}
                              {addressProvince
                                ? addressProvince.LocationName
                                : ''}
                            </p>
                            <p>{countries[0].countryName}</p>
                          </div>
                          <div className="col-sm-3 ">
                            {propShowSelection ? (
                              <div
                                className="inputGroup"
                                style={{
                                  marginBottom: '5px',
                                  marginRight: '15px',
                                  marginLeft: '-30px',
                                }}
                              >
                                <input
                                  checked={
                                    this.state.selectedAddressID ==
                                    item.AddressID
                                      ? true
                                      : false
                                  }
                                  id={'Dispatch' + itr}
                                  name={'Dispatch' + itr}
                                  type="checkbox"
                                  className="custom-control-input"
                                  onClick={() => {
                                    this.handleCheck(item);
                                    this.props.handleAddressSelection(item);
                                  }}
                                />
                                <label htmlFor={'Dispatch' + itr} style={{fontSize: '16px'}}>
                                  Dispatch Here
                                </label>
                              </div>
                            ) : (
                              <></>
                            )}

                            <p className="editable_buttons">
                              <a
                                href="#"
                                onClick={(e) => {
                                  e.preventDefault();
                                  item.ShowHideDiv = item.ShowHideDiv
                                    ? false
                                    : true;
                                  this.setState({
                                    addressDetail: this.state.addressDetail,
                                  });
                                }}
                              >
                                {item.ShowHideDiv ? 'Close' : 'Edit'}
                              </a>
                              <a
                                href="#"
                                onClick={(e) => {
                                  this.deleteAddress(item.AddressID);
                                }}
                              >
                                Delete
                              </a>
                            </p>
                          </div>
                        </div>
                        {item.ShowHideDiv ? (
                          <div className="row address_managmentrow">
                            <form
                              ref={item.FormRef}
                              action="#"
                              className="col-lg-12"
                            >
                              <div className="form-group required-field">
                                <label>Street Number </label>
                                <input
                                  type="text"
                                  maxLength = "200"
                                  className="form-control"
                                  required
                                  onInvalid={(e) => {
                                    e.target.scrollIntoViewIfNeeded();
                                  }}
                                  required
                                  value={item.StreetNumber}
                                  onChange={(e) => {
                                    this.handleTextChange(
                                      e,
                                      item,
                                      'StreetNumber',
                                    );
                                  }}
                                />
                              </div>
                              {/* End .form-group */}
                              <div className="form-group required-field">
                                <label>Street Name </label>
                                <input
                                  type="text"
                                  maxLength = "200"
                                  className="form-control"
                                  required
                                  value={item.PlotNumber}
                                  onChange={(e) => {
                                    this.handleTextChange(
                                      e,
                                      item,
                                      'PlotNumber',
                                    );
                                  }}
                                />
                              </div>
                              {/* End .form-group */}
                              <div className="form-group ">
                                <label>Apartment / Suite / Unit (optional)</label>
                                <input
                                  onInvalid={(e) => {
                                    e.target.scrollIntoViewIfNeeded();
                                  }}
                                  type="text"
                                  maxLength = "200"
                                  className="form-control"
                                  required
                                  onChange={(e) => {
                                    this.handleTextChange(
                                      e,
                                      item,
                                      'NearestLandmark',
                                    );
                                  }}
                                  value={item.NearestLandmark}
                                />
                              </div>
                              {/* End .form-group */}
                              <div className="form-group">
                                            <label>{default_strings.PROVINCE}</label>
                                <div className="select-custom">
                                  <select
                                    className="form-control"
                                    onInvalid={(e) => {
                                      e.target.scrollIntoViewIfNeeded();
                                    }}
                                    value={item.ProvinceID}
                                    required
                                    onChange={(e) =>
                                      this.handleProvinceDropdownChange(e, item)
                                    }
                                  >
                                    {optionsProvince}
                                  </select>
                                </div>
                                {/* End .select-custom */}
                              </div>
                              {/* End .form-group */}
                              <div className="form-group required-field">
                                <label>City</label>
                                <div className="select-custom">
                                  <select
                                    className="form-control"
                                    onInvalid={(e) => {
                                      e.target.scrollIntoViewIfNeeded();
                                    }}
                                    required
                                    value={item.CityID}
                                    onChange={(e) =>
                                      this.handleCityDropdownChange(e, item)
                                    }
                                  >
                                    {optionsCities}
                                  </select>
                                </div>
                                {/* End .select-custom */}
                              </div>
                              {/* End .form-group */}
                              <div className="form-group required-field">
                                <label>{default_strings.POSTAL} </label>
                                <input
                                  type="text"
                                  maxLength = "10"
                                  onInvalid={(e) => {
                                    e.target.scrollIntoViewIfNeeded();
                                  }}
                                  className="form-control"
                                  required
                                  value={item.PostalCode}
                                  onChange={(e) => {
                                    this.handleTextChange(
                                      e,
                                      item,
                                      'PostalCode',
                                    );
                                  }}
                                />
                              </div>
                              {/* End .form-group */}
                              <div className="checkout-steps-action">
                                <a
                                  href=""
                                  className="btn btn-block btn-outline-secondary"
                                  onClick={(e) => {
                                    e.preventDefault();
                                    this.updateAddressItem(e, item);
                                  }}
                                >
                                  Save
                                </a>
                              </div>
                              {/* End .checkout-steps-action */}
                              <input type="submit" hidden />
                            </form>
                          </div>
                        ) : (
                          <></>
                        )}
                      </div>,
                    );
                  }
                }
                return addressItem;
              })()}

              {/* End .row */}
            </div>
          ) : (
            <></>
          )}
        </div>
        {/* End .card */}
      </div>
    );
  }
}

export default AddressManagement;
