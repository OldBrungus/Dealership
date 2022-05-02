using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dealership.Models
{
    public class Special
    {
        public int SpecialID { get; set; }
        public string SpecialTitle { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}