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
    public class DiscountController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public DiscountController(IRepository Repository)
        {
            _Repository = Repository;
        }
        [HttpGet]

        [Route("GetDiscounts")]
        public object GetDiscounts()
        {
            List<Discounts> discounts = (
                from r in _CoreDbContext.DiscountRequest.ToList() 
                join s in _CoreDbContext.DiscountStatus.ToList()
                on r.DiscountStatusId equals s.DiscountStatusId
                join t in _CoreDbContext.DiscountType.ToList()
                on r.DiscountTypeId equals t.DiscountTypeId
                select new Discounts
                {
                    TypeDescription = t.Description,
                    StatusDescription = s.Description,
                    Percentage = t.Percentage,
                    DiscountDescription = r.DiscountDescription,
                       DiscountId = r.DiscountId,
                    DiscountTypeId = r.DiscountTypeId,
                    DiscountStatusId = r.DiscountStatusId,
                }
                ).ToList();
            return discounts;

        }


        [HttpPost]
        [Route("AddDiscount")]
        public async Task<ActionResult> AddDiscount(DiscountRequest cvm)
        {
            //var WorkshopHost = await _Repository.GetHostAsync(cvm.HostName);
            //var surname = await _Repository.GetHostSurnameAsync(cvm.HostSurname);
            //var email = await _Repository.GetHostEmailAsync(cvm.HostEmail);
            //{
            //    HostName = cvm.HostName,
            // HostSurname = cvm.HostSurname,
            //HostEmail = cvm.HostEmail
            //};

            try
            {
                //if (WorkshopHost == null && surname == null && email == null)
                //{
               
                var discount = new DiscountRequest
                {
                    DiscountDescription = cvm.DiscountDescription,
                    
                    DiscountStatusId = cvm.DiscountStatusId ,
                    DiscountTypeId = cvm.DiscountTypeId ,
                    
                    };
                    using (var contextmodel = new CoreDbContext())
                    {

                        contextmodel.Add(discount);
                        contextmodel.SaveChanges();

                    }

                //}
                //else
                //{
                //    return StatusCode(StatusCodes.Status403Forbidden, "Host already exists.");
                //}
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
        [HttpPost]
        [Route("AddType")]
        public async Task<ActionResult> AddType(DiscountType cvm)
        {
            //var WorkshopHost = await _Repository.GetHostAsync(cvm.HostName);
            //var surname = await _Repository.GetHostSurnameAsync(cvm.HostSurname);
            //var email = await _Repository.GetHostEmailAsync(cvm.HostEmail);
            //{
            //    HostName = cvm.HostName,
            // HostSurname = cvm.HostSurname,
            //HostEmail = cvm.HostEmail
            //};

            try
            {
                //if (WorkshopHost == null && surname == null && email == null)
                //{

                var discount = new DiscountType
                {
                    Description = cvm.Description,
                    Percentage = cvm.Percentage,
                    DiscountTypeId = cvm.DiscountTypeId,

                };
                using (var contextmodel = new CoreDbContext())
                {

                    contextmodel.Add(discount);
                    contextmodel.SaveChanges();

                }

                //}
                //else
                //{
                //    return StatusCode(StatusCodes.Status403Forbidden, "Host already exists.");
                //}
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
        [HttpGet]
        [Route("GetStatuses")]
        public ActionResult GetStatuses()
        {
            try
            {
                List<DiscountStatus> dbHosts = _CoreDbContext.DiscountStatus.ToList();

                List<DiscountStatus> HostList = new List<DiscountStatus>();

                foreach (var c in dbHosts)
                {
                    DiscountStatus oHost = new DiscountStatus();

                    oHost.DiscountStatusId = c.DiscountStatusId;
                    oHost.Description = c.Description;

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
        [Route("GetTypes")]
        public ActionResult GetTypes()
        {
            try
            {
                List<DiscountType> dbHosts = _CoreDbContext.DiscountType.ToList();

                List<DiscountType> HostList = new List<DiscountType>();

                foreach (var c in dbHosts)
                {
                    DiscountType oHost = new DiscountType();

                    oHost.DiscountTypeId = c.DiscountTypeId;
                    oHost.Description = c.Description;
                    oHost.Percentage = c.Percentage;
                    HostList.Add(oHost);
                }
                return Ok(HostList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpPut]
        [Route("UpdateDiscount")]
        public ActionResult UpdateDiscount(int id, DiscountRequest cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

       
            using (var contextmodel = new CoreDbContext())
            {

                var existing = contextmodel.DiscountRequest.Where(c => c.DiscountId == id).FirstOrDefault<DiscountRequest>();

                if (existing != null)
                {
                    existing.DiscountId = id;
                    existing.DiscountDescription = cvm.DiscountDescription;
                    existing.DiscountStatusId = cvm.DiscountStatusId;
                    existing.DiscountTypeId = cvm.DiscountTypeId;

                    try
                    {
                        contextmodel.DiscountRequest.Update(existing);
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
        [Route("GetDiscountByID")]
        public ActionResult GetDiscountByID(int id)
        {
            try
            {
                List<DiscountRequest> db = _CoreDbContext.DiscountRequest.ToList();
                List<DiscountRequest> List = new List<DiscountRequest>();

                foreach (var c in db)
                {
                    DiscountRequest o = new DiscountRequest();

                    if (id == c.DiscountId)
                    {
                        o.DiscountDescription = c.DiscountDescription;
                        o.DiscountStatusId = c.DiscountStatusId;
                        o.DiscountTypeId = c.DiscountTypeId;



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
        [HttpGet]
        [Route("ValidateDiscount")]
        public ActionResult ValidateDiscount(string description)
        {
            try
            {
                List<DiscountRequest> db = _CoreDbContext.DiscountRequest.ToList();
                List<DiscountRequest> List = new List<DiscountRequest>();

                foreach (var c in db)
                {
                    DiscountRequest o = new DiscountRequest();

                    if (description == c.DiscountDescription)
                    {
                        o.DiscountDescription = c.DiscountDescription;
                        o.DiscountStatusId = c.DiscountStatusId;
                        o.DiscountTypeId = c.DiscountTypeId;
                        o.DiscountId = c.DiscountId;


                        List.Add(o);
                    }
                    else
                    {
                        return Ok("Not found");
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
        [Route("DeleteDiscount")]
        public ActionResult DeleteDiscount(DiscountRequest cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existing = contextmodel.DiscountRequest.Where(c => c.DiscountId == cvm.DiscountId).FirstOrDefault<DiscountRequest>();

                    if (existing != null)

                    {

                        if (existing == null) return NotFound();


                        contextmodel.DiscountRequest.Remove(existing);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Discount deleted");

        }
        [HttpPost]
        [Route("DeleteDiscountType")]
        public ActionResult DeleteDiscountType(DiscountType cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existing = contextmodel.DiscountType.Where(c => c.DiscountTypeId == cvm.DiscountTypeId).FirstOrDefault<DiscountType>();

                    if (existing != null)

                    {

                        if (existing == null) return NotFound();


                        contextmodel.DiscountType.Remove(existing);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Discount type deleted");

        }
        [HttpPut]
        [Route("UpdateDiscountType")]
        public ActionResult UpdateDiscountType(int id, DiscountType cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            using (var contextmodel = new CoreDbContext())
            {

                var existing = contextmodel.DiscountType.Where(c => c.DiscountTypeId == id).FirstOrDefault<DiscountType>();

                if (existing != null)
                {
                    existing.DiscountTypeId = id;
                    existing.Description = cvm.Description;
                    existing.Percentage = cvm.Percentage;
                 

                    try
                    {
                        contextmodel.DiscountType.Update(existing);
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
    }
}
