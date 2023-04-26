using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using team40_iteration6_user.Models;

namespace team40_iteration6_user.ViewModel

{
    public class WriteOffInventoryHistoryVM
    {
        public int? WriteOffId { get; set; }
        public int InventoryId { get; set; }
        public int? WriteOffReasonId { get; set; }
        public int? AdminId { get; set; }
        public DateTime? WriteOffDate { get; set; }
        public int? WriteOffQty { get; set; }

        public string ItemName { get; set; }

        public string WriteOffReasonDescription { get; set; }

        public string AdminName { get; set; }

        public string Name { get; set; }
    }
}