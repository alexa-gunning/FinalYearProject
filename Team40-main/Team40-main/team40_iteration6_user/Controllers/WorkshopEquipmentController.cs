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
    public class WorkshopEquipmentController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public WorkshopEquipmentController(IRepository Repository)
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
        [Route("GetAllWorkshopEquipments")]
        public ActionResult GetAllWorkshopEquipments()
        {
            try
            {
                List<WorkshopEquipment> dbWorkshopEquipment = _CoreDbContext.WorkshopEquipment.ToList();

                List<WorkshopEquipment> WorshopEquipmentList = new List<WorkshopEquipment>();

                foreach (var c in dbWorkshopEquipment)
                {
                    WorkshopEquipment oEquipment = new WorkshopEquipment();

                    oEquipment.WorkshopEquipmentId = c.WorkshopEquipmentId;
                    oEquipment.Description = c.Description;

                    WorshopEquipmentList.Add(oEquipment);
                }
                return Ok(WorshopEquipmentList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetEquipmentByID")]
        public ActionResult GetEquipmentByID(int id)
        {
            try
            {
                List<WorkshopEquipment> dbWorkshopEquipment = _CoreDbContext.WorkshopEquipment.ToList();
                List<WorkshopEquipment> WorkshopEquipmentList = new List<WorkshopEquipment>();

                foreach (var c in dbWorkshopEquipment)
                {
                    WorkshopEquipment oWorkshopEquipment = new WorkshopEquipment();

                    if (id == c.WorkshopEquipmentId)
                    {
                        //oWorkshopEquipment.HostName = c.HostName;
                        oWorkshopEquipment.Description = c.Description;
                        //oWorkshopEquipment.HostEmail = c.HostEmail;


                        WorkshopEquipmentList.Add(oWorkshopEquipment);
                    }
                    else
                    {

                    }
                }
                return Ok(WorkshopEquipmentList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }


        [HttpPost]
        [Route("AddEquipment")]
        public async Task<ActionResult> AddEquipmentAsync(WorkshopEquipment cvm)
        {
            /*var WorkshopEquipment = new WorkshopEquipment
            {
                WorkshopEquipmentId = cvm.WorkshopEquipmentId,
                Description = cvm.Description
            };

            try
            {
                using (var contextmodel = new CoreDbContext())
                {
                    contextmodel.Add(WorkshopEquipment);
                    contextmodel.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "New WorkshopHost saved");*/
            var WorkshopEquipmentName = await _Repository.GetWorkshopEquipmentAsync(cvm.Description);

            try
            {
                if (WorkshopEquipmentName == null)
                {
                    WorkshopEquipmentName = new WorkshopEquipment
                    {
                        Description = cvm.Description
                    };
                    using (var contextmodel = new CoreDbContext())
                    {
                        contextmodel.Add(WorkshopEquipmentName);
                        contextmodel.SaveChanges();
                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Workshop Equipment already exists.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }
            return Ok();
        }


        [HttpPut]
        [Route("UpdateEquipment")]
        public async Task<ActionResult> UpdateEquipmentAsync(int id, WorkshopEquipment cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var WorkshopEquipmentName = await _Repository.GetWorkshopEquipmentAsync(cvm.Description);

            if (WorkshopEquipmentName == null)
            {
                using (var contextmodel = new CoreDbContext())
                {

                    var existingEquipment = contextmodel.WorkshopEquipment.Where(c => c.WorkshopEquipmentId == id).FirstOrDefault<WorkshopEquipment>();

                    if (existingEquipment != null)
                    {
                        existingEquipment.WorkshopEquipmentId = id;
                        existingEquipment.Description = cvm.Description;

                        try
                        {
                            contextmodel.WorkshopEquipment.Update(existingEquipment);
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
                return StatusCode(StatusCodes.Status403Forbidden, "Workshop Equipment already exists.");
            }
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteEquipment")]
        public ActionResult DeleteEquipment(int id, WorkshopEquipment cvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingEquipment = contextmodel.WorkshopEquipment.Where(c => c.WorkshopEquipmentId == id).FirstOrDefault<WorkshopEquipment>();

                    if (existingEquipment != null)

                    {

                        if (existingEquipment == null) return NotFound();


                        contextmodel.WorkshopEquipment.Remove(existingEquipment);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "WorkshopEquipment deleted");

        }

        [HttpDelete]
        [Route("DeleteEquipment2")]
        public ActionResult DeleteEquipment2(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                using (var contextmodel = new CoreDbContext())
                {

                    var existing = contextmodel.WorkshopEquipment.Where(c => c.WorkshopEquipmentId == id).FirstOrDefault<WorkshopEquipment>();

                    if (existing != null)

                    {
                        if (existing == null) return NotFound();
                        contextmodel.WorkshopEquipment.Remove(existing);
                        contextmodel.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, "Workshop Equipment deleted");
        }

        [HttpPost]
        [Route("DeleteEquipmentPost")]
        public ActionResult DeleteEquipmentPost(WorkshopEquipment cvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                using (var contextmodel = new CoreDbContext())
                {
                    var existingEquipment = contextmodel.WorkshopEquipment.Where(c => c.WorkshopEquipmentId == cvm.WorkshopEquipmentId).FirstOrDefault<WorkshopEquipment>();

                    if (existingEquipment != null)
                    {
                        if (existingEquipment == null) return NotFound();
                        contextmodel.WorkshopEquipment.Remove(existingEquipment);
                        contextmodel.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
            return StatusCode(StatusCodes.Status200OK, "Workshop Equipment deleted");
        }

    }
}