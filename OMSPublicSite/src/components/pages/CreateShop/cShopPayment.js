import React from 'react';

const enPARENT = {
  SUPPLIER: 'Supplier',
};

class ShopPayment extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      paypal: true,
      creditcard: true,
    };
  }

  componentDidMount() {}

  handleChangeCheckbox = (e) => {
    let temp = this.state[e.target.name];
    let _state = this.props.parentState.Supplier;
    switch (e.target.name) {
      case 'cashpayment':
        _state.IsCOD = e.target.checked;
        this.props.setValues(enPARENT.SUPPLIER, _state);
        break;
    }
  };

  render() {
    let _state = this.props.parentState.Supplier;
    return (
      <div className="body">
        <div className="row">
          <div className="col-sm-12 npad">
            <ul className="ks-cboxtags stacked">
              <li>
                <input
                  checked={_state.IsCOD}
                  id="cashpayment"
                  onChange={this.handleChangeCheckbox}
                  name="cashpayment"
                  type="checkbox"
                  className="custom-control-input"
                  value={_state.IsCOD}
                />
                <label
                  className="cash_payment"
                  htmlFor="cashpayment"
                  style={{ marginBottom: '5px' }}
                >
                  Cash Payment
                  <span className="hidden">
                    <img src="assets/images/logos/cashpng.png" />
                  </span>
                </label>
              </li>
              <li>
                <input
                  checked={this.state.paypal}
                  disabled={true}
                  id="paypal"
                  onChange={this.handleChangeCheckbox}
                  name="paypal"
                  type="checkbox"
                  className="custom-control-input"
                  value={this.state.paypal}
                />
                <label
                  className="db pay_pal"
                  htmlFor="paypal"
                  style={{ marginBottom: '5px' }}
                >
                  PayPal
                  <span className="hidden">
                    <img src="assets/images/logos/paypalpng.png" />
                  </span>
                </label>
              </li>
              <li>
                <input
                  checked={this.state.creditcard}
                  disabled={true}
                  id="creditcard"
                  onChange={this.handleChangeCheckbox}
                  name="creditcard"
                  type="checkbox"
                  className="custom-control-input"
                  value={this.state.creditcard}
                />
                <label className="db credit_card" htmlFor="creditcard">
                  Credit Card
                  <span className="hidden">
                    <img src="assets/images/logos/paymentspng.png" />
                  </span>
                </label>
              </li>
            </ul>
          </div>
          {/* End .row */}
          <label             style={{
              fontWeight: '500',
              marginBottom: '5px',
              textAlign: 'left',
              fontSize: '24px',
            }}>
          Pre-payment with credit/debit card is more secure for the shop as compare to to cash payment on delivery. But cash payment has NO transaction fee.
          </label>
        </div>
      </div>
    );
  }
}

export default ShopPayment;
