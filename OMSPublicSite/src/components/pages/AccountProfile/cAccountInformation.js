import React from 'react';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR, SIZE } from '../../../utils/constants';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  USER_PROFILE,
} from '../../../utils/constants';
import {
  FetchData,
  baseUrlImage,
  baseUrl,
  FetchData_Override,
} from '../../../utils/serviceHelper';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import { ImageEntityEnum, ImageUploadConfig } from '../../../utils/enums';
import Modal from 'react-modal';
import Cropper from 'react-easy-crop';
import { default_strings } from '../../../utils/globalConstants';
const IMAGE_ERR_MSG = {
  HEIGHT_EXCEED: 'file height exceeded',
  WIDTH_EXCEED: 'file width exceeded',
  SIZE_EXCEED: 'file size exceeded',
  INVALID_TYPE: 'Invalid file type',
};
const customStyles = {
  content: {
    top: '31%',
    left: '12%',
    right: '12%',
    bottom: '20%',
    padding: '0px',
    overflow: 'hidden',
    // marginRight           : '-50%',
    // transform             : 'translate(-50%, -50%)'
  },
};
class AccountInformation extends React.Component {
  constructor(props) {
    super(props);
    this.refUploadInput = React.createRef();
    this.profileImage = React.createRef();
    this.previewImage = React.createRef();
    this.croppedArea = null;
    this.croppedAreaPixels = null;
    this.ImageObj = null;
    this.FileObj = null;
    this.state = {
      userProfile: getStorageItem(USER_PROFILE),
      userInfo: [],
      userFirstName: '',
      userLastName: '',
      userEmailAddress: '',
      userContactNumber: '',
      CountryCode: default_strings.PHONE_COUNTRY_CODE,
      imagePath: '',
      ImageSrc: '',
      openModal: false,
      showCropper: false,
      image: '',
      crop: { x: 0, y: 0 },
      zoom: 1,
      aspect: 4 / 3,

      //Password States
      ChangePassword: {
        oldPassword: '',
        newPassword: '',
        confirmPassword: '',
      },
      ChangePassworderrors: {
        oldPassword: '',
        newPassword: '',
        confirmPassword: '',
      },
    };
  }
  onCropChange = (crop) => {
    this.setState({ crop });
  };

  onCropComplete = (croppedArea, croppedAreaPixels) => {
    this.croppedArea = croppedArea;
    this.croppedAreaPixels = croppedAreaPixels;
  };

  onZoomChange = (zoom) => {
    this.setState({ zoom });
  };

  componentDidMount() {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Profile_GetProfileByUserId +
        this.state.userProfile.UserID,
      null,
      this.gotUserData,
    );
  }

  gotUserData = (res) => {
    console.log('in user data')
    if (res !== null) {
      var contactNumber= res.FatherName;
      console.log(contactNumber)
      var _contactNumber = contactNumber.split('-');
      console.log("contactnumber[1]",_contactNumber[1])
      this.setState(
        {
          userInfo: res,
          userFirstName: res.FirstName ? res.FirstName : '',  
          userLastName: res.LastName ? res.LastName : '',
          userEmailAddress: res.UserName ? res.UserName : '',
          imagePath: res.ImagePath ? res.ImagePath : '',
          userContactNumber: res.FatherName ? _contactNumber[1] : '', //using FatherName for User Contact No
          ImageSrc:
            baseUrlImage +
            ImageEntityEnum.USER +
            '/' +
            this.state.userProfile.ProfileID +
            '/' +
            res.ImagePath,
        },
        () => {},
      );
    }
  };

  handleChange = (e) => {
    this.setState(
      {
        [e.target.name]: e.target.value,
      },
      () => {},
    );
  };
  handlePasswordChange = (e) => {
    let emptyErrors = {
      oldPassword: '',
      newPassword: '',
      confirmPassword: '',
    };
    this.setState({
      ChangePassworderrors: emptyErrors,
    });
    this.state.ChangePassword[e.target.name] = e.target.value;
    this.setState({
      ChangePassword: this.state.ChangePassword,
    });
  };

  AddImage = () => {
    this.refUploadInput.current.click();
  };

  onImageChange = (event) => {
    if (event.target.files && event.target.files.length > 0) {
      for (let file of event.target.files) {
        let filename = file.name.split('.')[0];
        let filesize = file.size;
        let filetype = file.type;
        if (filesize <= ImageUploadConfig.maxSize) {
          if (ImageUploadConfig.allowedTypes.includes(filetype)) {
            let _img = new Image();
            _img.src = URL.createObjectURL(file);
            _img.onload = () => {
              if (_img.width <= ImageUploadConfig.maxWidth) {
                if (_img.height <= ImageUploadConfig.maxHeight) {
                  this.ImageObj = _img;
                  this.FileObj = file;
                  this.setState(
                    {
                      ImageSrc: _img.src,
                      imagePath: file.name,
                      showCropper: true,
                      image: _img.src,
                    },
                    () => {
                      window.openModal('myModal');
                      setTimeout(() => {
                        window.dispatchEvent(new Event('resize'));
                      }, 1000);
                    },
                  );

                  let form = new FormData();
                  form.append(file.name, file, '');

                  var settings = {
                    url:
                      baseUrl +
                      SERVICE_ENDPOINTS.Profile_PutImageByProfileId +
                      '?Id=' +
                      this.state.userProfile.ProfileID +
                      '&isDefault=false',
                    method: REQUEST_TYPE.POST,
                    timeout: 0,
                    processData: false,
                    mimeType: 'multipart/form-data',
                    contentType: false,
                    data: form,
                  };

                  FetchData_Override(settings).done(function (response) {});
                } else {
                        izitoast.destroy();
      izitoast.show({

                    title: '',
                    icon: APP_ICONS.DANGER,
                    message: IMAGE_ERR_MSG.HEIGHT_EXCEED+ '. Current height is:' + _img.height + '. Maximum height is:' + ImageUploadConfig.maxHeight+ 'px.',
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
                  message: IMAGE_ERR_MSG.WIDTH_EXCEED + '. Current Width is:' + _img.width + '. Maximum width is:' + ImageUploadConfig.maxWidth+ 'px.' ,
                  //position : APP_TOAST_POSITION.BOTTOM_CENTER,
                  target: '.testtarget',
                  color: COLOR.RED,
                  messageSize: SIZE.FONT_SIZE
                });
              }
            };
          } else {
                  izitoast.destroy();
      izitoast.show({

              title: '',
              icon: APP_ICONS.DANGER,
              message: IMAGE_ERR_MSG.INVALID_TYPE + '. Current Filetype is:' + filetype + '. Allowed file type are: ' +ImageUploadConfig.allowedTypes ,
              //position : APP_TOAST_POSITION.BOTTOM_CENTER,
              target: '.testtarget',
              color: COLOR.RED,
              messageSize: SIZE.FONT_SIZE
            });
          }
        } else {
          let maxSize= parseFloat(ImageUploadConfig.maxSize) / 1000000;
          let curentSize= (parseFloat(filesize) / 1000000).toFixed(2);
                izitoast.destroy();
      izitoast.show({

            title: '',
            icon: APP_ICONS.DANGER,
            message: IMAGE_ERR_MSG.SIZE_EXCEED + '. Current size is:' + curentSize +'MB' + '. Maximum size is:' +maxSize+ 'MB.',
            //position : APP_TOAST_POSITION.BOTTOM_CENTER,
            target: '.testtarget',
            color: COLOR.RED,
            messageSize: SIZE.FONT_SIZE
          });
        }
      }
    }
  };
  validateInformation() {
    if (this.state.userContactNumber <= 0) {
      return false;
    } else {
      return true;
    }
  }
  saveAccountInfo = (e) => {
    var s1 = this.state.userContactNumber;
    var s2 = default_strings.PHONE_COUNTRY_CODE
    var contactNumber = s2 + "-" + s1;
    console.log('saveNumber' ,contactNumber )
  
    e.preventDefault();
    const prevUserInfo = this.state.userInfo;
    const updatedUserInfo = {
      FirstName: this.state.userFirstName,
      LastName: this.state.userLastName,
      ImagePath: this.state.imagePath,
      FatherName: contactNumber, //using FatherName for User Contact No
    };
    
    const newUpdatedInfo = { ...prevUserInfo, ...updatedUserInfo };
    console.log('updatesinfo',newUpdatedInfo)
    if (this.validateInformation()) {
      FetchData(
        REQUEST_TYPE.POST,
        SERVICE_ENDPOINTS.Profile_Post,
        newUpdatedInfo,
        this.infoSavedStatus,
      );
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Contact Number field is empty or not valid',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };

  infoSavedStatus = (res) => {
    if (res != null) {
      let _userProfile = getStorageItem(USER_PROFILE);
      _userProfile.FirstName = this.state.userFirstName;
      _userProfile.LastName = this.state.userLastName;
      _userProfile.ImagePath = this.state.imagePath;
      _userProfile.FatherName = this.state.userContactNumber;

      setStorageItem(USER_PROFILE, _userProfile);
      window.exposeUserHeader(_userProfile);
      this.setState(
        {
          showCropper: false,
        },
        () => {
          window.dismissModal('myModal');
                izitoast.destroy();
      izitoast.show({

            title: '',
            icon: APP_ICONS.SUCCESS,
            message: 'Information Saved Successfully',
            //position : APP_TOAST_POSITION.BOTTOM_CENTER,
            target: '.testtarget',
            color: COLOR.GREEN,
            messageSize: SIZE.FONT_SIZE
          });
        },
      );
      window.location.reload();
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: 'Error',
        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };
  ChangePasswordFunction = () => {
    let reqObj = {
      Email: this.state.userEmailAddress,
      OldPassword: this.state.ChangePassword.oldPassword,
      NewPassword: this.state.ChangePassword.newPassword,
    };
    if (this.ValidatePassword()) {
      FetchData(
        REQUEST_TYPE.POST,
        SERVICE_ENDPOINTS.Account_ChangePassword,
        reqObj,
        this.changePasswordResponse,
      );
    } else {
    }
  };

  changePasswordResponse = (res) => {
    if (res.StatusMessage == 'Password has been changed successfully') {
      this.setState({ openModal: false }, () => {
              izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.SUCCESS,
          message: res.StatusMessage,
          //position: APP_TOAST_POSITION.BOTTOM_CENTER,
          target: '.testtarget',
          color: COLOR.GREEN,
          messageSize: SIZE.FONT_SIZE
        });
      });
    } else {
            izitoast.destroy();
      izitoast.show({

        title: '',
        icon: APP_ICONS.WARNING,
        message: res.StatusMessage,
        //position: APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };
  ValidatePassword = () => {
    let errors = this.state.ChangePassworderrors;
    let ChangePasswordData = this.state.ChangePassword;
    let value = true;
    if (ChangePasswordData.oldPassword <= 0) {
      errors.oldPassword = 'Old Password Name Required!';
      value = false;
    }
    if (ChangePasswordData.confirmPassword <= 0) {
      errors.confirmPassword = 'Confirm Password Name Required!';
      value = false;
    }
    if (ChangePasswordData.newPassword != ChangePasswordData.confirmPassword) {
      errors.confirmPassword = 'Password does not match';
      value = false;
    }
    if (ChangePasswordData.newPassword.length < 8) {
      errors.newPassword =
        'Password length should not be less than 8 character';
      value = false;
    }
    if (ChangePasswordData.newPassword == ChangePasswordData.oldPassword) {
      errors.newPassword = 'Old Password and New Password cannot be same ';
      value = false;
    }

    this.setState({
      ChangePassworderrors: errors,
    });
    return value;
  };

  render() {
    return (
      <div className="col-lg-9 order-lg-last dashboard-content">
        
        <Modal
          isOpen={this.state.openModal}
          onRequestClose={() => {
            return this.state.openModal;
          }}
          style={customStyles}
          contentLabel="Change Password"
        >
          <div class="modal-header">
            <h4 class="modal-title">Change Password</h4>
            <label
              className="close"
              data-dismiss="modal"
              onClick={(e) => {
                this.setState(
                  {
                    openModal: false,
                  },
                  () => {},
                );
              }}
            >
              <i class="fa fa-times" aria-hidden="true"></i>
            </label>
          </div>
          <div className="row address_managmentrow">
            <form action="#" className="col-lg-12">
              <div className="row">
                <div className="col-md-6">
                  <div className="form-group required-field">
                    <label>Email Address</label>
                    {/*
                     */}
                    <h3>{this.state.userEmailAddress}</h3>
                  </div>
                  {/* End .form-group */}
                </div>
                {/* End .col-md-4 */}
                <div className="col-md-6">
                  <div className="form-group required-field">
                    <label>Old Password</label>
                    <input
                      type="password"
                      maxLength="25"
                      className="form-control"
                      name="oldPassword"
                      value={this.state.ChangePassword.oldPassword}
                      onChange={(e) => {
                        this.handlePasswordChange(e);
                      }}
                    />
                    {this.state.ChangePassworderrors.oldPassword ? (
                      <label style={{ fontSize: 11, color: 'RED' }}>
                        {this.state.ChangePassworderrors.oldPassword}
                      </label>
                    ) : (
                      <></>
                    )}
                  </div>
                  {/* End .form-group */}
                </div>
                {/* End .col-md-4 */}
              </div>
              <div className="row">
                <div className="col-md-6">
                  <div className="form-group required-field">
                    <label>New Password</label>
                    <input
                      type="password"
                      maxLength="25"
                      className="form-control"
                      name="newPassword"
                      value={this.state.ChangePassword.newPassword}
                      onChange={(e) => {
                        this.handlePasswordChange(e);
                      }}
                    />
                    {this.state.ChangePassworderrors.newPassword ? (
                      <label style={{ fontSize: 11, color: 'RED' }}>
                        {this.state.ChangePassworderrors.newPassword}
                      </label>
                    ) : (
                      <></>
                    )}
                  </div>
                  {/* End .form-group */}
                </div>
                {/* End .col-md-4 */}
                <div className="col-md-6">
                  <div className="form-group required-field">
                    <label>Confirm Password</label>
                    <input
                      type="password"
                      maxLength="25"
                      className="form-control"
                      name="confirmPassword"
                      value={this.state.ChangePassword.confirmPassword}
                      onChange={(e) => {
                        this.handlePasswordChange(e);
                      }}
                    />
                    {this.state.ChangePassworderrors.confirmPassword ? (
                      <label style={{ fontSize: 11, color: 'RED' }}>
                        {this.state.ChangePassworderrors.confirmPassword}
                      </label>
                    ) : (
                      <></>
                    )}
                  </div>
                  {/* End .form-group */}
                </div>
                {/* End .col-md-4 */}{' '}
              </div>
              <div className="checkout-steps-action">
                <a
                  href="#"
                  className="btn btn-block btn-outline-secondary"
                  onClick={(e) => {
                    this.ChangePasswordFunction();
                  }}
                >
                  Save
                </a>
              </div>
              {/* End .checkout-steps-action */}
            </form>
          </div>
        </Modal>

        {/* <h2>Account Information</h2> */}
        <div className="mb-4" />
        {/* margin */}
        <div className="card">
          <div className="card-header">
            User Profile
            <a
              href="#"
              className="card-edit"
              onClick={(e) => {
                this.setState({
                  openModal: true,
                });
              }}
            >
              Change Password
            </a>
          </div>
          <div className="card-body">
            <form action="#">
              <div className="row">
                <div className="col-sm-4 npad account_info">
                  <div className="row upload-row">
                    <div className="col col-md-12 upload-col profile_image">
                      <img
                        ref={this.profileImage}
                        src={this.state.ImageSrc}
                        onError={() => {
                          this.profileImage.current.src =
                            'https://d1nhio0ox7pgb.cloudfront.net/_img/o_collection_png/green_dark_grey/512x512/plain/user.png';
                        }}
                        alt="test"
                      />
                      <input
                        ref={this.refUploadInput}
                        onChange={this.onImageChange}
                        type="file"
                        style={{ opacity: 0 }}
                      />
                      <p className="text-center mt-1">
                        {this.state.userFirstName}&nbsp;
                        {this.state.userLastName}
                      </p>
                      <div />
                      <div
                        className="header-dropdown"
                        style={{
                          float: 'right',
                          position: 'absolute',
                          bottom: '5px',
                          right: '75px',
                        }}
                      >
                        <i className="icon-menu" />
                        <div className="header-menu">
                          <ul>
                            <li onClick={this.AddImage}>
                              <a  href="javascript:void(0)">Change Profile Picture</a>
                            </li>
                            <li
                              onClick={(e) => {
                                this.setState({
                                   imagePath: "", ImageSrc: ""},()=>this.saveAccountInfo(e)
                                );
                              }}
                            >
                              <a href="javascript:void(0)">Remove Profile Picture</a>
                            </li>
                          </ul>
                        </div>
                      </div>
                    </div>
                    <div>
                        <span style={{fontWeight:'bold'}}>Upload Image Guidelines</span>
                        <ul>
                          <li>*Image size less than 5mb.</li>
                          <li>*Image type must be .png .jpeg .jpg .webp</li>
                          <li>*Image width less than 2000px.</li>
                          <li>*Image height less than 2000px.</li>
                        </ul>

                      </div>
                  </div>
                </div>
                {/* End .row */}
                <div className="col-sm-8">
                  <div className="row">
                    <div className="col-md-6">
                      <div className="form-group required-field">
                        <label>First Name</label>
                        <input
                          type="text"
                          maxLength = "100"
                          className="form-control"
                          name="userFirstName"
                          value={this.state.userFirstName}
                          onChange={(e) => {
                            this.handleChange(e);
                          }}
                          required
                        />
                      </div>
                      {/* End .form-group */}
                    </div>
                    {/* End .col-md-4 */}
                    <div className="col-md-6">
                      <div className="form-group">
                        <label>Last Name</label>
                        <input
                          type="text"
                          maxLength = "100"
                          className="form-control"
                          name="userLastName"
                          value={this.state.userLastName}
                          onChange={(e) => {
                            this.handleChange(e);
                          }}
                        />
                      </div>
                      {/* End .form-group */}
                    </div>
                    {/* End .col-md-4 */}
                    <div className="col-md-6">
                      <div className="form-group required-field">
                        <label>Email</label>
                        <input
                          type="email"
                          maxLength = "200"
                          className="form-control"
                          name="userEmailAddress"
                          required
                          readOnly
                          defaultValue={this.state.userEmailAddress}
                        />
                      </div>
                      {/* End .form-group */}
                    </div>
                    {/* End .col-md-4 */}
                    <div className="col-md-6">
                      <div className="form-group">
                        <label>Contact Number</label>
                        <div className="row" style={{paddingLeft: '5%',alignItems:'center'}}>
                          <input 
                            type="text"
                            maxLength = "10"
                            className="form-control num-code"
                            name="userCountryCode"
                            value={this.state.CountryCode}
                            readOnly
                            style={{width: "20%"}}
                          />
                          <input
                            type="text"
                            maxLength = "20"
                            className="form-control con-num"
                            name="userContactNumber"
                            value={this.state.userContactNumber}
                            onChange={(e) => {
                              this.handleChange(e);
                            }}
                            style={{width: "76%",paddingBottom: '10px'}}
                          />
                        </div>
                      </div>
                      {/* End .form-group */}
                    </div>
                    {/* End .col-md-4 */}
                    {/* <div className="col-md-6"> */}
                    {/* <div className="form-group required-field">
                <label htmlFor="acc-name">Select Language</label>
                <select className="form-control">
                  <option value default selected disabled>Select Language</option>
                  <option value>English</option>
                  <option value>French</option>
                </select>
              </div> */}
                    {/* End .form-group */}
                    {/* </div> */}
                    {/* End .col-md-4 */}
                    <div className="col-md-6">
                      <div className="form-footer">
                        <div className="form-footer-right">
                          <button
                            type="submit"
                            className="btn btn-block btn-outline-secondary"
                            onClick={(e) => {
                              this.saveAccountInfo(e);
                            }}
                          >
                            Save
                          </button>
                        </div>
                      </div>
                      {/* End .form-footer */}
                    </div>
                  </div>
                  {/* End .row */}
                </div>
                {/* End .col-sm-11 */}
              </div>
              {/* End .row */}
            </form>
          </div>
          {/* End .card-body */}
        </div>
        {/* End .card */}
        <div className="modal fade" id="myModal" role="dialog">
          <div className="modal-dialog" style={{ right: '8%', top: '8%' }}>
            <div className="modal-content">
              <div className="modal-header">
                <h4 className="modal-title">Crop Image</h4>
              </div>
              <div className="modal-body">
                {this.state.showCropper ? (
                  <Cropper
                    image={this.state.image}
                    crop={this.state.crop}
                    zoom={this.state.zoom}
                    aspect={this.state.aspect}
                    onCropChange={this.onCropChange}
                    onCropComplete={this.onCropComplete}
                    onZoomChange={this.onZoomChange}
                    classes={{
                      containerClassName: 'testContainer',
                      mediaClassName: 'testMedia',
                      cropAreaClassName: 'testCropArea',
                    }}
                  />
                ) : (
                  <></>
                )}
                
              </div>
              <div className="modal-footer">
                {this.state.showCropper ? (
                  <>
                    <button
                      className="btn btn-default"
                      onClick={(e) => {
                        const outputX = this.croppedAreaPixels.x; //(outputWidth - inputWidth) * 0.5;
                        const outputY = this.croppedAreaPixels.y; //(outputHeight - inputHeight) * 0.5;

                        // create a canvas that will present the output image
                        const outputImage = document.createElement('canvas');

                        // set it to the same size as the image
                        outputImage.width = this.croppedAreaPixels.width; //outputWidth;
                        outputImage.height = this.croppedAreaPixels.height; //outputHeight;

                        // draw our image at position 0, 0 on the canvas
                        const ctx = outputImage.getContext('2d');
                        ctx.drawImage(
                          this.ImageObj,
                          outputX,
                          outputY,
                          this.croppedAreaPixels.width,
                          this.croppedAreaPixels.height,
                          0,
                          0,
                          this.croppedAreaPixels.width,
                          this.croppedAreaPixels.height,
                        );

                        ctx.canvas.toBlob((b) => {
                          b.name = this.FileObj.name;

                          let _form = new FormData();
                          _form.append(b.name, b, '');
                          
                          var settings = {
                            url:
                              baseUrl +
                              SERVICE_ENDPOINTS.Profile_PutImageByProfileId +
                              '?Id=' +
                              this.state.userProfile.ProfileID +
                              '&isDefault=false',
                            method: REQUEST_TYPE.POST,
                            timeout: 0,
                            processData: false,
                            mimeType: 'multipart/form-data',
                            contentType: false,
                            data: _form,
                          };

                          FetchData_Override(settings).done((response) => {
                            if (response != null) {
                              this.saveAccountInfo(e);
                            }
                          });
                        }, 'image/png');
                      }}
                    >
                      OK
                    </button>
                    <img ref={this.previewImage} src="" />
                  </>
                ) : (
                  <></>
                )}
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}
export default AccountInformation;
