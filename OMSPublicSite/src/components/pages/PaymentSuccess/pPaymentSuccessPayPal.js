import React from 'react';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import { Helmet } from 'react-helmet';
import { FetchData } from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  STATUS_CODE,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  GENERIC_ERR_MSG,
  INPROC_ORDERID,
  PROFILE_ID,
} from '../../../utils/constants';
import {
  getStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';

class PaymentSuccessPayPal extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      Message: '',
      seconds: 10,
    };
  }

  successPayPalPayment = (res) => {
    this.setState({
      Message: res.StatusMessage,
    });
  };

  componentDidMount() {
    let qDict = {};
    let params = window.location.search.substr(1).split('&'); //.map((item)=> {[item.split("=")[0]] = item.split("=")[1]})
    for (let param of params) {
      let indexEquals = param.indexOf('=');
      let key = param.substring(0, indexEquals);
      qDict[key] = param.substring(indexEquals + 1, param.length);
    }

    qDict.OrderID = getStorageItem(INPROC_ORDERID);
    removeStorageItem(INPROC_ORDERID);
    qDict.RequestedByProfileId = getStorageItem(PROFILE_ID);
    
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.PaymentGateway_PayPalExecutePayment,
      qDict,
      this.successPayPalPayment,
    );
  }

  render() {
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Payment Success</title>
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
                  Payment Success
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>

          <div className="container">
            <div className="heading mb-4">
              <h2 className="title">{this.state.Message}</h2>
            </div>
            <button
              className="btn btn-lg"
              onClick={(e) => {
                e.preventDefault();
                window.location.href = '/';
              }}
            >
              {' '}
              Continue Shopping{' '}
            </button>
            {/* <p>
                            {"the page will redirect in "+this.state.seconds+" seconds"}
                        </p> */}
          </div>

          <div className="mb-10" />
        </main>
        <Footer />
      </div>
    );
  }
}

export default PaymentSuccessPayPal;
