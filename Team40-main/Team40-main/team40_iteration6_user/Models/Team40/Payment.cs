using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Payment
    {
        [Key]
        [Column("PaymentID")]
        public int PaymentId { get; set; }
        [Column("CartID")]
        public int? CartId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("StatusID")]
        public int? StatusId { get; set; }
        [Column("PayfastID")]
        public int? PayfastId { get; set; }

        [ForeignKey(nameof(CartId))]
        [InverseProperty("Payment")]
        public virtual Cart Cart { get; set; }
        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(PaymentStatus.Payment))]
        public virtual PaymentStatus Status { get; set; }
    }
}
