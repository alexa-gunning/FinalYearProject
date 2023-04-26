using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class StockTakeTotal
    {
        [Column("InventoryID")]
        public int? InventoryId { get; set; }
        [Column("StocKTakeID")]
        public int? StocKtakeId { get; set; }
        [StringLength(255)]
        public string Remarks { get; set; }
        [Column("StockTakeTotal_Qty")]
        public int? StockTakeTotalQty { get; set; }
        [Key]
        [Column("StockTakeTotalID")]
        public int StockTakeTotalId { get; set; }

        [ForeignKey(nameof(InventoryId))]
        [InverseProperty("StockTakeTotal")]
        public virtual Inventory Inventory { get; set; }
        [ForeignKey(nameof(StocKtakeId))]
        [InverseProperty(nameof(StockTake.StockTakeTotal))]
        public virtual StockTake StocKtake { get; set; }
    }
}
