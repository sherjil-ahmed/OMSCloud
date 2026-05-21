using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Common
{
    public static class NLogger
    {
        private static Logger m_log = LogManager.GetCurrentClassLogger();
        private static Logger m_errorLog = LogManager.GetLogger("");

        public static Logger Log { get; } = LogManager.GetLogger("default");

        public static Logger ErrorLog { get; } = LogManager.GetLogger("errorLog");
    }
}
