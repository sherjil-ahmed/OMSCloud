import React from 'react';
import { default_strings } from '../../../utils/globalConstants';

class FooterBottom extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="footer-bottom">
        <div className="fot-d1">
        <p className="footer-copyright">Zvonr Technologies</p>
        <p className="footer-copyright">{default_strings.ZVONR_ADDRESS}</p>
        </div>
        <div className="fot-d2">
          <div className="fot-rs-d1">
          <img
          src="/assets/images/logoonly.png"
          width="280px"
          style={{ maxHeight: '50px' }}
        />
          </div>
          <div className="fot-rs-d1">
          <p className="footer-copyright">Powered by <a href={'//' + "avanturebyte.com"} target="_blank" rel="noopener noreferrer">Avanture Bytes</a> All Rights Reserved</p>
          </div>
        </div>
  
      </div> 
    );
  }
}

export default FooterBottom;
