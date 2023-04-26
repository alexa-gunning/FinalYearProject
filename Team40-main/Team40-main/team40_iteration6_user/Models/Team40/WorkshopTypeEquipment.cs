using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    [Table("WorkshopType_Equipment")]
    public partial class WorkshopTypeEquipment
    {
        [Key]
        [Column("WorkshopTypeID")]
        public int WorkshopTypeId { get; set; }
        [Key]
        [Column("WorkshopEquipmentID")]
        public int WorkshopEquipmentId { get; set; }

        [ForeignKey(nameof(WorkshopEquipmentId))]
        [InverseProperty("WorkshopTypeEquipment")]
        public virtual WorkshopEquipment WorkshopEquipment { get; set; }
        [ForeignKey(nameof(WorkshopTypeId))]
        [InverseProperty("WorkshopTypeEquipment")]
        public virtual WorkshopType WorkshopType { get; set; }
    }
}
