using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShamrockVault.Server.Models
{
    [Table("Message")]
    public partial class Message
    {
        [Key]
        public string MessageId { get; set; }
        [StringLength(1024)]
        public string MessageText { get; set; }
        [Required]
        [StringLength(450)]
        public string MessageTypeId { get; set; }
        [Required]
        [StringLength(512)]
        public string MessageName { get; set; }
        [Required]
        [StringLength(512)]
        public string MessageLocation { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreationTime { get; set; }
        public int MessageLifeInSeconds { get; set; }
        public int MessageReceiptCount { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        [ForeignKey(nameof(MessageTypeId))]
        [InverseProperty("Messages")]
        public virtual MessageType MessageType { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.Messages))]
        public virtual AspNetUser User { get; set; }
        [InverseProperty("Message")]
        public virtual MessageReceipt MessageReceipt { get; set; }
    }
}
