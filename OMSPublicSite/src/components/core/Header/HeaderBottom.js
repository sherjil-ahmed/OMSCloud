import React from 'react';

class HeaderBottom extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="header-bottom">
        <div className="container">
          <nav className="main-nav">
            <div className="menu-depart">
              <a href="#">
                <i className="icon-menu" />
                Shop by Category
              </a>
              <div className="submenu">
                <a href="#">
                  <i className="icon-category-home" />
                  Home
                </a>
                <a href="#">
                  <i className="icon-category-fashion" />
                  Fashion
                </a>
                <a href="#">
                  <i className="icon-category-electronics" />
                  Electronics
                </a>
                <a href="#">
                  <i className="icon-category-gifts" />
                  Gifts
                </a>
                <a href="#">
                  <i className="icon-category-garden" />
                  Garden
                </a>
                <a href="#">
                  <i className="icon-category-music" />
                  Music
                </a>
                <a href="#">
                  <i className="icon-category-motors" />
                  Motors
                </a>
                <a href="#">
                  <i className="icon-category-furniture" />
                  Furniture
                </a>
                <a href="#">
                  VIEW ALL <i className="icon-angle-right" />
                </a>
              </div>
            </div>
            <ul className="menu">
              <li>
                <a href="#" className="active">
                  Home
                </a>
              </li>
              <li>
                <a href="#">Categories</a>
                <div className="megamenu megamenu-fixed-width">
                  <div className="row row-sm">
                    <div className="col-lg-4">
                      <a href="#" className="nolink">
                        VARIATION 1
                      </a>
                      <ul className="submenu">
                        <li>
                          <a href="#">Fullwidth Banner</a>
                        </li>
                        <li>
                          <a href="#">Boxed Slider Banner</a>
                        </li>
                        <li>
                          <a href="#">Boxed Image Banner</a>
                        </li>
                        <li>
                          <a href="#">Left Sidebar</a>
                        </li>
                        <li>
                          <a href="#">Right Sidebar</a>
                        </li>
                        <li>
                          <a href="#">Product Flex Grid</a>
                        </li>
                        <li>
                          <a href="#">Horizontal Filter1</a>
                        </li>
                        <li>
                          <a href="#">Horizontal Filter2</a>
                        </li>
                      </ul>
                    </div>
                    <div className="col-lg-4">
                      <a href="#" className="nolink">
                        VARIATION 2
                      </a>
                      <ul className="submenu">
                        <li>
                          <a href="#">Product List Item Types</a>
                        </li>
                        <li>
                          <a href="#">Ajax Infinite Scroll</a>
                        </li>
                        <li>
                          <a href="#">3 Columns Products</a>
                        </li>
                        <li>
                          <a href="#">4 Columns Products</a>
                        </li>
                        <li>
                          <a href="#">5 Columns Products</a>
                        </li>
                        <li>
                          <a href="#">6 Columns Products</a>
                        </li>
                        <li>
                          <a href="#">7 Columns Products</a>
                        </li>
                        <li>
                          <a href="#">8 Columns Products</a>
                        </li>
                      </ul>
                    </div>
                    <div className="col-lg-4 image-container">
                      <img
                        src="assets/images/menu-banner-2.jpg"
                        align="Menu banner"
                      />
                    </div>
                  </div>
                </div>
                {/* End .megamenu */}
              </li>
              <li>
                <a href="#">Products</a>
                <div className="megamenu">
                  <div className="row row-sm">
                    <div className="col-lg-3">
                      <a href="#" className="nolink">
                        Variations 1
                      </a>
                      <ul className="submenu">
                        <li>
                          <a href="#">Horizontal Thumbnails</a>
                        </li>
                        <li>
                          <a href="#">Vertical Thumbnails</a>
                        </li>
                        <li>
                          <a href="#">Inner Zoom</a>
                        </li>
                        <li>
                          <a href="#">Addtocart Sticky</a>
                        </li>
                        <li>
                          <a href="#">Accordion Tabs</a>
                        </li>
                      </ul>
                    </div>
                    {/* End .col-lg-4 */}
                    <div className="col-lg-3">
                      <a href="#" className="nolink">
                        Variations 2
                      </a>
                      <ul className="submenu">
                        <li>
                          <a href="#">Sticky Tabs</a>
                        </li>
                        <li>
                          <a href="#">Simple Product</a>
                        </li>
                        <li>
                          <a href="#">With Left Sidebar</a>
                        </li>
                      </ul>
                    </div>
                    {/* End .col-lg-4 */}
                    <div className="col-lg-3">
                      <a href="#" className="nolink">
                        Product Layout Types
                      </a>
                      <ul className="submenu">
                        <li>
                          <a href="#">Default Layout</a>
                        </li>
                        <li>
                          <a href="#">Extended Layout</a>
                        </li>
                        <li>
                          <a href="#">Full Width Layout</a>
                        </li>
                        <li>
                          <a href="#">Grid Images Layout</a>
                        </li>
                        <li>
                          <a href="#">Sticky Both Side Info</a>
                        </li>
                        <li>
                          <a href="#">Sticky Right Side Info</a>
                        </li>
                      </ul>
                    </div>
                    {/* End .col-lg-4 */}
                    <div className="col-lg-3 image-container">
                      <img
                        src="assets/images/menu-banner-1.jpg"
                        alt="Menu banner"
                        className="product-promo"
                      />
                    </div>
                    {/* End .col-lg-4 */}
                  </div>
                  {/* End .row */}
                </div>
                {/* End .megamenu */}
              </li>
              <li className="sf-with-ul">
                <a href="#">Pages</a>
                <ul>
                  <li>
                    <a href="#">Shopping Cart</a>
                  </li>
                  <li>
                    <a href="#">Checkout</a>
                    <ul>
                      <li>
                        <a href="#">Checkout Shipping</a>
                      </li>
                      <li>
                        <a href="#">Checkout Shipping 2</a>
                      </li>
                      <li>
                        <a href="#">Checkout Review</a>
                      </li>
                    </ul>
                  </li>
                  <li>
                    <a href="#">Dashboard</a>
                    <ul>
                      <li>
                        <a href="#">Dashboard</a>
                      </li>
                      <li>
                        <a href="#">My Account</a>
                      </li>
                    </ul>
                  </li>
                  <li>
                    <a href="#">About Us</a>
                  </li>
                  <li>
                    <a href="#">Blog</a>
                    <ul>
                      <li>
                        <a href="#">Blog</a>
                      </li>
                      <li>
                        <a href="#">Blog Post</a>
                      </li>
                    </ul>
                  </li>
                  <li>
                    <a href="#">Contact Us</a>
                  </li>
                  <li>
                    <a href="#" className="login-link">
                      Login
                    </a>
                  </li>
                  <li>
                    <a href="forgot-password.html">Forgot Password</a>
                  </li>
                </ul>
              </li>
            </ul>
          </nav>
          <div className="header-dropdowns">
            {/* <div className="header-dropdown">
                        <a href="#" className="link-seller">Become a Seller</a>
                    </div> */}
            <div className="header-dropdown">
              <a href="#">USD</a>
              <div className="header-menu">
                <ul>
                  <li>
                    <a href="#">EUR</a>
                  </li>
                  <li>
                    <a href="#">USD</a>
                  </li>
                </ul>
              </div>
              {/* End .header-menu */}
            </div>
            {/* End .header-dropown */}
            <div className="header-dropdown">
              <a href="#">ENG</a>
              <div className="header-menu">
                <ul>
                  <li>
                    <a href="#">ENGLISH</a>
                  </li>
                  <li>
                    <a href="#">FRENCH</a>
                  </li>
                </ul>
              </div>
              {/* End .header-menu */}
            </div>
            {/* End .header-dropown */}
          </div>
          {/* End .header-left */}
        </div>
        {/* End .header-bottom */}
      </div>
    );
  }
}

export default HeaderBottom;
