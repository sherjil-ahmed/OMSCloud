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

        public static string Label(this Enum e)
        {
            return ((char)e.GetHashCode()).ToString(CultureInfo.InvariantCulture);
        }
        public static string GetDescription(this Enum e)
        {
            string output = null;
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
                else
                {
                    output = attrs[0].ToString();
                }
            }
            return output;
        }
    }
}
