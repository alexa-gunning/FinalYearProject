using Audit.WebApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class Supplier : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public Supplier(IRepository Repository)
        {
            _Repository = Repository;
        }
        [HttpGet]

        [Route("GetPurchases")]
        public object GetPurchases()
        {
            List<SupplierPurchasesVM> discounts = (
                from i in _CoreDbContext.Inventory.ToList()
                join s in _CoreDbContext.SupplierInventory.ToList()
                on i.InventoryId equals s.InventoryId
                join sup in _CoreDbContext.SupplierPurchase.ToList()
                 on s.SupplierPurchaseId equals sup.SupplierPurchaseId
                join n in _CoreDbContext.Supplier.ToList()
                on sup.SupplierId equals n.SupplierId
                
                select new SupplierPurchasesVM
                {
                    Date = sup.Date,
                    Price = sup.Price,
                    QuantityPurchased = sup.QuantityPurchased,
                    SupplierName = n.SupplierName,
                    ItemName = i.ItemName,
                    SupplierPurchaseId = sup.SupplierPurchaseId,
                    InventoryID = i.InventoryId,
                    SupplierID = sup.SupplierId,
                }
                ).ToList();
            return discounts;

        }
        //[HttpPost]
        //[Route("AddSupplierPurchase")]
        //public object AddSupplierPurchase(SupplierDetails cvm)
        //{
        //    //var Supplier = new SupplierDetails();
        //    //_CoreDbContext.SupplierDetails.Add(Supplier);
        //    //_CoreDbContext.SaveChanges();

        //    //var suppliers = await _CoreDbContext.

        //    try
        //    {
        //        var Supplier = new SupplierInventory();
        //        _CoreDbContext.SupplierInventory.Add(Supplier);
        //        _CoreDbContext.SaveChanges();

        //        var suppliers = _CoreDbContext.SupplierInventory
        //        .Include(x => x.SupplierPurchase)
        //        .Where(x => x.SupplierPurchaseId == Supplier.SupplierPurchaseId)
        //        //.Include(a => a.Supplier)
        //        //.Where(a => a.SupplierId == Supplier.SupplierId)
        //       .Include(z => z.Inventory)
        //        .Where(y => y.InventoryId == Supplier.InventoryId);


        //        //using (var contextmodel = new CoreDbContext())
        //        //{

        //        //    contextmodel.Add(Supplier);
        //        //    contextmodel.SaveChanges();
        //        return suppliers;

        //        //}
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
        //    }

        //    return Ok();
        //}
        [HttpPost]
        [Route("AddSupplierPurchase")]
        public async Task<ActionResult> AddSupplierPurchase(SupplierPurchasesVM cvm)
        {

            
                Random rnd = new Random();

                var key = rnd.Next(100, 999);

            //await UpdateInventoryAsync(cvm.InventoryID, (decimal?)cvm.QuantityPurchased);


            //try
            //{
            var discount2 = new SupplierPurchase
            {
                //SupplierPurchaseId = cvm.SupplierPurchaseID,
                //InventoryId = cvm.InventoryID,
                Price = cvm.Price,
                QuantityPurchased = cvm.QuantityPurchased,
                SupplierId = cvm.SupplierID,
                Date = cvm.Date,
                SupplierPurchaseId = key,
                //TotalCost = 1,

            };

            var discount = new SupplierInventory
                {

                    InventoryId = cvm.InventoryID,
                    //SupplierPurchaseId = cvm.
                    SupplierPurchaseId = key,
                    //SupplierInventoryId = cvm.InventoryID.ToString(),


                };
                //var discount2 = new SupplierPurchase
                //{
                //    //SupplierPurchaseId = cvm.SupplierPurchaseID,
                //    InventoryId = cvm.InventoryID,
                //    Price = cvm.Price,
                //    QuantityPurchased = cvm.QuantityPurchased,
                //    SupplierId = cvm.SupplierID,
                //    Date = cvm.Date,
                //    SupplierPurchaseId = key,
                //    //TotalCost = 1,

                //};
             

                using (var contextmodel = new CoreDbContext())
                {
                contextmodel.Add(discount2);
                contextmodel.SaveChanges();

                contextmodel.Add(discount);
                    contextmodel.SaveChanges();
              
                    //contextmodel.Add(discount2);
                    //contextmodel.SaveChanges();

                }


            //}

            //catch (Exception e)
            //{
            //    return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            //}


            return Ok();



        }
        [HttpGet]
        [Route("GetInventoryByID")]
        public ActionResult GetInventoryByID(int id)
        {
            try
            {
                List<Inventory> dbInventory = _CoreDbContext.Inventory.ToList();
                List<Inventory> InventoryList = new List<Inventory>();

                foreach (var c in dbInventory)
                {
                    Inventory oInventory = new Inventory();

                    if (id == c.InventoryId)
                    {
                        oInventory.ItemName = c.ItemName;
                        oInventory.QuantityOnHand = c.QuantityOnHand;
                        oInventory.LastUpdated = c.LastUpdated;
                        oInventory.InventoryId = c.InventoryId;
                      

                        InventoryList.Add(oInventory);
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
        [HttpPut]
        [Route("UpdateInventory")]
        public async Task<ActionResult> UpdateInventoryAsync(int id, decimal? quantity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Inventory = GetInventoryByID(id);
            //if (Inventory == null)
            //{
                using (var contextmodel = new CoreDbContext())
                {

                    var existingInventory = contextmodel.Inventory.Where(c => c.InventoryId == id).FirstOrDefault<Inventory>();

                    if (existingInventory != null)
                    {
                    if (existingInventory.QuantityOnHand == null) {
                       var existing =  existingInventory.QuantityOnHand = 0;
                        decimal? qty = existing + quantity;
                        existingInventory.InventoryId = id;
                        existingInventory.ItemName = existingInventory.ItemName;
                        existingInventory.QuantityOnHand = qty;
                        existingInventory.LastUpdated = DateTime.Now;
                    }
                    else
                    {
                        decimal? qty = existingInventory.QuantityOnHand + quantity;
                        existingInventory.InventoryId = id;
                        existingInventory.ItemName = existingInventory.ItemName;
                        existingInventory.QuantityOnHand = qty;
                        existingInventory.LastUpdated = DateTime.Now;
                    }
                        try
                        {
                            contextmodel.Inventory.Update(existingInventory);
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
        [HttpPut]
        [Route("UpdateSupplierPurchase")]
        public ActionResult UpdateSupplierPurchase(int id, SupplierPurchasesVM cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            using (var contextmodel = new CoreDbContext())
            {

                var existing = contextmodel.SupplierInventory.Where(c => c.SupplierPurchaseId == id).FirstOrDefault<SupplierInventory>();
                var existing2 = contextmodel.SupplierPurchase.Where(c => c.SupplierPurchaseId == id).FirstOrDefault<SupplierPurchase>();

                if (existing != null)
                {
                    existing.SupplierPurchaseId = id;
                    existing2.SupplierPurchaseId = id;
                    existing.InventoryId = cvm.InventoryID;
                    existing2.InventoryId = cvm.InventoryID;
                    existing2.Price = cvm.Price;
                    existing2.QuantityPurchased = cvm.QuantityPurchased;
                    existing2.Date = cvm.Date;
                    existing2.SupplierId = cvm.SupplierID;

                    try
                    {
                        contextmodel.SupplierPurchase.Update(existing2);
                        contextmodel.SaveChanges();
                        contextmodel.SupplierInventory.Update(existing);
                        contextmodel.SaveChanges();
                        //contextmodel.SupplierPurchase.Update(existing2);
                        //contextmodel.SaveChanges();
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
        [Route("GetPurchaseByID")]
        public ActionResult GetPurchaseByID(int id)
        {
            try
            {
                List<SupplierPurchase> db = _CoreDbContext.SupplierPurchase.ToList();
                List<SupplierPurchase> List = new List<SupplierPurchase>();
                List<SupplierInventory> db1 = _CoreDbContext.SupplierInventory.ToList();
                List<SupplierInventory> List1 = new List<SupplierInventory>();

                foreach (var c in db)
                {
                    SupplierPurchase o = new SupplierPurchase();

                    if (id == c.SupplierPurchaseId)
                    {
                        o.Date = c.Date;
                        o.SupplierId = c.SupplierId;
                        o.Price = c.Price;
                        o.InventoryId = c.InventoryId;
                        o.QuantityPurchased = c.QuantityPurchased;
                        List.Add(o);
                    }
                    else
                    {

                    }
                }
                foreach (var c in db1)
                {
                    SupplierInventory o = new SupplierInventory();

                    if (id == c.SupplierPurchaseId)
                    {
                    o.InventoryId = c.InventoryId;
                        List1.Add(o);
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
        [Route("DeleteSupplierPurchase")]
        public ActionResult DeleteSupplierPurchase(SupplierPurchasesVM cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existing = contextmodel.SupplierPurchase.Where(c => c.SupplierPurchaseId == cvm.SupplierPurchaseId).FirstOrDefault<SupplierPurchase>();
                    var existing2 = contextmodel.SupplierInventory.Where(c => c.SupplierPurchaseId == cvm.SupplierPurchaseId).FirstOrDefault<SupplierInventory>();

                    if (existing != null && existing2 != null)

                    {

                        if (existing == null && existing2 != null) return NotFound();


                        contextmodel.SupplierPurchase.Remove(existing);
                        contextmodel.SaveChanges();
                        contextmodel.SupplierInventory.Remove(existing2);
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
        //Add Supplier Company
        [HttpPost]
        [Route("AddSupplier")]
        public ActionResult AddSuppliery(Supply cvm)
        {
            Random rnd = new Random();

            var key = rnd.Next(100, 999);
            var Supplier = new Supply
            {
                SupplierId = key,
     
                SupplierName = cvm.SupplierName,
                SupplierPhoneNumber = cvm.SupplierPhoneNumber,
                SupplierEmail = cvm.SupplierEmail,
                SupplierAddress = cvm.SupplierAddress
            };

            try
            {
                using (var contextmodel = new CoreDbContext())
                {

                    contextmodel.Add(Supplier);
                    contextmodel.SaveChanges();

                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }

            return Ok();
        }

        //Update Delivery Company

        [HttpPut]
        [Route("UpdateSupplier")]
        public ActionResult UpdateSupplier(int id, Supply cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (var contextmodel = new CoreDbContext())
            {

                var existingSupplier = contextmodel.Supplier.Where(c => c.SupplierId == id).FirstOrDefault<Supply>();

                if (existingSupplier != null)
                {
                    existingSupplier.SupplierId = id;
                    existingSupplier.SupplierName = cvm.SupplierName;
                    existingSupplier.SupplierPhoneNumber = cvm.SupplierPhoneNumber;
                    existingSupplier.SupplierEmail = cvm.SupplierEmail;
                    existingSupplier.SupplierAddress = cvm.SupplierAddress;

                    try
                    {
                        contextmodel.Supplier.Update(existingSupplier);
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


        //Delete Supplier Company
        [HttpDelete]
        [Route("DeleteSupplier")]
        public ActionResult DeleteSupplierCompany(int id, Supply cvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingSupplier = contextmodel.Supplier.Where(c => c.SupplierId == id).FirstOrDefault<Supply>();

                    if (existingSupplier != null)

                    {

                        if (existingSupplier == null) return NotFound();


                        contextmodel.Supplier.Remove(existingSupplier);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Supplier Company deleted");

        }


        [HttpGet]
        [Route("GetAllSuppliers")]
        public ActionResult GetAllSuppliers()
        {
            try
            {
                List<Supply> dbSupplierCompany = _CoreDbContext.Supplier.ToList();

                List<Supply> SupplierCompanyList = new List<Supply>();

                foreach (var c in dbSupplierCompany)
                {
                    Supply oSupplierCompany = new Supply();

                    oSupplierCompany.SupplierName = c.SupplierName;
                    oSupplierCompany.SupplierPhoneNumber = c.SupplierPhoneNumber;
                    oSupplierCompany.SupplierEmail = c.SupplierEmail;
                    oSupplierCompany.SupplierAddress = c.SupplierAddress;

                    oSupplierCompany.SupplierId = c.SupplierId;


                    SupplierCompanyList.Add(oSupplierCompany);

                }
                return Ok(SupplierCompanyList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetSupplierByID")]
        public ActionResult GetSupplierByID(int id)
        {
            try
            {
                List<Supply> dbSupplier = _CoreDbContext.Supplier.ToList();
                List<Supply> SupplierList = new List<Supply>();

                foreach (var c in dbSupplier)
                {
                    Supply oSupplier = new Supply();

                    if (id == c.SupplierId)
                    {
                        oSupplier.SupplierName = c.SupplierName;
                        oSupplier.SupplierEmail = c.SupplierEmail;
                        oSupplier.SupplierId = c.SupplierId;
                        oSupplier.SupplierPhoneNumber = c.SupplierPhoneNumber;
                        oSupplier.SupplierAddress = c.SupplierAddress;


                        SupplierList.Add(oSupplier);
                    }
                    else
                    {

                    }
                }
                return Ok(SupplierList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
        [HttpPost]
        [Route("DeleteSupplierPost")]
        public ActionResult DeleteSupplierPost(Supply cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingSupplier = contextmodel.Supplier.Where(c => c.SupplierId == cvm.SupplierId).FirstOrDefault<Supply>();

                    if (existingSupplier != null)

                    {

                        if (existingSupplier == null) return NotFound();


                        contextmodel.Supplier.Remove(existingSupplier);
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
    }
}
