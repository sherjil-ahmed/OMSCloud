import React from 'react';
import HeaderTop from './HeaderTop';
import HeaderMiddle from './HeaderMiddle';
import HeaderBottom from './HeaderBottom';

class Header extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <header className="header">
        <HeaderTop />
        <HeaderMiddle />
        {/* <HeaderBottom/> */}
      </header>
    );
  }
}

export default Header;
