import React from 'react';
import {
  USER_PROFILE,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  PROFILE_ID,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  INPROC_CHATID,
  SIZE,
  IS_USER_LOGGEDIN
} from '../../../utils/constants';
import moment from 'moment';
import { FetchData, baseUrlImage } from '../../../utils/serviceHelper';
import {
  ImageEntityEnum,
  AddressTypeID,
  RatingSubject,
} from '../../../utils/enums';
import { getStorageItem, setStorageItem } from '../../../utils/storageHelper';
import izitoast from 'izitoast';
import 'izitoast/dist/css/iziToast.css';

class ShopSummary extends React.Component {
  constructor(props) {
    super(props);
    this.refUploadInput = React.createRef();
    this.shopImage = React.createRef();
    this.userImage = React.createRef();
    this.state = {
      userProfile: props.shopData,
      supplierDetails: {},
      webJ: {},
      Logo: '',
      LogoSrc: '',
      completeShopAddress: {},
      comments: [],
    };
  }
  componentDidMount() {
    console.log("ProfileId - Review Bool", getStorageItem(PROFILE_ID));
    
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Supplier_GetSupplierPublic +
        this.state.userProfile.ShopId + '/' + getStorageItem(PROFILE_ID),
      null,
      this.gotSupplierDetails,
    );
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.CustomerReview_GetCustomerReviewList +
        '?authorId=' +
        '' +
        '&subject=' +
        RatingSubject.SHOP.value +
        '&SubjectRowId=' +
        this.state.userProfile.ShopId +
        '&statusId=' +
        2,
      null,
      this.successGetCustomerReviewList,
    );
  }
  successGetCustomerReviewList = (res) => {
    console.log("Review",res);
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

  gotSupplierDetails = (res) => {
    console.log("Suplier Detail" , res);
    if (res != null) {
      this.setState(
        {
          supplierDetails: res,
          webJ: JSON.parse(res.WebLinksJSON),
          Logo: res.Logo ? res.Logo : '',
          LogoSrc:
            baseUrlImage +
            ImageEntityEnum.SUPPLIER +
            '/' +
            this.state.userProfile.ShopId +
            '/' +
            res.Logo,
        },
        () => {
          if (res.IsBusinessAddressVisible) {
            FetchData(
              REQUEST_TYPE.GET,
              SERVICE_ENDPOINTS.Address_GetAddressListByProfileid +
                '?Id=' +
                res.ShopOwnerProfileId +
                '&AddressTypeID=' +
                AddressTypeID.ShopAddressType,
              null,
              this.gotUserData,
            );
          }
        },
      );
    }
  };
  gotUserData = (res) => {
    this.setState({
      completeShopAddress: res,
    });
  };
  successInitiateChat = (res) => {
    if (res == '-1') {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message:
          'Please register an account on the Zvonr marketplace in order to chat with any seller!',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
          color: COLOR.GREEN,
      });
    } else {
      setStorageItem(INPROC_CHATID, {
        chatId: res,
        profileId: this.state.supplierDetails.ShopOwnerProfileId,
      });
      setTimeout(() => {
        window.location.href = '/chat';
      }, 1000);
    }
  };

  initiateChat = () => {
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Chat_InitiateChat +
        '?sender=' +
        getStorageItem(PROFILE_ID) +
        '&receiver=' +
        this.state.supplierDetails.ShopOwnerProfileId,
      null,
      this.successInitiateChat,
    );
  };

  render() {
    let _completeShopAddress = this.state.completeShopAddress[0];
    let shopReviewElement = this.props.shopReviewElement
      ? this.props.shopReviewElement
      : {};
    let reviewsCount = this.state.comments ? this.state.comments.length : 0;
    let rating = (this.state.supplierDetails.ShopRating * 100) / 5;
    return (
      <div className="body">
        <div className="row product-bas-head">
          <div className="col-md-4 col-sm-4 pro-h-d1">
            <div className="row">
              {window.location.pathname == '/search' ||
              window.location.pathname == '/productdetail' ? (
                <div
                  className="col-md-4 special_hover_link"
                  style={{ cursor: 'pointer' }}
                  onClick={() => {
                    window.location.href =
                      '/ShopDetail?ShopId=' + this.state.supplierDetails.ShopID;
                  }}
                >
                  <img
                    className="shop-icon-external wt-rounded wt-display-block "
                    ref={this.shopImage}
                    src={this.state.LogoSrc}
                    onError={() => {
                      this.shopImage.current.src =
                        'assets/images/logos/shop.png';
                    }}
                    alt="test"
                  />
                </div>
              ) : (
                <div 
                className="col-md-4 special_hover_link"
                style={{ cursor: 'pointer' }}
                onClick={() => {
                  window.location.href =
                  '/search?' +
                  `ShopId=${this.state.supplierDetails.ShopID}&openFilter=`;
                }}
              >
                  <img
                    className="shop-icon-external wt-rounded wt-display-block "
                    ref={this.shopImage}
                    src={this.state.LogoSrc}
                    onError={() => {
                      this.shopImage.current.src =
                        'assets/images/logos/shop.png';
                    }}
                    alt="test"
                  />
                </div>
              )}
              <div className="col-md-8 shop_details_section">
                {window.location.pathname == '/search' ||
                window.location.pathname == '/productdetail' ? (
                  <h1
                    style={{ cursor: 'pointer' }}
                    className="Shoptitle special_hover_link"
                    onClick={() => {
                      window.location.href =
                        '/ShopDetail?ShopId=' +
                        this.state.supplierDetails.ShopID;
                    }}
                  >
                    {this.state.supplierDetails.ShopName}
                  </h1>
                ) : (
                  <h1                     
                      style={{ cursor: 'pointer' }}
                      className="Shoptitle special_hover_link"
                      onClick={() => {
                          window.location.href =
                          '/search?' +
                          `ShopId=${this.state.supplierDetails.ShopID}&openFilter=`;
                  }}>
                    {this.state.supplierDetails.ShopName}
                  </h1>
                )}
                <p className="shop_subtitle"></p>
                {this.state.supplierDetails.IsBusinessAddressVisible &&
                _completeShopAddress ? (
                  <div className="col-sm-9" style={{ paddingLeft: '5px' }}>
                    <p className="custom-font-size-address">
                      {_completeShopAddress.PlotNumber +", "+ _completeShopAddress.StreetNumber}
                    </p>
                    <p className="custom-font-size-address">
                      {_completeShopAddress.PostalCode}
                    </p>
                  </div>
                ) : (
                  <></>
                )}
                <p className="shop_location_detail">
                  {this.state.supplierDetails.City +", "+ this.state.supplierDetails.Province}
                </p>

                <div className="ratings-container">
                  <div className="product-ratings">
                    <span className="ratings" style={{ width: rating + '%' }} />
                    {/* End .ratings */}
                  </div>
                  {/* End .product-ratings */}
                  <a href="#" className="rating-link">
                    ( {reviewsCount} Reviews )
                  </a>
                </div>
              </div>
            </div>
          </div>
          <div className="col-md-4 col-sm-4 shop_social_media_section">
            
            {this.state.webJ && this.state.webJ.fb ? (
              this.state.webJ.fb.includes('//') ? (
                <a href={'//' + this.state.webJ.fb} target="_blank">
                  <i className="fa fa-facebook-square" />
                </a>
              ) : (
                <a href={'//' + this.state.webJ.fb} target="_blank">
                  <i className="fa fa-facebook-square" />
                </a>
              )
            ) : (
              <></>
            )}
            {this.state.webJ && this.state.webJ.goog ? (
              this.state.webJ.goog.includes('//') ? (
                <a href={this.state.webJ.goog} target="_blank">
                  <i className="fas fa-store" />
                </a>
              ) : (
                <a href={'//' + this.state.webJ.goog} target="_blank">
                  <i className="fas fa-store" />
                </a>
              )
            ) : (
              <></>
            )}
            {this.state.webJ && this.state.webJ.instagrm ? (
              this.state.webJ.instagrm.includes('//') ? (
                <a href={this.state.webJ.instagrm} target="_blank">
                  <i className="fa fa-instagram" />
                </a>
              ) : (
                <a href={'//' + this.state.webJ.instagrm} target="_blank">
                  <i className="fa fa-instagram" />
                </a>
              )
            ) : (
              <></>
            )}
            {this.state.webJ && this.state.webJ.twitr ? (
              this.state.webJ.twitr.includes('//') ? (
                <a href={this.state.webJ.twitr} target="_blank">
                  <i className="fa fa-twitter" />
                </a>
              ) : (
                <a href={'//' + this.state.webJ.twitr} target="_blank">
                  <i className="fa fa-twitter" />
                </a>
              )
            ) : (
              <></>
            )}
            {this.state.webJ && this.state.webJ.pinterest ? (
              this.state.webJ.pinterest.includes('//') ? (
                <a href={this.state.webJ.pinterest} target="_blank">
                  <i className="fa fa-pinterest" />
                </a>
              ) : (
                <a href={'//' + this.state.webJ.pinterest} target="_blank">
                  <i className="fa fa-pinterest" />
                </a>
              )
            ) : (
              <></>
            )}
            {this.state.webJ && this.state.webJ.youtb ? (
              this.state.webJ.youtb.includes('//') ? (
                <a href={this.state.webJ.youtb} target="_blank">
                  <i className="fa fa-youtube" />
                </a>
              ) : (
                <a href={'//' + this.state.webJ.youtb} target="_blank">
                  <i className="fa fa-youtube" />
                </a>
              )
            ) : (
              <></>
            )}
          </div>
          {window.location.pathname == '/ShopDetail' ||
          window.location.pathname == '/productdetail' ? (
            <div className="mt-5">
              <a
                onClick={() => {
                  window.location.href =
                    '/search?' +
                    `ShopId=${this.state.userProfile.ShopId}&openFilter=`;
                }}
              >
                <p className="custom-linkstyle special_hover_link">
                  View Shop's Products
                </p>
              </a>
            </div>
          ) : (
            <></>
          )}
          <div className="col-md-2 col-sm-4 shop_owner_description">
            <div className="img_container mtk">
              <img
                ref={this.userImage}
                className="avatar circle user-avatar-external"
                src={
                  baseUrlImage +
                  ImageEntityEnum.USER +
                  '/' +
                  this.state.supplierDetails.ShopOwnerProfileId +
                  '/' +
                  this.state.supplierDetails.ShopOwnerImage
                }
                onError={() => {
                  this.userImage.current.src =
                    'https://d1nhio0ox7pgb.cloudfront.net/_img/o_collection_png/green_dark_grey/512x512/plain/user.png';
                }}
                alt="test"
              />
              <div style={{ clear: 'both' }} />
              <p>{this.state.supplierDetails.ShopOwnerName}</p>
              <span
                style={{ cursor: 'pointer' }}
                onClick={(e) => {
                  if (getStorageItem(IS_USER_LOGGEDIN)) {
                    this.initiateChat();
                  } else {
                          izitoast.destroy();
      izitoast.show({

                      title: '',
                      icon: APP_ICONS.WARNING,
                      message:
                        'Please register an account on the Zvonr marketplace in order to chat with any seller!',
                      //position : APP_TOAST_POSITION.BOTTOM_CENTER,
                      target: '.testtarget',
                        color: COLOR.GREEN,
                    });
                  }
                }}
                className="etsy-icon wt-icon--smaller-xs wt-nudge-b-1 wt-mr-xs-1"
              >
                <div className="icon-chat">{' '} Shop's spokesperson</div>
                
              </span>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
export default ShopSummary;
