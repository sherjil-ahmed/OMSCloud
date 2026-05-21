import React, { useState, useEffect } from 'react';
import ConversationSearch from '../ConversationSearch';
import ConversationListItem from '../ConversationListItem';
import Toolbar from '../Toolbar';
import ToolbarButton from '../ToolbarButton';
//import axios from 'axios';
import { FetchData, FetchData_Override } from '../../../../utils/serviceHelper';
import {
  getStorageItem,
  setStorageItem,
} from '../../../../utils/storageHelper';
import './ConversationList.css';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  PROFILE_ID,
  USER_PROFILE,
} from '../../../../utils/constants';

//export default function ConversationList(props) {
//const [conversations, setConversations] = useState([]);
//useEffect(() => {
//  getConversations()
//},[])

//const getConversations = () => {
//axios.get('https://randomuser.me/api/?results=20').then();
//   FetchData_Override({
//     url : 'https://randomuser.me/api/?results=20',
//     method : REQUEST_TYPE.GET
//   }).done(response => {
//     let newConversations = response.results.map(result => {
//       return {
//         photo: result.picture.large,
//         name: `${result.name.first} ${result.name.last}`,
//         text: 'Hello world! This is a long message that needs to be truncated.'
//       };
//     });
//     setConversations([...conversations, ...newConversations])
// })

//}

class ConversationList extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      conversations: [],
    };
  }

  successGetChats = (res) => {
    this.setState({
      conversations: res.filter((a) => a.ProfileId1 != a.ProfileId2),
    });
  };

  componentDidMount() {
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.Chat_GetChatListByProfileId +
        getStorageItem(PROFILE_ID),
      null,
      this.successGetChats,
    );
  }

  selectedChat = (ChatId) => {
    let chat = this.state.conversations.find((a) => a.ChatId == ChatId);
    let sessionProfileObj = getStorageItem(USER_PROFILE);
    if (sessionProfileObj) {
      sessionProfileObj.UnreadMessageCount =
        sessionProfileObj.UnreadMessageCount - chat.UnreadMessageCount;
      chat.UnreadMessageCount = 0;
    }
    setStorageItem(USER_PROFILE, sessionProfileObj);
    window.exposeUserHeader(sessionProfileObj);
    this.setState({
      conversations: this.state.conversations,
    });
  };

  render() {
    return (
      <div className="conversation-list">
        <Toolbar
          title="Messenger"
          leftItems={[<ToolbarButton key="cog" icon="ion-ios-cog" />]}
          rightItems={[
            <ToolbarButton key="add" icon="ion-ios-add-circle-outline" />,
          ]}
        />
        {/* <ConversationSearch /> */}
        {this.state.conversations.map((conversation) => (
          <ConversationListItem
            key={conversation.ProfileId2}
            data={conversation}
            selectedChat={this.props.selectedChat}
            selectedChat_Interim={this.selectedChat}
            ChatId={this.props.ChatId}
          />
        ))}
      </div>
    );
  }
}

export default ConversationList;
