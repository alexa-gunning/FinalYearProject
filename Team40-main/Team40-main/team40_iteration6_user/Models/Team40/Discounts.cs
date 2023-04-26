using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.Models
{
    public class Discounts
    {
        public int DiscountId { get; set; }
        public string DiscountDescription { get; set; }
        public int? DiscountStatusId { get; set; }
        public int? DiscountTypeId { get; set; }
        public string DiscountStatus { get; set; }
        public string DiscountType { get; set; }
        public string TypeDescription { get; set; }
        public string StatusDescription { get; set; }
        public decimal? Percentage { get; set; }
    }
}
