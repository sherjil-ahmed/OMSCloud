using NFSCloud.Contracts.Common;
using NFSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace NFSCloud.Contracts.Serialization
{
    public static class ModelSerializer
    {        
        #region Response

        /*<Reponse>
                <Status type="success">MessageEnum</Status>
                <Value>
                    <ID>1</ID>
                </Value>
            </Reponse>*/

        private static readonly string RESPONSE_FORMATING_XML_STRING = "<Response><Status type=\"{0}\">{1}</Status>{2}</Response>";

        private static string GenerateResponseXml(ResponseStatus responseStatus, StatusMessage responseMessage, string valueXml)
        {
            try
            {
                string xml = string.Format(RESPONSE_FORMATING_XML_STRING, responseStatus, (Int32)responseMessage, valueXml);

                return xml;
            }
            catch (Exception ex)
            {
                NLogger.Logger.Error(CommonUtilities.GetExceptionDetails(ex));
                throw;
            }        
        }

        public static string GenerateResponseXml(IModel model, ResponseStatus responseStatus, StatusMessage responseMessage)
        {
            return GenerateResponseXml(responseStatus, responseMessage,  SerializeToXml(model));
        }

        public static string GenerateResponseXml<T>(List<T> models, ResponseStatus responseStatus, StatusMessage responseMessage)
        {
            return GenerateResponseXml(responseStatus, responseMessage, SerializeToXml<T>(models));
        }

        public static string GenerateErrorResponseXml(Exception ex)
        {
            StatusMessage sm = StatusMessage.Error;
            ResponseStatus rs = ResponseStatus.Error;
            //
            //if (ex is AMTAccessDeniedException)
            //{
            //    sm = StatusMessage.AMTAccessDenied;
            //    rs = ResponseStatus.Failure;
            //}
            //else if (ex is AMTNetworkAccessFailureException)
            //{
            //    sm = StatusMessage.AMTNetworkAccessFailure;
            //    rs = ResponseStatus.Failure;
            //}
            return GenerateResponseXml(rs, sm, "<Value>" + GetErrorMessage(ex) + "</Value>");
        }

        #endregion Response

        #region Requests
        public static string GenerateRequestXml(IModel model, DBOption option, int? userID, Guid? AuthCode)
        {
            #region XML Format Required

            //return "<Request>" +
            //            "<OptionID>OptionID</OptionID>" +
            //            "<UserID>UserID</UserID>" +
            //            "<Value>" +
            //                "<Login>Admin</Login>" +
            //                "<Password>admin</Password>" +
            //            "</Value>" +
            //        "</Request>"; 

            #endregion

            try
            {
                var valueXml = SerializeToXml(model);
                string xml = string.Format("<Request><OptionID>{0}</OptionID><UserID AuthCode='{1}'>{2}</UserID>{3}</Request>",
                    (int)option, AuthCode == null ? "" : AuthCode.Value.ToString(), userID, valueXml);

                return xml;
            }
            catch (Exception ex)
            {
                NLogger.Logger.Error(NLogger.GetExceptionDetails(ex));
                throw;
            }
        }

        public static string GenerateRequestXml<T>(List<T> models, DBOption option, int? userID, Guid? AuthCode)
        {
            #region XML Format Required

            //return "<Request>" +
            //            "<OptionID>OptionID</OptionID>" +
            //            "<UserID>UserID</UserID>" +
            //            "<Value>" +
            //                "<Login>Admin</Login>" +
            //                "<Password>admin</Password>" +
            //            "</Value>" +
            //        "</Request>"; 

            #endregion

            try
            {
                var valueXml = SerializeToXml(models);
                string xml = string.Format("<Request><OptionID>{0}</OptionID><UserID AuthCode='{1}'>{2}</UserID>{3}</Request>",
                    (int)option, AuthCode == null ? "" : AuthCode.Value.ToString(), userID, valueXml);

                return xml;
            }
            catch (Exception ex)
            {
                NLogger.Logger.Error(NLogger.GetExceptionDetails(ex));
                throw;
            }
        }
        #endregion Requests

        #region Common
        
        private static readonly string lineBreak = "<br />";

        private static string GetErrorMessage(Exception ex)
        {
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                return string.Format("{0}{1}{2}", ex.Message, lineBreak, GetErrorMessage(ex.InnerException));
            else
                return string.Format("{0}{1}{2}{3}", 
                                    ex.Message, 
                                    lineBreak, 
                                    System.Web.HttpUtility.HtmlEncode(ex.StackTrace), 
                                    lineBreak
                            );
        }

        public static string SerializeToXml(IModel model)
        {
            try
            {
                if (model == null) return string.Empty;

                var serializer = new XmlSerializer(model.GetType());
                var textWriter = new StringWriter();
                var xns = new XmlSerializerNamespaces();

                xns.Add(string.Empty, string.Empty);

                serializer.Serialize(textWriter, model, xns);

                var valueXml = textWriter.ToString();
                if (valueXml.StartsWith("<?xml"))
                    valueXml = valueXml.Substring(41);

                return valueXml;
            }
            catch (Exception ex)
            {
                NLogger.Logger.Error(NLogger.GetExceptionDetails(ex));
                throw;
            }
        }

        public static string SerializeToXml<T>(List<T> models) 
        {
            try
            {
                var valueXml = "";
                if (models != null)
                {
                    var serializer = new XmlSerializer(typeof(List<T>));
                    var textWriter = new StringWriter();
                    serializer.Serialize(textWriter, models);
                    valueXml = textWriter.ToString();
                    textWriter.Close();

                    return valueXml.Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", "");
                }

                return valueXml;
            }
            catch (Exception ex)
            {
                NLogger.Logger.Error(NLogger.GetExceptionDetails(ex));
                throw;
            }
        }
        #endregion Common
    }
}

