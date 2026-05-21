import React from 'react';
import { Redirect } from 'react-router';
import { REQUEST_TYPE, SERVICE_ENDPOINTS } from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';

const enPARENT = {
  Product: 'Product',
};

class ProductInfo extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      productList: [],
      tagList: this.props.parentState.Product.BrifeDescription
        ? this.props.parentState.Product.BrifeDescription.split(',')
        : [],
    };
  }

  successGetProductTypeList = (res) => {
    let resData;
    if (res) {
      resData = res;
    } else {
      console.log('Error');
    }
    this.setState(
      {
        productList: resData,
      },
      () => {},
    );
  };

  componentDidMount() {
    window.scrollTo(0, 0);
    this.initMount();
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.ProductType_GetList,
      null,
      this.successGetProductTypeList,
    );
  }

  initMount = () => {};

  handleTextboxChange = (e) => {
    let _state = this.props.parentState.Product;
    _state[e.target.name] = e.target.value;
    this.props.setValues(enPARENT.Product, _state);
  };

  handleTagsOnChange = () => {};

  handleRadioChange = (e) => {
    let _state = this.props.parentState.Product;
    _state.ProductTypeID = e.target.getAttribute('value');
    this.props.setValues(enPARENT.Product, _state);
  };
  handleChange = (e) => {};
  handlePressEnter = (e) => {
    if (e.keyCode === 13) {
      let notExists = this.state.tagList.find((a) => a == e.target.value);
      let _state = this.props.parentState.Product;
      if (!notExists) {
        this.setState(
          {
            tagList: [...this.state.tagList, e.target.value],
          },
          () => {
            _state[e.target.name] = this.state.tagList.toString();
            this.props.setValues(enPARENT.Product, _state);
            e.target.value = '';
          },
        );
      } else {
        e.target.value = '';
      }
    }
  };
  removeTagElement = (e, tagValue) => {
    let _tagList = this.state.tagList.filter((a) => a != tagValue);
    let _state = this.props.parentState.Product;
    this.setState(
      {
        tagList: _tagList,
      },
      () => {
        _state.BrifeDescription = this.state.tagList.toString();
        this.props.setValues(enPARENT.Product, _state);
      },
    );
  };
  render() {
    let _state = this.props.parentState.Product;
    let arrBriefTags = this.state.tagList;
    let productList = [];
    for (var i = 0; i < this.state.productList.length; i++) {
      productList.push(
        <li key={i}>
          <input
            type="checkbox"
            name={this.state.productList[i].ProductTypeID}
            id={'chkbox' + this.state.productList[i].ProductTypeID}
            // defaultValue={this.state.productList[i].ProductTypeID}
            checked={
              _state.ProductTypeID == this.state.productList[i].ProductTypeID
                ? true
                : false
            }
            onChange={this.handleChange}
          />
          <label
            htmlFor={'chkbox' + this.state.productList[i].ProductTypeID}
            value={this.state.productList[i].ProductTypeID}
            onClick={this.handleRadioChange}
          >
            {this.state.productList[i].ProductTypeTitle}
          </label>
        </li>,
      );
      // productList.push(
      // <div key={i} className="col-sm-12 col radio-box" onChange={this.handleRadioChange}>
      //     <div className="form-check form-check-inline">
      //     <input
      //     className="form-check-input"
      //     type="radio"
      //     name="product-type"
      //     defaultValue={this.state.productList[i].ProductTypeID}
      //     checked = {(_state.ProductTypeID == this.state.productList[i].ProductTypeID)? true : false}
      //     onChange={this.handleChange}
      //     />
      //     <label className="form-check-label" htmlFor="inlineRadio1">{this.state.productList[i].ProductTypeTitle}</label>
      //     </div>
      // </div>);
    }
    return (
      <div className="body">
        <div className="row">
          <div className="col-sm-12 npad pro-las-info">

            {this.props.parentState.Product.ProductID ?
              <>
                <div>
                  <button
                    className=" custombtn-deleteproduct cursorpointer"
                    data-toggle="modal"
                    style={{ float: 'right' }}
                    data-target="#deleteProductModal"
                  >
                    {' '}
                    Inactivate Product
                  </button>
                </div>
                <br />
                <br />
                <div>
                <span style={{ color: 'red', float: 'right' }}> (To reactivate a product in Marketplace, please submit your request in Contact Us.)</span>
                </div>
              </> : ""}
            <label aria-required>
              Product Title <span style={{ color: 'red' }}>*</span>
            </label>
            

            <input
              type="text"
              maxLength="200"
              className="form-control"
              name="ProductTitle"
              aria-describedby="product-title"
              placeholder="Enter Product Title"
              value={_state.ProductTitle}
              onChange={this.handleTextboxChange}
            />
            <label
               
            >Product Type <span style={{ color: 'red' }}>*</span></label>
            <ul className="ks-cboxtags">{productList}</ul>
            <label>
              Product Description <span style={{ color: 'red' }}>*</span>
            </label>
            <textarea
              className="form-control"
              name="Description"
              value={_state.Description}
              rows={2}
              onChange={this.handleTextboxChange}
            />
            <label>
              Tags/ keywords <span style={{ color: 'red' }}>*</span>
            </label>
            <label>
              <span style={{ color: 'red' }}>Use ENTER key after input of each tag/keyword. Tags will appear below the input field as small black boxes.</span>
            </label>
            <input
              className="form-control"
              name="BrifeDescription"
              rows={2}
              onChange={() => {}}
              onKeyDown={this.handlePressEnter}
            />
            {(() => {
              if (arrBriefTags) {
                let item = [];
                for (let i = 0; i < arrBriefTags.length; i++) {
                  item.push(
                    <span className="selectivity-item">
                      <i
                        class="fa fa-times"
                        onClick={(e) => {
                          this.removeTagElement(e, arrBriefTags[i]);
                        }}
                      ></i>
                      {arrBriefTags[i]}
                    </span>,
                  );
                }
                return item;
              }
            })()}
          </div>
        </div>
        {/* End .row */}
        <div
          className="modal fade"
          id="deleteProductModal"
          tabIndex={-1}
          role="dialog"
          aria-labelledby="deleteProductModal"
        >
          <div className="modal-dialog custom-modalpostion" role="document">
            <div className="modal-content custom-deleteshopmodalsize">
              <div className="modal-body add-cart-box  custom-deleteshopmodalsize text-center">
                <p>
                  Do you really want to delete this product
                  <br />
                </p>
                <div className="btn-actions">
                  <a href="#">
                    <button
                      className="btn btn-dark"
                      style={{ padding: '8px' }}
                      data-dismiss="modal"
                      onClick={() => {
                        this.props.inactiveProduct();
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
      </div>
    );
  }
}

export default ProductInfo;
