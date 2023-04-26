using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class NewsletterSubscriber
    {
        [Key]
        [Column("NewsletterID")]
        public int NewsletterId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("SubscriberStatusID")]
        public int? SubscriberStatusId { get; set; }
        [Column("ClientID")]
        public int? ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("NewsletterSubscriber")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(SubscriberStatusId))]
        [InverseProperty("NewsletterSubscriber")]
        public virtual SubscriberStatus SubscriberStatus { get; set; }
    }
}
