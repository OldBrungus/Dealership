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
    [Authorize(Roles = "sales, admin")]
    public class SalesController : Controller
    {
        private IInventoryProvider _inventoryProvider = InventoryFactory.CreateInventoryProvider();

        [HttpGet]
        public ActionResult Index()
        {
            List<Sale> sales = new List<Sale>();
            return View(sales);
        }

        [HttpGet]
        public ActionResult SalesSearch(string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice)
        {
            List<Vehicle> vehicles = _inventoryProvider.GetVehicles(searchTerm, minYear, maxYear, minPrice, maxPrice);
            return Json(vehicles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Purchase(int ID)
        {
            PurchaseViewModel purchaseVM = _inventoryProvider.GetPurchaseResources(ID);
            return View(purchaseVM);
        }

        [HttpPost]
        public void Purchase(PurchaseInfo purchase)
        {
            _inventoryProvider.Purchase(purchase);
        }
    }
}