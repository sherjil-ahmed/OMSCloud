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
    public class ReviewBackgroundService
    {
        private static ReviewBackgroundService instance = new ReviewBackgroundService();
        object mutex;
        private Timer refreshDataTimer;
        private DateTime? lastrun;

        private ReviewBackgroundService()
        {
            mutex = new object();

            refreshDataTimer = new Timer();
            refreshDataTimer.Interval = (60 * 60 * 1000); // 1 Hour
            refreshDataTimer.Elapsed += refreshDataTimer_Elapsed;
            refreshDataTimer.AutoReset = true;
        }
        public static ReviewBackgroundService Instance
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
                string FilePath = Path.Combine(DirectoryPath, "review.txt");
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
                    CustomerReviewBusinessComponent crbm = new CustomerReviewBusinessComponent();
                    if (crbm.UpdateReviewStatusAuto())
                        NotificationHub.SendNotificationToMarketPlace(NotificationTypeEnum.BackgroundService, "Background service has changed some review status", 0);

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