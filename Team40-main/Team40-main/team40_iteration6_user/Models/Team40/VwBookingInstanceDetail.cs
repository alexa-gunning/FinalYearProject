using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class VwBookingInstanceDetail
    {
        [Column("BookingInstanceID")]
        public int BookingInstanceId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("WorkshopID")]
        public int WorkshopId { get; set; }
        [StringLength(255)]
        public string Type { get; set; }
        [StringLength(255)]
        public string VenueName { get; set; }
        [StringLength(255)]
        public string Address { get; set; }
        [StringLength(255)]
        public string HostName { get; set; }
        [StringLength(255)]
        public string HostSurname { get; set; }
        [StringLength(255)]
        public string HostEmail { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
    }
}
