using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class PrepareOrder
    {
        [Column("ProductID")]
        public int? ProductId { get; set; }
        [Column("InventoryID")]
        public int? InventoryId { get; set; }
        public int? Quantity { get; set; }
        [Key]
        [Column("PrepareOrderID")]
        public int PrepareOrderId { get; set; }

        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("PrepareOrder")]
        public virtual Inventory Inventory { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("PrepareOrder")]
        public virtual Product Product { get; set; }
    }
}
