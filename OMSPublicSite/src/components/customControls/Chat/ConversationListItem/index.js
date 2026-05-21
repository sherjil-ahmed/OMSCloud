import React, { useEffect, useRef } from 'react';
import { INPROC_CHATID, PROFILE_ID } from '../../../../utils/constants';
import { ImageEntityEnum } from '../../../../utils/enums';
import { baseUrlImage } from '../../../../utils/serviceHelper';
import { getStorageItem } from '../../../../utils/storageHelper';
//import shave from 'shave';

import './ConversationListItem.css';

export default function ConversationListItem(props) {
  const imgConversation = useRef();
  useEffect(() => {
    //shave('.conversation-snippet', 20);
  });
  
  let id =
    props.data.ProfileId1 == getStorageItem(PROFILE_ID)
      ? props.data.ProfileId2
      : props.data.ProfileId1;
  let name =
    props.data.ProfileId1 == getStorageItem(PROFILE_ID)
      ? props.data.ProfileId2_Name
      : props.data.ProfileId1_Name;
  let photo =
    props.data.ProfileId1 == getStorageItem(PROFILE_ID)
      ? props.data.ProfileId2_Image
      : props.data.ProfileId1_Image;
  //let text = (props.data.ProfileId1 == getStorageItem(PROFILE_ID))? props.data.ProfileId2_Name : props.data.ProfileId1_Name

  return (
    <div
      onClick={(e) => {
        props.selectedChat(props.data.ChatId, id);
        props.selectedChat_Interim(props.data.ChatId);
      }}
      className={
        props.data.ChatId == props.ChatId
          ? 'conversation-list-item active'
          : 'conversation-list-item'
      }
    >
      <img
        className="conversation-photo"
        ref={imgConversation}
        src={baseUrlImage + ImageEntityEnum.USER + '/' + id + '/' + photo}
        onError={() => {
          imgConversation.current.src =
            'http://www.pngall.com/wp-content/uploads/5/User-Profile-PNG-High-Quality-Image.png';
        }}
        alt="conversation"
      />
      <div className="conversation-info">
        <h1 className="conversation-title">{name}</h1>
      </div>
      {props.data &&
      props.data.UnreadMessageCount &&
      parseInt(props.data.UnreadMessageCount) > 0 ? (
        <div>
          <span
            className="badge bg-warning"
            style={{ marginLeft: '5px', zoom: '122%', float: 'right' }}
          >
            {props.data.UnreadMessageCount}
          </span>
        </div>
      ) : (
        <></>
      )}
    </div>
  );
}
