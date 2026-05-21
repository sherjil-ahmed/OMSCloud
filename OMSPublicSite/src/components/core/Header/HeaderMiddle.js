import React from 'react';
import {
  getStorageItem,
  clearStorage,
  setStorageItem,
} from '../../../utils/storageHelper';
import {
  PROFILE_ID,
  SERVICE_ENDPOINTS,
  REQUEST_TYPE,
  STATUS_CODE,
  LIST_CATEGORY,
  INPROC_ORDERID,
  USER_PROFILE,
  CART_DETAILS,
  IS_USER_LOGGEDIN,
  LAST_CAT_FETECHED_DATETIME,
  SIZE
} from '../../../utils/constants';
import { baseUrlImage, FetchData } from '../../../utils/serviceHelper';
import iziToast from 'izitoast';
import {
  DeliveryOptionEnum,
  ImageEntityEnum,
  PaymentMethod,
} from '../../../utils/enums';
import { default_currency } from '../../../utils/globalConstants';
import moment, { RFC_2822 } from 'moment';

const objURL = new window.URL(window.location.href);
class HeaderMiddle extends React.Component {
  constructor(props) {
    super(props);
    // this.refUserBox = React.createRef();
    this.profileImgRef = React.createRef();
    this.state = {
      selectedCategory: objURL.searchParams.get('CategoryID')
        ? objURL.searchParams.get('CategoryID')
        : '',
      searchText: objURL.searchParams.get('SearchString')
        ? objURL.searchParams.get('SearchString')
        : '',
      doesSessionExists: getStorageItem(IS_USER_LOGGEDIN) ? true : false,
      sessionProfileObj: getStorageItem(USER_PROFILE),
      listCategory: getStorageItem(LIST_CATEGORY)
        ? getStorageItem(LIST_CATEGORY)
        : [],
      openFilter: objURL.searchParams.get('openFilter')
        ? objURL.searchParams.get('openFilter')
        : '',
      selectedCategoryImg: '',
      cartdetailobj: null,
      // UserBoxVisible : false
    };
  }

  successGetCartDetails = (resp) => {
    setStorageItem(CART_DETAILS, resp);
    this.setState({
      cartdetailobj: resp,
    });
  };

  getCartDetailByProfileID = () => {
    if (getStorageItem(PROFILE_ID)) {
      if (getStorageItem(CART_DETAILS)) {
        this.setState({
          cartdetailobj: getStorageItem(CART_DETAILS),
        });
      } else {
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Cart_GetCartDetailsByProfileId +
            getStorageItem(PROFILE_ID),
          null,
          this.successGetCartDetails,
        );
      }
    }
  };

  updateCartDetailsObj = (obj) => {
    setStorageItem(CART_DETAILS, obj);
    this.setState({
      cartdetailobj: obj,
    });
  };

  updateUserDetailsObj = (obj) => {
    this.setState({
      sessionProfileObj: obj,
    });
  };
  //sessionProfileObj

  successGetCategoryList = (res) => {
    setStorageItem(LAST_CAT_FETECHED_DATETIME, moment().format("DD/MM/YYYY HH:mm:ss"));
    let sessionProfile = getStorageItem(IS_USER_LOGGEDIN);
    let _listCategory = this.state.listCategory;

    for (let item of res) {
      item.ParentsList = [];
      item.ParentsList = this.getParentsList(item.CategoryParentID, res);
    }
    _listCategory = res;
    this.setState(
      {
        listCategory: _listCategory,
        doesSessionExists: sessionProfile ? true : false,
      },
      () => {
        setStorageItem(LIST_CATEGORY, this.state.listCategory);
      },
    );
  };

  componentDidMount() {
    window.exHeaderComp = this;
    if (!(this.state.listCategory && this.state.listCategory.length > 0)) {
      FetchData(
        REQUEST_TYPE.GET,
        SERVICE_ENDPOINTS.Category_GetCategoryList,
        null,
        this.successGetCategoryList,
      );
    }

    this.getCartDetailByProfileID();
    window.exposeCardHeader = this.updateCartDetailsObj;
    window.exposeUserHeader = this.updateUserDetailsObj;
    window.attachJS();
  }

  //reuse
  getParentsList = (categoryId, list) => {
    let parent = list.find((a) => a.CategoryID == categoryId);
    if (parent) {
      if (parent.ParentCategoryID) {
        return [...this.getParentsList(parent.ParentCategoryID, list), parent];
      } else {
        //base condition
        let temp = new Array();
        temp.push(parent);
        return temp;
      }
    } else {
      return [];
    }
  };

  SearchProduct = () => {};

  showImage = (ImagePath) => {
    this.setState({
      selectedCategoryImg: ImagePath,
    });
  };

  handleChange = (e) => {
    this.setState({
      [e.target.name]: e.target.value,
    });
  };

  handleOnEnterKey = (e) => {
    if (e.keyCode === 13) {
      this.state.selectedCategory != 'shop'
        ? (window.location.href =
            '/search?' +
            `CategoryID=${this.state.selectedCategory}&SearchString=${this.state.searchText}&openFilter=${this.state.openFilter}`)
        : (window.location.href =
            '/Shopsearch?' +
            `CategoryID=${this.state.selectedCategory}&SearchString=${this.state.searchText}`);
    } else {
    }
  };
  render() {
    let pathname = window.location.pathname.split('/')[1];
    let allCategories =
      this.state.listCategory && this.state.listCategory.length > 0
        ? this.state.listCategory
        : [];
    let mainCategories =
      this.state.listCategory && this.state.listCategory.length > 0
        ? this.state.listCategory.filter((a) => a.CategoryTypeID == 1)
        : [];
    let sublvl1Categories =
      this.state.listCategory && this.state.listCategory.length > 0
        ? this.state.listCategory.filter((a) => a.CategoryTypeID == 2)
        : [];
    let sublvl2Categories =
      this.state.listCategory && this.state.listCategory.length > 0
        ? this.state.listCategory.filter((a) => a.CategoryTypeID == 3)
        : [];
    let sublvl3Categories =
      this.state.listCategory && this.state.listCategory.length > 0
        ? this.state.listCategory.filter((a) => a.CategoryTypeID == 4)
        : [];
    let childCategories =
      this.state.listCategory && this.state.listCategory.length > 0
        ? this.state.listCategory.filter(
            (a) => a.ParentsList && a.ParentsList.length > 0,
          )
        : [];
    return (
      // <div className="header-middle" style={pathname=="home" || pathname=="" ? {} : {background : "#f4f4f4"}}>
      <div
        className={
          pathname == 'home' || pathname == ''
            ? 'header-middle home_header_design'
            : 'header-middle'
        }
      >
        <div className="container-fluid mainhead">
          <div className="header-left">
            <button
              className="mobile-menu-toggler"
              type="button"
              onClick={(e) => {
                e.preventDefault();
                window.exposeMobileMenu();
              }}
            >
              <i className="icon-menu" />
            </button>
            <a
              href="#"
              onClick={() => {
                window.location.href = '/';
              }}
              className="logo"
            >
              <img src="assets/images/logo1.png" alt="Porto Logo" />
            </a>
          </div>
          <div className="header-center">
            <div className="header-search">
              <a href="#" className="search-toggle" role="button">
                <i className="icon-magnifier" />
              </a>
              {/* <form action="#" method="get"> */}
              <div className="header-search-wrapper header-mid-tog-form">
                <input
                  type="search"
                  className="form-control"
                  placeholder="I'm searching for..."
                  name="searchText"
                  value={this.state.searchText}
                  onChange={this.handleChange}
                  onKeyDown={(e) => {
                    this.handleOnEnterKey(e);
                  }}
                />
                <div className="select-custom">
                  <select
                    name="selectedCategory"
                    value={this.state.selectedCategory}
                    onChange={this.handleChange}
                  >
                    <option value="">All Categories</option>
                    <option value="shop">Shop</option>
                    {mainCategories && mainCategories.length > 0 ? (
                      mainCategories.map((item, i) => {
                        let arrOptions = [];
                        arrOptions.push(
                          <option key={'p' + i} value={item.CategoryID}>
                            {item.CategoryTitle}
                          </option>,
                        );
                        let selectedParentsChildCategories = childCategories.filter(
                          (a) =>
                            a.ParentsList.find(
                              (b) => b.CategoryID == item.CategoryID,
                            ),
                        );
                        let j = 0;
                        for (let subItem of selectedParentsChildCategories) {
                          arrOptions.push(
                            <option key={'c' + j} value={subItem.CategoryID}>
                              {'- ' + subItem.CategoryTitle}
                            </option>,
                          );
                          j++;
                        }
                        return arrOptions;
                      })
                    ) : (
                      <></>
                    )}
                  </select>
                </div>
                {this.state.selectedCategory != 'shop' ? (
                  <a
                    className="btn"
                    href={
                      '/search?' +
                      `CategoryID=${this.state.selectedCategory}&SearchString=${this.state.searchText}&openFilter=${this.state.openFilter}`
                    }
                  >
                    <i className="icon-magnifier" />
                  </a>
                ) : (
                  <a
                    className="btn"
                    href={
                      '/Shopsearch?' +
                      `CategoryID=${this.state.selectedCategory}&SearchString=${this.state.searchText}`
                    }
                  >
                    <i className="icon-magnifier" />
                  </a>
                )}
              </div>
              {/* </form> */}
            </div>
          </div>
          <div className="header-right">
            <div className="dropdown cart-dropdown">
              <a
                href="#"
                className="dropdown-toggle"
                role="button"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
                data-display="static"
              >
                <i className="fa fa-cart-plus" />
                {this.state.cartdetailobj &&
                this.state.cartdetailobj.CartItemList &&
                this.state.cartdetailobj.CartItemList.filter(
                  (a) => a.StatusID != 4,
                ).length > 0 ? (
                  <span className="cart-count">
                    {
                      this.state.cartdetailobj.CartItemList.filter(
                        (a) => a.StatusID != 4,
                      ).length
                    }
                  </span>
                ) : (
                  <></>
                )}
              </a>
              <div className="dropdown-menu">
                <div className="dropdownmenu-wrapper">
                  <div className="dropdown-cart-header">
                    <span>
                      {this.state.cartdetailobj &&
                      this.state.cartdetailobj.CartItemList
                        ? this.state.cartdetailobj.CartItemList.filter(
                            (a) => a.StatusID != 4,
                          ).length
                        : 0}{' '}
                      Items (few below)
                    </span>
                    <a
                      href=""
                      onClick={(e) => {
                        e.preventDefault();
                        window.location.href = '/cartdetail';
                      }}
                    >
                      view more...
                    </a>
                  </div>
                  <div className="dropdown-cart-products">
                    {this.state.cartdetailobj &&
                    this.state.cartdetailobj.CartItemList &&
                    this.state.cartdetailobj.CartItemList.length > 0 ? (
                      this.state.cartdetailobj.CartItemList.filter(
                        (a) => a.StatusID != 4,
                      ).map((item, i) => {
                        if (i < 2) {
                          return (
                            <div key={i} className="product">
                              <div className="product-details">
                                <h4 className="product-title">
                                  <a href="#">{item.ProductTitle}</a>
                                </h4>
                                <a
                                  href={
                                    '/productdetail?ProductId=' + item.ProductID
                                  }
                                >
                                  <span className="cart-product-info">
                                    <span className="cart-product-qty">
                                      x {' '}{item.Quantity} 
                                    </span>
                                    : Total({' '}
                                    {default_currency.symbol +
                                      item.ItemTotalPrice.toFixed(2)}
                                    )
                                  </span>
                                </a>
                              </div>
                              {/* <figure className="product-image-container">
                                  <a href={"/productdetail?ProductId="} className="product-image"><img src="assets/images/products/cart/product-1.jpg" alt="product" /></a>
                                  <a href="#" className="btn-remove" title="Remove Product"><i className="icon-retweet" /></a>
                                </figure> */}
                            </div>
                          );
                        }
                      })
                    ) : (
                      <></>
                    )}
                  </div>
                  {/* <div className="dropdown-cart-total"><span>Total</span><span className="cart-total-price">$134.00</span></div> */}
                  <div className="dropdown-cart-action">
                    <a
                      href=""
                      onClick={(e) => {
                        e.preventDefault();
                        window.location.href = '/cartdetail';
                      }}
                      className="btn btn-block"
                    >
                      View Cart Details
                    </a>
                  </div>
                </div>
              </div>
            </div>
            <div className="header-user">
              {/* onClick={(e)=>{ this.setState({UserBoxVisible : true})}} */}
              <i className="icon-user-2" />
              <div className="account-wrap">
                <div className="main_name">
                  <div className="carret" />
                  {this.state.doesSessionExists == true ? (
                    <>
                      <div className="mn1">
                        <img
                          ref={this.profileImgRef}
                          className="wt-circle wt-icon"
                          src={
                            baseUrlImage +
                            ImageEntityEnum.USER +
                            '/' +
                            this.state.sessionProfileObj.ProfileID +
                            '/' +
                            this.state.sessionProfileObj.ImagePath
                          }
                          alt=""
                          onError={() => {
                            this.profileImgRef.current.src =
                              'https://img2.etsystatic.com/site-assets/images/global-nav/no-user-avatar.svg';
                          }}
                        />
                      </div>

                      <div className="mn2">
                        <p className="acc_name">
                          {this.state.sessionProfileObj.FirstName +
                            ' ' +
                            this.state.sessionProfileObj.LastName}
                        </p>
                        <a
                          style={{ textDecoration: 'underline' }}
                          href="#"
                          onClick={(e) => {
                            e.preventDefault();
                            window.location.href = '/MyAccount';
                          }}
                        >
                          My Account
                        </a>
                      </div>
                    </>
                  ) : (
                    <div style={{ padding: '15px' }}>
                      <p className="acc_name">
                        Click to sign into your account now!
                      </p>
                    </div>
                  )}
                  <div style={{ clear: 'both' }} />
                </div>
                {this.state.doesSessionExists == true ? (
                  <ul>
                    <li>
                      <a href="/chat">
                        <p>
                          <span>
                            <i className="far fa-comments" />
                          </span>
                          Messages
                          {/*this.state.sessionProfileObj &&
                          this.state.sessionProfileObj.UnreadMessageCount &&
                          parseInt(
                            this.state.sessionProfileObj.UnreadMessageCount,
                          ) > 0 ? (
                            <span
                              className="badge bg-warning"
                              style={{ marginLeft: '5px', zoom: '122%' }}
                            >
                              {this.state.sessionProfileObj.UnreadMessageCount}
                            </span>
                          ) : (
                            <></>
                          )*/}
                        </p>
                      </a>
                    </li>
                    {this.state.sessionProfileObj.ShopId ? (
                      <li>
                        <a href="/ShopSettings">
                          <p>
                            <span>
                              <i className="fas fa-cogs" />
                            </span>
                            Shop Settings
                          </p>
                        </a>
                      </li>
                    ) : (
                      <></>
                    )}

                    <li>
                      <a
                        href="#"
                        onClick={() => {
                          clearStorage();
                          window.location.href = '/';
                        }}
                      >
                        <p>
                          <span>
                            <i className="fas fa-sign-out-alt" />
                          </span>
                          Sign out
                        </p>
                      </a>
                    </li>
                  </ul>
                ) : (
                  <ul>
                    {getStorageItem(PROFILE_ID) ? (
                      <li>
                        <a href="/OrderList">
                          <p>
                            <span>
                              <i className="fas fa-cart-arrow-down" />
                            </span>
                            Orders
                          </p>
                        </a>
                      </li>
                    ) : (
                      <></>
                    )}
                    <li>
                      <a href="/LoginSignUp">
                        <p>
                          <span>
                            <i className="fas fa-sign-in-alt" />
                          </span>
                          Sign In
                        </p>
                      </a>
                    </li>
                  </ul>
                )}
              </div>
            </div>
          </div>
          <div style={{ clear: 'both' }} />

          {/* <div className="headermiddle-bottom">
              <nav className="main-nav">
                <ul className="menu sf-js-enabled sf-arrows" style={{touchAction: 'pan-y'}}>
                  
                </ul>
              </nav>
            </div>
            */}
          <div className="headermiddle-bottom">
            <nav className="main-nav">
              <ul
                className="menu sf-js-enabled sf-arrows"
                style={{ touchAction: 'pan-y' }}
              >
                <li className="all_categories">
                  <a href="#" className="sf-with-ul">
                    <i className="fa fa-bars" aria-hidden="true" /> Categories
                  </a>
                  <div className="all_categories_inner megamenu megamenu-fixed-width">
                    <ul
                      className="in-side-menu submenu"
                      style={{ display: 'block' }}
                    >
                      {mainCategories.map((item, i) => (
                        <li key={i}>
                          <a
                            href={
                              '/search?' +
                              `CategoryID=${item.CategoryID}&openFilter=${this.state.openFilter}`
                            }
                          >
                            {item.CategoryTitle}
                            {sublvl1Categories.find(
                              (f) => f.CategoryParentID == item.CategoryID,
                            ) ? (
                              <i
                                className="fa fa-angle-right"
                                aria-hidden="true"
                              />
                            ) : (
                              <></>
                            )}
                          </a>
                          {sublvl1Categories.find(
                            (f) => f.CategoryParentID == item.CategoryID,
                          ) ? (
                            <div className="categories_inner_sub_main">
                              {sublvl1Categories &&
                              sublvl1Categories.length > 0 ? (
                                sublvl1Categories
                                  .filter(
                                    (f) =>
                                      f.CategoryParentID == item.CategoryID,
                                  )
                                  .map((slvl1item, j) => (
                                    <div
                                      className={
                                        'categories_inner_sub-menu ' +
                                        (j % 2 == 0 ? 'c2' : 'c1')
                                      }
                                      key={j}
                                    >
                                      <a
                                        href={
                                          '/search?' +
                                          `CategoryID=${slvl1item.CategoryID}&openFilter=${this.state.openFilter}`
                                        }
                                      >
                                        <h2>{slvl1item.CategoryTitle}</h2>
                                      </a>
                                      <ul>
                                        {sublvl2Categories &&
                                        sublvl2Categories.length > 0 ? (
                                          sublvl2Categories
                                            .filter(
                                              (f) =>
                                                f.CategoryParentID ==
                                                slvl1item.CategoryID,
                                            )
                                            .map((slvl2item, k) => (
                                              <li key={k}>
                                                <a
                                                  href={
                                                    '/search?' +
                                                    `CategoryID=${slvl2item.CategoryID}&openFilter=${this.state.openFilter}`
                                                  }
                                                >
                                                  {slvl2item.CategoryTitle}
                                                </a>
                                              </li>
                                            ))
                                        ) : (
                                          <></>
                                        )}
                                      </ul>
                                    </div>
                                  ))
                              ) : (
                                <></>
                              )}
                            </div>
                          ) : (
                            <></>
                          )}
                        </li>
                      ))}
                    </ul>
                  </div>
                </li>
                {mainCategories && mainCategories.length > 0 ? (
                  //mainCategories.map((item,i)=>{
                  (() => {
                    let arrOptions = [];

                    for (let i = 0; i < mainCategories.length; i++) {
                      if (i >= 7) {
                        break;
                      }

                      let item = mainCategories[i];
                      // let childoptions = [];
                      // let selectedParentsChildCategories = childCategories.filter(a=> (a.ParentsList.find(b=> b.CategoryID == item.CategoryID)))

                      // let j=0;
                      // for(let subItem of selectedParentsChildCategories){
                      //   childoptions.push(<li key={"c"+j}><a href={'/search?'+`CategoryID=${subItem.CategoryID}&openFilter=${this.state.openFilter}`}>{subItem.CategoryTitle}</a></li>)
                      //   j++;
                      // }
                      // let option = <li key={"p"+i} >
                      //             <a href={'/search?' + `CategoryID=${item.CategoryID}&openFilter=${this.state.openFilter}`} onMouseOver={()=>{this.showImage(item.LogoPath)}} className="sf-with-ul">{item.CategoryTitle}</a>
                      //               <div className="megamenu megamenu-fixed-width" style={{display: 'none'}}>
                      //                 <div className="row row-sm">
                      //                   <div className="col-lg-6">
                      //                   <ul className="submenu">
                      //                   {childoptions}
                      //                   </ul>
                      //                   </div>
                      //                   <div className="col-lg-6">
                      //                   <img src={this.state.selectedCategoryImg}/>
                      //                   </div>
                      //                 </div>
                      //               </div>
                      //               </li>
                      // arrOptions.push(option)
                      if (item.IsSystem === true && item.CategoryTypeID === 1) {
                        let option = (
                          <li key={i} className="all_categories">
                            <a href="#" className="sf-with-ul">
                              {/* <i className="fa fa-bars" aria-hidden="true" />  */}
                              {item.CategoryTitle}
                            </a>
                            <div
                              className="all_categories_inner megamenu megamenu-fixed-width"
                              id="all_categories"
                            >
                              <ul
                                className="in-side-menu submenu"
                                style={{ display: 'block' }}
                              >
                                {sublvl1Categories &&
                                sublvl1Categories.length > 0 ? (
                                  sublvl1Categories
                                    .filter(
                                      (f) =>
                                        f.CategoryParentID == item.CategoryID,
                                    )
                                    .map((slvl1item, j) => (
                                      <li key={j}>
                                        <a
                                          href={
                                            '/search?' +
                                            `CategoryID=${slvl1item.CategoryID}&openFilter=${this.state.openFilter}`
                                          }
                                        >
                                          {slvl1item.CategoryTitle}
                                          {sublvl2Categories.find(
                                            (f) =>
                                              f.CategoryParentID ==
                                              slvl1item.CategoryID,
                                          ) ? (
                                            <i
                                              className="fa fa-angle-right"
                                              aria-hidden="true"
                                            />
                                          ) : (
                                            <></>
                                          )}
                                        </a>
                                        {sublvl2Categories.find(
                                          (f) =>
                                            f.CategoryParentID ==
                                            slvl1item.CategoryID,
                                        ) ? (
                                          <div className="categories_inner_sub_main">
                                            {sublvl2Categories &&
                                            sublvl2Categories.length > 0 ? (
                                              sublvl2Categories
                                                .filter(
                                                  (f) =>
                                                    f.CategoryParentID ==
                                                    slvl1item.CategoryID,
                                                )
                                                .map((slvl2item, k) => (
                                                  <div
                                                    className={
                                                      'categories_inner_sub-menu ' +
                                                      (k % 2 == 0 ? 'c2' : 'c1')
                                                    }
                                                    key={k}
                                                  >
                                                    <a
                                                      href={
                                                        '/search?' +
                                                        `CategoryID=${slvl2item.CategoryID}&openFilter=${this.state.openFilter}`
                                                      }
                                                    >
                                                      <h2>
                                                        {
                                                          slvl2item.CategoryTitle
                                                        }
                                                      </h2>
                                                    </a>
                                                    <ul>
                                                      {sublvl3Categories &&
                                                      sublvl3Categories.length >
                                                        0 ? (
                                                        sublvl3Categories
                                                          .filter(
                                                            (f) =>
                                                              f.CategoryParentID ==
                                                              slvl2item.CategoryID,
                                                          )
                                                          .map(
                                                            (slvl3item, l) => (
                                                              <li key={l}>
                                                                <a
                                                                  href={
                                                                    '/search?' +
                                                                    `CategoryID=${slvl3item.CategoryID}&openFilter=${this.state.openFilter}`
                                                                  }
                                                                >
                                                                  {
                                                                    slvl3item.CategoryTitle
                                                                  }
                                                                </a>
                                                              </li>
                                                            ),
                                                          )
                                                      ) : (
                                                        <></>
                                                      )}
                                                    </ul>
                                                  </div>
                                                ))
                                            ) : (
                                              <></>
                                            )}
                                          </div>
                                        ) : (
                                          <></>
                                        )}
                                      </li>
                                    ))
                                ) : (
                                  <></>
                                )}
                              </ul>
                            </div>
                          </li>
                        );
                        arrOptions.push(option);
                      }
                    }
                    return arrOptions;
                  })()
                ) : (
                  <></>
                )}
              </ul>
            </nav>
          </div>
        </div>
      </div>
    );
  }
}

export default HeaderMiddle;
