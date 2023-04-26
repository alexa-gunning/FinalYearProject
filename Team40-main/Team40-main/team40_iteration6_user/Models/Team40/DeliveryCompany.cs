using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class DeliveryCompany
    {
        public DeliveryCompany()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        [Column("DeliveryCompanyID")]
        public int DeliveryCompanyId { get; set; }
        [StringLength(255)]
        public string DeliveryCompanyName { get; set; }
        //[StringLength(255)]
        //public string Method { get; set; }
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string DeliveryCompanyEmail { get; set; }
        [StringLength(255)]
        public string ContactPersonName { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? DeliveryCompanyBaseRate { get; set; }

        [InverseProperty("DeliveryCompany")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
