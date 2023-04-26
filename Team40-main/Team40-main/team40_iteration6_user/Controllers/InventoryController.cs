using Audit.WebApi;
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
    public class InventoryController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public InventoryController(IRepository Repository)
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
        [Route("GetAllInventory")]
        public ActionResult GetAllInventory()
        {
            try
            {
                List<Inventory> dbInventory = _CoreDbContext.Inventory.ToList();

                List<Inventory> InventoryList = new List<Inventory>();

                foreach (var c in dbInventory)
                {
                    Inventory oInventory = new Inventory();

                    oInventory.InventoryId = c.InventoryId;
                    oInventory.ItemName = c.ItemName;
                    oInventory.LastUpdated = c.LastUpdated;
                    oInventory.QuantityOnHand = c.QuantityOnHand;

                    InventoryList.Add(oInventory);
                }
                return Ok(InventoryList);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }



        [HttpPost]
        [Route("AddInventory")]
        public async Task<ActionResult> AddInventoryAsync(Inventory cvm)
        {
            var Inventory = await _Repository.GetInventoryItemAsync(cvm.ItemName);
            try
            {
                if (Inventory == null)
                {
                    Inventory = new Inventory
                    {
                        ItemName = cvm.ItemName,
                        QuantityOnHand = cvm.QuantityOnHand,
                        LastUpdated = cvm.LastUpdated
                    };
                    using (var contextmodel = new CoreDbContext())
                    {

                        contextmodel.Add(Inventory);
                        contextmodel.SaveChanges();

                    }
                }
                else
                {
                    return StatusCode(StatusCodes.Status403Forbidden, "Inventory item already exists.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message.ToString());
            }

            return Ok();
        }


        [HttpPut]
        [Route("UpdateInventory")]
        public async Task<ActionResult> UpdateInventoryAsync(int id, Inventory cvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Inventory = await _Repository.GetInventoryItemAsync(cvm.ItemName);
            if (Inventory == null)
            {
                using (var contextmodel = new CoreDbContext())
                {

                    var existingInventory = contextmodel.Inventory.Where(c => c.InventoryId == id).FirstOrDefault<Inventory>();

                    if (existingInventory != null)
                    {
                        existingInventory.InventoryId = id;
                        existingInventory.ItemName = cvm.ItemName;
                        existingInventory.QuantityOnHand = cvm.QuantityOnHand;
                        existingInventory.LastUpdated = cvm.LastUpdated;

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
            }
            else
            {
                return StatusCode(StatusCodes.Status403Forbidden, "Item already exists.");
            }

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
        [HttpDelete]
        [Route("DeleteInventory")]
        public ActionResult DeleteInventory(int id, Inventory cvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingInventory = contextmodel.Inventory.Where(c => c.InventoryId == id).FirstOrDefault<Inventory>();

                    if (existingInventory != null)

                    {
                        if (existingInventory == null) return NotFound();

                        contextmodel.Inventory.Remove(existingInventory);
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
        [HttpDelete]
        [Route("DeleteInventory2")]
        public async Task<IActionResult> DeleteInventory2(string ItemName)
        {
            try
            {
                var existing = await _Repository.GetInventoryItemAsync(ItemName);

                if (existing == null) return NotFound();

                _Repository.Delete(existing);

                if (await _Repository.SaveChangesAsync())
                {
                    return StatusCode(StatusCodes.Status200OK, "Item deleted");
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Item deleted");
        }
        [HttpPost]
        [Route("DeleteItemPost")]
        public ActionResult DeleteItemPost(Inventory cvm)

        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existingHost = contextmodel.Inventory.Where(c => c.InventoryId == cvm.InventoryId).FirstOrDefault<Inventory>();

                    if (existingHost != null)

                    {

                        if (existingHost == null) return NotFound();


                        contextmodel.Inventory.Remove(existingHost);
                        contextmodel.SaveChanges();


                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Item deleted");

        }




        [HttpGet]
        [Route("GetInventoryReport")]
        public object GetInventoryReport()
        {
            try
            {
                List<InventoryReportVM> reportlist =
                     (from i in _CoreDbContext.Inventory.ToList()

                      join sp in _CoreDbContext.SupplierPurchase.ToList()
                      on i.InventoryId equals sp.InventoryId
                    
                      select new InventoryReportVM
                      {
                          QuantityOnHand = i.QuantityOnHand,
                          QuantityPurchased = sp.QuantityPurchased,
                          Price = sp.Price,
                          ItemName = i.ItemName,
                          total = sp.Price * sp.QuantityPurchased,
                          actualqty = sp.QuantityPurchased - i.QuantityOnHand


                      }).ToList();

                return reportlist;


            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        [HttpGet]
        [Route("GetTopSuppliers")]
        public object GetTopSuppliers()
        {
            try
            {
                List<Supplierreport> topSuppliers =
                     (
                      from p in _CoreDbContext.SupplierPurchase.ToList()
                      join s in _CoreDbContext.Supplier.ToList()
                      on p.SupplierId equals s.SupplierId
                      group p by p.Supplier.SupplierName into grouped
                      select new Supplierreport
                      {

                          Count = (int)grouped.Count(),

                          SupplierName = _CoreDbContext.Supplier
                       .Where(y => y.SupplierId == grouped.Select(z => z.Supplier.SupplierId)
                       .FirstOrDefault())
                       .FirstOrDefault().SupplierName,

                          SupplierPhoneNumber = _CoreDbContext.Supplier.Where(y => y.SupplierId == grouped.Select(z => z.Supplier.SupplierId)
                       .FirstOrDefault())
                       .FirstOrDefault().SupplierPhoneNumber,

                          Price = _CoreDbContext.SupplierPurchase.Where(y => y.SupplierId == grouped.Select(z => z.Supplier.SupplierId)
                       .FirstOrDefault())
                       .FirstOrDefault().Price,

                          QuantityPurchased = _CoreDbContext.SupplierPurchase.Where(y => y.SupplierId == grouped.Select(z => z.Supplier.SupplierId)
                       .FirstOrDefault())
                       .FirstOrDefault().QuantityPurchased,

                          TotalCost = _CoreDbContext.SupplierPurchase.Where(y => y.SupplierId == grouped.Select(z => z.Supplier.SupplierId)
                       .FirstOrDefault())
                       .FirstOrDefault().TotalCost,

                      }).OrderByDescending(x => x.Count).ToList();

                return Ok(topSuppliers);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }

        //////not complete
        //[HttpGet]
        //[Route("GetInventoryCalculations")]
        //public object GetInventoryCalculations()
        //{
        //    try
        //    {
        //        List<Inventoryreport> reportlist =
        //             (from p in _CoreDbContext.SupplierPurchase.ToList()
        //              join i in _CoreDbContext.Inventory.ToList()
        //              on p.InventoryId equals i.InventoryId
        //              select new Inventoryreport
        //              {
        //                  ItemName = i.ItemName,
        //                  Price = p.Price,
        //                  QuantityPurchased = p.QuantityPurchased,
        //                  QuantityOnHand = i.QuantityOnHand,
        //                  ActualQty = (int?)(p.QuantityPurchased - i.QuantityOnHand),

        //              }).ToList();
        //        return Ok(reportlist);


        //    }
        //    catch (Exception e)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
        //    }
        //}
        //[HttpGet]
        //[Route("GetInventoryReport")]
        //public object GetInventoryReport()
        //{
        //    try
        //    {
        //        List<Inventoryreport> Inventoryreport = (
        //            from w in _CoreDbContext.WriteOffInventory.ToList()
        //            join i in _CoreDbContext.Inventory.ToList()
        //            on w.InventoryId equals i.InventoryId
        //            join si in _CoreDbContext.SupplierInventory.ToList()
        //            on i.InventoryId equals si.InventoryId
        //            join sp in _CoreDbContext.SupplierPurchase.ToList()
        //            on si.SupplierPurchaseId equals sp.SupplierPurchaseId
        //            select new Inventoryreport
        //            {
        //                ItemName = i.ItemName,
        //                QuantityOnHand = i.QuantityOnHand,
        //                InventoryItemPrice = si.InventoryItemPrice,
        //                QuantityPurchased = si.QuantityPurchased,
        //                WriteOffQty = w.WriteOffQty,
        //                TotalCostCalculated = si.QuantityPurchased * si.InventoryItemPrice,
        //                ActualInventoryCalculated = si.QuantityPurchased - w.WriteOffQty
        //            }
        //            ).ToList();
        //        return Inventoryreport;
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
        //    }


        //}
    }
}

