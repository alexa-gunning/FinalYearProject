using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.ViewModel
{
    public class UserViewModel
    {
        //[Required]
        //public string UserName { get; set; }
        ////data annotation for email address
        ////[DataType(DataType.EmailAddress)]
        ////public string EmailAddress { get; set; }
        //public string Password { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //public string userName { get; set; }
        //public string otp { get; set; }
    }
}
