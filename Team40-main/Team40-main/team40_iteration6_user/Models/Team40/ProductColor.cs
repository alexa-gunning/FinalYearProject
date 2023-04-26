using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class ProductColor
    {
        public ProductColor()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        [Column("ProductColorID")]
        public int ProductColorId { get; set; }
        [StringLength(255)]
        public string ColorName { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        [InverseProperty("ProductColour")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
