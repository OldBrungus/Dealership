using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class AddVehicleViewModel
    {
        public string VIN { get; set; }
        public string Year { get; set; }
        public int SalePrice { get; set; }
        public int MSRP { get; set; }
        public bool IsNew { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int Mileage { get; set; }
        public int BodyStyleID { get; set; }
        public int ColorID { get; set; }
        public int InteriorID { get; set; }
        public int MakeID { get; set; }
        public int ModelID { get; set; }
        public int TransmissionTypeID { get; set; }
        public HttpPostedFileBase Picture { get; set; }
        public List<BodyStyle> BodyStyles { get; set; }
        public List<Color> Colors { get; set; }
        public List<Interior> Interiors { get; set; }
        public List<Make> Makes { get; set; }
        public List<Model> Models { get; set; }
        public List<TransmissionType> TransmissionTypes { get; set; }
    }
}