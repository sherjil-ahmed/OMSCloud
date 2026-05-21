import React from 'react';
import Header from '../../core/Header/Header';
import {
  SHOP_MENU_LIST,
  TEMP_ORDER_LIST_TYPE,
  USER_PROFILE,
} from '../../../utils/constants';
import Footer from '../../core/Footer/Footer';
import { Helmet } from 'react-helmet';
import ShopInformation from './cShopInfo';
import ShopSchedule from './cShopSchedule';
import Orders from '../AccountProfile/cOrders';
import BankingInformation from './cBankingInfo';
import Notifications from '../AccountProfile/cNotification';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import ShopSettingSchedule from '../ShopSchedule/pShopSettingSchedule';
import ShopVerification from './cShopVerificationPage'
class ShopSettings extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      userProfile: getStorageItem(USER_PROFILE),
      menuIndex:
        getStorageItem(TEMP_ORDER_LIST_TYPE) &&
        SHOP_MENU_LIST.find(
          (a) => a.enumMap == getStorageItem(TEMP_ORDER_LIST_TYPE),
        )
          ? SHOP_MENU_LIST.find(
              (a) => a.enumMap == getStorageItem(TEMP_ORDER_LIST_TYPE),
            ).Index
          : '',
      show:
        getStorageItem(TEMP_ORDER_LIST_TYPE) &&
        SHOP_MENU_LIST.find(
          (a) => a.enumMap == getStorageItem(TEMP_ORDER_LIST_TYPE),
        )
          ? SHOP_MENU_LIST.find(
              (a) => a.enumMap == getStorageItem(TEMP_ORDER_LIST_TYPE),
            ).Path
          : '',
      breadCrumbName: 'Shop Profile',
    };
  }

  render() {
    let menuList = SHOP_MENU_LIST;
    let content = <ShopInformation />;
    if (this.state.show === 'ShopInformation') {
      content = <ShopInformation />;
    } else if (this.state.show === 'ShopSchedule') {
      content = <ShopSchedule />;
    } else if (this.state.show === 'BankingInfo') {
      content = <BankingInformation />;
    } else if (
      this.state.show === 'ShopCalender' &&
      this.state.menuIndex === 4
    ) {
      content = <ShopSettingSchedule />;
    } else if (this.state.show === 'Orders' && this.state.menuIndex === 5) {
      content = (
        <Orders
          Identity="ShopInProcess"
          source="Shop"
          menuIndex={this.state.menuIndex}
        />
      );
    } else if (this.state.show === 'Orders' && this.state.menuIndex === 6) {
      content = (
        <Orders
          Identity="ShopCompleted"
          source="Shop"
          menuIndex={this.state.menuIndex}
        />
      );
    } else if (this.state.show === 'Orders' && this.state.menuIndex === 7) {
      content = (
        <Orders
          Identity="ShopDisputed"
          source="Shop"
          menuIndex={this.state.menuIndex}
        />
      );
    } else if ( this.state.show === 'ShopVerification' && this.state.menuIndex === 8) {
      content = (
        <ShopVerification parentData={this.state.userProfile} />
      ); 
    } else if (this.state.show === 'Chat' && this.state.menuIndex === 9) {
      window.location.href = '/chat';
    } else if (
      this.state.show === 'Notifications' &&
      this.state.menuIndex === 10
    ) {
      content = (
        <Notifications source="Shop" parentData={this.state.userProfile} />
      );
    }

    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Edit Shop Information</title>
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
          <div className="container in-up">
            <div className="row">
              {content}

              <aside className="sidebar col-lg-3 sp-setting">
                <div className="widget widget-dashboard">
                  <h3 className="widget-title">Shop Setting </h3>
                  <ul className="list">
                    {(() => {
                      let MenuList = [];
                      for (let index = 0; index < menuList.length; index++) {
                        if (menuList[index].Index == 1) {
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
                                href="#"
                                onClick={() => {
                                  window.location.href = '/CreateShop';
                                }}
                              >
                                {menuList[index].Name}
                              </a>
                            </li>,
                          );
                        } else {
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
                                  this.setState({
                                    show: menuList[index].Path,
                                    menuIndex: index,
                                    breadCrumbName: menuList[index].Name,
                                  });
                                }}
                              >
                                {menuList[index].Name}
                              </a>
                            </li>,
                          );
                        }
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

export default ShopSettings;
