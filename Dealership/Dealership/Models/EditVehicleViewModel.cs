using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class EditVehicleViewModel
    {
        public int ID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public bool IsNew { get; set; }
        public int BodyStyleID { get; set; }
        public string Year { get; set; }
        public int TransmissionTypeID { get; set; }
        public int ColorID { get; set; }
        public int InteriorID { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public int MSRP { get; set; }
        public int SalePrice { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public HttpPostedFileBase Picture { get; set; }
        public byte[] PictureBytes { get; set; }
        public bool IsFeatured { get; set; }
        public List<BodyStyle> BodyStyles { get; set; }
        public List<Color> Colors { get; set; }
        public List<Make> Makes { get; set; }
        public List<Model> Models { get; set; }
        public List<Interior> Interiors { get; set; }
        public List<TransmissionType> TransmissionTypes { get; set; }

        public EditVehicleViewModel()
        {

        }
        public EditVehicleViewModel(Vehicle vehicle)
        {
            this.ID = vehicle.ID;
            this.MakeID = vehicle.Make.MakeID;
            this.ModelID = vehicle.Model.ModelID;
            this.IsNew = vehicle.New;
            this.BodyStyleID = vehicle.BodyStyle.BodyStyleID;
            this.Year = vehicle.Year;
            this.TransmissionTypeID = vehicle.TransmissionType.TransmissionTypeID;
            this.ColorID = vehicle.Color.ColorID;
            this.InteriorID = vehicle.Interior.InteriorID;
            this.Mileage = vehicle.Mileage;
            this.VIN = vehicle.VIN;
            this.MSRP = vehicle.MSRP;
            this.SalePrice = vehicle.SalePrice;
            this.Description = vehicle.Description;
            this.PictureBytes = vehicle.Picture;
        }
    }
}