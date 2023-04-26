using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class WorkshopEquipment
    {
        public WorkshopEquipment()
        {
            WorkshopTypeEquipment = new HashSet<WorkshopTypeEquipment>();
        }

        [Key]
        [Column("WorkshopEquipmentID")]
        public int WorkshopEquipmentId { get; set; }
        [StringLength(255)]
        public string Description { get; set; }

        [InverseProperty("WorkshopEquipment")]
        public virtual ICollection<WorkshopTypeEquipment> WorkshopTypeEquipment { get; set; }
    }
}
