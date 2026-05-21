using OMSCloud.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OMSCloud.Services.WebAPI.Hub
{
    public interface IPushNotification
    {
        PushNotificationResponseModel SendPushNotification(long profileId, String title, string msg);
    }
}