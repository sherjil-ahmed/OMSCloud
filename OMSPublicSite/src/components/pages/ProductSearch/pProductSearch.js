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
  SIZE
} from '../../../utils/constants';
import { getStorageItem, setStorageItem } from '../../../utils/storageHelper';
import { ImageEntityEnum, SortByEnum } from '../../../utils/enums';
import { FetchData, baseUrlImage } from '../../../utils/serviceHelper';
import { default_currency } from '../../../utils/globalConstants';
import { Helmet } from 'react-helmet';
import Header from '../../core/Header/Header';
import { DISPLAY_PAGES } from '../../../utils/constants';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR } from '../../../utils/constants';
import Footer from '../../core/Footer/Footer';
import ShopSummary from '../ShopDetailPage/cShopBasicInfo';
const objURL = new window.URL(window.location.href);
class ProductSearch extends React.Component {
  constructor() {
    super();
    this.productModal = React.createRef();
    this.ModalQtyRef = React.createRef();
    this.priceSlider = React.createRef();
    this.state = {
      searchresults: [],
      parentcategories: [],
      ProductCount_PerPage: DEFAULT_SEARCH_CONFIG.PRODUCTCOUNT_PERPAGE
        ? DEFAULT_SEARCH_CONFIG.PRODUCTCOUNT_PERPAGE
        : [],
      SelectProductsCount: '',
      sortby: objURL.searchParams.get('SortBy')
        ? objURL.searchParams.get('SortBy')
        : SortByEnum.None.value,
      // PageSize_RowCount : (objURL.searchParams.get("PageSizeRowCount"))? objURL.searchParams.get("PageSizeRowCount") : DEFAULT_SEARCH_CONFIG.ROWS,
      PageSize_RowCount: 25,
      CategoryId: objURL.searchParams.get('CategoryID')
        ? objURL.searchParams.get('CategoryID')
        : '',
      SearchString: objURL.searchParams.get('SearchString')
        ? objURL.searchParams.get('SearchString')
        : '',
      PageNum: objURL.searchParams.get('PageNum')
        ? objURL.searchParams.get('PageNum')
        : DEFAULT_SEARCH_CONFIG.PAGE,
      ShopId: objURL.searchParams.get('ShopId')
        ? objURL.searchParams.get('ShopId')
        : '',
      SortOrder: false,
      ProductTypeId: '',
      MinPrice: '',
      MaxPrice: '',
      absMinPrice: '',
      absMaxPrice: '',
      currentPageMinIndex: '',
      currentPageMaxIndex: '',
      grandRecordsCount: '',
      numberOfPages: '',
      AttributeList: [],
      uniqueAttributes: [],
      reqAttributeList: [],
      openFilter: objURL.searchParams.get('openFilter')
        ? objURL.searchParams.get('openFilter')
        : '',
      productIDForCart: '',
      productQuantity: 1,
    };
  }

  componentDidMount() {
    this.getProducts();
  }

  getReqAttributeListObj = () => {
    if (this.state.AttributeList && this.state.AttributeList.length > 0) {
      let obj = {};
      let shortListAttributes = this.state.AttributeList.filter(
        (a) => a.isChecked,
      );
      for (let x of shortListAttributes) {
        for (let y of this.state.uniqueAttributes) {
          let temp = shortListAttributes.find((a) => a.AttributeTitle == y);
          if (temp) {
            let tempList = shortListAttributes
              .filter((f) => f.AttributeID == temp.AttributeID)
              .map((z) => z.AttributeValue);
            obj[temp.AttributeID] = tempList;
          }
        }
      }
      return obj;
    } else {
      return {};
    }
  };
  changeBackground = (e) => {
    e.target.style.color = 'red';
  };
  whiteBackground = (e) => {
    e.target.style.color = '';
  };

  successProductSearch = (res) => {
    this.setState(
      {
        searchresults: res.ProductList,
        parentcategories:
          res.ParentCategoryList && res.ParentCategoryList.length > 0
            ? res.ParentCategoryList.sort(
              (b, a) =>
                (a.CategoryParentID === null) -
                (b.CategoryParentID === null) ||
                -(a.CategoryParentID > b.CategoryParentID) ||
                +(a.CategoryParentID < b.CategoryParentID),
            )
            : [],
        AttributeList: this.consolidateAttrFromPrev(res.AttributeList),
        uniqueAttributes:
          res.AttributeList && res.AttributeList.length > 0
            ? [...new Set(res.AttributeList.map((item) => item.AttributeTitle))]
            : [],
        absMaxPrice: res.MaxPrice,
        absMinPrice: res.MinPrice,
        currentPageMinIndex: res.CurrentPageMinIndex,
        currentPageMaxIndex: res.CurrentPageMaxIndex,
        grandRecordsCount: res.GrandRecordsCount,
        numberOfPages: res.NumberOfPages,
      },
      () => {
        if (this.priceSlider.current) {
          window.CreateUISlider(
            this.priceSlider,
            this.state.absMaxPrice,
            this.state.absMinPrice,
            this,
          );
        }
        if (this.ModalQtyRef.current) {
          window.createTouchspinElementVertical(this.ModalQtyRef, (value) => {
            this.setState({
              productQuantity: value,
            });
          });
        }

        if (this.productModal.current) {
          window.HookProductModal(this.productModal, () => {
            this.setState({
              productQuantity: 1,
            });
          });
        }
      },
    );
  };

  getProducts = () => {
    let reqObj = {
      CountryId: SELECTED_COUNTRY_VALUE,
      ProvinceId: getStorageItem(SELECTED_PROVINCE)
        ? getStorageItem(SELECTED_PROVINCE)
        : '',
      CityId: getStorageItem(SELECTED_CITY)
        ? getStorageItem(SELECTED_CITY)
        : '',
      CategoryId: this.state.CategoryId,
      SearchString: this.state.SearchString,
      PageNum: this.state.PageNum,
      PageSize_RowCount: this.state.PageSize_RowCount,
      SortBy: this.state.sortby,
      SortOrder: this.state.SortOrder, //True=Desc, False = Asc
      ProductTypeId: this.state.ProductTypeId,
      MinPrice: this.state.MinPrice,
      MaxPrice: this.state.MaxPrice,
      ShopId: this.state.ShopId,
      AttributeList: this.getReqAttributeListObj(),
    };

    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Product_ProductSearchByPage,
      reqObj,
      this.successProductSearch,
    );

    window.toggleFilter(this.state.openFilter);
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
    setStorageItem(PROFILE_ID, res);
    if (res != null) {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.SUCCESS,
        message: 'Product added successfully',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.GREEN,
        messageSize: SIZE.FONT_SIZE
      });
      this.getCartDetailByProfileID();
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Error',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };

  AddToCart = () => {
    let reqObj = {
      ProductID: this.state.productIDForCart,
      Quantity: this.state.productQuantity,
      RequestedByProfileId: getStorageItem(PROFILE_ID),
    };
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.CartItem_AddToCartByProductId,
      reqObj,
      this.successAddToCartByProductId,
    );
  };

  consolidateAttrFromPrev = (resAttrList) => {
    //isChecked
    //(res.AttributeList && res.AttributeList.length > 0)? res.AttributeList : []
    if (this.state.AttributeList && this.state.AttributeList.length > 0) {
      //for(let x of this.state.AttributeList){
      for (let y of resAttrList) {
        let tempObj = this.state.AttributeList.find(
          (x) =>
            x.AttributeID == y.AttributeID &&
            x.AttributeTitle == y.AttributeTitle &&
            x.AttributeValue == y.AttributeValue,
        );
        if (tempObj == null) {
          //add this new attribute
          this.state.AttributeList.push({
            AttributeID: y.AttributeID,
            AttributeTitle: y.AttributeTitle,
            AttributeValue: y.AttributeValue,
          });
        }
      }
      return this.state.AttributeList;
    } else {
      return resAttrList && resAttrList.length > 0 ? resAttrList : [];
    }
  };

  showPagination = () => {
    let pageObj = {
      pageArr: [],
      showLastPage: false,
      isPrevEnabled: false,
      isNextEnabled: false,
    };

    let startIdx =
      this.state.PageNum - DISPLAY_PAGES < 0
        ? 1
        : this.state.PageNum < this.state.numberOfPages
          ? this.state.PageNum - (DISPLAY_PAGES - 2)
          : this.state.PageNum - (DISPLAY_PAGES - 1);
    let endIdx =
      startIdx + DISPLAY_PAGES - 1 > this.state.numberOfPages
        ? this.state.numberOfPages
        : startIdx + DISPLAY_PAGES - 1;

    for (let i = startIdx; i <= endIdx; i++) {
      if (i == this.state.PageNum) {
        pageObj.pageArr.push(
          <li className="page-item active" key={i}>
            <a
              className="page-link"
              href="#"
              onClick={(e) => {
                e.preventDefault();
                this.setState({ PageNum: i }, () => {
                  this.getProducts();
                });
              }}
            >
              {i}
              <span className="sr-only">(current)</span>
            </a>
          </li>,
        );
      } else {
        pageObj.pageArr.push(
          <li className="page-item" key={i}>
            <a
              className="page-link"
              href="#"
              onClick={(e) => {
                e.preventDefault();
                this.setState({ PageNum: i }, () => {
                  this.getProducts();
                });
              }}
            >
              {i}
              <span className="sr-only">(current)</span>
            </a>
          </li>,
        );
      }
    }

    pageObj.isPrevEnabled = startIdx == 1 ? false : true;
    pageObj.isNextEnabled = endIdx == this.state.numberOfPages ? false : true;
    pageObj.showLastPage = endIdx == this.state.numberOfPages ? false : true;
    return (
      <ul className="pagination">
        {!pageObj.isPrevEnabled ? (
          <li className="page-item disabled">
            <a className="page-link page-link-btn" href="#">
              <i className="icon-angle-left" />
            </a>
          </li>
        ) : (
          <li className="page-item">
            <a
              className="page-link page-link-btn"
              href="#"
              onClick={(e) => {
                e.preventDefault();
                this.setState({ PageNum: this.state.PageNum - 1 }, () => {
                  this.getProducts();
                });
              }}
            >
              <i className="icon-angle-left" />
            </a>
            {/* <button className="page-link page-link-btn" onClick={()=>{ this.setState({ PageNum : (this.state.PageNum-1)},()=>{this.getProducts()}) }}><i className="icon-angle-left" /></button> */}
          </li>
        )}
        {pageObj.pageArr}
        {pageObj.showLastPage ? (
          <>
            <li className="page-item">
              <span>...</span>
            </li>
            <li className="page-item">
              <a
                className="page-link"
                href="#"
                onClick={(e) => {
                  e.preventDefault();
                  this.setState({ PageNum: this.state.numberOfPages }, () => {
                    this.getProducts();
                  });
                }}
              >
                {this.state.numberOfPages}
                <span className="sr-only">(current)</span>
              </a>
              {/* <button className="page-link" onClick={()=>{ this.setState({ PageNum : this.state.numberOfPages},()=>{this.getProducts()}) }}>{this.state.numberOfPages} <span className="sr-only">(current)</span></button> */}
            </li>
          </>
        ) : (
          <></>
        )}
        {!pageObj.isNextEnabled ? (
          <li className="page-item disabled">
            <a className="page-link page-link-btn" href="#">
              <i className="icon-angle-right"></i>
            </a>
          </li>
        ) : (
          <li className="page-item ">
            <a
              className="page-link page-link-btn"
              href="#"
              onClick={(e) => {
                e.preventDefault();
                this.setState({ PageNum: this.state.PageNum + 1 }, () => {
                  this.getProducts();
                });
              }}
            >
              <i className="icon-angle-right"></i>
            </a>
          </li>
        )}
      </ul>
    );
  };

  render() {
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Product Search</title>
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
                {this.state.parentcategories &&
                  this.state.parentcategories.length > 0 ? (
                  (() => {
                    let breadcrumbs = [];
                    for (
                      let i = 0;
                      i < this.state.parentcategories.length;
                      i++
                    ) {
                      let item = this.state.parentcategories[i];
                      if (i == this.state.parentcategories.length - 1) {
                        breadcrumbs.push(
                          <li
                            key={i}
                            className="breadcrumb-item active"
                            aria-current="page"
                          >
                            {item.CategoryTitle}
                          </li>,
                        );
                      } else {
                        breadcrumbs.push(
                          <li
                            key={i}
                            className="breadcrumb-item"
                            aria-current="page"
                          >
                            <a
                              href={
                                '/search?CategoryID=' +
                                item.CategoryID +
                                '&openFilter=' +
                                this.state.openFilter
                              }
                            >
                              {item.CategoryTitle}
                            </a>
                          </li>,
                        );
                      }
                    }
                    return breadcrumbs;
                  })()
                ) : (
                  <></>
                )}
              </ol>
            </div>
            {/* End .container */}
          </nav>

          <div className="container">
            {this.state.ShopId ? (
              <>
                <ShopSummary shopData={{ ShopId: this.state.ShopId }} />
                <div className="mainsliwrapper padding_above">
                  <hr />
                </div>
              </>
            ) : (
              <></>
            )}

            <nav className="toolbox horizontal-filter">
              <div className="toolbox-left">
                <div
                  className="filter-toggle"
                  onClick={(e) => {
                    this.setState(
                      {
                        openFilter: this.state.openFilter == 'Y' ? 'N' : 'Y',
                      },
                      () => {
                        window.exHeaderComp.setState({
                          openFilter: this.state.openFilter,
                        });
                        window.toggleFilter(this.state.openFilter);
                      },
                    );
                  }}
                >
                  <span>Filters:</span>
                  <a href="#">&nbsp;</a>
                </div>
              </div>
              {/* End .toolbox-left */}
              <div className="sidebar-overlay" />
              <aside className="toolbox-left sidebar-shop mobile-sidebar">
                <div className="toolbox-item toolbox-sort select-custom">
                  <a className="sort-menu-trigger" href="#">
                    Page Size({this.state.PageSize_RowCount})
                  </a>
                  <ul className="sort-list">
                    {(() => {
                      let ProductPerPage = [];
                      for (
                        let index = 0;
                        index <= this.state.ProductCount_PerPage.length;
                        index++
                      ) {
                        ProductPerPage.push(
                          <li
                            key={index}
                            style={{ cursor: 'pointer' }}
                            onMouseLeave={this.whiteBackground}
                            onMouseOver={this.changeBackground}
                            value={this.state.ProductCount_PerPage[index]}
                            onClick={(e) => {
                              this.setState(
                                {
                                  PageSize_RowCount: e.target.value,
                                  PageNum: 1,
                                },
                                () => this.getProducts(),
                              );
                            }}
                          >
                            {this.state.ProductCount_PerPage[index]}
                          </li>,
                        );
                      }
                      return ProductPerPage;
                    })()}
                  </ul>
                </div>
                {/* <div className="toolbox-item toolbox-sort select-custom">
                          <a className="sort-menu-trigger" href="#">Color</a>
                          <ul className="sort-list">
                            <li>Black</li>
                            <li>Blue</li>
                            <li>Brown</li>
                            <li>Green</li>
                            <li>Indigo</li>
                            <li>Light Blue</li>
                            <li>Red</li>
                            <li>Yellow</li>
                          </ul>
                        </div> */}
                <div className="toolbox-item toolbox-sort price-sort select-custom">
                  <a className="sort-menu-trigger" href="#">
                    Price
                  </a>
                  <form className="filter-price-form">
                    <div>
                      Price:{' '}
                      <span>
                        {default_currency.symbol + this.state.absMinPrice}
                      </span>{' '}
                      —{' '}
                      <span>
                        {default_currency.symbol + this.state.absMaxPrice}
                      </span>
                    </div>
                    <label>Min price</label>
                    <input
                      className="input-price"
                      name="MinPrice"
                      value={this.state.MinPrice}
                      onChange={(e) => {
                        this.setState({ MinPrice: e.target.value }, () => {
                          window.setNoUiSlider(this.priceSlider, [
                            this.state.MinPrice,
                            this.state.MaxPrice,
                          ]);
                        });
                      }}
                    />
                    <label>Max price</label>
                    <input
                      className="input-price"
                      name="MaxPrice"
                      value={this.state.MaxPrice}
                      onChange={(e) => {
                        this.setState({ MaxPrice: e.target.value }, () => {
                          window.setNoUiSlider(this.priceSlider, [
                            this.state.MinPrice,
                            this.state.MaxPrice,
                          ]);
                        });
                      }}
                    />
                    <div className="filter-price-action mt-0">
                      <button
                        type="button"
                        className="btn btn-primary filterbtn"
                        onClick={() => {
                          this.getProducts();
                        }}
                      >
                        Filter
                      </button>
                    </div>
                  </form>
                </div>
              </aside>
              <div className="toolbox-item toolbox-sort">
                <div className="select-custom">
                  <select
                    name="sortby"
                    value={this.state.sortby}
                    className="form-control"
                    onChange={(e) => {
                      this.setState({ sortby: e.target.value }, () => {
                        this.getProducts();
                      });
                    }}
                  >
                    {Object.keys(SortByEnum).map((key, i) => (
                      <option key={i} value={SortByEnum[key].value}>
                        {SortByEnum[key].text}
                      </option>
                    ))}
                  </select>
                </div>
                {/* End .select-custom */}
                <a
                  href="#"
                  className="sorter-btn"
                  title="Set Ascending Direction"
                >
                  <span className="sr-only">Set Ascending Direction</span>
                </a>
              </div>
              {/* End .toolbox-item */}
              <div className="toolbox-item">
                <div className="toolbox-item toolbox-show">
                  <label>
                    Showing {this.state.currentPageMinIndex}-
                    {this.state.currentPageMaxIndex} of{' '}
                    {this.state.grandRecordsCount} results
                  </label>
                </div>
                {/* End .toolbox-item */}
                <div className="toolbox-item"></div>
              </div>
            </nav>
            <div className="row products-body nt">
              <div className="col-lg-9 col-xl-5col-4 main-content">
                <div className="product-intro divide-line ">
                  {this.state.searchresults &&
                    this.state.searchresults.length > 0 ? (
                    this.state.searchresults.map((item, i) => (
                      <div
                        key={i}
                        className="col-6 col-sm-4 col-lg-3 product-default"
                      >
                        <figure>
                          {item.Discount !== 0 || item.Discount !== null ? (
                            <span className="product-label label-sale">
                              {item.Discount}
                              {item.IsDiscountPercentage
                                ? '%'
                                : default_currency.symbol}{' '}
                              OFF
                            </span>
                          ) : (
                            // <span className="product-label label-sale">{parseFloat(((item.SellingPrice)-((parseInt(item.DiscountAmount)+(item.SellingPrice))))/(parseInt(item.DiscountAmount)+(item.SellingPrice))*100).toFixed(2)}% OFF</span>
                            <></>
                          )}
                          <a href={
                            '/productdetail?ProductId=' + item.ProductID
                          }>
                            <div className='zoom'>
                              <img
                                src={
                                  baseUrlImage +
                                  ImageEntityEnum.PRODUCT +
                                  '/' +
                                  item.ProductID +
                                  '/' +
                                  item.Image
                                }
                              />
                            </div>
                          </a>
                          {/* <span class="product-label label-sale">27% OFF</span> */}
                        </figure>
                        <div className="product-details">
                          <h2 className="product-category">
                            <a
                              href={
                                item.Category
                                  ? '/search?CategoryID=' +
                                  item.Category.CategoryID +
                                  '&openFilter=' +
                                  this.state.openFilter
                                  : '/search?CategoryID=' +
                                  '&openFilter=' +
                                  this.state.openFilter
                              }
                            >
                              {item.Category ? item.Category.CategoryTitle : ''}
                            </a>
                          </h2>
                          <h2 className="product-title">
                            <a
                              href={
                                '/productdetail?ProductId=' + item.ProductID
                              }
                            >
                              {item.ProductName}
                            </a>
                          </h2>
                          <div className="ratings-container">
                            <div className="product-ratings">
                              <span
                                className="ratings"
                                style={{
                                  width:
                                    '' +
                                    parseFloat(item.Rating / 5) * 100 +
                                    '%',
                                }}
                              />
                              {/* End .ratings */}
                              <span className="tooltiptext tooltip-top" />
                            </div>
                            {/* End .product-ratings */}
                          </div>
                          {/* End .product-container */}
                          <div className="shop-name">
                            <span>
                              <a
                                href={
                                  '/search?ShopId=' +
                                  item.ShopId +
                                  '&openFilter=' +
                                  this.state.openFilter
                                }
                                target="_blank"
                              >
                                {item.ShopName}
                              </a>
                            </span>
                          </div>
                          <div className="price-box">
                            {item.DiscountAmount !== 0 ||
                              item.DiscountAmount !== null ? (
                              <span className="before-discount-price">
                                {default_currency.symbol + item.SellingPrice}
                              </span>
                            ) : (
                              <></>
                            )}
                            <span className="product-price">
                              {default_currency.symbol +
                                (
                                  item.SellingPrice -
                                  parseFloat(item.DiscountAmount).toFixed(2)
                                ).toFixed(2)}
                            </span>
                          </div>
                          {/* End .price-box */}

                          {/* <div className="product-action">
                            <a
                              className="btn-icon btn-add-cart"
                              href={
                                '/productdetail?ProductId=' + item.ProductID
                              }
                              
                            >
                              <i className="icon-bag" />
                              ADD TO CART
                            </a>
                            
                            <button className="btn-icon btn-add-cart" data-toggle="modal" data-target="#addCartModal" onClick={()=>{this.setState ({ productIDForCart: item.ProductID })}}><i className="icon-bag" />ADD TO CART</button> 
                            <a href={baseUrlImage + ImageEntityEnum.PRODUCT + "/" + item.ProductID + "/" + item.Image} className="btn-quickview" title="Quick View"><i className="fas fa-external-link-alt" /></a> 
                          </div> */}
                        </div>
                        {/* End .product-details */}
                      </div>
                    ))
                  ) : (
                    <span>No results found</span>
                  )}
                </div>
                {/* End .row */}
                <nav className="toolbox toolbox-pagination">
                  {/* <div className="toolbox-item toolbox-show">
                          <label>Showing 1–9 of 60 results</label>
                        </div> */}
                  {this.showPagination()}
                </nav>
              </div>
              {/* End .col-lg-9 */}
              <div className="sidebar-overlay" />
              <aside className="sidebar-shop col-lg-3 col-xl-5col-1 order-lg-first mobile-sidebar">
                <div className="pin-wrapper">
                  <div className="sidebar-wrapper">
                    <div className="widget">
                      <h3 className="widget-title">
                        <a
                          data-toggle="collapse"
                          href="#widget-body-2"
                          role="button"
                          aria-expanded="true"
                          aria-controls="widget-body-2"
                        >
                          Category
                        </a>
                      </h3>
                      <div className="collapse show" id="widget-body-2">
                        <div className="widget-body">
                          <ul className="cat-list">
                            {(() => {
                              let arrCategories = [];
                              let dash = '';
                              let i = 1;

                              let selectedCategoryChilderen = getStorageItem(
                                LIST_CATEGORY,
                              )
                                ? getStorageItem(LIST_CATEGORY)
                                : [];
                              selectedCategoryChilderen =
                                this.state.CategoryId &&
                                  this.state.CategoryId != ''
                                  ? selectedCategoryChilderen.filter(
                                    (a) =>
                                      a.CategoryParentID ==
                                      this.state.CategoryId,
                                  )
                                  : selectedCategoryChilderen.filter(
                                    (a) => a.CategoryTypeID == 1,
                                  );

                              for (let item of this.state.parentcategories) {
                                if (i == 1) {
                                  arrCategories.push(
                                    <li key={i}>
                                      <a
                                        href={
                                          '/search?CategoryID=' +
                                          item.CategoryID +
                                          '&openFilter=' +
                                          this.state.openFilter
                                        }
                                      >
                                        {/*dash +*/ ' ' + item.CategoryTitle}
                                      </a>
                                    </li>,
                                  );
                                } else {
                                  arrCategories.push(
                                    <li key={i} style={{ paddingLeft: '10px' }}>
                                      <i className="fa fa-long-arrow-right"></i>
                                      <a
                                        href={
                                          '/search?CategoryID=' +
                                          item.CategoryID +
                                          '&openFilter=' +
                                          this.state.openFilter
                                        }
                                      >
                                        {/*dash +*/ ' ' + item.CategoryTitle}
                                      </a>
                                    </li>,
                                  );
                                }
                                dash += '-';
                                i++;
                              }
                              for (let item of selectedCategoryChilderen) {
                                arrCategories.push(
                                  <li style={{ paddingLeft: '20px' }} key={i}>
                                    <i className="fa fa-long-arrow-right"></i>
                                    <a
                                      href={
                                        '/search?CategoryID=' +
                                        item.CategoryID +
                                        '&openFilter=' +
                                        this.state.openFilter
                                      }
                                    >
                                      {/*dash +*/ ' ' + item.CategoryTitle}
                                    </a>
                                  </li>,
                                );
                                i++;
                              }
                              return arrCategories;
                            })()}
                          </ul>
                        </div>
                        {/* End .widget-body */}
                      </div>
                      {/* End .collapse */}
                    </div>
                    {/* End .widget */}
                    <div className="widget">
                      <h3 className="widget-title">
                        <a
                          data-toggle="collapse"
                          href="#widget-body-3"
                          role="button"
                          aria-expanded="true"
                          aria-controls="widget-body-3"
                        >
                          Price
                        </a>
                      </h3>
                      <div className="collapse show" id="widget-body-3">
                        <div className="widget-body">
                          <form action="#">
                            <div className="price-slider-wrapper">
                              {/* <div id="price-slider" className="noUi-target noUi-ltr noUi-horizontal">
                                        <div className="noUi-base"><div className="noUi-connects"><div className="noUi-connect" style={{transform: 'translate(7.2%, 0px) scale(0.528, 1)'}} /></div><div className="noUi-origin" style={{transform: 'translate(-92.8%, 0px)', zIndex: 5}}><div className="noUi-handle noUi-handle-lower" data-handle={0} tabIndex={0} role="slider" aria-orientation="horizontal" aria-valuemin={0.0} aria-valuemax={20.0} aria-valuenow="7.2" aria-valuetext={18.00} /></div><div className="noUi-origin" style={{transform: 'translate(-40%, 0px)', zIndex: 4}}><div className="noUi-handle noUi-handle-upper" data-handle={1} tabIndex={0} role="slider" aria-orientation="horizontal" aria-valuemin="47.2" aria-valuemax={100.0} aria-valuenow={60.0} aria-valuetext={300.00} /></div></div>
                                        </div> */}
                              <div
                                className="noUi-target noUi-ltr noUi-horizontal"
                                ref={this.priceSlider}
                              ></div>
                            </div>
                            {/* End .price-slider-wrapper */}
                            <div className="filter-price-action">
                              <div className="filter-price-text">
                                Price:
                                <span id="filter-price-range">
                                  {default_currency.symbol +
                                    this.state.MinPrice +
                                    ' - ' +
                                    default_currency.symbol +
                                    this.state.MaxPrice}
                                </span>
                              </div>
                              {/* End .filter-price-text */}
                              <button
                                type="button"
                                onClick={() => {
                                  this.getProducts();
                                }}
                                className="btn btn-primary filterbtn"
                              >
                                Filter
                              </button>
                            </div>
                            {/* End .filter-price-action */}
                          </form>
                        </div>
                        {/* End .widget-body */}
                      </div>
                      {/* End .collapse */}
                    </div>

                    {this.state.uniqueAttributes &&
                      this.state.uniqueAttributes.length > 0 ? (
                      <>
                        {this.state.uniqueAttributes.map((item, i) => {
                          let attributeItems = this.state.AttributeList.filter(
                            (a) => a.AttributeTitle == item,
                          );
                          return (
                            <div key={i} className="widget">
                              <h3 className="widget-title">
                                <a
                                  data-toggle="collapse"
                                  href={'#widget-body-3' + i}
                                  role="button"
                                  aria-expanded="true"
                                  aria-controls="widget-body-3"
                                >
                                  {item}
                                </a>
                              </h3>
                              <div
                                className="collapse show"
                                id={'widget-body-3' + i}
                              >
                                <div className="widget-body">
                                  <ul className="cat-list">
                                    {attributeItems.map((attr, j) => {
                                      return (
                                        <li key={j} className="checkbox">
                                          <label>
                                            <input
                                              type="checkbox"
                                              checked={
                                                attr.isChecked
                                                  ? attr.isChecked
                                                  : false
                                              }
                                              onChange={() => {
                                                attr.isChecked = attr.isChecked
                                                  ? false
                                                  : true;
                                                this.setState(
                                                  {
                                                    AttributeList: this.state
                                                      .AttributeList,
                                                  },
                                                  () => {
                                                    this.getProducts();
                                                  },
                                                );
                                              }}
                                            />
                                            {attr.AttributeValue}
                                          </label>
                                        </li>
                                      );
                                    })}
                                  </ul>
                                </div>
                              </div>
                            </div>
                          );
                        })}
                      </>
                    ) : (
                      <></>
                    )}
                  </div>
                  {/* End .sidebar-wrapper */}
                </div>
              </aside>
              {/* End .col-lg-3 */}
            </div>
            {/* End .row */}
          </div>
          <div
            ref={this.productModal}
            className="modal fade"
            id="addCartModal"
            tabIndex={-1}
            role="dialog"
            aria-labelledby="addCartModal"
          >
            <div className="modal-dialog" role="document">
              <div className="modal-content">
                <div className="modal-body add-cart-box text-center">
                  <p>
                    You are about to add this product to the
                    <br />
                    cart:
                  </p>
                  <h4 id="productTitle">Porto Short Name</h4>
                  <img
                    src="assets/images/products/product-2.jpg"
                    id="productImage"
                    width={100}
                    height={100}
                    alt="adding cart image"
                  />
                  <div
                    className=""
                    style={{
                      display: 'flex',
                      justifyContent: 'center',
                      paddingBottom: '10px',
                    }}
                  >
                    <input
                      ref={this.ModalQtyRef}
                      className="vertical-quantity form-control"
                      type="text"
                      value={this.state.productQuantity}
                      onChange={(e) => { }}
                    />
                  </div>
                  <div className="btn-actions">
                    <a href="#">
                      <button
                        className="btn btn-dark"
                        style={{ padding: '8px' }}
                        data-dismiss="modal"
                        onClick={() => {
                          this.AddToCart();
                        }}
                      >
                        Add to Cart
                      </button>
                    </a>
                    <a href="#">
                      <button
                        className="btn btn-dark"
                        style={{ padding: '8px' }}
                        data-dismiss="modal"
                      >
                        Continue
                      </button>
                    </a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}

export default ProductSearch;
