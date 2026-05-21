import React, { useEffect, useState } from 'react';
import Compose from '../Compose';
import Toolbar from '../Toolbar';
import ToolbarButton from '../ToolbarButton';
import Message from '../Message';
import moment from 'moment';

import './MessageList.css';
import { PROFILE_ID } from '../../../../utils/constants';
import { getStorageItem } from '../../../../utils/storageHelper';

const MY_USER_ID = 'apple';

export default function MessageList(props) {
  useEffect(() => {
    getMessages();
  }, []);

  const getMessages = () => {};

  return (
    <div className="message-list">
      <Toolbar
        title="Conversation Title"
        rightItems={[
          <ToolbarButton
            key="info"
            icon="ion-ios-information-circle-outline"
          />,
          <ToolbarButton key="video" icon="ion-ios-videocam" />,
          <ToolbarButton key="phone" icon="ion-ios-call" />,
        ]}
      />

      <div className="message-list-container">
        {props.messages.map((data, i) => (
          <Message
            key={i}
            isMine={data.isMine}
            startsSequence={data.startsSequence}
            endsSequence={data.endsSequence}
            showTimestamp={data.showTimestamp}
            data={data.current}
          />
        ))}
      </div>
      {(() => {
        if (props.ChatId && props.chatProfileId != getStorageItem(PROFILE_ID)) {
          return (
            <Compose
              ChatId={props.ChatId}
              chatProfileId={props.chatProfileId}
              appendNewMessages={props.appendNewMessages}
              rightItems={[
                <ToolbarButton key="photo" icon="ion-ios-camera" />,
                <ToolbarButton key="image" icon="ion-ios-image" />,
                <ToolbarButton key="audio" icon="ion-ios-mic" />,
                <ToolbarButton key="money" icon="ion-ios-card" />,
                <ToolbarButton key="games" icon="ion-logo-game-controller-b" />,
                <ToolbarButton key="emoji" icon="ion-ios-happy" />,
              ]}
            />
          );
        }
      })()}
    </div>
  );
}
