using Dealership.Factories;
using Dealership.Interfaces;
using Dealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dealership.Controllers
{
    [Authorize(Roles = "admin")]
    public class ReportsController : Controller
    {
        private IInventoryProvider _inventoryProvider = InventoryFactory.CreateInventoryProvider();

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Inventory()
        {
            List<InventoryReport> rows = _inventoryProvider.GetInventoryReportRows();
            return View(rows);
        }

        [HttpGet]
        public ActionResult Sales()
        {
            SalesReportViewModel vm = _inventoryProvider.GetSalesReport(null, null);

            return View(vm);
        }

        [HttpGet]
        public ActionResult SalesReportSearch(DateTime? startDate, DateTime? endDate)
        {
            return Json(_inventoryProvider.GetSalesReport(startDate, endDate), JsonRequestBehavior.AllowGet);
        }
    }
}