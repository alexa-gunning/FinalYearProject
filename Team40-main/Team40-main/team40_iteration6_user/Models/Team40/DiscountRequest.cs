using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class DiscountRequest
    {
        public DiscountRequest()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        [Column("DiscountID")]
        public int DiscountId { get; set; }
        [StringLength(255)]
        public string DiscountDescription { get; set; }
        [Column("DiscountTypeID")]
        public int? DiscountTypeId { get; set; }
        [Column("DiscountStatusID")]
        public int? DiscountStatusId { get; set; }

        [ForeignKey(nameof(DiscountStatusId))]
        [InverseProperty("DiscountRequest")]
        public virtual DiscountStatus DiscountStatus { get; set; }
        [ForeignKey(nameof(DiscountTypeId))]
        [InverseProperty("DiscountRequest")]
        public virtual DiscountType DiscountType { get; set; }
        [InverseProperty("Discount")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
