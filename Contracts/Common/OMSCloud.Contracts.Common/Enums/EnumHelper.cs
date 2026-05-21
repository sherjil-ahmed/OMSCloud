using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Common
{
    public static class EnumHelper
    {
        private static ConcurrentDictionary<Enum, string> cachedDescriptions = new ConcurrentDictionary<Enum, string>();
        private static ConcurrentDictionary<Enum, string> cachedDefaultValues = new ConcurrentDictionary<Enum, string>();

        public static T ToEnum<T>(this string value, T defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            try
            {
                T result = (T)Enum.Parse(typeof(T), value, true);
                return result;
            }
            catch (ArgumentNullException argumentNullException)
            {
                return defaultValue;
            }
            catch (ArgumentException argumentException)
            {
                return defaultValue;
            }
            catch (OverflowException overflowException)
            {
                return defaultValue;
            }
            catch (Exception ex)
            {
                return defaultValue;
            }

            finally { }
        }

        public static string Label(this Enum e)
        {
            return ((char)e.GetHashCode()).ToString(CultureInfo.InvariantCulture);
        }
        public static string GetDescription(this Enum e)
        {
            string output = string.Empty;
            Type type = e.GetType();

            //Check first in our cached results...
            if (cachedDescriptions.ContainsKey(e))
                output = cachedDescriptions[e];
            else
            {   //Look for our 'DescriptionAttribute' 
                //in the field's custom attributes
                FieldInfo fi = type.GetField(e.ToString());
                DescriptionAttribute[] attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                if (attrs.Length > 0)
                {
                    output = attrs[0].Description;
                    cachedDescriptions.TryAdd(e, output);
                }
            }
            return output;
        }
        public static string GetDefaultValue(this Enum e)
        {
            string output = string.Empty;
            Type type = e.GetType();

            //Check first in our cached results...
            if (cachedDefaultValues.ContainsKey(e))
                output = cachedDefaultValues[e];
            else
            {   //Look for our 'DefaultValueAttribute' 
                //in the field's custom attributes
                FieldInfo fi = type.GetField(e.ToString());
                DefaultValueAttribute[] attrs = fi.GetCustomAttributes(typeof(DefaultValueAttribute), false) as DefaultValueAttribute[];
                if (attrs.Length > 0)
                {
                    output = attrs[0].Value.ToString();
                    cachedDescriptions.TryAdd(e, output);
                }
            }
            return output;
        }
    }
}
