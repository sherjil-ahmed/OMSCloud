import React from 'react';
import OwlCarousel from 'react-owl-carousel';
import 'owl.carousel/dist/assets/owl.carousel.css';
import 'owl.carousel/dist/assets/owl.theme.default.css';
import { getStorageItem, setStorageItem } from '../../../utils/storageHelper';
import {
  PROFILE_ID,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  RECENTLY_VIEWED_ITEMS,
} from '../../../utils/constants';
import { ImageEntityEnum } from '../../../utils/enums';
import { LIST_CATEGORY } from '../../../utils/constants';
import { FetchData, baseUrlImage } from '../../../utils/serviceHelper';
import { default_currency } from '../../../utils/globalConstants';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR, SIZE } from '../../../utils/constants';

class Body extends React.Component {
  constructor(props) {
    super(props);
    this.productModal = React.createRef();
    this.ModalQtyRef = React.createRef();
    this.state = {
      listCategory: getStorageItem(LIST_CATEGORY)
        ? getStorageItem(LIST_CATEGORY)
        : [],
      popularProduct: {},
      productQuantity: 1,
      recentlyViewedItem: [],
      options: {                    //For OwlCarousel responsiveness
        responsive: {
            0: {
                items: 1,
            },
            600: {
                items: 3,
            },
            1000: {
                items: 5,
            },
        },
    },
    };
  }
  componentDidMount() {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Product_GetPopularProductList,
      null,
      this.successGetPopularProducts,
    );
    this.setState({
      recentlyViewedItem: getStorageItem(RECENTLY_VIEWED_ITEMS),
    });
  }
  successGetPopularProducts = (res) => {
    this.setState(
      {
        popularProduct: res,
      },
      () => {
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

  render() {
    let recentlyViewedItemList = [];
    if (this.state.recentlyViewedItem) {
      if (this.state.recentlyViewedItem.length <= 5) {
        for (let i = 0; i < this.state.recentlyViewedItem.length; i++) {
          if (this.state.recentlyViewedItem[i]) {
            recentlyViewedItemList.push(this.state.recentlyViewedItem[i]);
          }
        }
      } else {
        for (
          let i = this.state.recentlyViewedItem.length - 1;
          i > this.state.recentlyViewedItem.length - 6;
          i--
        ) {
          if (i > 0 && this.state.recentlyViewedItem[i]) {
            recentlyViewedItemList.push(this.state.recentlyViewedItem[i]);
          }
        }
      }
    }
    let popularProduct = this.state.popularProduct;
    let mainCategories =
      this.state.listCategory && this.state.listCategory.length > 0
        ? this.state.listCategory.filter((a) => a.CategoryTypeID == 1)
        : [];
    return (
      <main id="main" className="main home">
        <div className="container-fluid">
          

          <section className="mainprodiv">
            {popularProduct && popularProduct.length > 5 ? (
                <div className="section-title">
                  <h2>Popular right now</h2>
                </div>
              ) : (
                <></>
              )}
            <div className="container-fluid">
              {popularProduct && popularProduct.length > 5 ? (
                <OwlCarousel
                  className="owl-theme"
                  {...this.state.options}
                  margin={5}
                  loop
                  items={4}
                  nav
                  autoplay={true}
                 
                >
                  {popularProduct.map((item, index) => (
                    <div key={index} className="product-default pt-2 in-pro">
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
                        <a href={'/productdetail?ProductId=' + item.ProductID}>
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
                            href={'/productdetail?ProductId=' + item.ProductID}
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
                                  '' + parseFloat(item.Rating / 5) * 100 + '%',
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
                              {default_currency.symbol +
                                (parseInt(item.DiscountAmount) +
                                  item.SellingPrice)}
                            </span>
                          ) : (
                            <></>
                          )}
                          <span className="product-price">
                            {default_currency.symbol + item.SellingPrice}
                          </span>
                        </div>
                        {/* End .price-box */}

                        <div className="product-action">
                          {/* <a href="#" className="btn-icon-wish"><i className="icon-heart" /></a> */}
                          <a
                            className="btn-icon btn-add-cart"
                            href={'/productdetail?ProductId=' + item.ProductID}
                            
                          >
                            <i className="icon-bag" />
                            ADD TO CART
                          </a>
                          {/* <button className="btn-icon btn-add-cart" data-toggle="modal" data-target="#addCartModal" onClick={()=>{this.setState ({ productIDForCart: item.ProductID })}}><i className="icon-bag" />ADD TO CART</button> */}
                          {/* <a href={baseUrlImage + ImageEntityEnum.PRODUCT + "/" + item.ProductID + "/" + item.Image} className="btn-quickview" title="Quick View"><i className="fas fa-external-link-alt" /></a>  */}
                        </div>
                      </div>
                      {/* End .product-details */}
                    </div>
                  ))}
                </OwlCarousel>
              ) : (
                <></>
              )}
            </div>
          </section>
          <section className="">
            {recentlyViewedItemList && recentlyViewedItemList.length > 5 ? (
              <div className="section-title">
                <h2>Recently Viewed Products</h2>
              </div>
            ) : (
              <></>
            )}
            <div className="container-fluid">
              {recentlyViewedItemList && recentlyViewedItemList.length > 5 ? (
                <OwlCarousel
                  className="owl-theme"
                  {...this.state.options}
                  margin={5}
                  loop
                  items={
                    recentlyViewedItemList.length > 4
                      ? 4
                      : recentlyViewedItemList.length
                  }
                  nav
                  autoplay={true}
                >
                  {recentlyViewedItemList.map((item2, index2) => (
                    <div key={index2} className="product-default pt-2">
                      <figure>
                        {item2 && item2.DiscountValue ? (
                          //<span className="product-label label-sale">{item2.Discount}{item2.IsDiscountPercentage ? "%":default_currency.symbol} OFF</span>
                          <span className="product-label label-sale">
                            {item2.DiscountValue
                              ? item2.IsDiscountPercentage
                                ? item2.DiscountValue + '%' + ' OFF'
                                : default_currency.symbol +
                                  item2.DiscountValue +
                                  ' OFF'
                              : ''}
                            {/* {parseFloat(((item2.SellingPrice)-((parseInt(item2.DiscountValue)+(item2.SellingPrice))))/(parseInt(item2.DiscountValue)+(item2.SellingPrice))*100).toFixed(0)}% OFF*/}
                          </span>
                        ) : (
                          <></>
                        )}
                        <a href={'/productdetail?ProductId=' + item2.ProductID}>
                          {item2.ProductImages &&
                          item2.ProductImages.length > 0 &&
                          item2.ProductImages.find(
                            (a) => a.IsDefault === true,
                          ) ? (
                            <img
                              src={
                                baseUrlImage +
                                ImageEntityEnum.PRODUCT +
                                '/' +
                                item2.ProductID +
                                '/' +
                                item2.ProductImages.find(
                                  (a) => a.IsDefault === true,
                                ).ImageFileName
                              }
                            />
                          ) : (
                            <></>
                          )}
                        </a>
                        {/* <span class="product-label label-sale">27% OFF</span> */}
                      </figure>
                      <div className="product-details">
                        {/* <h2 className="product-category">
              <a href={(item2.Category)?"/search?CategoryID="+item2.Category.CategoryID+"&openFilter="+this.state.openFilter : "/search?CategoryID="+"&openFilter="+this.state.openFilter}>{(item2.Category)? item2.Category.CategoryTitle : ""}</a>
            </h2> */}
                        <h2 className="product-title">
                          <a
                            href={'/productdetail?ProductId=' + item2.ProductID}
                          >
                            {item2.ProductTitle}
                          </a>
                        </h2>
                        <div className="ratings-container">
                          <div className="product-ratings">
                            <span
                              className="ratings"
                              style={{
                                width:
                                  '' + parseFloat(item2.Rating / 5) * 100 + '%',
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
                                item2.SupplierID +
                                '&openFilter=' +
                                this.state.openFilter
                              }
                              target="_blank"
                            >
                              {item2.SupplierName}
                            </a>
                          </span>
                        </div>
                        <div className="price-box">
                          {item2.DiscountValue && item2.DiscountValue > 0 ? (
                            <span className="before-discount-price">
                              {default_currency.symbol + item2.SellingPrice}
                            </span>
                          ) : (
                            <></>
                          )}
                          <span className="product-price">
                            {item2.IsDiscountPercentage
                              ? default_currency.symbol +
                                (item2.SellingPrice -
                                  parseFloat(
                                    parseFloat(item2.DiscountValue / 100) *
                                      item2.SellingPrice,
                                  ).toFixed(2))
                              : default_currency.symbol +
                                (item2.SellingPrice -
                                  parseFloat(item2.DiscountValue).toFixed(2))}
                            {/* {default_currency.symbol+(parseInt(item2.DiscountValue)+(item2.SellingPrice))} */}
                          </span>
                        </div>
                        {/* End .price-box */}
                        <div className="product-action">
                          {/* <a href="#" className="btn-icon-wish"><i className="icon-heart" /></a> */}
                          <a
                            className="btn-icon btn-add-cart"
                            href={'/productdetail?ProductId=' + item2.ProductID}
                          >
                            <i className="icon-bag" />
                            ADD TO CART
                          </a>
                          {/* <button className="btn-icon btn-add-cart" data-toggle="modal" data-target="#addCartModal" onClick={()=>{this.setState ({ productIDForCart: item2.ProductID })}}><i className="icon-bag" />ADD TO CART</button> */}
                          {/* <a href={baseUrlImage + ImageEntityEnum.PRODUCT + "/" + item2.ProductID + "/" + item2.Image} className="btn-quickview" title="Quick View"><i className="fas fa-external-link-alt" /></a>  */}
                        </div>
                      </div>
                      {/* End .product-details */}
                    </div>
                  ))}
                </OwlCarousel>
              ) : (
                <></>
              )}
            </div>
          </section>
          <section className="sec-2 hidden" id="section2">
          <div className="container" >
            <div className="row">
              <div className="col-md-12">
                <div className="sec-cont">
                  <div className="row">
                    <div className="col-md-6">
                      <div className="service-widget">
                        <i className="service-icon icon-shipping" />
                        <div className="service-content">
                          <h3 className="service-title">Local and Country-Wide Delivery</h3>
                            <p>Local sellers can arrange delivery with local customers through our open chats system and can also deliver to customers by mail shipping countrywide.</p>
                        </div>
                      </div>
                    </div>
                    <div className="col-md-6">
                      <div className="service-widget">
                        <i className="service-icon icon-money" />
                        <div className="service-content">
                          <h3 className="service-title">Free Cash Transactions</h3>
                          <p>
                            Sellers and customers are able to make transactions in cash 
                            if they mutually choose to and it is completely free from Zvonr’s fee.
                          </p>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-6">
                      <div className="service-widget">
                        <i className="service-icon icon-support" />
                        <div className="service-content">
                          <h3 className="service-title">online support 24/7</h3>
                          <p>We are on 24/7 standby to answer your questions through emails and in support chat. </p>
                        </div>
                      </div>
                    </div>
                    <div className="col-md-6 ">
                      <div className="service-widget">
                        <i className="service-icon icon-secure-payment" />
                        <div className="service-content">
                          <h3 className="service-title">Secure Payment</h3>
                          <p>All of our customers’ transactions, privacy and data are secured 
                          with the highest standard and regulations in the industry.</p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>        
                </div>
        <div className="container-fluid text-center full">
          <section className="product-panel mt-6 full-g">
            <div className="section-title">
              <h1>Zvonr</h1>
            </div>
            <div>
              <p>
              Zvonr allows tremendous business opportunities and empowers you to make use of your
in-house resources. Make your goods at your home, create your shop at Zvonr marketplace
and sell. All from the convenience of your home. Besides, you can sell your services too.
              </p>
            </div>
          <div className="container" >
            <div className="row">
              <div className="col-md-12">
                <div className="sec-cont">
                  <div className="row">
                    <div className="col-md-6">
                      <div className="service-widget">
                        <i className="service-icon icon-shipping" />
                        <div className="service-content">
                          <h3 className="service-title">Local and Country-Wide Delivery</h3>
                            <p>Local sellers can use our chat system to communicate with local buyers for delivery or pick-up arrangements.</p>
                        </div>
                      </div>
                    </div>
                    <div className="col-md-6">
                      <div className="service-widget">
                        <i className="service-icon icon-money" />
                        <div className="service-content">
                          <h3 className="service-title">Free Cash Transactions</h3>
                          <p>
                          Sellers and customers can make transactions in cash if they mutually choose to and there is NO fee charged by Zvonr for cash transactions.
                          </p>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-6">
                      <div className="service-widget">
                        <i className="service-icon icon-support" />
                        <div className="service-content">
                          <h3 className="service-title">online support 24/7</h3>
                          <p>We are on 24/7 standby to answer your questions through emails and support chat. </p>
                        </div>
                      </div>
                    </div>
                    <div className="col-md-6 ">
                      <div className="service-widget">
                        <i className="service-icon icon-secure-payment" />
                        <div className="service-content">
                          <h3 className="service-title">Secure Payment</h3>
                          <p>All of our customers’ transactions and data are secured as per the highest standard. Our operations are compliant with industry regulations.</p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        
          </section>
          
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
                      onChange={(e) => {}}
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
        </div>
      </main>
    );
  }
}

export default Body;
