using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class Sale
    {
        public int SaleID { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}