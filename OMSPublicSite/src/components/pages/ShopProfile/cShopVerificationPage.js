import React from 'react';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SUPPLIER_ID,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  PROFILE_ID,
  USER_PROFILE,
  SIZE
} from '../../../utils/constants';
import {
  baseUrl,
  baseUrlImage,
  FetchData,
  FetchData_Override,
} from '../../../utils/serviceHelper';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import izitoast from 'izitoast';

import { ImageEntityEnum, ImageUploadConfig } from '../../../utils/enums';

class ShopVerification extends React.Component {
  constructor(props) {
    super(props);
    this.refUploadInput = React.createRef();
    this.previewImage = React.createRef();
    this.state = {
      userID: getStorageItem(PROFILE_ID),
      shopOwnerDetails: getStorageItem(USER_PROFILE),
      userFullName: '',
      docType: '',
      docNumByUser: '',
      imgSrc: null,
      filename: null,
      file: null,
      documentTypeList: [],
      documentList: [],
      ShopDetails: {},
      EditRow: {},
      isEdit: false,
      isImageChange: false,
      editVerificationId : null,
      btnVerification : false
    };
  }
  componentDidMount() {
    this.GetDocumentTypeList();
    this.GetShopOwnerData();
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.ProfileVerification_GetListForPublic +
        encodeURI(this.state.userID),
      null,
      this.successListForPublic,
    );
  }
  GetShopOwnerData = () => {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Supplier_GetSupplierPublic +
        this.state.shopOwnerDetails.ShopId + '/' + getStorageItem(PROFILE_ID),
      null,
      this.gotSupplierDetails,
    );
  };
  gotSupplierDetails = (res) => {
    this.setState({
      ShopDetails: res,
    });
  };
  GetDocumentTypeList = () => {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.DocumentType_GetList,
      null,
      this.successDocTypeList,
    );
  };
  successDocTypeList = (res) => {
    if (res) {
      this.setState({
        documentTypeList: res,
      });
    }
  };
  successListForPublic = (res) => {
    if (res && res.length > 0) {
      this.setState({
        documentList: res,
      });
    }
  };

  AddImage = () => {
    this.refUploadInput.current.click();
  };

  handleOnChange = (e) => {
    console.log(e.target.value);
    console.log(this.state.documentList);
    // documentTypeList
    // .filter(
    //   (f) =>
    //     !this.state.documentList
    //       .map((a) => a.DocumentTypeID)
    //       .includes(f.DocumentTypeID),
    // )

    if (e.target.name === 'docType') {
      if (
        this.state.documentList.some((a) => a.DocumentTypeID == e.target.value)
      ) {
              izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.WARNING,
          message: 'This document type already exists',
          //position: APP_TOAST_POSITION.BOTTOM_CENTER,
          target: '.testtarget',
          color: COLOR.RED,
          messageSize: SIZE.FONT_SIZE
        });
      } else {
        this.setState({
          [e.target.name]: e.target.value,
        });
      }
    } else {
      this.setState({
        [e.target.name]: e.target.value,
      });
    }
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
                  console.log(_img);
                  console.log(file);
                  this.setState({
                    imgSrc: _img.src,
                    filename: file.name,
                    file: file,
                  });
                } else {
                        izitoast.destroy();
      izitoast.show({

                    title: '',
                    icon: APP_ICONS.DANGER,
                    message: IMAGE_ERR_MSG.HEIGHT_EXCEED,
                    //position : APP_TOAST_POSITION.BOTTOM_CENTER,
                    target: '.testtarget',
                    color: COLOR.GREEN, 
                  });
                }
              } else {
                      izitoast.destroy();
      izitoast.show({

                  title: '',
                  icon: APP_ICONS.DANGER,
                  message: IMAGE_ERR_MSG.WIDTH_EXCEED,
                  //position : APP_TOAST_POSITION.BOTTOM_CENTER,
                  target: '.testtarget',
                    color: COLOR.GREEN,
                });
              }
            };
          } else {
                  izitoast.destroy();
      izitoast.show({

              title: '',
              icon: APP_ICONS.DANGER,
              message: IMAGE_ERR_MSG.INVALID_TYPE,
              //position : APP_TOAST_POSITION.BOTTOM_CENTER,
              target: '.testtarget',
                color: COLOR.GREEN,
            });
          }
        } else {
                izitoast.destroy();
      izitoast.show({

            title: '',
            icon: APP_ICONS.DANGER,
            message: IMAGE_ERR_MSG.SIZE_EXCEED,
            //position : APP_TOAST_POSITION.BOTTOM_CENTER,
            target: '.testtarget',
              color: COLOR.GREEN,
          });
        }
      }
      this.setState({
        isImageChange: true,
      });
    }
  };
  submitDocument = (e) => {
    e.preventDefault();
    console.log('HERE', this.state.isImageChange);
    let reqPutObj = {
      ProfileID: this.state.userID,
      FullName: this.state.ShopDetails ? this.state.ShopDetails.ShopName : '',
      DocumentTypeID: this.state.docType,
      DocumentNumberByUser: this.state.docNumByUser,
      DocumentImagePath: this.state.filename,
      RequestedByProfileId: this.state.EditRow
        ? this.state.EditRow.RequestedByProfileId
        : '',
      VerificationID: this.state.EditRow
        ? this.state.EditRow.VerificationID
        : '',
    };

    if (this.state.isEdit) {
      FetchData(
        REQUEST_TYPE.POST,
        SERVICE_ENDPOINTS.ProfileVerification_PostForUser,
        reqPutObj,
        this.successPutVerification,
      );
    } else {
      FetchData(
        REQUEST_TYPE.PUT,
        SERVICE_ENDPOINTS.ProfileVerification_PutForUser,
        reqPutObj,
        this.successPutVerification,
      );
    }
    if (this.state.isImageChange) {
      let form = new FormData();
      form.append(this.state.filename, this.state.file, '');

      var settings = {
        url:
          baseUrl +
          SERVICE_ENDPOINTS.ProfileVerification_PutVerificationDocument +
          '?Id=' +
          this.state.userID,
        method: REQUEST_TYPE.POST,
        timeout: 0,
        processData: false,
        mimeType: 'multipart/form-data',
        contentType: false,
        data: form,
      };
    }

    FetchData_Override(settings).done(function (response) {
      console.log(response);
    });
  };

  failImageInsert = () => {
    console.log('image save failed');
  };

  successImageInsert = (res) => {
    console.log(res);
  };

  successPutVerification = (res) => {
    console.log(res);
    this.clearFields();
          izitoast.destroy();
      izitoast.show({

      title: '',
      icon: APP_ICONS.SUCCESS,
      message: 'Document saved success',
      //position: APP_TOAST_POSITION.BOTTOM_CENTER,
      target: '.testtarget',
      color: COLOR.GREEN,
      messageSize: SIZE.FONT_SIZE
    });
  };
  EditRow = (e, item) => {
    e.preventDefault();
    this.setState({
      btnVerification : false
    })
    if(item.VerificationStatusTitle === 'Verified')
    {
        this.setState({
          btnVerification : true
        })
        console.log('btnVerification', this.state.btnVerification)
    }
    let list = this.state.documentList.filter(f=> !(f.VerificationID == item.VerificationID))
    list.forEach(element => {
      element.isEdit = false
    });

    item.isEdit = (item.isEdit)?false : true
    
    this.setState(
      {
        documentList : this.state.documentList,
        isEdit: true,
        EditRow: item,
        userID: item.ProfileID,
        ShopDetails: item.FullName,
        docType: item.DocumentTypeID,
        docNumByUser: item.DocumentNumberByUser,
        filename: item.DocumentImagePath,
        imgSrc : baseUrlImage + ImageEntityEnum.PROFILEVERIFICATION + '/' + item.VerificationID + '/' + item.DocumentImagePath
      },
      () => {
        //console.log('THIS', this.state.documentList);
      },
    );
  };
  clearFields = () => {
    this.setState({
      isEdit: false,
      isImageChange: false,
      EditRow: {},
      docType: '',
      docNumByUser: '',
      filename: '',
    });
  };
  documentStatus = (item) => {
    let badge;
    if (item.VerificationStatusTitle == 'Verified') {
      badge = 'badge badge-success';
    }
    if (item.VerificationStatusTitle == 'UnVerified') {
      badge = 'badge badge-warning';
    }
    if (item.VerificationStatusTitle == 'Rejected') {
      badge = 'badge badge-danger';
    }
    if (item.VerificationStatusTitle == 'BlackListed') {
      badge = 'badge badge-dark';
    }
    return (
      <h4>
        <span className={badge}>{item.VerificationStatusTitle}</span>
      </h4>
    );
  };

  render() {
    let documentTypeList = this.state.documentTypeList;
    return (
      <div className="col-lg-9 order-lg-last dashboard-content">
        <table
          className="table table-striped"
          style={{
            borderWidth: '1px',
            borderColor: '#aaaaaa',
            borderStyle: 'solid',
          }}
        >
          <thead>
            <tr>
              <th>Full User Name</th>
              <th>Document Type</th>
              <th>Document Number</th>
              <th>Verification Status</th>
              <th>Edit</th>
            </tr>
          </thead>
          <tbody>
            {this.state.documentList ? (
              this.state.documentList.map((item, j) => (
                <tr key={j}>
                  <td>{item.FullName}</td>
                  <td>{item.DocumentTypeTitle}</td>
                  <td>{item.DocumentNumberByUser}</td>
                  <td>{this.documentStatus(item)}</td>
                  <td>
                    <label
                      className="checkbox-label form-check-label"
                      htmlFor={'check-' + j}
                      onClick={(e) => {
                        this.EditRow(e, item);
                      }}
                    >
                      <input
                        type="checkbox"
                        className="form-check-input"
                        id={'check-' + j}
                        
                        checked={item.isEdit}
                      />
                      <span className="checkbox-custom circular" />
                    </label>
                  </td>
                </tr>
              ))
            ) : (
              <p>{'  '}Currently you have not requested for document verification.</p>
            )}
          </tbody>
        </table>
        <hr />
        <div className="col-sm-9 mt-2">
          <div className="form-group">
            <label className="mr-4">User Full Name</label>
            <input
              type="text"
              maxLength="200"
              className="form-control"
              name="userFullName"
              disabled
              value={
                this.state.ShopDetails ? this.state.ShopDetails.ShopName : ''
              }
              required
              onChange={(e) => {
                this.handleOnChange(e);
              }}
            />
          </div>
          {/* End .form-group */}
        </div>
        <div className="col-sm-9">
          <div className="form-group">
            <label className="mr-4">Document Type</label>
            <select
              className="form-control"
              required
              value={this.state.docType}
              onChange={(e) => this.handleOnChange(e)}
              name="docType"
            >
              <option value="">Please Select</option>
              {/* {documentTypeList ? (
                documentTypeList
                  .filter(
                    (f) =>
                      !this.state.documentList
                        .map((a) => a.DocumentTypeID)
                        .includes(f.DocumentTypeID),
                  )
                  .map((item, i) => (
                    <option value={item.DocumentTypeID} key={i}>
                      {item.Description}
                    </option>
                  ))
              ) : (
                <></>
              )} */}
              {documentTypeList ? (
                documentTypeList.map((item, i) => (
                  <option value={item.DocumentTypeID} key={i}>
                    {item.Description}
                  </option>
                ))
              ) : (
                <></>
              )}
            </select>
          </div>
          {/* End .form-group */}
        </div>
        <div className="col-sm-9">
          <div className="form-group">
            <label className="mr-4">Document No. By User</label>
            <input
              type="text"
              maxLength="200"
              className="form-control"
              name="docNumByUser"
              value={this.state.docNumByUser ? this.state.docNumByUser : ''}
              required
              onChange={(e) => {
                this.handleOnChange(e);
              }}
            />
          </div>
          {/* End .form-group */}
        </div>
        <div className="col-sm-9">
          <div className="form-group">
            <div className="row" style={{ margin: '-4px' }}>
              <div
                onClick={this.AddImage}
                className="col col-md-4 upload-col d-flex flex-column justify-content-center"
                id="img-upload-container"
              >
                <img
                  src={
                    this.state.imgSrc
                      ? this.state.imgSrc
                      : 'assets/images/placeholder/camera-solid.svg'
                  }
                  alt="placeholder-img"
                />
                <input
                  ref={this.refUploadInput}
                  onChange={this.onImageChange}
                  type="file"
                  style={{ opacity: 0 }}
                />
                <p className="text-center mt-1">
                  {this.state.filename
                    ? this.state.filename
                    : 'Upload Document Image'}
                </p>
              </div>
            </div>
          </div>
        </div>
        {this.state.btnVerification ? null : 
        <div className="form-footer">
          <button
            name= "btnSubmit"
            type="submit"
            className="btn btn-primary nextbtn"
            onClick={(e) => {
              this.submitDocument(e);
            }}
          >
            Submit
          </button>
          <button
            name= "btnClear"
            type="submit"
            className="btn btn-primary nextbtn"
            onClick={(e) => {
              this.clearFields(e);
            }}
          >
            Clear
          </button>
        </div>}
        
        {/* End .form-footer */}
      </div>
    );
  }
}
export default ShopVerification;
