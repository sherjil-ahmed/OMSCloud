import React from 'react';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import ProductInfo from './cProductInfo';
import ProductImages from './cProductImages';
import ProductCategories from './cProductCategories';
import ProductAttributes from './cProductAttributes';
import ProductPricing from './cProductPricing';
import Wizard from '../../customControls/Wizard/Wizard';
import { Helmet } from 'react-helmet';
import {
  FetchData,
  FetchData_Override,
  baseUrl,
} from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SUPPLIER_ID,
  PRODUCT_ID,
  PROFILE_ID,
  DIRECT_PRODUCTS,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  SIZE
} from '../../../utils/constants';
import izitoast from 'izitoast';
import { ProductnShopStatus } from '../../../utils/enums';
import { getStorageItem, setStorageItem } from '../../../utils/storageHelper';

const enWIZARD_KEYS = {
  Information: 'Information',
  Images: 'Images',
  Categories: 'Categories',
  Attributes: 'Attributes',
  Pricing: 'Pricing',
};

class ProductListing extends React.Component {
  constructor(props) {
    super(props);
    this.steps = null;
    this.lastMaxStep = enWIZARD_KEYS.Information;
    this.state = {
      Product: {
        ProductID: null,
        ProductTitle: '',
        BrifeDescription: '',
        ProductActualImagePath: '',
        ProductImagePath: '',
        StockCount: '',
        WebLink: '',
        BasePrice: '',
        SellingPrice: '',
        OrderResponseTime: '',
        OrderResponseTimeUnitID: '0', //for now
        DiscountValue: '',
        IsDiscountPercentage: '',
        TaxTypeTitle: '',
        TaxTypeID: '1', //tax type inserted in DB vy AMQ
        UserRating: '',
        AnalysisRank: '',
        Description: '',
        ProductTypeID: '', //1 for physical 2 for digital
        ProductTypeName: '',
        BrandID: '1', //brand insert in DB by AMQ
        BrandName: '',
        SupplierID: getStorageItem(SUPPLIER_ID), //need to pick this up from a selection (as 1 user can have multiple Shops)
        SupplierName: '',
        StatusID: ProductnShopStatus.NEW,
        StatusName: '',
        CreatedBy: '',
        CreatedOn: null,
        ModifiedBy: '',
        ModifiedOn: null,
        RequestedByProfileId: getStorageItem(PROFILE_ID), //need to be same as ProfileID
      },

      ProductAttributePair: {
        ProductAttributePairID: '',
        ProductID: '',
        ProductName: '',
        AttributeID: '',
        AttributeName: '',
        AttributeValue: '',
        DisplayOrder: '',
        IsAssigned: '',
        IsSelectedForVariation: '',
        VariationInPrice: '',
        RequestedByProfileId: getStorageItem(PROFILE_ID), //need to be same as ProfileID
      },

      ProductPricing: {
        ProductID: null,
        BasePrice: '',
        SellingPrice: '',
        OrderResponseTime: '',
        OrderResponseTimeUnitID: '',
        DiscountValue: '',
        IsDiscountPercentage: true,
        TaxTypeID: '',
        RequestedByProfileId: getStorageItem(PROFILE_ID), //need to be same as ProfileID
      },

      ProductImages: [],
      ProductImageFileArray: [],
      ProductImagesRemove: [],
      listCategories: [],
      listProductAttributePairs: [],
      listAllProductAttributePairs: [],
      selectedCategory: null,
      previousCategories: null,
      activeStep: '',
      completedsteps: [],
      isNew: true,
    };
  }

  setValues = (key, value, callbackFunc) => {
    this.setState(
      {
        [key]: value,
      },
      () => {
        if (callbackFunc) {
          callbackFunc();
        }
      },
    );
  };

  setValuesMany = (obj, callbackFunc) => {
    this.setState(obj, () => {
      if (callbackFunc) {
        callbackFunc();
      }
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
  setActiveStep = (_activeStep) => {
    this.setMaxStep(_activeStep);
    this.setState({
      activeStep: _activeStep,
    });
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
  ValidateInformation = () => {
    return (
      this.state.Product.ProductTitle != '' &&
      this.state.Product.Description != '' &&
      this.state.Product.ProductTypeID != ''
    );
  };
  successProductPost = (resP) => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Information),
    );

    _completedsteps.push(enWIZARD_KEYS.Information);
    this.setState(
      {
        activeStep: enWIZARD_KEYS.Images,
        completedsteps: _completedsteps,
      },
      () => {
        this.setMaxStep(enWIZARD_KEYS.Images);
      },
    );
  };
  successGetProductById = (res) => {
    //get latest data for concurrency control
    this.state.Product.CreatedBy = res.CreatedBy;
    this.state.Product.CreatedOn = res.CreatedOn;
    this.state.Product.ModifiedBy = res.ModifiedBy;
    this.state.Product.ModifiedOn = res.ModifiedOn;
    this.state.Product.StatusID = 1; //new requirements

    this.setState(
      {
        Product: this.state.Product,
      },
      () => {
        FetchData(
          REQUEST_TYPE.POST,
          SERVICE_ENDPOINTS.Product_Post,
          this.state.Product,
          this.successProductPost,
        );
      },
    );
  };
  successProductInsert = (res) => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Information),
    );
    let _Product = this.state.Product;
    _Product.ProductID = res;
    _completedsteps.push(enWIZARD_KEYS.Information);

    this.setState(
      {
        Product: _Product,
        activeStep: enWIZARD_KEYS.Images,
        completedsteps: _completedsteps,
      },
      () => {
        this.setMaxStep(enWIZARD_KEYS.Images);
      },
    );
  };
  InformationNext = () => {
    if (this.ValidateInformation()) {
      if (this.state.Product.ProductID) {
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Product_GetById + this.state.Product.ProductID,
          null,
          this.successGetProductById,
        );
      } else {
        FetchData(
          REQUEST_TYPE.PUT,
          SERVICE_ENDPOINTS.Product_Put,
          this.state.Product,
          this.successProductInsert,
        );
      }
    } else {
      //validation failed message
    }
  };
  ValidateImages = () => {
    return true;
  };
  InactiveProduct = () => {
    if (this.state.Product.ProductID) {
      FetchData(
        REQUEST_TYPE.GET,
        SERVICE_ENDPOINTS.Product_GetById + this.state.Product.ProductID,
        null,
        this.successGetProductByIdForInactive,
      );
    }
  };
  successGetProductByIdForInactive = (res) => {
    this.state.Product.CreatedBy = res.CreatedBy;
    this.state.Product.CreatedOn = res.CreatedOn;
    this.state.Product.ModifiedBy = res.ModifiedBy;
    this.state.Product.ModifiedOn = res.ModifiedOn;
    this.state.Product.StatusID = 3;
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Product_Post,
      this.state.Product,
      this.successProductPostForInactive,
    );
  };
  successProductPostForInactive = (res) => {
    if (res == true) {
      setStorageItem(DIRECT_PRODUCTS, true);
      window.location.href = '/CreateShop';
    }
  };
  successImageInsert = (res, param) => {
    param._image.ProductMediaID = res;
    param.resolve(res);
  };
  failImageInsert = (err, param) => {
    param.reject(err);
  };
  successImageGet = (resCon, param) => {
    resCon.IsDefault = param._image.IsDefault;
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.ProductMediaDetail_Post,
      resCon,
      this.successImagePost,
      this.failImagePost,
      { resolve: param.resolve },
      { reject: param.reject },
    );
  };

  successImagePost = (res, param) => {
    param.resolve(res);
  };

  failImagePost = (err, param) => {
    param.reject(err);
  };

  successImageRemove = (res, param) => {
    this.state.ProductImagesRemove = this.state.ProductImagesRemove.filter(
      (a) => !(a.ProductMediaID == param._image.ProductMediaID),
    );
    param.resolve(res);
  };

  failImageRemove = (err, param) => {
    param.reject(err);
  };

  ImagesNext = () => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Images),
    );

    if (false) {
      //shop already created
      this.setActiveStep(enWIZARD_KEYS.Categories);

      _completedsteps.push(enWIZARD_KEYS.Images);
      this.setState({
        completedsteps: _completedsteps,
      });
    } else {
      //Validate Images
      if (this.ValidateImages()) {

        _completedsteps.push(enWIZARD_KEYS.Images);
        this.setState(
          {
            activeStep: enWIZARD_KEYS.Categories,
            completedsteps: _completedsteps,
          },
          () => {
            this.setMaxStep(enWIZARD_KEYS.Categories);
          },
        );
        // let arrPromises = [];
        // for (let _image of this.state.ProductImages) {
        //   if (!(_image.ProductMediaID && _image.ProductMediaID != '')) {

        //     // let p = new Promise((resolve, reject) => {

        //     //   FetchData(
        //     //     REQUEST_TYPE.PUT,
        //     //     SERVICE_ENDPOINTS.ProductMediaDetail_PutImage,
        //     //     {
        //     //       ImageFileName: _image.ImageFileName,
        //     //       IsDefault: _image.IsDefault,
        //     //       ProductID: _image.ProductID,
        //     //       ProductMediaID: _image.ProductMediaID
        //     //     },
        //     //     this.successImageInsert,
        //     //     this.failImageInsert,
        //     //     { _image: _image, resolve: resolve },
        //     //     { reject: reject },
        //     //   );
        //     // });
        //     // arrPromises.push(p);
        //   } else {
        //     //removing update for now
        //     let p = new Promise((resolve, reject) => {
        //       FetchData(
        //         REQUEST_TYPE.GET,
        //         SERVICE_ENDPOINTS.ProductMediaDetail_GetById +
        //         _image.ProductMediaID,
        //         null,
        //         this.successImageGet,
        //         null,
        //         { _image: _image, resolve: resolve, reject: reject },
        //       );
        //     });
        //     arrPromises.push(p);
        //   }
        // }

        // for (let _image of this.state.ProductImagesRemove) {
        // 
        //   let p = new Promise((resolve, reject) => {
        //     FetchData(
        //       REQUEST_TYPE.DELETE,
        //       SERVICE_ENDPOINTS.ProductMediaDetail_Delete +
        //       _image.ProductMediaID,
        //       null,
        //       this.successImageRemove,
        //       this.failImageRemove,
        //       { _image: _image, resolve: resolve },
        //       { reject: reject },
        //     );
        //   });
        //   arrPromises.push(p);
        // }

        // //posting images to server
        // // let pfilePost = new Promise((resolve, reject) => {
        // //  
        // //   if (this.state.ProductImageFileArray.length > 0) {
        // //     let form = new FormData();
        // //     for (let file of this.state.ProductImageFileArray) {
        // //       form.append(file.name, file, '');
        // //     }
        // //     var settings = {
        // //       url:
        // //         baseUrl +
        // //         SERVICE_ENDPOINTS.ProductMediaDetail_PutImageByProductId +
        // //         '?Id=' +
        // //         this.state.Product.ProductID +
        // //         '&isDefault=false',
        // //       method: REQUEST_TYPE.POST,
        // //       timeout: 0,
        // //       processData: false,
        // //       mimeType: 'multipart/form-data',
        // //       contentType: false,
        // //       data: form,
        // //     };

        // //     FetchData_Override(settings).done(function (response) {
        // //       resolve();
        // //     });
        // //   } else {
        // //     resolve();
        // //   }
        // // });

        // // arrPromises.push(pfilePost);
        // // console.log('hassan', arrPromises);

        // Promise.all(arrPromises).then((values) => {
        //   _completedsteps.push(enWIZARD_KEYS.Images);
        //   this.setState(
        //     {
        //       activeStep: enWIZARD_KEYS.Categories,
        //       completedsteps: _completedsteps,
        //     },
        //     () => {
        //       this.setMaxStep(enWIZARD_KEYS.Categories);
        //     },
        //   );
        // });
      } else {
      }
    }
  };

  ImagesPrev = () => {
    this.setActiveStep(enWIZARD_KEYS.Information);
  };

  ValidateCategories = () => {
    return this.state.selectedCategory;
  };

  successGetCategoriesList = (res) => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Categories),
    );

    _completedsteps.push(enWIZARD_KEYS.Categories);
    this.setState(
      {
        activeStep: enWIZARD_KEYS.Attributes,
        completedsteps: _completedsteps,
      },
      () => {
        this.setMaxStep(enWIZARD_KEYS.Attributes);
      },
    );
  };

  CategoriesNext = () => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Categories),
    );

    if (false) {
      //shop address already created
      this.setActiveStep(enWIZARD_KEYS.Attributes);

      _completedsteps.push(enWIZARD_KEYS.Categories);
      this.setState({
        completedsteps: _completedsteps,
      });
    } else {
      //Validate Categories
      if (this.ValidateCategories()) {
        let CategoryId = this.state.selectedCategory.CategoryID;
        let ProductId = this.state.Product.ProductID;
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Product_GetAllNonExistingCategoryList +
          CategoryId +
          '/' +
          ProductId,
          null,
          this.successGetCategoriesList,
        );
      } else {
        _completedsteps.push(enWIZARD_KEYS.Categories);
        this.setState(
          {
            activeStep: enWIZARD_KEYS.Attributes,
            completedsteps: _completedsteps,
          },
          () => {
            this.setMaxStep(enWIZARD_KEYS.Attributes);
          },
        );
      }
    }
  };

  CategoriesPrev = () => {
    this.setActiveStep(enWIZARD_KEYS.Images);
  };

  ValidateAttributes = () => {
    return true;
  };

  AttributesNext = () => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Attributes),
    );
    if (false) {
      //how to know this step was already done
      this.setActiveStep(enWIZARD_KEYS.Pricing);
      _completedsteps.push(enWIZARD_KEYS.Attributes);
      this.setState({
        completedsteps: _completedsteps,
      });
    } else {
      if (this.ValidateAttributes()) {
        _completedsteps.push(enWIZARD_KEYS.Attributes);

        this.setState(
          {
            activeStep: enWIZARD_KEYS.Pricing,
            completedsteps: _completedsteps,
          },
          () => {
            this.setMaxStep(enWIZARD_KEYS.Pricing);
          },
        );
      }
    }
  };

  AttributesPrev = () => {
    this.setActiveStep(enWIZARD_KEYS.Categories);
  };

  ValidatePricing = () => {
    if (this.state.ProductPricing.SellingPrice <= 0 ||
      this.state.ProductPricing.SellingPrice === '') {
      izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Product Price can not be empty, zero or less than 0. Please specify a positive non-zero value.',
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
      return false
    }
    else if (
      this.state.ProductPricing.OrderResponseTime === '' ||
      this.state.ProductPricing.OrderResponseTime <= 0
    ) {
      izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Expected Delivery Duration field is empty or less than 0',
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
      return false;
    } else if (
      this.state.ProductPricing.OrderResponseTimeUnitID === '' ||
      this.state.ProductPricing.OrderResponseTimeUnitID === '0'
    ) {
      izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Expected Delivery Duration Unit field is empty',
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
      return false;
    } else {
      return true;
    }
  };

  successUpdatePricing = (res) => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Pricing),
    );
    if (res) {
      _completedsteps.push(enWIZARD_KEYS.Pricing);
      this.setState({
        completedsteps: _completedsteps,
      });

      //window.localStorage.setItem("DirectProducts",true)
      setStorageItem(DIRECT_PRODUCTS, true);
      window.location.href = '/CreateShop';
    }
  };

  PricingNext = () => {
    let _completedsteps = this.state.completedsteps.filter(
      (a) => !(a == enWIZARD_KEYS.Pricing),
    );
    if (false) {
      //how to know this step was already done
      _completedsteps.push(enWIZARD_KEYS.Pricing);
      this.setState({
        completedsteps: _completedsteps,
      });
    } else {
      if (this.ValidatePricing()) {
        this.state.ProductPricing.ProductID = this.state.Product.ProductID;
        this.state.ProductPricing.RequestedByProfileId = getStorageItem(
          PROFILE_ID,
        );
        FetchData(
          REQUEST_TYPE.POST,
          SERVICE_ENDPOINTS.Product_UpdatePricing,
          this.state.ProductPricing,
          this.successUpdatePricing,
        );
      }
    }
  };

  PricingPrev = () => {
    this.setActiveStep(enWIZARD_KEYS.Attributes);
  };

  renderWizardPrevNext = () => {
    switch (this.state.activeStep) {
      case 'Information':
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.InformationNext}
            >
              Save & Continue
            </button>
          </div>
        );
      case 'Images':
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-outline-dark custom-btn prebtn"
              onClick={this.ImagesPrev}
            >
              Previous
            </button>

            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.ImagesNext}
            >
              Save & Continue
            </button>
          </div>
        );
      case 'Categories':
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-outline-dark custom-btn prebtn"
              onClick={this.CategoriesPrev}
            >
              Previous
            </button>

            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.CategoriesNext}
            >
              Save & Continue
            </button>
          </div>
        );
      case 'Attributes':
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-outline-dark custom-btn prebtn"
              onClick={this.AttributesPrev}
            >
              Previous
            </button>

            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.AttributesNext}
            >
              Save & Continue
            </button>
          </div>
        );
      case 'Pricing':
        return (
          <div className="col-md-6 col-sm-12 navbuttonspot">
            <button
              type="button"
              className="btn btn-outline-dark custom-btn prebtn"
              onClick={this.PricingPrev}
            >
              Previous
            </button>

            <button
              type="button"
              className="btn btn-primary nextbtn"
              onClick={this.PricingNext}
            >
              Save &amp; Exit
            </button>
          </div>
        );
      default:
        return <div></div>;
    }
  };

  successGetProductDetail = (resP) => {
    let _completedsteps = this.state.completedsteps;
    let sessionProductID = getStorageItem(PRODUCT_ID);
    if (resP) {
      _completedsteps.push(enWIZARD_KEYS.Information);
      this.setMaxStep(enWIZARD_KEYS.Information);
      let _Product = JSON.parse(JSON.stringify(resP));

      _Product.RequestedByProfileId = getStorageItem(PROFILE_ID);

      if (resP.CategoryList) delete _Product.CategoryList;

      if (resP.AttributeList) delete _Product.AttributeList;

      if (resP.ProductImages) delete _Product.ProductImages;

      let newState = {
        isNew: false,
        Product: _Product,
        ProductImages: resP.ProductImages,
        activeStep: enWIZARD_KEYS.Information,
        previousCategories: resP.CategoryList,
      };

      if (resP) {
        let ProductPricing = {
          ProductID: sessionProductID,
          BasePrice: resP.BasePrice,
          SellingPrice: resP.SellingPrice,
          OrderResponseTime: resP.OrderResponseTime,
          OrderResponseTimeUnitID: resP.OrderResponseTimeUnitID,
          DiscountValue: resP.DiscountValue,
          IsDiscountPercentage: true,
          TaxTypeID: resP.TaxTypeID,
          IsDiscountPercentage: resP.IsDiscountPercentage,
          RequestedByProfileId: getStorageItem(PROFILE_ID), //need to be same as ProfileID
        };

        newState.ProductPricing = ProductPricing;
      }
      this.setState(newState, () => {
        if (resP.CategoryList) {
          _completedsteps.push(enWIZARD_KEYS.Categories);
          this.setMaxStep(enWIZARD_KEYS.Categories);
        }
        if (resP.AttributeList) {
          _completedsteps.push(enWIZARD_KEYS.Attributes);
          this.setMaxStep(enWIZARD_KEYS.Attributes);
        }
        if (resP.ProductImages) {
          _completedsteps.push(enWIZARD_KEYS.Images);
          this.setMaxStep(enWIZARD_KEYS.Images);
        }

        if (resP.SellingPrice) {
          _completedsteps.push(enWIZARD_KEYS.Pricing);
          this.setMaxStep(enWIZARD_KEYS.Pricing);
        }

        this.setState({
          completedsteps: _completedsteps,
          activeStep: enWIZARD_KEYS.Information,
          statusID: resP.StatusID,
        });
        //}
      });
    }
  };

  componentDidMount() {
    let sessionProductID = getStorageItem(PRODUCT_ID);
    if (sessionProductID && sessionProductID != '') {
      FetchData(
        REQUEST_TYPE.GET,
        SERVICE_ENDPOINTS.Product_GetProductDetailFromShop + sessionProductID,
        null,
        this.successGetProductDetail,
      );
    } else {
      this.setState(
        {
          activeStep: enWIZARD_KEYS.Information,
        },
        () => {
          this.setMaxStep(enWIZARD_KEYS.Information);
        },
      );
    }
  }

  render() {
    this.steps = [
      {
        title: 'Product Information',
        rank: 1,
        name: enWIZARD_KEYS.Information,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <ProductInfo
            parentState={this.state}
            setValues={this.setValues}
            inactiveProduct={this.InactiveProduct}
          />
        ),
      },
      {
        title: 'Product Images',
        rank: 2,
        name: enWIZARD_KEYS.Images,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <ProductImages
            parentState={this.state}
            setValues={this.setValues}
            setValuesMany={this.setValuesMany}
          />
        ),
      },
      {
        title: 'Product Categories',
        rank: 3,
        name: enWIZARD_KEYS.Categories,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <ProductCategories
            parentState={this.state}
            setValues={this.setValues}
            setValuesMany={this.setValuesMany}
          />
        ),
      },
      {
        title: 'Product Attributes',
        rank: 4,
        name: enWIZARD_KEYS.Attributes,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <ProductAttributes
            parentState={this.state}
            setValues={this.setValues}
            setValuesMany={this.setValuesMany}
          />
        ),
      },
      {
        title: 'Product Pricing',
        rank: 5,
        name: enWIZARD_KEYS.Pricing,
        NextPrev: this.renderWizardPrevNext,
        component: (
          <ProductPricing parentState={this.state} setValues={this.setValues} />
        ),
      },
    ];

    return (
      <div className="page-wrapper">
        <Helmet
          style={[
            {
              cssText: `

                            .SearchSelectItem {
                                padding: 0px;
                                padding-left: 0px;
                                cursor: pointer;
                            }
                        
                            div.SearchSelectItem:hover {
                                background-color:transparent;
                                
                            }
                        `,
            },
          ]}
        >
          <title>Zvonr - Product Listing</title>
        </Helmet>
        <Header />
        <main className="main pro-pra">
          <div className="container pro-lis-main">
            {this.state.isNew ? (
              <h2>Add New Product</h2>
            ) : (
              <h2>Edit Product</h2>
            )}
            {/* {this.setActiveStep} */}
            <Wizard
              steps={this.steps}
              setActiveStep={this.setActiveStepWizard}
              activeStep={this.state.activeStep}
              completedsteps={this.state.completedsteps}
              wizardForProduct={this.state.isNew}
              statusID={this.state.statusID}
              productName={this.state.Product.ProductTitle}
            />
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

export default ProductListing;
