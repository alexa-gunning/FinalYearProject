using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.ViewModel
{
    public class ForgotPassword
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
    }
}
