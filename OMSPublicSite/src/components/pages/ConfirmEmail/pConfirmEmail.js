import React from 'react';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import { Helmet } from 'react-helmet';
import izitoast from 'izitoast';
import 'izitoast/dist/css/iziToast.css';
import { FetchData } from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  STATUS_CODE,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  GENERIC_ERR_MSG,
  SIZE
} from '../../../utils/constants';

class ConfirmEmail extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      isSuccess: 'Loading',
    };
  }

  successConfirmEmail = (res) => {
    if (res.StatusCode == STATUS_CODE.ZERO) {
      this.setState({
        isSuccess: 'true',
      });
    }
  };

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
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Account_ConfirmEmail,
      updateModel,
      this.successConfirmEmail,
    );
  }

  render() {
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Confirm Email</title>
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
                  confirm email
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>

          <div className="container">
            <div className="heading mb-4">
              {this.state.isSuccess == 'true' ? (
                <>
                  <h2 className="">
                    Email has been confirmed. You can proceed to{' '}
                    <a style={{color:'blue'}} href="/loginsignup">Login</a>
                  </h2>
                </>
              ) : this.state.isSuccess == 'false' ? (
                <h2 className="title">
                  The link has either expired or is invalid
                </h2>
              ) : (
                <h2>Either the verification-link is expired or invalid.</h2>
              )}
            </div>
          </div>

          <div className="mb-10" />
        </main>
        <Footer />
      </div>
    );
  }
}

export default ConfirmEmail;
