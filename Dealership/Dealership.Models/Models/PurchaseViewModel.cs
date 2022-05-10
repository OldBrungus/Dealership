using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class PurchaseViewModel
    {
        public Vehicle Vehicle { get; set; }
        public List<State> States { get; set; }
        public List<PurchaseType> PurchaseTypes { get; set; }
    }
}