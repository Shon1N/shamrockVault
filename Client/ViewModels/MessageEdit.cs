using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShamrockVault.Client.ViewModels
{
    public class MessageEdit
    {
        public string MessageId { get; set; }
        public string MessageText { get; set; }
        public int MessageTypeId { get; set; }
        public string MessageName { get; set; }
        public string MessageLocation { get; set; }
        public DateTime CreationTime { get; set; }
        public int MessageLifeInSeconds { get; set; }
        public int MessageReceiptCount { get; set; }
        public string UserId { get; set; }
    }
}
