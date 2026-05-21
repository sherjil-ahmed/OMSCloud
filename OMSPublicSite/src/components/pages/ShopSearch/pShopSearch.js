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
class ShopSearch extends React.Component {
  constructor() {
    super();
    this.productModal = React.createRef();
    this.ModalQtyRef = React.createRef();
    this.priceSlider = React.createRef();
    this.state = {
      searchresults: {},
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
      productIDForCart: '',
      productQuantity: 1,
    };
  }
  componentDidMount() {
    this.getShops();
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

  successShopSearch = (res) => {
    if (res) {
      this.setState(
        {
          searchresults: res,
          currentPageMinIndex: res.CurrentPageMinIndex,
          currentPageMaxIndex: res.CurrentPageMaxIndex,
          grandRecordsCount: res.GrandRecordsCount,
          numberOfPages: res.NumberOfPages,
        },
        () => {},
      );
    }
  };
  getShops = () => {
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
      ShopId: this.state.ShopId,
      AttributeList: this.getReqAttributeListObj(),
    };

    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Supplier_GetShopPublicList,
      reqObj,
      this.successShopSearch,
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
                  this.getShops();
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
                  this.getShops();
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
                  this.getShops();
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
                    this.getShops();
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
                  this.getShops();
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
          <title>Zvonr - Shop Search</title>
        </Helmet>
        <Header />
        <main className="main">
          <div className="container">
            <nav className="toolbox horizontal-filter">
              <div className="toolbox-left"></div>
              {/* End .toolbox-left */}
              <div className="sidebar-overlay" />
              <aside className="toolbox-left sidebar-shop mobile-sidebar">
                <div
                  className="toolbox-item toolbox-sort select-custom"
                  ref={(e) => (this.pageList = e)}
                  onClick={(e) => {
                    this.pageList.classList.value.includes('opened')
                      ? this.pageList.classList.remove('opened')
                      : this.pageList.classList.add('opened');
                  }}
                >
                  <a
                    className="sort-menu-trigger"
                    href=""
                    onClick={(e) => {
                      e.preventDefault();
                    }}
                  >
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
                                () => this.getShops(),
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
              </aside>
              <div className="toolbox-item toolbox-sort">
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
            <div className="row products-body">
              <div className="col-lg-12">
                <div className="product-intro divide-line">
                  {this.state.searchresults.ShopList &&
                  this.state.searchresults.ShopList.length > 0 ? (
                    this.state.searchresults.ShopList.map((item, i) => (
                      <div
                        key={i}
                        className="col-6 col-sm-4 col-lg-3 product-default cursorpointer"
                        onClick={() => {
                          window.location.href =
                            '/ShopDetail?ShopId=' + item.ShopID;
                        }}
                      >
                        <figure>
                          <a>
                          <div className='zoom'>
                            <img
                              src={
                                baseUrlImage +
                                ImageEntityEnum.SUPPLIER +
                                '/' +
                                item.ShopID +
                                '/' +
                                item.Logo
                              }
                            />
                          </div>
                          </a>
                        </figure>
                        <div className="product-details">
                          <h2 className="product-title  special_hover_link">
                            <a href={'/ShopDetail?ShopId=' + item.ShopID}>{item.ShopName}</a>
                          </h2>
                            <span>Owner: {item.ShopOwnerName}</span>
                          <div className="shop-name">
                            <span>
                              {item.City}, {item.Province}
                            </span>
                          </div>
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
            </div>
            {/* End .row */}
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}

export default ShopSearch;
