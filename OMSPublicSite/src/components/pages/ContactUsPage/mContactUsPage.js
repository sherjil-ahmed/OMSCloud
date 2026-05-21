import React from 'react';
import {
    REQUEST_TYPE,
    SERVICE_ENDPOINTS,
    APP_ICONS,
    PROFILE_ID,
    APP_TOAST_POSITION,
    INPROC_CHATID ,
    COLOR,
    SIZE,
    IS_USER_LOGGEDIN
} from '../../../utils/constants';
import { default_strings } from '../../../utils/globalConstants';
import { FetchData } from '../../../utils/serviceHelper';
import izitoast from 'izitoast';
import 'izitoast/dist/css/iziToast.css';
import { getStorageItem, setStorageItem } from '../../../utils/storageHelper';
import { appSocials } from '../../../utils/globalConstants';

class ContactUsMobile extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            userName: "",
            userEmail: "",
            userContactNum: "",
            userQuery: "",
            Errors: {}
        }
    }
    handleTextChange(e) {
        this.setState(
            {
                [e.target.name]: e.target.value,
            });
    }
    ValidateQuery = () => {
        let errors = this.state.Errors;
        let validEmailRegex = RegExp(
            /^(("[\w-\s]+")|([\w-]+(?:\.[\w-]+)*)|("[\w-\s]+")([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)/i,
        );
        let value = true;
        if (validEmailRegex.test(this.state.userEmail) == false) {
            errors.userEmail = 'Email is not valid or empty';
            value = false;
        }
        if (!this.state.userName && this.state.userName.length == 0) {
            errors.userName = 'Name is required'
            return false
        }
        if (!this.state.userQuery && this.state.userQuery.length == 0) {
            errors.userQuery = 'Description is required'
            return false
        }
        this.setState({
            Errors: errors,
        });
        return value;
    }
    submitQuery = (e) => {
        e.preventDefault();
        let reqObj = {
            From_FullName: this.state.userName,
            From_Email: this.state.userEmail,
            Subject: "Via Contact Us",
            PhoneNumber: this.state.userContactNum,
            Body: this.state.userQuery
        }
        if(this.ValidateQuery())
        {
            FetchData(
                REQUEST_TYPE.POST,
                SERVICE_ENDPOINTS.Account_SendContactUsEmail,
                reqObj,
                this.successQuerySubmit,
            );
        }
        else{
            let error ={}
                  izitoast.destroy();
      izitoast.show({

                title: '',
                icon: APP_ICONS.WARNING,
                message: this.state.Errors.userName || this.state.Errors.userEmail ||  this.state.Errors.userQuery,
                //position : APP_TOAST_POSITION.BOTTOM_CENTER,
                target: '.testtarget',
                color: COLOR.RED,
                messageSize: SIZE.FONT_SIZE
            });
            this.setState({
                Errors: error,
            });
    
        }
       
    };
    successQuerySubmit = (res) => {
        if (res == true) {
                  izitoast.destroy();
      izitoast.show({

                title: '',
                icon: APP_ICONS.SUCCESS,
                message: "We appreciate you contact us. We will get back in touch with you soon!",
                //position : APP_TOAST_POSITION.BOTTOM_CENTER,
                target: '.testtarget',
                color: COLOR.GREEN,
                messageSize: SIZE.FONT_SIZE
            });
        }
        else {
                  izitoast.destroy();

            ({

                title: '',
                icon: APP_ICONS.DANGER,
                message: "Unable to send email, try Again",
                //position : APP_TOAST_POSITION.BOTTOM_CENTER,
                target: '.testtarget',
                color: COLOR.RED,
                messageSize: SIZE.FONT_SIZE
            });
        }
    }

    successInitiateChat = (res) => {
        if (res == '-1') {
                izitoast.destroy();
          izitoast.show({
    
            title: '',
            icon: APP_ICONS.WARNING,
            message:
              'Please register an account on the Zvonr marketplace in order to chat with Zvonr-Support',
            //position : APP_TOAST_POSITION.BOTTOM_CENTER,
            target: '.testtarget',
              color: COLOR.GREEN,
          });
        } else {
          setStorageItem(INPROC_CHATID, {
            chatId: res,
            profileId: default_strings.ZVONR_SUPPORT_SHOP_PROFILEID,  // hardcoded shop's profile id for support shop
          });
          setTimeout(() => {
            window.location.href = '/chat';
          }, 1000);
        }
      };
    
      initiateChat = () => {
        FetchData(
          REQUEST_TYPE.POST,
          SERVICE_ENDPOINTS.Chat_InitiateChat +
            '?sender=' +
            getStorageItem(PROFILE_ID) +
            '&receiver=' + default_strings.ZVONR_SUPPORT_SHOP_PROFILEID,// hardcoded shop's profile id for support shop
            //this.state.supplierDetails.ShopOwnerProfileId,
          null,
          this.successInitiateChat,
        );
      };

    render() {
        return (
            <div>
                <div className="page-wrapper">
                    <main className="main">
                        <div className="mt-2">
                            <div className="container">
                                <h1>Contact Us</h1>
                            </div>{/* End .container */}
                        </div>{/* End .page-header */}
                        <div className="container">
                            <div className="row row-sparse">
                                <div className="col-md-8">
                                    <button type="submit" className="btn btn-primary nextbtn" onClick={(e) => { this.submitQuery(e) }} style={{ float: 'right' }}>Submit</button>
                                    <h2 className="light-title">Write <strong>Us</strong></h2>
                                    <form action="#">
                                        <div className="form-group required-field">
                                            <label htmlFor="contact-name">Name</label>
                                            <input type="text" className="form-control" value={this.state.userName} name="userName" required  maxLength="100"
                                                onChange={(e) => {
                                                    this.handleTextChange(e);
                                                }} />
                                        </div>{/* End .form-group */}
                                        <div className="form-group required-field">
                                            <label htmlFor="contact-email">Email</label>
                                            <input type="email" className="form-control" value={this.state.userEmail} name="userEmail" required  maxLength="100"
                                                onChange={(e) => {
                                                    this.handleTextChange(e);
                                                }} />
                                        </div>{/* End .form-group */}
                                        <div className="form-group">
                                            <label htmlFor="contact-phone">Phone Number</label>
                                            <input type="tel" className="form-control" value={this.state.userContactNum} name="userContactNum" maxLength="20"
                                                onChange={(e) => {
                                                    const re = /^[0-9\b]+$/;
                                                    if (e.target.value === '' || re.test(e.target.value)) {
                                                        this.setState(
                                                            {
                                                                [e.target.name]: e.target.value,
                                                            });
                                                    }
                                                }} />
                                        </div>{/* End .form-group */}
                                        <div className="form-group required-field">
                                            <label htmlFor="contact-message">What’s on your mind?</label>
                                            <textarea
                                                style={{ minHeight: '120px' }}
                                                cols={10} rows={1} value={this.state.userQuery} className="form-control" name="userQuery" required defaultValue={""}
                                                onChange={(e) => {
                                                    this.handleTextChange(e);
                                                }} />
                                        </div>{/* End .form-group */}
                                        <div className="form-footer">
                                            <button type="submit" className="btn btn-primary nextbtn" onClick={(e) => { this.submitQuery(e) }}>Submit</button>
                                        </div>{/* End .form-footer */}
                                    </form>
                                </div>{/* End .col-md-8 */}
                                <div className="col-md-4">
                                    <h2 className="light-title">Contact <strong>Details</strong></h2>
                                    <div className="contact-info">
                                        <div>
                                            <i className="icon-mail-alt"></i>
                                            <p><a href="mailto:#" className="custom-contactus-mail">support@zvonr.ca</a></p>
                                        </div>
                                        <div>
                                            <i className="icon-chat"></i>
                                            <p><a href='#' 
                                            onClick={(e) => {
                                                if (getStorageItem(IS_USER_LOGGEDIN)) {
                                                  this.initiateChat();
                                                } else {
                                                    izitoast.destroy();
                                                    izitoast.show({
                                                        title: '',
                                                        icon: APP_ICONS.WARNING,
                                                        message:
                                                        'Please register an account on the Zvonr marketplace in order to chat with Zvonr-Support!',
                                                        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
                                                        target: '.testtarget',
                                                        color: COLOR.GREEN,
                                                    });
                                                }
                                            }}
                                            className="custom-contactus-mail">support@zvonr</a></p>
                                        </div>
                                        <h4>USA: Zvonr Inc.</h4>
                                        <div>
                                            <i className="icon-home" />
                                            <p>388 Market Street, Suite 1300 </p>
                                            <p>San Francisco, CA 94111</p>
                                        </div>

                                        <h4>Canada: Zvonr Corporation</h4>
                                        <div>
                                            <i className="icon-home" />
                                            <p>330 Highway 7 East, Unit 305</p>
                                            <p>Richmond Hill, Ontario, L4B 3P8</p>
                                        </div>

                                        <h4>United Kingdom: Zvonr Technology Ltd</h4>
                                        <div>
                                            <i className="icon-home" />
                                            <p>71-75 Sheldon Street</p>
                                            <p>Covent Garden</p>
                                            <p>London, WC2H 9JQ</p>
                                        </div>
                                        <div className="col-md-6">
                                            <div className="social-icons mb-3">
                                            <a href={appSocials.FACEBOOK} className="social-icon" target="_blank">
                                                <i className="fab fa-facebook-f" />
                                            </a>
                                            <a href={appSocials.INSTAGRAM} className="social-icon" target="_blank">
                                                <i className="fab fa-instagram" />
                                            </a>
                                            <a href={appSocials.LINKEDIN} className="social-icon" target="_blank">
                                                <i className="fab fa-linkedin-in" />
                                            </a>
                                            </div>
                                        </div>
                                    </div>{/* End .contact-info */}
                                </div>{/* End .col-md-4 */}
                            </div>{/* End .row */}
                        </div>{/* End .container */}
                        <div className="mb-8" />{/* margin */}
                    </main>{/* End .main */}
                </div>{/* End .page-wrapper */}
                {/* Plugins JS File */}
                {/* Main JS File */}
                {/* Google Map*/}
                <div className="fot-d2">
                    <div className="fot-rs-d1">
                        <img
                        src="/assets/images/logoonly.png"
                        width="280px"
                        style={{ maxHeight: '50px' }}
                        />
                    </div>
                    <div className="fot-rs-d1">
                        <p className="footer-copyright">Powered by <a href={'//' + "avanturebyte.com"} target="_blank" rel="noopener noreferrer">Avanture Bytes</a> All Rights Reserved</p>
                    </div>
                </div>
            </div>

        )
    }
}
export default ContactUsMobile