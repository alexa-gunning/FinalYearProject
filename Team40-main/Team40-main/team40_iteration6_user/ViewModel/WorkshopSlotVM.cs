using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.ViewModel
{
    public class WorkshopSlotVM
    {
        public int WorkshopId { get; set; }
        public int HostId { get; set; }
        public string HostName { get; set; }
        public int WorkshopTypeId { get; set; }
        public string TypeDescription { get; set; }
        public int WorkshopVenueId { get; set; }
        public string VenueName { get; set; }
        public string address { get; set; }
        public decimal? Price { get; set; }
        public DateTime WorkshopDate { get; set; }
        
    }
}
