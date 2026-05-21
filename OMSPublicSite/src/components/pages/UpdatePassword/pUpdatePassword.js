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

class UpdatePassword extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      Password: '',
      ConfirmPassword: '',
    };
  }

  handleChange = (e) => {
    this.setState({
      [e.target.name]: e.target.value,
    });
  };

  ValidateUpdatePassword = () => {
    return true;
  };

  successUpdatePassword = (res) => {
    if (res.StatusCode == STATUS_CODE.ZERO) {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.SUCCESS,
        message: res.StatusMessage,
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.GREEN,
        messageSize: SIZE.FONT_SIZE
      });
      setTimeout(() => {
        window.location.href = '/';
      }, 2000);
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

  UpdatePassword = () => {
    if (this.ValidateUpdatePassword()) {
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
        SERVICE_ENDPOINTS.Account_UpdatePassword,
        updateModel,
        this.successUpdatePassword,
      );
    }
  };

  render() {
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Update Password</title>
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
                  Update Password
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>

          <div className="container">
            <div className="heading mb-4">
              <h2 className="title">Update Password</h2>
              <p>Please enter a new password for your account.</p>
            </div>
            <div className="form-group required-field">
              <label htmlFor="reset-email">Password</label>
              <input
                name="Password"
                value={this.state.Password}
                onChange={this.handleChange}
                type="password"
                maxLength="25"
                className="form-control"
                required
              />
              <label htmlFor="reset-email">Confirm Password</label>
              <input
                name="ConfirmPassword"
                value={this.state.ConfirmPassword}
                onChange={this.handleChange}
                type="password"
                maxLength="25"
                className="form-control"
                required
              />
            </div>
            {/* End .form-group */}
            <div className="form-footer">
              <button
                onClick={this.UpdatePassword}
                type="button"
                className="btn btn-primary nextbtn"
              >
                Reset My Password
              </button>
            </div>
            {/* End .form-footer */}
          </div>

          <div className="mb-10" />
        </main>
        <Footer />
      </div>
    );
  }
}

export default UpdatePassword;
