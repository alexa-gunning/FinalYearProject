using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.ViewModel
{
    public class BookingWithClientVM
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }
        public string typeDescription { get; set; }

        public DateTime? BirthDate { get; set; }
        public DateTime? Date { get; set; }


        public string EmailAddress { get; set; }
        public int BookingInstanceId { get; set; }
        public int WorkshopId { get; set; }
        public int BookingStatusId { get; set; }
        public int BookingId { get; set; }
        public int WorkshopTypeId { get; set; }
        public int HostId { get; set; }
        public int WorkshopVenueId { get; set; }
        //public int ClientID { get; set; }
        public int AttendingStatusId { get; set; }
        public string AttendanceStatusName { get; set; }
        public decimal Price { get; set; }
        public string hostName { get; set; }
        public string hostEmail { get; set; }
        public string address { get; set; }

        public string venueName { get; set; }
        public DateTime workshopDate { get; set; }
    }
}
