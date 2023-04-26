using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using team40_iteration6_user.Models;
using team40_iteration6_user.Team40;
using Microsoft.EntityFrameworkCore;
using team40_iteration6_user.ViewModel;
using System.Threading.Tasks;

namespace team40_iteration6_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkshopSlotController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        //public int WorkshopId { get; private set; }
        //public DateTime WorkshopDate { get; private set; }
        //public int HostId { get; private set; }
        //public int WorkshopTypeId { get; private set; }
        //public int WorkshopVenueId { get; private set; }

        public WorkshopSlotController(IRepository Repository)
        {
            _Repository = Repository;
        }
        [HttpGet]
        [Route("Test")]
        public object GetYipee()
        {
            return Ok("Yipeeee");
        }
        //[HttpGet]
        //[Route("GetAll")]
        //public ActionResult GetAll()
        //{
        //    try
        //    {
        //        List<Workshop> dbWorkshop = _CoreDbContext.Workshop.ToList();

        //        List<Workshop> WorkshopSlotList = new List<Workshop>();

        //        foreach (var c in dbWorkshop)
        //        {
        //            Workshop oWorkshopSlot = new Workshop();

        //            oWorkshopSlot.WorkshopId = c.WorkshopId;
        //            oWorkshopSlot.WorkshopDate = c.WorkshopDate;
        //            oWorkshopSlot.HostId = c.HostId;
        //            oWorkshopSlot.WorkshopTypeId = c.WorkshopTypeId;
        //            oWorkshopSlot.WorkshopVenueId = c.WorkshopVenueId;

        //            WorkshopSlotList.Add(oWorkshopSlot); //1
        //        }
        //        return Ok(WorkshopSlotList);

        //    }
        //    catch (Exception e)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
        //    }

        //}

        //[HttpGet]
        //[Route("GetWorkshopSlotByID")]
        //public ActionResult GetWorkshopSlot(int id)
        //{
        //    try
        //    {
        //        List<Workshop> dbWorkshop = _CoreDbContext.Workshop.ToList();

        //        List<Workshop> WorkshopList = new List<Workshop>();

        //        foreach (var c in dbWorkshop)
        //        {
        //            Workshop oWorkshopSlot = new Workshop();//2

        //            if (id == c.WorkshopId)
        //            {
        //                oWorkshopSlot.WorkshopId = c.WorkshopId;
        //                oWorkshopSlot.WorkshopDate = c.WorkshopDate;
        //                oWorkshopSlot.HostId = c.HostId;
        //                oWorkshopSlot.WorkshopTypeId = c.WorkshopTypeId;
        //                oWorkshopSlot.WorkshopVenueId = c.WorkshopVenueId;


        //                WorkshopList.Add(oWorkshopSlot);//3

        //            }
        //            else
        //            {

        //            }
        //        }
        //        return Ok(WorkshopList);

        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
        //    }
        //}

        //[HttpPost]
        //[Route("AddWorkshopSlot")]
        //public ActionResult AddWorkshopSlot(Workshop cvm)
        //{


        //    var Workshop = new Workshop
        //    {
        //        WorkshopDate = cvm.WorkshopDate,
        //        WorkshopType = cvm.WorkshopType,
        //        WorkshopVenue = cvm.WorkshopVenue,
        //        HostId = cvm.HostId
        //    };

        //    try
        //    {
        //        using (var contextmodel = new CoreDbContext())
        //        {

        //            contextmodel.Add(Workshop);//4
        //            contextmodel.SaveChanges();

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
        //    }

        //    return StatusCode(StatusCodes.Status200OK, "New Workshoptype saved");
        //}

        //[HttpPut]
        //[Route("UpdateWorkshoptype")]

        //public ActionResult UpdateWorkshopSlot(int id, Workshop cvm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    using (var contextmodel = new CoreDbContext())
        //    {

        //        var existingWorkshopSlot = contextmodel.Workshop.Where(c => c.WorkshopId == id).FirstOrDefault<Workshop>();

        //        if (existingWorkshopSlot != null)
        //        {
        //            existingWorkshopSlot.WorkshopId = cvm.WorkshopId;
        //            existingWorkshopSlot.WorkshopDate = cvm.WorkshopDate;
        //            existingWorkshopSlot.HostId = cvm.HostId;
        //            existingWorkshopSlot.WorkshopTypeId = cvm.WorkshopTypeId;
        //            existingWorkshopSlot.WorkshopVenueId = cvm.WorkshopVenueId;

        //            try
        //            {
        //                contextmodel.Workshop.Update(existingWorkshopSlot);
        //                contextmodel.SaveChanges();
        //            }
        //            catch (Exception e)
        //            {
        //                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
        //            }


        //        }
        //        else
        //        {
        //            return NotFound();
        //        }
        //    }


        //    return StatusCode(StatusCodes.Status200OK, "Workshop Slot updated");

        //}

        //[HttpDelete]
        //[Route("DeleteWorkshopSlot")]
        //public ActionResult DeleteWorkshopSlot(int id, Workshop cvm)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest();
        //        }

        //        using (var contextmodel = new CoreDbContext())
        //        {

        //            var existingWorkshopSlot = contextmodel.Workshop.Where(c => c.WorkshopId == id).FirstOrDefault<Workshop>();

        //            if (existingWorkshopSlot != null)

        //            {

        //                if (existingWorkshopSlot == null) return NotFound();


        //                contextmodel.Workshop.Remove(existingWorkshopSlot);
        //                contextmodel.SaveChanges();


        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
        //    }

        //    return StatusCode(StatusCodes.Status200OK, "Workshop Slot deleted");

        //}
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

        [Route("GetSlotsCLient")]
        public object GetSlotsClient()
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
                ).Where(w => w.WorkshopDate > DateTime.Now).ToList();
            return discounts;

        }


        [HttpGet]
        [Route("GetAllHosts")]
        public ActionResult GetAllHosts()
        {
            try
            {
                List<WorkshopHost> dbHosts = _CoreDbContext.WorkshopHost.ToList();

                List<WorkshopHost> HostList = new List<WorkshopHost>();

                foreach (var c in dbHosts)
                {
                    WorkshopHost oHost = new WorkshopHost();

                    oHost.HostId = c.HostId;
                    oHost.HostName = c.HostName;
                    oHost.HostSurname = c.HostSurname;
                    oHost.HostEmail = c.HostEmail;

                    HostList.Add(oHost);
                }
                return Ok(HostList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetAllWTypes")]
        public ActionResult GetAllWTypes()
        {
            try
            {
                List<WorkshopType> dbWorkshopTypes = _CoreDbContext.WorkshopType.ToList();

                List<WorkshopType> WorkshopTypeList = new List<WorkshopType>();

                foreach (var c in dbWorkshopTypes)
                {
                    WorkshopType oWorkshoptype = new WorkshopType();

                    oWorkshoptype.Description = c.Description;
                    oWorkshoptype.WorkshopTypeId = c.WorkshopTypeId;

                    WorkshopTypeList.Add(oWorkshoptype);
                }
                return Ok(WorkshopTypeList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetAllVenues")]
        public ActionResult GetAllVenues()
        {
            try
            {
                List<WorkshopVenue> dbWorkshopVenues = _CoreDbContext.WorkshopVenue.ToList();

                List<WorkshopVenue> WorkshopVenueList = new List<WorkshopVenue>();

                foreach (var c in dbWorkshopVenues)
                {
                    WorkshopVenue oWorkshopVenue = new WorkshopVenue();

                    oWorkshopVenue.Address = c.Address;
                    oWorkshopVenue.VenueName = c.VenueName;

                    oWorkshopVenue.WorkshopVenueId = c.WorkshopVenueId;

                    WorkshopVenueList.Add(oWorkshopVenue);
                }
                return Ok(WorkshopVenueList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpPost]
        [Route("AddSlot")]
        public async Task<ActionResult> AddSlot(Workshop cvm)

        {
            try
            {
                var slots = new Workshop
                {
                    HostId = cvm.HostId,
                    WorkshopTypeId = cvm.WorkshopTypeId,
                    WorkshopVenueId = cvm.WorkshopVenueId,
                    WorkshopDate = cvm.WorkshopDate,
                    Price = cvm.Price,

                };
                using (var contextmodel = new CoreDbContext())
                {

                    contextmodel.Add(slots);
                    contextmodel.SaveChanges();

                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }

            return Ok();


        }

        [HttpPut]
        [Route("UpdateWSlot")]
        public ActionResult UpdateWSlot(int id, Workshop cvm)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (var contextmodel = new CoreDbContext())
            {

                var existing = contextmodel.Workshop.Where(c => c.WorkshopId == id).FirstOrDefault<Workshop>();

                if (existing != null)
                {
                    existing.WorkshopId = id;
                    existing.WorkshopDate = cvm.WorkshopDate;
                    existing.WorkshopVenueId = cvm.WorkshopVenueId;
                    existing.Price = cvm.Price;
                    existing.HostId = cvm.HostId;

                    try
                    {
                        contextmodel.Workshop.Update(existing);
                        contextmodel.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
                    }


                }
                else
                {
                    return NotFound();
                }

            }
            return Ok();

        }

        [HttpGet]
        [Route("GetWSlotByID")]
        public ActionResult GetWSlotByID(int id)
        {
            try
            {
                List<Workshop> db = _CoreDbContext.Workshop.ToList();
                List<Workshop> List = new List<Workshop>();

                foreach (var c in db)
                {
                    Workshop o = new Workshop();

                    if (id == c.WorkshopId)
                    {
                        o.WorkshopDate = c.WorkshopDate;
                        o.WorkshopVenueId = c.WorkshopVenueId;
                        o.WorkshopId = c.WorkshopId;
                        o.HostId = c.HostId;
                        o.Price = c.Price;



                        List.Add(o);
                    }
                    else
                    {

                    }
                }
                return Ok(List);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }

        [HttpPost]
        [Route("DeleteWSlot")]
        public ActionResult DeleteWSlot(Workshop cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existing = contextmodel.Workshop.Where(c => c.WorkshopId == cvm.WorkshopId).FirstOrDefault<Workshop>();

                    if (existing != null)

                    {

                        if (existing == null) return NotFound();


                        contextmodel.Workshop.Remove(existing);
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

        [HttpGet]
        [Route("GetWorkshopPerformanceReport")]
        public object GetWorkshopPerformanceReport()
        {
            try
            {

                Random rd = new Random();



                List<Workshoperformancereport> reportlist =
                     (

                from h in _CoreDbContext.WorkshopHost.ToList()
                join w in _CoreDbContext.Workshop.ToList()
                on h.HostId equals w.HostId
                join v in _CoreDbContext.WorkshopVenue.ToList()
                on w.WorkshopVenueId equals v.WorkshopVenueId
                join t in _CoreDbContext.WorkshopType.ToList()
                on w.WorkshopTypeId equals t.WorkshopTypeId

                select new Workshoperformancereport
                {
                    workshopdate = w.WorkshopDate,
                    numerattended = rd.Next(1, 30),
                    NetProfit = 0,
                    SalesRevenue = rd.Next(30, 300),
                    workshoptype = t.Description,
                    totalBookings = rd.Next(31, 35),
                    WorkshopID = w.WorkshopId,
                    workshopvenue = v.VenueName,
                    workshopprice = w.Price


                }).ToList();

                return reportlist;


            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }



    }


}
