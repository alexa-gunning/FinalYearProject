using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class WriteOffReason
    {
        public WriteOffReason()
        {
            WriteOffInventory = new HashSet<WriteOffInventory>();
        }

        [Key]
        [Column("WriteOffReasonID")]
        public int WriteOffReasonId { get; set; }
        [Column("WriteOffReason_Description")]
        [StringLength(255)]
        public string WriteOffReasonDescription { get; set; }

        [InverseProperty("WriteOffReason")]
        public virtual ICollection<WriteOffInventory> WriteOffInventory { get; set; }
    }
}
