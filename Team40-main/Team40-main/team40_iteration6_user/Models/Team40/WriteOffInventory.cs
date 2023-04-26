using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class WriteOffInventory
    {
        [Key]
        [Column("WriteOffID")]
        public int WriteOffId { get; set; }
        [Column("InventoryID")]
        public int? InventoryId { get; set; }
        [Column("WriteOffReasonID")]
        public int? WriteOffReasonId { get; set; }
        [Column("AdminID")]
        public int? AdminId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? WriteOffDate { get; set; }
        public int? WriteOffQty { get; set; }

        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("WriteOffInventory")]
        public virtual Inventory Inventory { get; set; }
        [ForeignKey(nameof(WriteOffReasonId))]
        [InverseProperty("WriteOffInventory")]
        public virtual WriteOffReason WriteOffReason { get; set; }
        [StringLength(255)]
        [Column("Name")]
        public string Name { get; set; }


    }
}
