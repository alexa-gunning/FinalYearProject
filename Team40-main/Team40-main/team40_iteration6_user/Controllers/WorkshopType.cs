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
    public class WorkshopTypeController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public WorkshopTypeController(IRepository Repository)
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
        [Route("GetWorkshoptypeByID")]
        public ActionResult GetWorkshoptype(int id)
        {
            try
            {
                List<WorkshopType> dbWorkshoptypes = _CoreDbContext.WorkshopType.ToList();
                List<WorkshopType> WorkshoptypeList = new List<WorkshopType>();

                foreach (var c in dbWorkshoptypes)
                {
                    WorkshopType oWorkshoptype = new WorkshopType();

                    if (id == c.WorkshopTypeId)
                    {
                        oWorkshoptype.Description = c.Description;
                        oWorkshoptype.WorkshopTypeId = c.WorkshopTypeId;


                        WorkshoptypeList.Add(oWorkshoptype);
                    }
                    else
                    {

                    }
                }
                return Ok(WorkshoptypeList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }



        [HttpPost]
        [Route("AddWorkshoptype")]
        public async Task<ActionResult> AddWorkshoptypeAsync(WorkshopType cvm)

        {
            var WorkshopVenue = await _Repository.GetTypeAsync(cvm.Description);
    

            try
            {
                if (WorkshopVenue == null)
                {
                    WorkshopVenue = new WorkshopType
                    {
                        Description = cvm.Description,
               
                    };
                    using (var contextmodel = new CoreDbContext())
                    {

                        contextmodel.Add(WorkshopVenue);
                        contextmodel.SaveChanges();

                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Type already exists.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }

            return Ok();
        }
        [HttpPut]
        [Route("UpdateWorkshoptype")]
        public async Task<ActionResult> UpdateWorkshoptype(int id, WorkshopType cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var WorkshopVenue = await _Repository.GetTypeAsync(cvm.Description);
            if (WorkshopVenue == null )
            {
                using (var contextmodel = new CoreDbContext())
            {

                var existingWorkshoptype = contextmodel.WorkshopType.Where(c => c.WorkshopTypeId == id).FirstOrDefault<WorkshopType>();

                if (existingWorkshoptype != null)
                {
                    existingWorkshoptype.WorkshopTypeId = id;
                    existingWorkshoptype.Description = cvm.Description;

                    try
                    {
                        contextmodel.WorkshopType.Update(existingWorkshoptype);
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
                return StatusCode(StatusCodes.Status403Forbidden, " Type already exists.");
            }

            return Ok();



        }
        [HttpPost]
        [Route("DeleteTypePost")]
        public ActionResult DeleteTypePost(WorkshopType cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingHost = contextmodel.WorkshopType.Where(c => c.WorkshopTypeId == cvm.WorkshopTypeId).FirstOrDefault<WorkshopType>();

                    if (existingHost != null)

                    {

                        if (existingHost == null) return NotFound();


                        contextmodel.WorkshopType.Remove(existingHost);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Type deleted");

        }

        [HttpDelete]
        [Route("DeleteWorkshoptype")]
        public ActionResult DeleteWorkshoptype(int id, WorkshopType cvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingWorkshoptype = contextmodel.WorkshopType.Where(c => c.WorkshopTypeId == id).FirstOrDefault<WorkshopType>();

                    if (existingWorkshoptype != null)

                    {

                        if (existingWorkshoptype == null) return NotFound();


                        contextmodel.WorkshopType.Remove(existingWorkshoptype);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Workshoptype deleted");

        }
    }
}

