import React from 'react';
import Header from './core/Header/Header';
import Footer from './core/Footer/Footer';
import Body from './core/Body/Body';
import { Helmet } from 'react-helmet';
import BackgroundSlider from 'react-background-slider';
import backgroundimg from '../utils/mainshop.jpg';
import backgroundimg1 from '../utils/mainshop1.jpg';
import backgroundimg2 from '../utils/mainshop2.jpg';
import backgroundimg3 from '../utils/mainshop3.jpg';
import backgroundimg4 from '../utils/mainshop4.jpg';
import backgroundimg5 from '../utils/mainshop5.jpg';
import backgroundimg6 from '../utils/mainshop6.jpg';
import AliceCarousel from 'react-alice-carousel';
import "react-alice-carousel/lib/alice-carousel.css";
import { Link } from "react-router-dom";
import CookieConsent, { Cookies,getCookieConsentValue,resetCookieConsentValue  } from "react-cookie-consent";
import { slider_speed } from '../utils/globalConstants';

class ViewMain extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <div className="page-wrapper">
        <Header />
        <section id="hero">
          <CookieConsent
            location="bottom"
            buttonText="Accept"
            cookieName="myAwesomeCookieName2"
            style={{ background: "#150101" ,fontSize : "15px" }}
            buttonStyle={{ color: "#150101", fontSize: "15px" , background: "#ffffff", fontWeight: 'bold' }}
            expires={150}
            // visible= "show"
          >
            By using Zvonr marketplace, you consent to our, <Link style= {{color : '#9b94ff' , textDecoration: 'underline'}} to="/terms-of-service">Cookie Policy</Link>, <Link style= {{color : '#9b94ff' , textDecoration: 'underline'}} to="/terms-of-service">Privacy Policy</Link> and all <Link style= {{color : '#9b94ff' , textDecoration: 'underline'}} to="/terms-of-service">Terms of services</Link>.
          </CookieConsent>
          {/* <img src="assets/images/banners/mainshop.jpg" className="bannerimg" /> */}
          {/* <BackgroundSlider
            images={[backgroundimg, backgroundimg]}
            duration={10} transition={2} 
            className="bannerimg"/> */}
          {/* <a href="#main"> */}
          <AliceCarousel className="alice-carousel__dots alice-carousel__prev-btn alice-carousel__next-btn" autoPlay autoPlayInterval={slider_speed} autoPlayStrategy= 'none' infinite={true} >
            <img src={backgroundimg} className="bannerimg" />
            <img src={backgroundimg1} className="bannerimg" />
            <img src={backgroundimg2} className="bannerimg" />
            <img src={backgroundimg3} className="bannerimg" />
            <img src={backgroundimg4} className="bannerimg" />
            <img src={backgroundimg5} className="bannerimg" />
            <img src={backgroundimg6} className="bannerimg" />
          </AliceCarousel>

          <div onClick={(e) => {
            e.preventDefault();
            window.location.href = '/ShopSearch';
          }}
            className="downpointer left"
                    style={{ cursor: 'pointer' }}
          >
            <p>View Our Shops</p>
            <img src="assets/images/banners/shop.png" />
          </div>
          <div onClick={(e) => {
            e.preventDefault();
            window.MoveToDiv('main');
          }}
            className="downpointer" style={{ cursor: 'pointer' }}>
            <p>Popular Right Now</p>
            <img src="assets/images/banners/darrow2.png" />
          </div>
          <div onClick={(e) => {
            e.preventDefault();
            window.location.href = '/GuidePage';
          }} className="downpointer right" style={{ cursor: 'pointer' }}>
            <p >How it works?</p>
            <img src="assets/images/banners/qpng.png" />
          </div>
          {/* </a> */}
        </section>
        <Body />
        <Footer />
      </div>
    );
  }
}

export default ViewMain;
