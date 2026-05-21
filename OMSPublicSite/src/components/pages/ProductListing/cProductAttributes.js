import React from 'react';
import { FetchData } from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SUPPLIER_ID,
  APP_ICONS,
  APP_TOAST_POSITION,
  COLOR,
  PROFILE_ID,
  SIZE
} from '../../../utils/constants';
import { getStorageItem } from '../../../utils/storageHelper';
import Modal from 'react-modal';
import izitoast from 'izitoast';

const enAttributeType = {
  1: "Customization",
  2: "Specification"
}

const enPARENT = {
  AttributeID: 'AttributeID',
  lstUniqueAttributes: 'lstUniqueAttributes',
  Attribute: 'Attribute',
  listProductAttributePairs: 'listProductAttributePairs',
};

class ProductAttributes extends React.Component {
  constructor(props) {
    super(props);
    this.attrItem = null;
    this.stateitem= {};
    this.state = {
      Attribute: '',
      AttributeValue: '',
      listAttribute: [],
      listAttributeValues: [],
      RequestingAttribute: '',
      RequestingAttrData: {},
      requestAttributeModal: false,
      modalItem: {},
      adjustmentModal: false,
      UserProfile: getStorageItem(PROFILE_ID),
    };
  }

  componentDidMount() {
    window.scrollTo(0, 0);

    let _state = this.props.parentState;

    if (
      !(
        _state.listAllProductAttributePairs &&
        _state.listAllProductAttributePairs.length > 0
      )
    ) {
      //fetch Attributes
      this.fetchAllAttributes();
    } else {
      this.consolidateAttributeValues(_state.listAllProductAttributePairs);
    }
  }

  componentDidUpdate() { }

  successGetAllAttributesByProductId = (res) => {
    console.log(' this res', res);
    let _state = this.props.parentState;
    this.props.setValuesMany(
      {
        listProductAttributePairs: res.filter(a => a.IsAssigned == true), //&& a.AttributeTypeID == 2
        listAllProductAttributePairs: res,
      },
      () => {
        this.consolidateAttributeValues(res);
      },
    );

    // if (
    //   !(
    //     _state.listProductAttributePairs &&
    //     _state.listProductAttributePairs.length > 0
    //   )
    // ) {
    //   //fetch categories
    //   FetchData(
    //     REQUEST_TYPE.GET,
    //     SERVICE_ENDPOINTS.ProductAttribute_GetAssignedCustomizationAttributesByProductId +
    //       _state.Product.ProductID,
    //     null,
    //     this.successGetAssignedAttributesByProductId,
    //   );
    // }
  };

  successGetAssignedAttributesByProductId = (resp) => {
    let _state = this.props.parentState;
    let res = _state.listAllProductAttributePairs; //added
    this.props.setValuesMany(
      {
        listProductAttributePairs: resp,
        listAllProductAttributePairs: res,
      },
      () => {
        this.consolidateAttributeValues(res);
      },
    );
  };

  fetchAllAttributes = () => {
    let _state = this.props.parentState;
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.ProductAttribute_GetAllAttributesByProductId +
      _state.Product.ProductID,
      null,
      this.successGetAllAttributesByProductId,
    );
  };

  consolidateAttributeValues = (res) => {
    let _res =
      res && res.length > 0
        ? res.filter((obj, i) => obj.IsAssigned == false)
        : [];
    if (_res /*&& _res.length >0*/) {
      let lstUniqueAttributes = [
        ...new Map(
          _res.map((item) => [item[enPARENT.AttributeID], item]),
        ).values(),
      ];
      this.setState({
        listAttribute: lstUniqueAttributes,
        listAttributeValues: [],
        Attribute: '',
        AttributeValue: '',
      });
    }
  };

  handleChange = (e) => {
    this.setState(
      {
        [e.target.name]: e.target.value,
      },
      () => {
        if (e.target.name == enPARENT.Attribute) {
          let filteredList = this.props.parentState.listAllProductAttributePairs.filter(
            (a) => a.AttributeID == e.target.value,
          );
          for (let item of this.props.parentState.listProductAttributePairs) {
            filteredList = filteredList.filter(
              (a) =>
                !(
                  a.AttributeValue == item.AttributeValue &&
                  a.AttributeName == item.AttributeName
                ),
            );
          }
          this.setState({
            listAttributeValues: filteredList,
          });
        }
      },
    );
  };

  handleIsSelectedForVariation = (e, item) => {
    let _state = this.props.parentState;
    item.IsSelectedForVariation = e.target.checked;
    item.InvalidClass = '';
    if (item.IsSelectedForVariation == false) {
      item.VariationInPrice = '';
      item.VariationInPriceUC = '0';
      item.editablePrice = false;
    } else {
      item.editablePrice = true;
    }
    this.props.setValues(
      enPARENT.listProductAttributePairs,
      _state.listProductAttributePairs,
      () => {
        this.EditAttribute(item);
      },
    );
  };

  handleVariationInPrice = (e, item) => {
    let _state = this.props.parentState;
    item.VariationInPriceUC = e.target.value;
    item.VariationInPrice = e.target.value;
    this.props.setValues(
      enPARENT.listProductAttributePairs,
      _state.listProductAttributePairs,
    );
  };

  successAddAttribute = (res) => {
    let _state = this.props.parentState;
    let _item = _state.listAllProductAttributePairs.find(
      (a) =>
        a.AttributeID == this.state.Attribute &&
        a.AttributeValue == this.state.AttributeValue,
    );

    if (res) {
      _item.IsAssigned = true;
      _state.listProductAttributePairs.push(JSON.parse(JSON.stringify(_item)));
      this.props.setValuesMany(
        {
          listAllProductAttributePairs: _state.listAllProductAttributePairs,
          listProductAttributePairs: _state.listProductAttributePairs,
        },
        () => {
          this.consolidateAttributeValues(_state.listAllProductAttributePairs);
          this.setState({
            Attribute: '',
            AttributeValue: '',
          });
        },
      );
    }
  };

  AddAttribute = () => {
    if (this.state.Attribute && this.state.Attribute != '') {
      if (this.state.AttributeValue && this.state.AttributeValue != '') {
        //AddAttributeNow
        //after addAttribute Callback,
        let _state = this.props.parentState;
        let _item = _state.listAllProductAttributePairs.find(
          (a) =>
            a.AttributeID == this.state.Attribute &&
            a.AttributeValue == this.state.AttributeValue,
        );
        let reqObj = JSON.parse(JSON.stringify(_item));
        reqObj.IsAssigned = true;
        reqObj.RequestedByProfileId = _state.Product.RequestedByProfileId;

        FetchData(
          REQUEST_TYPE.POST,
          SERVICE_ENDPOINTS.ProductAttribute_UpdateIsAssigned,
          reqObj,
          this.successAddAttribute,
        );
      }
    }
  };

  successDeleteAttribute = (res) => {
    let item = this.attrItem;
    let _state = this.props.parentState;
    let _item = _state.listAllProductAttributePairs.find(
      (a) =>
        a.AttributeID == item.AttributeID &&
        a.AttributeValue == item.AttributeValue,
    );

    if (res) {
      _item.IsAssigned = false;
      _state.listProductAttributePairs = _state.listProductAttributePairs.filter(
        (a) =>
          !(
            a.AttributeID == item.AttributeID &&
            a.AttributeValue == item.AttributeValue
          ),
      );
      this.props.setValuesMany(
        {
          listAllProductAttributePairs: _state.listAllProductAttributePairs,
          listProductAttributePairs: _state.listProductAttributePairs,
        },
        () => {
          this.consolidateAttributeValues(_state.listAllProductAttributePairs);
        },
      );
    }
  };

  DeleteAttribute = (item) => {
    //after DeleteAttribute Callback
    this.attrItem = item;
    let _state = this.props.parentState;
    let _item = _state.listAllProductAttributePairs.find(
      (a) =>
        a.AttributeID == item.AttributeID &&
        a.AttributeValue == item.AttributeValue,
    );

    let reqObj = JSON.parse(JSON.stringify(_item));
    reqObj.IsAssigned = false;
    reqObj.RequestedByProfileId = _state.Product.RequestedByProfileId;

    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.ProductAttribute_UpdateIsAssigned,
      reqObj,
      this.successDeleteAttribute,
    );
  };

  successEditAttribute = (res) => {
    let item = this.attrItem;
    let _state = this.props.parentState;

    if (res) {
      item.VariationInPrice = item.VariationInPriceUC;
      item.editablePrice = false;
      this.props.setValues(
        enPARENT.listProductAttributePairs,
        _state.listProductAttributePairs,
      );
    }
  };

  EditAttribute = (item) => {
    this.attrItem = item;
    let _state = this.props.parentState;
    if (!(item.VariationInPriceUC && item.VariationInPriceUC != '')) {
      item.InvalidClass = 'custom-input-invalid';
      this.props.setValues(
        enPARENT.listProductAttributePairs,
        _state.listProductAttributePairs,
      );
      return;
    }
    
    let reqObj = JSON.parse(JSON.stringify(item));
    reqObj.RequestedByProfileId = _state.Product.RequestedByProfileId;
    reqObj.VariationInPrice = reqObj.VariationInPrice;
    FetchData(
      REQUEST_TYPE.POST,
      SERVICE_ENDPOINTS.ProductAttribute_UpdateIsAssigned,
      reqObj,
      this.successEditAttribute,
    );
  };
  OpenModalFunc() {
    this.setState({ requestAttributeModal: true });
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Supplier_GetCategoryAttributeRequestBySupplierId +
      getStorageItem(SUPPLIER_ID),
      null,
      this.successGetCategoryAttributeRequest,
    );
  }
  successGetCategoryAttributeRequest = (res) => {
    if (res) {
      this.setState({
        RequestingAttrData: res,
        RequestingAttribute: res.AttributeRequests,
      });
    }
  };
  RequestNewAttribute = () => {
    let reqObj = {
      AttributeRequests: this.state.RequestingAttribute,
      SupplierID: getStorageItem(SUPPLIER_ID),
      RequestedByProfileId: getStorageItem(PROFILE_ID),
      CreatedBy: this.state.RequestingAttrData.CreatedBy,
      ModifiedOn: this.state.RequestingAttrData.ModifiedOn,
      ModifiedBy: this.state.RequestingAttrData.ModifiedBy,
    };
    if (this.state.RequestingAttribute) {
      FetchData(
        REQUEST_TYPE.POST,
        SERVICE_ENDPOINTS.Supplier_UpdateSupplierAttributeRequests,
        reqObj,
        this.successOnSave,
      );
    }
  };
  successOnSave = (res) => {
    if (res) {
      this.setState({ requestAttributeModal: false }, () => {
        izitoast.destroy();
        izitoast.show({

          title: '',
          icon: APP_ICONS.SUCCESS,
          message: 'Requested Successfully',
          ////position: APP_TOAST_POSITION.BOTTOM_CENTER,
          target: '.testtarget',
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
        message: 'Error',
        //position: APP_TOAST_POSITION.BOTTOM_CENTER,
        target: '.testtarget',
        color: COLOR.RED,
        messageSize: SIZE.FONT_SIZE
      });
    }
  };
  /*handleChange=(e)=>{
        this.setState(
            {
              [e.target.name] : e.target.value
            })
    }*/

  render() {
    let _state = this.props.parentState;
    return (
      <div className="body">
        <div className="row">
          <div
            style={{
              fontWeight: '500',
              marginBottom: '5px',
              textAlign: 'center',
            }}
            className="container if-pas"
          >
            If you do not need any attributes, then please skip this step and
            tap "Save & Continue"
            <button
              className="custom-requestbtn cursorpointer"
              onClick={() => {
                this.OpenModalFunc();
              }}
            >
              Request Attribute
            </button>
          </div>

          <div className="col-sm-12 npad">
            <div className="row justify-content-center">
              <div className="col-md-4">
                <div className="form-group">
                  <label>Attributes</label>
                  <div className="select-custom">
                    <select
                      defaultValue=""
                      value={this.state.Attribute}
                      className="form-control"
                      name="Attribute"
                      onChange={this.handleChange}
                    >
                      <option value="">Select Attribute</option>
                      {this.state.listAttribute &&
                        this.state.listAttribute.length > 0 ? (
                        this.state.listAttribute.map((opt, i) => (
                          <option key={i} value={opt.AttributeID}>
                            {opt.AttributeName}
                          </option>
                        ))
                      ) : (
                        <></>
                      )}
                    </select>
                  </div>
                  {/* End .select-custom */}
                </div>
              </div>
              {/*End Form Col-1*/}
              <div className="col-md-4">
                <div className="form-group">
                  <label>Attribute Value</label>
                  <div className="select-custom">
                    <select
                      defaultValue=""
                      value={this.state.AttributeValue}
                      className="form-control"
                      name="AttributeValue"
                      onChange={this.handleChange}
                    >
                      <option value="">Select Attribute Value</option>
                      {this.state.listAttributeValues &&
                        this.state.listAttributeValues.length > 0 ? (
                        this.state.listAttributeValues.map((opt, i) => (
                          <option key={i} value={opt.AttributeValue}>
                            {opt.AttributeValue}
                          </option>
                        ))
                      ) : (
                        <></>
                      )}
                    </select>
                  </div>
                  {/* End .select-custom */}
                </div>
              </div>
              {/*End Form Col-2*/}
              <div className="col-md-4 att-btn-col epadi">
                <button
                  type="button"
                  className="btn btn-outline-dark custom-btn prebtn"
                  onClick={this.AddAttribute}
                >
                  Add Attribute
                </button>
              </div>
              {/*End Form Col-3*/}
            </div>
            <br />
            <div className="row">
              <div className="col-sm-12">
                {_state.listProductAttributePairs &&
                  _state.listProductAttributePairs.length > 0 ? (
                  <h4 className="text-left mb-4 d-inline-block pl-6">
                    Selected Attributes
                  </h4>
                ) : (
                  <h2 className="text-left mb-4 d-inline-block pl-6">
                    It seems you don't have any attribute attached to your
                    product...
                  </h2>
                )}
                {_state.listProductAttributePairs &&
                  _state.listProductAttributePairs.length > 0 ? (
                  <div>
                    <table className="table table-hover text-center">
                      <thead className="thead-light">
                        <tr>
                          <th scope="col">#</th>
                          <th scope="col">Attribute Name</th>
                          <th scope="col">Type</th>
                          <th scope="col">Value</th>
                          <th scope="col">Price Adjusment</th>
                          <th scope="col">Action</th>
                        </tr>
                      </thead>
                      <tbody>
                        {_state.listProductAttributePairs.map((item, i) => (
                          <tr key={i}>
                            <th scope="row">{i + 1}</th>
                            <td>{item.AttributeName}</td>
                            <td><h4><span className={(item.AttributeTypeID == 1) ? "badge badge-success mt-1" : "badge badge-info mt-1"}>{(enAttributeType[item.AttributeTypeID])}</span></h4></td>
                            <td>{item.AttributeValue}</td>
                            <>
                              {
                                (item.AttributeTypeID == 1) ?
                                  <td>
                                    <button
                                      type="button"
                                      className="btn btn-outline-dark custom-btn prebtn"
                                      id={'check' + i}
                                      onClick={(e) => {
                                        item.editablePrice = true;
                                        item.IsSelectedForVariation = true;
                                        this.props.setValues(
                                          enPARENT.listProductAttributePairs,
                                          _state.listProductAttributePairs,
                                        );
                                        this.stateitem=item;
                                        this.setState({
                                          adjustmentModal: true,
                                        })
                                      }}
                                    >
                                      Adjustment  
                                    </button>
                                    <span className="checkbox-custom circular" />

                                  </td>
                                  : <td></td>
                              }
                            </>
                            {/* <>
                              {
                                (item.AttributeTypeID == 1) ?
                                  <td
                                    style={{ textAlign: '-webkit-center' }}
                                    onDoubleClick={(e) => {
                                      console.log('Double clicked')
                                      item.editablePrice = true;
                                      item.IsSelectedForVariation = true;
                                      this.props.setValues(
                                        enPARENT.listProductAttributePairs,
                                        _state.listProductAttributePairs,
                                      );
                                      console.log('Hassan here', _state.listProductAttributePairs)
                                    }}
                                  >
                                    {item.editablePrice ? (
                                      <input
                                        value={item.VariationInPriceUC}
                                        style={{ width: '50%' }}
                                        autoFocus
                                        type="number"
                                        min="0"
                                        className={
                                          'form-control ' + item.InvalidClass
                                        }
                                        onChange={(e) => {
                                          this.handleVariationInPrice(e, item);
                                        }}
                                      />
                                    ) : (
                                      <span>
                                        {item.VariationInPrice &&
                                          item.VariationInPrice != 0
                                          ? item.VariationInPrice
                                          : ''}
                                      </span>
                                    )}
                                  </td>
                                  : <td></td>
                              }
                            </> */}
                            <td>
                              {/* {item.editablePrice ? (
                                <span
                                  onClick={() => {
                                    this.EditAttribute(item);
                                  }}
                                  style={{
                                    fontSize: '20px',
                                    margin: '5px',
                                    color: '#cddc39',
                                    cursor: 'pointer',
                                  }}
                                >
                                  <i className="fa fa-check-circle" />
                                </span>
                              ) : (
                                <></>
                              )} */}
                              <span
                                onClick={() => {
                                  this.DeleteAttribute(item);
                                }}
                                style={{
                                  fontSize: '20px',
                                  margin: '5px',
                                  color: '#f44336',
                                  cursor: 'pointer',
                                }}
                              >
                                <i className="fa fa-times-circle" />
                              </span>
                            </td>
                          </tr>
                        ))}
                      </tbody>
                    </table>
                    <ul>
                      <li>
                        Price adjustment will add/subtract the amount to/from the base price of the product (that you will define in next step of Pricing).
                      </li><li>
                        Price adjustment can be positive, negative, or even zero(default).
                      </li>
                    </ul>
                  </div>

                ) : (
                  <></>
                )}
              </div>
            </div>
          </div>
          {/* End .row */}
        </div>
        <Modal
          isOpen={this.state.requestAttributeModal}
          onRequestClose={() => {
            return this.state.requestAttributeModal;
          }}
          className="modal-content"
        >
          <div className="modal-header">
            <h4 class="modal-title">Request For New Attribute</h4>
            <label
              className="close"
              data-dismiss="modal"
              onClick={(e) => {
                this.setState({
                  requestAttributeModal: false,
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
                  <label>Requesting Attribute Name </label>
                  <textarea
                    style={{ minHeight: '150px' }}
                    type="text"
                    className="form-control"
                    required
                    name="RequestingAttribute"
                    value={this.state.RequestingAttribute}
                    required
                    onChange={(e) => {
                      this.handleChange(e);
                    }}
                  />
                </div>
                <div className="checkout-steps-action">
                  <a
                    href="#"
                    className="btn btn-block btn-outline-secondary"
                    onClick={(e) => {
                      this.RequestNewAttribute();
                    }}
                  >
                    Request
                  </a>
                </div>
              </form>
            </div>
          </div>
        </Modal>
        <Modal
          isOpen={this.state.adjustmentModal}
          onRequestClose={() => {
            return this.state.adjustmentModal;
          }}
          className="modal-content"
        >
          <div className="modal-header">
            <h4 class="modal-title">Price Adjustment</h4>
            <label
              className="close"
              data-dismiss="modal"
              onClick={(e) => {
                this.setState({
                  adjustmentModal: false,
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
                  <label>Price Adjustment</label>
                  <input
                    value={this.stateitem.VariationInPrice}
                    style={{ width: '50%' }}
                    type="number"
                    min="0"
                    className={
                      'form-control '
                    }
                    onChange={(e) => {
                      this.handleVariationInPrice(e, this.stateitem);
                    }}
                  />
                </div>
                <div className="checkout-steps-action">
                  <a
                    href="#"
                    className="btn btn-block btn-outline-secondary"
                    onClick={() => {
                      this.EditAttribute(this.stateitem);
                      this.setState({
                        adjustmentModal: false,
                      });
                      console.log("Price Adjustment Done")
                    }}
                  >
                    Ok
                  </a>
                </div>
              </form>
            </div>
          </div>
        </Modal>

      </div>

      // <div className="container bg-light">
      //     <h2 className="text-center mb-4 pt-5">Product Attributes</h2>
      //     <div className="row">
      //         <div className="col col-sm-8 col-md-12 mx-auto">

      //             <div className="container">
      //             <div className="row justify-content-center">
      //                 <div className="col-md-4">
      //                 <div className="form-group">
      //                     <label><strong>Attributes</strong></label>
      //                     <div className="select-custom">
      //                     <select defaultValue="" value={this.state.Attribute} className="form-control" name="Attribute" onChange={this.handleChange}>
      //                         <option value="" >Select Attribute</option>
      //                         {
      //                             (this.state.listAttribute && this.state.listAttribute.length >0)?
      //                             this.state.listAttribute.map((opt,i)=>
      //                                 <option key={i} value={opt.AttributeID}>{opt.AttributeName}</option>
      //                             )
      //                             :<></>
      //                         }
      //                     </select>
      //                     </div>{/* End .select-custom */}
      //                 </div>
      //                 </div>{/*End Form Col-1*/}
      //                 <div className="col-md-4">
      //                 <div className="form-group">
      //                     <label><strong>Attribute Value</strong></label>
      //                     <div className="select-custom">
      //                     <select defaultValue="" value={this.state.AttributeValue} className="form-control" name="AttributeValue" onChange={this.handleChange}>
      //                         <option value=""  >Select Attribute Value</option>
      //                         {
      //                             (this.state.listAttributeValues && this.state.listAttributeValues.length >0)?
      //                             this.state.listAttributeValues.map((opt,i)=>
      //                         <option key={i} value={opt.AttributeValue}>{opt.AttributeValue}</option>
      //                             )
      //                             :<></>
      //                         }
      //                     </select>
      //                     </div>{/* End .select-custom */}
      //                 </div>
      //                 </div>{/*End Form Col-2*/}
      //                 <div className="col-md-3 att-btn-col">
      //                 <button className="form-control btn btn-dark" style={{marginTop:'20px'}} onClick={this.AddAttribute}>Add Attribute</button>
      //                 </div>{/*End Form Col-3*/}
      //             </div>{/*End Form Row-1*/}
      //             <hr style={{paddingBottom:'20px'}} />
      //             </div>{/*End Form Container*/}

      //         </div>{/*End Col*/}
      //     </div>{/*End Row*/}
      //     <div className="row">
      //         <div className="col col-sm-8 col-md-12 mx-auto">
      //             <div className="container">
      //                 <div className="row justify-content-center">
      //                     <div className="col-lg-11">
      //                         {
      //                             (_state.listProductAttributePairs && _state.listProductAttributePairs.length > 0)?
      //                             <h4 className="text-left mb-4 d-inline-block pl-6">Selected Attributes</h4>
      //                             :
      //                             <h2 className="text-left mb-4 d-inline-block pl-6">
      //                                 It seems you donot have any attribute attached to your product...
      //                             </h2>
      //                         }
      //                     </div>
      //                 </div>
      //                 {
      //                 (_state.listProductAttributePairs && _state.listProductAttributePairs.length > 0)?
      //                 <div className="row justify-content-center">
      //                     <div className="col table-col">
      //                     <table className="table table-hover text-center">
      //                         <thead className="thead-light">
      //                         <tr>
      //                             <th scope="col">#</th>
      //                             <th scope="col">Attribute Name</th>
      //                             <th scope="col">Value</th>
      //                             <th scope="col">Price Adjusment Required?</th>
      //                             <th scope="col">Price Adjusment</th>
      //                             <th scope="col">Action</th>
      //                         </tr>
      //                         </thead>
      //                         <tbody>
      //                         {
      //                          _state.listProductAttributePairs.map((item,i)=>
      //                          <tr key={i}>
      //                             <th scope="row">{i+1}</th>
      //                             <td>{item.AttributeName}</td>
      //                             <td>{item.AttributeValue}</td>
      //                             <td>
      //                             <label className="checkbox-label form-check-label" htmlFor={"check"+i}>
      //                                 <input checked={item.IsSelectedForVariation} type="checkbox" id={"check"+i} className="form-check-input" onChange={(e)=>{this.handleIsSelectedForVariation(e,item)}} />
      //                                 <span className="checkbox-custom circular" />
      //                             </label>
      //                             </td>
      //                             <td style={{textAlign : '-webkit-center'}} onDoubleClick={
      //                                         (e)=>{
      //                                             item.editablePrice = true;
      //                                             item.IsSelectedForVariation = true;
      //                                             this.props.setValues(enPARENT.listProductAttributePairs, _state.listProductAttributePairs)
      //                                         }
      //                                     }>
      //                                 {
      //                                     (item.editablePrice)?
      //                                         <input value={item.VariationInPriceUC} style={{width:'50%'}} autoFocus type="number" className={"form-control " + item.InvalidClass} onChange={(e)=>{this.handleVariationInPrice(e,item)}} />
      //                                         :
      //                                     <span>
      //                                     {
      //                                         (item.VariationInPrice && item.VariationInPrice != 0)? item.VariationInPrice : ""
      //                                     }
      //                                     </span>

      //                                 }
      //                             </td>
      //                             <td>
      //                                 {
      //                                     (item.editablePrice)?
      //                                         <span onClick={()=>{this.EditAttribute(item)}} style={{fontSize:'20px', margin:'5px', color : '#cddc39', cursor:'pointer'}}>
      //                                             <i className="fa fa-check-circle" />
      //                                         </span>
      //                                         :<></>
      //                                 }
      //                                 <span onClick={()=>{this.DeleteAttribute(item)}} style={{fontSize:'20px', margin:'5px', color : '#f44336', cursor:'pointer'}}>
      //                                     <i className="fa fa-times-circle" />
      //                                 </span>
      //                             </td>
      //                         </tr>
      //                          )
      //                         }
      //                         </tbody>
      //                     </table>
      //                     </div>
      //                 </div>
      //                 :<></>
      //                 }
      //             </div>
      //         </div>
      //     </div>
      // </div>
    );
  }
}

export default ProductAttributes;