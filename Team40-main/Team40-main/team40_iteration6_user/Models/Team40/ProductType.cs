using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Product = new HashSet<Product>();
        }

        [Key]
        [Column("ProductTypeID")]
        public int ProductTypeId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [StringLength(255)]
        public string ProductTypeName { get; set; }

        [InverseProperty("ProductType")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
