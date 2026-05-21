using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Configuration;
using System.ServiceModel.Channels;
using System.IO;
using System.Xml;
using System.ServiceModel.Description;
using System.Configuration;
using System.IO.Compression;

//using Ionic.Zlib;

namespace Sprinxle.AMT.Contracts.Common.MessageEncoding.EncoderLib
{

    public enum ContentEncryptionType
    {
        None,
        Yes,
        No
    }

    public enum ContentCompressionType
    {
        None,
        GZip
    }

    // for now works only Text - but can be extended to work with Binary also
    public enum ContentEncodingType
    {
        Text,
        Binary
    }

    //[12]
    public abstract class CommonMessageEncodingElement : BindingElementExtensionElement
    {

        const string contentEncryptionName = "contentEncryption";
        const string contentCompressionName = "contentCompression";
        const string contentEncodingName = "contentEncoding";


        public CommonMessageEncodingElement()
        {
        }

        
        [ConfigurationProperty(contentEncodingName, DefaultValue = "Text")]
        public string ContentEncoding
        {
            get
            {
                return (string)base[contentEncodingName];
            }
            set 
            { 
                base[contentEncodingName] = value; 
            }
        }

        
        [ConfigurationProperty(contentEncryptionName, DefaultValue = "None")]
        public string ContentEncryption
        {
            get
            {
                return (string)base[contentEncryptionName];
            }
            set
            {
                base[contentEncryptionName] = value;
            }
        }

        
        [ConfigurationProperty(contentCompressionName, DefaultValue = "None")]
        public string ContentCompression
        {
            get
            {
                return (string)base[contentCompressionName];
            }
            set 
            { 
                base[contentCompressionName] = value; 
            }
        }


        public override void ApplyConfiguration(BindingElement bindingElement)
        {
            CommonMessageEncodingBindingElement binding = (CommonMessageEncodingBindingElement)bindingElement;
            PropertyInformationCollection propertyInfo = this.ElementInformation.Properties;

            ContentEncryptionType contentEncryption;
            Enum.TryParse<ContentEncryptionType>(propertyInfo[contentEncryptionName].Value.ToString(), out contentEncryption);
            binding.ContentEncryption = contentEncryption;

            ContentCompressionType contentCompression;
            Enum.TryParse<ContentCompressionType>(propertyInfo[contentCompressionName].Value.ToString(), out contentCompression);
            binding.ContentCompression = contentCompression;

            ContentEncodingType contentEncoding;
            Enum.TryParse<ContentEncodingType>(propertyInfo[contentEncodingName].Value.ToString(), out contentEncoding);
            binding.ContentEncoding = contentEncoding;


            if (contentEncoding == ContentEncodingType.Binary && contentEncryption != ContentEncryptionType.None)
            {
                throw new Exception("This version of the application doesn't support encryption with binary encoding!");
            }


            switch (contentEncoding)
            {
                case ContentEncodingType.Binary:
                    {
                        binding.InnerMessageEncodingBindingElement = new BinaryMessageEncodingBindingElement();
                        break;
                    }
                default:
                case ContentEncodingType.Text:
                    {
                        binding.InnerMessageEncodingBindingElement = new TextMessageEncodingBindingElement();
                        break;
                    }
            }



        }
    }

    public abstract class CommonMessageEncodingBindingElement : MessageEncodingBindingElement
    {

        protected MessageEncodingBindingElement innerBindingElement;

        public ContentEncodingType ContentEncoding { get; set; }

        public ContentCompressionType ContentCompression { get; set; }

        public ContentEncryptionType ContentEncryption { get; set; }

        public CommonMessageEncodingBindingElement()
            : this(new TextMessageEncodingBindingElement())
        {
            
        }

        public CommonMessageEncodingBindingElement(MessageEncodingBindingElement messageEncoderBindingElement)
        {
            this.innerBindingElement = messageEncoderBindingElement;
        }

        public MessageEncodingBindingElement InnerMessageEncodingBindingElement
        {
            get 
            { 
                return innerBindingElement; 
            }
            set 
            { 
                innerBindingElement = value; 
            }
        }

        public override MessageVersion MessageVersion
        {
            get 
            { 
                return innerBindingElement.MessageVersion; 
            }
            set 
            { 
                innerBindingElement.MessageVersion = value; 
            }
        }

        public override T GetProperty<T>(BindingContext context)
        {
            if (typeof(T) == typeof(XmlDictionaryReaderQuotas))
            {
                return innerBindingElement.GetProperty<T>(context);
            }
            else
            {
                return base.GetProperty<T>(context);
            }
        }

        public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            
            context.BindingParameters.Add(this);
            var property = GetProperty<XmlDictionaryReaderQuotas>(context);
            property.MaxStringContentLength = Int32.MaxValue; // [14]
            return context.BuildInnerChannelFactory<TChannel>();
        }

        public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.BuildInnerChannelListener<TChannel>();
        }

        public override bool CanBuildChannelListener<TChannel>(BindingContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");

            context.BindingParameters.Add(this);
            return context.CanBuildInnerChannelListener<TChannel>();
        }
    }

    //[4]
    public abstract class CommonMessageEncoder : MessageEncoder
    {
        const string gzipContentType = "application/x-gzip";
        const string encContentType = "application/soap+xml";
        const string gzipMediaType = "application/x-gzip";
        const string encMediaType = "application/soap+xml";

        public ContentCompressionType ContentCompression { get; set; }
        public ContentEncryptionType ContentEncryption { get; set; }

        protected MessageEncoder innerEncoder;
        public CommonMessageEncoder(MessageEncoder messageEncoder)
            : base()
        {
            if (messageEncoder == null)
                throw new ArgumentNullException("messageEncoder", "A valid message encoder must be supplied!");
            innerEncoder = messageEncoder;
        }

        public override string ContentType
        {
            get 
            {
                if (ContentCompression != ContentCompressionType.None)
                    return gzipContentType;
                if (ContentEncryption != ContentEncryptionType.None)
                    return encContentType;
                return innerEncoder.ContentType;
            }
        }

        public override string MediaType
        {
            get 
            {
                if (ContentCompression != ContentCompressionType.None)
                    return gzipMediaType;
                if (ContentEncryption != ContentEncryptionType.None)
                    return encMediaType;
                return innerEncoder.MediaType;
            }
        }

        public override MessageVersion MessageVersion
        {
            get { return innerEncoder.MessageVersion; }
        }



        public static ArraySegment<byte> CompressBuffer(ArraySegment<byte> buffer, BufferManager bufferManager, int messageOffset)
        {
            MemoryStream memoryStream = new MemoryStream();

            using (Stream compressedStream = (Stream)new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                compressedStream.Write(buffer.Array, buffer.Offset, buffer.Count);
            }

            byte[] compressedBytes = memoryStream.ToArray();
            int totalLength = messageOffset + compressedBytes.Length;
            byte[] bufferedBytes = bufferManager.TakeBuffer(totalLength);

            Array.Copy(compressedBytes, 0, bufferedBytes, messageOffset, compressedBytes.Length);

            bufferManager.ReturnBuffer(buffer.Array);
            ArraySegment<byte> byteArray = new ArraySegment<byte>(bufferedBytes, messageOffset, compressedBytes.Length);

            return byteArray;
        }

        public static ArraySegment<byte> DecompressBuffer(ArraySegment<byte> buffer, BufferManager bufferManager)
        {

            MemoryStream memoryStream = new MemoryStream(buffer.Array, buffer.Offset, buffer.Count - buffer.Offset);
            MemoryStream decompressedStream = new MemoryStream();
            //int totalRead = 0;
            int blockSize = 1024;
            byte[] tempBuffer = bufferManager.TakeBuffer(blockSize);
            using (GZipStream gzStream = new GZipStream(memoryStream, CompressionMode.Decompress))
            {
                while (true)
                {
                    int bytesRead = gzStream.Read(tempBuffer, 0, blockSize);
                    if (bytesRead == 0)
                        break;
                    decompressedStream.Write(tempBuffer, 0, bytesRead);
                    //totalRead += bytesRead;
                }
            }
            bufferManager.ReturnBuffer(tempBuffer);

            byte[] decompressedBytes = decompressedStream.ToArray();
            byte[] bufferManagerBuffer = bufferManager.TakeBuffer(decompressedBytes.Length + buffer.Offset);
            Array.Copy(buffer.Array, 0, bufferManagerBuffer, 0, buffer.Offset);
            Array.Copy(decompressedBytes, 0, bufferManagerBuffer, buffer.Offset, decompressedBytes.Length);

            ArraySegment<byte> byteArray = new ArraySegment<byte>(bufferManagerBuffer, buffer.Offset, decompressedBytes.Length);
            bufferManager.ReturnBuffer(buffer.Array);

            return byteArray;
        }

    }

}
