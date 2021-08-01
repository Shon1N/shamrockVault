using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ShamrockVault.Server.Models
{
    [Table("MessageReceipt")]
    public partial class MessageReceipt
    {
        [Required]
        [StringLength(450)]
        public string MessageReceiptId { get; set; }
        [Key]
        public string MessageId { get; set; }
        public bool MessageReceived { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }

        [ForeignKey(nameof(MessageId))]
        [InverseProperty("MessageReceipt")]
        public virtual Message Message { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(AspNetUser.MessageReceipts))]
        public virtual AspNetUser User { get; set; }
    }
}
