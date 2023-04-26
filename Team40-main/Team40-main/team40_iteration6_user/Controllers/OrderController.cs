using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using team40_iteration6_user.Models;
using team40_iteration6_user.Team40;
using team40_iteration6_user.ViewModel;

namespace team40_iteration6_user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public OrderController(IRepository Repository)
        {
            _Repository = Repository;
        }
        [HttpGet]

        [Route("GetOrders")]
        public object GetOrders()
        {
            
            var orderlist
                = (
                 from o in _CoreDbContext.Order.ToList()
                 //join p in _CoreDbContext.OrderProduct.ToList()
               //on o.OrderProductId equals p.OrderProductId
                 join s in _CoreDbContext.OrderStatus.ToList()
               on o.OrderStatusId equals s.OrderStatusId
                 join c in _CoreDbContext.Client.ToList()
               on o.ClientId equals c.ClientId
                 join d in _CoreDbContext.DeliveryCompany.ToList()
              on o.DeliveryCompanyId equals d.DeliveryCompanyId
                 join a in _CoreDbContext.Address.ToList()
               on o.AddressId equals a.AddressId
                 join prod in _CoreDbContext.Product.ToList()
               on o.ProductId equals prod.ProductId
                 group o by o.OrderProductId into grouped
                 select new OrderVM
                 {
                     ProductIds = grouped.Select(t => t.ProductId),
                     Quantities = grouped.Select(t => t.Quantity),


        //             ProductNames = new List<string> { 
        //             _CoreDbContext.Product
        //             .Where(y => y.ProductId == grouped.Select(x => x.Product.ProductId)).ProductName,
        //},

                     //OrderId = (int)_CoreDbContext.Order
                     //.Where(y => y.OrderId == grouped.Select(x => x.OrderId)
                     //.FirstOrDefault()).FirstOrDefault().OrderId,

                    // OrderProductId = (int)_CoreDbContext.OrderProduct
                    // .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                    // .FirstOrDefault()).FirstOrDefault().OrderProductId,

                     ClientId = _CoreDbContext.Order
                    .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                     .FirstOrDefault()).FirstOrDefault().ClientId,

                    // Description = _CoreDbContext.OrderStatus
                    //.Where(y => y.OrderStatusId == grouped.Select(x => x.OrderStatusId)
                    // .FirstOrDefault()).FirstOrDefault().Description,

                     Date = _CoreDbContext.Order
                    .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                     .FirstOrDefault()).FirstOrDefault().Date,

                     OrderStatusId = _CoreDbContext.Order
                    .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                     .FirstOrDefault()).FirstOrDefault().OrderStatusId,

                     DeliverCompanyId = _CoreDbContext.Order
                    .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                     .FirstOrDefault()).FirstOrDefault().DeliveryCompanyId,

                      DiscountId = _CoreDbContext.Order
                     .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                      .FirstOrDefault()).FirstOrDefault().DiscountId,

                     AddressId = _CoreDbContext.Order
                    .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                     .FirstOrDefault()).FirstOrDefault().AddressId,

                     Name = _CoreDbContext.Client
                    .Where(y => y.ClientId == grouped.Select(x => x.ClientId)
                     .FirstOrDefault()).FirstOrDefault().Name,

                     Surname = _CoreDbContext.Client
                    .Where(y => y.ClientId == grouped.Select(x => x.ClientId)
                     .FirstOrDefault()).FirstOrDefault().Surname,

                     DeliveryCompanyName = _CoreDbContext.DeliveryCompany
                    .Where(y => y.DeliveryCompanyId == grouped.Select(x => x.DeliveryCompanyId)
                     .FirstOrDefault()).FirstOrDefault().DeliveryCompanyName,

                     DeliveryCompanyBaseRate = _CoreDbContext.DeliveryCompany
                    .Where(y => y.DeliveryCompanyId == grouped.Select(x => x.DeliveryCompanyId)
                     .FirstOrDefault()).FirstOrDefault().DeliveryCompanyBaseRate,

                     streetNumber = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().StreetNumber,

                     streetName = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().StreetName,

                     city = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().City,

                     province = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().Province,

                     areaCode = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().AreaCode,

                     Country = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().Country,
                 } ) ;
           
            
            return orderlist;
        }
        [HttpGet]

        [Route("GetOrders2")]
        public object GetOrders2()
        {

            var orderlist
                = (
                 from o in _CoreDbContext.Order.ToList()
                     //join p in _CoreDbContext.OrderProduct.ToList()
                     //on o.OrderProductId equals p.OrderProductId
                 join s in _CoreDbContext.OrderStatus.ToList()
               on o.OrderStatusId equals s.OrderStatusId
                 join c in _CoreDbContext.Client.ToList()
               on o.ClientId equals c.ClientId
                 join d in _CoreDbContext.DeliveryCompany.ToList()
              on o.DeliveryCompanyId equals d.DeliveryCompanyId
                 join a in _CoreDbContext.Address.ToList()
               on o.AddressId equals a.AddressId
                 join prod in _CoreDbContext.Product.ToList()
               on o.ProductId equals prod.ProductId
                 select new OrderVM
                 { 

                     ClientId = c.ClientId,
                     OrderProductId = (int)o.OrderProductId,
                     Date = o.Date,
                     OrderStatusId = o.OrderStatusId,
                     DeliverCompanyId = o.DeliveryCompanyId,
                     DiscountId = o.DiscountId,
                     AddressId = o.AddressId,

                     Name = c.Name,
                     ProductName = prod.ProductName,

                     Quantity = o.Quantity,
                     

                     Surname = c.Surname,

                     DeliveryCompanyName = d.DeliveryCompanyName,

                     DeliveryCompanyBaseRate = d.DeliveryCompanyBaseRate,

                     streetNumber = a.StreetNumber,

                     streetName = a.StreetName,

                     city = a.City,
                     

                     province = a.Province,

                     areaCode = a.AreaCode,

                     Country = a.Country,
                 });


            return orderlist;
        }
        [HttpGet]

        [Route("GetOrderByClientID2")]
        public object GetOrderByClientID2(int id)
        {

            var orderlist
                = (
                 from o in _CoreDbContext.Order.ToList()
                     //join p in _CoreDbContext.OrderProduct.ToList()
                     //on o.OrderProductId equals p.OrderProductId
                 join s in _CoreDbContext.OrderStatus.ToList()
               on o.OrderStatusId equals s.OrderStatusId
                 join c in _CoreDbContext.Client.ToList()
               on o.ClientId equals c.ClientId
                 join d in _CoreDbContext.DeliveryCompany.ToList()
              on o.DeliveryCompanyId equals d.DeliveryCompanyId
                 join a in _CoreDbContext.Address.ToList()
               on o.AddressId equals a.AddressId
                 join prod in _CoreDbContext.Product.ToList()
               on o.ProductId equals prod.ProductId
                 select new OrderVM
                 {

                     ClientId = c.ClientId,
                     OrderProductId = (int)o.OrderProductId,
                     Date = o.Date,
                     OrderStatusId = o.OrderStatusId,
                     DeliverCompanyId = o.DeliveryCompanyId,
                     DiscountId = o.DiscountId,
                     AddressId = o.AddressId,

                     Name = c.Name,

                     Surname = c.Surname,

                     ProductName = prod.ProductName,

                    Quantity = o.Quantity,
                     DeliveryCompanyName = d.DeliveryCompanyName,

                     DeliveryCompanyBaseRate = d.DeliveryCompanyBaseRate,

                     streetNumber = a.StreetNumber,

                     streetName = a.StreetName,

                     city = a.City,


                     province = a.Province,

                     areaCode = a.AreaCode,

                     Country = a.Country,
                 }).Where(b => id == b.ClientId);


            return orderlist;
        }
        [HttpGet]
        [Route("GetMaxOrderId")]
        public object GetMaxOrderId()
        {
            using (var contextmodel = new CoreDbContext())
            {

                var maxId = _CoreDbContext.Order.Max(m => m.OrderId);

                return maxId;

                }
                }
        [HttpGet]

        [Route("GetOrderByClientID")]
        public object GetOrderByClientID(int id)
        {
            try
            {
                var orderlist
                    = (
                     from o in _CoreDbContext.Order.ToList()
                   //  join p in _CoreDbContext.OrderProduct.ToList()
                   //on o.OrderProductId equals p.OrderProductId
                     join s in _CoreDbContext.OrderStatus.ToList()
                   on o.OrderStatusId equals s.OrderStatusId
                     join c in _CoreDbContext.Client.ToList()
                   on o.ClientId equals c.ClientId
                     join d in _CoreDbContext.DeliveryCompany.ToList()
                  on o.DeliveryCompanyId equals d.DeliveryCompanyId
                     join a in _CoreDbContext.Address.ToList()
                   on o.AddressId equals a.AddressId
                     join prod in _CoreDbContext.Product.ToList()
                   on o.ProductId equals prod.ProductId
                     group o by o.OrderProductId into grouped
                     //group prod by prod.Order.ProductId into grouped
                     select new OrderVM
                     {
                         ProductIds = grouped.Select(t => t.ProductId),
                         Quantities = grouped.Select(t => t.Quantity),

                        

                         //ProductNames = (IEnumerable<string>)grouped.Select( x => x.Product.ProductName),
                         //ProductNames = (IEnumerable<string>)grouped.Select(x => x.ProductId),
                         //OrderId = (int)_CoreDbContext.Order
                         //.Where(y => y.OrderId == grouped.Select(x => x.OrderId)
                         //.FirstOrDefault()).FirstOrDefault().OrderId,

                         // OrderProductId = (int)_CoreDbContext.OrderProduct
                         // .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                         // .FirstOrDefault()).FirstOrDefault().OrderProductId,

                         ClientId = _CoreDbContext.Order
                    .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                     .FirstOrDefault()).FirstOrDefault().ClientId,

                         // Description = _CoreDbContext.OrderStatus
                         //.Where(y => y.OrderStatusId == grouped.Select(x => x.OrderStatusId)
                         // .FirstOrDefault()).FirstOrDefault().Description,

                         Date = _CoreDbContext.Order
                    .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                     .FirstOrDefault()).FirstOrDefault().Date,

                         OrderStatusId = _CoreDbContext.Order
                    .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                     .FirstOrDefault()).FirstOrDefault().OrderStatusId,

                         DeliverCompanyId = _CoreDbContext.Order
                    .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                     .FirstOrDefault()).FirstOrDefault().DeliveryCompanyId,

                         DiscountId = _CoreDbContext.Order
                     .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                      .FirstOrDefault()).FirstOrDefault().DiscountId,

                         AddressId = _CoreDbContext.Order
                    .Where(y => y.OrderProductId == grouped.Select(x => x.OrderProductId)
                     .FirstOrDefault()).FirstOrDefault().AddressId,

                         Name = _CoreDbContext.Client
                    .Where(y => y.ClientId == grouped.Select(x => x.ClientId)
                     .FirstOrDefault()).FirstOrDefault().Name,

                         Surname = _CoreDbContext.Client
                    .Where(y => y.ClientId == grouped.Select(x => x.ClientId)
                     .FirstOrDefault()).FirstOrDefault().Surname,

                         DeliveryCompanyName = _CoreDbContext.DeliveryCompany
                    .Where(y => y.DeliveryCompanyId == grouped.Select(x => x.DeliveryCompanyId)
                     .FirstOrDefault()).FirstOrDefault().DeliveryCompanyName,

                         DeliveryCompanyBaseRate = _CoreDbContext.DeliveryCompany
                    .Where(y => y.DeliveryCompanyId == grouped.Select(x => x.DeliveryCompanyId)
                     .FirstOrDefault()).FirstOrDefault().DeliveryCompanyBaseRate,

                         streetNumber = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().StreetNumber,

                         streetName = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().StreetName,

                         city = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().City,

                         province = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().Province,

                         areaCode = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().AreaCode,

                         Country = _CoreDbContext.Address
                    .Where(y => y.AddressId == grouped.Select(x => x.AddressId)
                     .FirstOrDefault()).FirstOrDefault().Country,
                     }).Where(b => id == b.ClientId);

                return orderlist;
            }
            catch
            {
                return Ok("error");
            }

            //return orderlist;
        }

        //[HttpPost]
        //[Route("AddOrderProduct")]
        //public ActionResult AddOrderProduct(int ProductId, decimal? Quantity, int OrderProductId)
        //{
        //    using (var contextmodel = new CoreDbContext())
        //    {
        //        var maxId = _CoreDbContext.Order.Max(m => m.OrderId);
        //        var booking1 = new OrderProduct
        //        {

        //            OrderId = maxId,
        //            ProductId = ProductId,
        //            Quantity = Quantity,
        //            OrderProductId = OrderProductId,
        //        };

        //        try
        //        {



        //            contextmodel.Add(booking1);
        //            contextmodel.SaveChanges();


        //        }

        //        catch (Exception e)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
        //        }

        //        return Ok();

        //    }
        //}
             [HttpPost]
        [Route("AddOrder")]
        public ActionResult AddOrder(Order cvm)
        {
            using (var contextmodel = new CoreDbContext())
            {
                //var maxId = _CoreDbContext.Order.Max(m => m.OrderId);
                var client = new Order
                {
                    //OrderId = maxId + 1,
                    
                    ClientId = cvm.ClientId,
                    Date = DateTime.Now,
                    OrderStatusId = cvm.OrderStatusId,
                    DeliveryCompanyId = cvm.DeliveryCompanyId,
                    DiscountId = cvm.DiscountId,
                    AddressId = cvm.AddressId,
                    OrderProductId = cvm.OrderProductId,
                    ProductId = cvm.ProductId,
                    Quantity = cvm.Quantity
                };
                //var maxId = _CoreDbContext.Order.Max(m => m.OrderId);
                //var booking1 = new OrderProduct
                //{
                
                //    OrderId = maxId,
                //    ProductId = cvm.ProductId,
                //    Quantity = cvm.Quantity,
                //    OrderProductId = cvm.OrderProductId,
                //};

                try
                {



                    contextmodel.Add(client);
                    contextmodel.SaveChanges();
                    //contextmodel.Add(booking1);
                    //contextmodel.SaveChanges();


                }

                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());

                }
               
                return Ok();

            }
        }

        [HttpPost]
        [Route("AddOrderProduct")]
        public ActionResult AddOrderProduct(int ProductId, decimal? Quantity, int OrderProductId)
        {
            using (var contextmodel = new CoreDbContext())
            {

                var maxId = GetMaxOrderId();

                var booking1 = new OrderProduct
                {
                    //maxId = _CoreDbContext.OrderProduct.Max(m => m.OrderId) + 1,
                    //OrderId = (int)maxId,
                    ProductId = ProductId,
                    Quantity = Quantity,
                    OrderProductId = OrderProductId,
                };

                try
                {



                    contextmodel.Add(booking1);
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
        [Route("DeleteOrder")]
        public ActionResult DeleteClient(Order vm)
        {
            try
            {

                List<Order> dbClients = _CoreDbContext.Order.ToList();
                List<OrderProduct> dbClients1 = _CoreDbContext.OrderProduct.ToList();
                //List<Client> ClientList = new List<Client>();

                foreach (var c in dbClients)
                {
                    //Client oClient = new Client();
                    if (!ModelState.IsValid)
                    {
                        return BadRequest();
                    }

                    using (var contextmodel = new CoreDbContext())
                    {

                        //var existingClient1 = contextmodel.OrderProduct.Where(c => c.OrderProductId == vm.OrderProductId).FirstOrDefault<OrderProduct>();
                        var existingClient = contextmodel.Order.Where(c => c.OrderProductId == vm.OrderProductId).FirstOrDefault<Order>();

                        if (existingClient != null 
                            //&& existingClient1 != null
                            )

                        {

                            if (existingClient == null 
                                //&& existingClient1 == null
                                ) return NotFound();

                            //contextmodel.OrderProduct.Remove(existingClient1);
                            //contextmodel.SaveChanges();
                            contextmodel.Order.Remove(existingClient);
                            contextmodel.SaveChanges();


                        }
                        else
                        {
                            return NotFound();
                        }

                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Order deleted");

        }
    }
}

    

