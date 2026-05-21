import React from 'react';
import { appSocials } from '../../../utils/globalConstants';
import { default_strings } from '../../../utils/globalConstants';

class FooterMobileApp extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="footer-mobileapp">
        <div className="row row-sm">
          <div className="col-md-6 col-lg-4 col-xl-6">
            <a href="https://play.google.com/store/apps/details?id=com.avanturebytes.zvonr&gl=GB" target="_blank">
            <img src='assets/images/logos/android.png' ></img>    
            </a>        
          </div>  
          <div className="col-md-6 col-lg-4 col-xl-6">
          <a href="https://apps.apple.com/gb/app/zvonr-home-based-business/id1609290240" target="_blank">
             <img src='assets/images/logos/ios.png' style={{float: 'right'}}></img>            
             </a>
          </div>
        </div>
      </div>
    );
  }
}

export default FooterMobileApp;
