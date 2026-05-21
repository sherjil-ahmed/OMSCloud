import React from 'react';
import { appSocials } from '../../../utils/globalConstants';
import { default_strings } from '../../../utils/globalConstants';

class FooterMiddle extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="footer-middle">
        <div className="row row-sm">
          <div className="col-lg-5 col-xl-3">

            <div className="row row-sm">
              <div className="col-sm-6" style={{display:'none'}}>
                <div className="contact-widget">
                  <h4 className="widget-title">ADDRESS</h4>
                  <p>{default_strings.ZVONR_ADDRESS}</p>
                </div>
              </div>
              
              <div className="col-md-6">
                <div className="social-icons mb-3">
                  <a href={appSocials.FACEBOOK} className="social-icon" target="_blank">
                    <i className="fab fa-facebook-f" />
                  </a>
                  <a href={appSocials.INSTAGRAM} className="social-icon" target="_blank">
                    <i className="fab fa-instagram" />
                  </a>
                  <a href={appSocials.LINKEDIN} className="social-icon" target="_blank">
                    <i className="fab fa-linkedin-in" />
                  </a>
                </div>
              </div>
            </div>
          </div>
          <div className="col-md-4 col-lg-2 col-xl-3">
            <div className="widget">
              <h4 className="special_hover_link">
                <a className="custom-footer-style" href={"/GuidePage#section1"}>About Us</a>
              </h4>
              {/* <ul className="links link-parts">
                <div className="link-part">
                  <li>
                    <a href="#">My Account</a>
                  </li>
                  <li>
                    <a href="#">Track Your Order</a>
                  </li>
                  <li>
                    <a href="#">Payment Methods</a>
                  </li>
                  <li>
                    <a href="#">Shipping Guide</a>
                  </li>
                  <li>
                    <a href="#">FAQs</a>
                  </li>
                  <li>
                    <a href="#">Product Support</a>
                  </li>
                  <li>
                    <a href="#">Privacy</a>
                  </li>
                </div>
              </ul> */}
            
            </div>
          </div>
          <div className="col-md-4 col-lg-2 col-xl-3">
            <div className="widget">
              <h4 className="special_hover_link">
                <a className="custom-footer-style" href={"/contact-us"}>Contact Us</a>
              </h4>
            </div>
          </div>  
          <div className="col-md-4 col-lg-2 col-xl-3">
            <div className="widget">
              <h4 className="special_hover_link">
                <a className="custom-footer-style" href={"/terms-of-service"}>Terms and Conditions </a>
              </h4>
            </div>
          </div> 
        </div>
      </div>
    );
  }
}

export default FooterMiddle;
