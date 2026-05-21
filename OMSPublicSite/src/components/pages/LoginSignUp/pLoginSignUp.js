import React from 'react';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import { Link } from 'react-router-dom';
import { Helmet } from 'react-helmet';
import izitoast from 'izitoast';
import 'izitoast/dist/css/iziToast.css';
import { FetchData } from '../../../utils/serviceHelper';
import { default_strings } from '../../../utils/globalConstants';
import {
  USER_PROFILE,
  PROFILE_ID,
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  STATUS_CODE,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  GENERIC_ERR_MSG,
  LOGIN_SUCCESS_MSG,
  PREV_AUTH_TOKEN,
  IS_AUTH_TOKEN_EXP,
  PREV_REFRESH_TOKEN,
  IS_REFRESH_TOKEN_EXP,
  IS_USER_LOGGEDIN,
  CART_DETAILS,
  SUPPLIER_ID,
  SIZE,
} from '../../../utils/constants';
import {
  getStorageItem,
  removeStorageItem,
  setStorageItem,
} from '../../../utils/storageHelper';
//import H1 from '../../core/h1'

class LoginSignUp extends React.Component {
  constructor(props) {
    super(props);
    let flag =0;
    this.state = {
      Login: {
        Email: '',
        Password: '',
        RememberMe: false,
      },

      Register: {
        UserName: '',
        Email: '',
        Firstname: '',
        Lastname: '',
        Password: '',
        ConfirmPassword: '',
        Mobile: '',
        CountryCode: default_strings.PHONE_COUNTRY_CODE,
        _Mobile: ''
      },
      RegisterErrors: {
        UserName: '',
        Email: '',
        Firstname: '',
        Lastname: '',
        Password: '',
        ConfirmPassword: '',
        Mobile: '',
      },
      LoginErrors: {
        Email: '',
        Password: '',
      },
    };
  }

  handleChange = (e, key) => {
    const EmptyRegisterErrors = {
      UserName: '',
      Email: '',
      Firstname: '',
      Lastname: '',
      Password: '',
      ConfirmPassword: '',
      Mobile: '',
      _Mobile: ''
    };
    const EmptyLoginErrors = {
      Email: '',
      Password: '',
    };
    this.setState({
      RegisterErrors: EmptyRegisterErrors,
      LoginErrors: EmptyLoginErrors,
    });
    if (key) {
      //!key
      let stateObj = this.state[key];
      stateObj[e.target.name] = e.target.value;
      this.setState({
        [e.target.name]: e.target.value,
      });
    } else {
      let _stateObj = this.state[key];
      _stateObj[e.target.name] = !e.target.type
        ? e.target.value
        : e.target.type == 'checkbox'
        ? e.target.checked
        : '';
      this.setState(_stateObj);
    }
    
  };
  handleKeyPress = (event) => {
    if (event.key === 'Enter') {
      this.Login();
    }
  };
  ValidateLogin = () => {
    let Lerrors = this.state.LoginErrors;
    let Login = this.state.Login;
    let value = true;
    if (Login.Email == '') {
      Lerrors.Email = 'Email Required';
      value = false;
    }
    if (Login.Password == '') {
      Lerrors.Password = 'Password Required';
      value = false;
    }

    this.setState(
      {
        LoginErrors: Lerrors,
      },
      () => {},
    );
    return value;
  };

  successGetProfileByEmail = (resProfile, params) => {
    if (resProfile) {
      removeStorageItem(CART_DETAILS);

      setStorageItem(PROFILE_ID, resProfile.ProfileID);
      if(resProfile.ShopId && resProfile.ShopId > 0)
        setStorageItem(SUPPLIER_ID, resProfile.ShopId);
      resProfile.routeList = params.routeList; 
      resProfile.FirstName = resProfile.FirstName ? resProfile.FirstName : '';
      resProfile.LastName = resProfile.LastName ? resProfile.LastName : '';

      setStorageItem(USER_PROFILE, resProfile);
      setStorageItem(IS_USER_LOGGEDIN, 'true');
      setTimeout(() => {
        window.location.href = '/';
      }, 3000);
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.SUCCESS,
        message: LOGIN_SUCCESS_MSG,
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.GREEN,
        messageSize: SIZE.FONT_SIZE,
        
       
      });
    }
  };

  successLoginUser = (res) => {
    if (res) {
      if (res.StatusCode == STATUS_CODE.ZERO) {
        setStorageItem(PREV_AUTH_TOKEN, res.TokenResponse.access_token);
        setStorageItem(IS_AUTH_TOKEN_EXP, 'N');
        setStorageItem(PREV_REFRESH_TOKEN, res.TokenResponse.refresh_token);
        setStorageItem(IS_REFRESH_TOKEN_EXP, 'N');
        FetchData(
          REQUEST_TYPE.GET,
          SERVICE_ENDPOINTS.Profile_GetProfileByEmail +
            encodeURIComponent(this.state.Login.Email),
          null,
          this.successGetProfileByEmail,
          null,
          { routeList: res.routeList },
        );
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
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.DANGER,
        message: GENERIC_ERR_MSG,
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
      //reset form
      let Login = {
        Email: '',
        Password: '',
        RememberMe: false,
      };

      this.setState({
        Login: Login,
      });
    }
  };

  failLoginUser = () => {
    //reset form
    let Login = {
      Email: '',
      Password: '',
      RememberMe: false,
    };

    this.setState({
      Login: Login,
    });
  };

  Login = () => {
    if (this.ValidateLogin()) {
        //setStorageItem(IS_AUTH_TOKEN_EXP, 'Y');
      FetchData(
        REQUEST_TYPE.POST,
        SERVICE_ENDPOINTS.Account_LoginUser,
        this.state.Login,
        this.successLoginUser,
        this.failLoginUser,
      );
    } else {
      //validation messages here
      console.log('validation issues');
    }
  };

  ValidateRegister = () => {
    let errors = this.state.RegisterErrors;
    let Register = this.state.Register;
    let value = true;
    let validEmailRegex = RegExp(
      /^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i,
    );
    let valideMobileContactpattern = new RegExp(/([0-9\s\-]{7,})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?$/);
    if (Register.Firstname.length <= 0) {
      errors.Firstname = 'First Name required';
      value = false;
    }
    if (Register.Lastname.length <= 0) {
      errors.Lastname = 'Last Name is required';
      value = false;
    }
    if (validEmailRegex.test(Register.Email) == false) {
      errors.Email = 'Valid email is required';
      value = false;
    }
    if (Register.Password.length <= 0) {
      errors.Password = 'Password is required';
      value = false;
    }
    if (Register.ConfirmPassword.length <= 0) {
      errors.ConfirmPassword = 'Confirm Password is required';
      value = false;
    }
    if (Register.Password !== Register.ConfirmPassword) {
      errors.ConfirmPassword = 'Password does not match';
      value = false;
    }
    if (valideMobileContactpattern.test(Register.Mobile) == false) {
      errors.Mobile = 'Valid Mobile Number is required';
      value = false;
    }

    this.setState({
      RegisterErrors: errors,
    });
    return value;
  };

  successAccountRegister = (res) => {
    //reset form
    if (res) {
      if (
        res.StatusCode == STATUS_CODE.ZERO ||
        res.StatusCode == STATUS_CODE.SIX ||
        res.StatusCode == STATUS_CODE.FIVE
      ) {
        let Register = {
          UserName: '',
          Email: '',
          Firstname: '',
          Lastname: '',
          Password: '',
          ConfirmPassword: '',
          _Mobile: '',
        };

        let Login = {
          UserName: '',
          Password: '',
          RememberMe: false,
        };

        this.setState({
          Login: Login,
          Register: Register,
        });
              izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.SUCCESS,
          message:
            'Account has been registered successfully. Before proceeding to log-in, please tap the \'verification link\' sent to your email.',
          //position : APP_TOAST_POSITION.BOTTOM_CENTER,
          target: '.testtarget',
          color: COLOR.GREEN,
          timeout: 11000,
          messageSize: SIZE.FONT_SIZE
        });
      } else {
        let _Register = this.state.Register;
        _Register.Password = '';
        _Register.ConfirmPassword = '';

        this.setState({
          Register: _Register,
        });

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
    }
  };

  failAccountRegister = () => {
    let _Register = this.state.Register;
    _Register.Password = '';
    _Register.ConfirmPassword = '';

    this.setState({
      Register: _Register,
    });
  };

  Register = () => {

    let _Register = this.state.Register;
    let s1 = this.state.Register._Mobile;
    let s2 = default_strings.PHONE_COUNTRY_CODE
    let s = s2 + '-' + s1;
    
    _Register.Mobile = s;

    this.setState({
      Register: _Register
    })
    
    console.log(this.state.Register.Mobile)
    if (this.ValidateRegister()) {
      this.state.Register.UserName = this.state.Register.Email;

      if (getStorageItem(PROFILE_ID)) {
        this.state.Register.RequestedByProfileId = getStorageItem(PROFILE_ID);
      }

      FetchData(
        REQUEST_TYPE.POST,
        SERVICE_ENDPOINTS.Account_Register,
        this.state.Register,
        this.successAccountRegister,
        this.failAccountRegister,
      );
    } else {
      //validation messages here
      console.log('validation issues');
    }
  };

  render() {
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Login or Signup</title>
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
                  Login
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>
          <div className="page-header" style={{ marginTop: '-7rem', paddingBottom: '0px' }}>
            <div className="container">
              <h1 style={{ textTransform: 'none' }}>
                Login and Create Account{' '}
              </h1>
            </div>
            {/* End .container */}
          </div>
          {/* End .page-header */}
          <div className="container login-section">
            <div className="row">
              <div className="col-md-6 ">
                <div className="heading" style={{ marginBottom: '10.5rem' }}>
                  <h2 className="title">Login</h2>
                  <p>If you have an account with us, please log in.</p>
                </div>
                {/* End .heading */}
                <label>Email</label>
                <input
                  style={{ marginBottom: 0 }}
                  name="Email"
                  value={this.state.Login.Email}
                  onChange={(e) => {
                    this.handleChange(e, 'Login');
                  }}
                  type="email"
                  maxLength="200"
                  className="form-control"
                  placeholder="Email"
                  required
                />
                <label style={{ fontSize: 12, marginBottom: 15, color: 'RED' }}>
                  {this.state.LoginErrors.Email}
                </label>
                <br></br>
                <label>Password</label>
                <input
                  style={{ marginBottom: 0 }}
                  name="Password"
                  value={this.state.Login.Password}
                  onKeyPress={this.handleKeyPress}
                  onChange={(e) => {
                    this.handleChange(e, 'Login');
                  }}
                  type="password"
                  maxLength="25"
                  className="form-control"
                  placeholder="Password"
                  required
                />
                <label style={{ fontSize: 12, marginBottom: 15, color: 'RED' }}>
                  {this.state.LoginErrors.Password}
                </label>
                <br></br>
                <div className="custom-control custom-checkbox">
                  <input
                    name="RememberMe"
                    value={this.state.Login.RememberMe}
                    onChange={(e) => {
                      this.handleChange(e, 'Login', 'checkbox');
                    }}
                    type="checkbox"
                    className="custom-control-input"
                    id="rememberMe"
                  />
                  <label className="custom-control-label" htmlFor="rememberMe">
                    Remember Me
                  </label>
                </div>
                {/* End .custom-checkbox */}
                <div className="form-footer">
                  <button
                    onClick={this.Login}
                    type="submit"
                    className="btn btn-primary nextbtn"
                  >
                    LOGIN
                  </button>
                </div>
                <br />
                <div className="col-md-12 ">
                  {/* <a href="/forgotpassword" className="forget-pass"> Forgot your password?</a> */}
                  Forgot your password? Click {' '}
                  <Link
                    onClick={() => {
                      window.location.href = '/forgotpassword';
                    }}
                    to="#"
                    className="forget-pass"
                    style={{ color: '#007bff'}}
                  >
                     Reset password . 
                  </Link>
                  </div>
                  <br />
                  <div className="col-md-12 ">
                    <span style={{color:'red'}}>
                    Didn't receive the verification email? <br />
                    </span>
                    <ul> 
                      <li> * Kindly check your Junk Folder and mark zvonr's emails as "not junk".</li>
                      <li> * Keep zvonr.com, zvonr.ca, zvonr.us, zvonr.co.uk in your email's whitelist</li> 
                      <li> * Or {' '}
                  <Link
                    onClick={() => {
                      window.location.href = '/resendlink';
                    }}
                    to="#"
                    className="resent-link"
                    style={{ color: '#007bff'}}
                  >
                    Resend verification link?
                  </Link>
                  </li>
                  </ul>
                  </div>
                {/* End .form-footer */}
              </div>
              {/* End .col-md-6 */}
              <div className="col-md-6 signup-div">
                <div className="heading">
                  <h2 className="title">Create An Account</h2>
                  <p className="sameheight">
                    By creating an account with Zvonr marketplace, buyers can checkout faster, store multiple shipping addresses, track orders in their account, and more.
                  </p>
                  <p className="sameheight">
                  Shops can reach out to millions of buyers with just a few taps of shop setup.
                  </p>
                </div>
                <label>
                  First Name<span className="required"> *</span>
                </label>
                <input
                  style={{ marginBottom: 0 }}
                  name="Firstname"
                  value={this.state.Register.Firstname}
                  onChange={(e) => {
                    this.handleChange(e, 'Register');
                  }}
                  type="text"
                  maxLength = "100"
                  className="form-control"
                  placeholder="First Name"
                  required
                />
                <label style={{ fontSize: 12, marginBottom: 15, color: 'RED' }}>
                  {this.state.RegisterErrors.Firstname}
                </label>
                <br></br>
                <label>
                  Last Name<span className="required"> *</span>
                </label>
                <input
                  style={{ marginBottom: 0 }}
                  name="Lastname"
                  value={this.state.Register.Lastname}
                  onChange={(e) => {
                    this.handleChange(e, 'Register');
                  }}
                  type="text"
                  maxLength = "100"
                  className="form-control"
                  placeholder="Last Name"
                  required
                />
                <label style={{ fontSize: 12, marginBottom: 15, color: 'RED' }}>
                  {this.state.RegisterErrors.Lastname}
                </label>
                <br></br>
                <label>
                  Email<span className="required"> *</span>
                </label>
                <input
                  style={{ marginBottom: 0 }}
                  name="Email"
                  value={this.state.Register.Email}
                  onChange={(e) => {
                    this.handleChange(e, 'Register');
                  }}
                  type="email"
                  maxLength = "200"
                  className="form-control"
                  placeholder="Email Address"
                  required
                />
                <label style={{ fontSize: 12, marginBottom: 15, color: 'RED' }}>
                  {this.state.RegisterErrors.Email}
                </label>
                <br></br>
                <label>
                  Password<span className="required"> *</span>
                </label>
                <input
                  style={{ marginBottom: 0 }}
                  name="Password"
                  value={this.state.Register.Password}
                  onChange={(e) => {
                    this.handleChange(e, 'Register');
                  }}
                  type="password"
                  maxLength="25"
                  className="form-control"
                  placeholder="Password"
                  required
                />
                <label style={{ fontSize: 12, marginBottom: 15, color: 'RED' }}>
                  {this.state.RegisterErrors.Password}
                </label>
                <br></br>
                <label>
                  Confirm Password<span className="required"> *</span>
                </label>
                <input
                  style={{ marginBottom: 0 }}
                  name="ConfirmPassword"
                  value={this.state.Register.ConfirmPassword}
                  onChange={(e) => {
                    this.handleChange(e, 'Register');
                  }}
                  type="password"
                  maxLength="25"
                  className="form-control"
                  placeholder="Confirm Password"
                  required
                />
                <label style={{ fontSize: 12, marginBottom: 15, color: 'RED' }}>
                  {this.state.RegisterErrors.ConfirmPassword}
                </label>
                <br></br>
                <label>
                  Mobile<span className="required"> *</span>
                </label>

                <div className="row log-all-num" style={{paddingright:'50px', alignItems:'center',width:'88%',paddingLeft:'3%'}}>
                  <input 
                  style={{ marginBottom: 0 ,width: '12%',justifyContent:'center',alignItems:'center'}}
                  name="CountryCode"
                  value={this.state.Register.CountryCode}
                  readOnly
                  type="text"
                  className="form-control log-num"
                  />
                  <input
                    style={{ marginBottom: 0 , width: '88%' }}
                    name="_Mobile"
                    value={this.state.Register._Mobile}
                    onChange={(e) => {
                      this.handleChange(e, 'Register');
                    }}
                    type="text"
                    maxLength = "20"
                    className="form-control log-fill-num"
                    placeholder="Mobile"
                  />
                </div>
                
                <label style={{ fontSize: 12, marginBottom: 15, color: 'RED' }}>
                  {this.state.RegisterErrors.Mobile}
                </label>
                <br></br>
                <div className="form-footer">
                  <button
                    onClick={this.Register}
                    type="submit"
                    className="btn btn-primary nextbtn black_font"
                  >
                    Create Account
                  </button>
                </div>
                {/* End .form-footer */}
              </div>
            </div>
            {/* End .row */}
          </div>
          {/* End .container */}
        </main>
        <Footer />
      </div>
    );
  }
}

export default LoginSignUp;
