using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Workshop
    {
        public Workshop()
        {
            BookingInstance = new HashSet<BookingInstance>();
        }

        [Key]
        [Column("WorkshopID")]
        public int WorkshopId { get; set; }
        [Column("HostID")]
        public int HostId { get; set; }
        [Column("WorkshopTypeID")]
        public int WorkshopTypeId { get; set; }
        [Column("WorkshopVenueID")]
        public int WorkshopVenueId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        public DateTime WorkshopDate { get; set; }

        [ForeignKey(nameof(HostId))]
        [InverseProperty(nameof(WorkshopHost.Workshop))]
        public virtual WorkshopHost Host { get; set; }
        [ForeignKey(nameof(WorkshopTypeId))]
        [InverseProperty("Workshop")]
        public virtual WorkshopType WorkshopType { get; set; }
        [ForeignKey(nameof(WorkshopVenueId))]
        [InverseProperty("Workshop")]
        public virtual WorkshopVenue WorkshopVenue { get; set; }
        [InverseProperty("Workshop")]
        public virtual ICollection<BookingInstance> BookingInstance { get; set; }
    }
}
