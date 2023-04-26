using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using team40_iteration6_user.Models;

namespace team40_iteration6_user.ViewModel
{
    public class StockTakeVM
    {
        public int StockTakeId { get; set; }
        public int StockTakeTotalQty { get; set; }
        public string itemName { get; set; }
        public int StockTakeTotalId { get; set; }

        public int InventoryId { get; set; }

        public string Remarks { get; set; }

        public DateTime StockTakeDate { get; set; }
        public string Name { get; set; }
    }
}