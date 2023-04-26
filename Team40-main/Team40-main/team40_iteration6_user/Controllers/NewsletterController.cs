using Audit.WebApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail; // For sending mail
using team40_iteration6_user.Models;
using team40_iteration6_user.Team40;
using Microsoft.AspNetCore.Authentication;
using System.Net;


namespace team40_iteration6_user.Controllers


{
    [Route("api/[controller]")]
    //[AuditApi(EventTypeName = "{controller}/{action}")]
    [ApiController]

    public class NewsletterController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _courseRepository;
        public NewsletterController(IRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }


        [HttpGet]
        [Route("GetAllSubscribers")]
        public ActionResult GetAllSubscribers()
        {
            try
            {
                List<NewsletterSubscriber> dbSubscriber = _CoreDbContext.NewsletterSubscriber.ToList();

                List<NewsletterSubscriber> SubscriberList = new List<NewsletterSubscriber>();

                foreach (var c in dbSubscriber)
                {
                    NewsletterSubscriber oSubscriber = new NewsletterSubscriber();

                    Client oClient = new Client();

                    oSubscriber.NewsletterId = c.NewsletterId;
                    oSubscriber.ClientId = c.ClientId;
                    oSubscriber.Date = c.Date;
                    oSubscriber.SubscriberStatusId = c.SubscriberStatusId;

                    SubscriberList.Add(oSubscriber);
                }
                return Ok(SubscriberList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }


        [HttpGet]
        [Route("GetSubscriberByID")]
        public ActionResult GetSubscriberByID(int id)
        {
            try
            {
                List<NewsletterSubscriber> dbSubscriber = _CoreDbContext.NewsletterSubscriber.ToList();

                List<NewsletterSubscriber> SubscriberList = new List<NewsletterSubscriber>();


                foreach (var c in dbSubscriber)
                {
                    if (id == c.NewsletterId)
                    {
                        NewsletterSubscriber oNewsletterSubscriber = new NewsletterSubscriber();

                        oNewsletterSubscriber.NewsletterId = c.NewsletterId;
                        oNewsletterSubscriber.Date = c.Date;
                        oNewsletterSubscriber.SubscriberStatusId = c.SubscriberStatusId;
                        oNewsletterSubscriber.ClientId = c.ClientId;

                        SubscriberList.Add(oNewsletterSubscriber);
                    }
                    else
                    {

                    }
                }
                return Ok(SubscriberList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }




        [HttpGet]

        [Route("GetSubscriberByClientID")]
        public ActionResult GetSubscriberByClientID(int Clientid)
        {
            try
            {
                List<NewsletterSubscriber> dbSubscriber = _CoreDbContext.NewsletterSubscriber.ToList();

                List<NewsletterSubscriber> SubscriberList = new List<NewsletterSubscriber>();


                foreach (var c in dbSubscriber)
                {
                    if (Clientid == c.ClientId)
                    {
                        NewsletterSubscriber oNewsletterSubscriber = new NewsletterSubscriber();

                        oNewsletterSubscriber.NewsletterId = c.NewsletterId;
                        oNewsletterSubscriber.Date = c.Date;
                        oNewsletterSubscriber.SubscriberStatusId = c.SubscriberStatusId;
                        oNewsletterSubscriber.ClientId = c.ClientId;

                        SubscriberList.Add(oNewsletterSubscriber);
                    }
                    else
                    {

                    }
                }
                return Ok(SubscriberList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }


        [HttpPost]
        [Route("AddSubscriber")]
        public ActionResult AddSubscriber(NewsletterSubscriber cvm)
        {
            using (var contextmodel = new CoreDbContext())
            {

                var subscriber = new NewsletterSubscriber
                {
                    ClientId = cvm.ClientId,
                    SubscriberStatusId = 1, //default to 1 for subscribe
                    Date = System.DateTime.Now
                };

                try
                {
                    contextmodel.Add(subscriber);
                    contextmodel.SaveChanges();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
                }

                return Ok("Record saved in database");
            }
        }


        [HttpPost]
        [Route("RemoveSubscriber")]

        public ActionResult RemoveSubscriber(int ClientID)
        {



            using (var contextmodel = new CoreDbContext())
            {

                List<NewsletterSubscriber> dbSubscriber = _CoreDbContext.NewsletterSubscriber.ToList();
                foreach (var c in dbSubscriber)
                {
                    if (ClientID == c.ClientId)
                    {
                        NewsletterSubscriber oNewsletterSubscriber = new NewsletterSubscriber();

                        oNewsletterSubscriber.NewsletterId = c.NewsletterId;
                        oNewsletterSubscriber.Date = c.Date;
                        oNewsletterSubscriber.SubscriberStatusId = 2; // Set to unsubscribe
                        oNewsletterSubscriber.ClientId = c.ClientId;


                        try
                        {
                            contextmodel.NewsletterSubscriber.Update(oNewsletterSubscriber);
                            contextmodel.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
                        }


                    }
                    else
                    {

                    }
                }
                return StatusCode(StatusCodes.Status200OK, "Client unsubscribed");


            }


        }


        [HttpPost]
        [Route("SendNewsletter")]
        public ActionResult SendNewsletter(Models.Team40.NewsletterMessage cvm)
        {
            try
            {

                // Get Post Params Here
                string subjectline = cvm.SubjectLine;
                string messagebody = cvm.MessageBody;



                //Linq join with where clause

                List<Client> details = (
               from c in _CoreDbContext.Client.ToList()
               join n in _CoreDbContext.NewsletterSubscriber.ToList().Where(a => a.SubscriberStatusId == 1)
               on c.ClientId equals n.ClientId
               select new Client
               {
                   ClientId = c.ClientId,
                   Name = c.Name,
                   Surname = c.Surname,
                   EmailAddress = c.EmailAddress,
               }
               ).ToList();


                foreach (Client c in details)

                {
                    Console.Write(c.ClientId + ':' + c.EmailAddress);
                    //SendMail(c, messagebody, subjectline);
                    SendMail2("resinartnewsletter@gmail.com", subjectline, messagebody, c);
                }


                return StatusCode(StatusCodes.Status200OK, "Mailer sent");


            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        private void SendMail2(string fromEmailAddress, string subjectline, string htmlbody, Client c)
        {
            var fromAddress = new MailAddress(fromEmailAddress);
            var toAddress = new MailAddress(c.EmailAddress);

            using (var compiledMessage = new MailMessage(fromAddress, toAddress))
            {
                compiledMessage.Subject = subjectline;
                compiledMessage.Body = string.Format("Message: {0}", htmlbody);

                Attachment att = new Attachment("C:\\fakepath\\Newsletter1.pdf");
                compiledMessage.Attachments.Add(att);


                compiledMessage.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com"; // for example: smtp.gmail.com
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("resinartnewsletter@gmail.com", "pnyblzriureedwgp"); // your own provided email and password

                    smtp.Send(compiledMessage);
                }
            }
        }

        private void SendMail(Client c, string htmlbody, string subjectline)
        {

            string From = "roelofsz.robin@gmail.com";

            string AppPassword = "BgME173y6T8hDXnj";
            //string smtpclient = "mail.aarix.com";
            string smtpclient = "smtp-relay.sendinblue.com";


            int smtpport = 587; //465 or 587

            SmtpClient smtpClient = new SmtpClient(smtpclient)
            {
                Port = smtpport,
                Credentials = new System.Net.NetworkCredential(From, AppPassword),
                EnableSsl = true,
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress(From),
                Subject = subjectline,
                Body = htmlbody,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(c.EmailAddress);

            try
            {
                smtpClient.Send(mailMessage);
                smtpClient.Dispose();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }




        }




    }




}