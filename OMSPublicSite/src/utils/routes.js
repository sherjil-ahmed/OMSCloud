import ViewMain from '../components/ViewMain';
import CreateShop from '../components/pages/CreateShop/pCreateShop';
import ProductListing from '../components/pages/ProductListing/pProductListing';
import LoginSignUp from '../components/pages/LoginSignUp/pLoginSignUp';
import ForgotPassword from '../components/pages/ForgotPassword/pForgotPassword';
import Profile from '../components/pages/ShopProfile/pProfile';
import UpdatePassword from '../components/pages/UpdatePassword/pUpdatePassword';
import ConfirmEmail from '../components/pages/ConfirmEmail/pConfirmEmail';
import ResendLink from '../components/pages/ResendLink/pResendLink';
import ShopSchedule from '../components/pages/ShopProfile/cShopSchedule';
import ShopSchedulePublic from '../components/pages/ShopSchedule/pShopSchedulePublic';
import EditAccountInformation from '../components/pages/AccountProfile/pAccountSetting';
import ProductSearch from '../components/pages/ProductSearch/pProductSearch';
import ProductDetail from '../components/pages/ProductDetail/pProductDetail';
import PaymentSuccess from '../components/pages/PaymentSuccess/pPaymentSuccess';
import PaymentCancel from '../components/pages/PaymentCancel/pPaymentCancel';
import PaymentSuccessPayPal from '../components/pages/PaymentSuccess/pPaymentSuccessPayPal';
import ShopSettings from '../components/pages/ShopProfile/pShopSettings';
import CartDetail from '../components/pages/CartDetail/pCardDetail';
import OrderDetail from '../components/pages/OrderDetail/pOrderDetail';
import ShippingAndPayment from '../components/pages/ShippingAndPayment/pShippingAndPayment';
import OrderList from '../components/pages/PublicOrderListing/OrderListing';
import ShopDetailPage from '../components/pages/ShopDetailPage/pShopDetailPage';
import ShopSearch from '../components/pages/ShopSearch/pShopSearch';
import PaidOrderDetail from '../components/pages/OrderDetail/pPaidOrderDetail';
import ChatApp from '../components/pages/Chat/pChatApp';
import GuidePage from '../components/pages/GuidePage/pGuidePage';
import GuidePageMobile from '../components/pages/GuidePage/mGuidePage';
import ContactUs from '../components/pages/ContactUsPage/ContactUsPage';
import ContactUsMobile from '../components/pages/ContactUsPage/mContactUsPage';
import ZonvrTerms from '../components/pages/ZonvrTerms/Terms';
import ZonvrTermsMobile from '../components/pages/ZonvrTerms/mTerms';

export const routes = [
  {
    path: '/',
    component: <ViewMain />,
    isAnon: true,
  },
  {
    path: '/home',
    component: <ViewMain />,
    isAnon: true,
  },
  {
    path: '/CreateShop',
    component: <CreateShop />,
    isAnon: false,
  },
  {
    path: '/ProductListing',
    component: <ProductListing />,
    isAnon: false,
  },
  // {
  //     path : '/Profile',
  //     component : ,
  //     isAnon : false
  // },
  // {
  //     path : '/ShopSchedule',
  //     component : ,
  //     isAnon : false
  // },
  // {
  //     path : '/ShopSchedulePublic',
  //     component : ,
  //     isAnon : false
  // },
  {
    path: '/MyAccount',
    component: <EditAccountInformation />,
    isAnon: false,
  },
  {
    path: '/search',
    component: <ProductSearch />,
    isAnon: true,
  },
  {
    path: '/productdetail',
    component: <ProductDetail />,
    isAnon: true,
  },
  {
    path: '/PaymentSuccess',
    component: <PaymentSuccess />,
    isAnon: true,
  },
  {
    path: '/PaymentCancel',
    component: <PaymentCancel />,
    isAnon: true,
  },
  {
    path: '/PaymentResponse',
    component: <PaymentSuccessPayPal />,
    isAnon: true,
  },
  {
    path: '/ShopSettings',
    component: <ShopSettings />,
    isAnon: false,
  },
  {
    path: '/CartDetail',
    component: <CartDetail />,
    isAnon: true,
  },
  {
    path: '/OrderDetail',
    component: <OrderDetail />,
    isAnon: true,
  },
  {
    path: '/Checkout',
    component: <ShippingAndPayment />,
    isAnon: true,
  },
   {
       path : '/OrderList',
       component : <OrderList /> ,
       isAnon : true,
   },
  {
    path: '/ShopDetail',
    component: <ShopDetailPage />,
    isAnon: true,
  },
  {
    path: '/ShopSearch',
    component: <ShopSearch />,
    isAnon: true,
  },
  {
    path: '/PaidOrderDetail',
    component: <PaidOrderDetail />,
    isAnon: true,
  },
  {
    path: '/chat',
    component: <ChatApp />,
    isAnon: false,
  },
  {
    path: '/LoginSignup',
    component: <LoginSignUp />,
    isAnon: true,
  },
  {
    path: '/ForgotPassword',
    component: <ForgotPassword />,
    isAnon: true,
  },
  {
    path: '/UpdatePassword',
    component: <UpdatePassword />,
    isAnon: true,
  },
  {
    path: '/ConfirmEmail',
    component: <ConfirmEmail />,
    isAnon: true,
  },
  {
    path: '/resendlink',
    component: <ResendLink />,
    isAnon: true,
  },
  {
    path: '/GuidePage',
    component: <GuidePage />,
    isAnon: true,
  },
  {
    path: '/GuidePage-mobile',
    component: <GuidePageMobile />,
    isAnon: true,
  },
  {
    path: '/contact-us',
    component: <ContactUs />,
    isAnon: true,
  },
  {
    path: '/contact-us-mobile',
    component: <ContactUsMobile />,
    isAnon: true,
  },  {
    path: '/terms-of-service',
    component: <ZonvrTerms />,
    isAnon: true,
  },
  {
    path: '/terms-of-service-mobile',
    component: <ZonvrTermsMobile />,
    isAnon: true,
  },
];
