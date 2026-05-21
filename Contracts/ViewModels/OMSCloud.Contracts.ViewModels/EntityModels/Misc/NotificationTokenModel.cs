using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public partial class NotificationTokenModel : BaseModel
    {
        public long TokenId { get; set; }
        public string Token { get; set; }
        public long ProfileId { get; set; }
        public string DevicePlatform { get; set; }
        public string NotificationService { get; set; }
        public long StatusId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string DeviceId { get; set; }
    }
}
