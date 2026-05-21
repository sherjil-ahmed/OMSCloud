export const LocationLevelEnum = {
  Country: 1,
  Province: 2,
  City: 3,
  Area: 4,
};

export const DeliveryOptionEnum = {
  SelfPickUp: 1,
  ShopDelivery: 2,
  DeliverSurroundingCities: 3,
  DeliveryAcrossCountry: 4,
};

export const ImageUploadConfig = {
  maxWidth: 2000,
  maxHeight: 2000,
  maxSize: 5000000, //5MB
  allowedTypes: ['image/png', 'image/webp', 'image/jpeg', 'image/jpg'],
};

export const ProductnShopStatus = {
  NEW: 1,
  ACTIVE: 2,
  INACTIVE: 3,
  DELETED: 4,
};
export const ReviewScaleText = {
  1: 'Hated it',
  2: 'Disliked it',
  3: 'It was ok',
  4: 'Liked it',
  5: 'Loved it',
};
export const DBResponseTimeUnitEnum = {
  // Month : { Value: 1, Description : "Months"},
  // Week : { Value: 2, Description : "Weeks"},
  Day: { Value: 3, Description: 'Days' },
  Hour: { Value: 4, Description: 'Hours' },
  Minute: { Value: 5, Description: 'Minutes' },
};

export const SortByEnum = {
  None: { value: -1, text: 'Default sorting' },
  UserRating: { value: 6, text: 'By Popularity' },
  ProductTitle: { value: 2, text: 'By Product Name' },
  Shop: { value: 4, text: 'By Shop' },
  MinPrice: { value: 1, text: 'Sort by price: low to high' },
  MaxPrice: { value: 3, text: 'Sort by price: high to low' },
};

export const PaymentMethod = {
  CASH: 1,
  STRIPE: 2,
  PAYPAL: 3,
};

export const OrderListingType = {
  New: 101,
  Inprogress: 102,
  Completed: 103,
  Failed: 104,
};

export const ImageEntityEnum = {
  PRODUCT: 'ProductMediaDetail',
  USER: 'Profile',
  SUPPLIER: 'Supplier',
  PROFILEVERIFICATION : 'ProfileVerification'
};

export const RatingSubject = {
  PRODUCT: { text: 'Product', value: 1 },
  SHOP: { text: 'Shop', value: 2 },
  ORDER: { text: 'Order', value: 3 },
};

export const NotificationTypes = {
  General: 1,
  Chat: 2,
  Order: 3,
  Review: 4,
  Shop: 5,
  Product: 6,
  CacheRebuild: 7,
  BackgroundService: 8,
};
export const AddressTypeID = {
  ShopAddressType: 1,
  DeliveryAddressType: 2,
};

export const SubjectID = {
  1 : "Shop",
  2 : "Product"
};


         