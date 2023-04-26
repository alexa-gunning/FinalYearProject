using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
//using System.Dynamic;
using team40_iteration6_user.Models;
using team40_iteration6_user.Team40;
using team40_iteration6_user.ViewModel;
using Audit.WebApi;

namespace team40_iteration6_user.Controllers
{
    [Route("api/[controller]")]
    [AuditApi(EventTypeName = "{controller}/{action}")]
    [ApiController]
    public class WriteOffReasonController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public WriteOffReasonController(IRepository Repository)
        {
            _Repository = Repository;
        }

        [HttpGet]
        [Route("GetWriteOffReason_Multi")]
        public object GetWriteOffReasonMulti()
        {
            List<WriteOffReasonsMultiVM> writeoffinventory = (
                from r in _CoreDbContext.WriteOffInventory.ToList()
                join s in _CoreDbContext.WriteOffReason.ToList()
                on r.WriteOffReasonId equals s.WriteOffReasonId
                join t in _CoreDbContext.Inventory.ToList()
                on r.InventoryId equals t.InventoryId
                select new WriteOffReasonsMultiVM
                {
                    WriteOffReasonDescription = s.WriteOffReasonDescription,

                    ItemName = t.ItemName,
                    QuantityOnHand = (int)t.QuantityOnHand,
                    LastUpdated = t.LastUpdated,

                    WriteOffDate = r.WriteOffDate,
                    WriteOffQty = (int)r.WriteOffQty
                }
                ).ToList();
            return writeoffinventory;
        }

        /*[HttpGet]
        [Route("GetAllWriteOffReasons")]
        public async Task<ActionResult> GetAllWriteOffReasons()
        {
            try
            {
                //List<dynamic> productdashboard = new List<dynamic>();

                //var results = await _repository.GetProductsDashboardReportAsync();

                List<WriteOffReason> dbWriteOffInventories = _CoreDbContext.WriteOffReason.ToList();
                List<WriteOffReason> WriteOffList = new List<WriteOffReason>();

                //List<WriteOffReason> dbWriteOffReasons = _CoreDbContext.WriteOffReason.ToList();
                //List<WriteOffReason> writeOffReasonList = new List<WriteOffReason>();

                /*foreach (var b in dbWriteOffReasons)
                {
                    WriteOffReason oWriteOffReason = new WriteOffReason();

                    oWriteOffReason.WriteOffReasonId = b.WriteOffReasonId;
                    oWriteOffReason.WriteOffReasonDescription = b.WriteOffReasonDescription;

                    writeOffReasonList.Add(oWriteOffReason);
                }

                foreach (var p in dbWriteOffInventories)
                {
                    WriteOffReason oWriteOff = new WriteOffReason();

                    oWriteOff.WriteOffReasonId = p.WriteOffReasonId;
                    oWriteOff.WriteOffReasonDescription = p.WriteOffReasonDescription;

                    WriteOffList.Add(oWriteOff);
                }

                return Ok(WriteOffList);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }*/

        /*[HttpGet]
        [Route("GetWriteOffReasons")]
        public List<dynamic> GetWriteOffReasons1()
        {
            var writeoffreasons = _CoreDbContext.WriteOffInventory.Include(x => x.WriteOffReason).Include(x => x.WriteOffReason.Inventory).Include(x => x.WriteOffReason.WriteOffInventory).ToList();
            return GetDynamicWriteOffReasonsHelper1(writeoffreasons);
        }
        public List<dynamic> GetDynamicWriteOffReasonsHelper1(List<WriteOffInventory> writeoffreasons)
        {
            var dynamicWriteOffReasons = new List<dynamic>();

            var writeOffReasonGroup = writeoffreasons.GroupBy(x => new
            {
                x.WriteOffReasonId,
                x.WriteOffReasons.WriteOffReasonDescription,
                x.WriteOffReasons.
            });

            foreach (var writeoffreason in writeoffreasons)
            {
                dynamic dynamicWriteOffReason = new ExpandoObject();
                dynamicWriteOffReason.WriteOffReasonId = writeoffreason.WriteOffReasonId;
                dynamicWriteOffReason.WriteOffReasonDescription = writeoffreason.WriteOffReasonDescription;
                dynamicWriteOffReason.InventoryId = writeoffreason.InventoryId;
                dynamicWriteOffReason.WriteOffReasonId = writeoffreason.WriteOffReasonId;
                dynamicWriteOffReason.AdminId = writeoffreason.WriteOffReasonId;
                dynamicWriteOffReason.WriteOffDate = writeoffreason.WriteOffDate;
                dynamicWriteOffReason.WriteOffQty = writeoffreason.WriteOffQty;

                dynamicWriteOffReasons.Add(dynamicWriteOffReason);
            }

            foreach ()
            {
                List<dynamic> dayList = new List<dynamic>();
                foreach (var day in supplierH.GroupBy(x => new ))
            }

            /*List<WriteOffReason> writeOffreasons = (
                from r in _CoreDbContext.WriteOffReason.ToList()
                join s in _CoreDbContext.WriteOffInventory.ToList()
                on r.WriteOffReasonId equals s.WriteOffReasonId
                join t in _CoreDbContext.Inventory.ToList()
                on s.InventoryId equals t.InventoryId
                select new WriteOffReason
                {
                    WriteOffReasonId = r.WriteOffReasonId,
                    WriteOffReasonDescription = r.WriteOffReasonDescription,
                    WriteOffId = s.WriteOffId,
                    InventoryId = s.InventoryId,
                    AdminId = s.AdminId,

                    ItemName = t.ItemName,
                    QuantityOnHand = t.QuantityOnHand,
                    LastUpdated = t.LastUpdated,


                    TypeDescription = t.Description,
                    StatusDescription = s.Description,
                    Percentage = t.Percentage,
                    DiscountDescription = r.DiscountDescription
                }
                ).ToList();

            return dynamicWriteOffReasons;
        }*/

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


        /*[HttpPost]
        [Route("AddWriteOffReason")]
        public ActionResult AddWriteOffReason(WriteOffReason wvm)
        {
            using (var contextmodel = new CoreDbContext())
            {
                var WriteOffReason = new WriteOffReason
                {

                    WriteOffReasonId = wvm.WriteOffReasonId,
                    WriteOffReasonDescription = wvm.WriteOffReasonDescription,
                };

                try
                {
                    contextmodel.Add(WriteOffReason);
                    contextmodel.SaveChanges();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
                }
                return Ok("Record saved in database");
            }
        }*/

        [HttpPost]
        [Route("AddWriteOffReason_Multi")]
        // [ServiceFilter(typeof(AuditFilterAttribute))]
        public ActionResult addWriteOffReasonMulti(WriteOffReasonVM writeoffreason)
        {
            try
            {
                //check if VAT number already exists
                /*var check = _CoreDbContext.WriteOffReason.Where(zz => zz.SupplierVatNumber == supplier.SupplierVatNumber || zz.SupplierContactNumber == supplier.SupplierContactNumber).FirstOrDefault();

                if (check != null)
                {
                    return BadRequest();
                }*/
                /*else
                {*/

                int WriteOffReasonId = _CoreDbContext.WriteOffReason.Max(x => x.WriteOffReasonId);
                var newWriteOffReason = new WriteOffReason
                {
                    WriteOffReasonId = WriteOffReasonId + 1,
                    WriteOffReasonDescription = writeoffreason.WriteOffReasonDescription
                };

                _CoreDbContext.WriteOffReason.Add(newWriteOffReason);
                _CoreDbContext.SaveChanges();

                var writeoffinventoryToAdd = writeoffreason.writeoffinventories;
                for (int i = 0; i < writeoffinventoryToAdd.Count(); i++)
                {
                    int writeOffReasonId = (int)_CoreDbContext.WriteOffInventory.Max(x => x.WriteOffReasonId);
                    var newWriteOffInventory = new WriteOffInventory
                    {
                        //WriteOffId = WriteOffId + 1,
                        WriteOffId = writeoffinventoryToAdd[i].WriteOffId + 1,
                        InventoryId = writeoffinventoryToAdd[i].InventoryId + 1,
                        // InventoryId = InventoryId + 1,
                        // WriteOffReasonId = writeoffinventoryToAdd[i].WriteOffReasonId,
                        WriteOffReasonId = WriteOffReasonId + 1,
                        AdminId = writeoffinventoryToAdd[i].AdminId,
                        WriteOffDate = writeoffinventoryToAdd[i].WriteOffDate,
                        WriteOffQty = writeoffinventoryToAdd[i].WriteOffQty
                    };

                    _CoreDbContext.WriteOffInventory.Add(newWriteOffInventory);
                    _CoreDbContext.SaveChanges();
                }
                //}
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*[HttpPut]
        [Route("UpdateWriteOffReason")]
        public ActionResult UpdateWriteOffReason(int id, WriteOffReason wvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (var contextmodel = new CoreDbContext())
            {
                var existingWriteOff = contextmodel.WriteOffReason.Where(b => b.WriteOffReasonId == id).FirstOrDefault<WriteOffReason>();

                if (existingWriteOff != null)
                {
                    existingWriteOff.WriteOffReasonId = wvm.WriteOffReasonId;
                    existingWriteOff.WriteOffReasonDescription = wvm.WriteOffReasonDescription;

                    try
                    {
                        contextmodel.WriteOffReason.Update(existingWriteOff);
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
            return StatusCode(StatusCodes.Status200OK, "Booking updated");
        }*/

        [HttpPost]
        [Route("UpdateWriteOffReason_Multi")]
        public ActionResult updateWriteOffReasonMulti(WriteOffReasonVM uVM)
        {
            try
            {
                var writeooffReasonToUpdate = _CoreDbContext.WriteOffReason.Where(x => x.WriteOffReasonId == uVM.WriteOffReasonId).FirstOrDefault();

                writeooffReasonToUpdate.WriteOffReasonId = (int)uVM.WriteOffReasonId;
                writeooffReasonToUpdate.WriteOffReasonDescription = uVM.WriteOffReasonDescription;

                var writeoffinventoryToAdd = uVM.writeoffinventories;
                for (int i = 0; i < writeoffinventoryToAdd.Count(); i++)
                {
                    //int WriteOffId = _CoreDbContext.WriteOffInventory.Max(x => x.WriteOffId);
                    var newriteoffinventories = new WriteOffInventory
                    {
                        WriteOffId = writeoffinventoryToAdd[i].WriteOffId + 1,
                        InventoryId = writeoffinventoryToAdd[i].InventoryId + 1,
                        // InventoryId = InventoryId + 1,
                        // WriteOffReasonId = writeoffinventoryToAdd[i].WriteOffReasonId,
                        WriteOffReasonId = writeoffinventoryToAdd[i].WriteOffReasonId + 1,
                        AdminId = writeoffinventoryToAdd[i].AdminId,
                        WriteOffDate = writeoffinventoryToAdd[i].WriteOffDate,
                        WriteOffQty = writeoffinventoryToAdd[i].WriteOffQty
                    };

                    _CoreDbContext.WriteOffInventory.Add(newriteoffinventories);
                    _CoreDbContext.SaveChanges();
                }

                _CoreDbContext.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /*[HttpDelete]
        [Route("DeleteWriteOffReason")]
        public ActionResult DeleteWriteOffReason(int id, WriteOffReason wvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {
                    var existingWriteOff = contextmodel.WriteOffReason.Where(c => c.WriteOffReasonId == id).FirstOrDefault<WriteOffReason>();

                    if (existingWriteOff != null)

                    {
                        if (existingWriteOff == null) return NotFound();

                        contextmodel.WriteOffReason.Remove(existingWriteOff);
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
        }*/

        /*[HttpPost]
        [Route("DeleteReasonPost")]
        public ActionResult DeleteReasonPost(WriteOffReason cvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {

                    var existing = contextmodel.WriteOffReason.Where(c => c.WriteOffReasonId == cvm.WriteOffReasonId).FirstOrDefault<WriteOffReason>();

                    if (existing != null)

                    {
                        if (existing == null) return NotFound();
                        contextmodel.WriteOffReason.Remove(existing);
                        contextmodel.SaveChanges();
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

            return StatusCode(StatusCodes.Status200OK, "Write Off Reasons deleted");

        }*/

        //------------- DELETE PRODUCT ---------------------------------
        [HttpPost]
        [Route("DeleteWriteOffReason_Multi")]

        public ActionResult DeleteWriteOffReasonMulti(WriteOffReasonVM v)
        {
            try
            {
                /*var b = db.Product.Where(x => x.ProductId == v.ProductId).FirstOrDefault();
                var pp = db.ProductPrice.Where(x => x.ProductId == b.ProductId).FirstOrDefault();
                var bp = db.BranchProduct.Where(x => x.ProductId == b.ProductId).FirstOrDefault();
                var pc = db.ProductContent.Where(x => x.ProductContentId == b.ProductId).ToList();
                var productInProductContent = db.ProductContent.Where(x => x.ProductId == b.ProductId).ToList();
                var pr = db.ProductReview.Where(x => x.ProductId == b.ProductId).FirstOrDefault();*/

                var wr = _CoreDbContext.WriteOffReason.Where(x => x.WriteOffReasonId == v.WriteOffReasonId).FirstOrDefault();
                var wi = _CoreDbContext.WriteOffInventory.Where(x => x.WriteOffId == wr.WriteOffReasonId).ToList();
                var writeoffreasonInWriteOffInventory = _CoreDbContext.WriteOffInventory.Where(x => x.WriteOffReasonId == wr.WriteOffReasonId).ToList();


                if (wr.WriteOffInventory.Count == 0)
                {
                    if (wi != null)
                    {
                        for (int i = 0; i < wi.Count(); i++)
                        {
                            _CoreDbContext.Remove(wi[i]);
                            _CoreDbContext.SaveChanges();
                        }
                    }
                    if (writeoffreasonInWriteOffInventory != null)
                    {
                        for (int i = 0; i < writeoffreasonInWriteOffInventory.Count(); i++)
                        {
                            _CoreDbContext.Remove(writeoffreasonInWriteOffInventory[i]);

                            _CoreDbContext.SaveChanges();
                        }
                    }

                    _CoreDbContext.SaveChanges();
                    _CoreDbContext.WriteOffReason.Remove(wr);
                    _CoreDbContext.SaveChanges();
                    return Ok();
                }
                else
                {
                    return BadRequest("This product cannot be deleted just yet!");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        //===============================================Code by Tokollo Bapela========================================================//

        [HttpPost]
        [Route("AddInventoryWriteOffReason")]
        public ActionResult AddInventoryWriteOffReason(WriteOffReasonVM wvm)
        {
            using (var w = new CoreDbContext())
            {
                var writeoffreason = new WriteOffReason
                {
                    WriteOffReasonId = (int)wvm.WriteOffReasonId,
                    WriteOffReasonDescription = wvm.WriteOffReasonDescription,

                };
                try
                {
                    w.Add(writeoffreason);
                    w.SaveChanges();

                }
                catch (Exception e)
                {
                    return BadRequest();
                }
                return Ok();
            }


        }

        [HttpGet]
        [Route("GetAllWriteOffReasons2")]
        public ActionResult GetAllWriteOffReasons2()
        {
            try
            {
                List<WriteOffReason> dbWriteOffReason = _CoreDbContext.WriteOffReason.ToList();

                List<WriteOffReason> WriteOffReasonList = new List<WriteOffReason>();

                foreach (var w in dbWriteOffReason)
                {
                    WriteOffReason oreason = new WriteOffReason();

                    oreason.WriteOffReasonId = w.WriteOffReasonId;
                    oreason.WriteOffReasonDescription = w.WriteOffReasonDescription;

                    WriteOffReasonList.Add(oreason);
                }
                return Ok(WriteOffReasonList);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateWriteOffReason")]
        public ActionResult UpdateWriteOffReason(int id, WriteOffReason wvm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            using (var contextmodel = new CoreDbContext())
            {
                var existingWriteOffReason = contextmodel.WriteOffReason.Where(b => b.WriteOffReasonId == id).FirstOrDefault<WriteOffReason>();

                if (existingWriteOffReason != null)
                {
                    existingWriteOffReason.WriteOffReasonId = id;
                    existingWriteOffReason.WriteOffReasonDescription = wvm.WriteOffReasonDescription;

                    try
                    {
                        contextmodel.WriteOffReason.Update(existingWriteOffReason);
                        contextmodel.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        return BadRequest();
                    }

                }
                else

                {
                    return NotFound();
                }

            }
            return StatusCode(StatusCodes.Status200OK, "Write-off reason has been updated");

        }

        [HttpPost]
        [Route("DeleteWriteOffReasonPost")]
        public ActionResult DeleteWriteOffReasonPost(WriteOffReason wvm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {
                    var existingWriteOffReason = contextmodel.WriteOffReason.Where(b => b.WriteOffReasonId == wvm.WriteOffReasonId).FirstOrDefault<WriteOffReason>();
                    if (existingWriteOffReason != null)
                    {
                        contextmodel.WriteOffReason.Remove(existingWriteOffReason);
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
    }

}