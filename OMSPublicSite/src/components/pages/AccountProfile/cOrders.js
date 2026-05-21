import React from 'react';
import { OrderListingType, ProductnShopStatus } from '../../../utils/enums';
import {
  INPROC_ORDERID,
  PROFILE_ID,
  PROFILE_MENU_LIST,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SHOP_MENU_LIST,
  TEMP_ORDER_LIST_TYPE,
  USER_PROFILE,
} from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import moment from 'moment';
import { default_currency } from '../../../utils/globalConstants';
import SearchItem from '../../customControls/SearchList/searchItem';
import Pagination from '../../customControls/Pagination/pagination';

const DISPLAY_PAGES = 10;

class Orders extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      profileId: getStorageItem(PROFILE_ID),
      userProfile: getStorageItem(USER_PROFILE),
      orderDetails: null,
      masterOrderDetails: null,
      currPage: 1,
    };
  }
  componentDidMount() {
    this.getOrderList();
  }

  componentDidUpdate(prevProps, prevState) {
    if (prevProps.Identity != this.props.Identity) {
      this.getOrderList();
    }
  }

  getOrderList = () => {
    let buyerProfileID = '';
    let orderStatusID = '';
    let shopId = '';

    if (this.props.source == 'Account') {
      if (this.props.Identity === 'NewOrder') {
        buyerProfileID = this.state.userProfile.ProfileID;
        orderStatusID = OrderListingType.New;
      } else if (this.props.Identity === 'InProcess') {
        buyerProfileID = this.state.userProfile.ProfileID;
        orderStatusID = OrderListingType.Inprogress;
      } else if (this.props.Identity === 'Completed') {
        buyerProfileID = this.state.userProfile.ProfileID;
        orderStatusID = OrderListingType.Completed;
      } else if (this.props.Identity === 'Disputed') {
        buyerProfileID = this.state.userProfile.ProfileID;
        orderStatusID = OrderListingType.Failed;
      }
    } else if (this.props.source == 'Shop') {
      if (this.props.Identity === 'ShopNewOrder') {
        shopId = this.state.userProfile.ShopId;
        orderStatusID = OrderListingType.New;
      } else if (this.props.Identity === 'ShopInProcess') {
        shopId = this.state.userProfile.ShopId;
        orderStatusID = OrderListingType.Inprogress;
      } else if (this.props.Identity === 'ShopCompleted') {
        shopId = this.state.userProfile.ShopId;
        orderStatusID = OrderListingType.Completed;
      } else if (this.props.Identity === 'ShopDisputed') {
        shopId = this.state.userProfile.ShopId;
        orderStatusID = OrderListingType.Failed;
      }
    }

    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Order_GetOrderList +
        '?buyerProfileId=' +
        buyerProfileID +
        '&shopId=' +
        shopId +
        '&orderStatusID=' +
        orderStatusID +
        '&parentCartId=',
      null,
      this.gotOrderDetails,
    );
  };
  gotOrderDetails = (res) => {
    res = res.filter(
      (item) =>
        item.StatusId != ProductnShopStatus.ACTIVE && item.PaymentTotal != 0,
    );
    this.setState({
      orderDetails: res,
      masterOrderDetails: res,
      currPage: 1,
    });
  };

  updateOrderDetails = (res) => {
    this.setState({
      orderDetails: res,
      currPage: 1,
    });
  };

  setCurrentPage = (pgnum) => {
    this.setState({
      currPage: pgnum,
    });
  };

  render() {
    let Idt = this.props.Identity;
    let data = this.state.orderDetails;
    return (
      <div className="col-lg-9 order-lg-last dashboard-content">
        <SearchItem
          parentData={this.state.masterOrderDetails}
          updateList={this.updateOrderDetails}
          criteria={[
            'OrderID',
            'OrderNumber',
            'ShopName',
            'BuyerName',
            'CreatedOn',
            'PaymentTotal',
          ]}
        />

        {data && data.length > 0 ? (
          <>
            <div className="table_view">
              <table
                className="table table-striped"
                style={{
                  borderWidth: '1px',
                  borderColor: '#aaaaaa',
                  borderStyle: 'solid',
                }}
              >
                <thead>
                  <tr>
                    <th>Order Number</th>
                    {Idt == 'NewOrder' ||
                    Idt == 'Completed' ||
                    Idt == 'Disputed' ||
                    Idt == 'InProcess' ? (
                      <th>Shop Name</th>
                    ) : (
                      <th>Buyer Name</th>
                    )}
                    <th>Order Date</th>
                    <th>Payment Total</th>
                  </tr>
                </thead>
                <tbody>
                  {
                    (() => {
                      let returnArr = [];
                      let startIdx = (this.state.currPage - 1) * DISPLAY_PAGES;
                      let endIdx =
                        this.state.currPage * DISPLAY_PAGES >
                        this.state.orderDetails.length
                          ? this.state.orderDetails.length
                          : this.state.currPage * DISPLAY_PAGES;
                      for (let index = startIdx; index < endIdx; index++) {
                        let item = this.state.orderDetails[index];
                        returnArr.push(
                          <tr key={index}>
                            <td>
                              <a
                                style={{ textDecoration: 'underline' }}
                                href=""
                                onClick={(e) => {
                                  e.preventDefault();
                                  setStorageItem(INPROC_ORDERID, item.OrderID);
                                  if (this.props.source == 'Account') {
                                    setStorageItem(
                                      TEMP_ORDER_LIST_TYPE,
                                      PROFILE_MENU_LIST.find(
                                        (a) => a.Index == this.props.menuIndex,
                                      ).enumMap,
                                    );
                                  } else if (this.props.source == 'Shop') {
                                    setStorageItem(
                                      TEMP_ORDER_LIST_TYPE,
                                      SHOP_MENU_LIST.find(
                                        (a) => a.Index == this.props.menuIndex,
                                      ).enumMap,
                                    );
                                  }
                                  setTimeout(() => {
                                    Idt == 'NewOrder'
                                      ? (window.location.href = '/OrderDetail')
                                      : (window.location.href =
                                          '/PaidOrderDetail?source=' +
                                          this.props.source);
                                  }, 500);
                                }}
                              >
                                {item.OrderNumber
                                  ? item.OrderNumber
                                  : item.OrderID}
                              </a>
                            </td>
                            {Idt == 'NewOrder' ||
                            Idt == 'Completed' ||
                            Idt == 'Disputed' ||
                            Idt == 'InProcess' ? (
                              <td>{item.ShopName}</td>
                            ) : (
                              <td>{item.BuyerName}</td>
                            )}
                            <td>
                              {moment(item.CreatedOn).format(
                                'DD/MM/YYYY hh:mm:ss',
                              )}
                            </td>
                            <td>
                              {default_currency.symbol +
                                parseFloat(item.PaymentTotal).toFixed(2)}
                            </td>
                          </tr>,
                        );
                      }
                      return returnArr;
                    })()

                    // data.map((item, index) =>
                    //     )
                  }
                </tbody>
              </table>
            </div>
            <Pagination
              currPage={this.state.currPage}
              totalRecords={this.state.orderDetails.length}
              DISPLAY_PAGES={DISPLAY_PAGES}
              setCurrentPage={this.setCurrentPage}
            />
          </>
        ) : (
          <h2>Currently there is no Order to view.</h2>
        )}
      </div>
    );
  }
}
export default Orders;
