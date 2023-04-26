/*using team40_iteration6_user.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace team40_iteration6_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public AdminController(IRepository courseRepository)
        {
            _Repository = courseRepository;
        }

        [HttpGet]
        [Route("GetAdmin")]
        public ActionResult GetAdmins()
        {
            try
            {
                List<Admin> dbAdmin = _CoreDbContext.Admins.ToList();

                List<Admin> AdminList = new List<Admin>();

                foreach (var c in dbAdmin)
                {
                    Admin oAdmin = new Admin();

                    oAdmin.AdministratorID = c.AdministratorID;
                    oAdmin.UserID = c.UserID;
                    oAdmin.AdministratorName = c.AdministratorName;
                    oAdmin.AdministratorSurname = c.AdministratorSurname;
                    oAdmin.AdministratorPhoneNumber = c.AdministratorPhoneNumber;
                    oAdmin.AdministratorEmail = c.AdministratorEmail;

                    AdminList.Add(oAdmin);
                }
                return Ok(AdminList);

                /*var test = _team40_4Context.Client.ToList();
                var results = await _courseRepository.GetAllClientsAsync();
                return await _team40_4Context.Client.ToListAsync();
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
    }
}*/
