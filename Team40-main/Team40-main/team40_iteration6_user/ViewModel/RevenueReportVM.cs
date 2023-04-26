using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.ViewModel
{
    public class RevenueReportVM
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal ProductPrice1 { get; set; }
        public int ProductPriceId { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
        public int SumOfTotal { get; set; }
        public int InventoryId { get; set; }
        public int QuantityInventory { get; set; }
        public int InventoryPrice { get; set; }
        public int SumInvPrice { get; set; }
    }
    
}
