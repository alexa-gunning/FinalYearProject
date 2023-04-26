using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.ViewModel
{
    public class InventoryReportVM
    {
        //inventory
        public string ItemName { get; set; }
        public decimal? QuantityOnHand { get; set; }

 

        //supplierpurchase
        public decimal? QuantityPurchased { get; set; }
        public decimal? Price { get; set; }

        //calculated
        public decimal? total { get; set; }
        public decimal? actualqty { get; set; }

       
    }

}
