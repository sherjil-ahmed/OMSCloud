using OMSCloud.Contracts.Common.DBEnums;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace OMSCloud.Contracts.Common.ConfigMgmt
{
    public partial class Config
    {
        public static string Origins { get => GetConfig("origins", ""); }
        public static bool IsSecure{ get => GetConfig("IsSecure", false); }

        public static string PublicSiteURL { get => GetConfig("PublicSiteURL", ""); }

        public static string SmtpPassword { get => GetConfig("SmtpPassword", ""); }
        public static string SupportEmail { get => GetConfig("SupportEmail", "support@zvonr.com"); }
            
        public static string StripeApiKey { get => GetConfig("StripeApiKey", ""); }
            
        public static string StripeSecretKey { get => GetConfig("StripeSecretKey", ""); }
            
        public static string PayPalclientId { get => GetConfig("PayPalclientId", ""); }
            
        public static string PayPalclientSecret { get => GetConfig("PayPalclientSecret", ""); }

        public static bool Mode { get => GetConfig("PayPalModeIsLive", false); }
            
        public static string TwilioAccountSID { get => GetConfig("TwilioAccountSID", ""); }
            
        public static string TwilioAuthToken { get => GetConfig("TwilioAuthToken", ""); }
            
        public static string WebAPIAnonymousUser { get => GetConfig("WebAPIAnonymousUser", ""); }
            
        public static string WebAPIAnonymousUserPassword { get => GetConfig("WebAPIAnonymousUserPassword", ""); }
            
        public static string MarketPlaceProfileID { get => GetConfig("MarketPlaceProfileID", ""); }

        public static string TwilioNumber { get => GetConfig("TwilioNumber", ""); }

        public static string WebAPIUser { get => GetConfig("WebAPIUser", ""); }
        public static string FirebaseAppKey { get => GetConfig("FirebaseAppKey", ""); }
        

        public static string WebAPIUserPassword { get => GetConfig("WebAPIUserPassword", ""); }
        
        public static int NewUserThresholdDays { get => GetConfig("NewUserThresholdDays", 7); }
        public static int InactiveShopDays { get => GetConfig("InactiveShopDays", 30); }
        public static bool IsEncryption { get => GetConfig("IsEncryption", true); }

        public static string DefaultCountry { get => GetConfig("DefaultCountry", "Canada"); }
        public static string CountrySelectionConfig { get => GetConfig("CountrySelectionConfig", "Canada,https://zvonr.ca:7072/api/,$,CAD,Canadian Dollar; UK,https://zvonr.co.uk:7073/api/,£,GBP,British Pound; USA,https://zvonr.us:7074/api/,$,USD,US Dollar"); }
        public static string WebAPIHost_Default
        {
            get { return GetWebAPIHost(DefaultCountry); }
        }
        public static string GetWebAPIHost(string CountryName)
        {
            return GetConfig("WebAPIHost_" + CountryName, "http://localhost:8749");
        }
        public static string WebAPIHost_Canada { get => GetConfig("WebAPIHost_Canada", "http://localhost:8749"); }
        public static string WebAPIHost_USA { get => GetConfig("WebAPIHost_USA", "http://localhost:8749"); }
        public static string WebAPIHost_UK { get => GetConfig("WebAPIHost_UK", "http://localhost:8749"); }
        public static string WebAPIHost_Australia { get => GetConfig("WebAPIHost_Australia", "http://localhost:8749"); }
        public static string DynamicContent { get => GetConfig("DynamicContent", "/DynamicContent/UploadedImages/"); }
        public static string WebApi_ProductImages { get => GetConfig("WebApi_ProductImages", "/DynamicContent/UploadedImages/"); }
        public static string WebApi_CategoryImages { get => GetConfig("WebApi_CategoryImages", "/DynamicContent/UploadedImages/"); }
        //public static string WebAPIUser { get => GetConfig("WebAPIUser", "admin"); }
        //public static string WebAPIUserPassword { get => GetConfig("WebAPIUserPassword", "T@rgetLive01"); }
        public static ConnectionStringConfig OMSContextConnectionConfig
        {
            get {
                var ConnConfg = new ConnectionStringConfig() { ConnectionString = string.Empty, KeyUsed = string.Empty, IsDefault = false};
                ConnConfg.ConnectionString = GetConnectionString(Environment.MachineName, "");
                if (!string.IsNullOrEmpty(ConnConfg.ConnectionString))
                {
                    ConnConfg.IsDefault = false;
                    ConnConfg.KeyUsed = Environment.MachineName;
                }
                else
                {
                    ConnConfg.ConnectionString = GetConnectionString("OMSContext", "");
                    if (!string.IsNullOrEmpty(ConnConfg.ConnectionString))
                    {
                        ConnConfg.IsDefault = true;
                        ConnConfg.KeyUsed = "OMSContext";
                    }
                }

                bool isEncryption = IsEncryption;
                if(isEncryption)
                    ConnConfg.ConnectionString = CommonUtilities.Decrypt(ConnConfg.ConnectionString);

                return ConnConfg;
            }
        }
    }

    public partial class AppSession
    {
        public static Dictionary<long, string> appConfigDictionary = new Dictionary<long, string>();

        public static string SMTPServer { get { return (string)appConfigDictionary[(int)DBAppConfigEnum.SMTPServer]; } }
        public static long CountryID { get { return Convert.ToInt64(appConfigDictionary[(int)DBAppConfigEnum.CountryID]); } }
        public static string CountryName { get { return (string)appConfigDictionary[(int)DBAppConfigEnum.CountryName]; } }        
        public static string CurrencyName { get { return (string)appConfigDictionary[(int)DBAppConfigEnum.CurrencyName]; } }
        public static string CurrencyCode { get { return (string)appConfigDictionary[(int)DBAppConfigEnum.CurrencyCode]; } }
        public static string CurrencySymbol { get { return (string)appConfigDictionary[(int)DBAppConfigEnum.CurrencySymbol]; } }
        public static string LanguageName { get { return (string)appConfigDictionary[(int)DBAppConfigEnum.LanguageName]; } }
        public static string LanguageCode { get { return (string)appConfigDictionary[(int)DBAppConfigEnum.LanguageCode]; } }
        public static float ZvonrProcessingFee { get { return Convert.ToInt64(appConfigDictionary[(int)DBAppConfigEnum.ProcessingFee]); } }
        public static bool IsProcessingFeePercentage { get { return Convert.ToBoolean(appConfigDictionary[(int)DBAppConfigEnum.IsProcessingFeePercentage]); } }
        public static float PaymentGatewayFee { get { return Convert.ToInt64(appConfigDictionary[(int)DBAppConfigEnum.PaymentGatewayFee]); } }
        public static bool IsPaymentGatewayFeePercentage { get { return Convert.ToBoolean(appConfigDictionary[(int)DBAppConfigEnum.IsPaymentGatewayFeePercentage]); } }
        public static long CurrencyID { get { return Convert.ToInt64(appConfigDictionary[(int)DBAppConfigEnum.CurrencyID]); } }
        public static long LanguageID { get { return Convert.ToInt64(appConfigDictionary[(int)DBAppConfigEnum.LanguageID]); } }
    }

    public struct ConnectionStringConfig {
        public string ConnectionString { get; set; } 
        public bool IsDefault { get; set; }
        public string KeyUsed { get; set; } 
    }
}
