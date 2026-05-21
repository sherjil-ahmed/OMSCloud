import React from 'react';
import Header from '../../core/Header/Header';
import {
  PROFILE_MENU_LIST,
  USER_PROFILE,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  TEMP_ORDER_LIST_TYPE,
  PROFILE_ID,
  INPROC_CHATID,
} from '../../../utils/constants';
import Footer from '../../core/Footer/Footer';
import { Helmet } from 'react-helmet';
import PrivacyAndSecurity from './cPrivacyAndSecurity';
import AccountInformation from './cAccountInformation';
import AddressManagement from './cAddressManagement';
import Notifications from './cNotification';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR, SIZE } from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';
import Orders from './cOrders';
import CartDetail from '../CartDetail/pCardDetail';
import Reviews from './cReviews';

class EditAccountInformation extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      userProfile: getStorageItem(USER_PROFILE),
      menuIndex:
        getStorageItem(TEMP_ORDER_LIST_TYPE) &&
        PROFILE_MENU_LIST.find(
          (a) => a.enumMap == getStorageItem(TEMP_ORDER_LIST_TYPE),
        )
          ? PROFILE_MENU_LIST.find(
              (a) => a.enumMap == getStorageItem(TEMP_ORDER_LIST_TYPE),
            ).Index
          : '',
      show:
        getStorageItem(TEMP_ORDER_LIST_TYPE) &&
        PROFILE_MENU_LIST.find(
          (a) => a.enumMap == getStorageItem(TEMP_ORDER_LIST_TYPE),
        )
          ? PROFILE_MENU_LIST.find(
              (a) => a.enumMap == getStorageItem(TEMP_ORDER_LIST_TYPE),
            ).Path
          : '',
      breadCrumbName: 'User Profile',
      orderListType: getStorageItem(TEMP_ORDER_LIST_TYPE),
    };
  }

  componentDidMount() {
    removeStorageItem(TEMP_ORDER_LIST_TYPE);
  }

  render() {
    let menuList = PROFILE_MENU_LIST;
    let content = <AccountInformation userData={this.state} />;
    if (this.state.show === 'AccountInformation') {
      content = <AccountInformation />;
    } else if (this.state.show === 'PrivacyAndSecurity') {
      content = <PrivacyAndSecurity />;
    } else if (this.state.show === 'AddressManagement') {
      content = <AddressManagement
                              setShowNew={(val) => {
                                
                              }}
                 />;
    } else if (this.state.show === 'ViewCart' && this.state.menuIndex === 3) {
      content = (
        <div className="col-lg-9 order-lg-last dashboard-content">
          <CartDetail showCompOnly={true} />
        </div>
      );
    } else if (this.state.show === 'Orders' && this.state.menuIndex === 4) {
      content = (
        <Orders
          Identity="NewOrder"
          source="Account"
          menuIndex={this.state.menuIndex}
        />
      );
    } else if (this.state.show === 'Orders' && this.state.menuIndex === 5) {
      content = (
        <Orders
          Identity="InProcess"
          source="Account"
          menuIndex={this.state.menuIndex}
        />
      );
    } else if (this.state.show === 'Orders' && this.state.menuIndex === 6) {
      content = (
        <Orders
          Identity="Completed"
          source="Account"
          menuIndex={this.state.menuIndex}
        />
      );
    } else if (this.state.show === 'Orders' && this.state.menuIndex === 7) {
      content = (
        <Orders
          Identity="Disputed"
          source="Account"
          menuIndex={this.state.menuIndex}
        />
      );
    } else if (this.state.show === 'Chat' && this.state.menuIndex === 8) {
      window.location.href = '/chat';
    } else if (
      this.state.show === 'Notifications' &&
      this.state.menuIndex === 9
    ) {
      content = (
        <Notifications source="Account" parentData={this.state.userProfile} />
      );
    }
    else if (this.state.show ==="Reviews" && this.state.menuIndex === 10){
        content = <Reviews source="Account" parentData={this.state.userProfile} />;
    }
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Edit Account Information</title>
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
                  {this.state.breadCrumbName}
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>
          <div className="container wafelss">
            <div className="row">
              {content}

              <aside className="sidebar col-lg-3 sp-setting">
                <div className="widget widget-dashboard">
                  <h3 className="widget-title">My Account</h3>
                  <ul className="list">
                    {(() => {
                      let MenuList = [];
                      for (let index = 0; index < menuList.length; index++) {
                        MenuList.push(
                          <li
                            key={index}
                            className={
                              this.state.menuIndex == menuList[index].Index
                                ? 'active'
                                : ''
                            }
                          >
                            <a
                              href=""
                              onClick={(e) => {
                                e.preventDefault();
                                window.scrollTo(0, 0);
                                this.setState(
                                  {
                                    show: menuList[index].Path,
                                    menuIndex: index,
                                    breadCrumbName: menuList[index].Name,
                                  },
                                  () => {},
                                );
                              }}
                            >
                              {menuList[index].Name}
                            </a>
                          </li>,
                        );
                      }
                      return MenuList;
                    })()}
                  </ul>
                </div>
                {/* End .widget */}
              </aside>
              {/* End .col-lg-3 */}
            </div>
            {/* End .row */}
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}

export default EditAccountInformation;
