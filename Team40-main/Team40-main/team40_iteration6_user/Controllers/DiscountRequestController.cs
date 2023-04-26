/*using API_Team40.Models;
using API_Team40.team40_4;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Team40.Controllers
{
    public class DiscountRequestController : Controller
    {
        Team40_4Context _team40_4Context = new Team40_4Context();
        private readonly ICourseRepository _courseRepository;

        public DiscountRequestController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetDiscountRequestByID")]
        public ActionResult GetDiscountRequestByID(int id)
        {
            try
            {
                List<DiscountRequest> dbDiscount = _team40_4Context.DiscountRequests.ToList();
                List<DiscountRequest> DiscountRequestList = new List<DiscountRequest>();

                foreach (var d in dbDiscount)
                {
                    DiscountRequest oDiscountRequest = new DiscountRequest();

                    if (id == d.DiscountID)
                    {
                        oDiscountRequest.DiscountID = d.DiscountID;
                        oDiscountRequest.DiscountPeriod = d.DiscountPeriod;
                        oDiscountRequest.DiscountDescription = d.DiscountDescription;
                        oDiscountRequest.DiscountTypeID = d.DiscountTypeID;
                        oDiscountRequest.DiscountStatusID = d.DiscountStatusID;

                        DiscountRequestList.Add(oDiscountRequest);
                    }
                    else
                    {

                    }
                }
                return Ok(DiscountRequestList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }

        [HttpGet]
        [Route("GetDiscounts")]
        public ActionResult GetDiscountRequestAsync()
        {
            try
            {
                List<DiscountRequest> dbDiscountRequests = _team40_4Context.DiscountRequests.ToList();

                List<DiscountRequest> DiscountList = new List<DiscountRequest>();

                foreach (var c in dbDiscountRequests)
                {
                    DiscountRequest oDiscountRequest = new DiscountRequest();

                    oDiscountRequest.DiscountID = c.DiscountID;
                    oDiscountRequest.DiscountPeriod = c.DiscountPeriod;
                    oDiscountRequest.DiscountDescription = c.DiscountDescription;
                    oDiscountRequest.DiscountTypeID = c.DiscountTypeID;
                    oDiscountRequest.DiscountStatusID = c.DiscountStatusID;
      
                    DiscountList.Add(oDiscountRequest);
                }
                return Ok(DiscountList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }

        [HttpPost]
        [Route("AddNewsletterSubscriber")]
        public async Task<IActionResult> AddDiscountRequest(DiscountRequest cvm)
        {
            var discountrequest = new DiscountRequest
            {
                DiscountID = cvm.DiscountID,
                DiscountPeriod = cvm.DiscountPeriod,
                DiscountDescription = cvm.DiscountDescription,
                DiscountTypeID = cvm.DiscountTypeID,
                DiscountStatusID = cvm.DiscountStatusID
            };

            var discountstatus = new DiscountStatus
            {
                DiscountStatusID = (int)cvm.DiscountStatusID,
                Description = cvm.DiscountDescription
            };

            var discounttype = new DiscountType
            {
                DiscountTypeID = (int)cvm.DiscountTypeID,
                Description = cvm.DiscountDescription,
                //Percentage = cvm.Percentage
            };
            try
            {
                _courseRepository.Add(discountrequest);
                _courseRepository.Add(discountstatus);
                _courseRepository.Add(discounttype);
                await _courseRepository.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest("Invalid transaction");
            }

            return Ok("Record saved in database");
        }

        [HttpDelete]
        [Route("DeleteNewsletterSubscriber")]
        public async Task<IActionResult> DeleteDiscountRequest(int id)
        {
            try
            {
                var exisitingDiscount = await _courseRepository.GetDiscountRequest(id);

                if (exisitingDiscount == null) return NotFound();

                _courseRepository.Delete(exisitingDiscount);

                if (await _courseRepository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error! Contact Support");
            }

            return BadRequest();
        }
    }
}*/
