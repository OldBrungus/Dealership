using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dealership.Models;

namespace Dealership.Interfaces
{
    public interface IInventoryDAL
    {
        List<Vehicle> GetNewOrUsedVehicles(bool isNew, string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice);
        Vehicle AddVehicle(Vehicle vehicle);
        Vehicle GetVehicleByID(int vehicleID);
        List<Vehicle> GetVehicles(string searchTerm, int? minYear, int? maxYear, int? minPrice, int? maxPrice);
        List<BodyStyle> GetBodyStyles();
        List<Color> GetColors();
        List<Interior> GetInteriors();
        List<Make> GetMakes();
        List<Model> GetModels();
        List<TransmissionType> GetTransmissionTypes();
        void EditVehicle(EditVehicleViewModel vehicleVM);
        void DeleteVehicle(int id);
        List<InventoryReport> GetInventoryReportRows();
        void AddModel(string modelName, int makeID, string userID);
        void AddMake(Make make, string userID);
        List<State> GetStates();
        SalesReportViewModel GetSalesReport(DateTime? startDate, DateTime? endDate);
        List<PurchaseType> GetPurchaseTypes();
        void Purchase(PurchaseInfo purchase);
        List<Vehicle> GetFeaturedVehicles();
    }
}
