using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.Models
{
    public class SupplierDetails
    {
        public int SupplierId { get; set; }
       
        public string SupplierName { get; set; }
      
        public string SupplierPhoneNumber { get; set; }
        public int SupplierPurchaseId { get; set; }
       
        public DateTime? Date { get; set; }
      
        public decimal? Price { get; set; }
        public int? QuantityPurchased { get; set; }
       
        public decimal? TotalCost { get; set; }
      
        public int? InventoryId { get; set; }
        public string SupplierInventoryId { get; set; }
        public string ItemName { get; set; }
      
    }
}
