using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static OMSCloud.Contracts.Common.NLogger;
using OMSCloud.Contracts.Common;
using OMSCloud.Contracts.ViewModels;
using System.Diagnostics;

namespace OMSCloud.Web.MVC.Net
{
    public static class MiscUtils
    {
        public static FilterAttributeInfoModel GetActionInfo(ActionDescriptor actionDescriptor)
        {
            StackTrace stackTrace = new StackTrace(); // get call stack
            StackFrame[] stackFrames = stackTrace.GetFrames(); // get method calls (frames)
                                                               // write call stack method names
            StackFrame stackFrame = stackFrames[1];
            string eventName = stackFrame.GetMethod().Name;
            var controlDesc = actionDescriptor.ControllerDescriptor;
            var area = GetArea(controlDesc.ControllerType.Namespace);
            var routeName = "Admin_default"; 
            //since we have only admin 'area' functional and 
            //we dont want to route (redirect) to any other 'area' 
            //therefore we have hardcoded the routeName to 'admin_default'
            //In-case we have multiple areas and need to route/redirect to respective area for un-authorization, Login Logoff etc.
            //then we will comment above line and un-comment below statement

            //var routeName = string.IsNullOrEmpty(area) ? 
            //                        "Admin_default" : 
            //                        area + "_default";
            string key = string.IsNullOrEmpty(area) ?
                String.Format("{0}-{1}", controlDesc.ControllerName, actionDescriptor.ActionName) :
                String.Format("{0}-{1}-{2}", area, controlDesc.ControllerName, actionDescriptor.ActionName);
            return new FilterAttributeInfoModel()
            {
                ControllerType = controlDesc.ControllerType,
                ControllerName = controlDesc.ControllerName,
                ActionName = actionDescriptor.ActionName,
                Namespace = controlDesc.ControllerType.Namespace,
                Area = area,
                SecurityKey = key,
                RouteName = routeName,
                RouteValues = new object[] { },
                EventName = eventName,
            };
        }
        private static string GetArea(string Namespace)
        {
            var area = string.Empty;
            var parts = Namespace.Split('.');
            int i = 0;
            //var result = (from p in parts
            //              where
            //              string.Compare(p, "areas", true, System.Globalization.CultureInfo.InvariantCulture) == 0
            //              select p);  //Dont know how to get the index of 'areas' so that we can pick next as done below.
            for (i = 0; i < parts.Length; i++)
            {
                var compareResult = string.Compare(parts[i], "areas", true, System.Globalization.CultureInfo.InvariantCulture);
                if (compareResult == 0)
                {
                    break;
                }
            }
            if(parts.Length > i)
                area = parts[i+1];
            //if (parts.Length > 3) // Length is 4 or more
            //{
            //    string part = parts[parts.Length - 3];
            //    if (part.ToLower() == "areas")
            //        area = parts[parts.Length - 2];// + "_";
            //}
            //area = string.IsNullOrEmpty(area) ? "Admin" : area;
            return area;
        }
        public static void DebugActionInfo(FilterAttributeInfoModel info)
        {
            if (info != null)
            {
                Log.Debug("Event: " + info.EventName +
                          ", Area: " + info.Area +
                          ", Controller Name: " + info.ControllerName +
                          ", Action Name: " + info.ActionName +
                          ", Namespace: " + info.Namespace +
                          ", routeValues[" + info.RouteValues?.ToString() + "]"
                );
            }
        }
    }
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> SelectRecursive<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> selector)
        {
            foreach (var parent in source)
            {
                yield return parent;

                var children = selector(parent);
                foreach (var child in SelectRecursive(children, selector))
                    yield return child;
            }
        }
    }
}