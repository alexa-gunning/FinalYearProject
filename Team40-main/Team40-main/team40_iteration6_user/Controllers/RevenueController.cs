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
    public class RevenueController : ControllerBase
    {
        CoreDbContext _CoreDbContext = new CoreDbContext();
        private readonly IRepository _Repository;

        public RevenueController(IRepository Repository)
        {
            _Repository = Repository;
        }

        //[HttpGet]
        //[Route("GetRevenueReport")]
        //public object GetRevenueReport()
        //{
        //    try
        //    {
        //        List<RevenueReportVM> reportlist =
        //             (from o in _CoreDbContext.Order.ToList()
        //              join p in _CoreDbContext.ProductPrice.ToList()
        //              on o.ProductId equals p.ProductId

        //              from sp in _CoreDbContext.SupplierPurchase.ToList()
                    

        //              select new RevenueReportVM
        //              {
        //                  QuantityOnHand = i.QuantityOnHand,
        //                  QuantityPurchased = sp.QuantityPurchased,
        //                  Price = sp.Price,
        //                  ItemName = i.ItemName,
        //                  total = sp.Price * sp.QuantityPurchased,
        //                  actualqty = sp.QuantityPurchased - i.QuantityOnHand


        //              }).ToList();

        //        return reportlist;


        //    }
        //    catch (Exception e)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, e.Message.ToString());
        //    }
        //}
    }
}
