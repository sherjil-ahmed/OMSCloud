import React from 'react';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import { Helmet } from 'react-helmet';
import { FetchData } from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  STATUS_CODE,
  SIZE
} from '../../../utils/constants';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR } from '../../../utils/constants';

class ForgotPassword extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      Email: '',
      EmailError: '',
      isSuccess: false,
    };
  }

  handleChange = (e) => {
    this.setState({
      [e.target.name]: e.target.value,
    });
  };

  ValidateForgotPassword = () => {
    let value = true;
    let EmailError = '';
    if (this.state.Email == '') {
      EmailError = 'Email Required';
      value = false;
    }
    this.setState({
      EmailError: EmailError,
    });
    return value;
  };

  successForgotPassword = (res) => {
    if (res.StatusCode == STATUS_CODE.ZERO) {
      this.setState({
        isSuccess: true,
      });
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: res.StatusMessage,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };

  ForgotPassword = () => {
    if (this.ValidateForgotPassword()) {
      FetchData(
        REQUEST_TYPE.POST,
        SERVICE_ENDPOINTS.Account_ForgotPassword,
        this.state,
        this.successForgotPassword,
      );
    }
  };

  render() {
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Forgot Password</title>
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
                  forgot password
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>
          {this.state.isSuccess ? (
            <div className="container">
              <div className="heading mb-4">
                <h2 className="">
                  A password reset link has been sent to your email. Please
                  click that link to reset your password.
                </h2>
              </div>
            </div>
          ) : (
            <div className="container">
              <div className="heading mb-4">
                <h2 className="">Reset Password</h2>
                <p>
                  Please enter your email address below to receive a password reset link.
                </p>
              </div>
              <div className="form-group">
                <label htmlFor="reset-email">Email</label>
                <span className="required"> *</span>
                <input
                  name="Email"
                  value={this.state.Email}
                  onChange={this.handleChange}
                  type="email"
                  maxLength="200"
                  className="form-control"
                />
                <label style={{ fontSize: 12, marginBottom: 15, color: 'RED' }}>
                  {this.state.EmailError}
                </label>
                <br />
              </div>
              {/* End .form-group */}
              <div className="form-footer">
                <button
                  onClick={this.ForgotPassword}
                  type="button"
                  className="btn btn-primary nextbtn"
                >
                  Reset My Password
                </button>
              </div>
              {/* End .form-footer */}
            </div>
          )}
          <div className="mb-10" />
        </main>
        <Footer />
      </div>
    );
  }
}

export default ForgotPassword;
