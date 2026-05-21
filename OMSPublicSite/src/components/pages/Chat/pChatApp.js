import React from 'react';
import { Helmet } from 'react-helmet';
import Footer from '../../core/Footer/Footer';
import Header from '../../core/Header/Header';
import App from '../../customControls/Chat/App';

class ChatApp extends React.Component {
  constructor() {
    super();
  }

  componentDidMount() {}

  render() {
    return (
      <div className="page-wrapper">
        <Helmet>
          <title>Zvonr - Chat</title>
        </Helmet>
        <Header />
        <main className="main home" style={{ padding: '25px' }}>
          <div className="container">
            <div className="page-wrapper">
              <div className="mainsliwrapper">
                <div className="heading">
                  <div className="row">
                    <div className="col-md-6 col-sm-12">
                      <h2 className="title">Chat</h2>
                    </div>
                  </div>
                </div>
                <App />
              </div>
            </div>
          </div>
        </main>
        <Footer />
      </div>
    );
  }
}

export default ChatApp;
