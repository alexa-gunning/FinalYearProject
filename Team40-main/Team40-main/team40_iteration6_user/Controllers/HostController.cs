using Audit.WebApi;
using Microsoft.AspNetCore.Authorization;
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
    
    public class HostController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public HostController(IRepository Repository)
        {
            _Repository = Repository;
        }

        [HttpGet]
        [Route("Test")]
        [Authorize]
        public object GetYipee()
        {
            return Ok("Yipeeee");
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



        [HttpPost]
        [Route("AddHost")]
        public async Task<ActionResult> AddHostAsync(WorkshopHost cvm)
        {
            var WorkshopHost = await _Repository.GetHostAsync(cvm.HostName);
            var surname = await _Repository.GetHostSurnameAsync(cvm.HostSurname);
            var email = await _Repository.GetHostEmailAsync(cvm.HostEmail);
            //{
            //    HostName = cvm.HostName,
            // HostSurname = cvm.HostSurname,
            //HostEmail = cvm.HostEmail
            //};

            try
            {
                if (WorkshopHost == null && surname == null && email == null)
                {
                    WorkshopHost = new WorkshopHost
                    {
                        HostName = cvm.HostName,
                        HostSurname = cvm.HostSurname,
                        HostEmail = cvm.HostEmail
                    };
                    using (var contextmodel = new CoreDbContext())
                    {

                        contextmodel.Add(WorkshopHost);
                        contextmodel.SaveChanges();

                    }

                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Host already exists.");
                }
            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }

            //return StatusCode(StatusCodes.Status200OK, "New host saved");
            //return Ok("New host saved");
            return Ok();
            //return null;


        }


        [HttpPut]
        [Route("UpdateHost")]
        public async Task<ActionResult> UpdateHostAsync(int id, WorkshopHost cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var host = await _Repository.GetHostAsync(cvm.HostName);
            var surname = await _Repository.GetHostSurnameAsync(cvm.HostSurname);
            var email = await _Repository.GetHostEmailAsync(cvm.HostEmail);
            if (host == null && surname == null && email == null)
            {
                using (var contextmodel = new CoreDbContext())
                {

                    var existingHost = contextmodel.WorkshopHost.Where(c => c.HostId == id).FirstOrDefault<WorkshopHost>();

                    if (existingHost != null)
                    {
                        existingHost.HostId = id;
                        existingHost.HostName = cvm.HostName;
                        existingHost.HostSurname = cvm.HostSurname;
                        existingHost.HostEmail = cvm.HostEmail;

                        try
                        {
                            contextmodel.WorkshopHost.Update(existingHost);
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
                return StatusCode(StatusCodes.Status403Forbidden, "Host already exists.");
            }
            return Ok();
        }




        [HttpGet]
        [Route("GetHostByID")]
        public ActionResult GetHostByID(int id)
        {
            try
            {
                List<WorkshopHost> dbWorkshopHost = _CoreDbContext.WorkshopHost.ToList();
                List<WorkshopHost> WorkshopHostList = new List<WorkshopHost>();

                foreach (var c in dbWorkshopHost)
                {
                    WorkshopHost oWorkshopHost = new WorkshopHost();

                    if (id == c.HostId)
                    {
                        oWorkshopHost.HostName = c.HostName;
                        oWorkshopHost.HostSurname = c.HostSurname;
                        oWorkshopHost.HostEmail = c.HostEmail;


                        WorkshopHostList.Add(oWorkshopHost);
                    }
                    else
                    {

                    }
                }
                return Ok(WorkshopHostList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }


        [HttpDelete]
        [Route("DeleteHost")]
        public ActionResult DeleteHost(int id, WorkshopHost cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingHost = contextmodel.WorkshopHost.Where(c => c.HostId == id).FirstOrDefault<WorkshopHost>();

                    if (existingHost != null)

                    {

                        if (existingHost == null) return NotFound();


                        contextmodel.WorkshopHost.Remove(existingHost);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "WorkshopHost deleted");

        }
        [HttpPost]
        [Route("DeleteHostPost")]
        public ActionResult DeleteHostPost( WorkshopHost cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingHost = contextmodel.WorkshopHost.Where(c => c.HostId == cvm.HostId).FirstOrDefault<WorkshopHost>();

                    if (existingHost != null)

                    {

                        if (existingHost == null) return NotFound();


                        contextmodel.WorkshopHost.Remove(existingHost);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "WorkshopHost deleted");

        }

        [HttpDelete]
        [Route("DeleteHost2")]
        public async Task<IActionResult> DeleteHost2(string HostName)
        {
            try
            {
                var existing = await _Repository.GetHostAsync(HostName);

                if (existing == null) return NotFound();

                _Repository.Delete(existing);

                if (await _Repository.SaveChangesAsync())
                {
                    return StatusCode(StatusCodes.Status200OK, "WorkshopHost deleted");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "WorkshopHost deleted");
        }


    }
}
