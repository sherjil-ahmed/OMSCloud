import React from 'react';
import Main from './components/Main';
// import MobileMenu from './components/Mobmenu';
import MobileMenu from './components/MobmenuNew';
import { getStorageItem, setStorageItem } from './utils/storageHelper';
import izitoast from 'izitoast';
import 'izitoast/dist/css/iziToast.css';
import {
  PROFILE_ID,
  APP_ICONS,
  COLOR,
  INPROC_CHATID,
  USER_PROFILE,
  SIZE
} from './utils/constants';
import { baseUrl_API } from './utils/serviceHelper';
// import {Translator, Translate} from 'react-auto-translate';

// const cacheProvider = {
//   get: (language, key) =>
//     ((JSON.parse(localStorage.getItem('translations')) || {})[key] || {})[
//       language
//     ],
//   set: (language, key, value) => {
//     const existing = JSON.parse(localStorage.getItem('translations')) || {
//       [key]: {},
//     };
//     existing[key] = {...existing[key], [language]: value};
//     localStorage.setItem('translations', JSON.stringify(existing));
//   },
// };

class App extends React.Component {
  constructor() {
    super();
  }

  componentDidMount() {
    window.startWebSocketConnection(
      baseUrl_API,
      getStorageItem(PROFILE_ID),
      (msg) => {
              izitoast.destroy();
      izitoast.show({

          title: '',
          icon: APP_ICONS.SUCCESS,
          message: msg.Message,
          //position : APP_TOAST_POSITION.BOTTOM_CENTER,
          target: '.testtarget',
          color: COLOR.GREEN,
          messageSize: SIZE.FONT_SIZE
        });

        let sessionProfileObj = getStorageItem(USER_PROFILE);
        if (sessionProfileObj) {
          if (msg.SenderProfileID) {
            sessionProfileObj.UnreadMessageCount =
              sessionProfileObj.UnreadMessageCount + 1;
          }
        }
        setStorageItem(USER_PROFILE, sessionProfileObj);
        window.exposeUserHeader(sessionProfileObj);

        if (Notification.permission == 'granted') {
          navigator.serviceWorker.getRegistration().then((reg) => {
            let n = new window.Notification(msg.Message);
            
            n.onclick = () => {
              if (msg.NotificationType == '2') {
                setStorageItem(INPROC_CHATID, {
                  chatId: msg.ChatID,
                  profileId: msg.SenderProfileID,
                });
                setTimeout(() => {
                  window.location.href = '/chat';
                  n.close();
                }, 1000);
              }
            };
          });
        }
      },
    );

    //window.appendTranslateScripts();
    //window.RegisterServiceWorker();
    try{
      window.RequestNotificationPermission();
    }
    catch(error){
      console.log(error.message);
    }
  }

  componentDidUpdate() {}

  render() {
    return (
      // <Translator
      //     cacheProvider={cacheProvider}
      //     to="fr"
      //     from="en"
      //     googleApiKey="AIzaSyDNF6Mz9BpfL4PZxYRgbZkJWCtCyD4i7k8"
      // >
      // </Translator>
      <>
        <Main />
        <MobileMenu/>
      </>
      
    );
  }
}
export default App;
