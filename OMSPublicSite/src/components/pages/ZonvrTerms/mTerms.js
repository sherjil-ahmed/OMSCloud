import { Helmet } from 'react-helmet';
import React from 'react';

class ZonvrTermsMobile extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      FAQsShowHide: {
        a1: false,
        a2: false,
        a3: false,
        a4: false,
        a5: false
      }
    }
  }
  showHideDiv = (id) => {
    if (!this.state.FAQsShowHide[id]) {
      this.state.FAQsShowHide[id] = true
    }
    else {
      this.state.FAQsShowHide[id] = false
    }
    this.setState({
      FAQsShowHide: this.state.FAQsShowHide
    })
  }
  render() {
    return (
      <>
        <Helmet>
          <link rel="stylesheet" href="assets/css/customguidepagecss.css" />
        </Helmet>
        <div className="container custom-topmargin">
          <div className="row">
            <div className="col-md-12">
              <div className="topnav" id="myTopnav">
                <a href="#q1" className="m-none">Privacy Policy</a>
                <a href="#q2">Terms Of Service</a>
                <a href="#q3">Cookie Policy</a>
                <a href="#q4">Acceptable Use Policy</a>
                <a className="icon">
                  <i className="fa fa-bars" />
                </a>
              </div>
            </div>
          </div>
        </div>
        <section className="sec1" id="section1" style={{ paddingTop: "100px" }}>
          <div className="container">
            <div className="row">
              <div className="col-md-12">
                <div className="main-fqs">
                  <div className="q1" id="q1">
                    <p className="qu1 tds" onClick={() => { this.showHideDiv("a1") }}>Privacy Policy</p>
                    <div className={this.state.FAQsShowHide.a1 ? "a1 show" : "a1"} id="a1">
                      <p><span lang="EN"
                      ></span></p>
                      <h2>
                        <span lang="EN">Privacy Policy</span>
                      </h2>
                      <p><span lang="EN"
                      >Your privacy is important to us. It
                        is Zvonr.com's policy to respect your privacy and comply with any applicable
                        law and regulation regarding any personal information we may collect about you,
                        including across our website,</span></p>
                      <p><span lang="EN"><a href="https://www.zvonr.com/"><span
                      >https://zvonr.com</span></a></span><span
                        lang="EN" >, </span><span lang="EN"><a href="https://www.zvonr.com/"><span
                        >https://zvonr.ca</span></a></span><span
                          lang="EN" >, </span><span lang="EN"><a href="https://www.zvonr.com/"><span
                          >https://zvonr.us</span></a></span><span
                            lang="EN" >, </span><span lang="EN"><a href="https://www.zvonr.com/"><span
                            >https://zvonr.co.uk</span></a></span><span
                              lang="EN" >

                        </span></p>
                      <p><span lang="EN"
                      >and other sites we own and operate.

                      </span></p>
                      <p><span lang="EN"
                      >Personal information is any
                        information about you that can be used to identify you. This includes
                        information about you as a person (such as name, address, and date of birth),
                        your devices, payment details, and even information about how you use a website
                        or online service.</span></p>
                      <p><span lang="EN"
                      >In the event our site contains links
                        to third-party sites and services, please be aware that those sites and
                        services have their own privacy policies. After following a link to any
                        third-party content, you should read their posted privacy policy information
                        about how they collect and use personal information. This Privacy Policy does
                        not apply to any of your activities after you leave our site.</span></p>
                      <p><span lang="EN"
                      >This policy is effective as of
                        November 01, 2021.</span></p>
                      <p><span lang="EN"
                      >Last updated: November 01, 2021.
                      </span></p>
                      <h3><a name="_kmblan1w342"></a><b><span lang="EN"
                      >Information
                        We Collect</span></b></h3>
                      <p><span lang="EN"
                      >Information we collect falls in the
                        category “voluntarily provided” information</span></p>
                      <p><span lang="EN"
                      >“Voluntarily provided” information
                        refers to any information you knowingly and actively provide us while you
                        register or subscribe to our web application as well as when using or
                        participating in any of our services and promotions.</span></p>
                      <h4><a name="_c5u3adkpg4g"></a><b><span lang="EN"
                      >Log Data</span></b></h4>
                      <p><span lang="EN"
                      >We do not log any of your activity
                        or browsing on any of our applications.</span></p>
                      <h4><a name="_y4yc1h9ijstc"></a><b><span lang="EN"
                      >Device Data</span></b></h4>
                      <p><span lang="EN"
                      >Any information or data about your
                        device, as below, is never collected by us.</span></p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Device
                          Type</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Operating
                          System</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Unique device
                          identifiers</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Device
                          settings</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Geo-location
                          data</span><span lang="EN">

                        </span>
                      </p>
                      <h4><a name="_j0paeyw21b07"></a><b><span lang="EN"
                      >Personal Information</span></b></h4>
                      <p><span lang="EN"
                      >We may ask for personal information
                        — for example, when you submit content to us or when you contact us — which may
                        include one or more of the following:</span></p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Name</span><span
                          lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Email</span><span
                          lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Social media
                          profiles</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Date of
                          birth</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Phone/mobile
                          number</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Home/mailing
                          address</span><span lang="EN">

                        </span>
                      </p>
                      <h4><a name="_zfdgpc91u1s5"></a><span lang="EN"
                      >Any such information will be voluntarily be entered by
                        you in our application and our application will never collect any of your
                        information automatically, implicitly, or unknowingly.</span></h4>
                      <p><span lang="EN">&nbsp;</span></p>
                      <h4><a name="_s09rojg68u11"></a><b><span lang="EN"
                      >User-Generated Content</span></b></h4>
                      <p><span lang="EN"
                      >We consider “user-generated content”
                        to be materials (text, image and/or video content) voluntarily supplied to us
                        by our users (sellers or service providers) for the purpose of publication on
                        our website or re-publishing on our social media channels. All user-generated
                        content is associated with the account or email address used to submit the
                        materials.</span></p>
                      <p><span lang="EN"
                      >Please be aware that any content you
                        submit for the purpose of publication will be public after posting (and
                        subsequent review or vetting process). Once published, it may be accessible to
                        third parties not covered under this privacy policy.</span></p>
                      <h4><a name="_zgnt75w4xlj7"></a><b><span lang="EN"
                      >Legitimate Reasons for
                        Processing Your Personal Information</span></b></h4>
                      <p><span lang="EN"
                      >We only collect and use your
                        personal information when we have a legitimate reason for doing so. In which
                        instance, we only collect personal information that is reasonably necessary to
                        provide our services to you.</span></p>
                      <h4><a name="_ecl48fk6ot8q"></a><b><span lang="EN"
                      >Collection and Use of
                        Information</span></b></h4>
                      <p><span lang="EN"
                      >We may collect personal information
                        from you when you do any of the following on our website:</span></p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Register for an
                          account</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Sign up to
                          receive updates from us via email or social
                          media channels</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Use a mobile
                          device or web browser to access our content</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Contact us via
                          email, social media, or on any similar
                          technologies</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >When you
                          mention us on social media</span><span lang="EN">

                        </span>
                      </p>
                      <p><span lang="EN"
                      >We may collect, hold, use, and
                        disclose information for the following purposes, and personal information will
                        not be further processed in a manner that is incompatible with these purposes:</span></p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >to provide you
                          with our platform's core features and
                          services</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >to enable you
                          to customize or personalize your experience
                          of our website</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >to deliver
                          products and/or services to you</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >to contact and
                          communicate with you</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >for analytics,
                          market research, and business development,
                          including to operate and improve our website, associated applications, and
                          associated social media platforms</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >for advertising
                          and marketing, including sending you
                          promotional information about our products and services and information about
                          third parties that we consider may be of interest to you, only if you
                          subscribe.</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >to enable you
                          to access and use our website, associated
                          applications, and associated social media platforms</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >for internal
                          record keeping and administrative purposes</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >to comply with
                          our legal obligations and resolve any
                          disputes that we may have</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >to attribute
                          any content (e.g. posts and comments) you
                          submit that we publish on our website</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >for security
                          and fraud prevention, and to ensure that our
                          sites and apps are safe, secure, and used in line with our terms of use</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >for technical
                          assessment, including to operate and
                          improve our app, associated applications, and associated social media platforms</span><span lang="EN">

                        </span>
                      </p>
                      <p><span lang="EN"
                      >We may combine voluntarily provided
                        personal information with general information or research data we receive from
                        other trusted sources. For example, Our marketing and market research
                        activities may uncover data and insights, which we may combine with information
                        about how visitors use our site to improve our site and your experience on it.</span></p>
                      <h4><a name="_52wdb5iq25p3"></a><b><span lang="EN"
                      >Security of Your Personal
                        Information</span></b></h4>
                      <p><span lang="EN"
                      >When we collect and process personal
                        information, and while we retain this information, we will protect it within
                        commercially acceptable means to prevent loss and theft, as well as
                        unauthorized access, disclosure, copying, use, or modification.</span></p>
                      <p><span lang="EN"
                      >Although we will do our best to
                        protect the personal information you provide to us, we advise that no method of
                        electronic transmission or storage is 100% secure, and no one can guarantee
                        absolute data security.</span></p>
                      <p><span lang="EN"
                      >You are responsible for selecting
                        any password and its overall security strength, ensuring the security of your
                        own information within the bounds of our services. For example, ensuring any
                        passwords associated with accessing your personal information and accounts are
                        secure and confidential.</span></p>
                      <h4><a name="_7wh26ibb9ka9"></a><b><span lang="EN"
                      >How Long We Keep Your
                        Personal Information</span></b></h4>
                      <p><span lang="EN"
                      >We keep your personal information
                        only for as long as we need to. This time period may depend on what we are
                        using your information for, in accordance with this privacy policy. For
                        example, if you have provided us with personal information as part of creating
                        an account with us, we may retain this information for the duration your
                        account exists on our system. If your personal information is no longer
                        required for this purpose, we will delete it or make it anonymous by removing
                        all details that identify you.</span></p>
                      <p><span lang="EN"
                      >However, if necessary, we may retain
                        your personal information for our compliance with a legal, accounting, or
                        reporting obligation or for archiving purposes in the public interest,
                        scientific, or historical research purposes, or statistical purposes.</span></p>
                      <h3><a name="_utd9pjqfqur2"></a><b><span lang="EN"
                      >Children’s
                        Privacy</span></b></h3>
                      <p><span lang="EN"
                      >We do not aim any of our products or
                        services directly at children under the age of 13, and we do not knowingly
                        collect personal information about children under 13.</span></p>
                      <h3><a name="_ovwpabau390c"></a><b><span lang="EN"
                      >Disclosure
                        of Personal Information to Third Parties</span></b></h3>
                      <p><span lang="EN"
                      >We may disclose personal information
                        to:</span></p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >a parent,
                          subsidiary, or affiliate of our company</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >third-party
                          service providers for the purpose of enabling
                          them to provide their services, including (without limitation) IT service
                          providers, data storage, hosting and server providers, ad networks, analytics,
                          error loggers, debt collectors, maintenance or problem-solving providers,
                          marketing or advertising providers, professional advisors, and payment systems
                          operators</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >our employees,
                          contractors, and/or related entities</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >our existing or
                          potential agents or business partners</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >credit
                          reporting agencies, courts, tribunals, and
                          regulatory authorities, in the event you fail to pay for goods or services we
                          have provided to you</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >courts,
                          tribunals, regulatory authorities, and law
                          enforcement officers, as required by law, in connection with any actual or
                          prospective legal proceedings, or in order to establish, exercise, or defend
                          our legal rights</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >third parties,
                          including agents or sub-contractors, who
                          assist us in providing information, products, services, or direct marketing to
                          you</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >third parties
                          to collect and process data</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >an entity that
                          buys, or to which we transfer all or
                          substantially all of our assets and business</span><span lang="EN">

                        </span>
                      </p>
                      <p><span lang="EN"
                      >Third parties we currently use
                        include:</span></p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Google
                          Analytics</span><span lang="EN">

                        </span>
                      </p>
                      <h3><a name="_ur7aq9wl19pt"></a><b><span lang="EN"
                      >International
                        Transfers of Personal Information</span></b></h3>
                      <p><span lang="EN"
                      >The personal information we collect
                        is stored and/or processed in Canada, or where we or our partners, affiliates,
                        and third-party providers maintain facilities.</span></p>
                      <p><span lang="EN"
                      >The countries to which we store,
                        process, or transfer your personal information may not have the same data
                        protection laws as the country in which you initially provided the information.
                        If we transfer your personal information to third parties in other countries:
                        (i) we will perform those transfers in accordance with the requirements of
                        applicable law; and (ii) we will protect the transferred personal information
                        in accordance with this privacy policy.</span></p>
                      <h3><a name="_djl2tijikh0m"></a><b><span lang="EN"
                      >Your
                        Rights and Controlling Your Personal Information</span></b></h3>
                      <p><b><span lang="EN"
                      >Your
                        choice:</span></b><span lang="EN" > By
                          providing personal information to
                          us, you understand we will
                          collect, hold, use, and disclose your personal information in accordance with
                          this privacy policy. You do not have to provide personal information to us,
                          however, if you do not, it may affect your use of our website or the products
                          and/or services offered on or through it.</span></p>
                      <p><span lang="EN"
                      >You may request to close your
                        account and delete all your information from our system at any time. You can
                        make this request through our “Contact Us” form.</span></p>
                      <p><b><span lang="EN"
                      >Information
                        from third parties:</span></b><span lang="EN"
                        > If we receive personal information
                          about you from a
                          third party, we will protect it as set out in this privacy policy. If you are a
                          third party providing personal information about somebody else, you represent
                          and warrant that you have such person’s consent to provide the personal
                          information to us.</span></p>
                      <p><b><span lang="EN"
                      >Marketing
                        permission:</span></b><span lang="EN" > If
                          you have previously agreed to us
                          using your personal
                          information for direct marketing purposes, you may change your mind at any time
                          by contacting us using the details below.</span></p>
                      <p><b><span lang="EN"
                      >Access:</span></b><span lang="EN"
                      > You may request details of
                          the personal information that we hold about you.</span></p>
                      <p><b><span lang="EN"
                      >Correction:</span></b><span lang="EN"
                      > If you believe that any
                          information we hold about you is inaccurate, out of date, incomplete,
                          irrelevant, or misleading, please contact us using the details provided in this
                          privacy policy. We will take reasonable steps to correct any information found
                          to be inaccurate, incomplete, misleading, or out of date.</span></p>
                      <p><b><span lang="EN"
                      >Non-discrimination:</span></b><span
                        lang="EN" > We will not discriminate
                          against you for exercising any of your rights over your personal information.
                          Unless your personal information is required to provide you with a particular
                          service or offer (for example providing user support), we will not deny you
                          goods or services and/or charge you different prices or rates for goods or
                          services, including through granting discounts or other benefits, or imposing
                          penalties, or provide you with a different level or quality of goods or
                          services.</span></p>
                      <p><b><span lang="EN"
                      >Downloading
                        of Personal Information:</span></b><span lang="EN"
                        > We provide a means for you to
                          download the personal
                          information you have shared through our site. Please contact us for more
                          information.</span></p>
                      <p><b><span lang="EN"
                      >Notification
                        of data breaches:</span></b><span lang="EN"
                        > We will comply with laws applicable
                          to us in respect of
                          any data breach.</span></p>
                      <p><b><span lang="EN"
                      >Complaints:</span></b><span lang="EN"
                      > If you believe that we
                          have
                          breached a relevant data protection law and wish to make a complaint, please
                          contact us using the details below and provide us with full details of the
                          alleged breach. We will promptly investigate your complaint and respond to you,
                          in writing, setting out the outcome of our investigation and the steps we will
                          take to deal with your complaint. You also have the right to contact a
                          regulatory body or data protection authority in relation to your complaint.</span></p>
                      <p><b><span lang="EN"
                      >Unsubscribe:</span></b><span lang="EN"
                      > To unsubscribe from our
                          email database or opt-out of communications (including marketing
                          communications), please contact us using the details provided in this privacy
                          policy, or opt-out using the opt-out facilities provided in the communication.
                          We may need to request specific information from you to help us confirm your
                          identity.</span></p>
                      <h3><a name="_m8q9b1dzbbe3"></a><b><span lang="EN"
                      >Use
                        of Cookies</span></b></h3>
                      <p><span lang="EN"
                      >We use “cookies” to collect
                        information about you and your activity across our site. A cookie is a small
                        piece of data that our website stores on your computer, and accesses each time
                        you visit, so we can understand how you use our site. This helps us serve you
                        content based on the preferences you have specified.</span></p>
                      <p><span lang="EN"
                      >Please refer to our Cookie Policy
                        for more information.</span></p>
                      <h3><a name="_civvwuunqiti"></a><b><span lang="EN"
                      >Business
                        Transfers</span></b></h3>
                      <p><span lang="EN"
                      >If we or our assets are acquired, or
                        in the unlikely event that we go out of business or enter bankruptcy, we would
                        include data, including your personal information, among the assets transferred
                        to any parties who acquire us. You acknowledge that such transfers may occur
                        and that any parties who acquire us may, to the extent permitted by applicable
                        law, continue to use your personal information according to this policy, which
                        they will be required to assume as it is the basis for any ownership or use
                        rights we have over such information.</span></p>
                      <h3><a name="_dj796frkt9wf"></a><b><span lang="EN"
                      >Limits
                        of Our Policy</span></b></h3>
                      <p><span lang="EN"
                      >Our website may link to external
                        sites that are not operated by us. Please be aware that we have no control over
                        the content and policies of those sites, and cannot accept responsibility or
                        liability for their respective privacy practices.</span></p>
                      <h3><a name="_ybmupjt6ooa"></a><b><span lang="EN"
                      >Changes
                        to This Policy</span></b></h3>
                      <p><span lang="EN"
                      >At our discretion, we may change our
                        privacy policy to reflect updates to our business processes, current acceptable
                        practices, or legislative or regulatory changes. If we decide to change this
                        privacy policy, we will post the changes here at the same link by which you are
                        accessing this privacy policy.</span></p>
                      <p><span lang="EN"
                      >If the changes are significant, or
                        if required by applicable law, we will contact you (based on your selected
                        preferences for communications from us) and all our registered users with the
                        new details and links to the updated or changed policy.</span></p>
                      <p><span lang="EN"
                      >If required by law, we will get your
                        permission or give you the opportunity to opt in to or opt out of, as
                        applicable, any new uses of your personal information.</span></p>
                      <h3><a name="_qka4mfbbe7gl"></a><b><span lang="EN"
                      >Additional
                        Disclosures for Australian Privacy Act Compliance (AU)</span></b></h3>
                      <h4><a name="_jhrkxepjureo"></a><b><span lang="EN"
                      >International Transfers of
                        Personal Information</span></b></h4>
                      <p><span lang="EN"
                      >Where the disclosure of your
                        personal information is solely subject to Australian privacy laws, you
                        acknowledge that some third parties may not be regulated by the Privacy Act and
                        the Australian Privacy Principles in the Privacy Act. You acknowledge that if
                        any such third party engages in any act or practice that contravenes the
                        Australian Privacy Principles, it would not be accountable under the Privacy
                        Act, and you will not be able to seek redress under the Privacy Act.</span></p>
                      <h3><a name="_n5mds2nj39n6"></a><b><span lang="EN"
                      >Additional
                        Disclosures for General Data Protection Regulation (GDPR) Compliance (EU)</span></b>
                      </h3>
                      <h4><a name="_yq4bvpbm7ig6"></a><b><span lang="EN"
                      >Data Controller / Data
                        Processor</span></b></h4>
                      <p><span lang="EN"
                      >The GDPR distinguishes between
                        organizations that process personal information for their own purposes (known
                        as “data controllers”) and organizations that process personal information on
                        behalf of other organizations (known as “data processors”). We, Zvonr.com,
                        located at the address provided in our Contact Us section, are a Data
                        Controller with respect to the personal information you provide to us.</span></p>
                      <h4><a name="_9hi3i5es23x7"></a><b><span lang="EN"
                      >Legal Bases for Processing
                        Your Personal Information</span></b></h4>
                      <p><span lang="EN"
                      >We will only collect and use your
                        personal information when we have a legal right to do so. In which case, we
                        will collect and use your personal information lawfully, fairly, and in a
                        transparent manner. If we seek your consent to process your personal information,
                        and you are under 16 years of age, we will seek your parent or legal guardian’s
                        consent to process your personal information for that specific purpose.</span></p>
                      <p><span lang="EN"
                      >Our lawful bases depend on the
                        services you use and how you use them. This means we only collect and use your
                        information on the following grounds:</span></p>
                      <h5><a name="_7vlnlyi0b0fo"></a><b><span lang="EN"
                      >Consent From You
                      </span></b></h5>
                      <p><span lang="EN"
                      >Where you give us consent to collect
                        and use your personal information for a specific purpose. You may withdraw your
                        consent at any time using the facilities we provide; however, this will not
                        affect any use of your information that has already taken place. You may
                        consent to provide your email address for the purpose of receiving marketing
                        emails from us. While you may unsubscribe at any time, we cannot recall any
                        email we have already sent. If you have any further inquiries about how to
                        withdraw your consent, please feel free to enquire using the details provided
                        in the Contact Us section of this privacy policy.</span></p>
                      <h5><a name="_qbbpasf5vbli"></a><b><span lang="EN"
                      >Performance of a Contract or
                        Transaction</span></b></h5>
                      <p><span lang="EN"
                      >Where you have entered into a
                        contract
                        or transaction with us, or in order to take preparatory steps prior to our
                        entering into a contract or transaction with you. For example, if you contact
                        us with an inquiry, we may require personal information such as your name and
                        contact details in order to respond.</span></p>
                      <h5><a name="_8w2b0ggjq8he"></a><b><span lang="EN"
                      >Our Legitimate Interests
                      </span></b></h5>
                      <p><span lang="EN"
                      >Where we assess it is necessary for
                        our legitimate interests, such as for us to provide, operate, improve and
                        communicate our services. We consider our legitimate interests to include
                        research and development, understanding our audience, marketing and promoting
                        our services, measures taken to operate our services efficiently, marketing
                        analysis, and measures taken to protect our legal rights and interests.</span></p>
                      <h5><a name="_eyqe18gbds8x"></a><b><span lang="EN"
                      >Compliance with Law
                      </span></b></h5>
                      <p><span lang="EN"
                      >In some cases, we may have a legal
                        obligation to use or keep your personal information. Such cases may include
                        (but are not limited to) court orders, criminal investigations, government
                        requests, and regulatory obligations. If you have any further inquiries about
                        how we retain personal information in order to comply with the law, please feel
                        free to enquire using the details provided in the Contact Us section of this
                        privacy policy.</span></p>
                      <h4><a name="_3677x4vnjgkv"></a><b><span lang="EN"
                      >International Transfers
                        Outside of the European Economic Area (EEA)</span></b></h4>
                      <p><span lang="EN"
                      >We will ensure that any transfer of
                        personal information from countries in the European Economic Area (EEA) to
                        countries outside the EEA will be protected by appropriate safeguards, for
                        example by using standard data protection clauses approved by the European
                        Commission, or the use of binding corporate rules or other legally accepted
                        means.</span></p>
                      <h4><a name="_1sdfse41ne8s"></a><b><span lang="EN"
                      >Your Rights and Controlling
                        Your Personal Information</span></b></h4>
                      <p><b><span lang="EN"
                      >Restrict:</span></b><span lang="EN"
                      > You have the right to
                          request that we restrict the processing of your personal information if (i) you
                          are concerned about the accuracy of your personal information; (ii) you believe
                          your personal information has been unlawfully processed; (iii) you need us to
                          maintain the personal information solely for the purpose of a legal claim; or
                          (iv) we are in the process of considering your objection in relation to
                          processing on the basis of legitimate interests.</span></p>
                      <p><b><span lang="EN"
                      >Objecting
                        to processing:</span></b><span lang="EN" >
                          You have the right to object to the
                          processing of your
                          personal information that is based on our legitimate interests or public
                          interest. If this is done, we must provide compelling legitimate grounds for
                          the processing which overrides your interests, rights, and freedoms, in order to
                          proceed with the processing of your personal information.</span></p>
                      <p><b><span lang="EN"
                      >Data
                        portability:</span></b><span lang="EN" >
                          You may have the right to request a
                          copy of the personal
                          information we hold about you. Where possible, we will provide this information
                          in CSV format or another easily readable machine format. You may also have the
                          right to request that we transfer this personal information to a third party.</span></p>
                      <p><b><span lang="EN"
                      >Deletion:</span></b><span lang="EN"
                      > You may have a right to
                          request that we delete the personal information we hold about you at any time,
                          and we will take reasonable steps to delete your personal information from our
                          current records. If you ask us to delete your personal information, we will let
                          you know how the deletion affects your use of our website or products and
                          services. There may be exceptions to this right for specific legal reasons
                          which, if applicable, we will set out for you in response to your request. If
                          you terminate or delete your account, we will delete your personal information
                          within 3 days of the deletion of your account. Please be aware that search
                          engines and similar third parties may still retain copies of your personal
                          information that has been made public at least once, like certain profile
                          information and public comments, even after you have deleted the information
                          from our services or deactivated your account.</span></p>
                      <h3><a name="_z0rdj1y3gta5"></a><b><span lang="EN"
                      >Additional
                        Disclosures for California Compliance (US)</span></b></h3>
                      <p><span lang="EN"
                      >Under California Civil Code Section
                        1798.83, if you live in California and your business relationship with us is
                        mainly for personal, family, or household purposes, you may ask us about the
                        information we release to other organizations for their marketing purposes.</span></p>
                      <p><span lang="EN"
                      >To make such a request, please
                        contact us using the details provided in this privacy policy with “Request for
                        California privacy information” in the subject line. You may make this type of
                        request once every calendar year. We will email you a list of categories of
                        personal information we revealed to other organizations for their marketing
                        purposes in the last calendar year, along with their names and addresses. Not
                        all personal information shared in this way is covered by Section 1798.83 of
                        the California Civil Code.</span></p>
                      <h4><a name="_6iaa5z7af2df"></a><b><span lang="EN"
                      >Do Not Track</span></b></h4>
                      <p><span lang="EN"
                      >Some browsers have a “Do Not Track”
                        feature that lets you tell websites that you do not want to have your online
                        activities tracked. At this time, we do not respond to browser “Do Not Track”
                        signals.</span></p>
                      <p><span lang="EN"
                      >We adhere to the standards outlined
                        in this privacy policy, ensuring we collect and process personal information
                        lawfully, fairly, transparently, and with legitimate, legal reasons for doing
                        so.</span></p>
                      <h4><a name="_w3bb59b9z3ce"></a><b><span lang="EN"
                      >Cookies and Pixels</span></b></h4>
                      <p><span lang="EN"
                      >At all times, you may decline
                        cookies from our site if your browser permits. Most browsers allow you to
                        activate settings on your browser to refuse the setting of all or some cookies.
                        Accordingly, your ability to limit cookies is based only on your browser’s
                        capabilities. Please refer to the Cookies section of this privacy policy for
                        more information.</span></p>
                      <h4><a name="_15a2jyl3rrak"></a><b><span lang="EN"
                      >CCPA-permitted financial
                        incentives</span></b></h4>
                      <p><span lang="EN"
                      >In accordance with your right to
                        non-discrimination, we may offer you certain financial incentives permitted by
                        the CCPA that can result in different prices, rates, or quality levels for the
                        goods or services we provide.</span></p>
                      <p><span lang="EN"
                      >Any CCPA-permitted financial
                        incentive we offer will reasonably relate to the value of your personal
                        information, and we will provide written terms that describe clearly the nature
                        of such an offer. Participation in a financial incentive program requires your
                        prior opt-in consent, which you may revoke at any time.</span></p>
                      <h4><a name="_o3tz1lt2ifyr"></a><b><span lang="EN"
                      >California Notice of
                        Collection</span></b></h4>
                      <p><span lang="EN"
                      >In the past 12 months, we have
                        collected the following categories of personal information enumerated in the
                        California Consumer Privacy Act:</span></p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Customer
                          records, such as billing and shipping address,
                          and credit or debit card data.</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >Audio or visual
                          data, such as photos or videos you share
                          with us or post on the service.</span><span lang="EN">

                        </span>
                      </p>
                      <p><span lang="EN"
                      >For more information on the
                        information we collect, including the sources we receive information from,
                        review the “Information We Collect” section. We collect and use these
                        categories of personal information for the business purposes described in the
                        “Collection and Use of Information” section, including to provide and manage
                        our Service.</span></p>
                      <h4><a name="_vddqcq84ubw4"></a><b><span lang="EN"
                      >Right to Know and Delete</span></b></h4>
                      <p><span lang="EN"
                      >If you are a California resident,
                        you have the right to delete the personal information we collected and know
                        certain information about our data practices in the preceding 12 months. In
                        particular, you have the right to request the following from us:</span></p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >The categories
                          of personal information we have collected
                          about you;</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >The categories
                          of sources from which the personal
                          information was collected;</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >The categories
                          of personal information about you we
                          disclosed for a business purpose;</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >The categories
                          of third parties to whom the personal
                          information was disclosed for a business purpose;</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >The business or
                          commercial purpose for collecting the
                          personal information; and</span><span lang="EN">

                        </span>
                      </p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >The specific
                          pieces of personal information we have
                          collected about you.</span><span lang="EN">

                        </span>
                      </p>
                      <p><span lang="EN"
                      >To exercise any of these rights,
                        please contact us using the details provided in this privacy policy.</span></p>
                      <h4><a name="_uh7tmyvcu39p"></a><b><span lang="EN"
                      >Shine the Light</span></b></h4>
                      <p><span lang="EN"
                      >If you are a California resident, in
                        addition to the rights discussed above, you have the right to request
                        information from us regarding the manner in which we share certain personal
                        information as defined by California’s “Shine the Light” with third parties and
                        affiliates for their own direct marketing purposes.</span></p>
                      <p><span lang="EN"
                      >To receive this information, send us
                        a request using the contact details provided in this privacy policy. Requests
                        must include “California Privacy Rights Request” in the first line of the
                        description and include your name, street address, city, state, and ZIP code.</span></p>
                      <h3><a name="_pbq4wv78bz9s"></a><b><span lang="EN"
                      >Contact
                        Us</span></b></h3>
                      <p><span lang="EN"
                      >For any questions or concerns
                        regarding your privacy, you may contact us using the following details:</span></p>
                      <p><span lang="EN"
                      >https://support@zvonr.com
                      </span></p>
                      <p>
                      </p>
                      <p><span lang="EN">&nbsp;</span></p>
                    </div>
                  </div><br />
                  <div className="q2" id="q2">
                    <p className="qu2 tds" onClick={() => { this.showHideDiv("a2") }}>Terms Of Service</p>
                    <div className={this.state.FAQsShowHide.a2 ? "a2 show" : "a2"} id="a2">
                      <h2><a></a><b><span lang="EN">Terms of Service</span></b>
                      </h2>

                      <p><span lang="EN">These Terms of Service govern your
                        use of the website located at </span><span lang="EN"><a
                          href="https://www.zvonr.com/"><span>https://www.Zvonr.com</span></a></span><span lang="EN"> and any
                            related services
                            provided by Zvonr.com such as <br />
                        </span><span lang="EN"><a href="https://www.zvonr.com/"><span>https://www.Zvonr.ca</span></a></span><span
                          lang="EN"><br />
                        </span><span lang="EN"><a href="https://www.zvonr.com/"><span>https://www.Zvonr.us</span></a></span><span
                          lang="EN"><br />
                        </span><span lang="EN"><a href="https://www.zvonr.com/"><span>https://www.Zvonr.uk</span></a></span><span
                          lang="EN">

                        </span></p>

                      <p><span lang="EN">By accessing </span><span lang="EN"><a
                        href="https://www.zvonr.com/"><span>https://www.Zvonr.com</span></a></span><span lang="EN">, you agree
                          to abide by these
                          Terms of Service and to comply with all applicable laws and regulations. If you
                          do not agree with these Terms of Service, you are prohibited from using or
                          accessing this website or using any other services provided by Zvonr.com.</span></p>

                      <p><span lang="EN">We, Zvonr.com, reserve the right to
                        review and amend any of these Terms of Service at our sole discretion. Upon
                        doing so, we will update this page. Any changes to these Terms of Service will
                        take effect immediately from the date of publication.</span></p>

                      <p><span lang="EN">These Terms of Service were last
                        updated on 01 November 2021.</span></p>


                      <h3><a></a><b><span lang="EN">Limitations
                        of Use</span></b></h3>


                      <p><span lang="EN">By using this website, you warrant
                        on behalf of yourself, your users, and other parties you represent that you
                        will not:</span></p>

                      <ol start="1" type="1">
                        <li><span lang="EN"> ●    modify,
                          copy, prepare
                          derivative works of, decompile, or reverse engineer any materials and software
                          contained on this website;</span><span lang="EN">

                          </span></li>
                        <li><span lang="EN"> ●    remove
                          any copyright or
                          other proprietary notations from any materials and software on this
                          website;</span><span lang="EN">

                          </span></li>
                        <li><span lang="EN"> ●    transfer the materials
                          to another person or “mirror” the materials on any other server;</span><span lang="EN">

                          </span></li>
                        <li><span lang="EN"> ●    knowingly or negligently
                          use this website or any of its associated services in a way that abuses or
                          disrupts our networks or any other service Zvonr.com provides;</span><span lang="EN">

                          </span></li>
                        <li><span lang="EN"> ●    use
                          this website or its
                          associated services to transmit or publish any harassing, indecent, obscene,
                          fraudulent, or unlawful material;</span><span lang="EN">

                          </span></li>
                        <li><span lang="EN"> ●    use
                          this website or its
                          associated services in violation of any applicable laws or regulations;</span><span lang="EN">

                          </span></li>
                        <li><span lang="EN"> ●    use
                          this website in
                          conjunction with sending unauthorized advertising or spam;</span><span lang="EN">

                          </span></li>
                        <li><span lang="EN"> ●    harvest, collect, or
                          gather user data without the user’s consent; or</span><span lang="EN">

                          </span></li>
                        <li><span lang="EN"> ●    use
                          this website or its associated services in such a way that may infringe
                          the privacy, intellectual property rights, or other rights of third
                          parties.</span><span lang="EN">

                          </span></li>
                      </ol>


                      <h3><a></a><b><span lang="EN">Intellectual
                        Property</span></b></h3>


                      <p><span lang="EN">The intellectual property in the
                        materials contained in this website is owned by or licensed to Zvonr.com and is
                        protected by applicable copyright and trademark law. We grant our users
                        permission to download one copy of the materials for personal, non-commercial
                        transitory use.</span></p>

                      <p><span lang="EN">This constitutes the grant of a
                        license, not a transfer of title. This license shall automatically terminate if
                        you violate any of these restrictions or the Terms of Service, and may be
                        terminated by Zvonr.com at any time.</span></p>


                      <h3><a></a><b><span lang="EN">User-Generated
                        Content</span></b></h3>


                      <p><span lang="EN">You retain your intellectual
                        property ownership rights over the content you submit to us for publication on
                        our website. We will never claim ownership of your content, but we may require
                        a license from you in order to use it.</span></p>

                      <p><span lang="EN">When you use our website or its
                        associated services to post, upload, share, or otherwise transmit content
                        covered by intellectual property rights, you grant to us a non-exclusive,
                        royalty-free, transferable, sub-licensable, worldwide license to use,
                        distribute, modify, run, copy, publicly display, translate, or otherwise create
                        derivative works of your content in a manner that is consistent with your
                        privacy preferences and our Privacy Policy.</span></p>

                      <p><span lang="EN">The license you grant us can be
                        terminated at any time by deleting your content or account. However, to the
                        extent that we (or our partners) have used your content in connection with
                        commercial or sponsored content, the license will continue until the relevant
                        commercial or post has been discontinued by us.</span></p>

                      <p><span lang="EN">You give us permission to use your
                        username and other identifying information associated with your account in a
                        manner that is consistent with your privacy preferences, and our Privacy
                        Policy.</span></p>


                      <h3><a></a><b><span lang="EN">Liability</span></b></h3>


                      <p><span lang="EN">Our website and the materials on our
                        website are provided on an 'as is’ basis. To the extent permitted by law,
                        Zvonr.com makes no warranties, expressed or implied, and hereby disclaims and
                        negates all other warranties including, without limitation, implied warranties
                        or conditions of merchantability, fitness for a particular purpose, or
                        non-infringement of intellectual property, or other violation of rights.</span></p>

                      <p><span lang="EN">In no event shall Zvonr.com or its
                        suppliers be liable for any consequential loss suffered or incurred by you or
                        any third party arising from the use or inability to use this website or the
                        materials on this website, even if Zvonr.com or an authorized representative
                        has been notified, orally or in writing, of the possibility of such damage.</span></p>

                      <p><span lang="EN">In the context of this agreement,
                        “consequential loss” includes any consequential loss, indirect loss, real or
                        anticipated loss of profit, loss of benefit, loss of revenue, loss of business,
                        loss of goodwill, loss of opportunity, loss of savings, loss of reputation, loss
                        of use and/or loss or corruption of data, whether under the statute, contract,
                        equity, tort (including negligence), indemnity, or otherwise.</span></p>

                      <p><span lang="EN">Because some jurisdictions do not
                        allow limitations on implied warranties, or limitations of liability for consequential
                        or incidental damages, these limitations may not apply to you.</span></p>


                      <h3><a></a><b><span lang="EN">Accuracy
                        of Materials</span></b></h3>


                      <p><span lang="EN">The materials appearing on our
                        website are not comprehensive and are for general information purposes only.
                        Zvonr.com does not warrant or make any representations concerning the accuracy,
                        likely results, or reliability of the use of the materials on this website, or
                        otherwise relating to such materials or on any resources linked to this
                        website.</span></p>


                      <h3><a></a><b><span lang="EN">Links</span></b></h3>


                      <p><span lang="EN">Zvonr.com has not reviewed all of
                        the sites linked to its website and is not responsible for the contents of any
                        such linked site. The inclusion of any link does not imply endorsement,
                        approval, or control by Zvonr.com of the site. Use of any such linked site is
                        at your own risk and we strongly advise you to make your own investigations
                        with respect to the suitability of those sites.</span></p>


                      <h3><a></a><b><span lang="EN">Right
                        to Terminate</span></b></h3>


                      <p><span lang="EN">We may suspend or terminate your
                        right to use our website and terminate these Terms of Service immediately upon
                        written notice to you for any breach of these Terms of Service.</span></p>


                      <h3><a></a><b><span lang="EN">Severance</span></b></h3>


                      <p><span lang="EN">Any term of these Terms of Service
                        which is wholly or partially void or unenforceable is severed to the extent
                        that it is void or unenforceable. The validity of the remainder of these Terms
                        of Service is not affected.</span></p>


                      <h3><a></a><b><span lang="EN">Governing
                        Law</span></b></h3>


                      <p><span lang="EN">These Terms of Service are governed
                        by and construed in accordance with the laws of the United States/Canada and
                        the United Kingdom. You irrevocably submit to the exclusive jurisdiction of the
                        courts in that State or location.</span></p>

                    </div>
                  </div><br />
                  <div className="q3" id="q3">
                    <p className="qu3 tds" onClick={() => { this.showHideDiv("a3") }}>Cookie Policy</p>
                    <div className={this.state.FAQsShowHide.a3 ? "a3 show" : "a3"} id="a3">
                      <h2><a></a><b><span lang="EN">Cookie Policy
                      </span></b></h2>
                      <p><span lang="EN">We use
                        cookies to help improve your
                        experience of our website at </span><span lang="EN"><a
                          href="https://www.zvonr.com/"><span>https://zvonr.com</span></a></span><span lang="EN">, </span><span
                            lang="EN"><a href="https://www.zvonr.com/"><span>https://zvonr.ca</span></a></span><span lang="EN">,
                        </span><span lang="EN"><a href="https://www.zvonr.com/"><span>https://zvonr.us</span></a></span><span lang="EN">,
                          and <br/>
                        </span><span lang="EN"><a href="https://www.zvonr.com/"><span>https://zvonr.co.uk</span></a></span><span
                          lang="EN"><br/>
                          This cookie policy is part of Zvonr.com's privacy policy. It covers the use of
                          cookies between your device and our site.</span></p>
                      <p><span lang="EN">We
                        also provide basic information on
                        third-party services we may use, who may also use cookies as part of their
                        service. This policy does not cover their cookies.</span></p>
                      <p><span lang="EN">If you
                        don’t wish to accept cookies
                        from us, you should instruct your browser to refuse cookies from </span><span lang="EN"><a
                          href="https://www.zvonr.com/"><span>https://www.Zvonr.com</span></a></span><span lang="EN">. In such a case,
                            we
                            may be
                            unable to provide you with some of your desired content and services.</span></p>
                      <h3><a ></a><b><span lang="EN">What
                        is a cookie?</span></b></h3>
                      <p><span lang="EN">A
                        cookie is a small piece of data
                        that a website stores on your device when you visit. It typically contains
                        information about the website itself, a unique identifier that allows the site
                        to recognize your web browser when you return, additional data that serves the
                        cookie’s purpose, and the lifespan of the cookie itself.</span></p>
                      <p><span lang="EN">Cookies are used to enable certain
                        features (e.g. logging in), track site usage (e.g. analytics), store your user
                        settings (e.g. time zone, notification preferences), and personalize your
                        content (e.g. advertising, language).</span></p>
                      <p><span lang="EN">Cookies set by the website you are
                        visiting are usually referred to as first-party cookies. They typically only
                        track your activity on that particular site.</span></p>
                      <p><span lang="EN">Cookies set by other sites and
                        companies (i.e. third parties) are called third-party cookies They can be used
                        to track you on other websites that use the same third-party service.</span></p>
                      
                      <h3><a></a><b><span lang="EN">Types
                        of cookies and how we use them</span></b></h3>
                      <h4><a></a><b><span lang="EN">Essential cookies</span></b></h4>
                      <p><span lang="EN">Essential cookies are crucial to
                        your experience of a website, enabling core features like user logins, account
                        management, shopping carts, and payment processing.</span></p>
                      <p><span lang="EN">We use
                        essential cookies to enable
                        certain functions on our website.</span></p>
                      <h4><a></a><b><span lang="EN">Performance cookies</span></b></h4>
                      <p><span lang="EN">Performance cookies track how you
                        use a website during your visit. Typically, this information is anonymous and
                        aggregated, with information tracked across all site users. They help companies
                        understand visitor usage patterns, identify and diagnose problems or errors
                        their users may encounter, and make better strategic decisions in improving
                        their audience’s overall website experience. These cookies may be set by the website
                        you’re visiting (first-party) or by third-party services. They do not collect
                        personal information about you.</span></p>
                      <p><span lang="EN">We do
                        not use performance cookies on
                        our site.</span></p>
                      <h4><a></a><b><span lang="EN">Functionality cookies</span></b></h4>
                      <p><span lang="EN">Functionality cookies are used to
                        collect information about your device and any settings you may configure on the
                        website you’re visiting (like language and time zone settings). With this
                        information, websites can provide you with customized, enhanced, or optimized
                        content and services. These cookies may be set by the website you’re visiting
                        (first-party) or by third-party services.</span></p>
                      <p><span lang="EN">We do
                        not use functionality cookies
                        for selected features on our site.</span></p>
                      <h4><a></a><b><span lang="EN">Targeting/advertising cookies</span></b></h4>
                      <p>
                      </p>
                      <p><span lang="EN">Targeting/advertising cookies help
                        determine what promotional content is most relevant and appropriate to you and
                        your interests. Websites may use them to deliver targeted advertising or limit
                        the number of times you see an advertisement. This helps companies improve the
                        effectiveness of their campaigns and the quality of content presented to you. These
                        cookies may be set by the website you’re visiting (first-party) or by
                        third-party services. Targeting/advertising cookies set by third parties may be
                        used to track you on other websites that use the same third-party service.<br/>
                        We do not use targeting/advertising cookies on our site.</span><span lang="EN">
                          
                        </span></p>
                    </div>
                  </div>
                  <br />
                  <div className="q4" id="q4">
                    <p className="qu4 tds" onClick={() => { this.showHideDiv("a4") }}>Acceptable Use Policy</p>
                    <div className={this.state.FAQsShowHide.a4 ? "a4 show" : "a4"} id="a4">
                      <h2>
                        <a></a><b><span lang="EN"
                        >Acceptable Use Policy</span></b></h2>
                      <p><span lang="EN"
                      >This acceptable use policy covers the
                        products, services, and technologies (collectively referred to as the “Products”) provided by Zvonr.com under
                        any ongoing agreement. It’s designed to protect us, our customers, and the general Internet community from
                        unethical, irresponsible, and illegal activity.</span></p>
                      <p><span lang="EN"
                      >Zvonr.com customers found engaging in
                        activities prohibited by this acceptable use policy can be liable for service suspension and account
                        termination. In extreme cases, we may be legally obliged to report such customers to the relevant
                        authorities.</span></p>
                      <p><span lang="EN"
                      >This policy was last reviewed on 1 November
                        2021.</span></p>
                      <h3><a
                      ></a><b><span lang="EN"
                      >Fair use</span></b></h3>
                      <p><span lang="EN"
                      >We provide our facilities with the
                        assumption your use will be “business as usual”, as per our offer schedule. If your use is considered to be
                        excessive, then additional fees may be charged, or capacity may be restricted.</span></p>
                      <p><span lang="EN"
                      >We are opposed to all forms of abuse,
                        discrimination, rights infringement, and/or any action that harms or disadvantages any group, individual, or
                        resource. We expect our customers and, where applicable, their users (“end-users”) to likewise engage our
                        Products with similar intent.</span></p>
                      <h3><a
                      ></a><b><span lang="EN"
                      >Customer accountability</span></b></h3>
                      <p><span lang="EN"
                      >We regard our customers as being responsible
                        for their own actions as well as for the actions of anyone using our Products with the customer’s permission.
                        This responsibility also applies to anyone using our Products on an unauthorized basis as a result of the
                        customer’s failure to put in place reasonable security measures.</span></p>
                      <p><span lang="EN"
                      >By accepting Products from us, our customers
                        agree to ensure adherence to this policy on behalf of anyone using the Products as their end-users. Complaints
                        regarding the actions of customers or their end-users will be forwarded to the nominated contact for the
                        account in question.</span></p>
                      <p><span lang="EN"
                      >If a customer — or their end-user or anyone
                        using our Products as a result of the customer — violates our acceptable use policy, we reserve the right to
                        terminate any Products associated with the offending account or the account itself or take any remedial or
                        preventative action we deem appropriate, without notice. To the extent permitted by law, no credit will be
                        available for interruptions of service resulting from any violation of our acceptable use policy.</span></p>
                      <h3><a
                      ></a><b><span lang="EN"
                      >Prohibited activity</span></b></h3>
                      <h4
                      >
                        <a ></a><b><span lang="EN"
                        >Copyright
                          infringement and access to unauthorized material</span></b></h4>
                      <p><span lang="EN"
                      >Our Products must not be used to transmit,
                        distribute or store any material in violation of any applicable law. This includes but isn’t limited to:</span>
                      </p>
                      <ol start="1" type="1">
                        <li><span lang="EN" >any
                          material protected by copyright, trademark, trade secret, or other intellectual property right used without
                          proper authorization, and</span><span lang="EN"></span></li>
                        <li><span lang="EN"
                        >any material that is obscene, defamatory,
                          constitutes an illegal threat, or violates export control laws.</span><span lang="EN"></span></li>
                      </ol>
                      <p><span lang="EN"
                      >The customer is solely responsible for all
                        material they input, upload, disseminate, transmit, create or publish through or on our Products, and for
                        obtaining legal permission to use any works included in such material.</span></p>
                      <h4
                      >
                        <a name="_adspsialzwmu"></a><b><span lang="EN"
                        >SPAM
                          and unauthorized message activity</span></b></h4>
                      <p><span lang="EN"
                      >Our Products must not be used for the
                        purpose of sending the unsolicited bulk or commercial messages in violation of the laws and regulations
                        applicable to your jurisdiction (“spam”). This includes but isn’t limited to sending spam, soliciting customers
                        from spam sent from other service providers, and collecting replies to spam sent from other service
                        providers.</span></p>
                      <p><span lang="EN"
                      >Our Products must not be used for the
                        purpose of running unconfirmed mailing lists or telephone number lists (“messaging lists”). This includes but
                        isn’t limited to subscribing email addresses or telephone numbers to any messaging list without the permission
                        of the email address or telephone number owner, and storing any email addresses or telephone numbers subscribed
                        in this way. All messaging lists run on or hosted by our Products must be “confirmed opt-in”. Verification of
                        the address or telephone number owner’s express permission must be available for the lifespan of the messaging
                        list.</span></p>
                      <p><span lang="EN"
                      >We prohibit the use of email lists,
                        telephone number lists, or databases purchased from third parties intended for spam or unconfirmed messaging
                        list purposes on our Products.</span></p>
                      <p><span lang="EN"
                      >This spam and unauthorized message activity
                        policy applies to messages sent using our Products, or to messages sent from any network by the customer or any
                        person on the customer’s behalf, that directly or indirectly refer the recipient to a site hosted via our
                        Products.</span></p>
                      <h4
                      >
                        <a name="_iiafsmeo2o4p"></a><b><span lang="EN"
                        >Unethical,
                          exploitative, and malicious activity</span></b></h4>
                      <p><span lang="EN"
                      >Our Products must not be used for the
                        purpose of advertising, transmitting, or otherwise making available any software, program, product, or service
                        designed to violate this acceptable use policy, or the acceptable use policy of other service providers. This
                        includes but isn’t limited to facilitating the means to send spam and the initiation of network sniffing,
                        pinging, packet spoofing, flooding, mail-bombing, and denial-of-service attacks.</span></p>
                      <p><span lang="EN"
                      >Our Products must not be used to access any
                        account or electronic resource where the group or individual attempting to gain access does not own or is not
                        authorized to access the resource (e.g. “hacking”, “cracking”, “phreaking”, etc.).</span></p>
                      <p><span lang="EN"
                      >Our Products must not be used for the
                        purpose of intentionally or recklessly introducing viruses or malicious code into our Products and
                        systems.</span></p>
                      <p><span lang="EN"
                      >Our Products must not be used for purposely
                        engaging in activities designed to harass another group or individual. Our definition of harassment includes
                        but is not limited to denial-of-service attacks, hate-speech, advocacy of racial or ethnic intolerance, and any
                        activity intended to threaten, abuse, infringe upon the rights of, or discriminate against any group or
                        individual.</span></p>
                      <p><span lang="EN"
                      >Other activities considered unethical,
                        exploitative, and malicious include:</span></p>
                      <ol start="1" type="1">
                        <li><span lang="EN" >Obtaining
                          (or attempting to obtain) services from us with the intent to avoid payment;</span><span lang="EN"></span>
                        </li>
                        <li><span lang="EN" >Using our
                          facilities to obtain (or attempt to obtain) services from another provider with the intent to avoid
                          payment;</span><span lang="EN"></span></li>
                        <li><span lang="EN" >The
                          unauthorized access, alteration, or destruction (or any attempt thereof) of any information about our
                          customers or end-users, by any means or device;</span><span lang="EN"></span></li>
                        <li><span lang="EN" >Using our
                          facilities to interfere with the use of our facilities and network by other customers or authorized
                          individuals;</span><span lang="EN"></span></li>
                        <li><span lang="EN"
                        >Publishing or transmitting any content of
                          links that incite violence, depict a violent act, depict child pornography, or threaten anyone’s health and
                          safety;</span><span lang="EN"></span></li>
                        <li><span lang="EN" >Any act
                          or omission in violation of consumer protection laws and regulations;</span><span lang="EN"></span></li>
                        <li><span lang="EN"
                        >Any violation of a person’s
                          privacy.</span><span lang="EN"></span></li>
                      </ol>
                      <p><span lang="EN"
                      >Our Products may not be used by any person
                        or entity, which is involved with or suspected of involvement in activities or causes relating to illegal
                        gambling; terrorism; narcotics trafficking; arms trafficking or the proliferation, development, design,
                        manufacture, production, stockpiling, or use of nuclear, chemical or biological weapons, weapons of mass
                        destruction, or missiles; in each case including any affiliation with others whatsoever who support the above
                        such activities or causes.</span></p>
                      <h4
                      >
                        <a name="_8j3i2kntwyzk"></a><b><span lang="EN"
                        >Unauthorized
                          use of Zvonr.com property</span></b></h4>
                      <p><span lang="EN"
                      >We prohibit the impersonation of Zvonr.com,
                        the representation of a significant business relationship with Zvonr.com, or ownership of any Zvonr.com
                        property (including our Products and brand) for the purpose of fraudulently gaining service, custom, patronage,
                        or user trust.</span></p>
                      <h3><a
                        name="_mb85abfera08"></a><b><span lang="EN"
                        >About this policy</span></b></h3>
                      <p><span lang="EN"
                      >This policy outlines a non-exclusive list of
                        activities and intent we deem unacceptable and incompatible with our brand.</span></p>
                      <p><span lang="EN"
                      >We reserve the right to modify this policy
                        at any time by publishing the revised version on our website. The revised version will be effective from the
                        earlier of:</span></p>
                      <p>
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >the date the
                          customer uses our Products after we publish the revised version on our website; or</span><span
                            lang="EN"></span>
                      </p>
                      <p
                      >
                        <span lang="EN" >●<span
                        >&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </span></span>
                        <span lang="EN" >30 days after we
                          publish the revised version on our website</span><span lang="EN"></span>
                      </p>
                      <p> </p>
                      <p><span lang="EN">&nbsp;</span></p>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </section>
      </>

    )
  }
}
export default ZonvrTermsMobile