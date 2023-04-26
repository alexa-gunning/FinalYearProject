using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Policy
    {
        [Key]
        [Column("PolicyID")]
        public int PolicyId { get; set; }
        [StringLength(225)]
        public string PolicyName { get; set; }
        [StringLength(225)]  
        public string Description { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("AdminID")]
        public int? AdminId { get; set; }

        [ForeignKey(nameof(AdminId))]
        [InverseProperty("Policy")]
        public virtual Admin Admin { get; set; }
    }
}
