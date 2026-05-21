//simple abstraction

export const getStorageItem = function (key) {
  let temp = window.localStorage.getItem(key);
  if (isJson(temp)) {
    temp = JSON.parse(temp);
  }

  return temp;
};

export const setStorageItem = function (key, value) {
  if (typeof value == 'object') {
    value = JSON.stringify(value);
  }
  window.localStorage.setItem(key, value);
};

export const pushToStorageItem = function (key, value) {
  //let items = []; // items is array
  // Get the existing data
  let existing = [];
  existing = getStorageItem(key) ? getStorageItem(key) : [];
  existing.push(value);
  
  // Save back to localStorage
  setStorageItem(key, existing);
};

export const removeStorageItem = function (key) {
  window.localStorage.removeItem(key);
};

export const clearStorage = function () {
  window.localStorage.clear();
};

const isJson = function (str) {
  try {
    JSON.parse(str);
  } catch (e) {
    return false;
  }
  return true;
};
