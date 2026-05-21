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
  SIZE
} from '../../../utils/constants';
import izitoast from 'izitoast';

class ResendLink extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      Email: '',
      isSuccess: false,
    };
  }

  handleChange = (e) => {
    this.setState({
      [e.target.name]: e.target.value,
    });
  };

  ValidateResendVerificationLink = () => {
    return true;
  };

  successResendConfirmationEmail = (res) => {
    if (res.StatusCode == STATUS_CODE.ZERO) {
      this.setState({
        isSuccess: true,
      });
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.DANGER,
        message: res.StatusMessage,
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };

  ResendVerificationLink = () => {
    if (this.ValidateResendVerificationLink()) {
      FetchData(
        REQUEST_TYPE.POST,
        SERVICE_ENDPOINTS.Account_ResendConfirmationEmail,
        this.state,
        this.successResendConfirmationEmail,
      );
    }
  };

  render() {
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Resend Verification Link</title>
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
                  Resend verification Link
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>
          {this.state.isSuccess ? (
            <div className="container">
              <div className="heading mb-4">
                <h2 className="">
                  A verification link has been sent to your email. Please click
                  that link to verify your account at Zvonr marketplace. 
                </h2>
              </div>
            </div>
          ) : (
            <div className="container">
              <div className="heading mb-4">
                <h2 className="">Resend verification link</h2>
                <p>
                  Please enter your email address below to receive a account
                  verification link.
                </p>
              </div>
              <div className="form-group required-field">
                <label htmlFor="reset-email">Email</label>
                <input
                  name="Email"
                  value={this.state.Email}
                  onChange={this.handleChange}
                  type="email"
                  maxLength="200"
                  className="form-control"
                  required
                />
              </div>
              {/* End .form-group */}
              <div className="form-footer">
                <button
                  onClick={this.ResendVerificationLink}
                  type="button"
                  className="btn btn-primary nextbtn"
                >
                  Resend verification link
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

export default ResendLink;
