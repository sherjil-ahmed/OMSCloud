using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.Common.ApiExplorerEnums;
using OMSCloud.Contracts.Interfaces.IServices;
using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace OMSCloud.Services.WebAPIs.Controllers
{
    [AllowAnonymous]
    public class WebApiExplorerController : ApiController, IWebApiExplorerController
    {
        private WebAPIVerbEnum GetWebAPIVerb(string HttpMethod)
        {
            switch (HttpMethod)
            {
                case "GET":
                    return WebAPIVerbEnum.GET;

                case "PUT":
                    return WebAPIVerbEnum.PUT;

                case "POST":
                    return WebAPIVerbEnum.POST;

                case "DELETE":
                    return WebAPIVerbEnum.DELETE;

                default:
                    return WebAPIVerbEnum.NotSupported;

            }
        }


        //api/WebApiExplorerController/Explore
        [HttpGet]
        [ReturnType(DataType = typeof(List<ApiDescriptorModel>))]
        public List<ApiDescriptorModel> Explore()
        {
            var apiExplorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();
            var apiDescriptions = apiExplorer.ApiDescriptions;
            var x = apiDescriptions[0].ActionDescriptor as ReflectedHttpActionDescriptor;
            string s = x.MethodInfo.Name;

            var result = (from ad in apiDescriptions
                          let rad = ad.ActionDescriptor as ReflectedHttpActionDescriptor
                          //where rad.ControllerDescriptor.ControllerName.Contains("Group") == true
                          orderby ad.RelativePath
                          select new ApiDescriptorModel
                          {
                              DeclaredResponseType = ad.ResponseDescription.DeclaredType?.ToString(),
                              Params = (from param in ad.ParameterDescriptions
                                        select new ParamDescription
                                        {
                                            DataType = param.ParameterDescriptor.ParameterType?.ToString(),
                                            IsOptional = param.ParameterDescriptor.IsOptional,
                                            Name = param.Name,// + ", " + param.ParameterDescriptor.ParameterName,
                                            Prefix = param.ParameterDescriptor.Prefix,
                                            Source = param.Source.ToString()
                                        }).ToList(),
                              ActionName = rad.ActionName,
                              MethodName = rad.MethodInfo.Name,
                              MethodSignature = GetMethodSignature(rad.MethodInfo),
                              ControllerName = rad.ControllerDescriptor.ControllerName,
                              RelativePath = ad.RelativePath,// + "`" + ad.HttpMethod.Method,
                              RouteTemplate = ad.Route.RouteTemplate,
                              HttpVerb = GetWebAPIVerb(ad.HttpMethod.Method)
                          }).ToList();

            //var result2 = result.ToDictionary(ord => ord.RelativePath, ord => ord, StringComparer.OrdinalIgnoreCase);
            return result;
        }

        private static string GetTypeString(Type t)
        {
            if (t.IsGenericType)
            {
                string[] nameParts = t.Name.Split('`');
                if (nameParts != null & nameParts.Length > 1)
                {
                    string name = nameParts[0].ToString() + "<";
                    foreach (Type g in t.GenericTypeArguments)
                    {
                        name += GetTypeString(g) + ", ";
                    }
                    name = name.Remove(name.Length - 2, 2);
                    name += ">";
                    return name;
                }
            }
            else
            {
                return t.Name == "Void" ? "void" : t.Name;
            }
            return "";
        }

        private static string GetMethodSignature(MethodInfo mi)
        {
            StringBuilder sb = new StringBuilder();
            Type returnType = GetReturnType(mi);
            sb.AppendFormat("public {0} {1}(", GetTypeString(returnType), mi.Name);
            //sb.AppendFormat("public {0} {1} ( ", GetTypeString(mi.ReturnType), mi.Name);
            ParameterInfo[] pInfos = mi.GetParameters();
            foreach (ParameterInfo pi in pInfos)
            {
                sb.AppendFormat("{0} {1}, ", GetTypeString(pi.ParameterType), pi.Name);
            }
            if (pInfos.Length > 0)
                sb.Remove(sb.Length - 2, 2);
            sb.AppendLine(")");
            return sb.ToString();
        }

        private static Type GetReturnType(MethodInfo mi)
        {
            Type returnType = typeof(void);
            var list = mi.GetCustomAttributes(typeof(ReturnTypeAttribute), true);
            if (list?.Count() > 0)
            {
                if (list[0] is ReturnTypeAttribute)
                {
                    var attrib = list[0] as ReturnTypeAttribute;
                    returnType = attrib.DataType;
                }
            }

            return returnType;
        }
    }
}
