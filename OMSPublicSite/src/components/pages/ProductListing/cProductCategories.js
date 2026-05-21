import React from 'react';
import SearchSelect from '../../customControls/SearchSelect/SearchSelect';
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
import { Helmet } from 'react-helmet';
import { getStorageItem } from '../../../utils/storageHelper';
import Modal from 'react-modal';
import izitoast from 'izitoast';
import moment from 'moment';

const enPARENT = {
  listCategories: 'listCategories',
};

class ProductCategories extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      requestCategoryModal: false,
      RequestingCategory: '',
      RequestingCatData: {},
      UserProfile: getStorageItem(PROFILE_ID),
    };
  }

  componentDidMount() {
    window.scrollTo(0, 0);
    if (
      !(
        this.props.parentState.listCategories &&
        this.props.parentState.listCategories.length > 0
      )
    ) {
      //fetch categories
      this.fetchCategories();
    }
  }

  componentDidUpdate() {}

  renderItemSearch = (obj, i, _selectedItem) => {
    return (
      <li
        className="category-result"
        style={{ listStyle: 'none', padding: '5px', paddingLeft: '10px' }}
        onClick={() => {
          _selectedItem(obj);
        }}
      >
        <div>
          <span>Searched Query</span> {'in ' + obj.CategoryTitle}{' '}
        </div>
        <ul
          className="custom-breadcrumbs"
          style={{ display: 'flex', width: '100%' }}
        >
          {obj.ParentsList.map((item, j) => {
            if (j == obj.ParentsList.length - 1) {
              //last item
              return (
                <li key={j} className="custom-breadcrumb">
                  {item.CategoryTitle}
                </li>
              );
            } else {
              return (
                <li key={j} className="custom-breadcrumb">
                  {item.CategoryTitle}
                  <i class="fa fa-angle-right" aria-hidden="true"></i>
                </li>
              );
            }
          })}
        </ul>
      </li>
    );
  };

  selectedItemSearch = (obj) => {
    this.props.setValuesMany({
      selectedCategory: obj,
      previousCategories: null,
    });
  };

  hookSearchTyping = () => {};

  successGetCategories = (res) => {
    for (let item of res) {
      item.ParentsList = [];
      item.ParentsList = this.getParentsList(item.ParentCategoryID, res);
    }
    this.props.setValues(enPARENT.listCategories, res);
  };

  fetchCategories = () => {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Category_GetCategoryListLookup,
      null,
      this.successGetCategories,
    );
  };

  getParentsList = (categoryId, list) => {
    let parent = list.find((a) => a.CategoryID == categoryId);
    if (parent) {
      if (parent.ParentCategoryID) {
        return [...this.getParentsList(parent.ParentCategoryID, list), parent];
      } else {
        //base condition
        let temp = new Array();
        temp.push(parent);
        return temp;
      }
    } else {
      return [];
    }
  };
  OpenModalFunc() {
    this.setState({ requestCategoryModal: true });
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
        RequestingCatData: res,
        RequestingCategory: res.CategoryRequests,
      });
    }
  };
  RequestNewCateogry = () => {
    let reqObj = {
      CategoryRequests: this.state.RequestingCategory,
      SupplierID: getStorageItem(SUPPLIER_ID),
      RequestedByProfileId: getStorageItem(PROFILE_ID),
      CreatedBy: this.state.RequestingCatData.CreatedBy,
      ModifiedOn: this.state.RequestingCatData.ModifiedOn,
      ModifiedBy: this.state.RequestingCatData.ModifiedBy,
    };
    if (this.state.RequestingCategory) {
      FetchData(
        REQUEST_TYPE.POST,
        SERVICE_ENDPOINTS.Supplier_UpdateSupplierCategoryRequests,
        reqObj,
        this.successOnSave,
      );
    }
  };
  successOnSave = (res) => {
    if (res) {
      this.setState({ requestCategoryModal: false }, () => {
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
  handleChange = (e) => {
    this.setState({
      [e.target.name]: e.target.value,
    });
  };

  render() {
    return (
      <div className="col-sm-12 npad">
        {/* <h2 className="text-center mb-4 pt-5">Add Product Categories</h2> */}
        <div className="">
          <div className="">
            <div className="form-group">
              <label htmlFor="product-title">
                <strong>Categories</strong>
              </label>
              <button
                className="custom-requestbtn cursorpointer"
                onClick={() => {
                  this.OpenModalFunc();
                }}
              >
                Request Category
              </button>
              <SearchSelect
                list={this.props.parentState.listCategories}
                placeholder={'Type to search categories'}
                disabled={false}
                filter={['CategoryTitle']}
                sKey="ProductCategories"
                CharacterCount={1 /*min character to start search*/}
                displayHook={this.renderItemSearch /*Can be customized*/}
                selectHook={this.selectedItemSearch}
                hookInputTyping={this.hookSearchTyping}
              />
            </div>
            {/*Form Group Input*/}
            <div className="form-group">
              <label htmlFor="description" className="mb-2">
                <strong>Selected-Categories</strong>
                <br />
                <span style={{color: "blue"}}>To remove selected Category, simply select a new one. It will remove previously selected categories and select new one.</span>
              </label>
              <div className="form-group-row">
                {this.props.parentState.selectedCategory ? (
                  this.props.parentState.selectedCategory.ParentsList &&
                  this.props.parentState.selectedCategory.ParentsList.length >
                    0 ? (
                    <div>
                      {this.props.parentState.selectedCategory.ParentsList.map(
                        (item, i) => (
                          <button
                            key={i}
                            style={{ margin: '5px' }}
                            className="btn tag-btn mb-one"
                            disabled
                          >
                            {item.CategoryTitle}
                          </button>
                        ),
                      )}
                      <button
                        style={{ margin: '5px' }}
                        className="btn tag-btn mb-one"
                        disabled
                      >
                        {this.props.parentState.selectedCategory.CategoryTitle}
                      </button>
                    </div>
                  ) : (
                    <button
                      style={{ margin: '5px' }}
                      className="btn tag-btn mb-one"
                      disabled
                    >
                      {this.props.parentState.selectedCategory.CategoryTitle}
                    </button>
                  )
                ) : (
                  <div></div>
                )}
                {this.props.parentState.previousCategories &&
                this.props.parentState.previousCategories.length > 0 ? (
                  <div>
                    {this.props.parentState.previousCategories.map(
                      (item, i) => (
                        <button
                          key={i}
                          style={{ margin: '5px' }}
                          className="btn tag-btn mb-one"
                          disabled
                        >
                          {item.CategoryTitle}
                        </button>
                      ),
                    )}
                  </div>
                ) : (
                  <></>
                )}
              </div>
            </div>
          </div>
        </div>
        <Modal
          isOpen={this.state.requestCategoryModal}
          onRequestClose={() => {
            return this.state.requestCategoryModal;
          }}
          className="modal-content"
        >
          <div className="modal-header">
            <h4 class="modal-title">Request For New Category</h4>
            <label
              className="close"
              data-dismiss="modal"
              onClick={(e) => {
                this.setState(
                  {
                    requestCategoryModal: false,
                  },
                  () => {},
                );
              }}
            >
              <i class="fa fa-times" aria-hidden="true"></i>
            </label>
          </div>
          <div className="modal-body">
            <div className="row address_managmentrow">
              <form className="col-lg-12">
                <div className="form-group">
                  <label>Requesting Category Name </label>
                  <textarea
                    type="text"
                    style={{ minHeight: '150px' }}
                    className="form-control"
                    required
                    name="RequestingCategory"
                    value={this.state.RequestingCategory}
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
                      this.RequestNewCateogry();
                    }}
                  >
                    Request
                  </a>
                </div>
              </form>
            </div>
          </div>
        </Modal>
      </div>
    );
  }
}

export default ProductCategories;
