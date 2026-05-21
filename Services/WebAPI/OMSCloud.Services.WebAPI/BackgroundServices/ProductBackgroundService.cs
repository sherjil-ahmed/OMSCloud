using OMSCloud.Business.Core;
using OMSCloud.Contracts.Common;
using OMSCloud.Services.WebAPIs.Hubs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Timers;
using System.Web;

namespace OMSCloud.Services.WebAPIs.BackgroundServices
{
    public class ProductBackgroundService
    {
        private static ProductBackgroundService instance = new ProductBackgroundService();
        object mutex;
        private Timer refreshDataTimer;
        private DateTime? lastrun;

        private ProductBackgroundService()
        {
            mutex = new object();

            refreshDataTimer = new Timer();
            refreshDataTimer.Interval = (60 * 60 * 1000); // 1 Hour
            refreshDataTimer.Elapsed += refreshDataTimer_Elapsed;
            refreshDataTimer.AutoReset = true;
        }
        public static ProductBackgroundService Instance
        {
            get
            {
                return instance;
            }
        }
        void refreshDataTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StopRefreshDataTimer();
            try
            {
                string DirectoryPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BackgroundServiceData");
                string FilePath = Path.Combine(DirectoryPath, "productAnalysisRank.txt");
                if (!lastrun.HasValue)
                {
                    if (!Directory.Exists(DirectoryPath))
                        Directory.CreateDirectory(DirectoryPath);

                    if (File.Exists(FilePath))
                        lastrun = DateTime.ParseExact(File.ReadAllText(FilePath), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    else
                        lastrun = DateTime.Now.AddDays(-1);
                }

                if (lastrun.Value.Day != DateTime.Now.Day)
                {
                    ProductBusinessComponent pbm = new ProductBusinessComponent();
                    if (pbm.UpdateForAnalysisRank())
                        NotificationHub.SendNotificationToMarketPlace(NotificationTypeEnum.BackgroundService, "Background service has updated product analysis rank", 0);

                    lastrun = DateTime.Now;
                    File.WriteAllText(FilePath, DateTime.Now.ToString("dd/MM/yyyy"));
                }
            }
            catch (Exception ex)
            {
                NLogger.ErrorLog.Error(ex);
            }
            StartRefreshDataTimer();

        }
        public void StartRefreshDataTimer()
        {
            refreshDataTimer.Start();
        }
        public void StopRefreshDataTimer()
        {
            refreshDataTimer.Stop();
        }
    }
}