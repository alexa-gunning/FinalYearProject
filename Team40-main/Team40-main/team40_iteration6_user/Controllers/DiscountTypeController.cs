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
    public class DiscountTypeController : Controller
    {
        Team40_4Context _team40_4Context = new Team40_4Context();
        private readonly ICourseRepository _courseRepository;

        [HttpGet]
        [Route("GetDiscountStatusByID")]
        public ActionResult GetDiscountTypeByID(int id)
        {   
            try
            {
                List<DiscountType> dbDiscountType = _team40_4Context.DiscountTypes.ToList();
                List<DiscountType> DiscountTypeList = new List<DiscountType>();

                foreach (var d in dbDiscountType)
                {
                    DiscountStatus oDiscountStatus = new DiscountStatus();

                    if (id == d.DiscountTypeID)
                    {
                        DiscountType oDiscountType = new DiscountType();

                        oDiscountType.DiscountTypeID = d.DiscountTypeID;
                        oDiscountType.Description = d.Description;
                        oDiscountType.Percentage = d.Percentage;

                        DiscountTypeList.Add(oDiscountType);
                    }
                    else
                    {

                    }
                }
                return Ok(DiscountTypeList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }

        [HttpGet]
        [Route("GetDiscountStatus")]
        public ActionResult GetDiscountTypeAsync()
        {
            try
            {
                List<DiscountType> dbDiscountType = _team40_4Context.DiscountTypes.ToList();
                List<DiscountType> DiscountTypeList = new List<DiscountType>();

                foreach (var d in dbDiscountType)
                {
                    DiscountType oDiscountType = new DiscountType();

                    oDiscountType.DiscountTypeID = d.DiscountTypeID;
                    oDiscountType.Description = d.Description;
                    oDiscountType.Percentage = d.Percentage;

                    DiscountTypeList.Add(oDiscountType);
                }
                return Ok(DiscountTypeList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
    }
}*/
