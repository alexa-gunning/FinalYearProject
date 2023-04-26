using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Inventory
    {
        public Inventory()
        {
            PrepareOrder = new HashSet<PrepareOrder>();
            StockTakeTotal = new HashSet<StockTakeTotal>();
            SupplierInventory = new HashSet<SupplierInventory>();
            WriteOffInventory = new HashSet<WriteOffInventory>();
        }

        [Key]
        [Column("InventoryID")]
        public int InventoryId { get; set; }
        [StringLength(255)]
        public string ItemName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? QuantityOnHand { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }

        [InverseProperty("Inventory")]
        public virtual ICollection<PrepareOrder> PrepareOrder { get; set; }
        [InverseProperty("Inventory")]
        public virtual ICollection<StockTakeTotal> StockTakeTotal { get; set; }
        [InverseProperty("Inventory")]
        public virtual ICollection<SupplierInventory> SupplierInventory { get; set; }
        [InverseProperty("Inventory")]
        public virtual ICollection<WriteOffInventory> WriteOffInventory { get; set; }
    }
}
