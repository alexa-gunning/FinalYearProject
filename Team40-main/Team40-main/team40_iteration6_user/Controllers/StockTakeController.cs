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
    public class StockTakeController : ControllerBase
    {

        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public StockTakeController(IRepository Repository)
        {
            _Repository = Repository;
        }
        //-----------------------------------------STOCKTAKE CODE-------------------------------------------------//
        [HttpGet]
        //[Route("GetAllStocktakes")]
        //public ActionResult GetAllStocktakes()

        //{
        //    try
        //    {

        //        List<StockTake> dbStockTake = _CoreDbContext.StockTake.ToList();
        //        List<StockTake> StocktakeList = new List<StockTake>();

        //        foreach (var s in dbStockTake)
        //        {
        //            StockTake ostockTake = new StockTake();

        //            ostockTake.StockTakeId = s.StockTakeId;
        //            ostockTake.AdminId = s.AdminId;
        //            ostockTake.StockTakeDate = s.StockTakeDate;

        //            StocktakeList.Add(ostockTake);

        //        }
        //        return Ok(StocktakeList);
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
        //    }
        //}


        //[HttpGet]
        //[Route("GetStockTakeById")]
        //public ActionResult GetStockTakeById(int id)
        //{
        //    try
        //    {
        //        List<StockTake> dbStockTake = _CoreDbContext.StockTake.ToList();
        //        List<StockTake> StocktakeList = new List<StockTake>();


        //        foreach (var s in dbStockTake)
        //        {
        //            StockTake ostockTake = new StockTake();
        //            if (s.StockTakeId == id)
        //            {
        //                ostockTake.StockTakeId = s.StockTakeId;
        //                ostockTake.AdminId = s.AdminId;
        //                ostockTake.StockTakeDate = s.StockTakeDate;

        //                StocktakeList.Add(ostockTake);
        //            }
        //            else
        //            {
        //            }
        //        }
        //        if (StocktakeList.Count == 0)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            return Ok(StocktakeList);
        //        }


        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
        //    }

        //}



        //[HttpDelete]
        //[Route("DeleteStocktake")]
        //public ActionResult DeleteStocktake(int id, StockTake svm)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest();
        //        }

        //        using (var contextmodel = new CoreDbContext())
        //        {
        //            var existingStocktake = contextmodel.StockTake.Where(c => c.StockTakeId == id).FirstOrDefault<StockTake>();

        //            if (existingStocktake != null)

        //            {
        //                if (existingStocktake == null) return NotFound();

        //                contextmodel.StockTake.Remove(existingStocktake);
        //                contextmodel.SaveChanges();
        //            }
        //            else
        //            {
        //                return NotFound();
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
        //    }
        //    return StatusCode(StatusCodes.Status200OK, "Stock take deleted");
        //}

        //[HttpPost]
        //[Route("AddStockTake")]
        //public ActionResult AddStockTake(StockTake svm)
        //{
        //    using (var contextmodel = new CoreDbContext())
        //    {
        //        var stocktake = new StockTake
        //        {

        //            AdminId = svm.AdminId,
        //            StockTakeId = svm.StockTakeId,
        //            StockTakeDate = svm.StockTakeDate,


        //        };

        //        try
        //        {
        //            contextmodel.Add(stocktake);
        //            contextmodel.SaveChanges();
        //        }
        //        catch (Exception e)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
        //        }
        //        return Ok();

        //    }
        //}

        ////---------------------------------------------------END OF STOCKTAKE CODE----------------------------------------------------------//



        ////--------------------------------------------------STOCKTAKE TOTAL CODE-----------------------------------------------------------//

        //[HttpGet]
        //[Route("GetAllStockTakeTotals")]
        //public ActionResult GetAllStockTakeTotals()
        //{
        //    try
        //    {
        //        List<StockTakeTotal> dbStockTakeTotal = _CoreDbContext.StockTakeTotal.ToList();
        //        List<StockTakeTotal> StocktakeTotalList = new List<StockTakeTotal>();

        //        foreach (var s in dbStockTakeTotal)
        //        {
        //            StockTakeTotal ostocktaketotal = new StockTakeTotal();
        //            ostocktaketotal.StockTakeTotalId = s.StockTakeTotalId;
        //            ostocktaketotal.StockTakeTotalQty = s.StockTakeTotalQty;
        //            ostocktaketotal.StocKtakeId = s.StocKtakeId;
        //            ostocktaketotal.InventoryId = s.InventoryId;
        //            ostocktaketotal.Remarks = s.Remarks;


        //            StocktakeTotalList.Add(ostocktaketotal);
        //        }
        //        return Ok(StocktakeTotalList);
        //    }
        //    catch (Exception e)
        //    { return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString()); }
        //}

        //[HttpPost]
        //[Route("AddStockTakeTotal")] //Error because remarks haven't been added to the API
        //public ActionResult AddStockTakeTotal(StockTakeTotal svm)
        //{
        //    using (var contextmodel = new CoreDbContext())
        //    {

        //        var stocktaketotal = new StockTakeTotal
        //        {
        //            StockTakeTotalId = svm.StockTakeTotalId,
        //            StockTakeTotalQty = svm.StockTakeTotalQty,
        //            StocKtakeId = svm.StocKtakeId,
        //            InventoryId = svm.InventoryId,
        //            Remarks = svm.Remarks,
        //        };

        //        //try
        //        // {
        //        contextmodel.Add(stocktaketotal);
        //        contextmodel.SaveChanges();
        //        //}
        //        // catch (Exception e)
        //        // {
        //        //    return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
        //        //}
        //        return Ok(stocktaketotal);

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
        public ActionResult UpdateInventory(int id, decimal? quantity)
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
                        decimal? qty = quantity;
                        existingInventory.InventoryId = id;
                        existingInventory.ItemName = existingInventory.ItemName;
                        existingInventory.QuantityOnHand = qty;
                        existingInventory.LastUpdated = DateTime.Now;
                    }
                    else
                    {
                        decimal? qty = quantity;
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
        //==============================================END of Stacktotal Code================================================//

        [HttpGet]
        [Route("GetAllStocktakes")]
        public ActionResult GetAllStocktakes()

        {
            try
            {

                List<StockTake> dbStockTake = _CoreDbContext.StockTake.ToList();
                List<StockTake> StocktakeList = new List<StockTake>();

                foreach (var s in dbStockTake)
                {
                    StockTake ostockTake = new StockTake();

                    ostockTake.StockTakeId = s.StockTakeId;
                    ostockTake.AdminId = s.AdminId;
                    ostockTake.StockTakeDate = s.StockTakeDate;
                    ostockTake.Name = s.Name;
                    StocktakeList.Add(ostockTake);

                }
                return Ok(StocktakeList);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }
        }


        [HttpGet]
        [Route("GetStockTakeById")]
        public ActionResult GetStockTakeById(int id)
        {
            try
            {
                List<StockTake> dbStockTake = _CoreDbContext.StockTake.ToList();
                List<StockTake> StocktakeList = new List<StockTake>();


                foreach (var s in dbStockTake)
                {
                    StockTake ostockTake = new StockTake();
                    if (s.StockTakeId == id)
                    {
                        ostockTake.StockTakeId = s.StockTakeId;
                        ostockTake.AdminId = s.AdminId;
                        ostockTake.StockTakeDate = s.StockTakeDate;
                        ostockTake.Name = s.Name;

                        StocktakeList.Add(ostockTake);
                    }
                    else
                    {
                    }
                }
                if (StocktakeList.Count == 0)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(StocktakeList);
                }


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
            }

        }



        [HttpDelete]
        [Route("DeleteStocktake")]
        public ActionResult DeleteStocktake(int id, StockTake svm)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                using (var contextmodel = new CoreDbContext())
                {
                    var existingStocktake = contextmodel.StockTake.Where(c => c.StockTakeId == id).FirstOrDefault<StockTake>();

                    if (existingStocktake != null)

                    {
                        if (existingStocktake == null) return NotFound();

                        contextmodel.StockTake.Remove(existingStocktake);
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
            return StatusCode(StatusCodes.Status200OK, "Stock take deleted");
        }

        [HttpPost]
        [Route("AddStockTake")]
        public ActionResult AddStockTake(StockTake svm)
        {
            using (var contextmodel = new CoreDbContext())
            {
                var stocktake = new StockTake
                {

                    AdminId = svm.AdminId,
                    StockTakeId = svm.StockTakeId,
                    StockTakeDate = DateTime.Today,
                    Name = svm.Name,

                };

                try
                {
                    contextmodel.Add(stocktake);
                    contextmodel.SaveChanges();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
                }
                return Ok();

            }
        }

        //---------------------------------------------------END OF STOCKTAKE CODE----------------------------------------------------------//



        //--------------------------------------------------STOCKTAKE TOTAL CODE-----------------------------------------------------------//

        [HttpGet]
        [Route("GetAllStockTakeTotals")]
        public ActionResult GetAllStockTakeTotals()
        {
            try
            {
                List<StockTakeTotal> dbStockTakeTotal = _CoreDbContext.StockTakeTotal.ToList();
                List<StockTakeTotal> StocktakeTotalList = new List<StockTakeTotal>();

                foreach (var s in dbStockTakeTotal)
                {
                    StockTakeTotal ostocktaketotal = new StockTakeTotal();
                    ostocktaketotal.StockTakeTotalId = s.StockTakeTotalId;
                    ostocktaketotal.StockTakeTotalQty = s.StockTakeTotalQty;
                    ostocktaketotal.StocKtakeId = s.StocKtakeId;
                    ostocktaketotal.InventoryId = s.InventoryId;
                    ostocktaketotal.Remarks = s.Remarks;


                    StocktakeTotalList.Add(ostocktaketotal);
                    //UpdateInventoryAsync(s.InventoryId, s.StockTakeTotalQty);
                }
              
                return Ok(StocktakeTotalList);
            }
            catch (Exception e)
            { return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString()); }
        }

        [HttpPost]
        [Route("AddStockTakeTotal")] //Error because remarks haven't been added to the API
        public ActionResult AddStockTakeTotal(StockTakeTotal svm)
        {
            using (var contextmodel = new CoreDbContext())
            {
                var maxId = _CoreDbContext.StockTake.Max(m => m.StockTakeId) ;

                var stocktaketotal = new StockTakeTotal
                {
                    StockTakeTotalId = svm.StockTakeTotalId,
                    StockTakeTotalQty = svm.StockTakeTotalQty,
                    StocKtakeId = maxId,
                    InventoryId = svm.InventoryId,
                    Remarks = svm.Remarks,

                };

                //try
                // {
               
                contextmodel.Add(stocktaketotal);
                contextmodel.SaveChanges();
                //}
                // catch (Exception e)
                // {
                //    return StatusCode(StatusCodes.Status400BadRequest, e.InnerException.Message.ToString());
                //}
                return Ok(stocktaketotal);

            }
        }

        [HttpGet]
        [Route("GetAllStockTakeTotals2")]
        public object GetAllStockTakeTotals2()
        {
            List<StockTakeVM> stocktakelist = (
                from i in _CoreDbContext.Inventory.ToList()
                join s in _CoreDbContext.StockTakeTotal.ToList()
                on i.InventoryId equals s.InventoryId
                join w in _CoreDbContext.StockTake.ToList()
                on s.StocKtakeId equals w.StockTakeId



                select new StockTakeVM
                {
                    InventoryId = i.InventoryId,
                    itemName = i.ItemName,
                    StockTakeTotalId = s.StockTakeTotalId,
                    StockTakeId = (int)s.StocKtakeId,
                    StockTakeTotalQty = (int)s.StockTakeTotalQty,
                    Remarks = s.Remarks,
                    Name = w.Name,
                    StockTakeDate = (DateTime)w.StockTakeDate,
                }

                ).ToList();

            return stocktakelist;
        }

        //==============================================END of Stacktotal Code================================================//



        //---------------------------------------------All the other Gets for foreign keys-------------------------------------------//

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
        [HttpPut]
        [Route("UpdateStocktaketotal")]
        public ActionResult UpdateStocktaketotal(int id, StockTakeTotal svm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var contextmodel = new CoreDbContext())
            {
                var existingStocktaketotal = contextmodel.StockTakeTotal.Where(b => b.StockTakeTotalId == id).FirstOrDefault<StockTakeTotal>();
                if (existingStocktaketotal != null)
                {
                    existingStocktaketotal.StockTakeTotalId = id;
                    existingStocktaketotal.StocKtakeId = svm.StocKtakeId;
                    existingStocktaketotal.StockTakeTotalQty = svm.StockTakeTotalQty;
                    existingStocktaketotal.InventoryId = svm.InventoryId;
                    existingStocktaketotal.Remarks = svm.Remarks;
                    try
                    {
                        contextmodel.StockTakeTotal.Update(existingStocktaketotal);
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
                return Ok();
            }
        }
        [HttpPut]
        [Route("UpdateStocktake")]
        public ActionResult UpdateStocktake(int id, StockTake svm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            using (var contextmodel = new CoreDbContext())
            {
                var existingStocktake = contextmodel.StockTake.Where(b => b.StockTakeId == id).FirstOrDefault<StockTake>();
                if (existingStocktake != null)
                {
                    existingStocktake.StockTakeId = id;
                    existingStocktake.StockTakeDate = DateTime.Now;
                    existingStocktake.AdminId = svm.AdminId;
                    existingStocktake.Name = svm.Name;

                    try
                    {
                        contextmodel.StockTake.Update(existingStocktake);
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
                return Ok();
            }
        }
        //}

        //---------------------------------------------All the other Gets for foreign keys-------------------------------------------//

        [HttpGet]
        [Route("GetStocktakeTotalById")]
        public ActionResult GetStocktakeTotalById(int id)
        {
            try
            {
                List<StockTakeTotal> dbStocktake = _CoreDbContext.StockTakeTotal.ToList();
                List<StockTakeTotal> List = new List<StockTakeTotal>();

                foreach (var s in dbStocktake)
                {
                    StockTakeTotal ustocktaketotal = new StockTakeTotal();

                    if (id == s.StockTakeTotalId)
                    {
                        ustocktaketotal.StockTakeTotalId = id;
                        ustocktaketotal.Remarks = s.Remarks;
                        ustocktaketotal.StockTakeTotalQty = s.StockTakeTotalQty;
                        ustocktaketotal.StocKtakeId = s.StocKtakeId;
                        ustocktaketotal.InventoryId = s.InventoryId;


                        List.Add(ustocktaketotal);
                    }
                    else
                    {

                    }
                }

                return Ok(List);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error, please contact support");
            }
        }
    }
}