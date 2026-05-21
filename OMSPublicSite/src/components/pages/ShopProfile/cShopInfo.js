import React from 'react';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  USER_PROFILE,
  LIST_PROVINCES,
  LIST_CITIES,
  SUPPLIER_ID,
  PROFILE_ID,
} from '../../../utils/constants';
import {
  FetchData,
  baseUrlImage,
  baseUrl,
  FetchData_Override,
} from '../../../utils/serviceHelper';
import izitoast from 'izitoast';
import { APP_ICONS, APP_TOAST_POSITION, COLOR,  SIZE } from '../../../utils/constants';
import { ImageEntityEnum, ImageUploadConfig } from '../../../utils/enums';
import Cropper from 'react-easy-crop';

const IMAGE_ERR_MSG = {
  HEIGHT_EXCEED: 'file height exceeded',
  WIDTH_EXCEED: 'file width exceeded',
  SIZE_EXCEED: 'file size exceeded',
  INVALID_TYPE: 'Invalid file type',
};

class ShopInformation extends React.Component {
  constructor(props) {
    super(props);
    this.refAnnouncments = React.createRef();
    this.refFAQs = React.createRef();
    this.refShopPolicy = React.createRef();
    this.refUploadInput = React.createRef();
    this.shopImage = React.createRef();
    this.previewImage = React.createRef();
    this.croppedArea = null;
    this.croppedAreaPixels = null;
    this.ImageObj = null;
    this.FileObj = null;
    this.state = {
      userProfile: getStorageItem(USER_PROFILE),
      supplierDetails: {},
      webJ: {},
      Logo: '',
      LogoSrc: '',
      Accouncmentshtml: '',
      ShopPolicyhtml: '',
      FAQshtml: '',
      showCropper: false,
      image: '',
      crop: { x: 0, y: 0 },
      zoom: 1,
      aspect: 4 / 3,
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

  handleOnChange = (e) => {
    this.state.webJ[e.target.name] = e.target.value;
    this.setState({
      webJ: this.state.webJ,
    });
  };

  componentDidMount() {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Supplier_GetSupplierPublic +
        this.state.userProfile.ShopId+ '/' + getStorageItem(PROFILE_ID),
      null,
      this.gotSupplierDetails,
    );
  }

  gotSupplierDetails = (res) => {
    if (res != null) {
      this.setState(
        {
          supplierDetails: res,
          webJ: res.WebLinksJSON ? JSON.parse(res.WebLinksJSON) : {},
          Logo: res.Logo ? res.Logo : '',
          LogoSrc:
            baseUrlImage +
            ImageEntityEnum.SUPPLIER +
            '/' +
            this.state.userProfile.ShopId +
            '/' +
            res.Logo,
          Accouncmentshtml: res.AnnouncementHTML,
          FAQshtml: res.FAQHTML,
          ShopPolicyhtml: res.PolicyHTML,
        },
        () => {
          this.initializeSummerNotes();
        },
      );
      setStorageItem(SUPPLIER_ID, res.ShopID);
    } else {
      this.initializeSummerNotes();
    }
  };

  initializeSummerNotes = () => {
    if (this.refAnnouncments)
      window.createSummerNote(
        this.refAnnouncments,
        (code, we, contents, editable) => {
          this.setState({
            Accouncmentshtml: contents,
          });
        },
        this.state.Accouncmentshtml,
      );

    if (this.refShopPolicy)
      window.createSummerNote(
        this.refShopPolicy,
        (code, we, contents, editable) => {
          this.setState({
            ShopPolicyhtml: contents,
          });
        },
        this.state.ShopPolicyhtml,
      );

    if (this.refFAQs)
      window.createSummerNote(
        this.refFAQs,
        (code, we, contents, editable) => {
          this.setState({
            FAQshtml: contents,
          });
        },
        this.state.FAQshtml,
      );
  };

  saveShopData = (e) => {
    if (e) e.preventDefault();
    this.state.supplierDetails.WebLinksJSON = JSON.stringify(this.state.webJ);
    this.state.supplierDetails.Logo = this.state.Logo;
    this.state.supplierDetails.AnnouncementHTML = this.state.Accouncmentshtml;
    this.state.supplierDetails.FAQHTML = this.state.FAQshtml;
    this.state.supplierDetails.PolicyHTML = this.state.ShopPolicyhtml;
    this.state.supplierDetails.StatusID = 1;
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Supplier_PostSupplierDetails,
      this.state.supplierDetails,
      this.successOnUpdateShopDetails,
    );
  };
  successOnUpdateShopDetails = (res) => {
    if (res === true) {
      FetchData(
        REQUEST_TYPE.GET,
        SERVICE_ENDPOINTS.Supplier_GetSupplierPublic +
          this.state.userProfile.ShopId + '/' + getStorageItem(PROFILE_ID),
        null,
        this.gotSupplierDetails,
      );
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
            message: 'Shop Details Saved Successfully',
            //position: APP_TOAST_POSITION.BOTTOM_CENTER,
            target: '.testtarget',
            color: COLOR.GREEN,
            messageSize: SIZE.FONT_SIZE
          });
        },
      );
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
  DeleteShop = () => {
    this.state.supplierDetails.StatusID = 3;
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.Supplier_PostSupplierDetails,
      this.state.supplierDetails,
      this.successOnUpdateShopDetails,
    );
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
                  this.FileObj = file;
                  this.ImageObj = _img;
                  this.setState(
                    {
                      LogoSrc: _img.src,
                      Logo: file.name,
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
                  message: IMAGE_ERR_MSG.WIDTH_EXCEED + '. Current Width is:' + _img.width + '. Maximum width is:' + ImageUploadConfig.maxWidth+ 'px.',
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
              message: IMAGE_ERR_MSG.INVALID_TYPE + '. Current Filetype is:' + filetype + '. Allowed file type are: ' +ImageUploadConfig.allowedTypes,
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

  render() {
    return (
      <div className="col-lg-9 order-lg-last dashboard-content">
        <div className="mb-4" />
        {/* margin */}
        <div className="card">
          <div className="card-header">
            Shop Information
            <a
              className="custom-boxheader special_hover_link"
              data-toggle="modal"
              data-target="#deleteShopModal"
            >
              Delete Shop
            </a>
          </div>
          {/* End .card-header */}
          <div className="card-body">
            <form action="#">
              <div className="row">
                <div className="col-sm-4 npad account_info">
                  <div className="row upload-row">
                    <div className="col col-md-12 upload-col profile_image">
                      <img
                        ref={this.shopImage}
                        src={this.state.LogoSrc}
                        onError={() => {
                          this.shopImage.current.src =
                            'assets/images/logos/shop.png';
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
                        {this.state.supplierDetails.ShopName}
                      </p>
                      <p className="text-center mt-1">
                        {this.state.supplierDetails.City},{' '}
                        {this.state.supplierDetails.Province}
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
                              <a  href="javascript:void(0)">Change Shop Logo</a>
                            </li>
                            <li
                              onClick={() => {
                                this.setState(
                                  { Logo: '', LogoSrc: '' },
                                  (e) => {
                                    this.saveShopData(e);
                                  },
                                );
                              }}
                            >
                              <a href="javascript:void(0)">Remove Shop Logo</a>
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
                <div className="col-sm-8 top_padding">
                  <div className="row">
                    <div className="col-md-6">
                      <div className="row">
                        <div className="col-sm-3">
                          <label htmlFor="acc-name">
                            {' '}
                            <img
                              src="assets/images/logos/f.png"
                              alt=""
                              className="shop_account_social_icon_image"
                            />
                          </label>
                        </div>
                        <div className="col-sm-9">
                          <div className="form-group">
                            <input
                              type="url"
                              maxLength="200"
                              className="form-control"
                              name="fb"
                              value={
                                this.state.webJ && this.state.webJ.fb
                                  ? this.state.webJ.fb
                                  : ''
                              }
                              required
                              placeholder="Socialmedia-link"
                              onChange={(e) => {
                                this.handleOnChange(e);
                              }}
                            />
                          </div>
                          {/* End .form-group */}
                        </div>
                      </div>
                    </div>
                    {/* End .col-md-4 */}
                    <div className="col-md-6">
                      <div className="row">
                        <div className="col-sm-3">
                          <label htmlFor="acc-name">
                            {' '}
                            <img
                              src="assets/images/logos/shop.png"
                              alt=""
                              className="shop_account_social_icon_image"
                            />
                          </label>
                        </div>
                        <div className="col-sm-9">
                          <div className="form-group">
                            <input
                              type="url"
                              maxLength="200"
                              className="form-control"
                              required
                              placeholder="Shop's web-link"
                              name="goog"
                              value={
                                this.state.webJ && this.state.webJ.goog
                                  ? this.state.webJ.goog
                                  : ''
                              }
                              onChange={(e) => {
                                this.handleOnChange(e);
                              }}
                            />
                          </div>
                          {/* End .form-group */}
                        </div>
                      </div>
                    </div>
                    {/* End .col-md-4 */}
                    <div className="col-md-6">
                      <div className="row">
                        <div className="col-sm-3">
                          <label htmlFor="acc-name">
                            {' '}
                            <img
                              src="assets/images/logos/i.png"
                              alt=""
                              className="shop_account_social_icon_image"
                            />
                          </label>
                        </div>
                        <div className="col-sm-9">
                          <div className="form-group">
                            <input
                              type="url"
                              maxLength="200"
                              className="form-control"
                              required
                              placeholder="Socialmedia-link"
                              name="instagrm"
                              value={
                                this.state.webJ && this.state.webJ.instagrm
                                  ? this.state.webJ.instagrm
                                  : ''
                              }
                              onChange={(e) => {
                                this.handleOnChange(e);
                              }}
                            />
                          </div>
                          {/* End .form-group */}
                        </div>
                      </div>
                    </div>
                    {/* End .col-md-4 */}
                    <div className="col-md-6">
                      <div className="row">
                        <div className="col-sm-3">
                          <label htmlFor="acc-name">
                            {' '}
                            <img
                              src="assets/images/logos/pp.png"
                              alt=""
                              className="shop_account_social_icon_image"
                            />
                          </label>
                        </div>
                        <div className="col-sm-9">
                          <div className="form-group">
                            <input
                              type="url"
                              maxLength="200"
                              className="form-control"
                              required
                              placeholder="Socialmedia-link"
                              name="pinterest"
                              value={
                                this.state.webJ && this.state.webJ.pinterest
                                  ? this.state.webJ.pinterest
                                  : ''
                              }
                              onChange={(e) => {
                                this.handleOnChange(e);
                              }}
                            />
                          </div>
                          {/* End .form-group */}
                        </div>
                      </div>
                    </div>
                    {/* End .col-md-4 */}
                    <div className="col-md-6">
                      <div className="row">
                        <div className="col-sm-3">
                          <label htmlFor="acc-name">
                            {' '}
                            <img
                              src="assets/images/logos/t.png"
                              alt=""
                              className="shop_account_social_icon_image"
                            />
                          </label>
                        </div>
                        <div className="col-sm-9">
                          <div className="form-group">
                            <input
                              type="url"
                              maxLength="200"
                              className="form-control"
                              required
                              placeholder="Socialmedia-link"
                              name="twitr"
                              value={
                                this.state.webJ && this.state.webJ.twitr
                                  ? this.state.webJ.twitr
                                  : ''
                              }
                              onChange={(e) => {
                                this.handleOnChange(e);
                              }}
                            />
                          </div>
                          {/* End .form-group */}
                        </div>
                      </div>
                    </div>
                    {/* End .col-md-4 */}
                    <div className="col-md-6">
                      <div className="row">
                        <div className="col-sm-3">
                          <label htmlFor="acc-name">
                            {' '}
                            <img
                              src="assets/images/logos/y.png"
                              alt=""
                              className="shop_account_social_icon_image"
                            />
                          </label>
                        </div>
                        <div className="col-sm-9">
                          <div className="form-group">
                            <input
                              type="url"
                              maxLength="200"
                              className="form-control"
                              required
                              placeholder="Socialmedia-link"
                              name="youtb"
                              value={
                                this.state.webJ && this.state.webJ.youtb
                                  ? this.state.webJ.youtb
                                  : ''
                              }
                              onChange={(e) => {
                                this.handleOnChange(e);
                              }}
                            />
                          </div>
                          {/* End .form-group */}
                        </div>
                        <div className="checkout-steps-action">
                          <a
                            href=""
                            className="btn btn-block btn-outline-secondary asv"
                            onClick={(e) => {
                              this.saveShopData(e);
                            }}
                          >
                            Save
                          </a>
                        </div>
                      </div>
                    </div>
                    {/* End .col-md-4 */}
                  </div>
                  {/* End .row */}
                </div>
                {/* End .col-sm-11 */}
              </div>
              {/* End .row */}
              <div className="row">
                <div className="col-sm-12">
                  <div className="form-group">
                    <label htmlFor="acc-name">Announcements</label>
                    <textarea
                      ref={this.refAnnouncments}
                      name="Description"
                      type="text"
                      className="form-control"
                      placeholder="Description"
                      cols={10}
                      rows={1}
                      defaultValue={''}
                    />
                  </div>
                  {/* End .form-group */}
                </div>
                <div className="col-sm-12">
                  <div className="form-group">
                    <label htmlFor="acc-name">Shop Policy</label>
                    <textarea
                      ref={this.refShopPolicy}
                      name="DescriptionPolicy"
                      type="text"
                      className="form-control"
                      placeholder="Description"
                      cols={10}
                      rows={1}
                      defaultValue={''}
                    />
                  </div>
                  {/* End .form-group */}
                </div>
                <div className="col-sm-12">
                  <div className="form-group">
                    <label htmlFor="acc-name">FAQs</label>
                    <textarea
                      ref={this.refFAQs}
                      name="DescriptionFAQs"
                      type="text"
                      className="form-control"
                      placeholder="Description"
                      cols={10}
                      rows={1}
                      defaultValue={''}
                    />
                  </div>
                  {/* End .form-group */}
                </div>
              </div>
            </form>
          </div>
          {/* End .card-body */}
        </div>
        {/* End .card */}
        <div
          className="modal fade"
          id="deleteShopModal"
          tabIndex={-1}
          role="dialog"
          aria-labelledby="deleteShopModal"
        >
          <div className="modal-dialog custom-modalpostion" role="document">
            <div className="modal-content custom-deleteshopmodalsize">
              <div className="modal-body add-cart-box  custom-deleteshopmodalsize text-center">
                <p>
                  Do you really want to delete your shop
                  <br />
                </p>
                <div className="btn-actions">
                  <a href="#">
                    <button
                      className="btn btn-dark"
                      style={{ padding: '8px' }}
                      data-dismiss="modal"
                      onClick={() => {
                        this.DeleteShop();
                      }}
                    >
                      Yes
                    </button>
                  </a>
                  <a href="#">
                    <button
                      className="btn btn-dark"
                      style={{ padding: '8px' }}
                      data-dismiss="modal"
                    >
                      No
                    </button>
                  </a>
                </div>
              </div>
            </div>
          </div>
        </div>
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

                          let settings = {
                            url:
                              baseUrl +
                              SERVICE_ENDPOINTS.Supplier_PutImageByShopId +
                              '?Id=' +
                              this.state.userProfile.ShopId +
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
                              this.saveShopData();
                            }
                          });
                        }, 'image/png');
                      }}
                    >
                      Ok
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

export default ShopInformation;
