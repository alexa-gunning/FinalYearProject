// using Microsoft.AspNetCore.Mvc;
// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using team40_iteration6_user.Models;

// namespace team40_iteration6_user.ViewModel
// {
//     public class WriteOffInventoryVM : Controller
//     {
//         public WriteOffInventory WriteOffInventory { get; set; }
//         public WriteOffReason WriteOffReason { get; set; }

//         /******Write Off Inventory********/

//         public int WriteOffID { get; set; }

//         public int InventoryID { get; set; }

//         public int WriteOffReasonID { get; set; }

//         public int AdminID { get; set; }

//         public string WriteOffDate { get; set; }

//         public string WriteOffQty { get; set; }

//         /**********Write Off Reason********/
//         public int WriteOffReasonDescription { get; set; }
//     }
// }

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using team40_iteration6_user.Models;

namespace team40_iteration6_user.ViewModel
{
    public class InventoryVM
    {
        public int? InventoryId { get; set; }
        public string ItemName { get; set; }
        public int? QuantityOnHand { get; set; }
        public DateTime LastUpdated { get; set; }
        public WriteOffInventory[] writeoffinventories { get; set; }
    }
    public class WriteOffInventoryVM
    {
        public int? WriteOffId { get; set; }
        public int InventoryId { get; set; }
        public int? WriteOffReasonId { get; set; }
        public int? AdminId { get; set; }
        public DateTime WriteOffDate { get; set; }
        public int? WriteOffQty { get; set; }
    }

    public class WriteOffReasonVM
    {
        public int? WriteOffReasonId { get; set; }
        public string WriteOffReasonDescription { get; set; }
        public WriteOffInventory[] writeoffinventories { get; set; }
    }

    public class WriteOffInventoryCombinedVM
    {
        public InventoryVM inventory { get; set; }
        public WriteOffInventoryVM writeoffinventory { get; set; }
        public WriteOffReasonVM writeoffreason { get; set; }
    }

    public class WriteOffReasonsMultiVM
    {
        /* WriteOff Reason */
        public int WriteOffReasonId { get; set; }
        public string WriteOffReasonDescription { get; set; }

        /* WriteOff Inventory */
        public int WriteOffId { get; set; }
        public int InventoryId { get; set; }
        public int AdminId { get; set; }
        public DateTime? WriteOffDate { get; set; }
        public int WriteOffQty { get; set; }

        /* Inventory */
        public string ItemName { get; set; }
        public int QuantityOnHand { get; set; }
        public DateTime? LastUpdated { get; set; }

    }
}

