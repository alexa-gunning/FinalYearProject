using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Payment = new HashSet<Payment>();
        }

        [Key]
        [Column("CartID")]
        public int CartId { get; set; }
        [Column("ProductID")]
        public int? ProductId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column("ClientID")]
        public int? ClientId { get; set; }
        [Column("BookingID")]
        public int? BookingId { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Cart")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("Cart")]
        public virtual Product Product { get; set; }
        [InverseProperty("Cart")]
        public virtual ICollection<Payment> Payment { get; set; }
    }
}
