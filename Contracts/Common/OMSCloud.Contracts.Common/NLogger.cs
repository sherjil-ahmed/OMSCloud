using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Common
{
    public class NLogger
    {
        protected static Logger m_logger = LogManager.GetCurrentClassLogger();

        public static Logger Logger
        {
            get
            {
                return m_logger;
            }
        }

        static public string GetExceptionDetails(Exception ex)
        {
            return string.Format
                (
                    "Message: {0}\r\nInner Message{1}\r\n",
                    (ex != null) ? ex.Message : "",
                    (ex != null) ? ((ex.InnerException != null) ? ex.InnerException.Message : "") : ""
                );
        }

    }
}
