using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Client
    {
        public Client()
        {
            Address = new HashSet<Address>();
            Booking = new HashSet<Booking>();
            Cart = new HashSet<Cart>();
            NewsletterSubscriber = new HashSet<NewsletterSubscriber>();
            Order = new HashSet<Order>();
        }

        [Key]
        [Column("ClientID")]
        public int ClientId { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string Surname { get; set; }
        [StringLength(255)]
        public string PhoneNumber { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BirthDate { get; set; }
        [StringLength(255)]
        public string EmailAddress { get; set; }
        [Column("GenderID")]
        public int? GenderId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }

        [ForeignKey(nameof(GenderId))]
        [InverseProperty("Client")]
        public virtual Gender Gender { get; set; }
        [ForeignKey(nameof(UserId))]
        [InverseProperty("Client")]
        public virtual User User { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<Address> Address { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<Booking> Booking { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<Cart> Cart { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<NewsletterSubscriber> NewsletterSubscriber { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
