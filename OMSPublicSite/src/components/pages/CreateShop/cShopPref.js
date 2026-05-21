import React from 'react';
import { countries, default_currency, default_language } from '../../../utils/globalConstants';

// const LanguageMapping = [
//   {
//     id: '1',
//     mnemonic: 'ENG',
//     description: 'English',
//   },
//   {
//     id: '2',
//     mnemonic: 'UR',
//     description: 'Urdu',
//   },
// ];

// const CurrencyMapping = [
//   {
//     id: '1',
//     mnemonic: 'USD',
//     description: 'US Dollar',
//   },
//   {
//     id: '2',
//     mnemonic: 'PKR',
//     description: 'Pakistani Rupee',
//   },
// ];

// const CountryMapping = [
//   {
//     id: '0',
//     mnemonic: 'CN',
//     description: 'Canada',
//   },
// ];

class ShopPref extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      country: '',
      language: '',
      currency: '',
    };
  }

  componentDidMount() {
    window.scrollTo(0, 0);
    // let _country = this.setCountry();
    // let _language = this.setLanguage();
    // let _currency = this.setCurrency();

    // this.setState({
    //   country: _country,
    //   language: _language,
    //   currency: _currency,
    // });
  }

  // setCountry = () => {
  //   let _state = this.props.parentState.Supplier;
  //   return CountryMapping.find((a) => a.id == _state.CountryID).description;
  // };

  // setLanguage = () => {
  //   let _state = this.props.parentState.Supplier;
  //   return LanguageMapping.find((a) => a.id == _state.LanguageID).description;
  // };

  // setCurrency = () => {
  //   let _state = this.props.parentState.Supplier;
  //   return CurrencyMapping.find((a) => a.id == _state.CurrencyID).description;
  // };

  render() {
    return (
      <div className="body">
        <div className="col-sm-12 npad">
          <div className="row">
            <div className="col-md-4">
              <div className="form-group">
                <label htmlFor="acc-mname">Shop country</label>
                <input
                  disabled
                  name="country"
                  type="text"
                  className="form-control"
                  defaultValue={countries.find(a=> a.countryId == "0").countryName}
                  placeholder="Country (Canada)"
                />
              </div>
              {/* End .form-group */}
            </div>
            {/* End .col-md-4 */}
            <div className="col-md-4">
              <div className="form-group">
                <label htmlFor="acc-name">Shop language</label>
                <input
                  disabled
                  name="language"
                  type="text"
                  className="form-control"
                  defaultValue={default_language.text}
                  placeholder="Language"
                />
              </div>
              {/* End .form-group */}
            </div>
            {/* End .col-md-4 */}
            <div className="col-md-4">
              <div className="form-group">
                <label htmlFor="acc-lastname">Shop currency</label>
                <input
                  disabled
                  name="currency"
                  type="text"
                  className="form-control"
                  defaultValue={default_currency.text + " ("+default_currency.symbol+")"}
                  placeholder="Currency"
                />
              </div>
              {/* End .form-group */}
            </div>
            {/* End .col-md-4 */}
          </div>
          {/* End .row */}
        </div>
      </div>
    );
  }
}

export default ShopPref;
