using Dealership.Interfaces;
using Dealership.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Dealership.Providers
{
    public class AdminProvider : IAdminProvider
    {
        private IInventoryDAL _inventoryDAL;
        public AdminProvider(IInventoryDAL inventoryDAL)
        {
            _inventoryDAL = inventoryDAL;
        }

        public Vehicle AddVehicle(AddVehicleViewModel vehicleVM)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.BodyStyle = new BodyStyle();
            vehicle.BodyStyle.BodyStyleID = vehicleVM.BodyStyleID;
            vehicle.Color = new Color();
            vehicle.Color.ColorID = vehicleVM.ColorID;
            vehicle.Description = vehicleVM.Description;
            vehicle.Interior = new Interior();
            vehicle.Interior.InteriorID = vehicleVM.InteriorID;
            vehicle.Make = new Make();
            vehicle.Make.MakeID = vehicleVM.MakeID;
            vehicle.Mileage = vehicleVM.Mileage;
            vehicle.Model = new Model();
            vehicle.Model.ModelID = vehicleVM.ModelID;
            vehicle.MSRP = vehicleVM.MSRP;
            vehicle.New = vehicleVM.IsNew;
            vehicle.Picture = ConvertImageToByteArray(vehicleVM.Picture);
            vehicle.SalePrice = vehicleVM.SalePrice;
            vehicle.TransmissionType = new TransmissionType();
            vehicle.TransmissionType.TransmissionTypeID = vehicleVM.TransmissionTypeID;
            vehicle.VIN = vehicleVM.VIN;
            vehicle.Year = vehicleVM.Year;

            return _inventoryDAL.AddVehicle(vehicle);
        }

        public AddVehicleViewModel GetAddVehicleResources()
        {
            AddVehicleViewModel addVehicleViewModel = new AddVehicleViewModel();

            addVehicleViewModel.BodyStyles = _inventoryDAL.GetBodyStyles();
            addVehicleViewModel.Colors = _inventoryDAL.GetColors();
            addVehicleViewModel.Interiors = _inventoryDAL.GetInteriors();
            addVehicleViewModel.Models = new List<Model>();
            addVehicleViewModel.Makes = _inventoryDAL.GetMakes();
            addVehicleViewModel.TransmissionTypes = _inventoryDAL.GetTransmissionTypes();

            return addVehicleViewModel;
        }

        public EditVehicleViewModel GetEditVehicleResources(int id)
        {
            EditVehicleViewModel vehicleVM =  new EditVehicleViewModel(_inventoryDAL.GetVehicleByID(id));

            vehicleVM.BodyStyles = _inventoryDAL.GetBodyStyles();
            vehicleVM.Colors = _inventoryDAL.GetColors();
            vehicleVM.Interiors = _inventoryDAL.GetInteriors();
            vehicleVM.Models = new List<Model>();
            vehicleVM.Makes = _inventoryDAL.GetMakes();
            vehicleVM.TransmissionTypes = _inventoryDAL.GetTransmissionTypes();

            return vehicleVM;
        }

        public void EditVehicle(EditVehicleViewModel vehicleVM)
        {
            if (vehicleVM.Picture != null)
            {
                vehicleVM.PictureBytes = ConvertImageToByteArray(vehicleVM.Picture);
            }
            
           _inventoryDAL.EditVehicle(vehicleVM);
        }

        public void DeleteVehicle(int id)
        {
            _inventoryDAL.DeleteVehicle(id);
        }

        public byte[] ConvertImageToByteArray(HttpPostedFileBase picture)
        {
            byte[] imageByte = null;
            BinaryReader reader = new BinaryReader(picture.InputStream);
            imageByte = reader.ReadBytes((int)picture.ContentLength);
            return imageByte;
        }

        public List<Make> GetMakes()
        {
            return  _inventoryDAL.GetMakes();
        }

        public void AddModel(string modelName, int makeID, string userName)
        {
            _inventoryDAL.AddModel(modelName, makeID, userName);
        }

        public void AddMake(Make make, string userName)
        {
            _inventoryDAL.AddMake(make, userName);
        }
        public List<Model> GetModels()
        {
            return _inventoryDAL.GetModels();
        }
    }
}