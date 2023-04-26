using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Booking
    {
        [Key]
        [Column("BookingID")]
        public int BookingId { get; set; }
        [Column("BookingInstanceID")]
        public int BookingInstanceId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime BookingDate { get; set; }
        [Column("ClientID")]
        public int ClientId { get; set; }
        [Column("AttendanceStatusID")]
        public int? AttendanceStatusId { get; set; }

        [ForeignKey(nameof(AttendanceStatusId))]
        [InverseProperty(nameof(AttendingStatus.Booking))]
        public virtual AttendingStatus AttendanceStatus { get; set; }
        [ForeignKey(nameof(BookingInstanceId))]
        [InverseProperty("Booking")]
        public virtual BookingInstance BookingInstance { get; set; }
        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Booking")]
        public virtual Client Client { get; set; }
    }
}
