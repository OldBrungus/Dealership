using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class PurchaseInfo
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public State State { get; set; }
        public string Zip { get; set; }
        public int PurchasePrice { get; set; }
        public PurchaseType PurchaseType { get; set; }
    }
}