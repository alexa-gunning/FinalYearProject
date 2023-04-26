using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using team40_iteration6_user.Models;
using team40_iteration6_user.Team40;
using team40_iteration6_user.ViewModel;

namespace team40_iteration6_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public BookingController(IRepository Repository)
        {
            _Repository = Repository;
        }

        [HttpGet]
        [Route("GetAllBookings")]
        public ActionResult GetAllBookings()
        {
            try
            {
                List<Booking> dbBookings = _CoreDbContext.Booking.ToList();
                List<Booking> BookingList = new List<Booking>();

                foreach (var b in dbBookings)
                {
                    Booking oBooking = new Booking();

                    oBooking.BookingId = b.BookingId;
                    oBooking.BookingInstanceId = b.BookingInstanceId;
                    oBooking.BookingDate = b.BookingDate;
                    oBooking.ClientId = b.ClientId;

                    BookingList.Add(oBooking);
                }
                return Ok(BookingList);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }
        [HttpGet]
        [Route("GetBookingsWithClients")]
        public object GetBookingsWithClients()
        {
            try
            {
                List<BookingWithClientVM> d = (
               from w in _CoreDbContext.Workshop.ToList()
               join bi in _CoreDbContext.BookingInstance.ToList()
               on w.WorkshopId equals bi.WorkshopId
               join b in _CoreDbContext.Booking.ToList()
               on  bi.BookingInstanceId equals b.BookingInstanceId
               join a in _CoreDbContext.AttendingStatus.ToList()
             on b.AttendanceStatusId equals a.AttendanceStatusId
               join c in _CoreDbContext.Client.ToList()
               on b.ClientId equals c.ClientId
              join t in _CoreDbContext.WorkshopType.ToList()
              on w.WorkshopTypeId equals t.WorkshopTypeId
               join v in _CoreDbContext.WorkshopVenue.ToList()
            on w.WorkshopVenueId equals v.WorkshopVenueId
               join h in _CoreDbContext.WorkshopHost.ToList()
            on w.HostId equals h.HostId
               select new BookingWithClientVM

               {
                   WorkshopId = w.WorkshopId,
                   ClientId = b.ClientId,
                   workshopDate = w.WorkshopDate,
                   Name = c.Name,
                   Surname = c.Surname,
                   BookingId = b.BookingId,
                   AttendanceStatusName = a.AttendanceStatusName,
                   typeDescription = t.Description,
                   venueName = v.VenueName,
                   hostName = h.HostName,
                   Date = bi.Date
               }
               ).ToList();
                return d;

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }
        [HttpGet]
        [Route("GetBookingById")]
        public ActionResult GetBookingById(int id)
        {
            try
            {
                List<Booking> dbBookings = _CoreDbContext.Booking.ToList();
                List<Booking> BookingList = new List<Booking>();

                foreach (var b in dbBookings)
                {
                    Booking oBooking = new Booking();

                    if (id == b.BookingId)
                    {
                        oBooking.BookingId = b.BookingId;
                        oBooking.BookingInstanceId = b.BookingInstanceId;
                        oBooking.BookingDate = b.BookingDate;
                        oBooking.ClientId = b.ClientId;

                        BookingList.Add(oBooking);
                    }
                    else
                    {

                    }
                }

                if (BookingList.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(BookingList);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }


        [HttpPost]
        [Route("AddBooking")]
        public ActionResult AddBooking(Booking bvm)
        {
          
            using (var contextmodel = new CoreDbContext())
            {
            
                var booking = new Booking
                {
                    BookingId = bvm.BookingId,
                    BookingInstanceId = bvm.BookingInstanceId,
                    BookingDate = bvm.BookingDate,
                    ClientId = bvm.ClientId
                };

                try
                {
           
                    contextmodel.Add(booking);
                    contextmodel.SaveChanges();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
                }
                return Ok();
            }
        }

        [HttpPost]
        [Route("AddBookingInstance")]
        public ActionResult AddBookingInstance(int WorkshopId)
        {
            using (var contextmodel = new CoreDbContext())
            {
                var date = new Workshop();
                var booking1 = new BookingInstance
                {
                  
                    
                    WorkshopId = WorkshopId,
                    BookingStatusId = 1,
                    Date = DateTime.Today,
                };
            
                    try
                    {
                    //if(booking1.Date < date.WorkshopDate)
                    //{ 

                        contextmodel.Add(booking1);
                        contextmodel.SaveChanges();
                         }

                    //else
                    //{
                    //    return Ok("cannot book a workshop thats already done");
                    //}
                    //}

                    catch (Exception e)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
                    }
            
                return Ok();

            }
        }
      
        [HttpPost]
        [Route("AddBooking2")]
        //int BookingInstanceId
        public ActionResult AddBooking2(int ClientId)
        {
            using (var contextmodel = new CoreDbContext())
            {
                var date = new Workshop();
                var maxId = _CoreDbContext.BookingInstance.Max(m => m.BookingInstanceId);
                var booking2 = new Booking
                {
                
                BookingInstanceId =  maxId ,
                    BookingDate = DateTime.Today,
                    ClientId =ClientId,
                    AttendanceStatusId = 2,
                };
                try
                {
                    //if (booking2.BookingDate < date.WorkshopDate)
                    //{

                        contextmodel.Add(booking2);
                        contextmodel.SaveChanges();
                    //}

                    //else
                    //{
                    //    return Ok("cannot book a workshop thats already done");
                    //}
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
                }
                return Ok();
            }
        }


        [HttpPut]
        [Route("UpdateBooking")]
        public ActionResult UpdateBooking(int id, Booking bvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (var contextmodel = new CoreDbContext())
            {
                var existingBooking = contextmodel.Booking.Where(b => b.BookingId == id).FirstOrDefault<Booking>();

                if (existingBooking != null)
                {
                    existingBooking.BookingId = id;
                    existingBooking.BookingInstanceId = bvm.BookingInstanceId;
                    existingBooking.BookingDate = bvm.BookingDate;
                    existingBooking.ClientId = bvm.ClientId;

                    try
                    {
                        contextmodel.Booking.Update(existingBooking);
                        contextmodel.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            return StatusCode(StatusCodes.Status200OK, "Booking updated");
        }

        [HttpDelete]
        [Route("DeleteBooking")]
        public ActionResult DeleteBooking(int id, Booking bvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {
                    var existingBooking = contextmodel.Booking.Where(c => c.BookingId == id).FirstOrDefault<Booking>();

                    if (existingBooking != null)

                    {
                        if (existingBooking == null) return NotFound();

                        contextmodel.Booking.Remove(existingBooking);
                        contextmodel.SaveChanges();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, "Bookng Slot deleted");
        }



        //CODE FOR ATTENDANCE
        [HttpGet]
        [Route("GetAllClients")]
        public ActionResult GetAllClients()
        {
            try
            {
                List<Client> dbClients = _CoreDbContext.Client.ToList();

                List<Client> ClientList = new List<Client>();

                foreach (var c in dbClients)
                {
                    Client oClient = new Client();

                    oClient.ClientId = c.ClientId;
                    oClient.Name = c.Name;
                    oClient.Surname = c.Surname;
                    oClient.PhoneNumber = c.PhoneNumber;
                    oClient.BirthDate = c.BirthDate;
                    oClient.EmailAddress = c.EmailAddress;
                    oClient.GenderId = c.GenderId;
                    oClient.UserId = c.UserId;

                    ClientList.Add(oClient);
                }
                return Ok(ClientList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }
        [HttpGet]

        [Route("GetSlots")]
        public object GetSlots()
        {
            List<WorkshopSlotVM> discounts = (

                from h in _CoreDbContext.WorkshopHost.ToList()
                join w in _CoreDbContext.Workshop.ToList()
                on h.HostId equals w.HostId
                join v in _CoreDbContext.WorkshopVenue.ToList()
                on w.WorkshopVenueId equals v.WorkshopVenueId
                join t in _CoreDbContext.WorkshopType.ToList()
                on w.WorkshopTypeId equals t.WorkshopTypeId
                select new WorkshopSlotVM
                {
                    WorkshopId = w.WorkshopId,
                    HostId = h.HostId,
                    HostName = h.HostName,
                    WorkshopTypeId = t.WorkshopTypeId,
                    TypeDescription = t.Description,
                    WorkshopVenueId = v.WorkshopVenueId,
                    VenueName = v.VenueName,
                    Price = w.Price,
                    WorkshopDate = w.WorkshopDate,
                    address = v.Address
                }
                ).ToList();
            return discounts;

        }

        [HttpGet]
        [Route("GetAllAttendance")]
        public ActionResult GetAllAttendance()
        {
            try
            {
                List<AttendingStatus> dbAttendingStatuses = _CoreDbContext.AttendingStatus.ToList();

                List<AttendingStatus> AttendingStatusList = new List<AttendingStatus>();

                foreach (var c in dbAttendingStatuses)
                {
                    AttendingStatus oAttendingStatus = new AttendingStatus();

                    oAttendingStatus.AttendanceStatusId = c.AttendanceStatusId;
                    oAttendingStatus.AttendanceStatusName = c.AttendanceStatusName;

                    AttendingStatusList.Add(oAttendingStatus);
                }
                return Ok(AttendingStatusList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }


        }

        [HttpGet]
        [Route("GetAllBookingInstances")]
        public ActionResult GetAllBookingInstances()
        {
            try
            {
                List<BookingInstance> dbBookingsInstance = _CoreDbContext.BookingInstance.ToList();
                List<BookingInstance> BookingInstanceList = new List<BookingInstance>();

                foreach (var b in dbBookingsInstance)
                {
                    BookingInstance oBookingInstance = new BookingInstance();

                    oBookingInstance.BookingInstanceId = b.BookingInstanceId;
                    oBookingInstance.WorkshopId = b.WorkshopId;
                    oBookingInstance.Date = b.Date;
                    oBookingInstance.BookingStatusId = b.BookingStatusId;

                    BookingInstanceList.Add(oBookingInstance);
                }
                return Ok(BookingInstanceList);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }


        [HttpGet]
        [Route("GetBookingByClientID")]
        public object GetClientByClientID(int id)
        {
            try
            {
                //List<Booking> dbClients = _CoreDbContext.Booking.ToList();
                ////List<BookingWithClientVM> ClientList = new List<BookingWithClientVM>();

                //foreach (var i in dbClients)
                //{
                //    //Booking oClient1 = new Booking();
                //    //BookingWithClientVM oClient1 = new BookingWithClientVM();

                //    if (id == i.ClientId)
                    //{
                        //oClient1.ClientId = c.ClientId;
                        //oClient1.BookingId = c.BookingId;
                        //oClient1.BookingInstanceId = c.BookingInstanceId;
                        //oClient1.BookingDate = c.BookingDate;
                        //oClient1.ClientId = c.ClientId;

                        List <BookingWithClientVM> d = (
             from w in _CoreDbContext.Workshop.ToList()
             join bi in _CoreDbContext.BookingInstance.ToList()
             on w.WorkshopId equals bi.WorkshopId
             join b in _CoreDbContext.Booking.ToList()
             on bi.BookingInstanceId equals b.BookingInstanceId
             join a in _CoreDbContext.AttendingStatus.ToList()
           on b.AttendanceStatusId equals a.AttendanceStatusId
             join c in _CoreDbContext.Client.ToList()
             on b.ClientId equals c.ClientId
             join t in _CoreDbContext.WorkshopType.ToList()
               on w.WorkshopTypeId equals t.WorkshopTypeId
             join v in _CoreDbContext.WorkshopVenue.ToList()
          on w.WorkshopVenueId equals v.WorkshopVenueId
             join h in _CoreDbContext.WorkshopHost.ToList()
          on w.HostId equals h.HostId
             select new BookingWithClientVM

             {
                 WorkshopId = w.WorkshopId,
                 ClientId = b.ClientId,
                 workshopDate = w.WorkshopDate,
                Name = c.Name,
                 Surname = c.Surname,
                 BookingId = b.BookingId,
                 AttendanceStatusName = a.AttendanceStatusName,
                 typeDescription = t.Description,
                 venueName = v.VenueName,
                 hostName = h.HostName,
                 hostEmail = h.HostEmail,
                 address = v.Address,
                 Date = bi.Date
                 
                 
             }
             ).Where(b => id == b.ClientId && b.workshopDate > DateTime.Now).ToList();
                        return d;
                        //ClientList.Add( d );
                    //}
                    //else
                    //    {
                    //        return NotFound();
                    //    }
                    //}

                    ////if (ClientList.Count == 0)
                    ////{
                    ////    return NotFound();
                    ////}
                    ////else
                    ////{
                    ////    //return Ok(ClientList);
                    ////    return Ok(d);
                //}
                    //return d;
                }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetPastBookingByClientID")]
        public object GetPastBookingByClientID(int id)
        {
            try
            {
                //List<Booking> dbClients = _CoreDbContext.Booking.ToList();
                ////List<BookingWithClientVM> ClientList = new List<BookingWithClientVM>();

                //foreach (var i in dbClients)
                //{
                //    //Booking oClient1 = new Booking();
                //    //BookingWithClientVM oClient1 = new BookingWithClientVM();

                //    if (id == i.ClientId)
                //{
                //oClient1.ClientId = c.ClientId;
                //oClient1.BookingId = c.BookingId;
                //oClient1.BookingInstanceId = c.BookingInstanceId;
                //oClient1.BookingDate = c.BookingDate;
                //oClient1.ClientId = c.ClientId;

                List<BookingWithClientVM> d = (
     from w in _CoreDbContext.Workshop.ToList()
     join bi in _CoreDbContext.BookingInstance.ToList()
     on w.WorkshopId equals bi.WorkshopId
     join b in _CoreDbContext.Booking.ToList()
     on bi.BookingInstanceId equals b.BookingInstanceId
     join a in _CoreDbContext.AttendingStatus.ToList()
   on b.AttendanceStatusId equals a.AttendanceStatusId
     join c in _CoreDbContext.Client.ToList()
     on b.ClientId equals c.ClientId
     join t in _CoreDbContext.WorkshopType.ToList()
       on w.WorkshopTypeId equals t.WorkshopTypeId
     join v in _CoreDbContext.WorkshopVenue.ToList()
  on w.WorkshopVenueId equals v.WorkshopVenueId
     join h in _CoreDbContext.WorkshopHost.ToList()
  on w.HostId equals h.HostId
     select new BookingWithClientVM

     {
         WorkshopId = w.WorkshopId,
         ClientId = b.ClientId,
         workshopDate = w.WorkshopDate,
         Name = c.Name,
         Surname = c.Surname,
         BookingId = b.BookingId,
         AttendanceStatusName = a.AttendanceStatusName,
         typeDescription = t.Description,
         venueName = v.VenueName,
         hostName = h.HostName,
         hostEmail = h.HostEmail,
         address = v.Address,
         Date = bi.Date


     }
     ).Where(b => id == b.ClientId && b.workshopDate < DateTime.Now).ToList();
                return d;
                //ClientList.Add( d );
                //}
                //else
                //    {
                //        return NotFound();
                //    }
                //}

                ////if (ClientList.Count == 0)
                ////{
                ////    return NotFound();
                ////}
                ////else
                ////{
                ////    //return Ok(ClientList);
                ////    return Ok(d);
                //}
                //return d;
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpPost]
        [Route("DeleteBookingPost")]
        public ActionResult DeleteHostPost(Booking cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingHost = contextmodel.Booking.Where(c => c.BookingId == cvm.BookingId).FirstOrDefault<Booking>();

                    if (existingHost != null)

                    {

                        if (existingHost == null) return NotFound();


                        contextmodel.Booking.Remove(existingHost);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return Ok();

        }


       


    }
}