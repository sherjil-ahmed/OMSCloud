import React from 'react';
import FooterTop from './FooterTop';
import FooterMiddle from './FooterMiddle';
import FooterMobileApp from './FooterMobileApp';
import FooterBottom from './FooterBottom';

class Footer extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <footer className="footer">
        <FooterTop />
        <div className="container">
        <FooterMobileApp />
        <FooterMiddle />
          
          <FooterBottom />
        </div>
      </footer>
    );
  }
}

export default Footer;
