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
} from '../../../utils/constants';

class PaymentCancel extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isSuccess: 'Loading',
    };
  }

  componentDidMount() {
    let qDict = {};
    let params = window.location.search.substr(1).split('&'); //.map((item)=> {[item.split("=")[0]] = item.split("=")[1]})
    for (let param of params) {
      let indexEquals = param.indexOf('=');
      let key = param.substring(0, indexEquals);
      qDict[key] = param.substring(indexEquals + 1, param.length);
    }
    let updateModel = this.state;
    updateModel.encText = qDict['q'];
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
                  Payment Cancel
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>

          <div className="container">
            <div className="heading mb-4">
              <h2 className="title">
                An error occured while processing your payment
              </h2>
            </div>
          </div>

          <div className="mb-10" />
        </main>
        <Footer />
      </div>
    );
  }
}

export default PaymentCancel;
