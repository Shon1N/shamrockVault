using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShamrockVault.Server.Models
{
    [Table("MessageType")]
    public partial class MessageType
    {
        public MessageType()
        {
            Messages = new HashSet<Message>();
        }

        [Key]
        public string MessageTypeId { get; set; }
        [StringLength(32)]
        public string MessageTypeName { get; set; }

        [InverseProperty(nameof(Message.MessageType))]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
