using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Dealership.Factories;
using Dealership.Interfaces;
using Dealership.Models;

namespace Dealership.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryProvider _inventoryProvider = InventoryFactory.CreateInventoryProvider();

        [HttpGet]
        public ActionResult New()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            return View(vehicles);
        }

        [HttpGet]
        public ActionResult NewSearch(string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice)
        {
            List<Vehicle> vehicles = _inventoryProvider.GetNewOrUsedVehicles(/*is new*/true, searchTerm, minYear, maxYear, minPrice, maxPrice);
            return Json(vehicles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Used()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            return View(vehicles);
        }

        [HttpGet]
        public ActionResult UsedSearch(string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice)
        {
            List<Vehicle> vehicles = _inventoryProvider.GetNewOrUsedVehicles(/*is new*/false, searchTerm, minYear, maxYear, minPrice, maxPrice);
            return Json(vehicles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(int vehicleID)
        {
            Vehicle vehicle = _inventoryProvider.GetVehicleByID(vehicleID);
            return View(vehicle);
        }
    }
}