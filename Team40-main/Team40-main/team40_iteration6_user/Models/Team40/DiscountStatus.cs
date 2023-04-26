using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class DiscountStatus
    {
        public DiscountStatus()
        {
            DiscountRequest = new HashSet<DiscountRequest>();
        }

        [Key]
        [Column("DiscountStatusID")]
        public int DiscountStatusId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        [InverseProperty("DiscountStatus")]
        public virtual ICollection<DiscountRequest> DiscountRequest { get; set; }
    }
}
