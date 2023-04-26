using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.Models
{
    public class Supplierreport
    {
        public string SupplierName { get; set; }

        public string SupplierPhoneNumber { get; set; }
        public decimal? Price { get; set; }
        public int? QuantityPurchased { get; set; }
        public decimal? TotalCost { get; set; }
        public int? Count { get; set; }
    }
}
