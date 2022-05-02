using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class Vehicle
    {
        public int ID { get; set; }
        public bool Featured { get; set; }
        public string VIN { get; set; }
        public string Year { get; set; }
        public BodyStyle BodyStyle { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public Color Color { get; set; }
        public Interior Interior { get; set; }
        public int SalePrice { get; set; }
        public int MSRP { get; set; }
        public bool New { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public int Mileage { get; set; }
        public byte[] Picture { get; set; }
        public Make Make { get; set; }
        public Model Model { get; set; }
    }
}