import React from 'react';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  USER_PROFILE,
} from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR , SIZE} from '../../../utils/constants';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';

class PrivacyAndSecurity extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      userProfile: getStorageItem(USER_PROFILE),
      //SMS_2FA : null,//this.state.userProfile.SMS_2FA,
      //EMail_2FA : null//this.state.userProfile.EMail_2FA
    };
  }

  componentDidMount() {}

  handleOnChange = (e) => {
    this.state.userProfile[e.target.name] = e.target.checked;
    let toggleName = "";

    if(e.target.name === 'EMail_2FA')
    {
      toggleName = 'on email'
    }
    else if (e.target.name === 'SMS_2FA')
    {
      toggleName = 'on message'
    }
    if ( this.state.userProfile[e.target.name] === false) {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.SUCCESS,
        message: 'Two factor authentication disabled ' + toggleName,
        //position: APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }

    else if(this.state.userProfile[e.target.name] === true){
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.SUCCESS,
        message: 'Two factor authentication enabled ' + toggleName,
        //position: APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.GREEN,
        messageSize: SIZE.FONT_SIZE
      });
    }


    this.setState(
      {
        userProfile: this.state.userProfile,
      },
      () => {
        this.Save_2FA();
      },
    );
  };
  Save_2FA = () => {
    let reqObj = {
      SMS_2FA: this.state.userProfile.SMS_2FA,
      EMail_2FA: this.state.userProfile.EMail_2FA,
      ProfileID: this.state.userProfile.ProfileID,
    };
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Profile_UpdateProfile_2FA,
      reqObj,
      this.succesSaved_2FA,
    );
  };
  succesSaved_2FA = (res) => {
    if (res === true) {
      setStorageItem(USER_PROFILE, this.state.userProfile);
      //       izitoast.destroy();
      //izitoast.show({

      //   title: '',
      //   icon: APP_ICONS.SUCCESS,
      //   message: 'success',
      //   //position: APP_TOAST_POSITION.BOTTOM_CENTER,
      //   target: '.testtarget',
      //   color: COLOR.GREEN,
      // });
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Error',
        //position: APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };

  render() {
    return (
      <div className="col-lg-9 order-lg-last dashboard-content">
        <div className="mb-4" />
        {/* margin */}
        <div className="card">
          <div className="card-header">
            Two Factor Authentication
            <a href="#" className="card-edit">
              Edit
            </a>
          </div>
          {/* End .card-header */}
          <div className="card-body">
            <form action="#">
              <div className="row">
                <div className="col-md-12">
                  <div className="form-group">
                    <label htmlFor="s2">SMS</label>
                    <input
                      name="SMS_2FA"
                      type="checkbox"
                      className="switch"
                      checked={this.state.userProfile.SMS_2FA}
                      onChange={(e) => {
                        this.handleOnChange(e);
                      }}
                    />
                  </div>
                  {/* End .form-group */}
                </div>
                {/* End .col-md-4 */}
                <div className="col-md-12">
                  <div className="form-group">
                    <label htmlFor="s2">Email</label>
                    <input
                      name="EMail_2FA"
                      type="checkbox"
                      className="switch"
                      checked={this.state.userProfile.EMail_2FA}
                      onChange={(e) => {
                        this.handleOnChange(e);
                      }}
                    />
                  </div>
                  {/* End .form-group */}
                </div>
                {/* End .col-md-4 */}
                <div className="col-md-12">
                  <div className="form-group">
                    <label>User Agreement</label>
                    <p style={{ fontSize: '16px', color: '#000' }}>
                      By using Zvonr Marketplace you are agreed to cover all policies, concerns, terms & conditions.
                    </p>
                    <p style={{ fontSize: '16px', color: '#000' }}>
                      Please find the detailed policies concerns and terms & conditions at the following link:
                    </p>
                    <h4 className="special_hover_link">
                      <a className="custom-footer-style" href={"/terms-of-service"}>Terms and Conditions </a>
                    </h4>
                  </div>
                  {/* End .form-group */}
                </div>
                {/* End .col-md-4 */}
              </div>
              {/* End .row */}
            </form>
          </div>
          {/* End .card-body */}
        </div>
        {/* End .card */}
      </div>
    );
  }
}

export default PrivacyAndSecurity;
