using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.ViewModel
{
    public class SupplierPurchasesVM
    {
        public int SupplierPurchaseId { get; set; }
        //public int SupplierInventoryId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityPurchased { get; set; }
        public int? SupplierID { get; set; }
        public int InventoryID { get; set; }
        public string SupplierName { get; set; }
        public string ItemName { get; set; }
    }
}
