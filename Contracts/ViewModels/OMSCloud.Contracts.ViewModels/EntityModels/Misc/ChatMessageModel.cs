using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMSCloud.Contracts.ViewModels
{
    public class ChatMessageModel : BaseModel
    {
        public long MessageId { get; set; }
        public string MessageCode { get; set; }
        public long ChatId { get; set; }
        public long SenderProfileId { get; set; }
        public string ReceiverProfileName { get; set; }
        public string SenderProfileName { get; set; }
        public long ReceiverProfileId { get; set; }
        public string Message { get; set; }
        public DateTime SentDateTime { get; set; }
        public string ReadDateTime { get; set; }
        public bool IsReceived { get; set; }
        public bool IsRead { get; set; }
        public long StatusId { get; set; }
    }
}
