import React from 'react';
import { FetchData, baseUrlImage } from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SUPPLIER_ID,
  PRODUCT_ID,
} from '../../../utils/constants';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';
import { ImageEntityEnum, ProductnShopStatus } from '../../../utils/enums';
import { Helmet } from 'react-helmet';

const enPARENT = {
  DELIVERY: 'Delivery',
};

class ShopProducts extends React.Component {
  constructor(props) {
    super(props);
    this.myRef = React.createRef();
    this.state = {
      isOpenActive: false,
      isOpenNew: false,
      isOpenInactive: false,

      productStatus: '1',
    };
  }

  componentDidMount() {}
  EditProduct = (item) => {
    setStorageItem(PRODUCT_ID, item.ProductID);
    window.location.href = '/productlisting';
  };
  toggle = (e) => {
    let name = this.state[e.target.name];
    if (name) {
      this.setState({ [e.target.name]: false });
    } else {
      document
        .getElementById(e.target.name)
        .scrollIntoView({ behavior: 'smooth' });
      this.setState({ [e.target.name]: true });
    }
  };

  render() {
    let products = this.props.parentState.Products;
    return (
      <>
        <Helmet>
          <link rel="stylesheet" href="assets/css/customshopcss.css" />
        </Helmet>
        
        <div className="mainsliwrapper">
          <div className="heading ins">
            <div className="row">
              <div className="col-md-12 col-sm-12">
                <span style={{color:"red"}}>You can add products to your shop but they will not be available in the marketplace unless shop and products are all approved</span>
                <h2 className="title">Add New Products/Services</h2>
              </div>
            </div>
          </div>
          <div className="col-sm-12 npad inner-add-pro">
            <ul className="ks-cboxtags cbox-for-mob">
              <li>
                <input
                  type="checkbox"
                  name={'NewProducts'}
                  id={'chkboxNewProducts'}
                  checked={this.state.productStatus == '1' ? true : false}
                  onChange={(e) => {
                    this.setState({ productStatus: '1' });
                  }}
                />

                <label
                  htmlFor={'chkboxNewProducts'}
                  value={'1'}
                  onClick={(e) => {}}
                >
                  New Products
                </label>
              </li>
              <li>
                <input
                  type="checkbox"
                  name={'ActiveProducts'}
                  id={'chkboxActiveProducts'}
                  checked={this.state.productStatus == '2' ? true : false}
                  onChange={(e) => {
                    this.setState({ productStatus: '2' });
                  }}
                />

                <label
                  htmlFor={'chkboxActiveProducts'}
                  value={'2'}
                  onClick={(e) => {}}
                >
                  Active Products
                </label>
              </li>
              <li>
                <input
                  type="checkbox"
                  name={'InActiveProducts'}
                  id={'chkboxInActiveProducts'}
                  checked={this.state.productStatus == '3' ? true : false}
                  onChange={(e) => {
                    this.setState({ productStatus: '3' });
                  }}
                />

                <label
                  htmlFor={'chkboxInActiveProducts'}
                  value={'3'}
                  onClick={(e) => {}}
                >
                  Inactive Products
                </label>
              </li>
            </ul>
          </div>

          <div className="row upload-row upl-main zx">
            {this.state.productStatus == '1' ? (
              <div
                onClick={() => {
                  removeStorageItem(PRODUCT_ID);
                  window.location.href = '/productlisting';
                }}
                className="col col-md-2 upload-col d-flex flex-column justify-content-center"
                id="img-upload-container"
              >
                <img
                  src="assets/images/placeholder/download.png"
                  alt="placeholder-img"
                />
                <br />
                <p style={{ textAlign: 'center' }}>Add a Product or Service</p>
              </div>
            ) : (
              <></>
            )}

            {products &&
            products.length > 0 
            &&
            products.find((product) => product.StatusId == this.state.productStatus) 
            ? (
              products
                .filter((a) => a.StatusId == this.state.productStatus)
                .map((product, i) => (
                  <div
                    key={i}
                    className="col col-md-2 upload-col cursorpointer "
                    onClick={() => {
                      this.EditProduct(product);
                    }}
                  >
                    <img
                      id="output"
                      src={
                        baseUrlImage +
                        ImageEntityEnum.PRODUCT +
                        '/' +
                        product.ProductID +
                        '/' +
                        product.ThumbnailImage
                      }
                      alt=""
                    />
                    <p className="text-center mt-1 custom-productbox-textsize">{product.ProductTitle} 
                    <br/> Status : {Object.keys(ProductnShopStatus).find(key => ProductnShopStatus[key] === product.StatusId)}</p>
                  </div>
                ))
            ) : (
              <div>
                <h4>Currently there is no product in this category.</h4>
              </div>
            )}
          </div>
        </div>
      </>
    );
  }
}

export default ShopProducts;
