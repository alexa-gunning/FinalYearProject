using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class PaymentStatus
    {
        public PaymentStatus()
        {
            Payment = new HashSet<Payment>();
        }

        [Key]
        [Column("StatusID")]
        public int StatusId { get; set; }
        [StringLength(255)]
        public string StatusName { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
