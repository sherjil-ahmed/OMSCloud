import React from 'react';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import {
  LIST_PROVINCES,
  PROFILE_ID,
  LIST_CITIES,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SELECTED_COUNTRY_VALUE,
  SELECTED_PROVINCE,
  SELECTED_CITY,
  IS_USER_LOGGEDIN,
  SUPPLIER_ID,
  SELECTED_LANG,
} from '../../../utils/constants';
import {
  allLanguages,
  countries,
  default_currency,
  default_language,
} from '../../../utils/globalConstants';
import { FetchData } from '../../../utils/serviceHelper';
import { LocationLevelEnum } from '../../../utils/enums';
import { default_strings } from '../../../utils/globalConstants';

class HeaderTop extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      doesSessionExists: getStorageItem(IS_USER_LOGGEDIN) ? true : false,
      supplierId: getStorageItem(SUPPLIER_ID),
      selectedProvinceValue: getStorageItem(SELECTED_PROVINCE)
        ? getStorageItem(SELECTED_PROVINCE)
        : '',
      selectedCountryValue: SELECTED_COUNTRY_VALUE,
      selectedCityValue: getStorageItem(SELECTED_CITY)
        ? getStorageItem(SELECTED_CITY)
        : '',
      listProvinces: getStorageItem(LIST_PROVINCES)
        ? getStorageItem(LIST_PROVINCES)
        : [],
      listCities: getStorageItem(LIST_CITIES)
        ? getStorageItem(LIST_CITIES)
        : [],
      selectedLanguage: getStorageItem(SELECTED_LANG)? getStorageItem(SELECTED_LANG) :default_language.text,
    };
  }

  handleDropdownChange = (e) => {
    window.location.href = e.target.selectedOptions[0].getAttribute(
      'customurl',
    );
  };

  successGetProvinceList = (res) => {
    let _listCities = this.state.listCities;
    _listCities = res;
    this.setState({ listCities: _listCities }, () => {
      setStorageItem(SELECTED_PROVINCE, this.state.selectedProvinceValue);
      setStorageItem(LIST_CITIES, this.state.listCities);
      removeStorageItem(SELECTED_CITY);
    });
  };

  handleProvinceDropdownChange = (e) => {
    this.setState({ selectedProvinceValue: e.target.value }, () => {
      let idParent = LocationLevelEnum.City;
      let idChild = this.state.selectedProvinceValue;
      FetchData(
        REQUEST_TYPE.GET,
        SERVICE_ENDPOINTS.LocationTree_GetLocationList +
          idParent +
          '/' +
          idChild,
        null,
        this.successGetProvinceList,
      );
    });
  };

  handleCityDropdownChange = (e) => {
    this.setState(
      {
        selectedCityValue: e.target.value,
      },
      () => {
        setStorageItem(SELECTED_CITY, this.state.selectedCityValue);
      },
    );
  };

  successGetCityList = (res) => {
    let sessionProfile = getStorageItem(IS_USER_LOGGEDIN);
    let _listProvinces = this.state.listProvinces;

    _listProvinces = res;
    this.setState(
      {
        listProvinces: _listProvinces,
        doesSessionExists: sessionProfile ? true : false,
      },
      () => {
        setStorageItem(LIST_PROVINCES, this.state.listProvinces);
        removeStorageItem(SELECTED_PROVINCE);
        removeStorageItem(SELECTED_CITY);
      },
    );
  };

  componentDidMount() {
    let sessionProfile = getStorageItem(IS_USER_LOGGEDIN);
    if (!(this.state.listProvinces && this.state.listProvinces.length > 0)) {
      let idParent = LocationLevelEnum.Province;
      let idChild = this.state.selectedCountryValue;
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
      this.setState(
        {
          doesSessionExists: sessionProfile ? true : false,
        },
        () => {},
      );
    }

    if (!(this.state.listCities && this.state.listCities.length > 0)) {
    }
  }

  render() {
    let optionsCountry = [];
    let optionsProvince = [];
    let optionsCities = [];
    let j = 1,
      k = 1;
    for (let i = 0; i < countries.length; i++) {
      optionsCountry.push(
        <option
          customurl={countries[i].redirectURL}
          value={countries[i].countryId}
          key={i}
        >
          {countries[i].countryName}
        </option>,
      );
    }
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
    if (this.state.listCities && this.state.listCities.length > 0) {
      for (let Citem of this.state.listCities) {
        optionsCities.push(
          <option value={Citem.LocationID} key={k}>
            {Citem.LocationName}
          </option>,
        );
        k++;
      }
    }
    return (
      <div className="header-top">
        <div className="select_top_wrp container-fluid">
          <div className="inner_wrp">
            <div className="row">
              <div className="col-sm-2">
                <div className="header-dropdowns">
                  <div className="header-dropdown h-top">
                    <span style={{ color: '#fff', fontWeight: '600' }}>
                      {default_currency.text}
                    </span>
                    {/* <div className="header-menu">
                      <ul>
                        <li>
                          <a href="#">EUR</a>
                        </li>
                        <li>
                          <a href="#">USD</a>
                        </li>
                      </ul>
                    </div> */}
                    {/* End .header-menu */}
                  </div>
                  {/* End .header-dropown */}
                  <div className="header-dropdown h-top">
                    <a href="#">{this.state.selectedLanguage}</a>
                    <div className="header-menu">
                      <ul>
                        {allLanguages.map((lang, langIter) => (
                          <li key={langIter}>
                            <a
                              href=""
                              onClick={(e) => {
                                e.preventDefault();
                                setStorageItem(SELECTED_LANG,lang.text)
                                this.setState({
                                  selectedLanguage: lang.text,
                                });
                                window.handleLanguageChange(lang.id);
                              }}
                            >
                              {lang.text}
                            </a>
                          </li>
                        ))}
                        {/* 
                        <li>
                          <a
                            href=""
                            onClick={(e) => {
                              e.preventDefault();
                              window.handleLanguageChange('en');
                            }}
                          >
                            ENGLISH
                          </a>
                        </li>
                        <li>
                          <a
                            href=""
                            onClick={(e) => {
                              e.preventDefault();
                              window.handleLanguageChange('fr');
                            }}
                          >
                            FRENCH
                          </a>
                        </li> */}
                      </ul>
                    </div>
                    {/* End .header-menu */}
                  </div>
                  {/* End .header-dropown */}
                </div>
              </div>

              <div className="col-sm-7 top_header_search_bar">
                <div className="header-search head-top-search">
                  <a href="#" className="search-toggle ttog" role="button">
                    <i className="icon-magnifier" />
                  </a>
                  <form action="#" method="get">
                    <div className="header-search-wrapper header-top-form">
                      <div className="select-custom">
                        <select
                          className="Country"
                          id="Country"
                          style={{ border: '0px solid' }}
                          value={this.state.selectedCountryValue} //changed for api, value = "0"
                          onChange={(e) => this.handleDropdownChange(e)}
                        >
                          <option className="test">Country</option>
                          {optionsCountry}
                        </select>
                      </div>
                      <div className="select-custom">
                        <select
                          className="Province"
                          id="Province"
                          value={this.state.selectedProvinceValue}
                          onChange={(e) => this.handleProvinceDropdownChange(e)}
                        >
                          <option value="">{default_strings.PROVINCE}</option>
                          {optionsProvince}
                        </select>
                      </div>
                      {/* End .select-custom */}
                      <div className="select-custom">
                        <select
                          className="City"
                          id="City"
                          value={this.state.selectedCityValue}
                          onChange={(e) => this.handleCityDropdownChange(e)}
                        >
                          <option value="">City</option>
                          {optionsCities}
                        </select>
                      </div>
                    </div>
                    {/* End .header-search-wrapper */}
                  </form>
                </div>
              </div>
              <div className="col-sm-3">
                <div className="header-right">
                  {
                    //console.log('sherjil log this.state.supplierId :::: ' + this.state.supplierId ),
                  this.state.doesSessionExists && this.state.supplierId  ? (
                    <a
                      href="#"
                      className="bcmsel_btntop"
                      onClick={() => {
                        window.location.href = '/CreateShop';
                      }}
                    >
                      <i className="fas fa-store" />
                      Manage your Shop
                    </a>
                  ) : (
                    <a
                      href="#"
                      className="bcmsel_btntop"
                      onClick={() => {
                        this.state.doesSessionExists ? (window.location.href = '/CreateShop') :(window.location.href = '/LoginSignup');
                      }}
                    >
                      <i className="fas fa-store" />
                      Open your Shop
                    </a>
                  )}
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default HeaderTop;
