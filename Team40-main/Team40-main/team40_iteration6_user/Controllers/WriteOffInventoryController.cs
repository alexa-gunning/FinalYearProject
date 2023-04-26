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
    [AuditApi(EventTypeName = "{controller}/{action}")]
    [ApiController]
    public class WriteOffInventoryController : Controller
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public WriteOffInventoryController(IRepository Repository)
        {
            _Repository = Repository;
        }

        //[HttpGet]
        //[Route("GetAllWriteOffs")]
        //public async Task<ActionResult<dynamic>> GetAllWriteOffs()
        //{
        //    try
        //    {
        //        //List<dynamic> productdashboard = new List<dynamic>();

        //        //var results = await _repository.GetProductsDashboardReportAsync();

        //        List<WriteOffInventory> dbWriteOffInventories = _CoreDbContext.WriteOffInventory.ToList();
        //        List<WriteOffInventory> WriteOffList = new List<WriteOffInventory>();

        //        //List<WriteOffReason> dbWriteOffReasons = _CoreDbContext.WriteOffReason.ToList();
        //        //List<WriteOffReason> writeOffReasonList = new List<WriteOffReason>();

        //        /*foreach (var b in dbWriteOffReasons)
        //        {
        //            WriteOffReason oWriteOffReason = new WriteOffReason();

        //            oWriteOffReason.WriteOffReasonId = b.WriteOffReasonId;
        //            oWriteOffReason.WriteOffReasonDescription = b.WriteOffReasonDescription;

        //            writeOffReasonList.Add(oWriteOffReason);
        //        }*/

        //        foreach (var p in dbWriteOffInventories)
        //        {
        //            WriteOffInventory oWriteOff = new WriteOffInventory();

        //            oWriteOff.WriteOffId = p.WriteOffId;
        //            oWriteOff.InventoryId = p.InventoryId;
        //            oWriteOff.WriteOffReasonId = p.WriteOffReasonId;
        //            oWriteOff.AdminId = p.AdminId;
        //            oWriteOff.WriteOffDate = p.WriteOffDate;
        //            oWriteOff.WriteOffQty = p.WriteOffQty;

        //            WriteOffList.Add(oWriteOff);
        //        }

        //        return Ok(WriteOffList);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
        //    }
        //}

        //[HttpGet]
        //[Route("GetWriteOffById")]
        //public ActionResult GetWriteOffById(int id)
        //{
        //    try
        //    {
        //        List<WriteOffInventory> dbWriteOff = _CoreDbContext.WriteOffInventory.ToList();
        //        List<WriteOffInventory> WriteOffList = new List<WriteOffInventory>();

        //        foreach (var b in dbWriteOff)
        //        {
        //            WriteOffInventory oWriteOff = new WriteOffInventory();

        //            if (id == b.WriteOffId)
        //            {
        //                oWriteOff.WriteOffId = b.WriteOffId;
        //                oWriteOff.InventoryId = b.InventoryId;
        //                oWriteOff.WriteOffReasonId = b.WriteOffReasonId;
        //                oWriteOff.AdminId = b.AdminId;
        //                oWriteOff.WriteOffDate = b.WriteOffDate;
        //                oWriteOff.WriteOffQty = b.WriteOffQty;

        //                WriteOffList.Add(oWriteOff);
        //            }
        //            else
        //            {

        //            }
        //        }

        //        if (WriteOffList.Count == 0)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return Ok(WriteOffList);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
        //    }
        //}


        //[HttpPost]
        //[Route("CreateWriteOff")]
        //public ActionResult AddWriteOffInventory(WriteOffInventory wvm)
        //{
        //    using (var contextmodel = new CoreDbContext())
        //    {
        //        var maxId = _CoreDbContext.WriteOffInventory.Max(m => m.WriteOffId);

        //        var writeoffinventory = new WriteOffInventory
        //        {
        //            WriteOffId = maxId+1,
        //            InventoryId = wvm.InventoryId,
        //            WriteOffReasonId = wvm.WriteOffReasonId,
        //            AdminId = wvm.AdminId,
        //            WriteOffDate = wvm.WriteOffDate,
        //            WriteOffQty = wvm.WriteOffQty
        //        };

        //        try
        //        {
        //            contextmodel.Add(writeoffinventory);
        //            contextmodel.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
        //        }
        //        return Ok("Record saved in database");
        //    }
        //}
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
                    if (existingInventory.QuantityOnHand == null)
                    {
                        var existing = existingInventory.QuantityOnHand = 0;
                        decimal? qty = existing - quantity;
                        existingInventory.InventoryId = id;
                        existingInventory.ItemName = existingInventory.ItemName;
                        existingInventory.QuantityOnHand = qty;
                        existingInventory.LastUpdated = DateTime.Now;
                    }
                    else
                    {
                        decimal? qty = existingInventory.QuantityOnHand - quantity;
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
        [Route("UpdateInventoryWithDelete")]
        public async Task<ActionResult> UpdateInventoryWithDeleteAsync(int id, decimal? quantity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Inventory = GetInventoryByID(id);
         
            using (var contextmodel = new CoreDbContext())
            {

                var existingInventory = contextmodel.Inventory.Where(c => c.InventoryId == id).FirstOrDefault<Inventory>();

                if (existingInventory != null)
                {
                    if (existingInventory.QuantityOnHand == null)
                    {
                        var existing = existingInventory.QuantityOnHand = 0;
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
                        //if (quantitynow > quantityupdated)
                        //{
                            //decimal? qty = existingInventory.QuantityOnHand - quantityupdated + quantitynow;
                            //existingInventory.InventoryId = id;
                            //existingInventory.ItemName = existingInventory.ItemName;
                            //existingInventory.QuantityOnHand = qty;
                            //existingInventory.LastUpdated = DateTime.Now;
                        //}
                        //else
                        //{
                        //    decimal? qty = existingInventory.QuantityOnHand - quantityupdated + quantitynow;
                        //    existingInventory.InventoryId = id;
                        //    existingInventory.ItemName = existingInventory.ItemName;
                        //    existingInventory.QuantityOnHand = qty;
                        //    existingInventory.LastUpdated = DateTime.Now;
                        //}
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
        [Route("UpdateInventoryWithDeleteSP")]
        public async Task<ActionResult> UpdateInventoryWithDeleteAsyncSP(int id, decimal? quantity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Inventory = GetInventoryByID(id);

            using (var contextmodel = new CoreDbContext())
            {

                var existingInventory = contextmodel.Inventory.Where(c => c.InventoryId == id).FirstOrDefault<Inventory>();

                if (existingInventory != null)
                {
                    if (existingInventory.QuantityOnHand == null)
                    {
                        var existing = existingInventory.QuantityOnHand = 0;
                        decimal? qty = existing-  quantity;
                        existingInventory.InventoryId = id;
                        existingInventory.ItemName = existingInventory.ItemName;
                        existingInventory.QuantityOnHand = qty;
                        existingInventory.LastUpdated = DateTime.Now;

                    }
                    else
                    {
                        decimal? qty = existingInventory.QuantityOnHand - quantity;
                        existingInventory.InventoryId = id;
                        existingInventory.ItemName = existingInventory.ItemName;
                        existingInventory.QuantityOnHand = qty;
                        existingInventory.LastUpdated = DateTime.Now;
                        //if (quantitynow > quantityupdated)
                        //{
                        //decimal? qty = existingInventory.QuantityOnHand - quantityupdated + quantitynow;
                        //existingInventory.InventoryId = id;
                        //existingInventory.ItemName = existingInventory.ItemName;
                        //existingInventory.QuantityOnHand = qty;
                        //existingInventory.LastUpdated = DateTime.Now;
                        //}
                        //else
                        //{
                        //    decimal? qty = existingInventory.QuantityOnHand - quantityupdated + quantitynow;
                        //    existingInventory.InventoryId = id;
                        //    existingInventory.ItemName = existingInventory.ItemName;
                        //    existingInventory.QuantityOnHand = qty;
                        //    existingInventory.LastUpdated = DateTime.Now;
                        //}
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
        [HttpPost]
        [Route("DeleteWriteOffPut")]
        public ActionResult DeleteWriteOffPut(WriteOffInventory wvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {
                    var exisitingWriteOff = contextmodel.WriteOffInventory.Where(c => c.WriteOffId == wvm.WriteOffId).FirstOrDefault<WriteOffInventory>();

                    if (exisitingWriteOff != null)

                    {
                        if (exisitingWriteOff == null) return NotFound();

                        contextmodel.WriteOffInventory.Remove(exisitingWriteOff);
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
            return StatusCode(StatusCodes.Status200OK, "Srocktaketotal deleted");

        }
        [HttpPut]
        [Route("UpdateInventoryWithUpdate")]
        public async Task<ActionResult> UpdateInventoryWithUpdateAsync(int id, decimal? quantitynow, decimal? quantityupdated)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var Inventory = GetInventoryByID(id);

            using (var contextmodel = new CoreDbContext())
            {

                var existingInventory = contextmodel.Inventory.Where(c => c.InventoryId == id).FirstOrDefault<Inventory>();

                if (existingInventory != null)
                {
                    if (existingInventory.QuantityOnHand == null)
                    {
                        //var existing = existingInventory.QuantityOnHand = 0;
                        //decimal? qty = existing - quantity;
                        //existingInventory.InventoryId = id;
                        //existingInventory.ItemName = existingInventory.ItemName;
                        //existingInventory.QuantityOnHand = qty;
                        //existingInventory.LastUpdated = DateTime.Now;
                        return Ok("Cannot write off");
                    }
                    else
                    {
                        //decimal? qty = existingInventory.QuantityOnHand - quantity;
                        //existingInventory.InventoryId = id;
                        //existingInventory.ItemName = existingInventory.ItemName;
                        //existingInventory.QuantityOnHand = qty;
                        //existingInventory.LastUpdated = DateTime.Now;
                        //if (quantitynow > quantityupdated)
                        //{
                        decimal? qty = existingInventory.QuantityOnHand - quantityupdated + quantitynow;
                        existingInventory.InventoryId = id;
                        existingInventory.ItemName = existingInventory.ItemName;
                        existingInventory.QuantityOnHand = qty;
                        existingInventory.LastUpdated = DateTime.Now;
                        //}
                        //else
                        //{
                        //    decimal? qty = existingInventory.QuantityOnHand - quantityupdated + quantitynow;
                        //    existingInventory.InventoryId = id;
                        //    existingInventory.ItemName = existingInventory.ItemName;
                        //    existingInventory.QuantityOnHand = qty;
                        //    existingInventory.LastUpdated = DateTime.Now;
                        //}
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
        [HttpGet]
        [Route("GetAllWriteOffs")]
        public async Task<ActionResult<dynamic>> GetAllWriteOffs()
        {
            try
            {
                //List<dynamic> productdashboard = new List<dynamic>();

                //var results = await _repository.GetProductsDashboardReportAsync();

                List<WriteOffInventory> dbWriteOffInventories = _CoreDbContext.WriteOffInventory.ToList();
                List<WriteOffInventory> WriteOffList = new List<WriteOffInventory>();

                //List<WriteOffReason> dbWriteOffReasons = _CoreDbContext.WriteOffReason.ToList();
                //List<WriteOffReason> writeOffReasonList = new List<WriteOffReason>();

                /*foreach (var b in dbWriteOffReasons)
                {
                    WriteOffReason oWriteOffReason = new WriteOffReason();

                    oWriteOffReason.WriteOffReasonId = b.WriteOffReasonId;
                    oWriteOffReason.WriteOffReasonDescription = b.WriteOffReasonDescription;

                    writeOffReasonList.Add(oWriteOffReason);
                }*/

                foreach (var p in dbWriteOffInventories)
                {
                    WriteOffInventory oWriteOff = new WriteOffInventory();

                    oWriteOff.WriteOffId = p.WriteOffId;
                    oWriteOff.InventoryId = p.InventoryId;
                    oWriteOff.WriteOffReasonId = p.WriteOffReasonId;
                    oWriteOff.AdminId = p.AdminId;
                    oWriteOff.WriteOffDate = p.WriteOffDate;
                    oWriteOff.WriteOffQty = p.WriteOffQty;
                    oWriteOff.Name = p.Name;


                    WriteOffList.Add(oWriteOff);
                }

                return Ok(WriteOffList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }

        [HttpGet]
        [Route("GetWriteOffById")]
        public ActionResult GetWriteOffById(int id)
        {
            try
            {
                List<WriteOffInventory> dbWriteOff = _CoreDbContext.WriteOffInventory.ToList();
                List<WriteOffInventory> WriteOffList = new List<WriteOffInventory>();

                foreach (var b in dbWriteOff)
                {
                    WriteOffInventory oWriteOff = new WriteOffInventory();

                    if (id == b.WriteOffId)
                    {
                        oWriteOff.WriteOffId = b.WriteOffId;
                        oWriteOff.InventoryId = b.InventoryId;
                        oWriteOff.WriteOffReasonId = b.WriteOffReasonId;
                        oWriteOff.AdminId = b.AdminId;
                        oWriteOff.WriteOffDate = b.WriteOffDate;
                        oWriteOff.WriteOffQty = b.WriteOffQty;
                        oWriteOff.Name = b.Name;

                        WriteOffList.Add(oWriteOff);
                    }
                    else
                    {

                    }
                }

                if (WriteOffList.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(WriteOffList);
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }


        [HttpPost]
        [Route("CreateWriteOff")]
        public ActionResult AddWriteOffInventory(WriteOffInventory wvm)
        {
            using (var contextmodel = new CoreDbContext())
            {
                var maxId = _CoreDbContext.WriteOffInventory.Max(m => m.WriteOffId) + 1;
                var writeoffinventory = new WriteOffInventory
                {
                    WriteOffId = maxId,
                    InventoryId = wvm.InventoryId,
                    WriteOffReasonId = wvm.WriteOffReasonId,
                    AdminId = wvm.AdminId,
                    WriteOffDate = DateTime.Now,
                    WriteOffQty = wvm.WriteOffQty,
                    Name = wvm.Name,
                };

                try
                {
                    contextmodel.Add(writeoffinventory);
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
        [Route("UpdateWriteOff")]
        public ActionResult UpdateWriteOffInventory(int id, WriteOffInventory wvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (var contextmodel = new CoreDbContext())
            {
                var existingWriteOff = contextmodel.WriteOffInventory.Where(b => b.WriteOffId == id).FirstOrDefault<WriteOffInventory>();

                if (existingWriteOff != null)
                {
                    existingWriteOff.WriteOffId = id;
                    existingWriteOff.InventoryId = wvm.InventoryId;
                    existingWriteOff.WriteOffReasonId = wvm.WriteOffReasonId;
                    existingWriteOff.AdminId = wvm.AdminId;
                    existingWriteOff.WriteOffDate =DateTime.Now;
                    existingWriteOff.WriteOffQty = wvm.WriteOffQty;
                    existingWriteOff.Name = wvm.Name;

                    try
                    {
                        contextmodel.WriteOffInventory.Update(existingWriteOff);
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

        [HttpDelete]
        [Route("DeleteWriteOff")]
        public ActionResult DeleteWriteOff(int id, WriteOffInventory wvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {
                    var existingWriteOff = contextmodel.WriteOffInventory.Where(c => c.WriteOffId == id).FirstOrDefault<WriteOffInventory>();

                    if (existingWriteOff != null)

                    {
                        if (existingWriteOff == null) return NotFound();

                        contextmodel.WriteOffInventory.Remove(existingWriteOff);
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
            return StatusCode(StatusCodes.Status200OK, "Write-Off Slot deleted");
        }


        //===================================================Code by Tokollo====================================================///

        [HttpGet]
        [Route("GetWrittenOffItems")]
        public object GetWrittenOffItems()
        {
            List<WriteOffInventoryHistoryVM> writeOffItems = (
            from i in _CoreDbContext.Inventory.ToList()
            join w in _CoreDbContext.WriteOffInventory.ToList()
            on i.InventoryId equals w.InventoryId
            join r in _CoreDbContext.WriteOffReason.ToList()
            on w.WriteOffReasonId equals r.WriteOffReasonId


            select new WriteOffInventoryHistoryVM
            {
                WriteOffDate = w.WriteOffDate,
                ItemName = i.ItemName,
                WriteOffReasonDescription = r.WriteOffReasonDescription,
                WriteOffQty = w.WriteOffQty,
                AdminName = "1",
                Name= w.Name,
                WriteOffId = w.WriteOffId,
                InventoryId = i.InventoryId

            }
            ).ToList();

            return writeOffItems;
        }
    }


    /*
     * try
            {
                List<Product> dbProduct = _appDbContext.Products.ToList();
                List<ProductVM> ProductList = new List<ProductVM>();

                //List<ProductType> dbProductType = _appDbContext.ProductTypes.ToList();
                //List<Brand> dbBrand = _appDbContext.Brands.ToList();
                foreach (var p in dbProduct)
                {
                    ProductVM oProductVM = new ProductVM();
                    Product oProduct = new Product();
                    //Brand oBrand = new Brand();
                    //ProductType oProductType = new ProductType();

                    string BrandOne = "Nike";
                    string BrandTwo = "Adidas";
                    string BrandThree = "Levi Strauss & Co.";

                    string TypeOne = "Footwear";
                    string TypeTwo = "Clothing";
                    string TypeThree = "Accessories";

                    oProductVM.ProductId = p.ProductId;
                    oProductVM.ProductName = p.Name;
                    oProductVM.BrandId = p.BrandId;
                    if (oProductVM.BrandId == 1) {
                        oProductVM.BrandName = BrandOne;
                    } else if (oProductVM.BrandId == 2) {
                        oProductVM.BrandName = BrandTwo;
                    } else if (oProductVM.BrandId == 3) {
                        oProductVM.BrandName = BrandThree;
                    } else { }

                    oProductVM.ProductTypeId = p.ProductTypeId;

                    if (oProductVM.ProductTypeId == 1) {
                        oProductVM.ProductTypeName = TypeOne;
                    } else if (oProductVM.ProductTypeId == 2) {
                        oProductVM.ProductTypeName = TypeTwo;
                    } else if (oProductVM.ProductTypeId == 3) {
                        oProductVM.ProductTypeName = TypeThree;
                    } else { }

                    oProductVM.ProductPrice = p.Price;
                    oProductVM.ProductDescription = p.Description;
                  
                    ProductList.Add(oProductVM);
                }
                return Ok(ProductList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
     */
    //    [HttpPut]
    //    [Route("UpdateWriteOff")]
    //    public ActionResult UpdateWriteOffInventory(int id, WriteOffInventory wvm)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest();
    //        }

    //        using (var contextmodel = new CoreDbContext())
    //        {
    //            var existingWriteOff = contextmodel.WriteOffInventory.Where(b => b.WriteOffId == id).FirstOrDefault<WriteOffInventory>();

    //            if (existingWriteOff != null)
    //            {
    //                existingWriteOff.WriteOffId = id;
    //                existingWriteOff.InventoryId = wvm.InventoryId;
    //                existingWriteOff.WriteOffReasonId = wvm.WriteOffReasonId;
    //                existingWriteOff.AdminId = wvm.AdminId;
    //                existingWriteOff.WriteOffDate = wvm.WriteOffDate;
    //                existingWriteOff.WriteOffQty = wvm.WriteOffQty;

    //                try
    //                {
    //                    contextmodel.WriteOffInventory.Update(existingWriteOff);
    //                    contextmodel.SaveChanges();
    //                }
    //                catch (Exception e)
    //                {
    //                    return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
    //                }
    //            }
    //            else
    //            {
    //                return NotFound();
    //            }
    //        }
    //        return StatusCode(StatusCodes.Status200OK, "Booking updated");
    //    }

    //    [HttpDelete]
    //    [Route("DeleteWriteOff")]
    //    public ActionResult DeleteWriteOff(int id, WriteOffInventory wvm)
    //    {
    //        try
    //        {
    //            if (!ModelState.IsValid)
    //            {
    //                return BadRequest();
    //            }

    //            using (var contextmodel = new CoreDbContext())
    //            {
    //                var existingWriteOff = contextmodel.WriteOffInventory.Where(c => c.WriteOffId == id).FirstOrDefault<WriteOffInventory>();

    //                if (existingWriteOff != null)

    //                {
    //                    if (existingWriteOff == null) return NotFound();

    //                    contextmodel.WriteOffInventory.Remove(existingWriteOff);
    //                    contextmodel.SaveChanges();
    //                }
    //                else
    //                {
    //                    return NotFound();
    //                }
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
    //        }
    //        return StatusCode(StatusCodes.Status200OK, "Write-Off Slot deleted");
    //    }


    //    //===================================================Code by Tokollo====================================================///

    //    [HttpGet]
    //    [Route("GetWrittenOffItems")]
    //    public object GetWrittenOffItems()
    //    {
    //        List<WriteOffInventoryHistoryVM> writeOffItems = (
    //        from i in _CoreDbContext.Inventory.ToList()
    //        join w in _CoreDbContext.WriteOffInventory.ToList()
    //        on i.InventoryId equals w.InventoryId
    //        join r in _CoreDbContext.WriteOffReason.ToList()
    //        on w.WriteOffReasonId equals r.WriteOffReasonId


    //        select new WriteOffInventoryHistoryVM
    //        {
    //            WriteOffDate = w.WriteOffDate,
    //            ItemName = i.ItemName,
    //            WriteOffReasonDescription = r.WriteOffReasonDescription,
    //            WriteOffQty = w.WriteOffQty,
    //            AdminName = "1"


    //        }
    //        ).ToList();

    //        return writeOffItems;
    //    }
    //}

    ///*
    // * try
    //        {
    //            List<Product> dbProduct = _appDbContext.Products.ToList();
    //            List<ProductVM> ProductList = new List<ProductVM>();

    //            //List<ProductType> dbProductType = _appDbContext.ProductTypes.ToList();
    //            //List<Brand> dbBrand = _appDbContext.Brands.ToList();
    //            foreach (var p in dbProduct)
    //            {
    //                ProductVM oProductVM = new ProductVM();
    //                Product oProduct = new Product();
    //                //Brand oBrand = new Brand();
    //                //ProductType oProductType = new ProductType();

    //                string BrandOne = "Nike";
    //                string BrandTwo = "Adidas";
    //                string BrandThree = "Levi Strauss & Co.";

    //                string TypeOne = "Footwear";
    //                string TypeTwo = "Clothing";
    //                string TypeThree = "Accessories";

    //                oProductVM.ProductId = p.ProductId;
    //                oProductVM.ProductName = p.Name;
    //                oProductVM.BrandId = p.BrandId;
    //                if (oProductVM.BrandId == 1) {
    //                    oProductVM.BrandName = BrandOne;
    //                } else if (oProductVM.BrandId == 2) {
    //                    oProductVM.BrandName = BrandTwo;
    //                } else if (oProductVM.BrandId == 3) {
    //                    oProductVM.BrandName = BrandThree;
    //                } else { }

    //                oProductVM.ProductTypeId = p.ProductTypeId;

    //                if (oProductVM.ProductTypeId == 1) {
    //                    oProductVM.ProductTypeName = TypeOne;
    //                } else if (oProductVM.ProductTypeId == 2) {
    //                    oProductVM.ProductTypeName = TypeTwo;
    //                } else if (oProductVM.ProductTypeId == 3) {
    //                    oProductVM.ProductTypeName = TypeThree;
    //                } else { }

    //                oProductVM.ProductPrice = p.Price;
    //                oProductVM.ProductDescription = p.Description;

    //                ProductList.Add(oProductVM);
    //            }
    //            return Ok(ProductList);
    //        }
    //        catch (Exception)
    //        {
    //            return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
    //        }

}
