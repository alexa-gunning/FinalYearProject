using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Address
    {
        public Address()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        [Column("AddressID")]
        public int AddressId { get; set; }
        [StringLength(255)]
        public string StreetNumber { get; set; }
        [StringLength(255)]
        public string StreetName { get; set; }
        [StringLength(255)]
        public string City { get; set; }
        [StringLength(255)]
        public string Province { get; set; }
        [StringLength(255)]
        public string AreaCode { get; set; }
        [StringLength(255)]
        public string Country { get; set; }
        [Column("ClientID")]
        public int? ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Address")]
        public virtual Client Client { get; set; }
        [InverseProperty("Address")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
