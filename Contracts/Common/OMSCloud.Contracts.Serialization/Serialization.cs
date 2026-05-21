using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ApiExplorerEnums;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml.Serialization;

namespace OMSCloud.Contracts.Serialization
{
    public interface IOMSSerialization<T> 
    {
        string Serialize(IModel model);
        T Deserialize(string text);
    }

    public class OMSJsonSerialization<T> : IOMSSerialization<T> 
    {
        private static JavaScriptSerializer serializer = null;

        private static JavaScriptSerializer Serializer
        {
            get
            {
                if (serializer == null)
                    serializer = new JavaScriptSerializer();
                return serializer;
            }
        }
        public T Deserialize(string text) 
        {
            return (T)Serializer.Deserialize(text, typeof(T));
        }

        public string Serialize(IModel model)
        {
            //Type t = model.GetType();
            var json = Serializer.Serialize(model);
            //var str = "{\"" + t.Name + "\":" + str + "}";
            return json;
        }
    }
    public class OMSXmlSerialization<T> : IOMSSerialization<T> 
    {
        public T Deserialize(string Xml) 
        {
            if (string.IsNullOrEmpty(Xml)) 
            {
                //return default(T);
                throw new ArgumentNullException("The string param \"Xml\" is either null or empty.");
            }

            var serializer = new XmlSerializer(typeof(T));
            var textWriter = new StringReader(Xml);

            T model = (T)serializer.Deserialize(textWriter);
            textWriter.Close();

            return model;
        }

        public string Serialize(IModel model)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            var textWriter = new StringWriter();
            var xns = new XmlSerializerNamespaces();

            xns.Add(string.Empty, string.Empty);
            serializer.Serialize(textWriter, model, xns);

            var valueXml = textWriter.ToString();

            if (valueXml.StartsWith("<?xml"))
                valueXml = valueXml.Substring(41);

            return valueXml;
        }
    }

    public static class SerializerFactory
    {
        public static IOMSSerialization<T> Instance<T>(WebAPIFormaterEnum formater)
        {
            if (formater == WebAPIFormaterEnum.json)
                return new OMSJsonSerialization<T>();
            else if (formater == WebAPIFormaterEnum.xml)
                return new OMSXmlSerialization<T>();
            else
                return new OMSJsonSerialization<T>();
        }

    }
}