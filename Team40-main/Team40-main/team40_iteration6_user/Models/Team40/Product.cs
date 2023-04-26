using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Product
    {
        public Product()
        {
            Cart = new HashSet<Cart>();
            OrderProduct = new HashSet<OrderProduct>();
            PrepareOrder = new HashSet<PrepareOrder>();
            ProductPrice = new HashSet<ProductPrice>();
            ProductRating = new HashSet<ProductRating>();
        }

        [Key]
        [Column("ProductID")]
        public int ProductId { get; set; }
        [StringLength(255)]
        public string ProductName { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column("ProductTypeID")]
        public int? ProductTypeId { get; set; }
        [Column("ProductColourID")]
        public int? ProductColourId { get; set; }
        [Column("QuantityOnHand")]
        public int QuantityOnHand { get; set; }
        [Column("Price", TypeName = "decimal(18, 2)")]
        public decimal? Price { get; set; }

        [ForeignKey(nameof(ProductColourId))]
        [InverseProperty(nameof(ProductColor.Product))]
        public virtual ProductColor ProductColour { get; set; }
        [ForeignKey(nameof(ProductTypeId))]
        [InverseProperty("Product")]
        public virtual ProductType ProductType { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<Cart> Cart { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<OrderProduct> OrderProduct { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<PrepareOrder> PrepareOrder { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductPrice> ProductPrice { get; set; }
        [InverseProperty("ProductNavigation")]
        public virtual ICollection<ProductRating> ProductRating { get; set; }
        public int GetProductId { get; internal set; }

        //[InverseProperty("Product")]
        //public virtual ICollection<Order> Order { get; set; }
        
    }
}
