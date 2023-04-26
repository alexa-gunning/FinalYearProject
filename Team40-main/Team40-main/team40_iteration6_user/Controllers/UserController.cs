using team40_iteration6_user.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using team40_iteration6_user.Team40;


namespace team40_iteration6_user.Controllers
{
    public class UserController : Controller
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _courseRepository;

        [HttpGet]
        [Route("GetUsers")]
        public ActionResult GetAllClients()
        {
            try
            {
                //List<User> dbUsers = _CoreDbContext.Users.ToList();
                List<User> dbUsers = _CoreDbContext.User.ToList(); 
                List <User> UserList = new List<User>();

                foreach (var u in dbUsers)
                {
                    User oUser = new User();

                    oUser.UserId = u.UserId;
                    oUser.Password = u.Password;
                    oUser.Username = u.Username;

                    UserList.Add(oUser);
                }
                return Ok(UserList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }

        [HttpGet]
        [Route("GetUserByUserName")]
        public ActionResult GetUser(string name)
        {
            try
            {
                List<User> dbUsers = _CoreDbContext.User.ToList();
                List<User> UserList = new List<User>();

                foreach (var u in dbUsers)
                {
                    User oUser = new User();

                    if (name == u.Username)
                    {
                        oUser.UserId = u.UserId;
                        oUser.Password = u.Password;
                        oUser.Username = u.Username;

                        UserList.Add(oUser);
                    }
                    else
                    {

                    }
                }
                return Ok(UserList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
    }
}
