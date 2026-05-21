using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using NFSCloud.Contracts.ViewModels;
using NFSCloud.Contracts.Common;

namespace NFSCloud.Contracts.Serialization
{
    public static class ModelDeserializer
    {
        public static ResponseModel<T> ParseResponseXml(string responseXml)
        {
            /*<Reponse>
                <Status type="success">MessageEnum</Status>
                <Value>
                    <ID>1</ID>
                </Value>
            </Reponse>*/
            if (string.IsNullOrEmpty(responseXml)) return null;

            var doc = new XmlDocument();
            doc.LoadXml(responseXml);

            var statusNode = doc.SelectSingleNode("/Response/Status");
            var valueNodes = doc.SelectNodes("/Response/*[starts-with(local-name(), 'Array')]");
            var valueXml = "";

            if (valueNodes != null && valueNodes.Count > 0)
            {
                foreach (XmlNode node in valueNodes)
                    valueXml += node.OuterXml;
            }
            else
            {
                valueXml = doc.SelectSingleNode("/Response/Value") != null ? doc.SelectSingleNode("/Response/Value").OuterXml : "";
            }

            var statusMessage = (StatusMessage)Convert.ToInt32(statusNode.InnerXml);

            ResponseModel<T> responseModel = new ResponseModel<T>
            {
                Status = (ResponseStatus)Enum.Parse(typeof(ResponseStatus), statusNode.Attributes["type"].Value),
                StatusMessage = statusMessage,
                ResponseMessage = statusMessage.GetDescription(),
                Model = valueXml
            };
            if (responseModel.StatusMessage == StatusMessage.Error && responseModel.Status == ResponseStatus.Error)
            {
                responseModel.ResponseMessage = responseModel.Model;
            }
            return responseModel ; 
        }

        public static RequestModel<T> ParseRequestXML(string requestXml)
        {
            if (string.IsNullOrEmpty(requestXml)) return null;

            var doc = new XmlDocument();
            doc.LoadXml(requestXml);

            var optionNode = doc.SelectSingleNode("/Request/OptionID");
            var userNode = doc.SelectSingleNode("/Request/UserID");


            
            //New code
            var valueNodes = doc.SelectNodes("/Request/*[starts-with(local-name(), 'Array')]");
            var valueXml = "";

            if (valueNodes != null && valueNodes.Count > 0)
            {
                foreach (XmlNode node in valueNodes)
                    valueXml += node.OuterXml;
            }
            else
            {
                valueXml = doc.SelectSingleNode("/Request/Value") != null ? doc.SelectSingleNode("/Request/Value").OuterXml : "";
            }


            //var valueXml = doc.SelectSingleNode("/Request/Value") != null ? doc.SelectSingleNode("/Request/Value").OuterXml : string.Empty;




            Guid authCode = new Guid();
            Guid.TryParse(userNode.Attributes["AuthCode"].Value, out authCode);
            
            return new RequestModel<T>
            {
                Option = Convert.ToInt32(optionNode.InnerText),
                UserID = Convert.ToInt32(userNode.InnerText),
                AuthCode =  authCode,
                Model = valueXml
            };
        }

        public static IModel DeserializeFromXml<T>(string modelXml)
        {
            if (string.IsNullOrEmpty(modelXml)) return null;

            var serializer = new XmlSerializer(typeof(T));
            var textWriter = new StringReader(modelXml);

            IModel model = (IModel)serializer.Deserialize(textWriter);
            textWriter.Close();

            return model;
        }

        public static List<T> DeserializeListFromXml<T>(string modelListXml)
        {
            if (string.IsNullOrEmpty(modelListXml)) return null;

            var serializer = new XmlSerializer(typeof(List<T>));
            var textWriter = new StringReader(modelListXml);
            List<T> models = (List<T>)serializer.Deserialize(textWriter);
            textWriter.Close();

            return models;
        }
    }
}
