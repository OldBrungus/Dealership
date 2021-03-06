using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dealership.Interfaces;
using Dealership.Models;

namespace Dealership.Providers
{
    public class InventoryProvider : IInventoryProvider
    {
        private IInventoryDAL _inventoryDAL;
        public InventoryProvider(IInventoryDAL inventoryDAL)
        {
            _inventoryDAL = inventoryDAL;
        }
        public List<Vehicle> GetNewOrUsedVehicles(bool isNew, string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice)
        {
            return _inventoryDAL.GetNewOrUsedVehicles(isNew, searchTerm, minYear, maxYear, minPrice, maxPrice);
        }

        public Vehicle GetVehicleByID(int vehicleID)
        {
            return _inventoryDAL.GetVehicleByID(vehicleID);
        }

        public List<Vehicle> GetVehicles(string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice)
        {
            return _inventoryDAL.GetVehicles(searchTerm, minYear, maxYear, minPrice, maxPrice);
        }

        public List<InventoryReport> GetInventoryReportRows()
        {
            return _inventoryDAL.GetInventoryReportRows();
        }
        
        public SalesReportViewModel GetSalesReport(DateTime? startDate, DateTime? endDate)
        {
            return _inventoryDAL.GetSalesReport(startDate, endDate);
        }

        public PurchaseViewModel GetPurchaseResources(int ID)
        {
            PurchaseViewModel purchaseVM = new PurchaseViewModel();
            Vehicle vehicle = _inventoryDAL.GetVehicleByID(ID);
            vehicle.PictureBase64String = Convert.ToBase64String(vehicle.Picture);
            List<State> states = _inventoryDAL.GetStates();
            List<PurchaseType> purchaseTypes = _inventoryDAL.GetPurchaseTypes();

            purchaseVM.Vehicle = vehicle;
            purchaseVM.States = states;
            purchaseVM.PurchaseTypes = purchaseTypes;

            return purchaseVM;
        }

        public void Purchase(PurchaseInfo purchase)
        {
            _inventoryDAL.Purchase(purchase);
        }

        public List<Vehicle> GetFeaturedVehicles()
        {
            List<Vehicle> vehicles = _inventoryDAL.GetFeaturedVehicles();
            foreach (var vehicle in vehicles)
            {
                vehicle.PictureBase64String = Convert.ToBase64String(vehicle.Picture);
            }

            return vehicles;
        }
    }
}