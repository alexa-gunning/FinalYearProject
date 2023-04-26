using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.Models
{
    public class Workshoperformancereport
    {


        public int WorkshopID { get; set; }

        public string workshopvenue { get; set; }


        public string workshoptype { get; set; }

        public DateTime workshopdate { get; set; }


        public decimal? totalBookings { get; set; }

        public decimal? workshopprice { get; set; }
        public Int32 numerattended { get; set; }
        public decimal? SalesRevenue { get; set; }
        public decimal? NetProfit { get; set; }



    }
}