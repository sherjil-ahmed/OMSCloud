using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprinxle.AMT.Contracts.Common.MessageEncoding.EncoderLib;
using System.ServiceModel.Channels;

namespace Sprinxle.AMT.Contracts.Common.MessageEncoding.EncodingProvider
{
    
    public class ClientMessageEncodingElement : CommonMessageEncodingElement
    {
        protected override BindingElement CreateBindingElement()
        {
            ClientMessageEncodingBindingElement bindingElement = new ClientMessageEncodingBindingElement();
            this.ApplyConfiguration(bindingElement);
            return bindingElement;
        }

        public override Type BindingElementType
        {

            get
            {
                return typeof(ClientMessageEncodingBindingElement);
            }
        }
    }

    public class ClientMessageEncodingBindingElement : CommonMessageEncodingBindingElement
    {

        public ClientMessageEncodingBindingElement()
            : base()
        { }

        public ClientMessageEncodingBindingElement(MessageEncodingBindingElement messageEncoderBindingElement)
            : base(messageEncoderBindingElement)
        {

        }



        public override MessageEncoderFactory CreateMessageEncoderFactory()
        {
            ClientMessageEncoderFactory factory = new ClientMessageEncoderFactory(innerBindingElement.CreateMessageEncoderFactory());
            ClientMessageEncoder encoder = factory.Encoder as ClientMessageEncoder;
            encoder.ContentCompression = ContentCompression;
            encoder.ContentEncryption = ContentEncryption;
            return factory;

        }

        public override BindingElement Clone()
        {
            var be = new ClientMessageEncodingBindingElement(this.innerBindingElement);
            be.ContentCompression = ContentCompression;
            be.ContentEncryption = ContentEncryption;
            be.ContentEncoding = ContentEncoding;
            return be;
        }
    }

    public class ClientMessageEncoderFactory : MessageEncoderFactory
    {
        MessageEncoder encoder;

        public ClientMessageEncoderFactory(MessageEncoderFactory messageEncoderFactory)
        {
            if (messageEncoderFactory == null)
                throw new ArgumentNullException("messageEncoderFactory", "A valid message encoder factory must be passed to the GZipEncoder");
            encoder = new ClientMessageEncoder(messageEncoderFactory.Encoder);


        }

        public override MessageEncoder Encoder
        {
            get { return encoder; }
        }

        public override MessageVersion MessageVersion
        {
            get { return encoder.MessageVersion; }
        }
    }

    public class ClientMessageEncoder : CommonMessageEncoder
    {
        public ClientMessageEncoder(MessageEncoder messageEncoder) : base(messageEncoder) { }

        public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
        {

             ArraySegment<byte> buffer = innerEncoder.WriteMessage(message, maxMessageSize, bufferManager, 0);
             if (ContentCompression == ContentCompressionType.GZip)
             {
                 buffer = CompressBuffer(buffer, bufferManager, messageOffset);

             }
            if (ContentEncryption == ContentEncryptionType.Yes)
            {
                //buffer = Common.Encryption.AESEncryption.EncryptBuffer(buffer, bufferManager, messageOffset);
            }
          

            
            return buffer;
        }

        public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
        {
            ArraySegment<byte> workingBuffer = buffer;

           

            if (ContentEncryption != ContentEncryptionType.Yes)
            {                
               //buffer = Common.Encryption.AESEncryption.DecryptBuffer(buffer, bufferManager);
            }
            if (ContentCompression == ContentCompressionType.GZip)
                buffer = DecompressBuffer(buffer, bufferManager);

            Message returnMessage = innerEncoder.ReadMessage(buffer, bufferManager);
            returnMessage.Properties.Encoder = this;
            return returnMessage;
        }

        public override Message ReadMessage(System.IO.Stream stream, int maxSizeOfHeaders, string contentType)
        {
            throw new NotImplementedException();
        }

        public override void WriteMessage(Message message, System.IO.Stream stream)
        {
            throw new NotImplementedException();
        }
    }

}
