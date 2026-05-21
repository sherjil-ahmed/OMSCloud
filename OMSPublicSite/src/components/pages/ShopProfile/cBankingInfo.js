import React from 'react';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SUPPLIER_ID,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  PROFILE_ID,
  USER_PROFILE,
  SIZE
} from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';
import izitoast from 'izitoast';
import { getStorageItem } from '../../../utils/storageHelper';
import { countries, default_strings } from '../../../utils/globalConstants';

class BankingInformation extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      user: getStorageItem(USER_PROFILE),
      bankName: '',
      bankAddress: '',
      acctHolderName: '',
      acctNumber: '',
      acctType: '',
      IBAN: '',
      IsNew: false,
      bankID: '',
      bankingInfo: [],
      openModal: false,
      currentRegion: {},
      //Tax
      taxConsent: 'false',
      taxRegistration: '',
      taxInfo: [],
    };
  }
  componentDidMount() {
    this.getShopTaxInfo();
    this.getAllBankingInfo();
    this.setState({
      currentRegion: countries.find((a) => a.countryId == 0),
    });
  }
  getShopTaxInfo = () => {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Supplier_GetShopTaxInfo + this.state.user.ShopId,
      null,
      this.successTaxInfo,
    );
  };
  successTaxInfo = (res) => {
    if (res) {
      this.setState({
        taxInfo: res,
        taxConsent: res.TaxConsent.toString(),
        taxRegistration: res.TaxRegistration,
      });
    }
  };

  getAllBankingInfo = () => {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.BackAccount_GetBankAccountByShopId +
        this.state.user.ShopId,
      null,
      this.successBankingInfo,
    );
  };
  successBankingInfo = (res) => {
    if (res) {
      this.setState({
        bankingInfo: res,
        bankName: res.Name,
        bankID: res.BankId,
        bankAddress: res.Address,
        acctHolderName: res.AccountTitle,
        acctNumber: res.AccountNumber,
        acctType: res.AccountTypeId,
        IBAN: res.IBAN,
      });
    } else {
      this.setState({
        IsNew: true,
      });
    }
  };

  handleTextChange(e) {
    this.setState(
      {
        [e.target.name]: e.target.value,
      },
      () => {},
    );
  }
  saveBankingInfo = () => {
    let reqObj = {
      SupplierId: this.state.user.ShopId,
      RequestedByProfileId: getStorageItem(PROFILE_ID),
      Name: this.state.bankName,
      Address: this.state.bankAddress,
      AccountTitle: this.state.acctHolderName,
      AccountNumber: this.state.acctNumber,
      AccountTypeId: this.state.acctType,
      BankId: this.state.bankID,
      IBAN: this.state.IBAN,
    };
    if (this.state.IsNew) {
      FetchData(
        REQUEST_TYPE.PUT,
        SERVICE_ENDPOINTS.BankAccount_AddBankAccount,
        reqObj,
        this.successSavedInfoItem,
      );
    } else {
      FetchData(
        REQUEST_TYPE.POST,
        SERVICE_ENDPOINTS.BankAccount_UpdateBankAccount,
        reqObj,
        this.successSavedInfoItem,
      );
    }
  };
  saveTaxInfo = () => {
    let reqObj = {
      RequestedByProfileId: getStorageItem(PROFILE_ID),
      SupplierID: this.state.user.ShopId,
      TaxConsent: this.state.taxConsent,
      TaxRegistration: this.state.taxRegistration,
      CreatedBy: this.state.taxInfo.CreatedBy,
      CreatedOn: this.state.taxInfo.CreatedOn,
      ModifiedBy: this.state.taxInfo.ModifiedBy,
      ModifiedOn: this.state.taxInfo.ModifiedOn,
    };
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Supplier_UpdateShopTaxInfo,
      reqObj,
      this.successSavedInfoItem,
    );
  };
  successSavedInfoItem = (res) => {
    if (res != null) {
      this.getAllBankingInfo();
      this.getShopTaxInfo();
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.SUCCESS,
        message: 'Information Saved Successfully',
        target: '.testtarget',
        color: COLOR.GREEN,
        messageSize: SIZE.FONT_SIZE
      });
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

  render() {
    let cRegion = this.state.currentRegion;
    return (
      <div className="col-lg-9 order-lg-last dashboard-content">
        <div className="mb-4" />
        {/* margin */}
        <div className="form-group">
          <label className="mr-4">Tax Consent</label>
          <input
            onInvalid={(e) => {
              e.target.scrollIntoViewIfNeeded();
            }}
            type="radio"
            checked={this.state.taxConsent == 'true'}
            required
            className="mr-2"
            onChange={(e) => {
              this.handleTextChange(e);
            }}
            name="taxConsent"
            value={true}
          />
          <label className="mr-4">Yes</label>
          <input
            onInvalid={(e) => {
              e.target.scrollIntoViewIfNeeded();
            }}
            type="radio"
            required
            checked={this.state.taxConsent == 'false'}
            className="mr-2"
            onChange={(e) => {
              this.handleTextChange(e);
            }}
            name="taxConsent"
            value={false}
          />
          <label>No</label>
          </div>
        <div className="form-group">
          <span>If you have tax registration number, select "Yes" and we will return you the sales tax collected on your sale</span>
        </div>
        <div className="form-group">
          <label>Tax Registration Number </label>
          <input
            onInvalid={(e) => {
              e.target.scrollIntoViewIfNeeded();
            }}
            type="text"
            maxLength="200"
            className="form-control"
            required
            onChange={(e) => {
              this.handleTextChange(e);
            }}
            name="taxRegistration"
            value={this.state.taxRegistration}
          />
        </div>
        <div className="checkout-steps-action">
          <a
            href="#"
            className="btn btn-block btn-outline-secondary"
            onClick={(e) => {
              this.saveTaxInfo();
            }}
          >
            {this.state.IsNew ? 'Add' : 'Save'}
          </a>
        </div>
        <hr />
        <div className="form-group mt-2">
          <label>Bank Name </label>
          <input
            onInvalid={(e) => {
              e.target.scrollIntoViewIfNeeded();
            }}
            type="text"
            maxLength="200"
            className="form-control"
            required
            onChange={(e) => {
              this.handleTextChange(e);
            }}
            name="bankName"
            value={this.state.bankName}
          />
        </div>
        <div className="form-group">
          <label>Bank Address </label>
          <input
            onInvalid={(e) => {
              e.target.scrollIntoViewIfNeeded();
            }}
            type="text"
            maxLength="500"
            className="form-control"
            required
            onChange={(e) => {
              this.handleTextChange(e);
            }}
            name="bankAddress"
            value={this.state.bankAddress}
          />
        </div>
        <div className="form-group">
          <label>Account Holder Name </label>
          <input
            onInvalid={(e) => {
              e.target.scrollIntoViewIfNeeded();
            }}
            type="text"
            maxLength="200"
            className="form-control"
            required
            onChange={(e) => {
              this.handleTextChange(e);
            }}
            name="acctHolderName"
            value={this.state.acctHolderName}
          />
        </div>
        
        <div className="form-group">
          <label>{default_strings.IBAN}</label>
          <input
            onInvalid={(e) => {
              e.target.scrollIntoViewIfNeeded();
            }}
            type="number"
            className="form-control"
            required
            onChange={(e) => {
              this.handleTextChange(e);
            }}
            name="IBAN"
            value={this.state.IBAN}
          />
        </div>
        <div className="form-group">
          <label>Institution Name and Account Number</label>
          <input
            onInvalid={(e) => {
              e.target.scrollIntoViewIfNeeded();
            }}
            type="text"
            maxLength="200"
            className="form-control"
            required
            onChange={(e) => {
              this.handleTextChange(e);
            }}
            name="acctNumber"
            value={this.state.acctNumber}
          />
        </div>

        <div className="form-group">
          <label>Account Type</label>
          <select
            name="selectedAccountType"
            value={this.state.selectedCategory}
            onChange={(e) => {
              this.handleTextChange(e);
            }}
            className="form-control"
            name="acctType"
            value={this.state.acctType}
          >
                    <option value="-1">N/A</option>
                    <option value="0">Business Chequing</option>
                    <option value="1">Business Saving</option>
                    <option value="2">Personal Chequing</option>
                    <option value="3">Personal Saving</option>
           </select>
        </div>
        <div className="checkout-steps-action">
          <a
            href="#"
            className="btn btn-block btn-outline-secondary"
            onClick={(e) => {
              this.saveBankingInfo();
            }}
          >
            {this.state.IsNew ? 'Add' : 'Save'}
          </a>
        </div>
      </div>
    );
  }
}
export default BankingInformation;
