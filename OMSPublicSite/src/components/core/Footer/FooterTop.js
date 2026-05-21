import React from 'react';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  STATUS_CODE,
  SIZE
} from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';
import izitoast from 'izitoast';
import 'izitoast/dist/css/iziToast.css';

class FooterTop extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      enteredEmail: '',
    };
  }
  subscribeEmail = (e) => {
    e.preventDefault();
    if (this.ValidateEmail()) {
      FetchData(
        REQUEST_TYPE.GET,
        SERVICE_ENDPOINTS.Profile_Subscribe +
          '?email=' +
          encodeURI(this.state.enteredEmail),
        null,
        this.successEmailSubscription,
      );
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.DANGER,
        message: 'Invalid email address',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };
  successEmailSubscription = (res) => {
    console.log('RES', res);
    if (res == "3") {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.SUCCESS,
        message: 'You have successfully subscribed. Thanks for the Subscription',
        target: '.testtarget',
        color: COLOR.GREEN,
        messageSize: SIZE.FONT_SIZE
      });
    } else if(res == "2") {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: "Your email address is already subscribed. Thanks.",
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    } else if(res == "1") {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: "You already have an account! Please click <a href='/loginsignup' style='font-weight:600' >Login</a> to subscribe",
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };
  successAccountRegister = (res) => {
    console.log('RES', res);
    if (
      res.StatusCode == STATUS_CODE.ZERO ||
      res.StatusCode == STATUS_CODE.FIVE ||
      res.StatusCode == STATUS_CODE.SIX
    ) {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.SUCCESS,
        message: 'You have successfully subscribed. Thanks for the Subscription',
        target: '.testtarget',
        color: COLOR.GREEN,
        messageSize: SIZE.FONT_SIZE
      });
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: "Looks like you already have an account! Please click <a href='/loginsignup' style='font-weight:600' >Login</a> to subscribe",
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };
  handleTextChange(e) {
    this.setState({
      [e.target.name]: e.target.value,
    });
  }
  ValidateEmail = () => {
    let validEmailRegex = RegExp(
      /^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i,
    );
    let value = true;
    if (validEmailRegex.test(this.state.enteredEmail) == false) {
      value = false;
    }
    return value;
  };
  render() {
    return (
      <div className="footer-top">
        <div className="container">
          <div className="row">
            <div className="col-lg-3">
              <p className="widget-newsletter-title">
                Zvonr Subscription
              </p>
            </div>
            <div className="col-lg-4">
              <p className="widget-newsletter-content">
                Get all the latest information on Events, Sales and Offers.
                <br />
                <span className="widget-newsletter-content">
                  subscribe to Zvonr.
                </span>
              </p>
            </div>
            <div className="col-lg-5">
              <form action="#">
                <div className="footer-submit-wrapper">
                  <input
                    type="email"
                    maxLength="200"
                    className="form-control"
                    name="enteredEmail"
                    onChange={(e) => {
                      this.handleTextChange(e);
                    }}
                    placeholder="Enter your Email address"
                    required
                  />
                  <button
                    type="submit"
                    className="btn"
                    onClick={(e) => {
                      this.subscribeEmail(e);
                    }}
                  >
                    Subscribe
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default FooterTop;
