import React, { useEffect, useState, useRef } from 'react';
import { FetchData } from '../../../../utils/serviceHelper';
import {
  REQUEST_TYPE,
  SERVICE_ENDPOINTS,
  INPROC_CHATID,
  PROFILE_ID,
} from '../../../../utils/constants';
import { getStorageItem } from '../../../../utils/storageHelper';
import ConversationList from '../ConversationList';
import MessageList from '../MessageList';
import './Messenger.css';

export default function Messenger(props) {
  const chatObj = getStorageItem(INPROC_CHATID);
  const messageList = useRef();
  const [chatId, setSelectedChat] = useState(
    chatObj && chatObj.chatId ? chatObj.chatId : '',
  );
  const [chatProfileId, setSelectedChatProfileId] = useState(
    chatObj && chatObj.profileId ? chatObj.profileId : '',
  );
  const [messages, setMessages] = useState([]);

  useEffect(() => {
    messageList.current.scrollTop = messageList.current.scrollHeight + 200;
  }, [messages]);

  useEffect(() => {
    selectedChat(chatId, chatProfileId);
  }, []);

  const appendNewMessages = (message) => {
    setMessages([...messages, ...message]);
  };

  const successChatMessageList = (res) => {
    setMessages(renderMessages(res));
  };

  const renderMessages = (messages) => {
    let i = 0;
    let messageCount = messages.length;
    let tempMessages = [];

    while (i < messageCount) {
      let isMine = messages[i].SenderProfileId == getStorageItem(PROFILE_ID);
      let current = messages[i];

      tempMessages.push({
        isMine: isMine,
        startsSequence: false,
        endsSequence: false,
        showTimestamp: false,
        current: current,
      });

      // Proceed to the next message.
      i += 1;
    }

    return tempMessages;
  };

  const selectedChat = (chatId, profileId) => {
    setSelectedChat(chatId);
    setSelectedChatProfileId(profileId);
    FetchData(
      REQUEST_TYPE.GET,
      SERVICE_ENDPOINTS.ChatMessage_GetChatMessageListByChatId +
        '?Id=' +
        chatId +
        '&ProfileId=' +
        getStorageItem(PROFILE_ID),
      null,
      successChatMessageList,
    );
  };

  return (
    <div className="messenger">
      {/* <Toolbar
          title="Messenger"
          leftItems={[
            <ToolbarButton key="cog" icon="ion-ios-cog" />
          ]}
          rightItems={[
            <ToolbarButton key="add" icon="ion-ios-add-circle-outline" />
          ]}
        /> */}

      {/* <Toolbar
          title="Conversation Title"
          rightItems={[
            <ToolbarButton key="info" icon="ion-ios-information-circle-outline" />,
            <ToolbarButton key="video" icon="ion-ios-videocam" />,
            <ToolbarButton key="phone" icon="ion-ios-call" />
          ]}
        /> */}

      <div className="scrollable sidebar chat-side">
        <ConversationList ChatId={chatId} selectedChat={selectedChat} />
      </div>

      <div className="scrollable content" ref={messageList}>
        <MessageList
          ChatId={chatId}
          chatProfileId={chatProfileId}
          messages={messages}
          appendNewMessages={appendNewMessages}
        />
      </div>
    </div>
  );
}
