using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class SupplierInventory
    {
        public SupplierInventory()
        {
            SupplierPurchase = new HashSet<SupplierPurchase>();
        }

        [Key]
        [Column("SupplierPurchaseID")]
        public int SupplierPurchaseId { get; set; }
        [Column("InventoryID")]
        public int? InventoryId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? InventoryItemPrice { get; set; }
        [Column("SupplierInventoryID")]
        [StringLength(50)]
        public string SupplierInventoryId { get; set; }

        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("SupplierInventory")]
        public virtual Inventory Inventory { get; set; }
        [InverseProperty("Inventory")]
        public virtual ICollection<SupplierPurchase> SupplierPurchase { get; set; }

        //public static implicit operator SupplierInventory(SupplierInventory v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
