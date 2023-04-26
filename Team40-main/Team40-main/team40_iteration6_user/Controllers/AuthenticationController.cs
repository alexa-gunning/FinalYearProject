using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using team40_iteration6_user.Models;
using team40_iteration6_user.Team40;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using team40_iteration6_user.ViewModel;
using Microsoft.AspNetCore.Authentication;
using System.Net.Mail;
using System.Net;
using Audit.WebApi;

namespace team40_iteration6_user.Controllers
{
    [Route("api/[controller]")]
    //[AuditApi(EventTypeName = "{controller}/{action}")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //private UserManager<User> _User;
        //private SignInManager<User> _SignIn;
        private readonly IRepository _Repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserClaimsPrincipalFactory<AppUser> _claimsPrincipalFactory;
        private static Dictionary<string, TwoFactorCode> _twoFactorCodeDictionary
          = new Dictionary<string, TwoFactorCode>();
        //to allow for jwt bearer
        private readonly IConfiguration _configuration;
        public AuthenticationController(UserManager<AppUser> userManager, 
            IUserClaimsPrincipalFactory<AppUser> claimsPrincipalFactory,
            IConfiguration configuration, IRepository repository
            )
        {
            _userManager = userManager;
            _claimsPrincipalFactory = claimsPrincipalFactory;
            _configuration = configuration;
            _Repository = repository;
        }
       

        [HttpPost]
        [Route("RegisterClient")]
        public async Task<IActionResult> RegisterClient(RegisterVM uvm)
        {
            //look at identity user for names of things (eg UserName...) look in db at AspNetUsers 
            //dont use ID so findbyname
            var user = await _userManager.FindByNameAsync(uvm.UserName);

            if (user == null)
            {
                user = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = uvm.UserName,
                    Email = uvm.UserName
                };

                var result = await _userManager.CreateAsync(user, uvm.Password);
                using (var contextmodel = new CoreDbContext())
                {
                    var client = new Client
                    {
                        Name = uvm.Name,
                        Surname = uvm.Surname,
                        PhoneNumber = uvm.PhoneNumber,
                        BirthDate = uvm.BirthDate,
                        EmailAddress = uvm.UserName,
                        GenderId = uvm.GenderId,
                        UserId = 1,
                    };


                    contextmodel.Add(client);
                    contextmodel.SaveChanges();
                }
                if (result.Errors.Count() > 0)
                    StatusCode(StatusCodes.Status500InternalServerError, "Internal error occured. Please contact support");
            }
            else
            { return StatusCode(StatusCodes.Status403Forbidden, "Account already exists"); }


            return Ok();
            // can use SHA256 instead of Identity too
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(UserViewModel uvm)
        {
            //look at identity user for names of things (eg UserName...) look in db at AspNetUsers 
            //dont use ID so findbyname
            var user = await _userManager.FindByNameAsync(uvm.UserName);

            if (user == null)
            {
                user = new AppUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = uvm.UserName,
                    Email = uvm.UserName
                };

                var result = await _userManager.CreateAsync(user, uvm.Password);
             
                if (result.Errors.Count() > 0)
                    StatusCode(StatusCodes.Status500InternalServerError, "Internal error occured. Please contact support");
            }
            else
            { return StatusCode(StatusCodes.Status403Forbidden, "Account already exists"); }


            return Ok();
            // can use SHA256 instead of Identity too
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserViewModel uvm)
        {
            var user = await _userManager.FindByNameAsync(uvm.UserName);

            if (user != null && await _userManager.CheckPasswordAsync(user, uvm.Password))
            {
                try
                {
                   
                    var principal = await _claimsPrincipalFactory.CreateAsync(user);
                
                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);

                    // 2 Step Verification
                    var otp = GenerateTwoFactorCodeFor(user.UserName);

                    var fromEmailAddress = "resinartnewsletter@gmail.com"; // you must add your own provided email
                    var subject = "System Log in";
                    var message = $"Enter the following OTP: {otp}";
                    var toEmailAddress = user.Email;

                    // Sending email
                    await SendEmail(fromEmailAddress, subject, message, toEmailAddress);

                    //return GenerateJWTToken(user);

                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal error occured. Please contact support");
                }
            }
            else
            {
                return NotFound("Does not exist");
            }
       
            //, Password = user.PasswordHash
            var loggedInUser = new UserViewModel { UserName = user.UserName };

            return Ok(loggedInUser);
        }
        [HttpPost]
        [Route("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword uvm)
        {
            var user = await _userManager.FindByNameAsync(uvm.UserName);

            if (user != null )
            {
                try
                {

                    var principal = await _claimsPrincipalFactory.CreateAsync(user);

                    await HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, principal);

                    // 2 Step Verification
                    var otp = GenerateTwoFactorCodeFor(user.UserName);

                    var fromEmailAddress = "resinartnewsletter@gmail.com"; // you must add your own provided email
                    var subject = "System Log in";
                    var message = $"Enter the following OTP: {otp}";
                    var toEmailAddress = user.Email;

                    // Sending email
                    await SendEmail(fromEmailAddress, subject, message, toEmailAddress);

                    //return GenerateJWTToken(user);

                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal error occured. Please contact support");
                }
            }
            else
            {
                return NotFound("Does not exist");
            }

            //, Password = user.PasswordHash
            var loggedInUser = new ForgotPassword { UserName = user.UserName };

            return Ok(loggedInUser);
        }
        [HttpPost]
        [Route("LoginHost")]
        public async Task<IActionResult> LoginHost(WorkshopHost cvm)
        {
            var user = await _Repository.GetHostEmailAsync(cvm.HostEmail);

            if (user != null)
            {
                try
                {


                    // 2 Step Verification
                    var otp = GenerateTwoFactorCodeFor(user.HostEmail);

                    var fromEmailAddress = "resinartnewsletter@gmail.com"; // you must add your own provided email
                    var subject = "System Log in";
                    var message = $"Enter the following OTP: {otp}";
                    var toEmailAddress = user.HostEmail;

                    // Sending email
                    await SendEmail(fromEmailAddress, subject, message, toEmailAddress);

                    //return GenerateJWTToken(user);

                }
                catch (Exception)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Internal error occured. Please contact support");
                }
            }
            else
            {
                return NotFound("Does not exist");
            }

            //, Password = user.PasswordHash
            var loggedInUser = new UserViewModel { UserName = user.HostEmail };

            return Ok(loggedInUser);
        }
        [HttpPost]
        [Route("Otp")]
        public IActionResult VerifyOTP(OTPViewModel user)
        {
            var validOtp = VerifyTwoFactorCodeFor(user.userName, user.otp);

            if (validOtp)
            {
                return Ok();
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Invalid OTP");
        }

        private async Task SendEmail(string fromEmailAddress, string subject, string message, string toEmailAddress)
        {
            var fromAddress = new MailAddress(fromEmailAddress);
            var toAddress = new MailAddress(toEmailAddress);

            using (var compiledMessage = new MailMessage(fromAddress, toAddress))
            {
                compiledMessage.Subject = subject;
                compiledMessage.Body = string.Format("Message: {0}", message);

                using (var smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com"; // for example: smtp.gmail.com
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("resinartnewsletter@gmail.com", "pnyblzriureedwgp"); // your own provided email and password
                    await smtp.SendMailAsync(compiledMessage);
                }
            }
        }

        private static string GetUniqueKey()
        {
            Random rnd = new Random();

            var optCode = rnd.Next(1000, 9999);

            return optCode.ToString();
        }

        private static string GenerateTwoFactorCodeFor(string username)
        {
            var code = GetUniqueKey();

            var twoFactorCode = new TwoFactorCode(code);

            // add or overwrite code
            _twoFactorCodeDictionary[username] = twoFactorCode;

            return code;
        }

        private bool VerifyTwoFactorCodeFor(string subject, string code)
        {
            TwoFactorCode twoFactorCodeFromDictionary = null;
            // find subject in dictionary
            if (_twoFactorCodeDictionary
                .TryGetValue(subject, out twoFactorCodeFromDictionary))
            {
                if (twoFactorCodeFromDictionary.CanBeVerifiedUntil > DateTime.Now
                    && twoFactorCodeFromDictionary.Code == code)
                {
                    twoFactorCodeFromDictionary.IsVerified = true;
                    return true;
                }
            }
            return false;
        }

      
        //[HttpGet]
        //private ActionResult GenerateJWTToken(AppUser appUser)
        //{

        //    var claims = new[]
        //    {


        //        new Claim(JwtRegisteredClaimNames.Sub, appUser.Email),

        //        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

        //        new Claim(JwtRegisteredClaimNames.UniqueName, appUser.UserName)
        //    };
        //    //error
        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));

        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(

        //        _configuration["Tokens:Issuer"],
        //        _configuration["Tokens:Audience"],
        //        claims,
        //        signingCredentials: credentials,

        //        expires: DateTime.UtcNow.AddHours(3)
        //   );

        //    return Created("", new
        //    {
        //        token = new JwtSecurityTokenHandler().WriteToken(token),
        //        expiration = token.ValidTo

        //    });
        //}

    }
}
