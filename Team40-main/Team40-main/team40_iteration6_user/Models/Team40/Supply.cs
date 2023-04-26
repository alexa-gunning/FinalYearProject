using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Supply
    {
        public Supply()
        {
            SupplierPurchase = new HashSet<SupplierPurchase>();
        }

        [Key]
        [Column("SupplierID")]
        public int SupplierId { get; set; }
        [StringLength(255)]
        public string SupplierName { get; set; }
        [StringLength(255)]
        public string SupplierPhoneNumber { get; set; }
        [StringLength(255)]
        public string SupplierEmail { get; set; }
        [StringLength(255)]
        public string SupplierAddress { get; set; }

        [InverseProperty("Supplier")]
        public virtual ICollection<SupplierPurchase> SupplierPurchase { get; set; }
    }
}
