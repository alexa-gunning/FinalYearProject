using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.ViewModel
{
    public class OrderVM
    {
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int OrderProductId { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? Date { get; set; }
        public int? ClientId { get; set; }
        public int? OrderStatusId { get; set; }
        public int? DeliverCompanyId { get; set; }
        public int? DiscountId { get; set; }
        public int? AddressId { get; set; }

        //get ids
        public IEnumerable<int?> ProductIds { get; set; }
        public IEnumerable<string> ProductNames { get; set; }
        public IEnumerable<decimal?> Quantities { get; set; }

        public string DeliveryCompanyName { get; set; }
        public decimal? DeliveryCompanyBaseRate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string city { get; set; }
        public string areaCode { get; set; }
        public string province { get; set; }

        public string streetName { get; set; }

        public string streetNumber { get; set; }

        public string Country { get; set; }
       public string Description { get; set; }
        public string ProductName { get; set; }
        public decimal? Price { get; set; }
        public decimal Total { get; set; }



    }
}
