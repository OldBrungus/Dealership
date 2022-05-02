using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class PurchaseViewModel
    {
        public int ID { get; set; }
        public Vehicle Vehicle { get; set; }
        public PurchaseInfo PurchaseInfo { get; set; }
        public List<State> States { get; set; }
        public List<PurchaseType> PurchaseTypes { get; set; }
    }
}