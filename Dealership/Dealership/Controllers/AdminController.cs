using Dealership.Factories;
using Dealership.Interfaces;
using Dealership.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dealership.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private IAdminProvider _adminProvider = AdminFactory.CreateAdminProvider();
        private ISpecialsProvider _specialsProvider = SpecialsFactory.GetSpecialsProvider();
        private IInventoryProvider _inventoryProvider = InventoryFactory.CreateInventoryProvider();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Vehicles()
        {
            var vehicles = new List<Vehicle>();
            return View(vehicles);
        }

        [HttpGet]
        public ActionResult VehicleSearch(string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice)
        {
            List<Vehicle> vehicles = _inventoryProvider.GetVehicles(searchTerm, minYear, maxYear, minPrice, maxPrice);
            return Json(vehicles, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddVehicle()
        {
            AddVehicleViewModel vehicleVM = _adminProvider.GetAddVehicleResources();
            return View(vehicleVM);
        }

        [HttpPost]
        public ActionResult AddVehicle(AddVehicleViewModel vehicleVM)
        {
            if (ModelState.IsValid)
            {
                Vehicle vehicle = _adminProvider.AddVehicle(vehicleVM);
                Response.Redirect($"/Admin/EditVehicle?id={vehicle.ID}");

                return Json(true);
            }
            else
            {
                vehicleVM = _adminProvider.GetAddVehicleResources();
                return View(vehicleVM);
            }
        }

        [HttpGet]
        public ActionResult Specials()
        {
            Special special = new Special();
            return View(special);
        }

        [HttpPost]
        public void Specials(Special special)
        {
            _specialsProvider.AddSpecial(special);

            Response.Redirect("/Admin/Specials");
        }
        
        [HttpGet]
        public void DeleteSpecial(int specialID)
        {
            _specialsProvider.DeleteSpecial(specialID);

            Response.Redirect("/Admin/Specials");
        }

        [HttpGet]
        public ActionResult GetSpecialsList()
        {
            List<Special> specials = _specialsProvider.GetSpecials();

            return Json(specials, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            EditVehicleViewModel vehicleVM = _adminProvider.GetEditVehicleResources(id);

            return View(vehicleVM);
        }

        [HttpPost]
        public ActionResult EditVehicle(EditVehicleViewModel vehicleVM)
        {
            if(ModelState.IsValid)
            {
                _adminProvider.EditVehicle(vehicleVM);
                var vehicles = new List<Vehicle>();
                return View("Vehicles", vehicles);
            }
            else
            {
                vehicleVM = _adminProvider.GetEditVehicleResources(vehicleVM.ID);
                return View(vehicleVM);
            }
        }

        [HttpGet]
        public ActionResult DeleteVehicle(int id)
        {
            EditVehicleViewModel vehicleVM = _adminProvider.GetEditVehicleResources(id);
            return View("DeleteVehicle", vehicleVM);
        }

        [HttpPost]
        public void DeleteVehicle(EditVehicleViewModel vehicleVM)
        {
            _adminProvider.DeleteVehicle(vehicleVM.ID);
            Response.Redirect("/Inventory/New");
        }

        [HttpGet]
        public ActionResult AddModel()
        {
            AddModelViewModel addModelVM = new AddModelViewModel();
            addModelVM.Makes = _adminProvider.GetMakes();
            return View(addModelVM);
        }

        [HttpGet]
        public ActionResult GetModels()
        {
            List<Model> models = _adminProvider.GetModels();
            return Json(models, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void AddModel(AddModelViewModel addModelVM)
        {
            string userName = User.Identity.GetUserName();
            _adminProvider.AddModel(addModelVM.ModelName, addModelVM.MakeID, userName);
            Response.Redirect("/Admin/AddModel");
        }

        [HttpGet]
        public ActionResult GetMakes()
        {
            List<Make> makes = _adminProvider.GetMakes();
            return Json(makes, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddMake()
        {
            return View();
        }

        [HttpPost]
        public void AddMake(Make make)
        {
            string userName = User.Identity.Name;
            _adminProvider.AddMake(make, userName);

            Response.Redirect("/Admin/AddMake");
        }
    }
}