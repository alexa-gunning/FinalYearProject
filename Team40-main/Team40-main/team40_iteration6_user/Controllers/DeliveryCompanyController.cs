using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using team40_iteration6_user.Models;
using team40_iteration6_user.Team40;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace team40_iteration6_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryCompanyController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;


        public DeliveryCompanyController(IRepository Repository)
        {
            _Repository = Repository;

        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult GetAll()
        {
            try
            {
                List<DeliveryCompany> dbDeliveryCompany = _CoreDbContext.DeliveryCompany.ToList();

                List<DeliveryCompany> DeliveryCompanyList = new List<DeliveryCompany>();

                foreach (var c in dbDeliveryCompany)
                {
                    DeliveryCompany oDeliveryCompany = new DeliveryCompany();

                    oDeliveryCompany.DeliveryCompanyName = c.DeliveryCompanyName;
                    oDeliveryCompany.DeliveryCompanyEmail = c.DeliveryCompanyEmail;
                    oDeliveryCompany.DeliveryCompanyId = c.DeliveryCompanyId;
                    oDeliveryCompany.ContactPersonName = c.ContactPersonName;
                    oDeliveryCompany.DeliveryCompanyBaseRate = c.DeliveryCompanyBaseRate;
                    //oDeliveryCompany.Method = c.Method;



                    DeliveryCompanyList.Add(oDeliveryCompany);
                }
                return Ok(DeliveryCompanyList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetDeliveryCompanyByID")]
        public ActionResult GetDeliveryCompany(int id)
        {
            try
            {
                List<DeliveryCompany> dbDeliveryCompany = _CoreDbContext.DeliveryCompany.ToList();
                List<DeliveryCompany> DeliveryCompanyList = new List<DeliveryCompany>();

                foreach (var c in dbDeliveryCompany)
                {
                    DeliveryCompany oDeliveryCompany = new DeliveryCompany();

                    if (id == c.DeliveryCompanyId)
                    {
                        oDeliveryCompany.DeliveryCompanyName = c.DeliveryCompanyName;
                        oDeliveryCompany.DeliveryCompanyEmail = c.DeliveryCompanyEmail;
                        oDeliveryCompany.DeliveryCompanyId = c.DeliveryCompanyId;
                        oDeliveryCompany.ContactPersonName = c.ContactPersonName;
                        oDeliveryCompany.DeliveryCompanyBaseRate = c.DeliveryCompanyBaseRate;
                        //oDeliveryCompany.Method = c.Method;



                        DeliveryCompanyList.Add(oDeliveryCompany);
                    }
                    else
                    {

                    }
                }
                return Ok(DeliveryCompanyList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }

        //Add Delivery Company
        [HttpPost]
        [Route("AddDeliveryCompany")]
        public ActionResult AddDeliveryCompany(DeliveryCompany cvm)
        {

            var DeliveryCompany = new DeliveryCompany
            {
                DeliveryCompanyName = cvm.DeliveryCompanyName,
                DeliveryCompanyEmail = cvm.DeliveryCompanyEmail,
                DeliveryCompanyBaseRate = cvm.DeliveryCompanyBaseRate,
                ContactPersonName = cvm.ContactPersonName,
                //Method = cvm.Method

            };

            try
            {
                using (var contextmodel = new CoreDbContext())
                {

                    contextmodel.Add(DeliveryCompany);
                    contextmodel.SaveChanges();

                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }


            return Ok();

        }

        //Update Delivery Company

        [HttpPut]
        [Route("UpdateDeliveryCompany")]
        public ActionResult UpdateDeliveryCompany(int id, DeliveryCompany cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (var contextmodel = new CoreDbContext())
            {

                var existingDeliveryCompany = contextmodel.DeliveryCompany.Where(c => c.DeliveryCompanyId == id).FirstOrDefault<DeliveryCompany>();

                if (existingDeliveryCompany != null)
                {
                    existingDeliveryCompany.DeliveryCompanyId = id;
                    existingDeliveryCompany.DeliveryCompanyName = cvm.DeliveryCompanyName;
                    existingDeliveryCompany.DeliveryCompanyEmail = cvm.DeliveryCompanyEmail;
                    existingDeliveryCompany.DeliveryCompanyBaseRate = cvm.DeliveryCompanyBaseRate;
                    existingDeliveryCompany.ContactPersonName = cvm.ContactPersonName;
                    //existingDeliveryCompany.Method = cvm.Method;

                    try
                    {
                        contextmodel.DeliveryCompany.Update(existingDeliveryCompany);
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

        //Delete Delivery Company
        [HttpDelete]
        [Route("DeleteDeliveryCompany")]
        public ActionResult DeleteDeliveryCompany(string deliveryCompanyName)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingDeliveryCompany = contextmodel.DeliveryCompany.Where(c => c.DeliveryCompanyName == deliveryCompanyName).FirstOrDefault<DeliveryCompany>();

                    if (existingDeliveryCompany != null)

                    {

                        if (existingDeliveryCompany == null) return NotFound();


                        contextmodel.DeliveryCompany.Remove(existingDeliveryCompany);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "DeliveryCompany deleted");

        }

        [HttpDelete]
        [Route("DeleteDelivery2")]
        public async Task<IActionResult> DeleteDelivery2(string deliveryCompanyName)
        {
            try
            {
                var existing = await _Repository.GetDeliveryCompanyAsync(deliveryCompanyName);
                if (existing == null) return NotFound();

                _Repository.Delete(existing);

                if (await _Repository.SaveChangesAsync())
                {
                    return StatusCode(StatusCodes.Status200OK, "Delivery Company Details have been deleted");
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
            return Ok();
        }

        [HttpPost]
        [Route("DeleteDeliveryCompanyPost")]
        public ActionResult DeleteDeliveryCompanyPost(DeliveryCompany cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingDel = contextmodel.DeliveryCompany.Where(c => c.DeliveryCompanyId == cvm.DeliveryCompanyId).FirstOrDefault<DeliveryCompany>();

                    if (existingDel != null)

                    {

                        if (existingDel == null) return NotFound();


                        contextmodel.DeliveryCompany.Remove(existingDel);
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