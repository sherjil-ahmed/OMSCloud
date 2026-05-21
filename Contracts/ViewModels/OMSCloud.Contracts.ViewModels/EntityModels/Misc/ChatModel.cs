using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ChatModel : ConcurrencyBaseModel
    {
        public long ChatId { get; set; }
        public string ChatCode { get; set; }
        public long ProfileId1 { get; set; }
        [Display(Name = "Receipient #1")]
        public string ProfileId1_Name { get; set; }
        public string ProfileId1_Image { get; set; }
        public long ProfileId2 { get; set; }
        [Display(Name ="Receipient #2")]
        public string ProfileId2_Name { get; set; }
        public string ProfileId2_Image { get; set; }
        [Display(Name = "Status")]
        public long StatusId { get; set; }
        public long UnreadMessageCount { get; set; }
    }

    public class ChatHubModel
    {
        public long SenderProfileID { get; set; }
        public long ReceiverProfileID { get; set; }
        public string Message { get; set; }        
        public DateTime ChatTime { get; set; }
        public bool isNew { get; set; }
    }
}
