using Audit.WebApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using team40_iteration6_user.Models;
using team40_iteration6_user.Team40;

namespace team40_iteration6_user.Controllers

{
    [Route("api/[controller]")]
    //[AuditApi(EventTypeName = "{controller}/{action}")]
    [ApiController]
    public class WorkshopVenueController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public WorkshopVenueController(IRepository Repository)
        {
            _Repository = Repository;
        }

        [HttpGet]
        [Route("Test")]
        public object GetYipee()
        {
            return Ok("Yipeeee");
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
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

        [HttpGet]
        [Route("GetWorkshopVenueByID")]
        public ActionResult GetWorkshopVenue(int id)
        {
            try
            {
                List<WorkshopVenue> dbWorkshopVenues = _CoreDbContext.WorkshopVenue.ToList();
                List<WorkshopVenue> WorkshopVenueList = new List<WorkshopVenue>();

                foreach (var c in dbWorkshopVenues)
                {
                    WorkshopVenue oWorkshopVenue = new WorkshopVenue();

                    if (id == c.WorkshopVenueId)
                    {
                        oWorkshopVenue.Address = c.Address;
                        oWorkshopVenue.VenueName = c.VenueName;

                        oWorkshopVenue.WorkshopVenueId = c.WorkshopVenueId;


                        WorkshopVenueList.Add(oWorkshopVenue);
                    }
                    else
                    {

                    }
                }
                return Ok(WorkshopVenueList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }



        [HttpPost]
        [Route("AddWorkshopVenue")]
        public async Task<ActionResult> AddWorkshopVenueAsync(WorkshopVenue cvm)
        {
            var WorkshopVenue = await _Repository.GetVenueAsync(cvm.VenueName);
            var address = await _Repository.GetVenueAddressAsync(cvm.Address);

            try
            {
                if (WorkshopVenue == null && address == null)
                {
                    WorkshopVenue = new WorkshopVenue
                    {
                        Address = cvm.Address,
                        VenueName = cvm.VenueName
                    };
                    using (var contextmodel = new CoreDbContext())
                    {

                        contextmodel.Add(WorkshopVenue);
                        contextmodel.SaveChanges();

                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Venue already exists.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }

            return Ok();
        }

        [HttpPut]
        [Route("UpdateWorkshopVenue")]
        public async Task<ActionResult> UpdateWorkshopVenueAsync(int id, WorkshopVenue cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var WorkshopVenue = await _Repository.GetVenueAsync(cvm.VenueName);
            var address = await _Repository.GetVenueAddressAsync(cvm.Address);
            if (WorkshopVenue == null && address == null)
            {
                using (var contextmodel = new CoreDbContext())
                {

                    var existingWorkshopVenue = contextmodel.WorkshopVenue.Where(c => c.WorkshopVenueId == id).FirstOrDefault<WorkshopVenue>();

                    if (existingWorkshopVenue != null)
                    {
                        existingWorkshopVenue.WorkshopVenueId = id;
                        existingWorkshopVenue.Address = cvm.Address;
                        existingWorkshopVenue.VenueName = cvm.VenueName;

                        try
                        {
                            contextmodel.WorkshopVenue.Update(existingWorkshopVenue);
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
            }
            else
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Venue already exists.");
            }

            return Ok();



        }

        [HttpDelete]
        [Route("DeleteWorkshopVenue")]
        public ActionResult DeleteWorkshopVenue(int id, WorkshopVenue cvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingWorkshopVenue = contextmodel.WorkshopVenue.Where(c => c.WorkshopVenueId == id).FirstOrDefault<WorkshopVenue>();

                    if (existingWorkshopVenue != null)

                    {

                        if (existingWorkshopVenue == null) return NotFound();


                        contextmodel.WorkshopVenue.Remove(existingWorkshopVenue);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "WorkshopVenue deleted");


        }
        [HttpPost]
        [Route("DeleteVenuePost")]
        public ActionResult DeleteVenuePost(WorkshopVenue cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingHost = contextmodel.WorkshopVenue.Where(c => c.WorkshopVenueId == cvm.WorkshopVenueId).FirstOrDefault<WorkshopVenue>();

                    if (existingHost != null)

                    {

                        if (existingHost == null) return NotFound();


                        contextmodel.WorkshopVenue.Remove(existingHost);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Venue deleted");

        }
        [HttpDelete]
        [Route("DeleteVenue2")]
        public async Task<IActionResult> DeleteVenue2(string VenueName)
        {
            try
            {
                var existing = await _Repository.GetVenueAsync(VenueName);

                if (existing == null) return NotFound();

                _Repository.Delete(existing);

                if (await _Repository.SaveChangesAsync())
                {
                    return StatusCode(StatusCodes.Status200OK, "Venue deleted");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Venue deleted");
        }
     
    }
}

