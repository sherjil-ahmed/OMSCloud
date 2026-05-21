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
} from '../../../utils/storageHelper';

class ShopAnnouncementsSummary extends React.Component {
  constructor(props) {
    super(props);
    this.refAnnouncments = React.createRef();
    this.refFAQs = React.createRef();
    this.refShopPolicy = React.createRef();
    this.state = {
      userProfile: props.shopData,
      supplierDetails: {},
      Accouncmentshtml: '',
      ShopPolicyhtml: '',
      FAQshtml: '',
    };
  }
  componentDidMount() {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Supplier_GetSupplierPublic +
        this.state.userProfile.ShopId + '/' + getStorageItem(PROFILE_ID),
      null,
      this.gotSupplierDetails,
    );
  }
  gotSupplierDetails = (res) => {
    if (res != null) {
      this.setState(
        {
          supplierDetails: res,
          Announcementhtml: res.AnnouncementHTML,
          FAQshtml: res.FAQHTML,
          ShopPolicyhtml: res.PolicyHTML,
        },
        () => {
          if (this.refAnnouncments && this.refAnnouncments.current)
            this.refAnnouncments.current.innerHTML = this.state.Announcementhtml;

          if (this.refShopPolicy && this.refShopPolicy.current)
            this.refShopPolicy.current.innerHTML = this.state.ShopPolicyhtml;

          if (this.refFAQs && this.refFAQs.current)
            this.refFAQs.current.innerHTML = this.state.FAQshtml;
        },
      );
    }
  };
  render() {
    return (
      <div className="body">
        <div className="row">
          <div className="col-sm-12">
          {this.refShopPolicy ? 
            <div className="row inrw">
              <div className="col-sm-2 npad shop_details_tabs">
                <p>Shop Policy</p>
              </div>
              <div className="col-sm-10 npad hb1 op1" ref={this.refShopPolicy}>
              </div>
            </div>:null}
            {this.refAnnouncments ? 
            <div className="row inrw">
              <div className="col-sm-2 npad shop_details_tabs">
                <p>Announcements</p>
              </div>
              <div
                className="col-sm-10 npad hb1 op1"
                ref={this.refAnnouncments}
              >
              </div>
            </div>: null}
            {this.refFAQs ? 
            <div className="row inrw">
              <div className="col-sm-2 npad shop_details_tabs">
                <p>FAQ</p>
              </div>
              <div className="col-sm-10 npad hb1 op1" ref={this.refFAQs}>
              </div>
            </div>: null}
          </div>
        </div>
      </div>
    );
  }
}
export default ShopAnnouncementsSummary;
