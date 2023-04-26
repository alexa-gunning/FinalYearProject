using team40_iteration6_user.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.ViewModel
{
    public class BookingVM
    {
        public Booking Booking { get; set; }
        public BookingInstance BookingInstance { get; set; }
        public Workshop Workshop { get; set; }
        public AttendingStatus AttendingStatus { get; set; }
        public BookingStatus BookingStatus { get; set; }
        public WorkshopVenue WorkshopVenue { get; set; }
        public WorkshopHost WorkshopHost { get; set; }
        public WorkshopType WorkshopType { get; set; }

        /*****Entity ID's*****/
        public int BookingInstanceID { get; set; }
        public int WorkshopID { get; set; }
        public int BookingStatusID { get; set; }
        public int BookingID { get; set; }
        public int WorkshopTypeID { get; set; }
        public int HostID { get; set; }
        public int WorkshopVenueID { get; set; }
        public int ClientID { get; set; }
        public int AttendingStatusID { get; set; }
        

        /***********BookingStatus**********/
        public string BookingStatusDescription { get; set; }
        public string LastUpdated { get; set; }

        /***********BookingInstance**********/
        public DateTime Date { get; set; }

        /***********Booking**********/
        public DateTime BookingDate { get; set; }

        /***********AttendingStatus**********/
        public int AttendanceStatusName { get; set; }

        /***********Workshop**********/
        public double Price { get; set; }

        /***********WorkshopType**********/
        public string Description { get; set; }

        /***********WorkshopVenue**********/
        public double VenueName { get; set; }
        public double Address { get; set; }
    }
}
