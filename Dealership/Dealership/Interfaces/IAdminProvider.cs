using Dealership.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        AppUser AddUser(AddEditUserViewModel userVM, UserManager<AppUser> userManager);
        AddEditUserViewModel GetUserByID(Guid userID);
        AddEditUserViewModel EditUser(AddEditUserViewModel userVM, UserManager<AppUser> userManager, string password, string oldRole);
        List<Make> GetMakes();
        void AddModel(string modelName, int makeID);
        void AddMake(Make make);
        List<Model> GetModels();
    }
}
