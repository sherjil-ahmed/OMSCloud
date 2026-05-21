import React from 'react';
import {
  USER_PROFILE,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  PROFILE_ID,
} from '../../../utils/constants';
import {
  FetchData,
  baseUrlImage,
  baseUrl,
  FetchData_Override,
} from '../../../utils/serviceHelper';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import { ImageEntityEnum, ImageUploadConfig } from '../../../utils/enums';

const IMAGE_ERR_MSG = {
  HEIGHT_EXCEED: 'file height exceeded',
  WIDTH_EXCEED: 'file width exceeded',
  SIZE_EXCEED: 'file size exceeded',
  INVALID_TYPE: 'Invalid file type',
};

class ShopSummary extends React.Component {
  constructor(props) {
    super(props);
    this.refAnnouncments = React.createRef();
    this.refFAQs = React.createRef();
    this.refShopPolicy = React.createRef();
    this.refUploadInput = React.createRef();
    this.shopImage = React.createRef();
    this.state = {
      userProfile: getStorageItem(USER_PROFILE),
      supplierDetails: {},
      webJ: '',
      Logo: '',
      LogoSrc: '',
      Accouncmentshtml: '',
      ShopPolicyhtml: '',
      FAQshtml: '',
    };
  }
  componentDidMount() {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Supplier_GetSupplierPublicByProfileId +
        this.state.userProfile.ProfileID,
      null,
      this.gotSupplierDetails,
    );
  }
  gotSupplierDetails = (res) => {
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
          Announcementhtml: res.AnnouncementHTML,
          FAQshtml: res.FAQHTML,
          ShopPolicyhtml: res.PolicyHTML,
        },
        () => {
          if (this.refAnnouncments)
            this.refAnnouncments.current.innerHTML = this.state.Announcementhtml;

          if (this.refShopPolicy)
            this.refShopPolicy.current.innerHTML = this.state.ShopPolicyhtml;

          if (this.refFAQs)
            this.refFAQs.current.innerHTML = this.state.FAQshtml;
        },
      );
    }
  };
  render() {
    return (
      <div className="container">
        <div className="row">
          <div className="col-sm-4 npad account_info">
            <div className="row upload-row">
              <div className="col col-md-12">
                <img
                  ref={this.shopImage}
                  src={this.state.LogoSrc}
                  onError={() => {
                    this.shopImage.current.src =
                      'assets/images/logos/shop.png';
                  }}
                  alt="test"
                />
                <p className="text-center mt-1">
                  {this.state.supplierDetails.SupplierName}
                </p>
                <div />
              </div>
            </div>
          </div>
          {/* End .row */}
          <div className="col-sm-8 top_padding">
            <div className="row">
              <div className="col-md-6">
                <div className="row">
                  <div className="col-sm-3">
                    <label htmlFor="acc-name">
                      {' '}
                      <img
                        src="assets/images/logos/f.png"
                        alt=""
                        className="shop_account_social_icon_image"
                      />
                    </label>
                  </div>
                  <div className="col-sm-9">
                    <div>
                      <span></span>
                      <input
                        type="url"
                        className="form-control"
                        placeholder="Socialmedia-link"
                        name="fb"
                        value={this.state.webJ.fb ? this.state.webJ.fb : ''}
                      />
                    </div>
                    {/* End .form-group */}
                  </div>
                </div>
              </div>
              {/* End .col-md-4 */}
              <div className="col-md-6">
                <div className="row">
                  <div className="col-sm-3">
                    <label htmlFor="acc-name">
                      {' '}
                      <img
                        src="assets/images/logos/shop.png"
                        alt=""
                        className="shop_account_social_icon_image"
                      />
                    </label>
                  </div>
                  <div className="col-sm-9">
                    <div className="form-group">
                      <input
                        type="url"
                        className="form-control"
                        placeholder="Socialmedia-link"
                        name="goog"
                        value={this.state.webJ.goog ? this.state.webJ.goog : ''}
                      />
                    </div>
                    {/* End .form-group */}
                  </div>
                </div>
              </div>
              {/* End .col-md-4 */}
              <div className="col-md-6">
                <div className="row">
                  <div className="col-sm-3">
                    <label htmlFor="acc-name">
                      {' '}
                      <img
                        src="assets/images/logos/i.png"
                        alt=""
                        className="shop_account_social_icon_image"
                      />
                    </label>
                  </div>
                  <div className="col-sm-9">
                    <div className="form-group">
                      <input
                        type="url"
                        className="form-control"
                        placeholder="Socialmedia-link"
                        name="instagrm"
                        value={
                          this.state.webJ.instagrm
                            ? this.state.webJ.instagrm
                            : ''
                        }
                      />
                    </div>
                    {/* End .form-group */}
                  </div>
                </div>
              </div>
              {/* End .col-md-4 */}
              <div className="col-md-6">
                <div className="row">
                  <div className="col-sm-3">
                    <label htmlFor="acc-name">
                      {' '}
                      <img
                        src="assets/images/logos/pp.png"
                        alt=""
                        className="shop_account_social_icon_image"
                      />
                    </label>
                  </div>
                  <div className="col-sm-9">
                    <div className="form-group">
                      <input
                        type="url"
                        className="form-control"
                        placeholder="Socialmedia-link"
                        name="pinterest"
                        value={
                          this.state.webJ.pinterest
                            ? this.state.webJ.pinterest
                            : ''
                        }
                      />
                    </div>
                    {/* End .form-group */}
                  </div>
                </div>
              </div>
              {/* End .col-md-4 */}
              <div className="col-md-6">
                <div className="row">
                  <div className="col-sm-3">
                    <label htmlFor="acc-name">
                      {' '}
                      <img
                        src="assets/images/logos/t.png"
                        alt=""
                        className="shop_account_social_icon_image"
                      />
                    </label>
                  </div>
                  <div className="col-sm-9">
                    <div className="form-group">
                      <input
                        type="url"
                        className="form-control"
                        placeholder="Socialmedia-link"
                        name="twitr"
                        value={
                          this.state.webJ.twitr ? this.state.webJ.twitr : ''
                        }
                      />
                    </div>
                    {/* End .form-group */}
                  </div>
                </div>
              </div>
              {/* End .col-md-4 */}
              <div className="col-md-6">
                <div className="row">
                  <div className="col-sm-3">
                    <label htmlFor="acc-name">
                      {' '}
                      <img
                        src="assets/images/logos/y.png"
                        alt=""
                        className="shop_account_social_icon_image"
                      />
                    </label>
                  </div>
                  <div className="col-sm-9">
                    <div className="form-group">
                      <input
                        type="url"
                        className="form-control"
                        placeholder="Socialmedia-link"
                        name="youtb"
                        value={
                          this.state.webJ.youtb ? this.state.webJ.youtb : ''
                        }
                      />
                    </div>
                    {/* End .form-group */}
                  </div>
                  <div className="checkout-steps-action"></div>
                </div>
              </div>
              {/* End .col-md-4 */}
            </div>
            {/* End .row */}
          </div>
          {/* End .col-sm-11 */}
        </div>
        <div className="col-sm-12">
          <div className="form-group">
            <label htmlFor="acc-name">Announcements</label>
            <div ref={this.refAnnouncments}></div>
          </div>
          {/* End .form-group */}
        </div>
        <div className="col-sm-12">
          <div className="form-group">
            <label htmlFor="acc-name">Shop Policy</label>
            <div ref={this.refShopPolicy}></div>
          </div>
          {/* End .form-group */}
        </div>
        <div className="col-sm-12">
          <div className="form-group">
            <label htmlFor="acc-name">FAQs</label>
            <div ref={this.refFAQs}></div>
          </div>
          {/* End .form-group */}
        </div>
      </div>
    );
  }
}
export default ShopSummary;
