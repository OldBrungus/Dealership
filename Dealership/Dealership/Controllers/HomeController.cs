using Dealership.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Dealership.Interfaces;
using Dealership.Factories;

namespace Dealership.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private IContactRequestProvider _contactRequestProvider = ContactFactory.CreateContactRequestProvider();
        private ISpecialsProvider _specialsProvider = SpecialsFactory.GetSpecialsProvider();
        private IInventoryProvider _inventoryProvider = InventoryFactory.CreateInventoryProvider();

        public ActionResult Index()
        {
            HomeViewModel homeVM = new HomeViewModel();
            homeVM.Specials = _specialsProvider.GetSpecials();
            homeVM.Vehicles = _inventoryProvider.GetFeaturedVehicles();
            return View(homeVM);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            
            AppUser user = userManager.Find(model.UserName, model.Password);

            
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index", "Sales");
            }
        }

        [HttpGet]
        public ActionResult Specials()
        {
            List<Special> specials = _specialsProvider.GetSpecials();
            return View(specials);
        }
        
        [HttpGet]
        public ActionResult Contact(string VIN)
        {
            ContactRequest request = new ContactRequest();
            request.Message = "VIN#: " + VIN;

            return View(request);
        }

        [HttpPost]
        public ActionResult Contact(ContactRequest request)
        {
            if (string.IsNullOrEmpty(request.PhoneNumber) && string.IsNullOrEmpty(request.Email))
            {
                ViewBag.Message = "Either a Phone Number or an Email Address is required.";
                return View(request);
            }

            _contactRequestProvider.SubmitRequest(request);

            ViewBag.Message = "Request Submitted!";
            return View(new ContactRequest());
        }
    }
}