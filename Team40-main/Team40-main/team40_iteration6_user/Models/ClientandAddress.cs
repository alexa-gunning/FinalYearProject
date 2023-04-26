using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.Models
{
    public class ClientandAddress
    {
        public int ClientId { get; set; }
        
        public string Name { get; set; }
        
        public string Surname { get; set; }
 
        public string PhoneNumber { get; set; }

        public DateTime? BirthDate { get; set; }
 
        public string EmailAddress { get; set; }
        public int AddressId { get; set; }
       
        public string StreetNumber { get; set; }
        
        public string StreetName { get; set; }
       
        public string City { get; set; }
   
        public string Province { get; set; }

        public string AreaCode { get; set; }
    
        public string Country { get; set; }
    
    }
}
