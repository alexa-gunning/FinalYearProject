using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class StockTake
    {
        public StockTake()
        {
            StockTakeTotal = new HashSet<StockTakeTotal>();
        }

        [Key]
        [Column("StockTakeID")]
        public int StockTakeId { get; set; }
        [Column("AdminID")]
        public int? AdminId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StockTakeDate { get; set; }
        [StringLength(255)]
        [Column("Name")]
        public string Name { get; set; }

        [InverseProperty("StocKtake")]
        public virtual ICollection<StockTakeTotal> StockTakeTotal { get; set; }
    }
}
