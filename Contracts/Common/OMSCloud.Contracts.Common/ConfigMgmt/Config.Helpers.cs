using OMSCloud.Contracts.Common.TypeConverter;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace OMSCloud.Contracts.Common.ConfigMgmt
{
    public partial class Config
    {
        private static List<string> EncryptedConfigKeys = new List<string>() {
            "origins",
            "PublicSiteURL",
            "SmtpPassword",
            "StripeApiKey",
            "StripeSecretKey",
            "PayPalclientId",
            "PayPalclientSecret",
            "TwilioAccountSID",
            "TwilioAuthToken",
            "WebAPIAnonymousUser",
            "WebAPIAnonymousUserPassword",
            "MarketPlaceProfileID",
            "DynamicContent",
            "DefaultCountry",
            "WebAPIHost_Canada",
            "WebAPIHost_UK",
            "WebAPIHost_USA",
            "WebAPIHost_Australia",
            "WebAPIHost_Default",
            "WebAPIUser",
            "WebAPIUserPassword",
        };
        /// <summary>
        /// <typeparam name="T">Type of Parameter</typeparam>
        /// <param name="key">Key of ConfigurationManager.AppSettings</param>
        /// <param name="defaultValue">return Default value if Exceptions occur</param>
        /// <returns></returns>
        /// </summary>
        /// 
        public static T GetConfig<T>(string key, T defaultValue)
        {
            var isEncrypt = ParseType.Get(ConfigurationManager.AppSettings["IsEncryption"], true);
            if (isEncrypt && EncryptedConfigKeys.Contains(key))
            {
                var encryptedValue = ConfigurationManager.AppSettings[key];
                if (!string.IsNullOrEmpty(encryptedValue))
                {
                    var dcryptedValue = CommonUtilities.Decrypt(encryptedValue);
                    return ParseType.Get(dcryptedValue, defaultValue);
                }
            }
           
            return ParseType.Get(ConfigurationManager.AppSettings[key], defaultValue);
        }
        public static T GetConnectionString<T>(string key, T defaultValue)
        {
            var obj = ConfigurationManager.ConnectionStrings[key];
            return obj != null ? ParseType.Get(obj.ConnectionString, defaultValue) : defaultValue;
        }

        public static bool HasKey(string key)
        {
            return ConfigurationManager.AppSettings[key] != null;
        }
    }
}
