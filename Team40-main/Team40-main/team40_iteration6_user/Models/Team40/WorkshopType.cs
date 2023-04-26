using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class WorkshopType
    {
        public WorkshopType()
        {
            Workshop = new HashSet<Workshop>();
            WorkshopTypeEquipment = new HashSet<WorkshopTypeEquipment>();
        }

        [Key]
        [Column("WorkshopTypeID")]
        public int WorkshopTypeId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        [InverseProperty("WorkshopType")]
        public virtual ICollection<Workshop> Workshop { get; set; }
        [InverseProperty("WorkshopType")]
        public virtual ICollection<WorkshopTypeEquipment> WorkshopTypeEquipment { get; set; }
    }
}
