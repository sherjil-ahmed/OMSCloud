import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import { FetchData, set_baseUrl_API } from './utils/serviceHelper';
import {
  set_countries,
  set_allLanguages,
  set_appSocials,
  set_default_currency,
  set_default_language,
  set_default_strings,
  set_slider_speed,
} from './utils/globalConstants';
import { clearStorage, getStorageItem } from './utils/storageHelper'
import moment from 'moment';
import { LAST_CAT_FETECHED_DATETIME, REQUEST_TYPE, SERVICE_ENDPOINTS } from './utils/constants';

window.GetConfiguration();

document.addEventListener('configLoaded', () => {
  console.log('the config is now loaded');

  set_baseUrl_API(window.appConfig.baseUrl_API);
  set_countries(window.appConfig.countries);
  set_allLanguages(window.appConfig.allLanguages);
  set_appSocials(window.appConfig.appSocials);
  set_default_currency(window.appConfig.default_currency);
  set_default_language(window.appConfig.default_language);
  set_default_strings(window.appConfig.default_strings);
  set_slider_speed(window.appConfig.slider_speed);

  ReactDOM.render(
    <React.StrictMode>
      <App />
    </React.StrictMode>,
    document.getElementById('root'),
  );

  let minifyScript = document.createElement('script')
  minifyScript.src = 'assets/js/main-unminify.js'
  document.getElementsByTagName('body')[0].appendChild(minifyScript)
});

var myTimer;
(function () {
  myTimer = setInterval(() => {
    // console.log('Called from interval at', moment().format("DD/MM/YYYY HH:mm:ss"))
    // console.log('lastCatFetchedDateTime', getStorageItem(LAST_CAT_FETECHED_DATETIME))
    // console.log("moment object", moment(getStorageItem(LAST_CAT_FETECHED_DATETIME), "DD/MM/YYYY HH:mm:ss"))
    // console.log("diff", moment().diff(moment(getStorageItem(LAST_CAT_FETECHED_DATETIME), "DD/MM/YYYY HH:mm:ss"), 'minutes'))
    if (moment().diff(moment(getStorageItem(LAST_CAT_FETECHED_DATETIME), "DD/MM/YYYY HH:mm:ss"), 'minutes') > 1) {
      FetchData(
        REQUEST_TYPE.GET,
        SERVICE_ENDPOINTS.Category_GetCategoryList,
        null,
        (res) => { 
          if(window.exposeMobileMenuComp)
            window.exposeMobileMenuComp.successGetCategoryList(res)
          
          if(window.exHeaderComp)
            window.exHeaderComp.successGetCategoryList(res)
         },
      );
    }
  }, 10000) //in miliseconds
})();

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
