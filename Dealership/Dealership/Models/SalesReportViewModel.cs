using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class SalesReportViewModel
    {
        public string TotalSalesAmount { get; set; }
        public int TotalSalesCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}