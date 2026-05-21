import { React, Component } from 'react';
import { Translator, Translate } from 'react-auto-translate';

class H1 extends Component {
  constructor(props) {
    super(props);
  }

  componentDidMount() {}

  render() {
    return (
      <h1>
        <Translate>{this.props.children}</Translate>
      </h1>
    );
  }
}

export default H1;
