using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Models;

namespace Dealership.Interfaces
{
    public interface IInventoryProvider
    {
        List<Vehicle> GetNewOrUsedVehicles(bool isNew, string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice);
        Vehicle GetVehicleByID(int vehicleID);
        List<Vehicle> GetVehicles(string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice);
        List<InventoryReport> GetInventoryReportRows();
        PurchaseViewModel GetPurchaseResources(int ID);
        SalesReportViewModel GetSalesReport(DateTime? startDate, DateTime? endDate);
        void Purchase(PurchaseInfo purchase);
        List<Vehicle> GetFeaturedVehicles();
    }
}
