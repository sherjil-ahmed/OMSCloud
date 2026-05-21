import React from 'react';
import WizardHeader from './WizardHeader';
import WizardFooter from './WizardFooter';
import { getStorageItem } from '../../../utils/storageHelper';
import {
  SUPPLIER_NAME, REQUEST_TYPE,SUPPLIER_ID,
  SERVICE_ENDPOINTS,PROFILE_ID
} from '../../../utils/constants';
import { ProductnShopStatus, DeliveryOptionEnum } from '../../../utils/enums';
import { FetchData, baseUrlImage } from '../../../utils/serviceHelper';
import ShopAddress from '../../pages/CreateShop/cShopAddress';

class Wizard extends React.Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {
    //set first step as active when initialized
    this.setStepasActive(this.props.steps[0].name);
  }

  setStepasActive = (item) => {
    //disabling wizard jump from header
    this.props.setActiveStep(item.name, item.rank);
  };

  renderStepComp = () => {
    let item = this.props.steps.find((a) => a.name == this.props.activeStep);
    let shopName = getStorageItem(SUPPLIER_NAME);
    let IsProductWizard = this.props.wizardForProduct;
    let status = Object.keys(ProductnShopStatus).find(
      (key) => ProductnShopStatus[key] === this.props.statusID,
    );
    if (item && item.component) {
      return (
        <div className="mainsliwrapper">
          <div className="heading">
            <div className="row">
              <div className="col-md-6 col-sm-12">
                <h2 className="title">{item.title}</h2>
                
                {
                  shopName != null?(
                IsProductWizard != null ? (
                  <h4>
                    Shop: {shopName}
                    &nbsp;&nbsp;&nbsp; Product Name : {
                      this.props.productName
                    }{' '}
                    &nbsp;&nbsp;&nbsp; Status: {status}
                  </h4>
                ) : (
                  <h4>
                    Shop: {shopName} &nbsp;&nbsp;&nbsp; Status: {status}
                  </h4>
                )):(<h4></h4>)}
              </div>
              {item.NextPrev(item.name)}
            </div>
          </div>
          {item.component}
        </div>
      );
    } else {
      return <div></div>;
    }
  };

  render() {
    return (
      <div className="page-wrapper">
        <WizardHeader
          activeStep={this.props.activeStep}
          steps={this.props.steps}
          completedsteps={this.props.completedsteps}
          setStepasActive={this.setStepasActive}
        />
        {this.renderStepComp()}
        {/* <WizardFooter/> */}
      </div>
    );
  }
}

export default Wizard;
