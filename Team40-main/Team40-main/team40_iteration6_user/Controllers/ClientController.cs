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
    public class ClientController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public ClientController(IRepository Repository)
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
        [Route("GetAllClients")]
        public ActionResult GetAllClients()
        {
            try
            {
                List<Client> dbClients = _CoreDbContext.Client.ToList();

                List<Client> ClientList = new List<Client>();

                foreach (var c in dbClients)
                {
                    Client oClient = new Client();

                    oClient.ClientId = c.ClientId;
                    oClient.Name = c.Name;
                    oClient.Surname = c.Surname;
                    oClient.PhoneNumber = c.PhoneNumber;
                    oClient.BirthDate = c.BirthDate;
                    oClient.EmailAddress = c.EmailAddress;
                    oClient.GenderId = c.GenderId;
                    oClient.UserId = 1;

                    ClientList.Add(oClient);
                }
                return Ok(ClientList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetClientByID")]
        public ActionResult GetClient(int id)
        {
            try
            {
                List<Client> dbClients = _CoreDbContext.Client.ToList();
                List<Client> ClientList = new List<Client>();

                foreach (var c in dbClients)
                {
                    Client oClient1 = new Client();

                    if (id == c.ClientId)
                    {
                        oClient1.ClientId = c.ClientId;
                        oClient1.Name = c.Name;
                        oClient1.Surname = c.Surname;
                        oClient1.PhoneNumber = c.PhoneNumber;
                        oClient1.BirthDate = c.BirthDate;
                        oClient1.EmailAddress = c.EmailAddress;
                        oClient1.GenderId = c.GenderId;
                        oClient1.UserId = 1;

                        ClientList.Add(oClient1);
                    }
                    else
                    {

                    }
                }

                if (ClientList.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(ClientList);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetClientID")]
        public ActionResult GetClientID(string EmailAddress)
        {
            try
            {
                List<Client> db = _CoreDbContext.Client.ToList();
                List<Client> List = new List<Client>();

                foreach (var c in db)
                {
                    Client o = new Client();

                    if (EmailAddress == c.EmailAddress)
                    {

                        o.ClientId = c.ClientId;
                        o.Name = c.Name;
                        o.Surname = c.Surname;
                        o.PhoneNumber = c.PhoneNumber;
                        o.BirthDate = c.BirthDate;
                        o.EmailAddress = c.EmailAddress;
                        o.GenderId = c.GenderId;
                        o.UserId = 1;


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
        [HttpPost]
        [Route("AddClient")]
        public ActionResult AddClient(Client cvm)
        {
            using (var contextmodel = new CoreDbContext())
            {

                var client = new Client
                {
                    Name = cvm.Name,
                    Surname = cvm.Surname,
                    PhoneNumber = cvm.PhoneNumber,
                    BirthDate = cvm.BirthDate,
                    EmailAddress = cvm.EmailAddress,
                    GenderId = cvm.GenderId,
                    UserId = 1,
                };

                try
                {
                    contextmodel.Add(client);
                    contextmodel.SaveChanges();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
                }

                return Ok();
            }
        }
        [HttpPost]
        [Route("DeleteAddress")]
        public ActionResult DeleteAddress(Address cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingHost = contextmodel.Address.Where(c => c.AddressId == cvm.AddressId).FirstOrDefault<Address>();

                    if (existingHost != null)

                    {

                        if (existingHost == null) return NotFound();


                        contextmodel.Address.Remove(existingHost);
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
        [HttpPost]
        [Route("AddAddress")]
        public ActionResult AddAddress(int ClientId, Address cvm)
        {
            using (var contextmodel = new CoreDbContext())
            {

                var client = new Address
                {
                    ClientId = ClientId,
                    StreetName = cvm.StreetName,
                    StreetNumber = cvm.StreetNumber,
                    City = cvm.City,
                    Province = cvm.Province,
                    AreaCode = cvm.AreaCode,
                    Country = "South Africa",
                };

                try
                {
                    contextmodel.Add(client);
                    contextmodel.SaveChanges();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
                }

                return Ok();
            }
        }
        [HttpPut]
        [Route("UpdateClient")]
        public ActionResult UpdateClient(int id, Client cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (var contextmodel = new CoreDbContext())
            {

                var existingClient = contextmodel.Client.Where(c => c.ClientId == id).FirstOrDefault<Client>();

                if (existingClient != null)
                {
                    existingClient.ClientId = id;
                    existingClient.Name = cvm.Name;
                    existingClient.Surname = cvm.Surname;
                    existingClient.PhoneNumber = cvm.PhoneNumber;
                    existingClient.BirthDate = cvm.BirthDate;
                    existingClient.EmailAddress = cvm.EmailAddress;
                    existingClient.GenderId = cvm.GenderId;
                    existingClient.UserId = 1;

                    try
                    {
                        contextmodel.Client.Update(existingClient);
                        contextmodel.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
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
        [Route("GetAddressyByID")]
        public ActionResult GetAddressByID(int id)
        {
            try
            {
                List<Address> dbInventory = _CoreDbContext.Address.ToList();
                List<Address> InventoryList = new List<Address>();

                foreach (var a in dbInventory)
                {
                    Address o = new Address();

                    if (id == a.AddressId)
                    {
                        o.StreetNumber = a.StreetNumber;
                        o.StreetName = a.StreetName;
                        o.City = a.City;
                        o.Province = a.Province;
                        o.AreaCode = a.AreaCode;
                        o.Country = a.Country;

                        InventoryList.Add(o);
                    }
                    else
                    {

                    }
                }
                return Ok(InventoryList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
        [HttpGet]
        [Route("GetGenders")]
        public ActionResult GetGenders()
        {
            try
            {
                List<Gender> dbHosts = _CoreDbContext.Gender.ToList();

                List<Gender> HostList = new List<Gender>();

                foreach (var c in dbHosts)
                {
                    Gender oHost = new Gender();

                    oHost.GenderId = c.GenderId;
                    oHost.GenderName = c.GenderName;

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
        [Route("DeleteClient")]
        public ActionResult DeleteClient(Client cvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingClient = contextmodel.Client.Where(c => c.ClientId == cvm.ClientId).FirstOrDefault<Client>();

                    if (existingClient != null)

                    {

                        if (existingClient == null) return NotFound();


                        contextmodel.Client.Remove(existingClient);
                        contextmodel.SaveChanges();


                    }
                    else
                    {
                        return NotFound();
                    }

                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return Ok();

        }


        [HttpGet]
        [Route("GetAllClientsWithAdress")]
        public object GetAllClientsWithAddress()
        {
            try
            {

                List<ClientandAddress> details = (
               from c in _CoreDbContext.Client.ToList()
               join a in _CoreDbContext.Address.ToList()
               on c.ClientId equals a.ClientId
               select new ClientandAddress
               {

                   Name = c.Name,
                   Surname = c.Surname,
                   PhoneNumber = c.PhoneNumber,
                   BirthDate = c.BirthDate,
                   EmailAddress = c.EmailAddress,
                   StreetNumber = a.StreetNumber,
                   StreetName = a.StreetName,
                   City = a.City,
                   Province = a.Province,
                   AreaCode = a.AreaCode,
                   Country = a.Country,


               }
               ).ToList();
                return details;

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }
        [HttpGet]
        [Route("GetAddressByClientID")]
        public ActionResult GetAddressByClientID(int id)
        {
            try
            {
                List<Address> db = _CoreDbContext.Address.ToList();
                List<Address> List = new List<Address>();

                foreach (var a in db)
                {
                    Address o = new Address();

                    if (id == a.ClientId)
                    {

                        o.ClientId = id;
                        o.AddressId = a.AddressId;
                        o.StreetNumber = a.StreetNumber;
                        o.StreetName = a.StreetName;
                        o.City = a.City;
                        o.Province = a.Province;
                        o.AreaCode = a.AreaCode;
                        o.Country = a.Country;


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
        [HttpPut]
        [Route("UpdateAddress")]
        public async Task<ActionResult> UpdateAddress(int id, Address cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            {
                using (var contextmodel = new CoreDbContext())
                {

                    var existingHost = contextmodel.Address.Where(c => c.AddressId == id).FirstOrDefault<Address>();

                    if (existingHost != null)
                    {
                        existingHost.AddressId = id;
                        existingHost.ClientId = existingHost.ClientId;
                        existingHost.Country = existingHost.Country;
                        existingHost.StreetName = cvm.StreetName;
                        existingHost.StreetNumber = cvm.StreetNumber;
                        existingHost.Province = cvm.Province;
                        existingHost.City = cvm.City;
                        existingHost.AreaCode = cvm.AreaCode;
                        try
                        {
                            contextmodel.Address.Update(existingHost);
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


                    return Ok();
                }

            }
        }
           

            }
      
}