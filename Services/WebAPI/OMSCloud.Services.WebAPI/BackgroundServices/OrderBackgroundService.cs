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
    public class OrderBackgroundService
    {
        private static OrderBackgroundService instance = new OrderBackgroundService();        
        object mutex;
        private Timer refreshDataTimer;
        private DateTime? lastrun;

        private OrderBackgroundService()
        {
            mutex = new object();

            refreshDataTimer = new Timer();
            refreshDataTimer.Interval = (60 * 60 * 1000); // 1 Hour
            refreshDataTimer.Elapsed += refreshDataTimer_Elapsed;
            refreshDataTimer.AutoReset = true;
        }
        public static OrderBackgroundService Instance
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
                string FilePath = Path.Combine(DirectoryPath, "order.txt");
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
                    OrderBusinessComponent obm = new OrderBusinessComponent();
                    if (obm.UpdateOrderStatusAuto())
                        NotificationHub.SendNotificationToMarketPlace(NotificationTypeEnum.BackgroundService, "Background service has changed some orders status", 0);

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