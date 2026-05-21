import izitoast from 'izitoast';
import {
  APP_ICONS,
  APP_TOAST_POSITION,
  GENERIC_ERR_MSG,
  COLOR,
  NETWORK_ERR_MSG,
  PROFILE_ID,
  PREV_AUTH_TOKEN,
  PREV_REFRESH_TOKEN,
  SESSION_TIMEOUT_ERR_MSG,
  IS_AUTH_TOKEN_EXP,
  IS_REFRESH_TOKEN_EXP,
  IS_USER_LOGGEDIN,
  SIZE,
} from './constants';
import { clearStorage, getStorageItem, setStorageItem } from './storageHelper';

export let baseUrl_API = ''; //window.appConfig.baseUrl_API; // "http://localhost:8749";
export let baseUrl = ''; //baseUrl_API + '/api';
export let baseUrlImage = ''; //baseUrl_API + '/DynamicContent/UploadedImages/';

export const set_baseUrl_API = function (val) {
  baseUrl_API = val;
  baseUrl = baseUrl_API + '/api';
  baseUrlImage = baseUrl_API + '/DynamicContent/UploadedImages/';
  //console.log(baseUrl_API);
};

export const FetchData = function (
  reqType,
  reqEP,
  reqData,
  successFunc,
  failFunc,
  successParams,
  failParams,
) {
  console.log(reqEP, JSON.stringify(reqData));
  getToken().then((token) => {
    let settings = {
      url: baseUrl + reqEP,
      method: reqType,
      headers: {
        'Content-Type': 'application/json',
        Authorization: 'Bearer ' + token,
      },
      data: JSON.stringify(reqData),
      success: (res) => {
        window.HideLoader();
        if (successFunc) {
          console.log('these are successparams', successParams, reqEP);
          successFunc(res, successParams);
        }
      },
      error: (xhr, status, error) => {
        console.log('error service xhr', xhr);
        console.log('error service status', status);
        console.log('error service error', error);
        window.HideLoader();
        if (xhr.status == 0) {
                izitoast.destroy();
      izitoast.show({

            title: '',
            icon: APP_ICONS.DANGER,
            message: NETWORK_ERR_MSG,
            //position : APP_TOAST_POSITION.BOTTOM_CENTER,
            target: '.testtarget',
            color: COLOR.RED,
            messageSize: SIZE.FONT_SIZE,
          });
        } else {
          /*      izitoast.destroy();
      izitoast.show({

                        title: '',
                        icon : APP_ICONS.DANGER,
                        message: GENERIC_ERR_MSG,
                        //position : APP_TOAST_POSITION.BOTTOM_CENTER,
                 target : '.testtarget',
                        color : COLOR.RED
                    });*/
        }
        if (
          xhr.status == 400 &&
          Object.keys(xhr.responseJSON).includes('error')
        ) {
          setStorageItem(IS_AUTH_TOKEN_EXP, 'Y');
          FetchData(
            reqType,
            reqEP,
            reqData,
            successFunc,
            failFunc,
            successParams,
            failParams,
          );
        } else if (xhr.status == 401 || xhr.status == 403) {
          setStorageItem(IS_AUTH_TOKEN_EXP, 'Y');
          FetchData(
            reqType,
            reqEP,
            reqData,
            successFunc,
            failFunc,
            successParams,
            failParams,
            );
        } else {
          if (failFunc) {
            failFunc(xhr, failParams);
          }
        }
      },
    };
    /*return*/ window.exJquery.ajax(settings);
  });

  window.ShowLoader();
};

export const FetchData_Override = function (settings) {
  return window.exJquery.ajax(settings);
};

const getAnonymousToken = function () {
  let settings = {
    url: baseUrl + '/Account/GetAnonymousToken/',
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    data: null,
  };
  return window.exJquery.ajax(settings);
};

const getToken = function () {
  return new Promise((resolve, reject) => {
    let authToken = getStorageItem(PREV_AUTH_TOKEN);
    let refreshToken = getStorageItem(PREV_REFRESH_TOKEN);
    let isauthTokenExp = getStorageItem(IS_AUTH_TOKEN_EXP);
    let isrefreshTokenExp = getStorageItem(IS_REFRESH_TOKEN_EXP);
    if (authToken && isauthTokenExp && isauthTokenExp == 'N') {
      resolve(authToken);
    } else if (refreshToken && isrefreshTokenExp && isrefreshTokenExp == 'N') {
      getAuthTokenFromRefreshToken(refreshToken)
        .done((data) => {
          setStorageItem(PREV_AUTH_TOKEN, data.access_token);
          setStorageItem(PREV_REFRESH_TOKEN, data.refresh_token);
          setStorageItem(IS_AUTH_TOKEN_EXP, 'N');
          setStorageItem(IS_REFRESH_TOKEN_EXP, 'N');
          resolve(data.access_token);
        })
        .fail((err) => {
          if (getStorageItem(IS_USER_LOGGEDIN)) {
            console.log('Profile id exists');
            //refresh token has expired, so redirect to login page.
                  izitoast.destroy();
      izitoast.show({

              title: '',
              icon: APP_ICONS.DANGER,
              message: SESSION_TIMEOUT_ERR_MSG,
              //position : APP_TOAST_POSITION.BOTTOM_CENTER,
              target: '.testtarget',
              color: COLOR.RED,
              messageSize: SIZE.FONT_SIZE,
            });
            clearStorage();
            getAnonymousToken().done((data) => {
              setStorageItem(PREV_AUTH_TOKEN, data.access_token);
              setStorageItem(PREV_REFRESH_TOKEN, data.refresh_token);
              setStorageItem(IS_AUTH_TOKEN_EXP, 'N');
              setStorageItem(IS_REFRESH_TOKEN_EXP, 'N');
              setTimeout(() => {
                window.location.href = '/LoginSignup';
              }, 3000);
            });
          } else {
            console.log('Profile id does not exists');
            //Anonymous token
            getAnonymousToken().done((data) => {
              setStorageItem(PREV_AUTH_TOKEN, data.access_token);
              setStorageItem(PREV_REFRESH_TOKEN, data.refresh_token);
              setStorageItem(IS_AUTH_TOKEN_EXP, 'N');
              setStorageItem(IS_REFRESH_TOKEN_EXP, 'N');
              resolve(data.access_token);
            });
          }
        });
    } else {
      if (getStorageItem(IS_USER_LOGGEDIN)) {
        console.log('Profile id exists');
        //proper token
      } else {
        console.log('Profile id does not exists');
        //Anonymous token
        getAnonymousToken().done((data) => {
          setStorageItem(PREV_AUTH_TOKEN, data.access_token);
          setStorageItem(PREV_REFRESH_TOKEN, data.refresh_token);
          setStorageItem(IS_AUTH_TOKEN_EXP, 'N');
          setStorageItem(IS_REFRESH_TOKEN_EXP, 'N');
          resolve(data.access_token);
        });
      }
    }
  });
};

const getAuthTokenFromRefreshToken = function (refreshToken) {
  return window.exJquery.ajax({
    url: baseUrl_API + '/token',
    method: 'POST',
    data: {
      grant_type: 'refresh_token',
      refresh_token: refreshToken,
    },
  });
};
