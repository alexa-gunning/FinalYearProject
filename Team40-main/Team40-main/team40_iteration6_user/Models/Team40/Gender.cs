using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Client = new HashSet<Client>();
        }

        [Key]
        [Column("GenderID")]
        public int GenderId { get; set; }
        [StringLength(225)]
        public string GenderName { get; set; }

        [InverseProperty("Gender")]
        public virtual ICollection<Client> Client { get; set; }
    }
}
