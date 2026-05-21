import React from 'react';
import Header from '../../core/Header/Header';
//import {PROFILE_MENU_LIST, USER_PROFILE,REQUEST_TYPE, SERVICE_ENDPOINTS} from '../../../utils/constants'
import Footer from '../../core/Footer/Footer';
import { Helmet } from 'react-helmet';
import ShopSummary from './cShopBasicInfo';
import ShopAnnouncementsSummary from './cShopAnnouncementsInfo';
import { FetchData } from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  PROFILE_ID,
} from '../../../utils/constants';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import { USER_PROFILE } from '../../../utils/constants';
import ShopSchedulePublic from '../ShopSchedule/pShopSchedulePublic';
import CreateReview from '../Reviews/cCreateReview';
import { RatingSubject } from '../../../utils/enums';
import ReviewList from '../Reviews/cReviewList';

const objURL = new window.URL(window.location.href);
class ShopDetailPage extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      ShopId: objURL.searchParams.get('ShopId')
        ? objURL.searchParams.get('ShopId')
        : '',
       IsReviewInputAllowed: true
    };

    if (this.state.ShopId) {
    } else {
      window.location.href = '/';
    }
  }

  componentDidMount() {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Supplier_GetSupplierPublic +
        this.state.ShopId + '/' + getStorageItem(PROFILE_ID),
      null,
      this.gotSupplierDetails,
    );
  }

  gotSupplierDetails = (res) => {
    if(res){
    console.log("Suplier Detail for review" , res);
    this.setState({
      IsReviewInputAllowed : res.IsReviewInputAllowed
    })
    console.log('IsReviewInputAllowed in shop detail page',this.state.IsReviewInputAllowed)
  }
};

  render() {
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Shop Detail</title>
        </Helmet>
        <Header />
        <main className="main home" style={{ padding: '25px' }}>
          <div className="container">
            <div className="page-wrapper">
              <div className="mainsliwrapper">
                <div className="heading">
                  <div className="row">
                    <div className="col-md-6 col-sm-12">
                      <h2 className="title">Shop Information</h2>
                    </div>
                  </div>
                </div>

                <ShopSummary shopData={{ ShopId: this.state.ShopId }} />
                <div className="mainsliwrapper padding_above">
                  <hr />
                  <ShopSchedulePublic SupplierID={this.state.ShopId} shopData={{ ShopId: this.state.ShopId }} shopDescription ={true} />
                  <hr />
                  <ShopAnnouncementsSummary
                    shopData={{ ShopId: this.state.ShopId }}
                  />
                  <hr />
                  {this.state.IsReviewInputAllowed ?  <CreateReview
                    type={RatingSubject.SHOP}
                    id={this.state.ShopId}
                  />:null}
                 
                </div>
                <div className="container">
                  <ReviewList
                    id={this.state.ShopId}
                    type={RatingSubject.SHOP}
                  />
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
export default ShopDetailPage;
