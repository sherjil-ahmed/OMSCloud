import React from 'react';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import ShopPref from './cShopPref';
import ShopBasic from './cShopBasic';
import ShopAddress from './cShopAddress';
import ShopDelivery from './cShopDelivery';
import ShopMail from './cShopMail';
import ShopPayment from './cShopPayment';
//import ShopSchedule from './cShopSchedule';
import ShopProducts from './cShopProducts';
import Wizard from '../../customControls/Wizard/Wizard';
import { Helmet } from 'react-helmet';
import { FetchData } from '../../../utils/serviceHelper';
import { default_strings } from '../../../utils/globalConstants';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SUPPLIER_ID,
  PRODUCT_ID,
  PROFILE_ID,
  DIRECT_PRODUCTS,
  SUPPLIER_NAME,
} from '../../../utils/constants';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import { DeliveryOptionEnum } from '../../../utils/enums';

const enWIZARD_KEYS = {
  Preferences: 'Preferences',
  Basic: 'Basic',
  Address: 'Address',
  Delivery: 'Delivery',
  Mail: 'Mail',
  Payment: 'Payment',
  Schedule: 'Schedule',
  Products: 'Products',
};

class CreateShop extends React.Component {
  constructor(props) {
    super(props);
    this.steps = null;
    this.lastMaxStep = enWIZARD_KEYS.Basic;
    this.resolve = null;
    this._Supplier = null;
    this.state = {
      Supplier: {
        SupplierID: getStorageItem(SUPPLIER_ID),
        LanguageID: '1', //need to access this from session
        CurrencyID: '1', //need to access this from session
        CountryID: '0',
        SupplierName: '',
        Logo: null,
        Description: '',
        StatusID: '1', //default active
        StatusNotes: null,
        BusinessAddressID: '',
        IsBusinessAddressVisible: false,
        OperatingLanguageID: null,
        OperatingCurrencyID: null,
        IsCOD: false,
        ProfileID: getStorageItem(PROFILE_ID), //need to get this from session
        ProcessingFee: '',
        PaymentGatewayFee: '',
        IsProcessingFeePercentage: true, //setting it true for now (needs to be corrected in API)
        IsPaymentGatewayFeePercentage: false,
        CreatedBy: '',
        CreatedOn: null,
        ModifiedBy: '',
        ModifiedOn: null,
        RequestedByProfileId: getStorageItem(PROFILE_ID), //need to be same as ProfileID
      },

      Address: {
        ShopID: getStorageItem(SUPPLIER_ID),
        AddressID: null,
        ProfileID: getStorageItem(PROFILE_ID), //need to get this from session
        AddressTypeID: '1', //
        ProvinceID: '',
        CityID: '',
        PlotNumber: '',
        StreetNumber: '',
        LocationID: '',
        NearestLandmark: '',
        PostalCode: '',
        MapLink: '',
        IDForStatus: '',
        IsBusinessAddressVisible: false,
        RequestedByProfileId: getStorageItem(PROFILE_ID), //need to be same as ProfileID
      },

      Products: [],

      listProvinces: [],
      listCities: [],
      Delivery: [],
      activeStep: '',
      completedsteps: [],
      statusID: '',
      postalCodeerror: ""
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
  ValidateBasic = () => {
    return (
      this.state.Supplier.SupplierName &&
      this.state.Supplier.SupplierName != '' &&
      this.state.Supplier.Description &&
      this.state.Supplier.Description != ''
    );
  };

  ValidateAddress = () => {
    
    //validate atleast if the shop has been created
    
      return this.state.Supplier.SupplierID;
    
  };

  ValidateDelivery = () => {
    console.log(this.state.Delivery)
    if(this.state.Delivery.length > 0){
      return true;
    }
    else{return false;}
    /*
    else{
      let _model = {
        SupplierDeliveryOptionPairID: '',
        SupplierID: this.state.Supplier.SupplierID,
        SupplierName: this.state.Supplier.SupplierName,
        DeliveryOptionID: '',
        DeliveryOptionTitle: '',
        DeliveryCharges: '',
        MinOrderLimit: '',
        SurroundingCities: '',
        SurroundingCitiesIDs: '',
        RequestedByProfileId: this.state.Supplier.RequestedByProfileId,
      };
      _model.DeliveryOptionID = DeliveryOptionEnum.SelfPickUp;
      _model.DeliveryOptionTitle = "SelfPickUp";
      this.state.Delivery.push(_model);
      return true;ppp
    }*/
  };

  ValidateMail = () => {
    return this.state.Delivery.length > 0;
  };

  ValidatePayment = () => {
    return true;
  };

  // ValidateSchedule = ()=>{
  //     return true;
  // }

  ///////////////////////VALIDATE END///////////////////////////////
  /////////////////////PREV BEGIN//////////////////////////////////

  BasicPrev = () => {
    this.setActiveStep(enWIZARD_KEYS.Preferences);
  };

  AddressPrev = () => {
    this.setActiveStep(enWIZARD_KEYS.Basic);
  };

  DeliveryPrev = () => {
    this.setActiveStep(enWIZARD_KEYS.Address);
  };

  MailPrev = () => {
    this.setActiveStep(enWIZARD_KEYS.Delivery);
  };

  PaymentPrev = () => {
    this.setActiveStep(enWIZARD_KEYS.Delivery);
  };

  // SchedulePrev = () =>{
  //     this.setActiveStep(enWIZARD_KEYS.Payment);
  // }

  ProductsPrev = () => {
    this.setActiveStep(enWIZARD_KEYS.Payment);
  };
  //////////////////////PREV END/////////////////////////////////
  /////////////////////NEXT BEGIN////////////////////////////////

  PreferencesNext = () => {
    this.setActiveStep(enWIZARD_KEYS.Basic);
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Preferences),
    );
    _completedsteps.push(enWIZARD_KEYS.Preferences);
    this.setState({
      completedsteps: _completedsteps,
    });
  };

  successSupplierInsert = (res) => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Basic),
    );
    let _Supplier = this.state.Supplier;
    let _Address = this.state.Address;

    _Supplier.SupplierID = res;
    _Address.ShopID = res;
    _completedsteps.push(enWIZARD_KEYS.Basic);

    this.setState(
      {
        Supplier: _Supplier,
        Address: _Address,
        activeStep: enWIZARD_KEYS.Address,
        completedsteps: _completedsteps,
      },
      () => {
        this.setMaxStep(enWIZARD_KEYS.Address);
        setStorageItem(SUPPLIER_ID, this.state.Supplier.SupplierID);
      },
    );
  };

  successSupplierPost = (res) => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Basic),
    );

    _completedsteps.push(enWIZARD_KEYS.Basic);
    this.setState(
      {
        activeStep: enWIZARD_KEYS.Address,
        completedsteps: _completedsteps,
      },
      () => {
        this.setMaxStep(enWIZARD_KEYS.Address);
      },
    );
  };

  successGetSupplier = (res) => {
    //get latest data for concurrency control
    this.state.Supplier.CreatedBy = res.CreatedBy;
    this.state.Supplier.CreatedOn = res.CreatedOn;
    this.state.Supplier.ModifiedBy = res.ModifiedBy;
    this.state.Supplier.ModifiedOn = res.ModifiedOn;

    this.state.Supplier.StatusID =
      this.state.IDForStatus === 3 || this.state.IDForStatus === 4
        ? this.state.IDForStatus
        : 1;
    this.setState(
      {
        Supplier: this.state.Supplier,
      },
      () => {
        FetchData(
          REQUEST_TYPE.POST,
          SERVICE_ENDPOINTS.Supplier_Post,
          this.state.Supplier,
          this.successSupplierPost,
        );
      },
    );
  };

  BasicNext = () => {
    if (this.ValidateBasic()) {
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

  successAddressPost = (res) => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Address),
    );
    _completedsteps.push(enWIZARD_KEYS.Address);
    this.setState(
      {
        activeStep: enWIZARD_KEYS.Delivery,
        completedsteps: _completedsteps,
      },
      () => {
        this.setMaxStep(enWIZARD_KEYS.Delivery);
      },
    );
  };

  successGetAddress = (res) => {
    //get latest data for concurrency control
    this.state.Address.CreatedBy = res.CreatedBy;
    this.state.Address.CreatedOn = res.CreatedOn;
    this.state.Address.ModifiedBy = res.ModifiedBy;
    this.state.Address.ModifiedOn = res.ModifiedOn;

    this.setState(
      {
        Address: {...this.state.Address,}
      },
      () => {
        
        FetchData(
          REQUEST_TYPE.POST,
          SERVICE_ENDPOINTS.Address_Post,
          this.state.Address,
          this.successAddressPost,
        );
      },
    );
  };

  successAddressInsert = (res) => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Address),
    );
    let _Address = this.state.Address;
    _Address.AddressID = res;

    //update business addressid aswell in supplier

    let _Supplier = this.state.Supplier;
    _Supplier.BusinessAddressID = res;

    _completedsteps.push(enWIZARD_KEYS.Address);

    this.setState(
      {
        Address: _Address,
        Supplier: _Supplier,
        activeStep: enWIZARD_KEYS.Delivery,
        completedsteps: _completedsteps,
      },
      () => {
        this.setMaxStep(enWIZARD_KEYS.Delivery);
      },
    );
  };

  AddressNext = () => {
    if (this.ValidateAddress()) {
      if (this.state.Address.AddressID) {
        //shop address already created
        //concurrency
        
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Address_GetById + this.state.Address.AddressID,
          null,
          this.successGetAddress,
        );
      } else {
        FetchData(
          REQUEST_TYPE.PUT,
          SERVICE_ENDPOINTS.Address_Put,
          this.state.Address,
          this.successAddressInsert,
        );
      }
    } else {
    }
  };

  successSupplierDeliveryInsert = (res) => {
      //this.state.Delivery = res;
      this.setState({
          Delivery : res
      })
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Delivery),
    );
    _completedsteps.push(enWIZARD_KEYS.Delivery);

    this.setState(
      {
        activeStep: enWIZARD_KEYS.Payment,
        completedsteps: _completedsteps,
      },
      () => {
        this.setMaxStep(enWIZARD_KEYS.Payment);
      },
    );
  };

  DeliveryNext = () => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Delivery),
    );
    if (false) {
      //how to know this step was already done
      this.setActiveStep(enWIZARD_KEYS.Mail);
      _completedsteps.push(enWIZARD_KEYS.Delivery);
      this.setState({
        completedsteps: _completedsteps,
      });
    } else {
      
      if (this.ValidateDelivery()) {
        
        FetchData(
          REQUEST_TYPE.PUT,
          SERVICE_ENDPOINTS.SupplierDelivery_PutSupplierDeliveryOptionList,
          this.state.Delivery,
          this.successSupplierDeliveryInsert,
        );
      }
    }
  };

  successSupplierPost_Payment = (res2) => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Payment),
    );
    _completedsteps.push(enWIZARD_KEYS.Payment);

    this.setState(
      {
        activeStep: enWIZARD_KEYS.Products,
        completedsteps: _completedsteps,
      },
      () => {
        this.setMaxStep(enWIZARD_KEYS.Products);
      },
    );
  };

  successGetSupplier_Payment = (res) => {
    //get latest data for concurrency control
    this.state.Supplier.CreatedBy = res.CreatedBy;
    this.state.Supplier.CreatedOn = res.CreatedOn;
    this.state.Supplier.ModifiedBy = res.ModifiedBy;
    this.state.Supplier.ModifiedOn = res.ModifiedOn;

    this.setState(
      {
        Supplier: this.state.Supplier,
      },
      () => {
        FetchData(
          REQUEST_TYPE.POST,
          SERVICE_ENDPOINTS.Supplier_Post,
          this.state.Supplier,
          this.successSupplierPost_Payment,
        );
      },
    );
  };

  PaymentNext = () => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Payment),
    );
    if (false) {
      //how to know this step was already done

      _completedsteps.push(enWIZARD_KEYS.Payment);
      this.setState({
        completedsteps: _completedsteps,
      });
    } else {
      if (this.ValidatePayment()) {
        //concurrency
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Supplier_GetById + this.state.Supplier.SupplierID,
          null,
          this.successGetSupplier_Payment,
        );
      }
    }
  };

  // ScheduleNext = () =>{
  //     let _completedsteps = this.state.completedsteps.filter(a=> !(a==enWIZARD_KEYS.Schedule));
  //     if(false ){ //how to know this step was already done

  //         _completedsteps.push(enWIZARD_KEYS.Schedule);
  //         this.setState({
  //             completedsteps : _completedsteps
  //         })
  //     }
  //     else{
  //         if(this.ValidateSchedule()){
  //             _completedsteps.push(enWIZARD_KEYS.Schedule);

  //             this.setState({
  //                 activeStep : enWIZARD_KEYS.Products,
  //                 completedsteps : _completedsteps
  //             },()=>{
  //                 this.setMaxStep(enWIZARD_KEYS.Products)
  //             })
  //         }
  //     }
  // }

  //
  ProductsNext = () => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Products),
    );
    _completedsteps.push(enWIZARD_KEYS.Products);

    this.setState({
      completedsteps: _completedsteps,
    });

    if (true) {
      window.location.href = '/';
    }
  };

  renderWizardPrevNext = (activeStep) => {
    switch (activeStep) {
      case enWIZARD_KEYS.Preferences:
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.PreferencesNext}
            >
              Save & Continue
            </button>
          </div>
        );
      case enWIZARD_KEYS.Basic:
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-outline-dark custom-btn prebtn"
              onClick={this.BasicPrev}
            >
              Previous
            </button>
            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.BasicNext}
            >
              Save & Continue
            </button>
          </div>
        );
      case enWIZARD_KEYS.Address:
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-outline-dark custom-btn prebtn"
              onClick={this.AddressPrev}
            >
              Previous
            </button>
            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.AddressNext}
            >
              Save & Continue
            </button>
          </div>
        );
      case enWIZARD_KEYS.Delivery:
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-outline-dark custom-btn prebtn"
              onClick={this.DeliveryPrev}
            >
              Previous
            </button>
            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.DeliveryNext}
            >
              Save & Continue
            </button>
          </div>
        );
      // case  enWIZARD_KEYS.Mail :
      //     return (
      //         <div className="col-md-6 col-sm-12 navbuttonspot">

      //                 <button type="button" className="btn btn-outline-dark custom-btn prebtn" onClick={this.MailPrev}>Previous</button>

      //                 <button type="button" className="btn btn-primary nextbtn" onClick={this.MailNext}>Save & Continue</button>

      //         </div>
      //     )
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
      // case  enWIZARD_KEYS.Schedule :
      //     return (
      //         <div className="col-md-6 col-sm-12 navbuttonspot">
      //             <button type="button" className="btn btn-outline-dark custom-btn prebtn" onClick={this.SchedulePrev}>Previous</button>
      //             <button type="button" className="btn btn-primary nextbtn" onClick={this.ScheduleNext}>Save & Continue</button>
      //         </div>
      //     )
      case enWIZARD_KEYS.Products:
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-outline-dark custom-btn prebtn"
              onClick={this.ProductsPrev}
            >
              Previous
            </button>
            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.ProductsNext}
            >
              Save & Exit
            </button>
          </div>
        );
      default:
        return <div></div>;
    }
  };

  successGetSupplierByProfileId = (res) => {
    if (res) {
      
      this.state.Address.IsBusinessAddressVisible = res.IsBusinessAddressVisible
      //get a single object
      setStorageItem(SUPPLIER_ID, res.SupplierID);
      setStorageItem(SUPPLIER_NAME, res.SupplierName);
      this.setState(
        {
          IDForStatus: res.StatusID,
          Address : this.state.Address
        },
        () => {console.log("Address in Supplier by if",this.state.Address)},
      );
    }
    this.resolve();
  };

  successGetSupplierAddressDetails = (resPaddr) => {
    let completedsteps = this.state.completedsteps;
    let Address = {
      ShopID: getStorageItem(SUPPLIER_ID),
      AddressID: resPaddr.AddressID,
      ProfileID: getStorageItem(PROFILE_ID), //need to get this from session
      AddressTypeID: resPaddr.AddressTypeID, //
      ProvinceID: resPaddr.ProvinceID,
      CityID: resPaddr.CityID,
      PlotNumber: resPaddr.PlotNumber,
      StreetNumber: resPaddr.StreetNumber,
      LocationID: resPaddr.LocationID,
      NearestLandmark: resPaddr.NearestLandmark,
      PostalCode: resPaddr.PostalCode,
      MapLink: resPaddr.MapLink,
      StatusID: resPaddr.StatusID,
      RequestedByProfileId: getStorageItem(PROFILE_ID), //need to be same as ProfileID
      CreatedBy: resPaddr.CreatedBy,
      CreatedOn: resPaddr.CreatedOn,
      ModifiedBy: resPaddr.ModifiedBy,
      ModifiedOn: resPaddr.ModifiedOn,
      IsBusinessAddressVisible : this.state.Address.IsBusinessAddressVisible
    };
    completedsteps.push(enWIZARD_KEYS.Address);
    this.setState(
      {
        Address: Address,
        completedsteps: completedsteps,
      },
      () => {
        this.setMaxStep(enWIZARD_KEYS.Address);
      },
    );
  };

  successGetSupplierDeliveryDetails = (resPdelivery) => {
    let completedsteps = this.state.completedsteps;

    if (resPdelivery) {
      completedsteps.push(enWIZARD_KEYS.Delivery);

      if (this._Supplier.IsCOD) {
        completedsteps.push(enWIZARD_KEYS.Payment);
      }

      this.setState(
        {
          Delivery: resPdelivery,
          completedsteps: completedsteps,
        },
        () => {
          this.setMaxStep(enWIZARD_KEYS.Payment);
        },
      );
    }
  };

  successGetSupplierProducts = (resProducts) => {
    let completedsteps = this.state.completedsteps;
    if (resProducts) {
      completedsteps.push(enWIZARD_KEYS.Products);
      this.setState(
        {
          Products: resProducts,
          completedsteps: completedsteps,
        },
        () => {
          this.setMaxStep(enWIZARD_KEYS.Products);
        },
      );
    }
  };

  successGetSupplierDetails = (resP) => {
    let completedsteps = this.state.completedsteps;
    let sessionSupplierID = getStorageItem(SUPPLIER_ID);
    let Direct_Products = getStorageItem(DIRECT_PRODUCTS);

    if (resP) {
      let _Supplier = JSON.parse(JSON.stringify(resP));
      if (resP.StatusID == '3' || resP.StatusID == '4') {
        resP.StatusID = resP.StatusID;
      } else {
        resP.StatusID = '1';
      }

      _Supplier.RequestedByProfileId = getStorageItem(PROFILE_ID);
      _Supplier.LanguageID = '1';
      _Supplier.CurrencyID = '1';
      _Supplier.CountryID = '0';

      completedsteps.push(enWIZARD_KEYS.Preferences);
      completedsteps.push(enWIZARD_KEYS.Basic);

      let newState = {
        Supplier: _Supplier,
        activeStep: enWIZARD_KEYS.Preferences,
        completedsteps: completedsteps,
      };
      this.state.Address.IsBusinessAddressVisible = resP.IsBusinessAddressVisible
      this.setState({
        Address : this.state.Address
      })
      this._Supplier = _Supplier;

      if (
        resP.BusinessAddressID &&
        resP.BusinessAddressID != '' &&
        resP.BusinessAddressID != 0
      ) {
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Address_GetById + resP.BusinessAddressID,
          null,
          this.successGetSupplierAddressDetails,
        );
      }

      if (resP) {
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.SupplierDelivery_GetSupplierDeliveryOptionBySupplierId +
            sessionSupplierID,
          null,
          this.successGetSupplierDeliveryDetails,
        );
      }

      if (resP) {
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Product_GetLookupByShopId + sessionSupplierID,
          null,
          this.successGetSupplierProducts,
        );
      }

      this.setState(newState, () => {
        if (Direct_Products) {
          let _completedsteps = this.state.completedsteps;
          _completedsteps.push(enWIZARD_KEYS.Preferences);
          _completedsteps.push(enWIZARD_KEYS.Basic);
          _completedsteps.push(enWIZARD_KEYS.Address);
          _completedsteps.push(enWIZARD_KEYS.Delivery);
          _completedsteps.push(enWIZARD_KEYS.Mail);
          //   _completedsteps.push(enWIZARD_KEYS.Schedule);
          _completedsteps.push(enWIZARD_KEYS.Payment);
          this.setState(
            {
              completedsteps: _completedsteps,
              activeStep: enWIZARD_KEYS.Products,
            },
            () => {
              this.setMaxStep(enWIZARD_KEYS.Products);
            },
          );
        }
      });
    }
  };

  componentDidMount() {
    let ProfileID = getStorageItem(PROFILE_ID);

    if (ProfileID && ProfileID != '') {
      let _promise = new Promise((resolve, reject) => {
        this.resolve = resolve;
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Supplier_GetByProfileId + ProfileID,
          null,
          this.successGetSupplierByProfileId,
        );
      });

      _promise.then(() => {
        let sessionSupplierID = getStorageItem(SUPPLIER_ID);
        if (sessionSupplierID && sessionSupplierID != '') {
          FetchData(
            REQUEST_TYPE.GET,
            SERVICE_ENDPOINTS.Supplier_GetById + sessionSupplierID,
            null,
            this.successGetSupplierDetails,
          );
        } else {
          this.setState(
            {
              activeStep: enWIZARD_KEYS.Preferences,
            },
            () => {
              this.setMaxStep(enWIZARD_KEYS.Preferences);
            },
          );
        }
      });
    } else {
      this.setState(
        {
          activeStep: enWIZARD_KEYS.Preferences,
        },
        () => {
          this.setMaxStep(enWIZARD_KEYS.Preferences);
        },
      );
    }
  }

  render() {
    this.steps = [
      {
        title: 'Shop Preferences',
        rank: 1,
        name: enWIZARD_KEYS.Preferences,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <ShopPref parentState={this.state} setValues={this.setValues} />
        ),
      },
      {
        title: 'Shop Basic Information',
        rank: 2,
        name: enWIZARD_KEYS.Basic,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <ShopBasic parentState={this.state} setValues={this.setValues} />
        ),
      },
      {
        title: 'Shop Basic Information',
        rank: 3,
        name: enWIZARD_KEYS.Address,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <ShopAddress
            parentState={this.state}
            setValues={this.setValues}
            setValuesMany={this.setValuesMany}
          />
        ),
      },
      {
        title: 'Shop Local Delivery and Shipping Setup',
        rank: 4,
        name: enWIZARD_KEYS.Delivery,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <ShopDelivery parentState={this.state} setValues={this.setValues} />
        ),
      },
      // { title:"", rank:5, name: enWIZARD_KEYS.Mail, component: <ShopMail parentState={this.state} setValues={this.setValues}/>},
      {
        title: 'Payment Options',
        rank: 5,
        name: enWIZARD_KEYS.Payment,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <ShopPayment parentState={this.state} setValues={this.setValues} />
        ),
      },
      //  { title:"Shop Delivery Schedule", rank:6, name: enWIZARD_KEYS.Schedule, NextPrev: this.renderWizardPrevNext, component: <ShopSchedule parentState={this.state} setValues={this.setValues}/>},
      {
        title: 'Products',
        rank: 7,
        name: enWIZARD_KEYS.Products,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <ShopProducts parentState={this.state} setValues={this.setValues} />
        ),
      },
    ];

    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Create Shop</title>
        </Helmet>
        <Header />
        <main className="main shop-main" style={{ padding: '25px' }}>
          <div className="container main-cont">
            {/* <Multistep showNavigation={true} steps={steps}/> */}
            {this.state.IDForStatus != 4 ? (
              <Wizard
                steps={this.steps}
                setActiveStep={this.setActiveStepWizard}
                activeStep={this.state.activeStep}
                completedsteps={this.state.completedsteps}
                statusID={this.state.IDForStatus}
              />
            ) : (
              <div className="mt-5" style={{ marginLeft: '16%' }}>
                <h3>
                  This shop has been removed from the marketplace please contact
                  adminstrator of Zvonr marketplace{' '}
                </h3>
              </div>
            )}

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

export default CreateShop;
