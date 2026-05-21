import React from 'react';
import Header from '../../core/Header/Header';
import Footer from '../../core/Footer/Footer';
import { Helmet } from 'react-helmet';
import Account_UpdatePassword from '../../../utils';

class EditAccountInformation extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Edit Account Information</title>
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
                  dashboard
                </li>
              </ol>
            </div>
            {/* End .container */}
          </nav>
          <div className="container">
            <div className="row">
              <div className="col-lg-9 order-lg-last dashboard-content">
                <h2>Edit Account Information</h2>
                <form action="#">
                  <div className="row">
                    <div className="col-sm-11">
                      <div className="row">
                        <div className="col-md-4">
                          <div className="form-group required-field">
                            <label htmlFor="acc-name">First Name</label>
                            <input
                              type="text"
                              maxLength="200"
                              className="form-control"
                              id="acc-name"
                              name="acc-name"
                              required
                            />
                          </div>
                          {/* End .form-group */}
                        </div>
                        {/* End .col-md-4 */}
                        <div className="col-md-4">
                          <div className="form-group">
                            <label htmlFor="acc-mname">First Name</label>
                            <input
                              type="text"
                              maxLength="200"
                              className="form-control"
                              id="acc-mname"
                              name="acc-mname"
                            />
                          </div>
                          {/* End .form-group */}
                        </div>
                        {/* End .col-md-4 */}
                        <div className="col-md-4">
                          <div className="form-group required-field">
                            <label htmlFor="acc-lastname">Last Name</label>
                            <input
                              type="text"
                              maxLength="200"
                              className="form-control"
                              id="acc-lastname"
                              name="acc-lastname"
                              required
                            />
                          </div>
                          {/* End .form-group */}
                        </div>
                        {/* End .col-md-4 */}
                      </div>
                      {/* End .row */}
                    </div>
                    {/* End .col-sm-11 */}
                  </div>
                  {/* End .row */}
                  <div className="form-group required-field">
                    <label htmlFor="acc-email">Email</label>
                    <input
                      type="email"
                      maxLength="200"
                      className="form-control"
                      id="acc-email"
                      name="acc-email"
                      required
                    />
                  </div>
                  {/* End .form-group */}
                  <div className="form-group required-field">
                    <label htmlFor="acc-password">Password</label>
                    <input
                      type="password"
                      maxLength="25"
                      className="form-control"
                      id="acc-password"
                      name="acc-password"
                      required
                    />
                  </div>
                  {/* End .form-group */}
                  <div className="mb-2" />
                  {/* margin */}
                  <div className="custom-control custom-checkbox">
                    <input
                      type="checkbox"
                      className="custom-control-input"
                      id="change-pass-checkbox"
                      defaultValue={1}
                    />
                    <label
                      className="custom-control-label"
                      htmlFor="change-pass-checkbox"
                    >
                      Change Password
                    </label>
                  </div>
                  {/* End .custom-checkbox */}
                  <div id="account-chage-pass">
                    <h3 className="mb-2">Change Password</h3>
                    <div className="row">
                      <div className="col-md-6">
                        <div className="form-group required-field">
                          <label htmlFor="acc-pass2">Password</label>
                          <input
                            type="password"
                            maxLength="25"
                            className="form-control"
                            id="acc-pass2"
                            name="acc-pass2"
                          />
                        </div>
                        {/* End .form-group */}
                      </div>
                      {/* End .col-md-6 */}
                      <div className="col-md-6">
                        <div className="form-group required-field">
                          <label htmlFor="acc-pass3">Confirm Password</label>
                          <input
                            type="password"
                            maxLength="25"
                            className="form-control"
                            id="acc-pass3"
                            name="acc-pass3"
                          />
                        </div>
                        {/* End .form-group */}
                      </div>
                      {/* End .col-md-6 */}
                    </div>
                    {/* End .row */}
                  </div>
                  {/* End #account-chage-pass */}
                  <div className="required text-right">* Required Field</div>
                  <div className="form-footer">
                    <a href="#">
                      <i className="icon-angle-double-left" />
                      Back
                    </a>
                    <div className="form-footer-right">
                      <button type="submit" className="btn btn-primary">
                        Save
                      </button>
                    </div>
                  </div>
                  {/* End .form-footer */}
                </form>
              </div>
              {/* End .col-lg-9 */}
              <aside className="sidebar col-lg-3">
                <div className="widget widget-dashboard">
                  <h3 className="widget-title">My Account</h3>
                  <ul className="list">
                    <li className="active">
                      <a href="#">Account Dashboard</a>
                    </li>
                    <li>
                      <a href="#">Account Information</a>
                    </li>
                    <li>
                      <a href="#">Address Book</a>
                    </li>
                    <li>
                      <a href="#">My Orders</a>
                    </li>
                    <li>
                      <a href="#">Billing Agreements</a>
                    </li>
                    <li>
                      <a href="#">Recurring Profiles</a>
                    </li>
                    <li>
                      <a href="#">My Product Reviews</a>
                    </li>
                    <li>
                      <a href="#">My Tags</a>
                    </li>
                    <li>
                      <a href="#">My Wishlist</a>
                    </li>
                    <li>
                      <a href="#">My Applications</a>
                    </li>
                    <li>
                      <a href="#">Newsletter Subscriptions</a>
                    </li>
                    <li>
                      <a href="#">My Downloadable Products</a>
                    </li>
                  </ul>
                </div>
                {/* End .widget */}
              </aside>
              {/* End .col-lg-3 */}
            </div>
            {/* End .row */}
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}

export default EditAccountInformation;
