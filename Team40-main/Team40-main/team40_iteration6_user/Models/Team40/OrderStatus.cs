using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class OrderStatus
    {
        public OrderStatus()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        [Column("OrderStatusID")]
        public int OrderStatusId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        [InverseProperty("OrderStatus")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
