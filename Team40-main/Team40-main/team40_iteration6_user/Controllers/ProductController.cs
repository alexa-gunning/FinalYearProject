using Audit.WebApi;
using Microsoft.AspNetCore.Authorization;
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
    //[AuditApi(EventTypeName = "{controller}/{action}")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public ProductController(IRepository Repository)
        {
            _Repository = Repository;
        }

        [HttpGet]
  
        [Route("GetProducts")]
        public object GetProducts()
        {
            List<ProductsVM> prod = (
                from c in _CoreDbContext.ProductColor.ToList()
                join p in _CoreDbContext.Product.ToList()
                on c.ProductColorId equals p.ProductColourId
                join t in _CoreDbContext.ProductType.ToList()
                on p.ProductTypeId equals t.ProductTypeId
                //join pr in _CoreDbContext.ProductPrice.ToList()
                // on p.ProductId equals pr.ProductId
                select new ProductsVM
                {
                    ProductName = p.ProductName,
                    Price = p.Price,
                    ColorName = c.ColorName,
                    ColorDescription = c.Description,
                    //Date = p.Date,
                    //ProductPrice = pr.ProductPrice1,
                    TypeDescription = t.Description,
                    ProductTypeName = t.ProductTypeName,
                    ProductId = p.ProductId,
                    QuantityOnHand = p.QuantityOnHand,
                    //ProductPriceId = pr.ProductPriceId

                }
                ).ToList();
            return prod;

        }
        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult> AddProduct(Product cvm)
        {
          

            //try
            //{

                var discount = new Product
                {
                    
                    ProductColourId = cvm.ProductColourId,
                ProductName = cvm.ProductName,
                ProductTypeId = cvm.ProductTypeId,
                Price = cvm.Price,
                    QuantityOnHand = cvm.QuantityOnHand,


                };
                using (var contextmodel = new CoreDbContext())
                {

                    contextmodel.Add(discount);
                    contextmodel.SaveChanges();

                }

              
            //}

            //catch (Exception e)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            //}

       
            return Ok();
          


        }
        [HttpPut]
        [Route("UpdateProductQty")]
        public async Task<ActionResult> UpdateProductQtyAsync(int id, int quantity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Inventory = GetProductByID(id);
            //if (Inventory == null)
            //{
            using (var contextmodel = new CoreDbContext())
            {

                var existingInventory = contextmodel.Product.Where(c => c.ProductId == id).FirstOrDefault<Product>();

                if (existingInventory != null)
                {
                    if (existingInventory.QuantityOnHand == null)
                    {
                        var existing = existingInventory.QuantityOnHand = 0;
                        int qty = existing - quantity;
                        existingInventory.ProductId = id;
                        existingInventory.ProductName = existingInventory.ProductName;
                        existingInventory.QuantityOnHand = qty;
                        existingInventory.ProductTypeId = existingInventory.ProductTypeId;
                        existingInventory.Price = existingInventory.Price;
                        existingInventory.ProductColourId = existingInventory.ProductColourId;
                    }
                    else
                    {
                        int qty = existingInventory.QuantityOnHand - quantity;
                        existingInventory.ProductId = id;
                        existingInventory.ProductName = existingInventory.ProductName;
                        existingInventory.QuantityOnHand = qty;
                        existingInventory.ProductTypeId = existingInventory.ProductTypeId;
                        existingInventory.Price = existingInventory.Price;
                        existingInventory.ProductColourId = existingInventory.ProductColourId;
                    }
                    try
                    {
                        contextmodel.Product.Update(existingInventory);
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
            }
            //}
            //else
            //{
            //    return StatusCode(StatusCodes.Status403Forbidden, "Item already exists.");
            //}

            return Ok();


        }
        [HttpPost]
        [Route("AddProductPrice")]
        public async Task<ActionResult> AddProductPrice(ProductPrice cvm)
        {


            try
            {

                var discount = new ProductPrice
                {

                   ProductId = cvm.ProductId,
                   ProductPrice1 = cvm.ProductPrice1


                };
                using (var contextmodel = new CoreDbContext())
                {

                    contextmodel.Add(discount);
                    contextmodel.SaveChanges();

                }


            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }


            return Ok();



        }
        [HttpPost]
        [Route("AddColor")]
        public async Task<ActionResult> AddColor(ProductColor cvm)
        {


            try
            {

                var discount = new ProductColor
                {

                    ColorName = cvm.ColorName,
                    Description = cvm.Description,


                };
                using (var contextmodel = new CoreDbContext())
                {

                    contextmodel.Add(discount);
                    contextmodel.SaveChanges();

                }


            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }


            return Ok();



        }
        [HttpPost]
        [Route("AddType")]
        public async Task<ActionResult> AddType(ProductType cvm)
        {


            try
            {

                var discount = new ProductType
                {

                    ProductTypeName = cvm.ProductTypeName,
                    Description = cvm.Description,


                };
                using (var contextmodel = new CoreDbContext())
                {

                    contextmodel.Add(discount);
                    contextmodel.SaveChanges();

                }


            }

            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }


            return Ok();
        }
        [HttpGet]
        [Route("GetColors")]
        public ActionResult GetColors()
        {
            try
            {
                List<ProductColor> dbHosts = _CoreDbContext.ProductColor.ToList();

                List<ProductColor> HostList = new List<ProductColor>();

                foreach (var c in dbHosts)
                {
                    ProductColor oHost = new ProductColor();
                    oHost.ProductColorId = c.ProductColorId;
                    oHost.ColorName = c.ColorName;
                    oHost.Description = c.Description;

                    HostList.Add(oHost);
                }
                return Ok(HostList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }
        [HttpGet]
        [Route("GetJustProducts")]
        public ActionResult GetJustProducts()
        {
            try
            {
                List<Product> dbHosts = _CoreDbContext.Product.ToList();

                List<Product> HostList = new List<Product>();

                foreach (var c in dbHosts)
                {
                    Product oHost = new Product();
                    oHost.ProductId = c.ProductId;
                    oHost.ProductName = c.ProductName;

                    HostList.Add(oHost);
                }
                return Ok(HostList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public ActionResult UpdateProduct(int id, Product cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            using (var contextmodel = new CoreDbContext())
            {

                var existing = contextmodel.Product.Where(c => c.ProductId == id).FirstOrDefault<Product>();

                if (existing != null)
                {
                    existing.ProductId = id;
                    existing.ProductColourId = cvm.ProductColourId;
                    existing.ProductName = cvm.ProductName;
                    existing.ProductTypeId = cvm.ProductTypeId;
                    existing.Price = cvm.Price;

                    existing.QuantityOnHand = cvm.QuantityOnHand;
                    try
                    {
                        contextmodel.Product.Update(existing);
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
            }


            return Ok();
        }

        [HttpGet]
        [Route("GetProductByID")]
        public ActionResult GetProductByID(int id)
        {
            try
            {
                List<Product> dbWorkshopHost = _CoreDbContext.Product.ToList();
                List<Product> WorkshopHostList = new List<Product>();

                foreach (var c in dbWorkshopHost)
                {
                    Product oWorkshopHost = new Product();

                    if (id == c.ProductId)
                    {
                        oWorkshopHost.ProductName = c.ProductName;
                        oWorkshopHost.ProductColourId = c.ProductColourId;
                        oWorkshopHost.ProductTypeId = c.ProductTypeId;
                        oWorkshopHost.Price = c.Price;
                        oWorkshopHost.QuantityOnHand = c.QuantityOnHand;

                        WorkshopHostList.Add(oWorkshopHost);
                    }
                    else
                    {

                    }
                }
                return Ok(WorkshopHostList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
        [HttpGet]
        [Route("GetTypes")]
        public ActionResult GetTypes()
        {
            try
            {
                List<ProductType> dbHosts = _CoreDbContext.ProductType.ToList();

                List<ProductType> HostList = new List<ProductType>();

                foreach (var c in dbHosts)
                {
                    ProductType oHost = new ProductType();
                    oHost.ProductTypeId = c.ProductTypeId;
                    oHost.ProductTypeName = c.ProductTypeName;
                    oHost.Description = c.Description;

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
        [Route("DeleteProduct")]
        public ActionResult DeleteProduct(ProductsVM cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {
                    var order = contextmodel.Order.Where(c => c.ProductId == cvm.ProductId).FirstOrDefault<Order>();

                    //var existing = contextmodel.ProductPrice.Where(c => c.ProductId == cvm.ProductId).FirstOrDefault<ProductPrice>();
                    var existing = contextmodel.Product.Where(c => c.ProductId == cvm.ProductId).FirstOrDefault<Product>();

                    if (existing != null )

                    {
                        if (order != null)
                        {
                            return Ok("Product ordered");
                        }
                        else 
                        {
                            if(existing == null) return NotFound();


                            //contextmodel.ProductPrice.Remove(existing);
                            //contextmodel.SaveChanges();
                            contextmodel.Product.Remove(existing);
                            contextmodel.SaveChanges();
                            
                        
                        };

                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return Ok();

        }
        [HttpPut]
        [Route("UpdateColor")]
        public ActionResult UpdateColor(int id, ProductColor cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            using (var contextmodel = new CoreDbContext())
            {

                var existing = contextmodel.ProductColor.Where(c => c.ProductColorId == id).FirstOrDefault<ProductColor>();

                if (existing != null)
                {
                    existing.ProductColorId = id;
                    existing.Description = cvm.Description;
                    existing.ColorName = cvm.ColorName;


                    try
                    {
                        contextmodel.ProductColor.Update(existing);
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
            }


            return Ok();
        }
        [HttpPut]
        [Route("UpdateType")]
        public ActionResult UpdateType(int id, ProductType cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            using (var contextmodel = new CoreDbContext())
            {

                var existing = contextmodel.ProductType.Where(c => c.ProductTypeId == id).FirstOrDefault<ProductType>();

                if (existing != null)
                {
                    existing.ProductTypeId = id;
                    existing.Description = cvm.Description;
                    existing.ProductTypeName = cvm.ProductTypeName;


                    try
                    {
                        contextmodel.ProductType.Update(existing);
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
            }


            return Ok();
        }
        [HttpPost]
        [Route("DeleteColor")]
        public ActionResult DeleteColor(ProductColor cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existing = contextmodel.ProductColor.Where(c => c.ProductColorId == cvm.ProductColorId).FirstOrDefault<ProductColor>();

                    if (existing != null)

                    {

                        if (existing == null) return NotFound();


                        contextmodel.ProductColor.Remove(existing);
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
        [Route("DeleteType")]
        public ActionResult DeleteType(ProductType cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existing = contextmodel.ProductType.Where(c => c.ProductTypeId == cvm.ProductTypeId).FirstOrDefault<ProductType>();

                    if (existing != null)

                    {

                        if (existing == null) return NotFound();


                        contextmodel.ProductType.Remove(existing);
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
        [HttpGet]
        [Route("GetColorByID")]
        public ActionResult GetColorByID(int id)
        {
            try
            {
                List<ProductColor> dbWorkshopHost = _CoreDbContext.ProductColor.ToList();
                List<ProductColor> WorkshopHostList = new List<ProductColor>();

                foreach (var c in dbWorkshopHost)
                {
                    ProductColor oWorkshopHost = new ProductColor();

                    if (id == c.ProductColorId)
                    {
                        oWorkshopHost.ColorName = c.ColorName;
                        oWorkshopHost.Description = c.Description;
                      


                        WorkshopHostList.Add(oWorkshopHost);
                    }
                    else
                    {

                    }
                }
                return Ok(WorkshopHostList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
        [HttpGet]
        [Route("GetTypeByID")]
        public ActionResult GetTypeByID(int id)
        {
            try
            {
                List<ProductType> dbWorkshopHost = _CoreDbContext.ProductType.ToList();
                List<ProductType> WorkshopHostList = new List<ProductType>();

                foreach (var c in dbWorkshopHost)
                {
                    ProductType oWorkshopHost = new ProductType();

                    if (id == c.ProductTypeId)
                    {
                        oWorkshopHost.ProductTypeName = c.ProductTypeName;
                        oWorkshopHost.Description = c.Description;



                        WorkshopHostList.Add(oWorkshopHost);
                    }
                    else
                    {

                    }
                }
                return Ok(WorkshopHostList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
        [HttpGet]
        [Route("GetProductPerformanceReport")]
        public object GetProductPerformanceReport()
        {
            try
            {

                Random rd = new Random();
                


                List<Productperformancereport > reportlist =
                     (from i in _CoreDbContext.Product.ToList()

                
                select new Productperformancereport
                      {
                          ProductID = i.ProductId,
                          ProductName = i.ProductName,
                          TotalProductSold = rd.Next(1, 100),
                          CostOfProduction = rd.Next(1, 50),
                          NetProfit = 0,
                          SalesRevenue = rd.Next(50, 200)


                }).ToList();

                return reportlist;


            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }
    }

}