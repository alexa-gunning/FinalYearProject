using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.ViewModel
{
    public class ProductsVM
    {
        public int? ProductId { get; set; }
        public int ProductPriceId { get; set; }
        public string ProductName { get; set; }
        public int ProductTypeID { get; set; }
        public int QuantityOnHand { get; set; }
        public int ProductColourID { get; set; }
        public string ColorName { get; set; }
        public string ColorDescription { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Price { get; set; }
        public string TypeDescription { get; set; }
        public string ProductTypeName { get; set; }
     

    }

}
