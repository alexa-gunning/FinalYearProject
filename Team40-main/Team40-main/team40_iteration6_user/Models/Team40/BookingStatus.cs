using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class BookingStatus
    {
        public BookingStatus()
        {
            BookingInstance = new HashSet<BookingInstance>();
        }

        [Key]
        [Column("BookingStatusID")]
        public int BookingStatusId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LastUpdated { get; set; }

        [InverseProperty("BookingStatus")]
        public virtual ICollection<BookingInstance> BookingInstance { get; set; }
    }
}
