using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class HomeViewModel
    {
        public List<Special> Specials { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}