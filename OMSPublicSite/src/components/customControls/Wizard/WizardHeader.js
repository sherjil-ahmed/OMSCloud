import React from 'react';

class WizardHeader extends React.Component {
  constructor(props) {
    super(props);
  }

  render() {
    return (
      <ul className="checkout-progress-bar" style={{ textAlign: 'center' }}>
        {this.props.steps.map((item, i) => {
          return (
            <li
              key={i}
              className={
                this.props.activeStep == item.name
                  ? 'activeCurrent cursorpointer'
                  : this.props.completedsteps.includes(item.name)
                  ? ' active visited cursorpointer'
                  : 'cursorpointer'
              }
              onClick={() => {
                this.props.setStepasActive(item);
              }}
            >
              <span>{item.name}</span>
            </li>
          );
        })}
      </ul>
    );
  }
}

export default WizardHeader;
