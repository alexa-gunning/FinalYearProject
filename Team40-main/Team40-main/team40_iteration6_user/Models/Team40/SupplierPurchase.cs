using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class SupplierPurchase
    {
        [Key]
        [Column("SupplierPurchaseID")]
        public int SupplierPurchaseId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }
        public int? QuantityPurchased { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? TotalCost { get; set; }
        [Column("SupplierID")]
        public int? SupplierId { get; set; }
        [Column("InventoryID")]
        public int? InventoryId { get; set; }

        [ForeignKey(nameof(InventoryId))]
        [InverseProperty(nameof(SupplierInventory.SupplierPurchase))]
        public virtual SupplierInventory Inventory { get; set; }
        [ForeignKey(nameof(SupplierId))]
        [InverseProperty("SupplierPurchase")]
        public virtual Supply Supplier { get; set; }


       
    }
}
