import { Helmet } from 'react-helmet';
import React from 'react';

class GuidePageMobile extends React.Component {
  constructor(props) {
    super(props);
    this.state={
      FAQsShowHide : {
        a1 : false,
        a2 : false,
        a3 : false,
        a4 : false,
        a5 : false
      }
    }
  }

  showHideDiv = (id)=>{
    if(!this.state.FAQsShowHide[id]){
      this.state.FAQsShowHide[id] = true
      }
    else{
      this.state.FAQsShowHide[id] = false
    } 
    this.setState({
      FAQsShowHide : this.state.FAQsShowHide
    }) 
    }
    render(){
        return(
         
		  <div className="page-wrapper">
		   <Helmet>
          <link rel="stylesheet" href="assets/css/customguidepagecss.css" />
          </Helmet>
            <div className="container-fluid custom-topmargin">
              <div className="row">
                <div className="col-md-12">
                  <div className="topnav" id="myTopnav">
                    <a href="#section1" className="m-none">Zvonr Introduction</a>
                    <a href="#section2">Features of Zvonr marketplace</a>
                    <a href="#s3">Opening a shop at Zvonr</a>
                    <a href="#section4">Frequently Asked Questions</a>
                    <a className="icon">
                      <i className="fa fa-bars" />
                    </a>
                  </div>
                </div>
              </div>
            </div>
        <section className="sec1" id="section1">
          <div className="container">
            <div className="row">
              <div className="col-md-8 js-m">
                <h2>Zvonr Introduction</h2>
                <p>
                Zvonr marketplace is a state-of-the-art eCommerce marketplace that allows wider visibility to
locally sourced goods and services. It allows vendors the freedom to sell their valuable products
and services without the conventional limitations of retail business. Through our user-friendly
application, it is easier than ever for everyday people to become entrepreneurs and start their own
profitable businesses from the convenience of their homes. Besides, consumers enjoy their
handpicked selection of locally made goods and personalized services. </p>
              </div>
              <div className="col-md-4" />
            </div>
          </div>
        </section>
        <section className="sec-2" id="section2">
          <div className="container" >
            <div className="row">
              <div className="col-md-12">
                <div className="sec-cont">
                  <h2>Features of <span>Zvonr</span> marketplace</h2>
                  <div className="row">
                    <div className="col-md-6">
                      <div className="service-widget">
                        <i className="service-icon icon-shipping" />
                        <div className="service-content">
                          <h3 className="service-title">Local and Country-Wide Delivery</h3>
                            <p>Local sellers can use our chat system to communicate with local buyers for delivery or pick-up arrangements.</p>
                        </div>
                      </div>
                    </div>
                    <div className="col-md-6">
                      <div className="service-widget">
                        <i className="service-icon icon-money" />
                        <div className="service-content">
                          <h3 className="service-title">Free Cash Transactions</h3>
                          <p>
                          Sellers and customers can make transactions in cash if they mutually choose to and there is NO fee charged by Zvonr for cash transactions.
                          </p>
                        </div>
                      </div>
                    </div>
                  </div>
                  <div className="row">
                    <div className="col-md-6">
                      <div className="service-widget">
                        <i className="service-icon icon-support" />
                        <div className="service-content">
                          <h3 className="service-title">online support 24/7</h3>
                          <p>We are on 24/7 standby to answer your questions through emails and support chat. </p>
                        </div>
                      </div>
                    </div>
                    <div className="col-md-6 " id="s3">
                      <div className="service-widget">
                        <i className="service-icon icon-secure-payment" />
                        <div className="service-content">
                          <h3 className="service-title">Secure Payment</h3>
                          <p>All of our customers’ transactions and data are secured as per the highest standard. Our operations are compliant with industry regulations.</p>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>        
        
        <section className="sec3">
          <div className="container">
          
            <div className="row">
              <div className="col-md-12 h-df">
                <h2 id="section3">Opening a shop at Zvonr</h2>
              </div>
            </div>
            <div className="row sec3-row">
            <div className="col-md-6 indiv">
                <div className="row">
                  <div className="col-md-1 ica">
                    <h2>01</h2>
                  </div>
                  <div className="col-md-11 abm">
                    <div className="ins-cont">
                      <h3>Setting up your shop</h3>
                      <p>You set up your own shop, determine available options such as delivery or pickup or both,
determine your minimum order amount and handling charge, determine available payment options
to your customers such as cash or online payment.</p>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-md-6 indiv">
                <div className="row">
                  <div className="col-md-1 ica">
                    <h2>02</h2>
                  </div>
                  <div className="col-md-11 abm">
                    <div className="ins-cont">
                      <h3>Reaching out to your customers</h3>
                      <p>
                      Not only sell your goods to locals and help the community to grow but also you will be visible to
buyers from far and wide locations. You can accept online orders for your services and you serve
your customers right at their doorstep.
                      </p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div className="row sec3-row">
            <div className="col-md-6 indiv">
                <div className="row">
                  <div className="col-md-1 ica">
                    <h2>03</h2>
                  </div>
                  <div className="col-md-11 abm">
                    <div className="ins-cont">
                      <h3>Customer's Visibility</h3>
                      <p>You can sell your goods and services with increased flexibility. If you need a break from your
business then you can set up your shop’s availability in your calendar. Control days with your
calendar when your shop will not appear at the marketplace.</p>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-md-6 indiv">
                <div className="row">
                  <div className="col-md-1 ica">
                    <h2>04</h2>
                  </div>
                  <div className="col-md-11 abm">
                    <div className="ins-cont">
                      <h3>Social Media and Website</h3>
                      <p>
                      You can add links to your website and social media page at Zvonr marketplace. Attract millions of
buyers of the Zvonr marketplace to your own website. Although adding these links is not
mandatory. Add anytime when you are ready.</p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col-md-3" />
              <div className="col-md-6 indiv">
                <div className="row">
                  <div className="col-md-1 ica">
                    <h2>05</h2>
                  </div>
                  <div className="col-md-11 abm">
                    <div className="ins-cont">
                      <h3>Zero Fee Opening, Listing and Selling</h3>
                      <p>Sellers and customers can make transactions in cash if they mutually choose to and there is NO
                          fee charged by Zvonr for cash transactions. You pay only 5% payment processing and 5%
                          transaction fee when you prefer to be secured by accepting deposits and payments in advance
                          through our payment system.</p>
                          <p>
                          Automatic payout deposits to your account every week.</p>
                    </div>
                  </div>
                </div>
              </div>
              <div className="col-md-3" />
            </div>
          </div>
        </section>
        <section className="sec-4" id="section4">
          <div className="container">
            <div className="row">
              <div className="col-md-12">
                <h2 className="faq">Frequently Asked Questions</h2><br />
              </div>
            </div>
            <div className="row">
              <div className="col-md-12">
                <div className="main-fqs">
                  <div className="q1">
                    <p className="qu1 tds" onClick={()=>{this.showHideDiv("a1")}}>Who and what can be listed / sold on Zvonr?</p>
                    <p className={this.state.FAQsShowHide.a1 ? "a1 show" : "a1"}   id="a1">
                      Any shop can sell its products and services. The products are particularly homemade. Services
can be provided at the doorstep of the buyers. A seller can be a home-based individual or a small
local shop and business. Shop owners are supposed to be responsible for their own licensing of
goods and services if needed. Zvonr will not be responsible for licensing.</p>
                  </div><br />
                  <div className="q2">
                    <p className="qu2 tds" onClick={()=>{this.showHideDiv("a2")}}>How do shops get paid?</p>
                    <p className={this.state.FAQsShowHide.a2 ? "a2 show" : "a2"}>
                    At Zvonr marketplace, shops may accept payments with credit cards, debit cards, PayPal, or
cash. Funds from your sale are deposited directly to your bank account weekly.</p>
                  </div><br />
                  <div className="q3">
                    <p className="qu3 tds" onClick={()=>{this.showHideDiv("a3")}}>How does Zvonr protect sellers?</p>
                    <p className={this.state.FAQsShowHide.a3 ? "a3 show" : "a3"}>
                    If the shop can not resolve a disagreement with the buyer and the transaction meets eligibility
criteria then Zvonr will assist to resolve the issue through our dispute resolution system.</p>
                  </div><br />
                  <div className="q4">
                    <p className="qu4 tds" onClick={()=>{this.showHideDiv("a4")}}>Do I need a credit or debit card to open a shop?</p>
                    <p className={this.state.FAQsShowHide.a4 ? "a4 show" : "a4"}>
                    No, they are not required to open a shop.
                      </p>
                  </div><br />
                  <div className="q5">
                    <p className="qu5 tds" onClick={()=>{this.showHideDiv("a5")}}>What is needed to create a shop?</p>
                    <p className={this.state.FAQsShowHide.a5 ? "a5 show" : "a5"}>
                    It is easy to open and set up a shop at Zvonr. You need to sign up (create an account) at Zvonr
with your email. You will use your account to open and manage your shop and the ‘step-by-step’
shop opening wizard will guide you through.</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>
        </div> 
        )
    }
}
export default GuidePageMobile;

