using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.Models
{
    public class Productperformancereport
    {


        public int ProductID { get; set; }

        public string ProductName { get; set; }


        public decimal? TotalProductSold { get; set; }
        public decimal? CostOfProduction { get; set; }
        public decimal? SalesRevenue { get; set; }
        public decimal? NetProfit { get; set; }







    }
}