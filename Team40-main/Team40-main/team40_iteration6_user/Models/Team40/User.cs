using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace team40_iteration6_user.Models
{
    public partial class User
    {
        public User()
        {
            Admin = new HashSet<Admin>();
            Client = new HashSet<Client>();
        }

        [Key]
        [Column("UserID")]
        public int UserId { get; set; }
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(255)]
        
        public string Username { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Admin> Admin { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Client> Client { get; set; }
    }
}
