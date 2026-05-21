import React from 'react';
import {
  DEFAULT_SEARCH_CONFIG,
  LIST_CATEGORY,
  PROFILE_ID,
  REQUEST_TYPE,
  SELECTED_CITY,
  SELECTED_COUNTRY_VALUE,
  SELECTED_PROVINCE,
  SERVICE_ENDPOINTS,
  RECENTLY_VIEWED_ITEMS,
  SIZE
} from '../../../utils/constants';
import {
  getStorageItem,
  setStorageItem,
  pushToStorageItem,
} from '../../../utils/storageHelper';
import {
  ImageEntityEnum,
  RatingSubject,
  SortByEnum,
} from '../../../utils/enums';
import { FetchData, baseUrlImage } from '../../../utils/serviceHelper';
import { default_currency } from '../../../utils/globalConstants';
import { Helmet } from 'react-helmet';
import Header from '../../core/Header/Header';
import { DISPLAY_PAGES, ADD_TO_CART } from '../../../utils/constants';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR } from '../../../utils/constants';
import Footer from '../../core/Footer/Footer';
import CreateReview from '../Reviews/cCreateReview';
import ReviewList from '../Reviews/cReviewList';
import ShopSummary from '../ShopDetailPage/cShopBasicInfo';
import moment from 'moment';

const objURL = new window.URL(window.location.href);
class ProductDetail extends React.Component {
  constructor() {
    super();
    this.ProductQtyRef = React.createRef();
    this.productImageOwlCarousel = React.createRef();
    this.ReviewElement = React.createRef();
    this.state = {
      ProductId: objURL.searchParams.get('ProductId')
        ? objURL.searchParams.get('ProductId')
        : '',
      ProductDetail: null,
      productQuantity: 1,
      hasImageBool: false,
      TotalPrice: null,
      attributeList: [],
      reqAttr: [],
      attributeListCount: null,
      specificationList: [],
      ValidateReviewLength: false,
      IsReviewInputAllowed: true
    };

    if (this.state.ProductId) {
    } else {
      window.location.href = '/';
    }
  }

  componentDidMount() {
    this.getProductDetails();
    this.getProductReviews();
    this.getReviewDetils();
  }
  getProductReviews = () => {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.CustomerReview_GetCustomerReviewList +
        '?authorId=' +
        '' +
        '&subject=' +
        RatingSubject.PRODUCT.value +
        '&SubjectRowId=' +
        this.state.ProductId +
        '&statusId=' +
        2,
      null,
      this.successGetCustomerReviewList,
    );
  };
  successGetCustomerReviewList = (res) => {
    let _comments = [];
    for (let item of res) {
      item.ago = moment(item.CreatedOn).fromNow();
      let comment = {
        id: item.CustomerReviewID,
        user: item.ReviewerName,
        content: item.ReviewText,
        userPic: item.ReviewerImage,
        publishDate: item.ago,
        rating: item.Rating,
        customerReviewID: item.CreatedBy,
      };
      _comments.push(comment);
    }
    this.setState({
      comments: _comments,
    });
  };
  successGetCartDetails = (resp) => {
    window.exposeCardHeader(resp);
    if (resp != null && resp.CartItemList && resp.CartItemList.length > 0) {
    }
  };

  getCartDetailByProfileID = () => {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Cart_GetCartDetailsByProfileId +
        getStorageItem(PROFILE_ID),
      null,
      this.successGetCartDetails,
    );
  };

  successAddToCartByProductId = (res) => {
    if (res != null && res != -1) {
      setStorageItem(PROFILE_ID, res);
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.SUCCESS,
        message: 'Your requested item has been successfully added to the cart',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.GREEN,
        messageSize: SIZE.FONT_SIZE
      });
      this.getCartDetailByProfileID();
    } else if (res !== 1) {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Unable to add requested item to the cart. Either Shop or requested item is unavailable',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Unable to add requested item to the cart. Unknown error occured.',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };

  successGetProductDetails = (res) => {
    console.log('productdetail',res)
    this.setState({
      IsReviewInputAllowed : res.IsReviewInputAllowed
    })
    console.log('IsReviewInputAllowed',this.state.IsReviewInputAllowed)
    let objList = res.AttributeList.filter(
      (a) => a.IsAssigned == true && a.AttributeTypeID == 1,
    );
    let objSpecList = res.AttributeList.filter(
      (a) => a.IsAssigned == true && a.AttributeTypeID == 2,
    );
    this.setState(
      {
        ProductDetail: res,
        hasImageBool:
          res.ProductImages && res.ProductImages.length > 0 ? true : false,
        attributeList: objList,
        specificationList: objSpecList,
      },
      () => {
        if (getStorageItem(RECENTLY_VIEWED_ITEMS)) {
          let recentlyViewedItemsList = getStorageItem(RECENTLY_VIEWED_ITEMS);
          let findItemInList = recentlyViewedItemsList.find(
            (a) => a.ProductID == res.ProductID,
          );
          if (!findItemInList) {
            recentlyViewedItemsList.push(res);
            setStorageItem(RECENTLY_VIEWED_ITEMS, recentlyViewedItemsList);
          }
        } else {
          let recentlyViewedItemsList = [];
          recentlyViewedItemsList.push(res);
          setStorageItem(RECENTLY_VIEWED_ITEMS, recentlyViewedItemsList);
        }

        if (this.productImageOwlCarousel.current)
          window.createProductCarousle(this.productImageOwlCarousel);

        if (this.ProductQtyRef.current) {
          window.createTouchspinElementVertical(this.ProductQtyRef, (value) => {
            this.setState({
              productQuantity: value,
            });
          });
        }
      },
    );
  };
  SetAttributeValue = (attributeID, attributeValue, e) => {
    //e.preventDefault()
    let data = this.state.attributeList.find(
      (a) => a.AttributeID == attributeID && a.AttributeValue == attributeValue,
    );
    this.state.reqAttr.map((a) => {
      if (
        a.AttributeID === attributeID &&
        a.AttributeValue !== data.attributeValue
      ) {
        this.state.ProductDetail.SellingPrice = this.state.ProductDetail
          .SellingPrice
          ? parseInt(this.state.ProductDetail.SellingPrice - a.VariationInPrice)
          : parseInt(
              this.state.ProductDetail.SellingPrice - a.VariationInPrice,
            );
      }
    });
    this.state.reqAttr = this.state.reqAttr.filter(
      (a) => !(a.AttributeID == attributeID),
    );
    this.state.reqAttr.push(data);

    this.state.ProductDetail.SellingPrice = this.state.ProductDetail
      .SellingPrice
      ? parseInt(this.state.ProductDetail.SellingPrice + data.VariationInPrice)
      : parseInt(this.state.ProductDetail.SellingPrice + data.VariationInPrice);
    this.setState(
      {
        reqAttr: this.state.reqAttr,
        ProductDetail: this.state.ProductDetail,
      },
      () => {},
    );
  };
  getProductDetails = () => {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Product_GetProductDetail + this.state.ProductId + '/' + getStorageItem(PROFILE_ID) ,
      null,
      this.successGetProductDetails,
    );
  };

  getReviewDetils =() => {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.CustomerReview_GetCustomerReviewList +
        '?authorId=' +
        '' +
        '&subject=' +
        RatingSubject.PRODUCT.value +
        '&SubjectRowId=' +
        this.state.ProductId +
        '&statusId=' +
        2,
      null,
      this.successGetProductReviewList,
    );
  }

  successGetProductReviewList = (res) => {
    console.log('resInproduct', res)
    console.log('beforeset',this.state.ValidateReviewLength)
    console.log(res.length)
     if(res.length > 0)
     {
       console.log('in if')
       this.setState({
         ValidateReviewLength : true
       })
       console.log('Afterset',this.state.ValidateReviewLength)
     }
  }

    addToCartByProductID = () => {
    let reqObject = {
      ProductID: this.state.ProductId,
      Quantity: this.state.productQuantity,
      attributeList: this.state.reqAttr,
      RequestedByProfileId: getStorageItem(PROFILE_ID),
    };
    let unique = [
      ...new Set(this.state.attributeList.map((item) => item.AttributeID)),
    ];
    if (this.state.reqAttr.length !== unique.length) {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Please select all customization options before adding to cart',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
      return false;
    }
    
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.CartItem_AddToCartWithAttributesByProductId,
      reqObject,
      this.successAddToCartByProductId,
    );
  };

  render() {
    let imageData = this.state.ProductDetail;
    let shopID = this.state.ProductDetail
      ? this.state.ProductDetail.SupplierID
      : '';
    let tagList = this.state.ProductDetail
      ? this.state.ProductDetail.BrifeDescription === null ? [] : this.state.ProductDetail.BrifeDescription.split(',')
      : [];
    let reviewsCount = this.state.comments ? this.state.comments.length : 0;

    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Product Detail</title>
        </Helmet>
        <Header />
        <main className="main">
          <nav aria-label="breadcrumb" className="breadcrumb-nav">
            <div className="container">
              <ol className="breadcrumb">
                <li className="breadcrumb-item">
                  <a href="/">
                    <i className="icon-home" />
                  </a>
                </li>
                <li className="breadcrumb-item active" aria-current="page">
                  Products
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>
          <div className="container">
            {this.state.ProductDetail && this.state.ProductDetail.SupplierID ? (
              <ShopSummary
                shopData={{ ShopId: this.state.ProductDetail.SupplierID }}
              />
            ) : (
              <></>
            )}

            <div className="mb-2"></div>
            <div className="product-single-container product-single-default">
              <div className="row">
                <div className="col-lg-5 product-single-gallery">
                  <div className="">
                    {/* sticky-slider */}
                    <div className="product-slider-container product-item">
                      <div
                        className="product-single-carousel owl-carousel owl-theme"
                        ref={this.productImageOwlCarousel}
                      >
                        {(() => {
                          let productImage = [];
                          if (this.state.hasImageBool) {
                            for (
                              let imgNum = 0;
                              imgNum <
                              this.state.ProductDetail.ProductImages.length;
                              imgNum++
                            ) {
                              productImage.push(
                                <div>
                                  <div className="product-item" key={imgNum}>
                                    <img
                                      key={imgNum}
                                      className="product-single-image"
                                      src={
                                        baseUrlImage +
                                        ImageEntityEnum.PRODUCT +
                                        '/' +
                                        this.state.ProductDetail.ProductID +
                                        '/' +
                                        this.state.ProductDetail.ProductImages[
                                          imgNum
                                        ].ImageFileName
                                      }
                                      data-zoom-image={
                                        baseUrlImage +
                                        ImageEntityEnum.PRODUCT +
                                        '/' +
                                        this.state.ProductDetail.ProductID +
                                        '/' +
                                        this.state.ProductDetail.ProductImages[
                                          imgNum
                                        ].ImageFileName
                                      }
                                    />
                                  </div>
                                </div>,
                              );
                            }
                            return productImage;
                          }
                        })()}
                      </div>
                      {/* End .product-single-carousel */}
                      <span className="prod-full-screen">
                        <i className="icon-plus" />
                      </span>
                    </div>
                    <div
                      className="prod-thumbnail row owl-dots transparent-dots"
                      id="carousel-custom-dots"
                    >
                      {(() => {
                        let productthumbnail = [];
                        if (this.state.hasImageBool) {
                          for (
                            let thumbNum = 0;
                            thumbNum <
                            this.state.ProductDetail.ProductImages.length;
                            thumbNum++
                          ) {
                            if (thumbNum === 0) {
                              productthumbnail.push(
                                <div className="owl-dot active" key={thumbNum}>
                                  <img
                                    src={
                                      baseUrlImage +
                                      ImageEntityEnum.PRODUCT +
                                      '/' +
                                      this.state.ProductDetail.ProductID +
                                      '/' +
                                      this.state.ProductDetail.ProductImages[
                                        thumbNum
                                      ].ImageFileName
                                    }
                                  />
                                </div>,
                              );
                            } else {
                              productthumbnail.push(
                                <div className="owl-dot" key={thumbNum}>
                                  <img
                                    src={
                                      baseUrlImage +
                                      ImageEntityEnum.PRODUCT +
                                      '/' +
                                      this.state.ProductDetail.ProductID +
                                      '/' +
                                      this.state.ProductDetail.ProductImages[
                                        thumbNum
                                      ].ImageFileName
                                    }
                                  />
                                </div>,
                              );
                            }
                          }
                          return productthumbnail;
                        } else {
                        }
                      })()}
                    </div>
                  </div>
                </div>
                {/* End .col-md-6 */}
                <div className="col-lg-4 cent-card addto" >
                  <div className="product-single-details">
                    <h1 className="product-title">
                      {this.state.ProductDetail
                        ? this.state.ProductDetail.ProductTitle
                        : ''}
                    </h1>
                    {this.state.ProductDetail &&
                    this.state.ProductDetail.DiscountValue ? (
                      <span className="product-label label-sale custom-ProdDtlDiscount">
                        {this.state.ProductDetail.DiscountValue
                          ? this.state.ProductDetail.IsDiscountPercentage
                            ? this.state.ProductDetail.DiscountValue +
                              '%' +
                              ' OFF'
                            : default_currency.symbol +
                              this.state.ProductDetail.DiscountValue +
                              ' OFF'
                          : ''}
                      </span>
                    ) : (
                      // <span className="product-label label-sale">{parseFloat(((item.SellingPrice)-((parseInt(item.DiscountAmount)+(item.SellingPrice))))/(parseInt(item.DiscountAmount)+(item.SellingPrice))*100).toFixed(2)}% OFF</span>
                      <></>
                    )}
                    <div className="ratings-container">
                      <div className="product-ratings">
                        {this.state.ProductDetail ? (
                          <span
                            className="ratings"
                            style={{
                              width:
                                '' +
                                parseFloat(
                                  this.state.ProductDetail.UserRating / 5,
                                ) *
                                  100 +
                                '%',
                            }}
                          />
                        ) : (
                          <></>
                        )}
                        {/* End .ratings */}
                      </div>
                      {/* End .product-ratings */}
                      <a href="#" className="rating-link">
                        ( {reviewsCount} Reviews )
                      </a>
                    </div>
                    <h4>
                      <a
                        className="special_hover_link"
                        href={
                          this.state.ProductDetail &&
                          this.state.ProductDetail.Category
                            ? '/search?CategoryID=' +
                              this.state.ProductDetail.Category.CategoryID
                            : '#'
                        }
                      >
                        {this.state.ProductDetail &&
                        this.state.ProductDetail.Category
                          ? this.state.ProductDetail.Category.CategoryTitle
                          : ''}
                      </a>
                    </h4>
                    <h5>
                      <a
                        className="special_hover_link"
                        href={
                          this.state.ProductDetail
                            ? '/search?ShopId=' +
                              this.state.ProductDetail.SupplierID
                            : '#'
                        }
                      >
                        {this.state.ProductDetail
                          ? this.state.ProductDetail.SupplierName
                          : ''}
                      </a>
                    </h5>
                    {/* End .product-container */}
                    <div className="price-box">
                      {this.state.ProductDetail ? (
                        <span className="before-discount-price">
                          {this.state.ProductDetail.SupplierName
                            ? default_currency.symbol +
                              this.state.ProductDetail.SellingPrice
                            : default_currency.symbol +
                              this.state.ProductDetail.SellingPrice}
                        </span>
                      ) : (
                        ''
                      )}
                      <span className="product-price">
                        {this.state.ProductDetail
                          ? this.state.ProductDetail.IsDiscountPercentage
                            ? default_currency.symbol +
                              (this.state.ProductDetail.SellingPrice -
                                parseFloat(
                                  parseFloat(
                                    this.state.ProductDetail.DiscountValue /
                                      100,
                                  ) * this.state.ProductDetail.SellingPrice,
                                ).toFixed(2)).toFixed(2)
                            : default_currency.symbol +
                              (this.state.ProductDetail.SellingPrice -
                                parseFloat(
                                  this.state.ProductDetail.DiscountValue,
                                ).toFixed(2))
                          : ''}
                      </span>
                    </div>
                    {/* End .price-box */}
                    {/* End .product-desc */}
                    {(() => {
                      let unique = [
                        ...new Set(
                          this.state.attributeList.map(
                            (item) => item.AttributeID,
                          ),
                        ),
                      ];
                      let uniqueName = [
                        ...new Set(
                          this.state.attributeList.map(
                            (item) => item.AttributeName,
                          ),
                        ),
                      ];
                      let itemAttr = [];
                      for (let i = 0; i < unique.length; i++) {
                        let itemCheckBox = [];
                        let item = this.state.attributeList.filter(
                          (a) => a.AttributeID == unique[i],
                        );
                        let labelName = uniqueName[i];
                        for (let j = 0; j < item.length; j++) {
                          let temp = this.state.reqAttr.find(
                            (a) =>
                              a.AttributeID == item[j].AttributeID &&
                              a.AttributeValue == item[j].AttributeValue,
                          );
                          itemCheckBox.push(
                            // <li key={j} className={temp ? "active":"" } >
                            //   <a onClick={(e)=>{this.SetAttributeValue(item[j].AttributeID,item[j].AttributeValue,e)}} href="#">
                            //     {item[j].AttributeValue}
                            //   </a>
                            // </li>
                            <li key={j}>
                              <input
                                type="checkbox"
                                checked={temp ? true : false}
                                name={item[j].AttributeValue + j}
                                id={item[j].AttributeValue + j}
                                onChange={(e) => {
                                  this.SetAttributeValue(
                                    item[j].AttributeID,
                                    item[j].AttributeValue,
                                    e,
                                  );
                                }}
                              />
                              <label
                                htmlFor={item[j].AttributeValue + j}
                                value={item[j].AttributeValue}
                              >
                                {item[j].AttributeValue}
                              </label>
                            </li>,
                          );
                        }
                        itemAttr.push(
                          <>
                            <label>{labelName}</label>{' '}
                            <ul className="ks-cboxtags">{itemCheckBox}</ul>
                          </>,
                        );
                      }

                      return itemAttr;
                    })()}
                    {this.state.ProductDetail &&
                    this.state.ProductDetail.ExpectedDeliveryInfo ? (
                      <div>
                        <h5>
                          {this.state.ProductDetail
                            ? this.state.ProductDetail.ExpectedDeliveryInfo
                            : ''}
                        </h5>
                      </div>
                    ) : (
                      <></>
                    )}
                    <div className="product-action">
                      <div className="" style={{ paddingRight: '12px' }}>
                        <input
                          ref={this.ProductQtyRef}
                          className="vertical-quantity form-control"
                          type="text"
                        />
                      </div>
                      {/* End .product-single-qty */}
                      <a
                        href="#"
                        className="paction add-cart"
                        title="Add to Cart"
                        style={{ cursor: 'pointer' }}
                        onClick={(e) => {
                          e.preventDefault();
                          this.addToCartByProductID();
                        }}
                      >
                        Add to Cart
                      </a>
                      {/* <a
                              href="#"
                              className="paction add-wishlist"
                              title="Add to Wishlist"
                            >
                              <span>Add to Wishlist</span>
                            </a>
                            <a
                              href="#"
                              className="paction add-compare"
                              title="Add to Compare"
                            >
                              <span>Add to Compare</span>
                            </a> */}
                    </div>
                    {/* End .product-action */}
                    {/* End .product single-share */}
                  </div>
                  {/* End .product-single-details */}
                  <div style={{ minHeight: '90px' }}>
                    {(() => {
                      if (tagList) {
                        let item = [];
                        for (let i = 0; i < tagList.length; i++) {
                          item.push(
                            <span className="selectivity-item">
                              {tagList[i]}
                            </span>,
                          );
                        }
                        return item;
                      }
                    })()}
                    <br />
                  </div>
                  
                  {/* End .product-single-tabs */}
                </div>
                {/* End .col-md-6 */}
                <div className="col-lg-2 in-desc">
                      <div>
                          <span style={{fontWeight:'bold', fontSize:25, color:'black'}}>Read more about this product...</span>
                            <p style={{fontSize: 20}}>
                              {this.state.ProductDetail
                                ? this.state.ProductDetail.Description
                                : ''}
                            </p>
                        </div>
                </div>
                {/* End .col-lg-2 */}
              </div>
              {/* End .row */}
              <div className="row r45">
                      <div className="col-md-5 in-pad"></div>
                      <div className="col-md-7 r2-s">
                      <div className="product-single-tabs">
                    <ul className="nav nav-tabs" role="tablist">
                      {this.state.specificationList &&
                      this.state.specificationList.length > 0 ? (
                        <li className="nav-item">
                          <a
                            className="nav-link active"
                            id="product-tab-tags"
                            data-toggle="tab"
                            href="#product-tags-content"
                            role="tab"
                            aria-controls="product-tags-content"
                            aria-selected="false"
                          >
                            Specification
                          </a>
                        </li>
                      ) : (
                        <></>
                      )}

                      
                      {this.state.IsReviewInputAllowed ? <li className="nav-item">
                        <a
                          className={
                            this.state.specificationList &&
                            this.state.specificationList.length > 0
                              ? 'nav-link'
                              : 'nav-link active'
                          }
                          id="product-tab-reviews"
                          data-toggle="tab"
                          href="#product-reviews-content"
                          role="tab"
                          aria-controls="product-reviews-content"
                          aria-selected="false"
                        >
                          Write a Review
                        </a>
                      </li> : null}
                      
                    </ul>
                    <div className="tab-content">
                      {this.state.specificationList &&
                      this.state.specificationList.length > 0 ? (
                        <div
                          className="tab-pane fade  show active"
                          id="product-tags-content"
                          role="tabpanel"
                          aria-labelledby="product-tab-tags"
                        >
                          <div className="product-tags-content">
                            <table className="table table-bordered table-striped">
                              <tr>
                                <th>Specification</th>
                                <th>Value</th>
                              </tr>
                              <tbody>
                                {this.state.specificationList.map((item, i) => {
                                  return (
                                    <tr key={i}>
                                      <td>{item.AttributeName}</td>
                                      <td>{item.AttributeValue}</td>
                                    </tr>
                                  );
                                })}
                              </tbody>
                            </table>
                          </div>
                        </div>
                      ) : (
                        <></>
                      )}

                      <div
                        className={
                          this.state.specificationList &&
                          this.state.specificationList.length > 0
                            ? 'tab-pane fade'
                            : 'tab-pane fade show active'
                        }
                        id="product-desc-content"
                        role="tabpanel"
                        aria-labelledby="product-tab-desc"
                      >
                        {this.state.IsReviewInputAllowed ?
                        <div className="product-reviews-content">
                          <p>
                          <CreateReview
                            type={RatingSubject.PRODUCT}
                            id={this.state.ProductId}
                          />
                          </p>
                        </div> : null}
                        {/* End .product-desc-content */}
                      </div>
                      {/* End .tab-pane */}
                      <div
                        className="tab-pane fade"
                        id="product-reviews-content"
                        role="tabpanel"
                        aria-labelledby="product-tab-reviews"
                      >
                        <div className="product-reviews-content">
                                                   {/* <div className="collateral-box">
                                  <ul>
                                    <li>Be the first to review this product</li>
                                  </ul>
                                </div> */}
                          
                        </div>
                        {/* End .product-reviews-content */}
                      </div>
                      {/* End .tab-pane */}
                    </div>
                    {/* End .tab-content */}
                  </div>
                      </div>
              </div>
            </div>
            {/* End .product-single-container */}
          </div>
          {/* End .container */}
          {/* <div
                  className="product-single-video"
                  style={{
                    backgroundImage: 'url("assets/images/products/single/extended/bg-4.jpg")',
                  }}
                >
                  <div className="container">
                    <h3>Concept Film</h3>
                    <a
                      href="https://www.youtube.com/watch?v=Ph_VkTVmXh4"
                      className="video-btn"
                    >
                      Watch{" "}
                      <img
                        src="assets/images/products/single/extended/icon-play.png"
                        alt="play"
                      />
                    </a>
                  </div>
                </div> */}
          {this.state.ValidateReviewLength ?
          <section className="bg-light pt-3 pb-3">
            
          <div className="container">
            <ReviewList
              type={RatingSubject.PRODUCT}
              id={this.state.ProductId}
            />
          </div>
        </section> : null }
          
        </main>
        <Footer />
      </div>
    );
  }
}

export default ProductDetail;
