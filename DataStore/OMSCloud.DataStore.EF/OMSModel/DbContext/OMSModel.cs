using System;
//using static System.Environment;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Infrastructure.Interception;
using nl = OMSCloud.Contracts.Common.NLogger;
//using System.Configuration;
using OMSCloud.Contracts.Common.ConfigMgmt;

namespace OMSCloud.DataStore.EF.OMSModel
{
    public partial class OMSContext : DbContext
    {
        public static string _ConnectionString = string.Empty;
        private static OMSContext context = null;
        private static object contextLock = new object();

        private OMSContext(string connectionString) : base(connectionString)
        {
            //nl.Log.Debug("Constructor OMSContext, using connection string: " + connectionString);
        }

        public static OMSContext Instance()
        {
            try
            {
                //nl.Log.Debug("Creating new instance of OMSContext");
                var context = new OMSContext(ConnectionString);
                //nl.Log.Debug("Successfully Created new instance of OMSContext");
                //context.ObjectContext.Connection.Open();
                //context.Configuration.AutoDetectChangesEnabled = false;
                //DbInterception.Add(new SqlInterceptor());
                return context;
            }
            catch (Exception ex)
            {
                var msg = "Occured while creating new instance of OMSContext. ExceptionType: " + ex.GetType();
                var e = new Exception(ex.Message + Environment.NewLine + msg, innerException: ex);
                nl.Log.Error(ex, msg);

                throw e;
            }
        }

        private static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_ConnectionString))
                {
                    var connConfig = Config.OMSContextConnectionConfig;
                    if (!string.IsNullOrEmpty(connConfig.ConnectionString))
                    {
                        _ConnectionString = connConfig.ConnectionString;
                        //nl.Log.Info("using the {0} connection string used Key: [{1}], ConnectionString: {2} ", connConfig.IsDefault ? "Default" : "Machine Specific" , connConfig.KeyUsed, connConfig.ConnectionString);
                    }
                    else
                    {
                        string ErrorMsg = "Neither default nor MachineName specific ConnectionString found in config file.";
                        var ex = new Exception(ErrorMsg);
                        nl.Log.Error(ex, ErrorMsg);
                        throw ex;
                    }
                }
                return _ConnectionString;
            }
        }

    }
}
