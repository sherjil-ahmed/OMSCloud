import React from 'react';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import { Helmet } from 'react-helmet';
import { ProductnShopStatus } from '../../../utils/enums';
import {
  INPROC_ORDERID,
  PROFILE_ID,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  USER_PROFILE,
  TEMP_ORDER_LIST_TYPE,
} from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import moment from 'moment';
import { default_currency } from '../../../utils/globalConstants';
import { OrderListingType } from '../../../utils/enums';

class OrderList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      profileId: getStorageItem(PROFILE_ID),
      userProfile: getStorageItem(USER_PROFILE),
      orderDetails: null,
    };
  }
  componentDidMount() {
    if (this.state.profileId) {
      this.getOrderList();
    } else {
      window.location.href = '/';
    }
  }
  getOrderList = () => {
    let buyerProfileID = this.state.profileId; //userProfile.ProfileID;
    let orderStatusID = '';//OrderListingType.New;
    let shopId = '';

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
    });
  };

  render() {
    let Idt = this.props.Identity;
    let data = this.state.orderDetails;
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Order List</title>
        </Helmet>
        <Header />
        <nav aria-label="breadcrumb" className="breadcrumb-nav">
          <div className="container">
            <ol className="breadcrumb">
              <li className="breadcrumb-item">
                <a href="/">
                  <i className="icon-home" />
                </a>
              </li>
              <li className="breadcrumb-item active" aria-current="page">
                order listing
              </li>
            </ol>
          </div>
          {/* End .container */}
        </nav>
        <main className="main">
          <div className="container">
            <div style={{ paddingTop: '6em' }}>
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
                    <th>Order ID</th>
                    <th>Order Status</th>
                    {Idt == 'NewOrder' ||
                    Idt == 'Completed' ||
                    Idt == 'Disputed' ||
                    Idt == 'InProcess' ? (
                      <th>Buyer Name</th>
                    ) : (
                      <th>Shop Name</th>
                    )}
                    <th>Order Date</th>
                    <th>Payment Total</th>
                  </tr>
                </thead>
                {data && data.length > 0 ? (
                  <tbody>
                    {data.map((item, index) => (
                      <tr key={index}>
                        <td>
                          <a
                            style={{
                              textDecoration: 'underline',
                            }}
                                    href=""
                            onClick={(e) => {
                              e.preventDefault();
                              setStorageItem(INPROC_ORDERID, item.OrderID);
                              setStorageItem(
                                TEMP_ORDER_LIST_TYPE,
                                (
                                  (item.OrderStatusId == 3 ) 															                          ? 101 : 
                                  (item.OrderStatusId == 4 || item.OrderStatusId == 5 || item.OrderStatusId == 6) 	? 102 :
                                  (item.OrderStatusId == 10 || item.OrderStatusId == 8 ) 							? 103 : 
                                  (item.OrderStatusId == 11 || item.OrderStatusId == 12 || item.OrderStatusId == 13)? 104 : 100000
                                )
                              );
                              setTimeout(() => {
                                item.OrderStatusId === 3 
                                  ? (window.location.href = '/OrderDetail')
                                  : (window.location.href = '/PaidOrderDetail?source=Account' );
                              }, 500);
                            }}
                          >
                            {item.OrderNumber}
                          </a>
                            </td>
                            <td>{item.OrderStatusTitle}</td>
                        {Idt == 'NewOrder' ||
                        Idt == 'Completed' ||
                        Idt == 'Disputed' ||
                        Idt == 'InProcess' ? (
                          <td>{item.BuyerName}</td>
                        ) : (
                          <td>{item.ShopName}</td>
                        )}
                        <td>
                          {moment(item.CreatedOn).format('DD/MM/YYYY hh:mm:ss')}
                        </td>
                        <td>{default_currency.symbol + item.PaymentTotal}</td>
                      </tr>
                    ))}
                  </tbody>
                ) : (
                  <h2>{'  '}Currently there is no order found.</h2>
                )}
              </table>
            </div>
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}
export default OrderList;
