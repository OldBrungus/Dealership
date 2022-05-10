using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class InventoryReport
    {
        public string Year { get; set; }
        public string MakeName { get; set; }
        public string ModelName { get; set; }
        public int Count { get; set; }
        public string StockValue { get; set; }
        public bool IsNew { get; set; }
    }
}