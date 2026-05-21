import React from 'react';
import { PROFILE_ID } from '../../../../utils/constants';
import { getStorageItem } from '../../../../utils/storageHelper';
import './Compose.css';
import moment from 'moment';

class Compose extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      myMessage: '',
    };
  }

  componentDidMount() {
    // Listen for the event.
    window.addEventListener(
      'gotMessage',
      (e) => {
        let newMessage = [
          {
            isMine: e.detail.SenderProfileID == getStorageItem(PROFILE_ID),
            startsSequence: false,
            endsSequence: false,
            showTimestamp: false,
            current: {
              Message: e.detail.Message,
              SentDateTime: e.detail.NotificationTime,
            },
          },
        ];

        this.props.appendNewMessages(newMessage);
      },
      false,
    );
  }

  componentDidUpdate() {}

  render() {
    return (
      <div className="compose">
        <textarea
          type="text"
          className="compose-input"
          placeholder="Type a message.."
          style={{resize: "none"}}
          value={this.state.myMessage}
          onChange={(e) => {
            this.setState(
              {
                myMessage: e.target.value,
              },
              () => {},
            );
          }}
          onKeyUp={(e) => {
            if (e.key == 'Enter') {
              //ChatId={chatId} chatProfileId={chatProfileId}
              window.hub.server.receiveMessage({
                ChatId: this.props.ChatId,
                SenderProfileID: getStorageItem(PROFILE_ID),
                ReceiverProfileID: this.props.chatProfileId,
                Message: this.state.myMessage,
                NotificationType: '2',
              });

              let newMessage = [
                {
                  isMine: true,
                  startsSequence: false,
                  endsSequence: false,
                  showTimestamp: false,
                  current: {
                    Message: this.state.myMessage,
                    SentDateTime: moment().format('YYYY-MM-DDTHH:mm:ss'),
                  },
                },
              ];

              this.props.appendNewMessages(newMessage);

              this.setState({
                myMessage: '',
              });
            }
          }}
        />
        <div className="hidden">
            {this.props.rightItems}
        </div>
      </div>
    );
  }
}

export default Compose;

// export default function Compose(props) {
//     return (
//       <div className="compose">
//         <input
//           type="text"
//           className="compose-input"
//           placeholder="Type a message, @name"
//         />

//         {
//           props.rightItems
//         }
//       </div>
//     );
// }

//
