using System;
using System.Web;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using OMSCloud.Contracts.Common.ConfigMgmt;
using System.Drawing;
using System.Security.Cryptography;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Net.Http;
using System.ServiceModel.Channels;

namespace OMSCloud.Contracts.Common
{
    public class ReturnTypeAttribute : Attribute
    {
        public Type DataType { get; set; }
    }
    public static class CommonUtilities
    {
        /// <summary>
        /// Checks if the specified date is older than a particular number of hours
        /// </summary>
        /// <param name="dtUtc"></param>
        /// <param name="hours"></param>
        /// <returns></returns>
        public static bool IsOlderThan(this DateTime dtUtc, int seconds)
        {
            return dtUtc.AddSeconds(seconds) < DateTime.UtcNow;
        }
        public static string ConvertToWebPath(string FilePath)
        {
            if (String.IsNullOrEmpty(FilePath))
            {
                return "";
            }
            var path = FilePath.Replace(@"\\", "/");
            path = path.Replace(@"\", "/");
            path = path.Replace("//", "/");
            return path;
        }
        public static string ConvertToWindowsFileSystemPath(string FilePath)
        {
            if (String.IsNullOrEmpty(FilePath))
            {
                return "";
            }
            var path = FilePath.Replace("//", @"\");
            path = path.Replace(@"\\", @"\");
            path = path.Replace(@"/", @"\");

            return path;
        }
        public static string RandomFileName(int ProductID)
        {
            const string Chars = "ABCDEFGHIJKLMNPOQRSTUVWXYZ";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(Chars, 7)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
            result = (ProductID + "_" + result).ToString();
            return result;
        }
        public static string GetFileName(string OriginalFileName, ImageRoute imageRoute, FileType fileType, long id)
        {
            var routeString = imageRoute.GetDescription();
            routeString = routeString.Replace("{ext}", fileType.GetDescription());
            routeString = routeString.Replace("{FileName}", Guid.NewGuid().ToString());
            routeString = routeString.Replace("{id}", id.ToString());

            return routeString;
        }
        public static string GetFilePath(ImageRoute imageRoute, long id)
        {
            var routeString = imageRoute.GetDescription();
            routeString = routeString.Replace("{id}", id.ToString());
            return routeString;
        }
        public static string GetComputerName()
        {
            return System.Environment.MachineName;
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
        public static string GetClientIp(HttpRequestMessage request = null)
        {
            //request = request ?? Request;

            if (request.Properties.ContainsKey("MS_HttpContext"))
            {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else if (HttpContext.Current != null)
            {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else
            {
                return null;
            }
        }
        static public string GetExceptionDetails(Exception ex)
        {
            string exMsg = string.Empty;
            if (ex.InnerException != null)
                 exMsg = GetExceptionDetails(ex.InnerException);
            exMsg = exMsg + Environment.NewLine + ex.GetType() + " ==>>" + ex.Message ;
            return exMsg;
        }
        public static string SaveFile(HttpPostedFileBase file, string rootPath, ImageRoute fileRoute, long recordId)
        {
            try
            {
                if (file == null)
                    return string.Empty;
                var ext = Path.GetExtension(file.FileName);
                var fileType = ext.ToEnum<FileType>(FileType.PNG);

                var dynamicContentLocation = Config.DynamicContent;
                if ((file != null && file.ContentLength > 0))
                {
                    var relativePath = Path.Combine(dynamicContentLocation + GetFileName(file.FileName, fileRoute, fileType, recordId));
                    relativePath = CommonUtilities.ConvertToWindowsFileSystemPath(relativePath);
                    var relativeWebPath = CommonUtilities.ConvertToWebPath(relativePath);

                    var FinalPath = Path.Combine(rootPath + relativePath);
                    FinalPath = CommonUtilities.ConvertToWindowsFileSystemPath(FinalPath);

                    if (!Directory.Exists(Path.GetDirectoryName(FinalPath)))
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(FinalPath));
                    }
                    try
                    {
                        file.SaveAs(FinalPath);
                        return relativeWebPath;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {

                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
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
            catch (Exception ex)
            {
                return false;
            }
        }
        private static bool IsEqual(DateTime dt1, DateTime dt2)
        {
            string dt1Str = dt1.ToString("dd-mm-yyyy HH:MM:ss");
            string dt2Str = dt2.ToString("dd-mm-yyyy HH:MM:ss");
            //return (dt1.Date == dt2.Date && dt1.ToLongTimeString() == dt2.ToLongTimeString());
            return String.Equals(dt1Str, dt2Str, StringComparison.InvariantCultureIgnoreCase);
        }
        public static string Encrypt(string clearText)
        {
            string EncryptionKey = "987938ZNOVR128383792";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string Decrypt(string cipherText)
        {
            string EncryptionKey = "987938ZNOVR128383792";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public static Image ResizeImageOriginalRatio(string targetImageFile, Image sourceImage, int width = 200, int height = 200)
        {
            var image = ResizeImageOriginalRatio(sourceImage, width, height);
            ImageFormat format = ImageFormat.Png;
            var f = Path.GetExtension(targetImageFile);
            switch (f)
            {
                case ".jpeg":
                case ".jpg":
                    format = ImageFormat.Jpeg;
                    break;
                case ".png":
                    format = ImageFormat.Png;
                    break;
            }
            image.Save(targetImageFile, format);
            return image;
        }
        public static Image ResizeImageOriginalRatio(Image image, int width, int height)
        {
            int oraginal_Height = image.Height;
            int oraginal_width = image.Width;
            width = oraginal_width;
            height = oraginal_Height;
            int percent_Height = oraginal_Height / height;
            int percent_Width = oraginal_width / width;

            if ((oraginal_width / oraginal_Height) >= 1)
            {
                //Portrait
                width = oraginal_width / percent_Width;
            }
            else
            {
                //Landscape
                height = oraginal_Height / percent_Height;
            }

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return (Image)destImage;
        }
    }
}
