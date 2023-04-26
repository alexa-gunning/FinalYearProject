using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class DiscountType
    {
        public DiscountType()
        {
            DiscountRequest = new HashSet<DiscountRequest>();
        }

        [Key]
        [Column("DiscountTypeID")]
        public int DiscountTypeId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Percentage { get; set; }

        [InverseProperty("DiscountType")]
        public virtual ICollection<DiscountRequest> DiscountRequest { get; set; }
    }
}
