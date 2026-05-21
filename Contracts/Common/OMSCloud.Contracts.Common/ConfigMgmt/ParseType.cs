using System;

namespace OMSCloud.Contracts.Common.TypeConverter
{
    public class ParseType
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">Type of Parameter</typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue">returns the default value if exception occurs</param>
        /// <returns></returns>
        public static T Get<T>(string value, T defaultValue)
        {
            try
            {
                if (string.IsNullOrEmpty(value))
                    return defaultValue;
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}