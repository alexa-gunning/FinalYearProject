using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class SubscriberStatus
    {
        public SubscriberStatus()
        {
            NewsletterSubscriber = new HashSet<NewsletterSubscriber>();
        }

        [Key]
        [Column("SubscriberStatusID")]
        public int SubscriberStatusId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        [InverseProperty("SubscriberStatus")]
        public virtual ICollection<NewsletterSubscriber> NewsletterSubscriber { get; set; }
    }
}
