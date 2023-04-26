using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class ProductPrice
    {
        [Key]
        [Column("ProductPriceID")]
        public int ProductPriceId { get; set; }
        [Column("ProductPrice", TypeName = "decimal(18, 2)")]
        public decimal? ProductPrice1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("ProductID")]
        public int? ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("ProductPrice")]
        public virtual Product Product { get; set; }
    }
}
