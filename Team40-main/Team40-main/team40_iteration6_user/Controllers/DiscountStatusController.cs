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
    public class DiscountStatusController : Controller
    {
        Team40_4Context _team40_4Context = new Team40_4Context();
        private readonly ICourseRepository _courseRepository;

        [HttpGet]
        [Route("GetDiscountStatusByID")]
        public ActionResult GetDiscountStatusByID(int id)
        {
            try
            {
                List<DiscountStatus> dbDiscountStatus = _team40_4Context.DiscountStatuses.ToList();
                List<DiscountStatus> DiscountStatusList = new List<DiscountStatus>();

                foreach (var d in dbDiscountStatus)
                {
                    DiscountStatus oDiscountStatus = new DiscountStatus();

                    if (id == d.DiscountStatusID)
                    {
                        oDiscountStatus.DiscountStatusID = d.DiscountStatusID;
                        oDiscountStatus.Description = d.Description;

                        DiscountStatusList.Add(oDiscountStatus);
                    }
                    else
                    {

                    }
                }
                return Ok(DiscountStatusList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }

        [HttpGet]
        [Route("GetDiscountStatus")]
        public ActionResult GetDiscountStatusAsync()
        {
            try
            {
                List<DiscountStatus> dbDiscountStatus = _team40_4Context.DiscountStatuses.ToList();
                List<DiscountStatus> DiscountStatusList = new List<DiscountStatus>();

                foreach (var d in dbDiscountStatus)
                {
                    DiscountStatus oDiscountStatus = new DiscountStatus();

                    oDiscountStatus.DiscountStatusID = d.DiscountStatusID;
                    oDiscountStatus.Description = d.Description;

                    DiscountStatusList.Add(oDiscountStatus);
                }
                return Ok(DiscountStatusList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
    }
}*/
