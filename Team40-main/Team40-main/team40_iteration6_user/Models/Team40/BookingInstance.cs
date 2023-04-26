using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class BookingInstance
    {
        public BookingInstance()
        {
            Booking = new HashSet<Booking>();
        }

        [Key]
        [Column("BookingInstanceID")]
        public int BookingInstanceId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("WorkshopID")]
        public int? WorkshopId { get; set; }
        [Column("BookingStatusID")]
        public int? BookingStatusId { get; set; }

        [ForeignKey(nameof(BookingStatusId))]
        [InverseProperty("BookingInstance")]
        public virtual BookingStatus BookingStatus { get; set; }
        [ForeignKey(nameof(WorkshopId))]
        [InverseProperty("BookingInstance")]
        public virtual Workshop Workshop { get; set; }
        [InverseProperty("BookingInstance")]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
