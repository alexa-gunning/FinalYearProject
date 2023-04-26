using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class WorkshopHost
    {
        public WorkshopHost()
        {
            Workshop = new HashSet<Workshop>();
        }

        [Key]
        [Column("HostID")]
        public int HostId { get; set; }
        [StringLength(255)]
        public string HostName { get; set; }
        [StringLength(255)]
        public string HostSurname { get; set; }
        [StringLength(255)]
        public string HostEmail { get; set; }

        [InverseProperty("Host")]
        public virtual ICollection<Workshop> Workshop { get; set; }
    }
}
