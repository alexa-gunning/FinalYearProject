using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class WorkshopVenue
    {
        public WorkshopVenue()
        {
            Workshop = new HashSet<Workshop>();
        }

        [Key]
        [Column("WorkshopVenueID")]
        public int WorkshopVenueId { get; set; }
        [StringLength(255)]
        public string VenueName { get; set; }
        [StringLength(255)]
        public string Address { get; set; }

        [InverseProperty("WorkshopVenue")]
        public virtual ICollection<Workshop> Workshop { get; set; }
    }
}
