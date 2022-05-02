using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class AddModelViewModel
    {
        public string ModelName { get; set; }
        public int MakeID { get; set; }
        public List<Make> Makes { get; set; }
    }
}