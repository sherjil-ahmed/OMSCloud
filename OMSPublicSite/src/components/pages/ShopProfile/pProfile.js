import React from 'react';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import { Helmet } from 'react-helmet';
import { FetchData } from '../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  SUPPLIER_ID,
  PRODUCT_ID,
  PROFILE_ID,
} from '../../../utils/constants';
import { ProductStatus } from '../../../utils/enums';
import {
  getStorageItem,
  setStorageItem,
  removeStorageItem,
} from '../../../utils/storageHelper';

class Profile extends React.Component {
  constructor(props) {
    super(props);
    this.selectedItem = null;
    this.state = {
      ProfileID: getStorageItem(PROFILE_ID),
      listShops: [],
      listProducts: [],
      selectedShop: null,
    };
  }

  successGetSupplierByProfileId = (res) => {
    if (res) {
      //get a single object
      setStorageItem(SUPPLIER_ID, res.SupplierID);
      this.state.listShops.push(res);
      this.setState(
        {
          listShops: this.state.listShops,
        },
        () => {
          this.SelectShop(res);
        },
      );
    }
  };

  componentDidMount() {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Supplier_GetByProfileId + this.state.ProfileID,
      null,
      this.successGetSupplierByProfileId,
    );
  }

  EditProduct = (item) => {
    setStorageItem(PRODUCT_ID, item.ProductID);
    window.location.href = '/productlisting';
  };

  EditShop = (item) => {
    setStorageItem(SUPPLIER_ID, item.SupplierID);
    window.location.href = '/createshop';
  };

  successGetProductByShopId = (resP) => {
    let item = this.selectedItem;
    if (resP) {
      this.state.listProducts = resP;
    }
    this.setState({
      selectedShop: item.SupplierID,
      listProducts: this.state.listProducts,
    });
  };

  SelectShop = (item) => {
    this.selectedItem = item;
    setStorageItem(SUPPLIER_ID, item.SupplierID);
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Product_GetLookupByShopId + item.SupplierID,
      null,
      this.successGetProductByShopId,
    );
  };

  render() {
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Profile</title>
        </Helmet>
        <Header />
        <main className="main">
          <nav aria-label="breadcrumb" className="breadcrumb-nav">
            <div className="container">
              <ol className="breadcrumb">
                <li className="breadcrumb-item">
                  <a href="/">
                    <i className="icon-home" />
                  </a>
                </li>
                <li className="breadcrumb-item active" aria-current="page">
                  Profile
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>
          <div className="container ">
            <div className="heading mb-4  sp-setting">
              <h2 className="title">My Shops</h2>
              {this.state.listShops && this.state.listShops.length > 0 ? (
                <div className="row justify-content-center">
                  <div className="col table-col">
                    <table className="table table-hover text-center">
                      <thead className="thead-light">
                        <tr>
                          <th scope="col">#</th>
                          <th scope="col">Shop Name</th>
                          <th scope="col">Action</th>
                        </tr>
                      </thead>
                      <tbody>
                        {this.state.listShops.map((item, i) => (
                          <tr key={i}>
                            <th scope="row">{i + 1}</th>
                            <td>{item.SupplierName}</td>
                            <td>
                              <span
                                onClick={() => {
                                  this.EditShop(item);
                                }}
                                type="button"
                                className="btn btn-sm btn-warning"
                                style={{ borderRadius: '10px' }}
                              >
                                <i className="fa fa-edit" />
                                Edit
                              </span>
                            </td>
                          </tr>
                        ))}
                      </tbody>
                    </table>
                  </div>
                </div>
              ) : (
                <div>
                  <button
                    onClick={() => {
                      removeStorageItem(SUPPLIER_ID);
                      window.location.href = '/createshop';
                    }}
                    className="btn btn-success"
                    style={{ float: 'right', marginTop: '-15px' }}
                  >
                    <i className="fa fa-plus" />
                    Create new shop
                  </button>
                  <h3>
                    Whoops, no shops created, click create new to get started!
                  </h3>
                </div>
              )}
              {this.state.selectedShop ? (
                <>
                  <div>
                    <h2 className="title">My Products</h2>
                  </div>
                  <div>
                    <button
                      onClick={() => {
                        removeStorageItem(PRODUCT_ID);
                        window.location.href = '/productlisting';
                      }}
                      className="btn btn-success"
                      style={{ float: 'right', marginBottom: '20px' }}
                    >
                      <i className="fa fa-plus" />
                      Add New Product
                    </button>
                  </div>
                </>
              ) : (
                <></>
              )}
              {this.state.listProducts && this.state.listProducts.length > 0 ? (
                <div style={{ paddingTop: '20px' }}>
                  <div className="col table-col">
                    <table className="table table-hover text-center">
                      <thead className="thead-light">
                        <tr>
                          <th scope="col">#</th>
                          <th scope="col">Product Name</th>
                          <th scope="col">Action</th>
                        </tr>
                      </thead>
                      <tbody>
                        {this.state.listProducts.map((item, i) => (
                          <tr key={i}>
                            <th scope="row">{i + 1}</th>
                            <td>{item.ProductTitle}</td>
                            <td>
                              <button
                                onClick={() => {
                                  this.EditProduct(item);
                                }}
                                type="button"
                                className="btn btn-sm btn-warning"
                                style={{ borderRadius: '10px' }}
                              >
                                <i className="fa fa-edit" />
                                Edit
                              </button>
                            </td>
                          </tr>
                        ))}
                      </tbody>
                    </table>
                  </div>
                </div>
              ) : this.state.selectedShop ? (
                <div>
                  <h3>Get started by adding Products to your shop!</h3>
                </div>
              ) : (
                <></>
              )}
            </div>
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}

export default Profile;
