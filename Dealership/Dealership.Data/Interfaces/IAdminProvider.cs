using Dealership.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Dealership.Interfaces
{
    public interface IAdminProvider
    {
        Vehicle AddVehicle(AddVehicleViewModel vehicleVM);
        AddVehicleViewModel GetAddVehicleResources();
        byte[] ConvertImageToByteArray(HttpPostedFileBase picture);
        void EditVehicle(EditVehicleViewModel vehicleVM);
        EditVehicleViewModel GetEditVehicleResources(int id);
        void DeleteVehicle(int id);
        List<Make> GetMakes();
        void AddModel(string modelName, int makeID, string userID);
        void AddMake(Make make, string userID);
        List<Model> GetModels();
    }
}
