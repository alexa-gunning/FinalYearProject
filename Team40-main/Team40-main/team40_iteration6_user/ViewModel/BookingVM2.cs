using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.ViewModel
{
    public class BookingVM2
    {

    //    WorkshopId = bvm.WorkshopID,
    //                BookingStatusId = 1,
    //                Date = DateTime.Today,
    //            };
    //var booking2 = new Booking
    //{


    //    BookingDate = DateTime.Today,
    //    ClientId = bvm.ClientID,
    //    AttendanceStatusId = 2,
        public int WorkshopId { get; set; }
        public int BookingStatusId { get; set; }
        public DateTime Date { get; set;  }
        public DateTime BookingDate { get; set; }
        public int ClientId { get; set; }
        public int AttendanceStatusId { get; set; }
    }
}
