using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.Common.ApiExplorerEnums
{
    public enum WebAPIFormaterEnum
    {
        [Description("application/json")]//; charset = utf - 8")]
        json,
        [Description("text/xml")]//; charset = utf - 8")]
        xml
    }
    public enum WebAPIVerbEnum
    {
        [Description("GET")]
        GET,
        [Description("POST")]
        POST,
        [Description("PUT")]
        PUT,
        [Description("DELETE")]
        DELETE,
        [Description("Not Supported")]
        NotSupported
    }
    public enum WebAPIControllerEnum
    {
        [Description("Contract")]
        Contract,
        [Description("WebApiExplorer")]
        WebApiExplorer
    }
}
