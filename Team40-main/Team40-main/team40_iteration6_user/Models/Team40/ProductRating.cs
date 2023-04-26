using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class ProductRating
    {
        [Key]
        [Column("ProductRatingID")]
        public int ProductRatingId { get; set; }
        [StringLength(50)]
        public string Rating { get; set; }
        [StringLength(255)]
        public string ReviewDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("ProductID")]
        public int? ProductId { get; set; }
        [Column("OrderID")]
        public int? OrderId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(OrderProduct.ProductRating))]
        public virtual OrderProduct Product { get; set; }
        [ForeignKey(nameof(ProductId))]
       // [InverseProperty(nameof(Product.ProductRating))]
        public virtual Product ProductNavigation { get; set; }
    }
}
