using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Common
{
    public static class CommonUtilities
    {
        public static string GetComputerName()
        {
            return System.Environment.MachineName;
        }

        public static string EnumValue(Enum e)
        {
            return ((char)e.GetHashCode()).ToString(CultureInfo.InvariantCulture);
        }

        public static T ToEnum<T>(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ArgumentException("Argument null or empty");
            }
            if (s.Length > 1)
            {
                throw new ArgumentException("Argument length greater than one");
            }
            return (T)Enum.ToObject(typeof(T), s[0]);
        }

        public static IPAddress LocalIPAddress()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(Dns.GetHostName());
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
                foreach (IPAddress ip in host.AddressList)
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        return ip;
            return null;
        }

        static public string GetExceptionDetails(Exception ex)
        {
            return string.Format
                (
                    "Message: {0}\r\nInner Message{1}\r\n",
                    (ex != null) ? ex.Message : "",
                    (ex != null) ? ((ex.InnerException != null) ? ex.InnerException.Message : "") : ""
                );
        }

        public static bool WriteFile(string path, string fileName, String data)
        {
            try
            {
                //string fileName = String.Format(@"Designer\{0}.Designer.cs", table.TableName);
                Stream outputFile = File.Open(Path.Combine(path, fileName), FileMode.Create);
                StreamWriter streamWriter = new StreamWriter(outputFile);

                streamWriter.Write(data);

                streamWriter.Flush();
                streamWriter.Close();
                outputFile.Close();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
