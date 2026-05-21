import React from 'react';
import izitoast from 'izitoast';
import 'izitoast/dist/css/iziToast.css';
import { APP_ICONS, APP_TOAST_POSITION, PRODUCT_ID, PROFILE_ID, COLOR, REQUEST_TYPE, SERVICE_ENDPOINTS, SIZE } from '../../../utils/constants';
import { ImageEntityEnum, ImageUploadConfig } from '../../../utils/enums';
import {
  baseUrlImage, FetchData,
  FetchData_Override,
  baseUrl
} from '../../../utils/serviceHelper';
import Cropper from 'react-easy-crop';
import { getStorageItem, setStorageItem } from '../../../utils/storageHelper';
import Modal from 'react-modal';


const enPARENT = {
  ProductImages: 'ProductImages',
};

const IMAGE_ERR_MSG = {
  HEIGHT_EXCEED: 'file height exceeded',
  WIDTH_EXCEED: 'file width exceeded',
  SIZE_EXCEED: 'file size exceeded',
  INVALID_TYPE: 'Invalid file type',
};

class ProductImages extends React.Component {
  constructor(props) {
    super(props);
    this.refUploadInput = React.createRef();
    this.previewImage = React.createRef();
    this.croppedArea = null;
    this.croppedAreaPixels = null;
    this.ImageObj = null;
    this.FileObj = null;
    this.state = {
      showCropper: false,
      removeImageModal: false,
      removeImage: false,
      stateImage: {},
      stateImageIndex: 0,
      image: '',
      crop: { x: 0, y: 0 },
      zoom: 0.4,
      minZoom: 0.4,
      aspect: 4 / 3,
      ProductImages: [],
      ProductImageFileArray: [],
      Product: {
        RequestedByProfileId: getStorageItem(PROFILE_ID)
      }

    };
  }
  successImageGet = (resCon, param) => {
    resCon.IsDefault = param._image.IsDefault;
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.ProductMediaDetail_Post,
      resCon,
      this.successImagePost,
      this.failImagePost,
      { resolve: param.resolve },
      { reject: param.reject },
    );
  };

  successImagePost = (res, param) => {
    param.resolve(res);
  };

  failImagePost = (err, param) => {
    param.reject(err);
  };

  successImageInsert = (res, param) => {
    param._image.ProductMediaID = res;
    param.resolve(res);
    izitoast.show({
      title: '',
      icon: APP_ICONS.DANGER,
      message: 'Image uploaded successfully',
      //position : APP_TOAST_POSITION.BOTTOM_CENTER,
      target: '.testtarget',
      color: COLOR.GREEN,
      messageSize: SIZE.FONT_SIZE
    });
  };
  failImageInsert = (err, param) => {
    param.reject(err);
  };
  uploadImageToServer = () => {
    console.log('Upload Image to server', this.state.ProductImages);
    console.log('Upload Image to server', this.state.ProductImageFileArray);
    let arrPromises = [];
    for (let _image of this.state.ProductImages) {
      if (!(_image.ProductMediaID && _image.ProductMediaID != '')) {
        let p = new Promise((resolve, reject) => {
          FetchData(
            REQUEST_TYPE.PUT,
            SERVICE_ENDPOINTS.ProductMediaDetail_PutImage,
            {
              ImageFileName: _image.ImageFileName,
              IsDefault: _image.IsDefault,
              ProductID: _image.ProductID,
              ProductMediaID: _image.ProductMediaID
            },
            this.successImageInsert,
            this.failImageInsert,
            { _image: _image, resolve: resolve },
            { reject: reject },
          );
        });
        arrPromises.push(p);
      } else {
        //removing update for now
        let p = new Promise((resolve, reject) => {
          FetchData(
            REQUEST_TYPE.GET,
            SERVICE_ENDPOINTS.ProductMediaDetail_GetById +
            _image.ProductMediaID,
            null,
            this.successImageGet,
            null,
            { _image: _image, resolve: resolve, reject: reject },
          );
        });
        arrPromises.push(p);
      }

      //posting images to server
      let pfilePost = new Promise((resolve, reject) => {
        if (this.state.ProductImageFileArray.length > 0) {

          let form = new FormData();
          for (let file of this.state.ProductImageFileArray) {
            form.append(file.name, file, '');
          }
          var settings = {
            url:
              baseUrl +
              SERVICE_ENDPOINTS.ProductMediaDetail_PutImageByProductId +
              '?Id=' +
              _image.ProductID +
              '&isDefault=false',
            method: REQUEST_TYPE.POST,
            timeout: 0,
            processData: false,
            mimeType: 'multipart/form-data',
            contentType: false,
            data: form,
          };

          FetchData_Override(settings).done(function (response) {
            resolve();
          });
        } else {
          resolve();
        }
      });
      arrPromises.push(pfilePost);

    }
    console.log(arrPromises);
    Promise.all(arrPromises).then((values) => {
      console.log('Images pushed.', values)
    });
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
    window.scrollTo(0, 0);
  }

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
                    message: IMAGE_ERR_MSG.HEIGHT_EXCEED + '. Current height is:' + _img.height + '. Maximum height is:' + ImageUploadConfig.maxHeight + 'px.',
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
                  message: IMAGE_ERR_MSG.WIDTH_EXCEED + '. Current Width is:' + _img.width + '. Maximum width is:' + ImageUploadConfig.maxWidth + 'px.',
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
              message: IMAGE_ERR_MSG.INVALID_TYPE + '. Current Filetype is:' + filetype + '. Allowed file type are: ' + ImageUploadConfig.allowedTypes,
              //position : APP_TOAST_POSITION.BOTTOM_CENTER,
              target: '.testtarget',
              color: COLOR.RED,
              messageSize: SIZE.FONT_SIZE
            });
          }
        } else {
          let maxSize = parseFloat(ImageUploadConfig.maxSize) / 1000000;
          let curentSize = (parseFloat(filesize) / 1000000).toFixed(2);
          izitoast.destroy();
          izitoast.show({

            title: '',
            icon: APP_ICONS.DANGER,
            message: IMAGE_ERR_MSG.SIZE_EXCEED + '. Current size is:' + curentSize + 'MB' + '. Maximum size is:' + maxSize + 'MB.',
            //position : APP_TOAST_POSITION.BOTTOM_CENTER,
            target: '.testtarget',
            color: COLOR.RED,
            messageSize: SIZE.FONT_SIZE
          });
        }
      }
    }
  };

  AddImage = () => {
    this.refUploadInput.current.click();
  };

  successImageRemove = (res, param) => {
    param.resolve(res);
  };

  failImageRemove = (err, param) => {
    param.reject(err);
  };

  RemoveImage = (image, i) => {
    let arrPromises = [];
    let _state = this.props.parentState;
    if (image.ProductMediaID && image.ProductMediaID != '') {
      let p = new Promise((resolve, reject) => {
        FetchData(
          REQUEST_TYPE.DELETE,
          SERVICE_ENDPOINTS.ProductMediaDetail_Delete +
          image.ProductMediaID,
          null,
          this.successImageRemove,
          this.failImageRemove,
          { image: image, resolve: resolve },
          { reject: reject },
        );
      });
      arrPromises.push(p);

      Promise.all(arrPromises).then((values) => {
        console.log('Images Removed');
      });
    }
    _state.ProductImages.splice(i, 1);
    this.props.setValues(enPARENT.ProductImages, _state.ProductImages);
  };

  setAsDefault = (image, i) => {
    let _state = this.props.parentState;
    for (let item of _state.ProductImages) {
      item.IsDefault = false;
    }
    image.IsDefault = true;
    this.props.setValues(enPARENT.ProductImages, _state.ProductImages);
    this.setState({
      ProductImages: _state.ProductImages
    });

    if (_state.ProductImages.length) {
      for (let i = 0; i < _state.ProductImages.length; i++){
       if(_state.ProductImages[i].IsDefault === true)
       {
         FetchData(
          REQUEST_TYPE.POST,
          `/ProductMediaDetail/SetImageAsDefault/${_state.ProductImages[i].ProductMediaID}`,
          null,
          this.successDefaultImage,
        );
       } 
      }
    }
  };

  successDefaultImage = (res) => {
    console.log('Image setted as default',res);
  }

  render() {
    let _state = this.props.parentState;
    return (
      <>
        <span style={{ fontWeight: 'bold', fontSize: '1.7em', color: 'Red' }}>Please remember to set one image as default</span>
        <div className="body">
          <div className="row">
            <div className="col-sm-12 npad">
              <div className="row upload-row">
                <div className="img-ins">
                  <span style={{ fontWeight: 'bold' }}>Upload Image Guidelines</span>
                  <ul>
                    <li>* Image size less than 5mb.</li>
                    <li>* Image type must be .png .jpeg .jpg .webp</li>
                    <li>* Image width less than 2000px.</li>
                    <li>* Image height less than 2000px.</li>
                  </ul>
                </div>
                <div
                  onClick={this.AddImage}
                  className="col col-md-4 upload-col d-flex flex-column justify-content-center pro-img-upload"
                  id="img-upload-container"
                >
                  <img
                    src="assets/images/placeholder/camera-solid.svg"
                    alt="placeholder-img"
                  />
                  <input
                    ref={this.refUploadInput}
                    onChange={this.onImageChange}
                    type="file"
                    style={{ opacity: 0 }}
                  />
                  <p className="text-center mt-1"> Add an Image</p>
                </div>

                {_state.ProductImages && _state.ProductImages.length > 0 ? (
                  _state.ProductImages.map((image, i) => (
                    <div key={i} className="col col-md-4 upload-col for-res-inm">
                      {image.ProductMediaID ? (
                        <img
                          src={
                            baseUrlImage +
                            ImageEntityEnum.PRODUCT +
                            '/' +
                            image.ProductID +
                            '/' +
                            image.ImageFileName
                          }
                          alt=""
                        />
                      ) : (
                        <img src={image.URL} alt="" />
                      )}

                      <p className="text-center mt-1">{image.ImageFileName}</p>
                      {image.IsDefault ? (
                        <div
                          style={{
                            float: 'left',
                            position: 'absolute',
                            top: '5px',
                            left: '5px',
                            color: 'green',
                            fontSize: '20px',
                          }}
                        >
                          <i className="fa fa-check-circle" />
                        </div>
                      ) : (
                        <div></div>
                      )}

                      <div
                        className="header-dropdown"
                        style={{
                          float: 'right',
                          position: 'absolute',
                          bottom: '5px',
                          right: '5px',
                        }}
                      >
                        <i className="icon-menu" />
                        <div className="header-menu">
                          <ul>
                            <li
                              onClick={() => {
                                this.setAsDefault(image, i);
                              }}
                            >
                              <a href="javascript:void(0)">Set as Default</a>
                            </li>
                            <li
                              onClick={() => {
                                console.log('clicked')
                                this.setState({
                                  removeImageModal: true,
                                  stateImage: image,
                                  stateImageIndex: i
                                });
                              }}
                            >
                              <a href="javascript:void(0)">Remove Image</a>
                            </li>
                          </ul>
                        </div>
                      </div>
                    </div>
                  ))
                ) : (
                  <div></div>
                )}
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
                      minZoom={this.state.minZoom}
                      restrictPosition={false}
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

                          let _state = this.state;
                          let _state1 = this.props.parentState
                          let currentProductImage = [];
                          let currentProductImageFileArray = [];

                          let ProductImage = {
                            ProductMediaID: null,
                            RequestedByProfileId:
                              _state.Product.RequestedByProfileId,
                            ProductID: _state1.Product.ProductID,
                            ImageFileName: this.FileObj.name, //filename,
                            IsDefault: false,
                            URL: ctx.canvas.toDataURL('image/png'),
                          };

                          _state.ProductImages.push(ProductImage);
                          _state1.ProductImages.push(ProductImage);
                          currentProductImage.push(ProductImage);
                          ctx.canvas.toBlob((b) => {
                            b.name = this.FileObj.name;
                            _state.ProductImageFileArray.push(b);
                            currentProductImageFileArray.push(b)

                            this.props.setValuesMany(
                              {
                                ProductImages: _state1.ProductImages,
                                ProductImageFileArray:
                                  _state1.ProductImageFileArray,
                              }
                            );
                            this.setState(
                              {
                                showCropper: false,
                                ProductImages: currentProductImage,
                                ProductImageFileArray: currentProductImageFileArray,

                              },
                              () => {
                                window.dismissModal('myModal');
                              },
                            );
                          }, 'image/png');
                          setTimeout(() => {
                            this.uploadImageToServer()
                          }, 2500)
                        }
                        }
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
        <Modal
          isOpen={this.state.removeImageModal}
          onRequestClose={() => {
            return this.state.removeImageModal;
          }}
          className="modal-content"
        >
          <div className="modal-header">
            <h4 class="modal-title">Remove Image</h4>
            <label
              className="close"
              data-dismiss="modal"
              onClick={(e) => {
                this.setState({
                  removeImageModal: false,
                });
              }}
            >
              <i class="fa fa-times" aria-hidden="true"></i>
            </label>
          </div>
          <div className="modal-body">
            <div className="row address_managmentrow">
              <form className="col-lg-12">
                <div className="form-group">
                  <label>Are you sure you want to remove this image?</label>
                </div>
                <div className="btn-actions" style={{ justifyContent: 'space-between' }}>
                  <a href="#">
                    <button
                      className="btn btn-dark"
                      style={{ padding: '8px', marginBottom: '24px', marginRight: '24px' }}
                      data-dismiss="modal"
                      onClick={() => {
                        this.setState({
                          removeImageModal: false
                        })
                      }}
                    >
                      No
                    </button>
                  </a>
                  <a href="#">
                    <button
                      className="btn btn-dark"
                      style={{ backgroundColor: 'grey', marginBottom: '24px' }}
                      data-dismiss="modal"
                      onClick={() => {
                        console.log('remove removeImageModal', this.state.removeImageModal)
                        this.setState({
                          removeImage: true,
                          removeImageModal: false
                        })

                        setTimeout(() => {
                          console.log('remove image', this.state.removeImage)
                          console.log('remove removeImageModal', this.state.removeImageModal)
                          if (this.state.removeImage) {
                            console.log('remove image')
                            this.RemoveImage(this.state.stateImage, this.state.stateImageIndex);
                          }
                        }, 500)

                      }}
                    >
                      Yes
                    </button>
                  </a>
                </div>
                {/* <div>
                  <div className="checkout-steps-action" >
                    <a
                      href="#"
                      className="btn btn-block btn-outline-secondary"
                      onClick={() => {
                        console.log('remove removeImageModal', this.state.removeImageModal)
                        this.setState({
                          removeImage: true,
                          removeImageModal: false
                        })
                        
                        setTimeout(() => {
                          console.log('remove image', this.state.removeImage)
                          console.log('remove removeImageModal', this.state.removeImageModal)
                          if (this.state.removeImage) {
                            console.log('remove image')
                            this.RemoveImage(this.state.stateImage, this.state.stateImageIndex);
                          }
                        }, 500)
                        
                      }}
                    >
                      Yes
                    </a>
                  </div>
                  <div className="checkout-steps-action">
                    <a
                      href="#"
                      className="btn btn-block btn-outline-secondary"
                      onClick={() => {
                        this.setState({
                          removeImageModal: false
                        })
                      }}
                    >
                      No
                    </a>
                  </div>
                </div> */}

              </form>
            </div>
          </div>
        </Modal>
      </>
    );
  }
}

export default ProductImages;
