//General Constants

//Storage Constants
export const USER_PROFILE = 'UserProfile';
export const PROFILE_ID = 'ProfileID';
export const SUPPLIER_ID = 'SupplierID';
export const SUPPLIER_NAME = 'SupplierName';
export const PRODUCT_ID = 'ProductID';
export const DIRECT_PRODUCTS = 'DirectProducts';
export const LIST_PROVINCES = 'ListProvinces';
export const LIST_CITIES = 'ListCities';
export const SELECTED_LANG = 'selectedLang';
export const SELECTED_PROVINCE = 'SelectedProvince';
export const SELECTED_CITY = 'SelectedCity';
export const LIST_CATEGORY = 'ListCategory';
export const OPEN_FILTER = 'openFilter';
export const ADD_TO_CART = 'CartItems';
export const CART_DETAILS = 'CartDetails';
export const IS_USER_LOGGEDIN = 'IsUserLoggedIn';
export const INPROC_ORDERID = 'InprocessOrderId';
export const INPROC_CHATID = 'InprocessChatId';
export const INPROC_SHIPPING_ORDER = 'InprocessShippingOrder';

export const PREV_AUTH_TOKEN = 'prevAuthToken';
export const IS_AUTH_TOKEN_EXP = 'isAuthTokenExp';
export const PREV_REFRESH_TOKEN = 'prevRefreshToken';
export const IS_REFRESH_TOKEN_EXP = 'isRefreshTokenExp';
export const TEMP_ORDER_LIST_TYPE = 'tempOrderListType';

export const LAST_CAT_FETECHED_DATETIME = 'lastCatFetchedDateTime';

export const RECENTLY_VIEWED_ITEMS = 'recentlyViewedItems';

export const SELECTED_COUNTRY_VALUE = '0';
export const DISPLAY_PAGES = 4;

export const DEFAULT_SEARCH_CONFIG = {
  PAGE: 1,
  ROWS: 50,
  PRODUCTCOUNT_PERPAGE: [10, 25, 50, 100],
};

//Service - Request Types
export const REQUEST_TYPE = {
  GET: 'GET',
  POST: 'POST',
  PUT: 'PUT',
  DELETE: 'DELETE',
};

export const STATUS_CODE = {
  ZERO: 0,
  FIVE: 5,
  SIX: 6,
};

export const APP_ICONS = {
  SUCCESS: '',
    WARNING: '',
    INFO: '',
  DANGER: '',
};

export const COLOR = {
  //RED: 'black',
   RED : '#d77070',
  GREEN: '#5aa958',
  YELLOW: 'yellow',
  BLUE: 'blue',
  WHITE: 'white',
};
export const SIZE = {
  FONT_SIZE: 15,
  Extra_Small: '8px',
  Small: '10px',
  Mediam: '12px',
  Large: '15px',
  Extra_Large: '20px'
};
export const APP_TOAST_POSITION = {
  BOTTOM_CENTER: 'bottomCenter',
};

export const PROFILE_MENU_LIST = [
  {
    Index: 0,
    Name: 'User Profile',
    Path: 'AccountInformation',
  },
  {
    Index: 1,
    Name: 'Privacy & Security',
    Path: 'PrivacyAndSecurity',
  },
  {
    Index: 2,
    Name: 'Address Management',
    Path: 'AddressManagement',
  },
  {
    Index: 3,
    Name: 'View Cart',
    Path: 'ViewCart',
  },
  {
    Index: 4,
    Name: 'New (unpaid) Orders',
    Path: 'Orders',
    enumMap: 101,
  },
  {
    Index: 5,
    Name: 'In Process Orders',
    Path: 'Orders',
    enumMap: 102,
  },
  {
    Index: 6,
    Name: 'Completed Orders',
    Path: 'Orders',
    enumMap: 103,
  },
  {
    Index: 7,
    Name: 'Disputed Orders',
    Path: 'Orders',
    enumMap: 104,
  },
  {
    Index: 8,
    Name: 'Chat',
    Path: 'Chat',
  },
  {
    Index: 9,
    Name: 'Notifications',
    Path: 'Notifications',
  },
  {
    Index: 10,
    Name: 'Reviews',
    Path: 'Reviews',
  },
];

export const SHOP_MENU_LIST = [
  {
    Index: 0,
    Name: 'Shop Profile',
    Path: 'ShopInformation',
  },
  {
    Index: 1,
    Name: 'Manage Shop',
    Path: '/CreateShop',
  },
  {
    Index: 2,
    Name: 'Banking Information',
    Path: 'BankingInfo',
  },
  {
    Index: 3,
    Name: 'Shop Schedule',
    Path: 'ShopSchedule',
  },
  {
    Index: 4,
    Name: 'Shop Calender',
    Path: 'ShopCalender',
  },
  {
    Index: 5,
    Name: 'In Process Orders',
    Path: 'Orders',
    enumMap: 102,
  },
  {
    Index: 6,
    Name: 'Completed Orders',
    Path: 'Orders',
    enumMap: 103,
  },
  {
    Index: 7,
    Name: 'Disputed Orders',
    Path: 'Orders',
    enumMap: 104,
  },
  {
    Index: 8,
    Name: 'Shop Verification',
    Path: 'ShopVerification',
  },
  {
    Index: 9,
    Name: 'Chat',
    Path: 'Chat',
  },
  {
    Index: 10,
    Name: 'Notifications',
    Path: 'Notifications',
  },
];

export const LOGIN_SUCCESS_MSG = 'Login Success';
export const GENERIC_ERR_MSG = 'Something went wrong, please try again later.';
export const NETWORK_ERR_MSG =
  'Something went wrong, please try again later or check your internet connection.';
export const SESSION_TIMEOUT_ERR_MSG =
  'Your session has timed out, please login again';
export const GENERIC_VALIDATION_ERR_MSG = 'Please select all values';

export const SERVICE_ENDPOINTS = {
  LocationTree_GetLocationList: '/LocationTree/GetLocationList/',
  SupplierDelivery_GetSurroundingCities:
    '/SupplierDeliveryOptionPair/GetSurroundingCities/',
  SupplierDelivery_PutSupplierDeliveryOptionList:
    '/SupplierDeliveryOptionPair/PutSupplierDeliveryOptionList/',
  SupplierDelivery_GetSupplierDeliveryOptionBySupplierId:
    '/SupplierDeliveryOptionPair/GetSupplierDeliveryOptionBySupplierId/',
  Product_GetLookupByShopId: '/Product/GetLookupByShopId/',
  Supplier_Put: '/Supplier/Put/',
  Supplier_GetById: '/Supplier/GetById/',
  Supplier_GetByProfileId: '/Supplier/GetSupplierByProfileId/',
  Supplier_Post: '/Supplier/Post/',
  Supplier_GetByName: '/Supplier/GetSupplierByName?supplierName=',
  Address_GetById: '/Address/GetById/',
  Address_Post: '/Address/Post/',
  Address_Put: '/Address/Put/',
  Account_ForgotPassword: '/Account/ForgotPassword/',
  Account_ResendConfirmationEmail: '/Account/ResendConfirmationEmail/',
  Account_UpdatePassword: '/Account/ResetPassword/',
  Account_ConfirmEmail: '/Account/ConfirmEmail/',
  Account_LoginUser: '/Account/LoginUser/',
  Profile_GetProfileByUserName: '/Profile/GetProfileByUserName?userName=',
  Profile_GetProfileByEmail: '/Profile/GetProfileByEmail?eMail=',
  Account_Register: '/Account/Register/',
  Account_RegisterGuest: '/Account/RegisterGuest/',
  ProductAttribute_GetAllAttributesByProductId:
    '/ProductAttributePair/GetAllAttributesByProductId/',
  ProductAttribute_GetAssignedCustomizationAttributesByProductId:
    '/ProductAttributePair/GetAssignedCustomizationAttributesByProductId/',
  ProductAttribute_UpdateIsAssigned: '/ProductAttributePair/UpdateIsAssigned/',
  Category_GetCategoryListLookup: '/Category/GetCategoryListLookup/',
  Category_GetCategoryList: '/Category/GetCategoryList',
  TaxType_GetList: '/TaxType/GetList/',
  Product_GetById: '/Product/GetById/',
  Product_Post: '/Product/Post/',
  Product_Put: '/Product/Put/',
  ProductMediaDetail_PutImage: '/ProductMediaDetail/PutImage/',
  ProductMediaDetail_GetById: '/ProductMediaDetail/GetById/',
  ProductMediaDetail_Post: '/ProductMediaDetail/Post/',
  ProductMediaDetail_Delete: '/ProductMediaDetail/Delete/',
  ProductMediaDetail_PutImageByProductId:
    '/ProductMediaDetail/PutImageByProductId',
  Profile_PutImageByProfileId: '/Profile/PutImageByProfileId',
  Supplier_PutImageByShopId: '/Supplier/PutImageByShopId',
  Product_GetAllNonExistingCategoryList:
    '/Product/GetAllNonExistingCategoryList/',
  Product_UpdatePricing: '/Product/UpdatePricing',
  Product_GetProductDetail: '/Product/GetProductDetail/',
  Product_ProductSearchByPage: '/Product/ProductSearchByPage/',
  ProductType_GetList: '/ProductType/GetList',
  Schedule_Delete: '/Schedule/Delete/',
  Schedule_Put: '/Schedule/Put/',
  Schedule_Post: '/Schedule/Post/',
  Schedule_GetScheduleListBySupplierId:
    '/Schedule/GetScheduleListBySupplierId/',
  Schedule_GetScheduleById: '/Schedule/GetScheduleById/',
  Schedule_GetNextScheduleBySpecificDate:
    '/Schedule/GetNextScheduleBySpecificDate',
  Schedule_GetScheduleByDates: '/Schedule/GetScheduleByDates',
  CartItem_AddToCartByProductId: '/CartItem/AddToCartByProductId',
  CartItem_AddToCartWithAttributesByProductId:
    '/CartItem/AddToCartWithAttributesByProductId',
  PaymentGateway_PayOrder: '/PaymentGateway/PayOrder/',
  PaymentGateway_PayPalExecutePayment: '/PaymentGateway/PayPalExecutePayment/',
  Profile_GetProfileByUserId: '/Profile/GetProfileByUserId/',
  Profile_Post: '/Profile/Post/',
  Address_GetAddressListByProfileid: '/Address/GetAddressListByProfileid/',
  Address_Delete: '/Address/Delete/',
  Cart_GetCartDetailsByProfileId: '/Cart/GetCartDetailsByProfileId/',
  Cart_UpdateCartDetail: '/Cart/UpdateCartDetail/',
  Order_ConvertCartToOrders: '/Order/Sp_ConvertCartToOrders/',
  Order_GetOrderList: '/Order/GetOrderList/',
  Order_GetOrderDetailByOrderId: '/Order/GetOrderDetailByOrderId/',
  Order_UpdateOrderDetail: '/Order/UpdateOrderDetail/',
  Supplier_GetSupplierPublicByProfileId:
    '/Supplier/GetSupplierPublicByProfileId/',
  Supplier_GetSupplierPublic: '/Supplier/GetShopPublicProfile/',
  Supplier_PostSupplierDetails: '/Supplier/PostSupplierDetails/',
  Profile_UpdateProfile_2FA: '/Profile/UpdateProfile_2FA/',
  Account_ChangePassword: '/Account/ChangePassword/',
  Supplier_GetShopPublicList: '/Supplier/GetShopPublicList',
  Product_GetPopularProductList: '/Product/GetPopularProductList/',
  BackAccount_GetBankAccountByShopId: '/BankAccount/GetBankAccountByShopId/',
  BankAccount_AddBankAccount: '/BankAccount/PUT/',
  BankAccount_UpdateBankAccount: '/BankAccount/POST/',
  Supplier_GetCategoryAttributeRequestBySupplierId:
    '/Supplier/GetCategoryAttributeRequestBySupplierId/',
  Supplier_UpdateSupplierCategoryRequests:
    '/Supplier/UpdateSupplierCategoryRequests/',
  Supplier_UpdateSupplierAttributeRequests:
    '/Supplier/UpdateSupplierAttributeRequests/',
  Order_GetNextOrderStatusList: '/Order/GetNextOrderStatusList',
  Chat_InitiateChat: '/Chat/InitiateChat',
  Chat_GetChatListByProfileId: '/Chat/GetChatListByProfileId/',
  ChatMessage_GetChatMessageListByChatId:
    '/ChatMessage/GetChatMessageListByChatId',
  CustomerReview_Put: '/CustomerReview/Put/',
  CustomerReview_GetCustomerReviewList: '/CustomerReview/GetCustomerReviewList',
  Order_UpdateOrderStatus: '/Order/UpdateOrderStatus/',
  Product_GetProductDetailFromShop: '/Product/GetProductDetailFromShop/',
  Notification_GetNotifyList: '/Notification/GetNotifyList/',
  Supplier_GetShopTaxInfo: '/Supplier/GetShopTaxInfo/',
  Supplier_UpdateShopTaxInfo: '/Supplier/UpdateShopTaxInfo/',
  ProfileVerification_GetListForPublic:
    '/ProfileVerification/GetListForPublic/',
  DocumentType_GetList: '/DocumentType/GetList/',
  ProfileVerification_PutForUser: '/ProfileVerification/PutForUser/',
  ProfileVerification_PutVerificationDocument:
    '/ProfileVerification/PutVerificationDocument/',
  ProfileVerification_PostForUser: '/ProfileVerification/PostForUser/',
  ProfileVerification_PostVerificationDocument:
    '/ProfileVerification/PostVerificationDocument/',
  Account_SendContactUsEmail: '/Account/SendContactUsEmail/',
  Profile_Subscribe: '/Profile/Subscribe',
};
