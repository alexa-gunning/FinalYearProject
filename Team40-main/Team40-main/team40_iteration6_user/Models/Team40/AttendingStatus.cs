using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class AttendingStatus
    {
        public AttendingStatus()
        {
            Booking = new HashSet<Booking>();
        }

        [Key]
        [Column("AttendanceStatusID")]
        public int AttendanceStatusId { get; set; }
        [StringLength(255)]
        public string AttendanceStatusName { get; set; }

        [InverseProperty("AttendanceStatus")]
        public virtual ICollection<Booking> Booking { get; set; }
    }
}
