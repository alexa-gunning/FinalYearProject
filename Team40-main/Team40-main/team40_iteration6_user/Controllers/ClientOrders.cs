using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using team40_iteration6_user.Models;
using team40_iteration6_user.Team40;
using System;
using System.Collections.Generic;
using System.Linq;
using Audit.WebApi;

namespace team40_iteration6_user.Controllers
{
    [Route("api/[controller]")]
    //[AuditApi(EventTypeName = "{controller}/{action}")]
    [ApiController]
    public class ClientOrders : ControllerBase
    {

        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public ClientOrders(IRepository Repository)
        {
            _Repository = Repository;
        }
        [HttpGet]
        [Route("GetClientOrders")]
        public object Ordered()
        {
            List<Order> clientorders = (
                from r in _CoreDbContext.Order.ToList()
                join s in _CoreDbContext.OrderStatus.ToList()
                on r.OrderStatusId equals s.OrderStatusId
                join c in _CoreDbContext.Client.ToList()
                on r.ClientId equals c.ClientId

                select new Order
                {
                    OrderId = r.OrderId,
                    ClientId = c.ClientId,
                    Date = r.Date,
                    OrderStatus = r.OrderStatus
                }
                ).ToList();

            return clientorders;

        }
        //[HttpGet]
        //[Route("GetClientOrders")]
        //public object GetClientOrders()
        //{
        //    List<Order> clientorders = (
        //        from r in _CoreDbContext.Order.ToList()
        //        join s in _CoreDbContext.OrderStatus
        //        on r.OrderStatusId equals s.OrderStatusId
        //        join t in _CoreDbContext.Client.ToList()
        //        on r.ClientId equals t.ClientId
        //        join d in _CoreDbContext.DeliveryCompany.ToList()
        //        on r.DeliveryCompanyId equals d.DeliveryCompanyId
        //        join c in _CoreDbContext.DiscountRequest
        //        on r.DiscountId equals c.DiscountId

        //        //select new Order
        //        //{
        //        //    Date = r.Date,
        //        //    ClientId = t.ClientId,
        //        //    Description = s.Description,
        //        //    DeliveryCompanyName= d.DeliveryCompanyName,
        //        //    Percentage = c.Percentage





        //        //}
        //        //).ToList();
        //}
    }
}
