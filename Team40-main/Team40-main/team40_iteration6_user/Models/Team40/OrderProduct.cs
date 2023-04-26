using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class OrderProduct
    {
        public OrderProduct()
        {
            ProductRating = new HashSet<ProductRating>();
        }

        [Key]
        [Column("OrderID")]
        public int OrderId { get; set; }
        [Column("ProductID")]
        public int? ProductId { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Quantity { get; set; }

        [Column("OrderProductID")]
        public int? OrderProductId { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderProduct")]
        public virtual Order Order { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderProduct")]
        public virtual Product Product { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductRating> ProductRating { get; set; }
    }
}
