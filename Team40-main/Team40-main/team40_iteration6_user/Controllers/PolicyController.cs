using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using team40_iteration6_user.Models;
using team40_iteration6_user.Team40;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Audit.WebApi;

namespace team40_iteration6_user.Controllers
{
    [Route("api/[controller]")]
    //[AuditApi(EventTypeName = "{controller}/{action}")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public PolicyController(IRepository Repository)
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
        [Route("GetAllPolicies")]
        public ActionResult GetAllPolicies()
        {
            try
            {
                List<Policy> dbHosts = _CoreDbContext.Policy.ToList();

                List<Policy> HostList = new List<Policy>();

                foreach (var c in dbHosts)
                {
                    Policy oHost = new Policy();

                    oHost.PolicyId = c.PolicyId;
                    oHost.PolicyName = c.PolicyName;
                    oHost.Description = c.Description;
                    oHost.Date = c.Date;

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
        [Route("AddPolicy")]
        public async Task<ActionResult> AddPolicyAsync(Policy cvm)
        {
            var WorkshopHost = await _Repository.GetPolicyNameAsync(cvm.PolicyName);
            
           

            try
            {
                if (WorkshopHost == null )
                {
                    WorkshopHost = new Policy
                    {
                
                    PolicyName = cvm.PolicyName,
                    Description = cvm.Description,
                    Date = cvm.Date
                };
                    using (var contextmodel = new CoreDbContext())
                    {

                        contextmodel.Add(WorkshopHost);
                        contextmodel.SaveChanges();

                    }

                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Policy already exists.");
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
        [Route("UpdatePolicy")]
        public async Task<ActionResult> UpdatezPolicyAsync(int id, Policy cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var host = await _Repository.GetPolicyNameAsync(cvm.PolicyName);
       
            if (host == null)
            {
                using (var contextmodel = new CoreDbContext())
                {

                    var existingHost = contextmodel.Policy.Where(c => c.PolicyId== id).FirstOrDefault<Policy>();

                    if (existingHost != null)
                    {
                        existingHost.PolicyId = id;
                        existingHost.PolicyName = cvm.PolicyName;
                        existingHost.Description = cvm.Description;
                        existingHost.Date = cvm.Date;

                        try
                        {
                            contextmodel.Policy.Update(existingHost);
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
                return StatusCode(StatusCodes.Status403Forbidden, "Policy already exists.");
            }
            return Ok();
        }




        [HttpGet]
        [Route("GetPolicyByID")]
        public ActionResult GetPolicyByID(int id)
        {
            try
            {
                List<Policy> dbWorkshopHost = _CoreDbContext.Policy.ToList();
                List<Policy> WorkshopHostList = new List<Policy>();

                foreach (var c in dbWorkshopHost)
                {
                    Policy oWorkshopHost = new Policy();

                    if (id == c.PolicyId)
                    {
                        oWorkshopHost.PolicyName = c.PolicyName;
                        oWorkshopHost.Description = c.Description;
                        oWorkshopHost.Date = c.Date;


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


       
        [HttpPost]
        [Route("DeletePolicyPost")]
        public ActionResult DeletePolicyPost(Policy cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingHost = contextmodel.Policy.Where(c => c.PolicyId == cvm.PolicyId).FirstOrDefault<Policy>();

                    if (existingHost != null)

                    {

                        if (existingHost == null) return NotFound();


                        contextmodel.Policy.Remove(existingHost);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Policy deleted");

        }

      


    }
}

