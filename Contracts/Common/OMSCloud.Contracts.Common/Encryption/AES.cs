using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Sprinxle.AMT.Contracts.Common.Encryption
{
    public static class AESEncryption
    {
        // 128bit(16byte)IV and Key
        // private const string AesIV = @"!QAZ2WSX#EDC4RFV";
        //private const string AesKey = @"5TGB&YHN7UJM(IK<";

        /// <summary>
        /// AES Encryption , Returns Base64 string 
        /// </summary>
        public static string Encrypt(string text, string AesIV, string AesKey)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;

            aes.IV = System.Text.Encoding.UTF8.GetBytes(AesIV);
            aes.Key = System.Text.Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert string to byte array
            byte[] src = System.Text.Encoding.Unicode.GetBytes(text);

            // encryption
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);

                // Convert byte array to Base64 strings
                return Convert.ToBase64String(dest);
            }
        }
        public static byte[] Encrypt(byte[] src, string AesIV, string AesKey)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = System.Text.Encoding.UTF8.GetBytes(AesIV);
            aes.Key = System.Text.Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert string to byte array
            //byte[] src = Encoding.Unicode.GetBytes(text);

            // encryption
            using (ICryptoTransform encrypt = aes.CreateEncryptor())
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
                return dest;
                // Convert byte array to Base64 strings
                //return Convert.ToBase64String(dest);
            }
        }

        /// <summary>
        /// AES decryption
        /// </summary>
        public static string Decrypt(string text, string AesIV, string AesKey)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = System.Text.Encoding.UTF8.GetBytes(AesIV);
            aes.Key = System.Text.Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert Base64 strings to byte array
            byte[] src = System.Convert.FromBase64String(text);

            // decryption
            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return System.Text.Encoding.Unicode.GetString(dest);
            }
        }
        public static string Decrypt(byte[] src, string AesIV, string AesKey)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = System.Text.Encoding.UTF8.GetBytes(AesIV);
            aes.Key = System.Text.Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert Base64 strings to byte array
            //byte[] src = System.Convert.FromBase64String(text);

            // decryption
            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                // return dest;
                return System.Text.Encoding.Unicode.GetString(dest);
            }
        }
        public static byte[] DecryptToByte(byte[] src, string AesIV, string AesKey)
        {
            // AesCryptoServiceProvider
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = System.Text.Encoding.UTF8.GetBytes(AesIV);
            aes.Key = System.Text.Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert Base64 strings to byte array
            //byte[] src = System.Convert.FromBase64String(text);

            // decryption
            using (ICryptoTransform decrypt = aes.CreateDecryptor())
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                return dest;
                // return System.Text.Encoding.Unicode.GetString(dest);
            }
        }
        public static ArraySegment<byte> EncryptBuffer(ArraySegment<byte> buffer, BufferManager bufferManager, int messageOffset, string elementToEncrypt = "s:Envelope")
        {
            byte[] bufferedBytes;
            byte[] encryptedBytes;
            XmlDocument xmlDoc = new XmlDocument();

            using (MemoryStream memoryStream = new MemoryStream(buffer.Array, buffer.Offset, buffer.Count))
            {
                xmlDoc.Load(memoryStream);
            }

            Encrypt(xmlDoc, elementToEncrypt, "OBJECTSYNERGYFFF", "FFFOBJECTSYNERGY");
            encryptedBytes = System.Text.Encoding.UTF8.GetBytes(xmlDoc.OuterXml);
            bufferedBytes = bufferManager.TakeBuffer(encryptedBytes.Length);
            Array.Copy(encryptedBytes, 0, bufferedBytes, 0, encryptedBytes.Length);
            bufferManager.ReturnBuffer(buffer.Array);

            ArraySegment<byte> byteArray = new ArraySegment<byte>(bufferedBytes,0, encryptedBytes.Length);

            

            return byteArray;
        }
        public static ArraySegment<byte> DecryptBuffer(ArraySegment<byte> buffer, BufferManager bufferManager)
        {

            byte[] bufferedBytes;
            ArraySegment<byte> byteArray;
            XmlDocument xmlDoc = new XmlDocument();
            string s2 = System.Text.Encoding.UTF8.GetString(buffer.Array, buffer.Offset, buffer.Count);
            using (MemoryStream memoryStream = new MemoryStream(buffer.Array, buffer.Offset, buffer.Count))
            {
                xmlDoc.Load(memoryStream);
            }

            //ClientCryptographer.Decrypt(xmlDoc);
            Decrypt(xmlDoc, "OBJECTSYNERGYFFF", "FFFOBJECTSYNERGY");
            byte[] decryptedBytes = System.Text.Encoding.UTF8.GetBytes(xmlDoc.OuterXml);

            bufferedBytes = bufferManager.TakeBuffer(decryptedBytes.Length);
            Array.Copy(decryptedBytes, 0, bufferedBytes, 0, decryptedBytes.Length);
            bufferManager.ReturnBuffer(buffer.Array);
            byteArray = new ArraySegment<byte>(bufferedBytes, 0, decryptedBytes.Length);

            string s = System.Text.Encoding.UTF8.GetString(byteArray.Array, byteArray.Offset, byteArray.Count);
            return byteArray;

        }
        public static void Decrypt(XmlDocument xmlDoc, string AesIV, string AesKey)
        {

            XmlNodeList encryptedElements = xmlDoc.GetElementsByTagName("EncryptedData");
            if (encryptedElements.Count == 0)
                return;

            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
           
            aes.BlockSize = 128;
            aes.KeySize = 128;
            aes.IV = System.Text.Encoding.UTF8.GetBytes(AesIV);
            aes.Key = System.Text.Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            XmlElement encryptedElement = (XmlElement)encryptedElements[0];

            EncryptedData encryptedData = new EncryptedData();
            encryptedData.LoadXml(encryptedElement);


        


            EncryptedXml encryptedXml = new EncryptedXml();
            encryptedXml.ReplaceData(encryptedElement, encryptedXml.DecryptData(encryptedData, aes));
        }
        public static void Encrypt(XmlDocument xmlDoc, string elementToEncrypt, string AesIV, string AesKey)
        {
            XmlNodeList elementsToEncrypt = xmlDoc.GetElementsByTagName(elementToEncrypt);
            if (elementsToEncrypt.Count == 0)
                return;
            AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 128;

            aes.IV = System.Text.Encoding.UTF8.GetBytes(AesIV);
            aes.Key = System.Text.Encoding.UTF8.GetBytes(AesKey);
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

          
            XmlElement xmlElementToEncrypt = (XmlElement)elementsToEncrypt[0];
            EncryptedXml encryptedXml = new EncryptedXml();

            byte[] encryptedElement = encryptedXml.EncryptData(xmlElementToEncrypt, aes, false);

            EncryptedData encryptedData = new EncryptedData();
            encryptedData.Type = EncryptedXml.XmlEncElementUrl;
            encryptedData.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);
            EncryptedKey encryptedKey = new EncryptedKey();
            encryptedKey.CipherData = new CipherData(EncryptedXml.EncryptKey(aes.Key, new RSACryptoServiceProvider(), false));
            encryptedKey.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);
            encryptedData.KeyInfo = new KeyInfo();
            encryptedKey.KeyInfo.AddClause(new KeyInfoName("EncryptionKey"));
            encryptedData.KeyInfo.AddClause(new KeyInfoEncryptedKey(encryptedKey));
            encryptedData.CipherData.CipherValue = encryptedElement;
            encryptedData.Id = "";
            EncryptedXml.ReplaceElement(xmlElementToEncrypt, encryptedData, false);



          
        }
    }
}
