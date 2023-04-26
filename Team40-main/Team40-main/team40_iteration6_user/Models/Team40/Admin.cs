using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Policy = new HashSet<Policy>();
        }

        [Key]
        [Column("AdministratorID")]
        public int AdministratorId { get; set; }
        [Column("UserID")]
        public int? UserId { get; set; }
        [StringLength(255)]
        public string AdministratorName { get; set; }
        [StringLength(255)]
        public string AdministratorSurname { get; set; }
        [StringLength(255)]
        public string AdministratorPhoneNumber { get; set; }
        [StringLength(255)]
        public string AdministratorEmail { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Admin")]
        public virtual User User { get; set; }
        [InverseProperty("Admin")]
        public virtual ICollection<Policy> Policy { get; set; }
    }
}
