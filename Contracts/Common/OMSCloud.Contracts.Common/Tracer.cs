using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Common
{
    public static class Tracer
    {
        public static DateTime Start(string component, string action, string paramList)
        {
            NLogger.Logger.Trace
            (
                string.Format
                (
                    ">> Execute >> Server: {0} >> Thread ID: {1} >> Component: {2} >> Action: {3} >> ParamList: {4}",
                    CommonUtilities.GetComputerName(),
                    System.Threading.Thread.CurrentThread.ManagedThreadId,
                    component,
                    action, paramList
                )
            );

            return DateTime.Now;
        }

        public static DateTime End(DateTime time)
        {
            TimeSpan interval = DateTime.Now - time;
            NLogger.Logger.Trace
            (
                string.Format
                (
                    ">> Execute >> Server: {0} >> Thread ID: {1} >> Completed: {2} ms>>",
                    CommonUtilities.GetComputerName(),
                    System.Threading.Thread.CurrentThread.ManagedThreadId,
                    interval.TotalMilliseconds
                )
            );

            return DateTime.Now;
        }


    }
}
