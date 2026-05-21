import React from 'react';
import { REQUEST_TYPE, SERVICE_ENDPOINTS } from '../../../utils/constants';
import { FetchData } from '../../../utils/serviceHelper';

const enPARENT = {
  SUPPLIER: 'Supplier',
};

class ShopBasic extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      Availability: '',
      color: '',
    };
  }

  componentDidMount() {
    window.scrollTo(0, 0);
  }

  handleChange = (e) => {
    let _state = this.props.parentState.Supplier;

    _state[e.target.name] = e.target.value;
    this.props.setValues(enPARENT.SUPPLIER, _state);
  };

  successGetSupplierByName = (res) => {
    let NameAvailability, Color;
    if (res == false) {
      NameAvailability = 'Name is available';
      Color = 'Green';
    } else if (res == true) {
      NameAvailability = 'Name is not available';
      Color = 'Red';
    }
    this.setState({
      Availability: NameAvailability,
      color: Color,
    });
  };

  CheckAvailability = () => {
    var strName  = this.props.parentState.Supplier.SupplierName;
    if(strName && strName.trim() !== "")
    {
      FetchData(
        REQUEST_TYPE.GET,
        SERVICE_ENDPOINTS.Supplier_GetByName +
          this.props.parentState.Supplier.SupplierName,
        null,
        this.successGetSupplierByName,
      );
    }
  };

  render() {
    let _state = this.props.parentState.Supplier;
    return (
      <div className="body">
        <div className="row">
          <div className="col-md-12 col-sm-12">
            <div className="row">
              <div className="col-md-8">
                <label>
                  Shop Name<span style={{ color: 'red' }}>*</span>
                </label>
                <input
                  name="SupplierName"
                  type="text"
                  maxLength = "200"
                  className="form-control"
                  placeholder="Shop Name"
                  onChange={this.handleChange}
                  value={_state.SupplierName}
                />
                <label style={{ color: this.state.color }}>
                  {this.state.Availability}
                </label>
              </div>
              <div className="col-md-4 epadi">
                <button
                  onClick={this.CheckAvailability}
                  type="button"
                  className="btn btn-outline-dark custom-btn prebtn"
                >
                  Check Availability
                </button>
              </div>
            </div>
            <div className="row">
              <div className="col-md-12">
                <label>
                  Shop Description<span style={{ color: 'red' }}>*</span>
                </label>
                <textarea
                  name="Description"
                  type="text"
                  className="form-control"
                  placeholder="Description"
                  cols={10}
                  rows={1}
                  onChange={this.handleChange}
                  value={_state.Description}
                />
              </div>
            </div>
          </div>
        </div>
      </div>
    );
  }
}

export default ShopBasic;
